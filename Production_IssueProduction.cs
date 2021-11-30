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
using DeliciousPartnerApp.API_Class.Warehouse;
using DeliciousPartnerApp.API_Class.Branch;
namespace DeliciousPartnerApp
{
    public partial class Production_IssueProduction : Form
    {
        public Production_IssueProduction(string type)
        {
            gType = type;
            InitializeComponent();
        }
        string gType = "";
        utility_class utilityc = new utility_class();
        branch_class branchc = new branch_class();
        warehouse_class warehousec = new warehouse_class();
        DataTable dtWarehouse = new DataTable(), dtBranches = new DataTable();
        int cDocStatus = 1, cBranch = 1, cWarehouse = 1, cFromDate = 1, cToDate = 1, cToTime = 1, cFromTime = 1;

        private async void cmbBranches_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cBranch <= 0)
            {
                await loadWarehouse();
                loadData();
            }
        }

        private void cmbWarehouse_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cWarehouse <= 0)
            {
                loadData();
            }
        }

        private void cmbDocStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cDocStatus <= 0)
            {
                loadData();
            }
        }

        private void checkDate_CheckedChanged(object sender, EventArgs e)
        {
            if (cFromDate <= 0)
            {
                dtFromDate.Visible = checkDate.Checked;
                loadData();
            }
        }

        private void checkToDate_CheckedChanged(object sender, EventArgs e)
        {
            if (cToDate <= 0)
            {
                dtToDate.Visible = checkToDate.Checked;
                loadData();
            }
        }

        private void dtFromDate_ValueChanged(object sender, EventArgs e)
        {
            if (cFromDate <= 0)
            {
                loadData();
            }
        }

        private void dtToDate_ValueChanged(object sender, EventArgs e)
        {
            if (cToDate <= 0)
            {
                loadData();
            }
        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dgv.Rows.Count > 0)
            {
                if(e.RowIndex >= 0)
                {
                    if (e.ColumnIndex == 8)
                    {
                        if(dgv.CurrentRow.Cells["btnClosed"].Value.ToString() == "Closed")
                        {

                        }
                    }
                    else if(e.ColumnIndex==2)
                    {
                        Production_IssueProduction_Items items = new Production_IssueProduction_Items(gType);
                        items.selectedID = string.IsNullOrEmpty(dgv.CurrentRow.Cells["id"].Value.ToString()) ? 0 : Convert.ToInt32(dgv.CurrentRow.Cells["id"].Value.ToString());
                        items.reference = dgv.CurrentRow.Cells["reference"].Value.ToString();
                        items.ShowDialog();
                        if (Production_IssueProduction_Items.isSubmit)
                        {
                            loadData();
                        }
                    }
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            loadData();
        }

        private void cmbFromTime_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cFromTime <= 0)
            {
                loadData();
            }
        }

        private void cmbToTime_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cToTime <= 0)
            {
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

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            loadData();
        }

        private void Production_IssueProduction_Load(object sender, EventArgs e)
        {
            dtFromDate.Visible = false;
            checkToDate.Checked = true;
            cmbDocStatus.SelectedIndex = 0;
            cmbFromTime.SelectedIndex = 0;
            cmbToTime.SelectedIndex = cmbToTime.Items.Count - 1;
            Task task1 = Task.Factory.StartNew(async () => await loadBranches());
            Task task2 = Task.Factory.StartNew(async () => await loadWarehouse());
            Task.WaitAll(task1, task2);
            loadData();
            cBranch = 0;
            cWarehouse = 0;
            cDocStatus = 0;
            cToDate = 0;
            cFromDate = 0;
            cToTime = 0;
            cFromTime = 0;
        }

        public async Task loadBranches()
        {
            int isAdmin = 0;
            string branch = "";
            dtBranches = await Task.Run(() => branchc.returnBranches());
            cmbBranches.Items.Clear();
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
                                    foreach (DataRow row in dtBranches.Rows)
                                    {
                                        if (row["code"].ToString() == branch)
                                        {
                                            cmbBranches.Items.Add(row["name"].ToString());
                                            if (cmbBranches.Items.Count > 0)
                                            {
                                                cmbBranches.SelectedIndex = 0;
                                            }
                                            return;
                                        }
                                    }
                                }
                                else
                                {
                                    isAdmin += 1;
                                    break;
                                }
                            }
                            else if (y.Key.Equals("isAccounting"))
                            {
                                if (y.Value.ToString().ToLower() == "false" || y.Value.ToString() == "")
                                {
                                    foreach (DataRow row in dtBranches.Rows)
                                    {
                                        if (row["code"].ToString() == branch && isAdmin <= 0)
                                        {
                                            cmbBranches.Items.Add(row["name"].ToString());
                                            break;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                if (cmbBranches.Items.Count <= 0)
                {
                    cmbBranches.Items.Add("All");
                    foreach (DataRow row in dtBranches.Rows)
                    {
                        cmbBranches.Items.Add(row["name"]);
                    }
                }
            }
            if (cmbBranches.Items.Count > 0)
            {
                string branchName = "";
                foreach (DataRow row in dtBranches.Rows)
                {
                    if (row["code"].ToString() == branch)
                    {
                        branchName = row["name"].ToString();
                        break;
                    }
                }
                cmbBranches.SelectedIndex = cmbBranches.Items.IndexOf(branchName);
            }
        }

        public string findCode(string value, string typee)
        {
            string result = "";
            if (typee.Equals("Warehouse"))
            {
                foreach (DataRow row in dtWarehouse.Rows)
                {
                    if (row["whsename"].ToString() == value)
                    {
                        result = row["whsecode"].ToString();
                        break;
                    }
                }
            }
            else
            {
                foreach (DataRow row in dtBranches.Rows)
                {
                    if (row["name"].ToString() == value)
                    {
                        result = row["code"].ToString();
                        break;
                    }
                }
            }
            return result;
        }

        public async Task loadWarehouse()
        {
            string branchCode = "";
            string warehouse = "";
            cmbWarehouse.Items.Clear();
            cmbWarehouse.Items.Add("All-Good");
            foreach (DataRow row in dtBranches.Rows)
            {
                if (cmbBranches.Text.Equals(row["name"].ToString()))
                {
                    branchCode = row["code"].ToString();
                    break;
                }
            }
            dtWarehouse = await Task.Run(() => warehousec.returnWarehouse(branchCode, string.IsNullOrEmpty(branchCode.Trim()) ? "?" : "&" + "is_production=1"));
            foreach (DataRow row in dtWarehouse.Rows)
            {
                cmbWarehouse.Items.Add(row["whsename"]);
            }
            if (cmbWarehouse.Items.Count > 0)
            {
                string whseName = "";
                foreach (DataRow row in dtWarehouse.Rows)
                {
                    if (row["whsecode"].ToString() == warehouse)
                    {
                        whseName = row["whsename"].ToString();
                        break;
                    }
                }
                cmbWarehouse.SelectedIndex = cmbWarehouse.Items.IndexOf(whseName);
                if (cmbWarehouse.Text == "")
                {
                    cmbWarehouse.SelectedIndex = 0;
                }
            }
        }

        public void loadData()
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
                    string sDocStatus = cmbDocStatus.SelectedIndex == 0 || cmbDocStatus.Text == "All" ? "?docstatus=" : cmbDocStatus.Text == "Open" ? "?docstatus=O" : cmbDocStatus.Text == "Closed" ? "?docstatus=C" : cmbDocStatus.Text == "Cancelled" ? "?docstatus=N" : "?doctstaus=";
                    string sBranch = "&branch=" + findCode(cmbBranches.Text, "Branch");
                    string sWarehouse = "&whsecode=" + findCode(cmbWarehouse.Text, "Warehouse");
                    string sDate = !checkDate.Checked ? "&from_date=" : "&from_date=" + dtFromDate.Value.ToString("yyyy-MM-dd");
                    sDate += !checkToDate.Checked ? "&to_date=" : "&to_date=" + dtToDate.Value.ToString("yyyy-MM-dd");
                    string sMode = "&mode=" + (gType.Equals("For SAP") ? "for_sap" : "");
                    //di pa nalalagay
                    string sFromTime = "&from_time=" + cmbFromTime.Text;
                    string sToTime = "&to_time=" + cmbToTime.Text;

                    var request = new RestRequest("/api/production/issue_for_prod/get_all" + sDocStatus + sBranch + sWarehouse + sDate + sMode + sFromTime + sToTime);
                    //Console.WriteLine("/api/production/issue_for_prod/get_all" + sDocStatus + sBranch + sWarehouse + sDate + sMode + sFromTime + sToTime);
                    request.AddHeader("Authorization", "Bearer " + token);
                    var response = client.Execute(request);
                    Console.WriteLine(response.Content);
                    if (response.ErrorMessage == null)
                    {
                        if (response.Content.ToString().Substring(0, 1).Equals("{"))
                        {
                            JObject jObject = new JObject();
                            jObject = JObject.Parse(response.Content.ToString());
                            dgv.Rows.Clear();
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
                                        if (x.Value.ToString() != "[]")
                                        {
                                            JArray jsonArray = JArray.Parse(x.Value.ToString());
                                            for (int i = 0; i < jsonArray.Count(); i++)
                                            {
                                                JObject data = JObject.Parse(jsonArray[i].ToString());
                                                int id = 0;
                                                string referenceNumber = "", docStatus = "", sapNumber = "", remarkss = "", sIsConfirmed = "", prodReference = "";
                                                bool IsConfirmed = false;
                                                DateTime dtTransDate = new DateTime();
                                                foreach (var q in data)
                                                {
                                                    if (q.Key.Equals("id"))
                                                    {
                                                        id = Convert.ToInt32(q.Value.ToString());
                                                    }
                                                    else if (q.Key.Equals("transdate"))
                                                    {
                                                        string replaceT = q.Value.ToString().Replace("T", "");
                                                        dtTransDate = Convert.ToDateTime(replaceT);
                                                    }
                                                    else if (q.Key.Equals("reference"))
                                                    {
                                                        referenceNumber = q.Value.ToString();
                                                        auto.Add(referenceNumber);
                                                    }
                                                    else if (q.Key.Equals("docstatus"))
                                                    {
                                                        docStatus = q.Value.ToString() == "O" ? "Open" : q.Value.ToString() == "N" ? "Cancelled" : q.Value.ToString() == "C" ? "Closed" : "";
                                                    }
                                                    else if (q.Key.Equals("sap_number"))
                                                    {
                                                        sapNumber = q.Value.ToString();
                                                    }
                                                    else if (q.Key.Equals("remarks"))
                                                    {
                                                        remarkss = q.Value.ToString();
                                                    }
                                                    else if (q.Key.Equals("confirm"))
                                                    {
                                                        IsConfirmed = (q.Value.ToString().Trim() == "" ? false : Convert.ToBoolean(q.Value.ToString()));
                                                        sIsConfirmed = (IsConfirmed ? "✔ " : "");
                                                    }
                                                    else if (q.Key.Equals("prod_order_ref"))
                                                    {
                                                        prodReference = q.Value.ToString();
                                                    }
                                                }
                                                if (!string.IsNullOrEmpty(txtSearch.Text.ToString().Trim()))
                                                {
                                                    if (txtSearch.Text.ToString().Trim().ToLower().Contains(referenceNumber.ToLower()))
                                                    {
                                                        dgv.Rows.Add(id, dtTransDate.ToString("yyyy-MM-dd HH:mm"), referenceNumber, docStatus, sapNumber, remarkss, sIsConfirmed, prodReference, docStatus.Equals("Open") ? "Close" : "");
                                                    }
                                                }
                                                else
                                                {
                                                    dgv.Rows.Add(id, dtTransDate.ToString("yyyy-MM-dd HH:mm"), referenceNumber, docStatus, sapNumber, remarkss, sIsConfirmed, prodReference, docStatus.Equals("Open") ? "Close" : "");
                                                }
                                            }
                                        }
                                    }
                                }
                                txtSearch.AutoCompleteCustomSource = auto;
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
                            MessageBox.Show(response.Content.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show(response.ErrorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                //for(int i = 0; i < dgv.Rows.Count; i++)
                //{
                //    if(dgv.Rows[i].Cells["docstatus"].Value.ToString() == "Closed")
                //    {
                //        dgv.Rows[i].Cells["btnClosed"].Style.BackColor = Color.Firebrick;
                //        dgv.Rows[i].Cells["btnClosed"].Style.ForeColor = Color.White;
                //    }
                //}
                Cursor.Current = Cursors.Default;
            }
        }
    }
}
