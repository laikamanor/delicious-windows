using Newtonsoft.Json.Linq;
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
using RestSharp;
using DeliciousPartnerApp.API_Class.Payment_Type;
using DeliciousPartnerApp.API_Class.Customer_Type;
using DeliciousPartnerApp.API_Class.Branch;
namespace DeliciousPartnerApp
{
    public partial class forSAPIP2 : Form
    {
        utility_class utilityc = new utility_class();
        paymenttype_class paymenttypec = new paymenttype_class();
        customertype_class customertypec = new customertype_class();
        branch_class branchc = new branch_class();
        string gForType = "", gSalesType = "";
        DataTable dtPaymentTypes, dtBranches = new DataTable();
        int cPaymentType = 1, cDate = 1, cToDate = 1, cCustType = 1, cBranch = 1;
        DataTable dtCustType = new DataTable();
        public forSAPIP2(string salesType, string forType)
        {
            gForType = forType;
            gSalesType = salesType;
            InitializeComponent();
        }

        private void checkTransDate_CheckedChanged(object sender, EventArgs e)
        {
            if(cDate <= 0)
            {
                dtFromDate.Visible = checkTransDate.Checked;
                loadData();
            }
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        public bool haveSelected()
        {
            int int_result = 0;
            bool result = false;    
            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                if (Convert.ToBoolean(dgv.Rows[i].Cells["selectt"].Value.ToString()) == true)
                {
                    int_result += 1;
                }
            }
            result = int_result > 0;
            return result;
        }

