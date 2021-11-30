using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DeliciousPartnerApp.UI_Class;
using DeliciousPartnerApp.API_Class.Branch;
namespace DeliciousPartnerApp
{
    public partial class CashVariance2 : Form
    {
        string gType = "";
        utility_class utilityc = new utility_class();
        branch_class branchc = new branch_class();
        DataTable dtBranch = new DataTable();
        int cBranch = 1, cDate = 1;
        public CashVariance2(string type)
        {
            gType = type;
            InitializeComponent();
        }

        private async void CashVariance2_Load(object sender, EventArgs e)
        {
            checkTransDate.Checked = true;
            dtDate.Value = DateTime.Now;
            await loadBranch();
            loadData();
            cBranch = 0;
            cDate = 0;
            dgv.Columns["btnUpdateSAP"].Visible = gType.Equals("Done") ? false : true;
        }

        public async Task loadBranch()
        {
            string currentBranch = "";
            bool isAdmin = false;
            cmbBranch.Items.Clear();

            //get muna whse and check kung admin , superadmin or manager
            if (Login.jsonResult != null)
            {
                foreach (var x in Login.jsonResult)
                {
                    if (x.Key.Equals("data"))
                    {
                        JObject jObjectData = JObject.Parse(x.Value.ToString());
                        foreach (var y in jObjectData)
                        {
                            if (y.Key.Equals("branch"))
                            {
                                currentBranch = y.Value.ToString();
                            }
                            else if (y.Key.Equals("isAdmin") || y.Key.Equals("isSuperAdmin") || y.Key.Equals("isManager") || y.Key.Equals("isCashier") || y.Key.Equals("isAccounting") || y.Key.Equals("isSalesAgent"))
                            {
                                isAdmin = string.IsNullOrEmpty(y.Value.ToString()) ? false : Convert.ToBoolean(y.Value.ToString());
                                if (isAdmin)
                                {
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            dtBranch = await branchc.returnBranches();
            if (isAdmin)
            {
                dtBranch = await branchc.returnBranches();
                cmbBranch.Items.Add("All");
                foreach (DataRow row in dtBranch.Rows)
                {
                    cmbBranch.Items.Add(row["name"]);
                }
            }
            else
            {
                foreach (DataRow row in dtBranch.Rows)
                {
                    if (row["code"].ToString() == currentBranch)
                    {
                        cmbBranch.Items.Add(row["name"]);
                        break;
                    }
                }
            }
            //default text 
            //kapag admin or to whse all yung lalabas
            //kapag hindi kung ano yung current whse nya yun yung lalabas
            string branchName = "";
            foreach (DataRow row in dtBranch.Rows)
            {
                if (row["code"].ToString().Trim().ToLower() == currentBranch.Trim().ToLower())
                {
                    branchName = row["name"].ToString();
                    break;
                }
            }
            cmbBranch.SelectedIndex = cmbBranch.Items.IndexOf(branchName);
        }
        public void loadData()
        {
            if (Login.jsonResult != null)
            {
                Cursor.Current = Cursors.WaitCursor;
                AutoCompleteStringCollection auto = new AutoCompleteStringCollection();
                string token = "";
                foreach (var x in Login.jsonResult)
                {
                    if (x.Key.Equals("token"))
                    {
                        token = x.Value.ToString();
                    }
                }
                if (!token.Equals(""))
                {
                    var client = new RestClient(utilityc.URL);
                    client.Timeout = -1;
                    //string branch = "A1-S";

                    //BRANCH
                    string branchCode = "";
                    foreach (DataRow row in dtBranch.Rows)
                    {
                        if (cmbBranch.Text.Equals(row["name"].ToString()))
                        {
                            branchCode = row["code"].ToString();
                            break;
                        }
                    }
                    string sBranch = string.IsNullOrEmpty(branchCode) ? "?branch=" : "?branch=" + branchCode;
                    string sDate = !checkTransDate.Checked ? "&transdate=" : "&transdate=" + dtDate.Value.ToString("yyyy-MM-dd");
                    string sNumber = gType.Equals("For SAP") ? "&ar_number=&ip_number=" : "";
                    string sDocStatus = gType.Equals("Done") ? "&docstatus=C" : "";
                    var request = new RestRequest("/api/cashvar/get_all" + sBranch + sDate + sNumber + sDocStatus);
                    Console.WriteLine("/api/cashvar/get_all" + sBranch + sDate + sNumber + sDocStatus);
                    request.AddHeader("Authorization", "Bearer " + token);
                    var response = client.Execute(request);
                    JObject jObject = new JObject();
                    jObject = JObject.Parse(response.Content.ToString());
                    dgv.Rows.Clear();
                    bool isSuccess = false;
                    foreach (var x in jObject)
                    {
                        if (x.Key.Equals("success"))
                        {
                            isSuccess = Convert.ToBoolean(x.Value.ToString());
                        }
                    }
                    if (isSuccess)
                    {
                        foreach (var x in jObject)
                        {
                            if (x.Key.Equals("data"))
                            {
                                if (x.Value.ToString() != "[]")
                                {
                                    JArray jsonArray = JArray.Parse(x.Value.ToString());
                                    for (int i = 0; i < jsonArray.Count(); i++)
                                    {
                                        JObject data = JObject.Parse(jsonArray[i].ToString());
                                        int id = 0;
                                        string referenceNumber = "", bRanch = "", arNumber = "", ipNumber = "";
                                        double systemCash = 0.00, actualCash = 0.00, vaRiance = 0.00;
                                        DateTime dtTransDate = new DateTime();
                                        foreach (var q in data)
                                        {
                                            if (q.Key.Equals("id"))
                                            {
                                                id = Convert.ToInt32(q.Value.ToString());
                                            }
                                            else if (q.Key.Equals("reference"))
                                            {
                                                referenceNumber = q.Value.ToString();
                                                auto.Add(q.Value.ToString());
                                            }
                                            else if (q.Key.Equals("branch"))
                                            {
                                                bRanch = q.Value.ToString();
                                            }
                                            else if (q.Key.Equals("system_cash"))
                                            {
                                                systemCash = Convert.ToDouble(q.Value.ToString());
                                            }
                                            else if (q.Key.Equals("actual_cash"))
                                            {
                                                actualCash = Convert.ToDouble(q.Value.ToString());
                                            }
                                            else if (q.Key.Equals("variance"))
                                            {
                                                vaRiance = Convert.ToDouble(q.Value.ToString());
                                            }
                                            else if (q.Key.Equals("ar_number"))
                                            {
                                                arNumber = q.Value.ToString();
                                            }
                                            else if (q.Key.Equals("ip_number"))
                                            {
                                                ipNumber = q.Value.ToString();
                                            }
                                            else if (q.Key.Equals("transdate"))
                                            {
                                                string replaceT = q.Value.ToString().Replace("T", "");
                                                dtTransDate = Convert.ToDateTime(replaceT);
                                            }
                                        }
                                        if (!string.IsNullOrEmpty(txtSearch.Text.ToString().Trim()))
                                        {
                                            if (txtSearch.Text.ToString().Trim().ToLower().Contains(referenceNumber.ToLower()))
                                            {
                                                dgv.Rows.Add(id, referenceNumber, dtTransDate.ToString("yyyy-MM-dd HH:mm"), Convert.ToDecimal(string.Format("{0:0.00}", systemCash)), Convert.ToDecimal(string.Format("{0:0.00}", actualCash)), Convert.ToDecimal(string.Format("{0:0.00}", vaRiance)), arNumber, ipNumber, bRanch);
                                            }
                                        }
                                        else
                                        {
                                            dgv.Rows.Add(id, referenceNumber, dtTransDate.ToString("yyyy-MM-dd HH:mm"), Convert.ToDecimal(string.Format("{0:0.00}", systemCash)), Convert.ToDecimal(string.Format("{0:0.00}", actualCash)), Convert.ToDecimal(string.Format("{0:0.00}", vaRiance)), arNumber, ipNumber, bRanch);
                                        }
                                     
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        string msg = "No message response found";
                        foreach (var x in jObject)
                        {
                            if (x.Key.Equals("message"))
                            {
                                msg = x.Value.ToString();
                            }
                        }
                        MessageBox.Show(msg, "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                txtSearch.AutoCompleteCustomSource = auto;
                Cursor.Current = Cursors.Default;
            }
        }

        private void cmbBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cBranch <= 0)
            {
                loadData();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            loadData();
        }

        private void checkTransDate_CheckedChanged(object sender, EventArgs e)
        {
            dtDate.Visible = checkTransDate.Checked;
            loadData();
        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dgv.Rows.Count > 0)
            {
                if(e.ColumnIndex== 9)
                {
                    if(e.RowIndex >= 0)
                    {
                        double variance = Convert.ToDouble(dgv.CurrentRow.Cells["variance"].Value.ToString());
                        IPRemarks ipRemarks = new IPRemarks();
                        ipRemarks.label2.Text = variance < 0 ? "*AR #: " : "*IP #: ";
                        ipRemarks.ShowDialog();
                        if (IPRemarks.isSubmit)
                        {
                            JObject body = new JObject();
                            body.Add(variance < 0 ? "ar_number" : "ip_number", IPRemarks.sap_number);
                            body.Add("remarks", string.IsNullOrEmpty(IPRemarks.rem) ? null : IPRemarks.rem);
                            string URL = "/api/sap_num/cashvar/update/" + dgv.CurrentRow.Cells["id"].Value.ToString();
                            apiPUT(body, URL);
                        }
                    }
                }
            }
        }

        public void apiPUT(JObject body, string URL)
        {
            if (Login.jsonResult != null)
            {
                string token = "";
                foreach (var x in Login.jsonResult)
                {
                    if (x.Key.Equals("token"))
                    {
                        token = x.Value.ToString();
                    }
                }
                if (!token.Equals(""))
                {
                    var client = new RestClient(utilityc.URL);
                    client.Timeout = -1;
                    var request = new RestRequest(URL);
                    Console.WriteLine(URL);
                    request.AddHeader("Authorization", "Bearer " + token);
                    request.Method = Method.PUT;

                    Console.WriteLine(body);
                    request.AddParameter("application/json", body, ParameterType.RequestBody);
                    var response = client.Execute(request);
                    if (response.ErrorMessage == null)
                    {
                        if (response.Content.ToString().Substring(0, 1).Equals("{"))
                        {
                            bool isSuccess = false;
                            JObject jObjectResponse = JObject.Parse(response.Content);
                            foreach (var x in jObjectResponse)
                            {
                                if (x.Key.Equals("success"))
                                {
                                    isSuccess = Convert.ToBoolean(x.Value.ToString());
                                    break;
                                }
                            }

                            string msg = "No message response found";
                            foreach (var x in jObjectResponse)
                            {
                                if (x.Key.Equals("message"))
                                {
                                    msg = x.Value.ToString();
                                }
                            }
                            MessageBox.Show(msg, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            if (isSuccess)
                            {
                                loadData();
                            }
                        }
                        else
                        {
                            MessageBox.Show(response.Content.ToString(), "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show(response.ErrorMessage, "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                   
                }
            }
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                loadData();
            }
        }

        private void dtDate_ValueChanged(object sender, EventArgs e)
        {
            if(cDate <= 0)
            {
                loadData();
            }
        }
    }
}
