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
    public partial class Production_ProductionOrder : Form
    {
        utility_class utilityc = new utility_class();
        warehouse_class warehousec = new warehouse_class();
        branch_class branchc = new branch_class();
        DataTable dtStatus = new DataTable();
        DataTable dtWarehouse = new DataTable();
        DataTable dtBranches = new DataTable();
        int cDtStatus = 1, cStatus = 1, cDocStatus = 1, cBranch = 1, cWarehouse = 1, cFromDate = 1, cToDate = 1, cToTime = 1, cFromTime = 1;
        public Production_ProductionOrder()
        {
            InitializeComponent();
        }

        private void Production_ProductionOrder_Load(object sender, EventArgs e)
        {
            checkToDate.Checked = true;
            dtFromDate.Value = DateTime.Now;
            dtToDate.Value = DateTime.Now;
            cmbDocStatus.SelectedIndex = 0;
            cmbFromTime.SelectedIndex = 0;
            cmbToTime.SelectedIndex = cmbToTime.Items.Count - 1;
            dtStatus.Columns.Add("data");
            Task task1 = Task.Factory.StartNew(async () => await loadBranches());
            Task task2 = Task.Factory.StartNew(async () => await loadWarehouse());
            Task.WaitAll(task1, task2);
            loadData();
            loadSearch();
            cDtStatus = 0;
            cBranch = 0;
            cWarehouse = 0;
            cStatus = 0;
            cDocStatus = 0;
            cToDate = 0;
            cFromDate = 0;
            cToTime = 0;
            cFromTime = 0;
            dgv.Columns["btnClosed"].Visible = cmbStatus.Text == "Closed" ? false : true;
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
            dtWarehouse = await Task.Run(() => warehousec.returnWarehouse(branchCode, string.IsNullOrEmpty(branchCode.Trim()) ? "?" : "&" + "is_production=1" + "is_production=1"));
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

        private void checkDate_CheckedChanged(object sender, EventArgs e)
        {
            if(cFromDate <= 0)
            {
                cDtStatus = 1;               
                dtFromDate.Visible = checkDate.Checked;
                loadData();
            }
        }

        private void checkToDate_CheckedChanged(object sender, EventArgs e)
        {
            if (cToDate <= 0)
            {
                cDtStatus = 1;
                dtToDate.Visible = checkToDate.Checked;
                loadData();
            }
        }

        private void dtFromDate_ValueChanged(object sender, EventArgs e)
        {
            if(cFromDate <= 0)
            {
                cDtStatus = 1;
                loadData();
            }
        }

        private void dtToDate_ValueChanged(object sender, EventArgs e)
        {
            if (cToDate <= 0)
            {
                cDtStatus = 1;
                loadData();
            }
        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dgv.Rows.Count > 0)
            {
                if(e.RowIndex >= 0)
                {
                    if(e.ColumnIndex == 3)
                    {
                        Production_ProductionOrder_Items items = new Production_ProductionOrder_Items();
                        items.referenceNumber = dgv.CurrentRow.Cells["reference"].Value.ToString();
                        items.selectedID = string.IsNullOrEmpty(dgv.CurrentRow.Cells["id"].Value.ToString()) ? 0 : Convert.ToInt32(dgv.CurrentRow.Cells["id"].Value.ToString());
                        items.ShowDialog();
                    }
                    else if(e.ColumnIndex==10)
                    {
                        if (dgv.CurrentRow.Cells["docstatus"].Value.ToString() == "Open")
                        {
                            Remarks remarks = new Remarks();
                            remarks.ShowDialog();
                            if (Remarks.isSubmit)
                            {
                                string rem = Remarks.rem;
                                JObject joBody = new JObject();
                                joBody.Add("remarks", rem);
                                int selectediD = string.IsNullOrEmpty(dgv.CurrentRow.Cells["id"].Value.ToString()) ? 0 : Convert.ToInt32(dgv.CurrentRow.Cells["id"].Value.ToString());
                                string URL = "/api/production/order/close/" + selectediD;
                                apiPUT(joBody, URL);
                                loadData();
                            }
                        }
                        else
                        {
                            MessageBox.Show(dgv.CurrentRow.Cells["reference"].Value.ToString() + " is already " + dgv.CurrentRow.Cells["docstatus"].Value.ToString() + "!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }else if (e.ColumnIndex == 8 || e.ColumnIndex==9)
                    {
                        isIssuedProdOrderItems items = new isIssuedProdOrderItems(e.ColumnIndex == 8 ? "Issue for Production Order" : "Receipt from Production Order");
                        items.selectedID = string.IsNullOrEmpty(dgv.CurrentRow.Cells["id"].Value.ToString()) ? 0 : Convert.ToInt32(dgv.CurrentRow.Cells["id"].Value.ToString());
                        items.ShowDialog();
                    }
                }
            }
        }

        private void cmbFromTime_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cFromTime <= 0)
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
                        if (response.Content.Substring(0, 1).Equals("{"))
                        {
                            JObject jObjectResponse = JObject.Parse(response.Content);
                            bool isSubmit = false;
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
                            MessageBox.Show(msg, "", MessageBoxButtons.OK, isSubmit ? MessageBoxIcon.Information : MessageBoxIcon.Warning);
                        }
                        else
                        {
                            MessageBox.Show(response.Content.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show(response.ErrorMessage, "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            loadData();
        }

        private async void cmbBranches_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cBranch <= 0)
            {
                cDtStatus = 1;
                await loadWarehouse();
                loadData();
            }
        }

        private void cmbWarehouse_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cWarehouse <= 0)
            {
                cDtStatus = 1;
                loadData();
            }
        }

        public void loadSearch()
        {
            cmbStatus.Items.Clear();
            if (dtStatus.Rows.Count > 0)
            {
                cmbStatus.Items.Clear();
                cmbStatus.Items.Add("All");
                DataView view = new DataView(dtStatus);
                DataTable distinctValues = view.ToTable(true, "data");
                foreach (DataRow row in distinctValues.Rows)
                {
                    cmbStatus.Items.Add(row["data"].ToString());
                }
                cmbStatus.SelectedIndex = 0;
            }
        }

        private void cmbDocStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cDocStatus <= 0)
            {
                cDtStatus = 1;
                loadData();
            }
        }

        private void cmbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cStatus <= 0)
            {
                loadData();
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

                    //di pa nalalagay
                    string sFromTime = "&from_time=" + cmbFromTime.Text;
                    string sToTime = "&to_time=" + cmbToTime.Text;

                    var request = new RestRequest("/api/production/order/get_all" + sDocStatus + sBranch + sWarehouse + sDate + sFromTime + sToTime);
                    request.AddHeader("Authorization", "Bearer " + token);
                    var response = client.Execute(request);
                    if (response.ErrorMessage == null)
                    {
                        if (response.Content.ToString().Substring(0, 1).Equals("{"))
                        {
                            JObject jObject = new JObject();
                            jObject = JObject.Parse(response.Content.ToString());
                            dgv.Rows.Clear();
                            AutoCompleteStringCollection auto = new AutoCompleteStringCollection();
                            dtStatus.Rows.Clear();
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
                                                int id = 0, issue_for_prod = 0,receipt_form_prod = 0;
                                                string referenceNumber = "", docStatus = "", sapNumber = "", remarkss = "", statuss = "", prodDate = "", sIssue= "", sReceipt = "";
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
                                                    else if (q.Key.Equals("production_date"))
                                                    {
                                                        prodDate = q.Value.ToString();
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
                                                    else if (q.Key.Equals("status"))
                                                    {
                                                        statuss = q.Value.ToString();
                                                    }
                                                    else if (q.Key.Equals("issue_for_prod"))
                                                    {
                                                        issue_for_prod = (q.Value.ToString().Trim() == "" ? 0 : Convert.ToInt32(q.Value.ToString()));
                                                        sIssue = issue_for_prod <= 0 ? "" : "View Issue For Prod. Order";

                                                    }
                                                    else if (q.Key.Equals("receipt_from_prod"))
                                                    {
                                                        receipt_form_prod = (q.Value.ToString().Trim() == "" ? 0 : Convert.ToInt32(q.Value.ToString()));
                                                        sReceipt = receipt_form_prod <= 0 ? "" : "View Receipt From Prod. Order";
                                                    }
                                                }
                                                if (cDtStatus > 0)
                                                {
                                                    dtStatus.Rows.Add(statuss);
                                                }
                                                if (cmbStatus.SelectedIndex==0 || cmbStatus.Text == "All")
                                                {
                                                    dgv.Rows.Add(id, dtTransDate.ToString("yyyy-MM-dd HH:mm"), prodDate, referenceNumber, docStatus, sapNumber, remarkss, statuss,sIssue, sReceipt, docStatus.Equals("Open") ? "Close" : "");
                                                }
                                                else
                                                {
                                                    if(cmbStatus.Text== statuss)
                                                    {
                                                        dgv.Rows.Add(id, dtTransDate.ToString("yyyy-MM-dd HH:mm"), prodDate, referenceNumber, docStatus, sapNumber, remarkss, statuss, sIssue, sReceipt, docStatus.Equals("Open") ? "Close" : "");
                                                    }
                                                    else if(cDtStatus > 0)
                                                    {
                                                        dgv.Rows.Add(id, dtTransDate.ToString("yyyy-MM-dd HH:mm"), prodDate, referenceNumber, docStatus, sapNumber, remarkss, statuss, sIssue, sReceipt, docStatus.Equals("Open") ? "Close" : "");
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                                if(cDtStatus > 0)
                                {
                                    cDtStatus = 0;
                                    loadSearch();
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
                for (int i = 0; i < dgv.Rows.Count; i++)
                {
                    if (dgv.Rows[i].Cells["docstatus"].Value.ToString() == "Open")
                    {
                        dgv.Rows[i].Cells["btnClosed"].Style.BackColor = Color.DodgerBlue;
                        dgv.Rows[i].Cells["btnClosed"].Style.ForeColor = Color.White;
                    }
                     if (dgv.Rows[i].Cells["btnIssue"].Value.ToString() != "")
                    {
                        dgv.Rows[i].Cells["btnIssue"].Style.BackColor = Color.DodgerBlue;
                        dgv.Rows[i].Cells["btnIssue"].Style.ForeColor = Color.White;
                    }
                     if (dgv.Rows[i].Cells["btnReceipt"].Value.ToString() != "")
                    {
                        dgv.Rows[i].Cells["btnReceipt"].Style.BackColor = Color.DodgerBlue;
                        dgv.Rows[i].Cells["btnReceipt"].Style.ForeColor = Color.White;
                    }
                }
                Cursor.Current = Cursors.Default;
            }
        }
    }
}