        private void btnProceed_Click(object sender, EventArgs e)
        {
            if (dgv.Rows.Count <= 0)
            {
                MessageBox.Show("No data found", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }else if (!haveSelected())
            {
                MessageBox.Show("No data selected", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                JArray jarrayBody = new JArray();
                for (int i = 0; i < dgv.Rows.Count; i++)
                {
                    if (Convert.ToBoolean(dgv.Rows[i].Cells["selectt"].Value.ToString()) == true)
                    {
                        jarrayBody.Add(Convert.ToInt32(dgv.Rows[i].Cells["id"].Value));
                    }
                }
                JObject jObjectBody = new JObject();
                SAP_Remarks sAPNumber = new SAP_Remarks();
                sAPNumber.isOptional = false;
                sAPNumber.ShowDialog();
                if (SAP_Remarks.isSubmit)
                {
                    jObjectBody.Add("sap_number", SAP_Remarks.sap_number);
                    jObjectBody.Add("remarks", SAP_Remarks.rem);
                    jObjectBody.Add("ids", jarrayBody);
                    apiPUT(jObjectBody, "/api/sap_num/payment/update");
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


                    request.AddParameter("application/json", body, ParameterType.RequestBody);
                    var response = client.Execute(request);
                    Console.WriteLine(response.Content);
                    JObject jObjectResponse = JObject.Parse(response.Content);

                    foreach (var x in jObjectResponse)
                    {
                        if (x.Key.Equals("success"))
                        {
                            loadData();
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
                    MessageBox.Show(msg, "", MessageBoxButtons.OK,  MessageBoxIcon.Information);

                }
            }
        }

        public async Task loadBranch()
        {
            string currentBranch = "";
            bool isAdmin = false;
            cmbBranches.Items.Clear();

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
            dtBranches = await branchc.returnBranches();
            if (isAdmin)
            {
                dtBranches = await branchc.returnBranches();
                cmbBranches.Items.Add("All");
                foreach (DataRow row in dtBranches.Rows)
                {
                    cmbBranches.Items.Add(row["name"]);
                }
            }
            else
            {
                foreach (DataRow row in dtBranches.Rows)
                {
                    if (row["code"].ToString() == currentBranch)
                    {
                        cmbBranches.Items.Add(row["name"]);
                        break;
                    }
                }
            }
            //default text 
            //kapag admin or to whse all yung lalabas
            //kapag hindi kung ano yung current whse nya yun yung lalabas
            string branchName = "";
            foreach (DataRow row in dtBranches.Rows)
            {
                if (row["code"].ToString().Trim().ToLower() == currentBranch.Trim().ToLower())
                {
                    branchName = row["name"].ToString();
                    break;
                }
            }
            cmbBranches.SelectedIndex = cmbBranches.Items.IndexOf(branchName);
        }
        private async void forSAPIP2_Load(object sender, EventArgs e)
        {
            dgv.Columns["amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtPaymentTypes = new DataTable();
            dtFromDate.Value = DateTime.Now;
            dtToDate.Value = DateTime.Now;
            loadPaymentTypes();
            loadCustomerType();
            await loadBranch();
            cmbPaymentType.SelectedIndex = 0;
            checkTransDate.Checked = true;
            checkToDate.Checked = true;
            loadData();
            cPaymentType = 0;
            cDate = 0;
            cToDate = 0;
            cBranch = 0;
            cCustType = 0;
        }

        public void loadCustomerType()
        {
            cmbCustType.Items.Clear();
            dtCustType = customertypec.loadCustomerTypes();
            if (dtCustType.Rows.Count > 0)
            {
                cmbCustType.Items.Add("All");
                foreach (DataRow row in dtCustType.Rows)
                {
                    cmbCustType.Items.Add(row["code"].ToString());
                }
                cmbCustType.SelectedIndex = 0;
            }
        }

        private void cmbPaymentType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cPaymentType <= 0)
            {
                loadData();
            }
        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv.Rows.Count > 0)
            {
                if (e.ColumnIndex.Equals(0))
                {
                    selectData();
                }
            }
        }

        public void selectData()
        {
            if (dgv.Rows.Count > 0)
            {
                dgv.CommitEdit(DataGridViewDataErrorContexts.Commit);
                if (Convert.ToBoolean(dgv.CurrentRow.Cells["selectt"].Value.ToString()) == true)
                {
                    double amount = 0.00;
                    for (int i = 0; i < dgv.Rows.Count; i++)
                    {
                        if (Convert.ToBoolean(dgv.Rows[i].Cells["selectt"].Value.ToString()) == true)
                        {
                            amount += Convert.ToDouble(dgv.Rows[i].Cells["amount"].Value.ToString());
                        }
                    }
                    lblTotalAmount.Text = amount.ToString("n2");
                }
            }
        }

        private void checkSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            if(dgv.Rows.Count > 0)
            {
                toggleSelectAll(checkSelectAll.Checked);
                selectData();
                if (!checkSelectAll.Checked)
                {
                    lblTotalAmount.Text = "0.00";
                }
            }
            else if(dgv.Rows.Count <= 0 && checkSelectAll.Checked)
            {
                lblTotalAmount.Text = "0.00";
                MessageBox.Show("No data to select", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public void toggleSelectAll(bool value)
        {
            if (dgv.Rows.Count > 0)
            {
                for (int i = 0; i < dgv.Rows.Count; i++)
                {
                    dgv.Rows[i].Cells["selectt"].Value = value;
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            loadData();
        }
        private void dtFromDate_CloseUp(object sender, EventArgs e)
        {
            if (cDate <= 0)
            {
                loadData();
            }
        }

        private void cmbBranches_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cBranch <= 0)
            {
                loadData();
            }
        }

        private void dtToDate_CloseUp(object sender, EventArgs e)
        {
            if (cToDate <= 0)
            {
                loadData();
            }
        }

        private void cmbCustType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cCustType <= 0)
            {
                loadData();
            }
        }

        private void checkToDate_CheckedChanged(object sender, EventArgs e)
        {
           if(cToDate <= 0)
            {
                dtToDate.Visible = checkToDate.Checked;
                loadData();
            }
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                loadData();
            }
        }

        public void loadPaymentTypes()
        {
            dtPaymentTypes = paymenttypec.loadPaymentType("payment");
            cmbPaymentType.Items.Clear();
            cmbPaymentType.Items.Add("All");
            foreach (DataRow row in dtPaymentTypes.Rows)
            {
                cmbPaymentType.Items.Add(row["description"].ToString());
            }
        }

        public void loadData()
        {
            Cursor.Current = Cursors.WaitCursor;
            lblTotalAmount.Text = "0.00";
            if (Login.jsonResult != null)
            {
                string token = "", branch = "";
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
                    string sTransDate = !checkTransDate.Checked ? "?from_date=" : "?from_date=" + dtFromDate.Value.ToString("yyyy-MM-dd");
                    string sFromDate = !checkToDate.Checked ? "&to_date=" : "&to_date=" + dtToDate.Value.ToString("yyyy-MM-dd");
                    string sSalesType = string.IsNullOrEmpty(gSalesType) ? "" : "&sales_type=" + gSalesType;


                    string paymentCode = "";
                    foreach (DataRow row in dtPaymentTypes.Rows)
                    {
                        if (cmbPaymentType.SelectedIndex != 0 || !cmbPaymentType.Text.Equals("All"))
                        {
                            if (cmbPaymentType.Text.Equals(row["description"].ToString()))
                            {
                                paymentCode = row["code"].ToString();
                                break;
                            }
                        }
                    }

                    string sPaymentType = string.IsNullOrEmpty(paymentCode) ? "&payment_type=" : "&payment_type=" + paymentCode;
                    string sSearch = "&search=" + txtSearch.Text.Trim();
                    string sSAPNumber = "&sap_number=";
                    string cCustType = "";
                    if(cmbCustType.Text=="All" || cmbCustType.SelectedIndex == 0)
                    {
                        cCustType = "&cust_type=";
                    }
                    else
                    {
                        foreach(DataRow row in dtCustType.Rows)
                        {
                            if(row["code"].ToString() == cmbCustType.Text)
                            {
                                cCustType = "&cust_type=" + row["id"].ToString();
                                break;
                            }
                        }
                    }

                    foreach (DataRow row in dtBranches.Rows)
                    {
                        if (row["name"].ToString() == cmbBranches.Text)
                        {
                            branch = row["code"].ToString();
                            break;
                        }
                    }

                    var request = new RestRequest("/api/sap_num/payment/update" + sTransDate +  sFromDate +  sSalesType + sPaymentType + sSearch + sSAPNumber + cCustType + "&branch=" + branch );
                    Console.WriteLine("/api/sap_num/payment/update" + sTransDate + sFromDate+ sSalesType + sPaymentType + sSearch + sSAPNumber + cCustType + "&branch=" + branch);
                    //Console.WriteLine("/api/sap_num/payment/update" + sTransDate + sSalesType + sSalesType + sPaymentType + sSearch);
                    request.AddHeader("Authorization", "Bearer " + token);
                    var response = client.Execute(request);
                    if (response.ErrorMessage == null)
                    {
                        if (response.Content.Substring(0, 1).Equals("{"))
                        {
                            JObject jObjectResponse = JObject.Parse(response.Content);
                            bool isSuccess = false;
                            AutoCompleteStringCollection auto = new AutoCompleteStringCollection();
                            dgv.Rows.Clear();
                            foreach (var x in jObjectResponse)
                            {
                                if (x.Key.Equals("success"))
                                {
                                    isSuccess = Convert.ToBoolean(x.Value.ToString());
                                }
                            }
                            if (isSuccess)
                            {
                                foreach (var z in jObjectResponse)
                                {
                                    if (z.Key.Equals("data"))
                                    {
                                        if (z.Value.ToString() != "[]")
                                        {
                                            JArray jsonArray = JArray.Parse(z.Value.ToString());
                                            for (int i = 0; i < jsonArray.Count(); i++)
                                            {
                                                JObject jObjectData = JObject.Parse(jsonArray[i].ToString());
                                                int id = 0, paymentID = 0;
                                                string paymentType = "", customerCode = "", paymentReference = "";
                                                double amount = 0.00;
                                                DateTime dtTransDatee = new DateTime();
                                                foreach (var y in jObjectData)
                                                {
                                                    if (y.Key.Equals("id"))
                                                    {
                                                        id = Convert.ToInt32(y.Value.ToString());
                                                    }
                                                    else if (y.Key.Equals("payment_id"))
                                                    {
                                                        paymentID = Convert.ToInt32(y.Value.ToString());
                                                    }
                                                    else if (y.Key.Equals("payment_type"))
                                                    {
                                                        paymentType = y.Value.ToString();
                                                    }
                                                    else if (y.Key.Equals("cust_code"))
                                                    {
                                                        customerCode = y.Value.ToString();
                                                    }
                                                    else if (y.Key.Equals("amount"))
                                                    {
                                                        amount = Convert.ToDouble(y.Value.ToString());
                                                    }
                                                    else if (y.Key.Equals("reference"))
                                                    {
                                                        paymentReference = y.Value.ToString();
                                                    }
                                                    else if (y.Key.Equals("transdate"))
                                                    {
                                                        string replaceT = y.Value.ToString().Replace("T", "");
                                                        dtTransDatee = Convert.ToDateTime(replaceT);
                                                    }
                                                }
                                                auto.Add(customerCode);
                                                dgv.Rows.Add(false, id, paymentID, dtTransDatee.ToString("yyyy-MM-dd"), customerCode, paymentType, Convert.ToDecimal(string.Format("{0:0.00}", amount)), paymentReference);
                                            }
                                        }
                                    }
                                }
                                foreach (DataGridViewColumn col in dgv.Columns)
                                {
                                    col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                                    int colw = col.Width;
                                    col.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                                    col.Width = colw;
                                }
                                txtSearch.AutoCompleteCustomSource = auto;
                                lblCount.Text = "COUNT (" + dgv.Rows.Count.ToString("N0") + ")";
                            }
                            else
                            {
                                string msg = "";
                                foreach (var x in jObjectResponse)
                                {
                                    if (x.Key.Equals("msg"))
                                    {
                                        msg = x.Value.ToString();
                                    }
                                }
                                if (!msg.Trim().Equals(""))
                                {
                                    MessageBox.Show(msg, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show(response.Content.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show(response.ErrorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            lblNoDataFound.Visible = (dgv.Rows.Count > 0 ? false : true);
        }
    }
}
