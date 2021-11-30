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
using DeliciousPartnerApp.API_Class.Warehouse;
namespace DeliciousPartnerApp
{
    public partial class AddActualCash : Form
    {
        public AddActualCash()
        {
            InitializeComponent();
        }
        utility_class utilityc = new utility_class();
        branch_class branchc = new branch_class();
        warehouse_class warehousec = new warehouse_class();
        DataTable dtBranches = new DataTable();
        DataTable dtWarehouse = new DataTable();
        int cBranch = 1;
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to submit?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                insertActualCash();
            }
        }

        public async Task loadBranches()
        {
            bool isAdmin = false;
            string branch = "";
            string currentBranch = "";
            dtBranches = await Task.Run(() => branchc.returnBranches());
            cmbBranches.Items.Clear(); ;
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
                                branch = y.Value.ToString();
                            }
                            else if (y.Key.Equals("isAdmin") || y.Key.Equals("isSuperAdmin") || y.Key.Equals("isAccounting") || y.Key.Equals("isManager"))
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

                foreach (DataRow row in dtBranches.Rows)
                {
                    if (row["code"].ToString() == branch)
                    {
                        currentBranch = row["name"].ToString();
                    }
                }
                if (isAdmin)
                {
                    foreach (DataRow row in dtBranches.Rows)
                    {
                        cmbBranches.Items.Add(row["name"].ToString());
                    }
                }
                else
                {
                    cmbBranches.Items.Add(currentBranch);
                }
                cmbBranches.SelectedIndex = cmbBranches.Items.IndexOf(currentBranch);
            }
        }

        public async void loadWarehouse()
        {
            bool isAdmin = false;
            string whse = "", branch = "";
            cmbWarehouse.Items.Clear();

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
                            if (y.Key.Equals("whse"))
                            {
                                whse = y.Value.ToString();
                            }
                            else if (y.Key.Equals("isAdmin") || y.Key.Equals("isSuperAdmin") || y.Key.Equals("isAccounting") || y.Key.Equals("isManager"))
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

            //kunin yung branch code ng combobox branch text
            foreach (DataRow row in dtBranches.Rows)
            {
                if (row["name"].ToString() == cmbBranches.Text)
                {
                    branch = row["code"].ToString();
                    break;
                }
            }
            // kunin warehouse base kung to or from whse
            dtWarehouse = await Task.Run(() => warehousec.returnWarehouse(branch, ""));
            //kapag admin kunin lahat ng warehouse 
            // kapag di admin kukunin lang yung current wareheouse nya
            if (isAdmin)
            {
                foreach (DataRow row in dtWarehouse.Rows)
                {
                    cmbWarehouse.Items.Add(row["whsename"]);
                }
            }
            else
            {
                string currentWhse = "";
                foreach (DataRow row in dtWarehouse.Rows)
                {
                    if (row["whsecode"].ToString() == whse)
                    {
                        currentWhse = row["whsename"].ToString();
                    }
                }
                cmbWarehouse.Items.Add(currentWhse);
            }
            //default text 
            //kapag admin or to whse all yung lalabas
            //kapag hindi kung ano yung current whse nya yun yung lalabas
            string whseName = "";
            foreach (DataRow row in dtWarehouse.Rows)
            {
                if (row["whsecode"].ToString() == whse)
                {
                    whseName = row["whsename"].ToString();
                    break;
                }
            }
            cmbWarehouse.SelectedIndex = cmbWarehouse.Items.IndexOf(whseName);
        }

        public void insertActualCash()
        {
            if (string.IsNullOrEmpty(txtActualCash.Text.Trim()))
            {
                MessageBox.Show("Actual Cash field is required", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (Convert.ToDouble(txtActualCash.Text.Trim()) <= 0)
            {
                MessageBox.Show("Please enter Actual Cash atleast 1!", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (string.IsNullOrEmpty(cmbBranches.Text.Trim()))
            {
                MessageBox.Show("Branch field is required", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbBranches.Focus();
            }
            else if (string.IsNullOrEmpty(cmbWarehouse.Text.Trim()))
            {
                MessageBox.Show("Warehouse field is required", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbWarehouse.Focus();
            }
            else
            {
                string selectedBranch = findCode("name", "code", cmbBranches.Text, dtBranches),
                   selectedWarehouse = findCode("whsename", "whsecode", cmbWarehouse.Text, dtWarehouse);

                JObject joBody = new JObject();
                joBody.Add("actual_cash", Convert.ToDouble(txtActualCash.Text.Trim()));
                joBody.Add("branch", selectedBranch);
                joBody.Add("whse", selectedWarehouse);
                joBody.Add("transdate", dateTimePicker1.Value.ToString("yyyy-MM-dd"));
                string URL = "/api/report/actual_cash/add";
                apiPOST(joBody, URL);
            }
        }

        public string findCode(string findName, string findCode, string text, DataTable dt)
        {
            string result = "";
            foreach (DataRow row in dt.Rows)
            {
                if (row[findName].ToString() == text)
                {
                    result = row[findCode].ToString();
                    break;
                }
            }
            return result;
        }

        public void apiPOST(JObject body, string URL)
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
                        bool isSubmit = false;
                        foreach (var x in jObjectResponse)
                        {
                            if (x.Key.Equals("success"))
                            {
                                isSubmit = Convert.ToBoolean(x.Value.ToString());
                                break;
                            }
                        }

                        string msg = "No message response found";
                        foreach (var x in jObjectResponse)
                        {
                            if (x.Key.Equals("message"))
                            {
                                msg = x.Value.ToString();
                                break;
                            }
                        }
                        MessageBox.Show(msg, isSubmit ? "Success" : "Validation", MessageBoxButtons.OK, isSubmit ? MessageBoxIcon.Information : MessageBoxIcon.Warning);

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

        private async void AddActualCash_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Value = DateTime.Now;
            txtActualCash.Focus();
            await loadBranches();
            loadWarehouse();
            cBranch = 0;
        }

        private void txtActualCash_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)
   && !char.IsDigit(e.KeyChar)
   && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if (e.KeyChar == '.'
                && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }

        private void txtActualCash_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                insertActualCash();
            }
        }

        private void cmbBranches_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cBranch <= 0)
            {
                loadWarehouse();
            }
        }
    }
}
