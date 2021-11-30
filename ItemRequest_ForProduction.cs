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
    public partial class ItemRequest_ForProduction : Form
    {
        public ItemRequest_ForProduction()
        {
            InitializeComponent();
        }
        utility_class utilityc = new utility_class();
        warehouse_class warehousec = new warehouse_class();
        branch_class branchc = new branch_class();
        int cCheck = 0, cBranch = 1, cPodWhse = 1, cReqWhse = 1, cToDate = 1, cFromDate = 1;
        DataTable dtReqWhse = new DataTable(), dtProdWhse = new DataTable(), dtBranches = new DataTable();
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        public async Task loadWarehouses(bool value, ComboBox cmb)
        {
            cmb.Items.Clear();
            string ownWhse = "";
            if (value)
            {
                dtReqWhse = new DataTable();
                cmb.Items.Add("All");
                dtReqWhse = await Task.Run(() => warehousec.returnWarehouse("", ""));
                foreach (DataRow row in dtReqWhse.Rows)
                {
                    cmb.Items.Add(row["whsename"].ToString());
                }
            }
            else
            {
                string branchCode = findCode(dtBranches, cmbBranches.Text, "name", "code");
                dtProdWhse = await Task.Run(() => warehousec.returnWarehouse(branchCode, string.IsNullOrEmpty(branchCode.Trim()) ? "?" : "&" + "is_production=1"));
                cmb.Items.Add("All");
                foreach (DataRow row in dtProdWhse.Rows)
                {
                    cmb.Items.Add(row["whsename"].ToString());
                }
            }
            if (cmb.Items.Count > 0 && !value)
            {
                string whseName = "";
                foreach (DataRow row in dtReqWhse.Rows)
                {
                    if (row["whsecode"].ToString() == ownWhse)
                    {
                        whseName = row["whsename"].ToString();
                        break;
                    }
                }
                cmb.SelectedIndex = cmb.Items.IndexOf(whseName);
                if (cmb.Text == "")
                {
                    cmb.SelectedIndex = 0;
                }
            }
            else if (cmb.Items.Count > 0 && value)
            {
                cmb.SelectedIndex = 0;
            }
        }

        public string findCode(DataTable dt, string value, string findWord,string resultWord)
        {
            string result = "";
            foreach (DataRow row in dt.Rows)
            {
                if (row[findWord].ToString() == value)
                {
                    result = row[resultWord].ToString();
                    break;
                }
            }
            return result;
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
                    string sBranch = "?branch=" + findCode(dtBranches, cmbBranches.Text, "name", "code");
                    string sProdWhse = "&from_whse=" + findCode(dtProdWhse, cmbProdWhse.Text, "whsename", "whsecode");
                    string sReqWhse = "&to_whse=" + findCode(dtReqWhse, cmbRequestorWhse.Text, "whsename", "whsecode");
                    string sFromDate = !checkDate.Checked ? "&from_date=" : "&from_date=" + dtFromDate.Value.ToString("yyyy-MM-dd");
                    string sToDate = !checkToDate.Checked ? "&to_date=" : "&to_date=" + dtToDate.Value.ToString("yyyy-MM-dd");
                    var request = new RestRequest("/api/inv/item_request/for_production/get_all" + sBranch + sProdWhse + sReqWhse + sFromDate + sToDate);
                    Console.WriteLine("hehe: " + "/api/inv/item_request/for_production/get_all" + sBranch + sProdWhse + sReqWhse + sFromDate + sToDate);
                    request.AddHeader("Authorization", "Bearer " + token);
                    var response = client.Execute(request);
                    JObject jObject = new JObject();
                    jObject = JObject.Parse(response.Content.ToString());
                    //Console.WriteLine(response.Content.ToString());
                    dgvOrders.Rows.Clear();
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
                                        int id = 0, seriesID = 0, transNumber = 0;
                                        string seriesCode = "", docStatus = "", referenceNumber = "", referenceNumber2 = "";
                                        DateTime dtTransDate = new DateTime(),
                                            dtDueDate = new DateTime();
                                        foreach (var q in data)
                                        {
                                            if (q.Key.Equals("id"))
                                            {
                                                id = Convert.ToInt32(q.Value.ToString());
                                            }
                                            else if (q.Key.Equals("series"))
                                            {
                                                seriesID = Convert.ToInt32(q.Value.ToString());
                                            }
                                            else if (q.Key.Equals("seriescode"))
                                            {
                                                seriesCode = q.Value.ToString();
                                            }
                                            else if (q.Key.Equals("transnumber"))
                                            {
                                                transNumber = Convert.ToInt32(q.Value.ToString());
                                            }
                                            else if (q.Key.Equals("docstatus"))
                                            {
                                                docStatus = q.Value.ToString();
                                            }
                                            else if (q.Key.Equals("reference"))
                                            {
                                                referenceNumber = q.Value.ToString();
                                            }
                                            else if (q.Key.Equals("transdate"))
                                            {
                                                string replaceT = q.Value.ToString().Replace("T", "");
                                                dtTransDate = Convert.ToDateTime(replaceT);
                                            }
                                            else if (q.Key.Equals("duedate"))
                                            {
                                                string replaceT = q.Value.ToString().Replace("T", "");
                                                dtDueDate = Convert.ToDateTime(replaceT);
                                            }
                                            else if (q.Key.Equals("reference2"))
                                            {
                                                referenceNumber2= q.Value.ToString();
                                            }
                                        }
                                        auto.Add(referenceNumber);
                                        if (!string.IsNullOrEmpty(txtSearch.Text.ToString().Trim()))
                                        {
                                            if (txtSearch.Text.ToString().Trim().ToLower().Contains(referenceNumber.ToLower()))
                                            {
                                                dgvOrders.Rows.Add(false, id, seriesID, seriesCode, transNumber, docStatus, referenceNumber, dtTransDate.ToString("yyyy-MM-dd HH:mm"), dtDueDate.ToString("yyyy-MM-dd"), referenceNumber2);
                                            }
                                        }
                                        else
                                        {
                                            dgvOrders.Rows.Add(false, id, seriesID, seriesCode, transNumber, docStatus, referenceNumber, dtTransDate.ToString("yyyy-MM-dd HH:mm"), dtDueDate.ToString("yyyy-MM-dd"), referenceNumber2);
                                        }
                                    }
                                }
                            }
                        }
                        lblOrderCount.Text = "TRANSACTIONS (" + dgvOrders.Rows.Count.ToString("N0") + ")";
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
                lblNoDataFound.Visible = (dgvOrders.Rows.Count > 0 ? false : true);
            }
        }

        public async void loadBranches()
        {
            dtBranches = await Task.Run(() => branchc.returnBranches());
            if (dtBranches.Rows.Count > 0)
            {
                cmbBranches.Items.Add("All");
                foreach(DataRow row in dtBranches.Rows)
                {
                    cmbBranches.Items.Add(row["name"].ToString());
                }
                cmbBranches.SelectedIndex = 0;
            }
        }

        private async void ItemRequest_ForProduction_Load(object sender, EventArgs e)
        {
            dgvitems.Columns["item"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            loadBranches();
            await loadWarehouses(true, cmbRequestorWhse);
            await loadWarehouses(false, cmbProdWhse);
            loadData();
            cCheck = 0;
            cBranch = 0;
            cReqWhse = 0;
            cPodWhse = 0;
            cToDate = 0;
            cFromDate = 0;
        }

        private void btnsearch_Click(object sender, EventArgs e)
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

        private void dgvOrders_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvOrders.Rows.Count > 0)
            {
                if (e.ColumnIndex == 0)
                {
                    selectOrders(false);
                }
            }
        }

        public void selectOrders(bool value)
        {
            Cursor.Current = Cursors.WaitCursor;
            //DataTable dt = new DataTable();
            if (Login.jsonResult != null)
            {
                dgvitems.Rows.Clear();
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
                    dgvOrders.CommitEdit(DataGridViewDataErrorContexts.Commit);
                    if (value)
                    {
                        for (int i = 0; i < dgvOrders.Rows.Count; i++)
                        {
                            dgvOrders.Rows[i].Cells["selectt"].Value = checkSelect.Checked;
                        }
                    }
                    else
                    {
                        int isCheckAll_int = 0;
                        for (int i = 0; i < dgvOrders.Rows.Count; i++)
                        {
                            if (Convert.ToBoolean(dgvOrders.Rows[i].Cells["selectt"].Value.ToString()) == true)
                            {
                                isCheckAll_int += 1;
                            }
                        }
                        if (checkSelect.Checked && !isCheckAll_int.Equals(dgvOrders.Rows.Count))
                        {
                            cCheck = 1;
                            checkSelect.Checked = false;
                        }
                        else if (!checkSelect.Checked && isCheckAll_int.Equals(dgvOrders.Rows.Count))
                        {
                            checkSelect.Checked = true;
                        }
                    }

                    string ids = "";
                    for (int i = 0; i < dgvOrders.Rows.Count; i++)
                    {
                        if (Convert.ToBoolean(dgvOrders.Rows[i].Cells["selectt"].Value.ToString()) == true)
                        {
                            //totalPendingAmount += Convert.ToDouble(dgvOrders.Rows[i].Cells["amountdue"].Value.ToString());
                            ids = ids + "," + dgvOrders.Rows[i].Cells["id"].Value.ToString();
                        }
                    }
                    ids = (string.IsNullOrEmpty(ids) ? "" : ids.Substring(1));
                    dgvitems.Rows.Clear();
                    string sDate = checkDate.Checked ? "from_date=" + dtFromDate.Value.ToString("yyyy-MM-dd") : "";
                    var client = new RestClient(utilityc.URL);
                    client.Timeout = -1;
                    var request = new RestRequest("/api/inv/item_request/for_production/details?ids=%5B" + ids + "%5D");
                    request.AddHeader("Authorization", "Bearer " + token);
                    request.Method = Method.GET;
                    var response = client.Execute(request);
                    if (response.ErrorMessage == null)
                    {
                        JObject jObject = new JObject();
                        jObject = JObject.Parse(response.Content.ToString());
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
                                        JArray jArrayRow = JArray.Parse(x.Value.ToString());
                                        for (int i = 0; i < jArrayRow.Count(); i++)
                                        {
                                            JObject data = JObject.Parse(jArrayRow[i].ToString());
                                            String itemName = "", fromWhse = "", toWhse = "";
                                            int quantity = 0;
                                            foreach (var z in data)
                                            {
                                                if (z.Key.Equals("item_code"))
                                                {
                                                    itemName = z.Value.ToString();
                                                }
                                                else if (z.Key.Equals("quantity"))
                                                {
                                                    quantity = Convert.ToInt32(z.Value.ToString());
                                                }
                                                else if (z.Key.Equals("from_whse"))
                                                {
                                                    fromWhse = z.Value.ToString();
                                                }
                                                else if (z.Key.Equals("to_whse"))
                                                {
                                                    toWhse = z.Value.ToString();
                                                }
                                            }
                                            dgvitems.Rows.Add(false,itemName,quantity, fromWhse,toWhse);
                                        }
                                    }
                                }
                            }
                            lblItemsCount.Text = "Items (" + dgvitems.Rows.Count.ToString("N0") + ")";
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
                    else
                    {
                        Cursor.Current = Cursors.Default;
                        MessageBox.Show(response.ErrorMessage, "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            Cursor.Current = Cursors.Default;
        }

        private void checkSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            if (dgvOrders.Rows.Count > 0)
            {
                if (cCheck == 0)
                {
                    selectOrders(true);
                }
                else
                {
                    cCheck = 0;
                }
            }
        }

        private async void cmbBranches_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cBranch <= 0)
            {
                await loadWarehouses(false, cmbProdWhse);
            }
        }

        private void dtFromDate_ValueChanged(object sender, EventArgs e)
        {
            if(cFromDate <= 0)
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

        private void checkDate_CheckedChanged(object sender, EventArgs e)
        {
            dtFromDate.Visible = checkDate.Checked;
           if(cFromDate <= 0)
            {
                loadData();
            }
        }

        private void checkToDate_CheckedChanged(object sender, EventArgs e)
        {
            dtToDate.Visible = checkToDate.Checked;
            if (cToDate <= 0)
            {
                loadData();
            }
        }

        private void cmbProdWhse_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cPodWhse <= 0)
            {
                loadData();
            }
        }

        private void cmbRequestorWhse_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cReqWhse <= 0)
            {
                loadData();
            }
        }

        private void dgvOrders_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            //e.Cancel = true;
        }

        private void checkSelect_CheckedChanged(object sender, EventArgs e)
        {
            if (dgvOrders.Rows.Count > 0)
            {
                if (cCheck == 0)
                {
                    selectOrders(true);
                }
                else
                {
                    cCheck = 0;
                }
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (dgvOrders.Rows.Count <= 0)
            {
                MessageBox.Show("No transaction found", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                int hasOrderCheck = 0;
                for (int i = 0; i < dgvOrders.Rows.Count; i++)
                {
                    if (Convert.ToBoolean(dgvOrders.Rows[i].Cells["selectt"].Value.ToString()))
                    {
                        hasOrderCheck += 1;
                    }
                }
                if (hasOrderCheck <= 0)
                {
                    MessageBox.Show("No transaction selected", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (dgvitems.Rows.Count <= 0)
                {
                    MessageBox.Show("No item found", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    int hasItemCheck = 0;
                    for (int i = 0; i < dgvitems.Rows.Count; i++)
                    {
                        if (Convert.ToBoolean(dgvitems.Rows[i].Cells["selectt2"].Value.ToString()))
                        {
                            hasItemCheck += 1;
                        }
                    }
                    if (hasItemCheck <= 0)
                    {
                        MessageBox.Show("No order selected", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        SAP_RemarksDate sapRemarks = new SAP_RemarksDate();
                        sapRemarks.isOptional = true;
                        sapRemarks.ShowDialog();
                        if (SAP_RemarksDate.isSubmit)
                        {
                            JObject joBody = new JObject();
                            JArray jaIds = new JArray();
                            //ids
                            for (int i = 0; i < dgvOrders.Rows.Count; i++)
                            {
                                if (Convert.ToBoolean(dgvOrders.Rows[i].Cells["selectt"].Value.ToString()))
                                {
                                    jaIds.Add(Convert.ToInt32(dgvOrders.Rows[i].Cells["id"].Value.ToString()));
                                }
                            }
                            JObject joHeader = new JObject();
                            joHeader.Add("transdate", DateTime.Now.ToString("yyyy-MM-dd HH:mm"));
                            if (SAP_RemarksDate.sap_number <= 0)
                            {
                                joHeader.Add("sap_number", null);
                            }
                            else
                            {
                                joHeader.Add("sap_number", SAP_RemarksDate.sap_number);
                            }
                            if (SAP_RemarksDate.rem.Trim() == "")
                            {
                                joHeader.Add("remarks", null);
                            }
                            else
                            {
                                joHeader.Add("remarks", SAP_RemarksDate.rem);
                            }
                            joHeader.Add("production_date", SAP_RemarksDate.prodDate.ToString("yyyy-MM-dd"));
                            string lastFromWhse = "";
                            JArray jaRows = new JArray();                      
                            for (int i = 0; i < dgvitems.Rows.Count; i++)
                            {
                                if (Convert.ToBoolean(dgvitems.Rows[i].Cells["selectt2"].Value.ToString()))
                                {
                                    lastFromWhse = dgvitems.Rows[i].Cells["from_whse"].Value.ToString();
                                    JObject joRows = new JObject();
                                    joRows.Add("item_code", dgvitems.Rows[i].Cells["item"].Value.ToString());
                                    joRows.Add("planned_qty", Convert.ToInt32(dgvitems.Rows[i].Cells["quantity"].Value.ToString()));
                                    joRows.Add("whsecode", dgvitems.Rows[i].Cells["from_whse"].Value.ToString());
                                    joRows.Add("uom", "pc(s)");
                                    jaRows.Add(joRows);
                                }
                            }
                            joHeader.Add("whsecode", lastFromWhse);
                            joBody.Add("ids", jaIds);
                            joBody.Add("header", joHeader);
                            joBody.Add("rows", jaRows);
                            apiPUT(joBody, "/api/production/order/new");
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
                    request.Method = Method.POST;

                    Console.WriteLine(body);
                    request.AddParameter("application/json", body, ParameterType.RequestBody);
                    var response = client.Execute(request);
                    bool isSubmit = false;
                    if (response.ErrorMessage == null)
                    {
                        JObject jObjectResponse = JObject.Parse(response.Content);

                        foreach (var x in jObjectResponse)
                        {
                            if (x.Key.Equals("success"))
                            {
                                isSubmit = string.IsNullOrEmpty(x.Value.ToString().Trim()) ? false : Convert.ToBoolean(x.Value.ToString().Trim());
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
                            loadData();
                            dgvitems.Rows.Clear();
                            lblItemsCount.Text = "ITEMS (0)";
                        }
                    }
                    else
                    {
                        MessageBox.Show(response.ErrorMessage, "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                }
            }
        }

    }
}
