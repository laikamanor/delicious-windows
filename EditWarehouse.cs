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
using Newtonsoft.Json;
using DeliciousPartnerApp.API_Class.Branch;
using DeliciousPartnerApp.API_Class.Customer;
using DeliciousPartnerApp.API_Class.Warehouse;   
namespace DeliciousPartnerApp
{
    public partial class EditWarehouse : Form
    {
        public EditWarehouse()
        {
            InitializeComponent();
        }
        utility_class utilityc = new utility_class();
        branch_class branchc = new branch_class();
        customer_class customerc = new customer_class();
        warehouse_class warehousec = new warehouse_class();
        public int selectedID = 0;
        public static bool isSubmit = false;
        DataTable dtBranch = new DataTable(), dtPriceList = new DataTable(), dtCustomer = new DataTable(), dtWarehouse = new DataTable();
        private async void EditWarehouse_Load(object sender, EventArgs e)
        {
            loadBranches();
            loadColumns();
            dtWarehouse = await warehousec.returnWarehouse("", "");
            dtCustomer = customerc.loadCustomers("");
            DataTable dt = await loadData();
            foreach (DataRow row in dt.Rows)
            {
                cmbBranch.Text = findBranches(row["branch"].ToString());
                txtCode.Text = row["whsecode"].ToString();
                txtName.Text = row["whsename"].ToString();
                //Console.WriteLine(row[counter].ToString());

                for (int i = 0; i < dgvURL.Rows.Count; i++)
                {
                    string key = dgvURL.Rows[i].Cells["URLdescription"].Value.ToString().Replace(" ", "_").ToLower();
                    string rowName = findNames(dt, key);
                    if (rowName.Contains("_whse") || rowName.Contains("_account"))
                    {
                        if (key.Equals(rowName))
                        {
                            DataGridViewComboBoxCell comboCell = (DataGridViewComboBoxCell)dgvURL.Rows[i].Cells["URLCmbAction"];
                            string val = rowName.Contains("_whse") ? findWarehouseCode(row[rowName].ToString(), "whsecode", "whsename") : findCustomerCode(row[rowName].ToString(), "code", "name");

                            comboCell.Items.Add(val);
                            comboCell.Value = val;
                        }
                    }
                }
                for (int i = 0; i < dgvIs.Rows.Count; i++)
                {
                    string key = dgvIs.Rows[i].Cells["ISdescription"].Value.ToString().Replace(" ", "_").ToLower();
                    string rowName = findNames(dt, key);
                    if (rowName.Contains("is"))
                    {
                        if (key.Equals(rowName))
                        {
                            bool boolTemp = false;
                            DataGridViewCheckBoxCell checkCell = (DataGridViewCheckBoxCell)dgvIs.Rows[i].Cells["ISAction"];
                            checkCell.Value = bool.TryParse(row[rowName].ToString(), out boolTemp) ? Convert.ToBoolean(row[rowName].ToString()) : boolTemp;
                        }
                    }
                }
            }
        }

        public string findBranches(string value)
        {
            string result = "";
            if (dtBranch.Rows.Count > 0)
            {
                foreach (DataRow row in dtBranch.Rows)
                {
                    if (row["code"].ToString() == value)
                    {
                        result = row["name"].ToString();
                    }
                }
            }
            return result;
        }

        public string findNames(DataTable dt, string findValue)
        {
            string name = "";
            foreach(DataColumn dc in dt.Columns)
            {
                if (findValue.Equals(dc.ColumnName))
                {
                    name = dc.ColumnName;
                }
            }
            return name;
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
                    if (response.ErrorMessage == null)
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
                                                if (q.Key.ToLower().Substring(0, 2).Contains("is"))
                                                {
                                                    dgvIs.Rows.Add(q.Key.ToString().Replace("_", " ").ToUpper(), false);
                                                }
                                                else if (q.Value.ToString().Contains("api"))
                                                {
                                                    dgvURL.Rows.Add(q.Key.ToString().Replace("_", " ").ToUpper(), q.Value.ToString(), null);
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
                dgvURL.Rows.Add("PriceList", "/api/item/pricelist/get_all", null);
                Cursor.Current = Cursors.Default;
            }
        }

        public async void loadBranches()
        {
            //int isAdmin = 0;
            string branch = "";
            dtBranch = await branchc.returnBranches();
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

        public async Task <DataTable> loadData()
        {
            DataTable dt = new DataTable();
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
                    var request = new RestRequest("/api/whse/details/" + selectedID);
                    request.AddHeader("Authorization", "Bearer " + token);
                    Task<IRestResponse> t = client.ExecuteAsync(request);
                    t.Wait();
                    var response = await t;
                    JObject jObject = new JObject();
                    jObject = JObject.Parse(response.Content.ToString());
                    bool isSuccess = false;
                    JArray jaToData = new JArray();
                    foreach (var x in jObject)
                    {
                        if (x.Key.Equals("success"))
                        {
                            isSuccess = Convert.ToBoolean(x.Value.ToString());
                        }
                        else if (x.Key.Equals("data"))
                        {
                            JObject jo = JObject.Parse(x.Value.ToString());
                            jaToData.Add(jo);
                        }
                    }
                    if (isSuccess)
                    {
                        dt = (DataTable)JsonConvert.DeserializeObject(jaToData.ToString(), (typeof(DataTable)));
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
                Cursor.Current = Cursors.Default;
            }
            return dt;
        }

        private void dgvURL_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvURL.Rows.Count > 0)
            {
                if (e.ColumnIndex == 2)
                {
                    DataGridViewComboBoxCell combo = this.dgvURL.CurrentRow.Cells["URLcmbAction"] as DataGridViewComboBoxCell;
                    combo.Items.Clear();
                    if (e.RowIndex >= 0)
                    {
                        if (combo.Items.Count <= 0)
                        {
                            DataTable dt = new DataTable();
                            if (dgvURL.CurrentRow.Cells["URLdescription"].Value.ToString().Trim().ToLower() == "pricelist")
                            {
                                dt = loadShit(dgvURL.CurrentRow.Cells["url"].Value.ToString(), "code");
                                dtPriceList = dt;
                            }
                            else
                            {
                                dt = loadShit(dgvURL.CurrentRow.Cells["url"].Value.ToString(), dgvURL.CurrentRow.Cells["URLdescription"].Value.ToString().Replace(" ", "_").ToLower());
                            }
                            combo.Items.Add("");
                            foreach (DataRow row in dt.Rows)
                            {
                                combo.Items.Add(row["name"].ToString());
                            }
                        }
                    }
                }
            }
        }

