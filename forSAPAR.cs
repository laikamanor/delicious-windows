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
using Newtonsoft.Json.Linq;

namespace DeliciousPartnerApp
{
    public partial class forSAPAR : Form
    {
        utility_class utilityc = new utility_class();
        public forSAPAR()
        {
            InitializeComponent();
        }

        private void forSAPAR_Load(object sender, EventArgs e)
        {
            loadTenderType();
           
        }

        public void loadTenderType()
        {
            Cursor.Current = Cursors.WaitCursor;
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
                    var request = new RestRequest("/api/sales/type/get_all");
                    request.AddHeader("Authorization", "Bearer " + token);
                    var response = client.Execute(request);
                    JObject jObjectResponse = JObject.Parse(response.Content);
                    cmbTenderType.Items.Clear();
                    cmbTenderType.Items.Add("All");
                    bool isSuccess = false;
                    foreach (var x in jObjectResponse)
                    {
                        if (x.Key.Equals("success"))
                        {
                            isSuccess = Convert.ToBoolean(x.Value.ToString());
                        }
                    }
                    if (isSuccess)
                    {
                        foreach (var x in jObjectResponse)
                        {
                            if (x.Key.Equals("data"))
                            {
                                if (x.Value.ToString() != "[]")
                                {
                                    JArray jArrayData = JArray.Parse(x.Value.ToString());
                                    for (int i = 0; i < jArrayData.Count(); i++)
                                    {
                                        JObject jObjectData = JObject.Parse(jArrayData[i].ToString());
                                        foreach (var y in jObjectData)
                                        {
                                            if (y.Key.Equals("code"))
                                            {
                                                cmbTenderType.Items.Add(y.Value.ToString());
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        cmbTenderType.SelectedIndex = cmbTenderType.Items.IndexOf("AR Sales");
                    }
                    else
                    {
                        string msg = "No message response found";
                        foreach (var x in jObjectResponse)
                        {
                            if (x.Key.Equals("message"))
                            {
                                msg = x.Value.ToString();
                            }
                        }
                        if (msg.Equals("Token is invalid"))
                        {
                            Cursor.Current = Cursors.Default;
                            MessageBox.Show("Your login session is expired. Please login again", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {
                            Cursor.Current = Cursors.Default;
                            MessageBox.Show(msg, "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            Cursor.Current = Cursors.Default;
        }

        public void loadData()
        {
            checkSelectAll.Checked = false;
            Cursor.Current = Cursors.WaitCursor;
            if (Login.jsonResult != null)
            {
                string token = "", branch = "";
                foreach (var x in Login.jsonResult)
                {
                    if (x.Key.Equals("token"))
                    {
                        token = x.Value.ToString();
                    }
                    else if (x.Key.Equals("data"))
                    {
                        JObject jObjectData = JObject.Parse(x.Value.ToString());
                        foreach (var y in jObjectData)
                        {
                            if (y.Key.Equals("branch"))
                            {
                                branch = y.Value.ToString();
                            }
                        }
                    }
                }
                if (!token.Equals(""))
                {
                    var client = new RestClient(utilityc.URL);
                    client.Timeout = -1;
                    var request = new RestRequest("/api/sales/for_sap/get_all?date=" + dtDate.Value.ToString("yyyy-MM-dd") + "&branch=" + branch + "&transtype=" + (cmbTenderType.SelectedIndex <= 0 ? "" : cmbTenderType.Text) + "&cust_code=" + txtSearch.Text);
                    request.AddHeader("Authorization", "Bearer " + token);
                    var response = client.Execute(request);
                    Console.WriteLine(response.Content);
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
                                        int id = 0, transNumber = 0;
                                        string referenceNumber = "", customerCode = "", tenderType = "";
                                        double documentTotal = 0.00, amountDue = 0.00;
                                        DateTime dtTransDate = new DateTime();
                                        foreach (var y in jObjectData)
                                        {
                                            if (y.Key.Equals("id"))
                                            {
                                                id = Convert.ToInt32(y.Value.ToString());
                                            }else if (y.Key.Equals("transnumber"))
                                            {
                                                transNumber = Convert.ToInt32(y.Value.ToString());
                                            }
                                            else if (y.Key.Equals("transnumber"))
                                            {
                                                transNumber = Convert.ToInt32(y.Value.ToString());
                                            }
                                            else if (y.Key.Equals("reference"))
                                            {
                                                referenceNumber = y.Value.ToString();
                                            }
                                            else if (y.Key.Equals("cust_code"))
                                            {
                                                customerCode = y.Value.ToString();
                                            }
                                            else if (y.Key.Equals("doctotal"))
                                            {
                                                documentTotal = Convert.ToDouble(y.Value.ToString());
                                            }
                                            else if (y.Key.Equals("amount_due"))
                                            {
                                                amountDue = Convert.ToDouble(y.Value.ToString());
                                            }
                                            else if (y.Key.Equals("transtype"))
                                            {
                                                tenderType = y.Value.ToString();
                                            }
                                            else if (y.Key.Equals("transdate"))
                                            {
                                                string replaceT = y.Value.ToString().Replace("T","");
                                                dtTransDate = Convert.ToDateTime(replaceT);
                                            }
                                            auto.Add(customerCode);
                                        }
                                        dgv.Rows.Add(false, id, transNumber, referenceNumber, customerCode, documentTotal.ToString("n2"), amountDue.ToString("n2"), tenderType, dtTransDate.ToString("yyyy-MM-dd HH:mm tt"));
                                    }
                                }
                            }
                        }
                    }
                    txtSearch.Refresh();
                    txtSearch.AutoCompleteCustomSource = auto;
                }
            }
            lblNoDataFound.Visible = (dgv.Rows.Count > 0 ? false : true);
        }

        private void cmbTenderType_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadData();
        }

        private void dtDate_ValueChanged(object sender, EventArgs e)
        {
            loadData();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            loadData();
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                loadData();
            }
        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dgv.Rows.Count > 0)
            {
                if(e.ColumnIndex==0 && e.RowIndex >= 0)
                {
                    dgv.CommitEdit(DataGridViewDataErrorContexts.Commit);
                    string ids = "";
                    int int_selectAll = 0;
                    for (int i = 0; i < dgv.Rows.Count; i++)
                    {
                        if (Convert.ToBoolean(dgv.Rows[i].Cells["selectt"].Value.ToString()) == true)
                        {   
                            ids = ids + "," + dgv.Rows[i].Cells["base_id"].Value.ToString();
                            int_selectAll += 1;
                        }
                    }
                    ids = (string.IsNullOrEmpty(ids) ? "" : ids.Substring(1));
                    if(int_selectAll <= 0 && checkSelectAll.Checked) 
                    {
                        checkSelectAll.Checked = false;
                    }

                }
            }
        }

        private void checkSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            toggleSelectAll(checkSelectAll.Checked);
        }

        public void toggleSelectAll(bool value)
        {
            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                dgv.Rows[i].Cells["selectt"].Value = value;
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            string ids = "";
            int int_hasSelected = 0;
            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                if (Convert.ToBoolean(dgv.Rows[i].Cells["selectt"].Value.ToString()) == true)
                {
                    ids = ids + "," + dgv.Rows[i].Cells["base_id"].Value.ToString();
                    int_hasSelected += 1;
                }
            }
            ids = (string.IsNullOrEmpty(ids) ? "" : ids.Substring(1));
            if (int_hasSelected > 0)
            {
                forSAPAR_Items forSAPARItems = new forSAPAR_Items();
                forSAPARItems.ids = ids;
                forSAPARItems.ShowDialog();
                if (forSAPAR_Items.isSubmit)
                {
                    loadData();
                }
            }
            else if (dgv.Rows.Count <= 0)
            {
                MessageBox.Show("No data found", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show("No data selected", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
