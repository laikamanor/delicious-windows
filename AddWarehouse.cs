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
using Newtonsoft.Json.Linq;
using RestSharp;
using DeliciousPartnerApp.API_Class.Customer;
using DeliciousPartnerApp.API_Class.Warehouse;
using DeliciousPartnerApp.API_Class.Pricelist;
namespace DeliciousPartnerApp
{
    public partial class AddWarehouse : Form
    {
        public AddWarehouse()
        {
            InitializeComponent();
        }
        utility_class utilityc = new utility_class();
        branch_class branchc = new branch_class();
        customer_class customerc = new customer_class();
        warehouse_class warehousec = new warehouse_class();
        pricelist_class pricelistc = new pricelist_class();
        DataTable dtBranch = new DataTable();
        DataTable dtWarehouse = new DataTable();
        DataTable dtCustomer = new DataTable();
        DataTable dtPricelist = new DataTable();
        public static bool isSubmit = false;
        int cBranch = 1;
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmbBranch.Text.Trim()))
            {
                MessageBox.Show("Branch field is required", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbBranch.Focus();
            }
            else if (string.IsNullOrEmpty(txtCode.Text.Trim()))
            {
                MessageBox.Show("Code field is required", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCode.Focus();
            }
            else if (string.IsNullOrEmpty(txtName.Text.Trim()))
            {
                MessageBox.Show("Name field is required", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
            }
            else if (!string.IsNullOrEmpty(txtSeriesCode.Text.Trim()) && string.IsNullOrEmpty(txtSeriesName.Text.Trim()))
            {
                MessageBox.Show("Series Name field is required", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSeriesName.Focus();
            }
            else if (!string.IsNullOrEmpty(txtSeriesCode.Text.Trim()) && string.IsNullOrEmpty(txtStartNum.Text.Trim()))
            {
                MessageBox.Show("Start Num field is required", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNextNum.Focus();
            }
            else if (!string.IsNullOrEmpty(txtSeriesCode.Text.Trim()) && string.IsNullOrEmpty(txtNextNum.Text.Trim()))
            {
                MessageBox.Show("Next Num field is required", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNextNum.Focus();
            }
            else if (!string.IsNullOrEmpty(txtSeriesCode.Text.Trim()) && string.IsNullOrEmpty(txtEndNum.Text.Trim()))
            {
                MessageBox.Show("End Num field is required", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEndNum.Focus();
            }
            else
            {
                JArray jaBody = new JArray();
                JObject joBody = new JObject();
                joBody.Add("whsecode", txtCode.Text.Trim());
                joBody.Add("whsename", txtName.Text.Trim());
                string branchCode = "";
                foreach (DataRow row in dtBranch.Rows)
                {
                    if (cmbBranch.Text.Trim() == row["name"].ToString())
                    {
                        branchCode = row["code"].ToString();
                        break;
                    }
                }
                joBody.Add("branch", branchCode);
                for (int i = 0; i < dgvURL.Rows.Count; i++)
                {
                    string keyName = dgvURL.Rows[i].Cells["URLdescription"].Value.ToString().Replace(" ", "_").ToLower();
                    if (dgvURL.Rows[i].Cells["URLcmbAction"].Value == null)
                    {
                        joBody.Add(keyName, null);
                    }
                    else
                    {
                        if (dgvURL.Rows[i].Cells["URLdescription"].Value.ToString().ToLower().Contains("account"))
                        {
                            joBody.Add(keyName, findCustomerCode(dgvURL.Rows[i].Cells["URLcmbAction"].Value.ToString()));
                        }
                        else if (keyName.ToLower().Equals("pricelist"))
                        {
                            joBody.Add(keyName, findPriceListID(dgvURL.Rows[i].Cells["URLcmbAction"].Value.ToString()));
                        }
                        else
                        {
                            joBody.Add(keyName, findWarehouseCode(dgvURL.Rows[i].Cells["URLcmbAction"].Value.ToString()));
                        }
                    }
                }
                for (int i = 0; i < dgvIs.Rows.Count; i++)
                {
                    string keyName = dgvIs.Rows[i].Cells["ISdescription"].Value.ToString().Replace(" ", "_").ToLower();
                    joBody.Add(keyName, Convert.ToBoolean(dgvIs.Rows[i].Cells["ISAction"].Value.ToString()));
                }
                JObject joSeries = new JObject();
                joSeries.Add("series_code", string.IsNullOrEmpty(txtSeriesCode.Text.Trim()) ? null : txtSeriesCode.Text.Trim());
                joSeries.Add("series_name", string.IsNullOrEmpty(txtSeriesName.Text.Trim()) ? null : txtSeriesName.Text.Trim());
                joSeries.Add("start_num", string.IsNullOrEmpty(txtStartNum.Text.Trim()) ? (int?)null : Convert.ToInt32(txtStartNum.Text.Trim()));
                joSeries.Add("next_num", string.IsNullOrEmpty(txtNextNum.Text.Trim()) ? (int?)null : Convert.ToInt32(txtNextNum.Text.Trim()));
                joSeries.Add("end_num", string.IsNullOrEmpty(txtEndNum.Text.Trim()) ? (int?)null : Convert.ToInt32(txtEndNum.Text.Trim()));
                joBody.Add("series", joSeries);
                jaBody.Add(joBody);
                apiPUT(jaBody, "/api/warehouse/new");
            }
        }

        public string findWarehouseCode(string value)
        {
            foreach(DataRow row in dtWarehouse.Rows)
            {
                if(row["whsename"].ToString() == value)
                {
                    return row["whsecode"].ToString();
                }
            }
            return "";
        }
        public int findPriceListID(string value)
        {
            foreach (DataRow row in dtPricelist.Rows)
            {
                if (row["code"].ToString() == value)
                {
                    return Convert.ToInt32(row["id"].ToString());
                }
            }
            return 0;
        }

        public string findCustomerCode(string value)
        {
            foreach (DataRow row in dtCustomer.Rows)
            {
                if (row["name"].ToString() == value)
                {
                    return row["code"].ToString();
                }
            }
            return "";
        }
        public void apiPUT(JArray body, string URL)
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
                    request.Method = Method.POST;

                    Console.WriteLine(body);
                    request.AddParameter("application/json", body, ParameterType.RequestBody);
                    var response = client.Execute(request);
                    if (response.ErrorMessage == null)
                    {
                        JObject jObjectResponse = JObject.Parse(response.Content);
                        foreach (var x in jObjectResponse)
                        {
                            if (x.Key.Equals("success"))
                            {
                                isSubmit = string.IsNullOrEmpty(x.Value.ToString()) ? false : Convert.ToBoolean(x.Value.ToString());
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
                        MessageBox.Show(msg, isSubmit ? "Message" : "Validation", MessageBoxButtons.OK, isSubmit ? MessageBoxIcon.Information : MessageBoxIcon.Warning);

                        if (isSubmit)
                        {
                            this.Dispose();
                        }
                    }
                    else
                    {
                        MessageBox.Show(response.ErrorMessage, "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        public void loadPriceList()
        {
            DataTable dt = pricelistc.loadData();
            if (dt.Columns.Count > 0 && dt.Rows.Count > 0)
            {
                dtPricelist = dt;
            }
        }

        public async void loadBranches()
        {
            //int isAdmin = 0;
            string branch = "";
            dtBranch = await Task.Run(() => branchc.returnBranches());
            cmbBranch.Items.Clear();
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
                                branch = y.Value.ToString();
                            }
                            else if (y.Key.Equals("isAdmin"))
                            {

                                if (y.Value.ToString().ToLower() == "false" || y.Value.ToString() == "")
                                {
                                    foreach (DataRow row in dtBranch.Rows)
                                    {
                                        if (row["code"].ToString() == branch)
                                        {
                                            cmbBranch.Items.Add(row["name"].ToString());
                                            if (cmbBranch.Items.Count > 0)
                                            {
                                                cmbBranch.SelectedIndex = 0;
                                            }
                                            return;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                if (cmbBranch.Items.Count <= 0)
                {
                    foreach (DataRow row in dtBranch.Rows)
                    {
                        cmbBranch.Items.Add(row["name"]);
                    }
                }
            }
            if (cmbBranch.Items.Count > 0)
            {
                string branchName = "";
                foreach (DataRow row in dtBranch.Rows)
                {
                    if (row["code"].ToString() == branch)
                    {
                        branchName = row["name"].ToString();
                        break;
                    }
                }
                cmbBranch.SelectedIndex = cmbBranch.Items.IndexOf(branchName);
            }
        }

        private void cmbBranch_Click(object sender, EventArgs e)
        {
            if(cBranch >0)
            {
                loadBranches();
                cBranch = 0;
            }
        }

        public void loadColumns()
        {
            if (Login.jsonResult != null)
            {
                Cursor.Current = Cursors.WaitCursor;
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
                    var request = new RestRequest("/api/branch/columns");
                    request.AddHeader("Authorization", "Bearer " + token);
                    var response = client.Execute(request);
                    if(response.ErrorMessage == null)
                    {
                        if (response.Content.Substring(0, 1).Equals("{"))
                        {
                            JObject jObject = new JObject();
                            jObject = JObject.Parse(response.Content.ToString());
                            dgvURL.Rows.Clear();
                            dgvIs.Rows.Clear();
                            AutoCompleteStringCollection auto = new AutoCompleteStringCollection();
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
                                        if (x.Value.ToString() != "{}")
                                        {
                                            JObject data = JObject.Parse(x.Value.ToString());
                                            foreach (var q in data)
                                            {
                                                if (q.Key.ToLower().Substring(0,2).Contains("is"))
                                                {
                                                    dgvIs.Rows.Add(q.Key.ToString().Replace("_", " ").ToUpper(),false);
                                                }else if (q.Value.ToString().Contains("api"))
                                                {
                                                    dgvURL.Rows.Add(q.Key.ToString().Replace("_", " ").ToUpper(), q.Value.ToString(), null);
                                                }
                                            }
                                        }
                                    }
                                }
                                dgvURL.Rows.Add("Pricelist", "/api/item/pricelist/get_all", null);
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
                Cursor.Current = Cursors.Default;
            }
        }

        public DataTable loadShit(string url,string keyName)
        {
            Cursor.Current = Cursors.WaitCursor;
            DataTable dt = new DataTable();
            dt.Columns.Add("name");
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
                var request = new RestRequest(url);
                request.AddHeader("Authorization", "Bearer " + token);
                var response = client.Execute(request);
                //Console.WriteLine(response.Content.ToString());
                JObject jObject = new JObject();
                if (response.Content.ToString().Substring(0, 1).Equals("{"))
                {
                    jObject = JObject.Parse(response.Content.ToString());
                }
                else
                {
                    MessageBox.Show(response.Content.ToString(), "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
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
                                    string namee = "";
                                    foreach (var q in data)
                                    {
                                        if (keyName.ToLower().Contains("account"))
                                        {
                                            if (q.Key.Equals("name"))
                                            {
                                                namee = q.Value.ToString();
                                            }
                                        }
                                        else if (keyName.Equals("pricelist"))
                                        {
                                            if (q.Key.Equals("code"))
                                            {
                                                namee = q.Value.ToString();
                                            }
                                        }
                                        else
                                        {
                                            if (q.Key.Equals("whsename"))
                                            {
                                                namee = q.Value.ToString();
                                            }
                                        }
                                    }
                                    dt.Rows.Add(namee);
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
                    if (msg.Equals("Token is invalid"))
                    {
                        MessageBox.Show("Your login session is expired. Please login again", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        MessageBox.Show(msg, "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            Cursor.Current = Cursors.Default;
            return dt;
        }

        private async void AddWarehouse_Load(object sender, EventArgs e)
        {
            loadColumns();
            dtWarehouse = await Task.Run(() => warehousec.returnWarehouse("", ""));
            dtCustomer = customerc.loadCustomers("");
            loadPriceList();
        }

        private void dgvURL_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dgvURL.Rows.Count> 0)
            {
                if (e.ColumnIndex == 2)
                {
                    if(e.RowIndex >= 0)
                    {
                        DataGridViewComboBoxCell combo = this.dgvURL.CurrentRow.Cells["URLcmbAction"] as DataGridViewComboBoxCell;
                        if (combo.Items.Count <= 0)
                        {
                            DataTable dt = loadShit(dgvURL.CurrentRow.Cells["url"].Value.ToString(), dgvURL.CurrentRow.Cells["URLdescription"].Value.ToString().Replace(" ", "_").ToLower());
                           foreach(DataRow row in dt.Rows)
                            {
                                combo.Items.Add(row["name"].ToString());
                            }
                        }
                    }
                }
            }
        }

        private void dgvURL_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