        private void dgvURL_DataError_1(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;

        }

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
            else
            {
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
                int intTemp = 0;
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
                            string val = findCustomerCode(dgvURL.Rows[i].Cells["URLcmbAction"].Value.ToString(), "name", "code");
                            joBody.Add(keyName, string.IsNullOrEmpty(val.Trim()) ? null : val);
                        }
                        else if (dgvURL.Rows[i].Cells["URLdescription"].Value.ToString().Trim().ToLower() == "pricelist")
                        {
                            int priceListID = 0;
                            foreach (DataRow row in dtPriceList.Rows)
                            {
                                if (dgvURL.Rows[i].Cells["URLCmbAction"].Value.ToString().Trim().ToLower() == row["name"].ToString().Trim().ToLower())
                                {
                                    priceListID = Int32.TryParse(row["id"].ToString(), out intTemp) ? Convert.ToInt32(row["id"].ToString()) : intTemp;
                                    break;
                                }
                            }
                            joBody.Add("pricelist", priceListID <=0 ? (int?) null : priceListID);
                        }
                        else
                        {
                            string val = findWarehouseCode(dgvURL.Rows[i].Cells["URLcmbAction"].Value.ToString(), "whsename", "whsecode");
                            joBody.Add(keyName, string.IsNullOrEmpty(val.Trim()) ? null : val);
                        }
                    }
                }
                for (int i = 0; i < dgvIs.Rows.Count; i++)
                {
                    string keyName = dgvIs.Rows[i].Cells["ISdescription"].Value.ToString().Replace(" ", "_").ToLower();
                    bool val = false, boolTemp = false;
                    val = bool.TryParse(dgvIs.Rows[i].Cells["ISAction"].Value.ToString(), out boolTemp) ? Convert.ToBoolean(dgvIs.Rows[i].Cells["ISAction"].Value.ToString()) : false;
                    joBody.Add(keyName, !val ? (bool?)null : val);
                }
                apiPUT(joBody, "/api/whse/update/" + selectedID);
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
                    request.AddHeader("Authorization", "Bearer " + token);
                    request.Method = Method.PUT;

                    request.AddParameter("application/json", body, ParameterType.RequestBody);
                    var response = client.Execute(request);
                    if (response.ErrorMessage == null)
                    {
                        if (response.Content.Substring(0, 1).Equals("{"))
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
                            MessageBox.Show(response.Content, "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show(response.ErrorMessage, "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }


        public string findWarehouseCode(string value, string compareName, string searchName)
        {
            foreach (DataRow row in dtWarehouse.Rows)
            {
                if (row[compareName].ToString() == value)
                {
                    return row[searchName].ToString();
                }
            }
            return "";
        }

        public string findCustomerCode(string value, string compareName, string searchName)
        {
            foreach (DataRow row in dtCustomer.Rows)
            {
                if (row[compareName].ToString() == value)
                {
                    return row[searchName].ToString();
                }
            }
            return "";
        }

        public DataTable loadShit(string url, string keyName)
        {
            Cursor.Current = Cursors.WaitCursor;
            DataTable dt = new DataTable();
            dt.Columns.Add("id", typeof(int));
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
                                    int id = 0, intTemp = 0;
                                    string namee = "";
                                    foreach (var q in data)
                                    {
                                        if (keyName.ToLower().Contains("account"))
                                        {
                                            if (q.Key.Equals("id"))
                                            {
                                                id = Int32.TryParse(q.Value.ToString(), out intTemp) ? Convert.ToInt32(q.Value.ToString()) : intTemp = 0;
                                            }
                                            else if (q.Key.Equals("name"))
                                            {
                                                namee = q.Value.ToString();
                                            }
                                        }
                                        else if (keyName.ToLower().Contains("code"))
                                        {
                                            if (q.Key.Equals("id"))
                                            {
                                                id = Int32.TryParse(q.Value.ToString(), out intTemp) ? Convert.ToInt32(q.Value.ToString()) : intTemp = 0;
                                            }
                                            else if (q.Key.Equals("code"))
                                            {
                                                namee = q.Value.ToString();
                                            }
                                        }
                                        else
                                        {
                                            if (q.Key.Equals("id"))
                                            {
                                                id = Int32.TryParse(q.Value.ToString(), out intTemp) ? Convert.ToInt32(q.Value.ToString()) : intTemp = 0;
                                            }
                                            else if (q.Key.Equals("whsename"))
                                            {
                                                namee = q.Value.ToString();
                                            }
                                        }
                                    }
                                    dt.Rows.Add(id, namee);
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
    }
}
