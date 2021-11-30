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
using DeliciousPartnerApp.API_Class.User;
using DeliciousPartnerApp.API_Class.Branch;
using DeliciousPartnerApp.API_Class.Warehouse;
using DeliciousPartnerApp.API_Class.Payment_Type;
using DeliciousPartnerApp.API_Class.Customer_Type;
using Newtonsoft.Json;

namespace DeliciousPartnerApp
{
    public partial class SalesReport : Form
    {
        DataTable dtBranch = new DataTable();
        DataTable dtWarehouse = new DataTable();
        branch_class branchc = new branch_class();
        warehouse_class warehousec = new warehouse_class();
        customertype_class customertypec = new customertype_class();
        utility_class utilityc = new utility_class();
        user_clas userc = new user_clas();
        paymenttype_class paymenttypec = new paymenttype_class();
        DataTable dtSalesAgent = new DataTable();
        DataTable dtSearch = new DataTable();
        DataTable dtCustType = new DataTable();
        int cBranch = 1, cUser = 1, cTransType = 1, cCheck = 0, cFromDate = 1, cToDate = 1, cFromTime = 1, cToTime = 1, cWarehouse = 1, cCustType = 1;
        public SalesReport()
        {
            InitializeComponent();
        }

        public async void loadWarehouse()
        {
            string branchCode = "";
            string warehouse = "";
            AutoCompleteStringCollection auto = new AutoCompleteStringCollection();
            foreach (DataRow row in dtBranch.Rows)
            {
                if (cmbBranch.Text.Equals(row["name"].ToString()))
                {
                    branchCode = row["code"].ToString();
                    break;
                }
            }
            dtWarehouse = await Task.Run(() => warehousec.returnWarehouse(branchCode, ""));
            cmbWarehouse.Items.Clear();
            int isAdmin = 0;
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
                                warehouse = y.Value.ToString();
                            }
                            else if (y.Key.Equals("isAdmin") || y.Key.Equals("isSuperAdmin") || y.Key.Equals("isManager") || y.Key.Equals("isCashier") || y.Key.Equals("isAccounting") || y.Key.Equals("isSalesAgent"))
                            {
                                if (y.Value.ToString().ToLower() == "true")
                                {
                                    cmbWarehouse.Items.Add("All-Good");
                                    foreach (DataRow row in dtWarehouse.Rows)
                                    {
                                        auto.Add(row["whsename"].ToString());
                                        cmbWarehouse.Items.Add(row["whsename"].ToString());
                                        cmbWarehouse.SelectedIndex = 0;
                                    }
                                    return;
                                }
                                else
                                {
                                    isAdmin += 1;
                                }
                            }
                        }
                    }
                }
            }
            if (isAdmin > 0)
            {
                string whseName = "";
                foreach (DataRow row in dtWarehouse.Rows)
                {
                    if (row["whsecode"].ToString() == warehouse)
                    {
                        auto.Add(row["whsename"].ToString());
                        whseName = row["whsename"].ToString();
                        cmbWarehouse.Items.Add(whseName);
                    }
                }
                cmbWarehouse.SelectedIndex = cmbWarehouse.Items.IndexOf(whseName);
            }
            cmbWarehouse.AutoCompleteCustomSource = auto;
        }

        private async void SalesReport_Load(object sender, EventArgs e)
        {
            dtBranch = new DataTable();
            dtWarehouse = new DataTable();
            dtSearch.Columns.Clear();
            dtSearch.Columns.Add("search", typeof(string));
            dtSearch.Columns.Add("type", typeof(string));

          

            loadBranch();
            loadWarehouse();
            loadSalesAgent();
            loadTransType();
            loadData();
            loadCustomerType();
            cBranch = 0;
            cUser = 0;
            cTransType = 0;
            cFromDate = 0;
            cToDate = 0;
            cFromTime = 0;
            cToTime = 0;
            cWarehouse = 0;
            cCustType = 0;
            cmbFromTime.SelectedIndex = 0;
            cmbSearchType.SelectedIndex = 0;
            cmbToTime.SelectedIndex = cmbToTime.Items.Count - 1;
            dgv.Columns["gross"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv.Columns["doctotal"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvitems.Columns["item"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv.Columns["disc_amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }
        public async Task loadBranch()
        {
            string currentBranch = "";
            bool isAdmin = false;
            cmbBranch.Items.Clear();
            AutoCompleteStringCollection auto = new AutoCompleteStringCollection();

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
                    auto.Add(row["name"].ToString());
                    cmbBranch.Items.Add(row["name"]);
                }
            }
            else
            {
                foreach (DataRow row in dtBranch.Rows)
                {
                    if (row["code"].ToString() == currentBranch)
                    {
                        auto.Add(row["name"].ToString());
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
                    auto.Add(row["name"].ToString());
                    branchName = row["name"].ToString();
                    break;
                }
            }
            cmbBranch.AutoCompleteCustomSource=auto;
            cmbBranch.SelectedIndex = cmbBranch.Items.IndexOf(branchName);
        }
        public void loadSalesAgent()
        {
            string sBranch = "?branch=" + findCode(cmbBranch.Text, "Branch");
            DataTable adtUsers = new DataTable();
            adtUsers = userc.returnUsers(sBranch + "&isSales=1");
            dtSalesAgent = adtUsers;

            cmbsales.Items.Clear();
            cmbsales.Items.Add("All");
            foreach (DataRow r0w in adtUsers.Rows)
            {
                cmbsales.Items.Add(r0w["username"].ToString());
            }
            cmbsales.SelectedIndex = 0;
        }

        public void loadTransType()
        {
            DataTable dtTransType = new DataTable();
            dtTransType = paymenttypec.loadPaymentType("sales");

            cmbTransType.Items.Clear();
            cmbTransType.Items.Add("All");
            foreach (DataRow r0w in dtTransType.Rows)
            {
                cmbTransType.Items.Add(r0w["code"].ToString());
            }
            cmbTransType.SelectedIndex = (cmbTransType.Items.Contains("CASH") ? cmbTransType.Items.IndexOf("CASH") : 0);
        }

        public void clearBillsField()
        {
            txtGrossPrice.Text = "0.00";
            txtDiscountAmount.Text = "0.00";
            txtDelFee.Text = "0.00";
            txtlAmountPayable.Text = "0.00";
            txtTotalPayment.Text = "0.00";
            txtTenderAmount.Text = "0.00";
            txtChange.Text = "0.00";
            checkSelectAll.Checked = false;
        }

        public void highlightHaveDiscount()
        {
            if (dgv.Rows.Count > 0)
            {
                for (int i = 0; i < dgv.Rows.Count; i++)
                {
                    if (Convert.ToDouble(dgv.Rows[i].Cells["disc_amount"].Value.ToString()) > 0)
                    {
                        
                        dgv.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;
                        dgv.Rows[i].Cells["btnPrintAR"].Style.BackColor = Color.ForestGreen;
                        dgv.Rows[i].Cells["selectt"].Style.BackColor = Color.White;
                    }
                }
            }
        }

        public void loadData()
        {
            try
            {
                clearBillsField();
                dgvitems.Rows.Clear();

                dtSearch.Rows.Clear();

                dgv.Columns["btnPrintAR"].Visible = cmbTransType.Text.Equals("AR Sales");

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
                        dgv.Rows.Clear();
                        var client = new RestClient(utilityc.URL);
                        client.Timeout = -1;

                        int salesID = 0;

                        foreach (DataRow r0wUsers in dtSalesAgent.Rows)
                        {

                            if (r0wUsers["username"].ToString() == cmbsales.Text)
                            {
                                salesID = Convert.ToInt32(r0wUsers["userid"].ToString());
                            }
                        }

                        string sSales = (salesID <= 0 ? "&user_id=" : "&user_id=" + salesID);
                        string sBranch = "&branch=" + findCode(cmbBranch.Text, "Branch");
                        string sWarehouse = "&whse=" + (!string.IsNullOrEmpty(findCode(cmbWarehouse.Text, "Warehouse")) || cmbWarehouse.SelectedIndex == 0 ? findCode(cmbWarehouse.Text, "Warehouse") : cmbWarehouse.Text);
                        string sTransType = (cmbTransType.SelectedIndex <= 0 ? "&transtype=" : "&transtype=" + cmbTransType.Text);
                        string sDate = "?from_date=" + dtFromDate.Value.ToString("yyyy-MM-dd") + "&to_date=" + dtToDate.Value.ToString("yyyy-MM-dd");
                        string sFromTime = cFromTime > 0 ? "&from_time=" : "&from_time=" + cmbFromTime.Text;

                        string sToTime = cToTime > 0 ? "&to_time=" : "&to_time=" + cmbToTime.Text;
                        string sSearch = "&search=" + (cmbSearchType.Text.Equals("Remarks") ? "" : txtsearch.Text);
                        string sCustType = "&cust_type=";

                        foreach (DataRow row in dtCustType.Rows)
                        {
                            if (row["code"].ToString() == cmbCustomerType.Text)
                            {
                                sCustType += row["id"].ToString();
                                break;
                            }
                        }

                        var request = new RestRequest("/api/sales/report" + sDate + sSales + sBranch + sWarehouse + sTransType + sFromTime + sToTime + sSearch + sCustType);
                        Console.WriteLine("/api/sales/report" + sDate + sSales + sWarehouse + sTransType + sFromTime + sToTime + sSearch + sCustType);
                        request.AddHeader("Authorization", "Bearer " + token);
                        var response = client.Execute(request);
                        if (response.ErrorMessage == null)
                        {
                            if (response.Content.Substring(0, 1).Equals("{"))
                            {
                                JObject jObject = new JObject();
                                jObject = JObject.Parse(response.Content.ToString());
                                bool isSuccess = false;
                                foreach (var x in jObject)
                                {
                                    if (x.Key.Equals("success"))
                                    {
                                        isSuccess = Convert.ToBoolean(x.Value.ToString());
                                        break;
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
                                                JObject jObjectData = JObject.Parse(x.Value.ToString());
                                                foreach (var y in jObjectData)
                                                {
                                                    if (y.Key.Equals("row"))
                                                    {
                                                        dgv.Rows.Clear();
                                                        JArray jArraySalesRows = JArray.Parse(y.Value.ToString());
                                                        for (int aa = 0; aa < jArraySalesRows.Count(); aa++)
                                                        {

                                                            JObject jObjectSalesRows = JObject.Parse(jArraySalesRows[aa].ToString());
                                                            int transNumber = 0, id = 0;
                                                            string referenceNumber = "", customerCode = "", processedBy = "", transType = "", discType = "", remarks = "";
                                                            double gross = 0.00, docTotal = 0.00, discAmount = 0.00;
                                                            DateTime dtTransDate = new DateTime();
                                                            foreach (var z in jObjectSalesRows)
                                                            {
                                                                if (z.Key.Equals("id"))
                                                                {
                                                                    id = Convert.ToInt32(z.Value.ToString());
                                                                }
                                                                else if (z.Key.Equals("transnumber"))
                                                                {
                                                                    transNumber = Convert.ToInt32(z.Value.ToString());
                                                                }
                                                                else if (z.Key.Equals("reference"))
                                                                {
                                                                    referenceNumber = z.Value.ToString();
                                                                    dtSearch.Rows.Add(referenceNumber, "Transnum");
                                                                }
                                                                else if (z.Key.Equals("gross"))
                                                                {
                                                                    gross = Convert.ToDouble(z.Value.ToString());
                                                                }
                                                                else if (z.Key.Equals("disctype"))
                                                                {
                                                                    discType = z.Value.ToString();
                                                                }
                                                                else if (z.Key.Equals("disc_amount"))
                                                                {
                                                                    discAmount = Convert.ToDouble(z.Value.ToString());
                                                                }
                                                                else if (z.Key.Equals("doctotal"))
                                                                {
                                                                    docTotal = Convert.ToDouble(z.Value.ToString());
                                                                }
                                                                else if (z.Key.Equals("user"))
                                                                {
                                                                    processedBy = z.Value.ToString();
                                                                }
                                                                else if (z.Key.Equals("cust_code"))
                                                                {
                                                                    customerCode = z.Value.ToString();
                                                                    dtSearch.Rows.Add(customerCode, "Customer");
                                                                }
                                                                else if (z.Key.Equals("transtype"))
                                                                {
                                                                    transType = z.Value.ToString();
                                                                }
                                                                else if (z.Key.Equals("remarks"))
                                                                {
                                                                    remarks = z.Value.ToString();
                                                                    dtSearch.Rows.Add(remarks, "Remarks");
                                                                }
                                                                else if (z.Key.Equals("transdate"))
                                                                {
                                                                    string replaceT = z.Value.ToString().Replace("T", "");
                                                                    dtTransDate = Convert.ToDateTime(replaceT);
                                                                }
                                                                //else if (z.Key.Equals("SalesType"))
                                                                //{
                                                                //    salesType = z.Value.ToString();
                                                                //}
                                                                //else if (z.Key.Equals("PaymentType"))
                                                                //{
                                                                //    paymentType = z.Value.ToString();
                                                                //}
                                                            }

                                                            if (!string.IsNullOrEmpty(txtsearch.Text))
                                                            {
                                                                if (cmbSearchType.Text.Equals("Trans. #"))
                                                                {
                                                                    if (referenceNumber.ToLower().Trim().Contains(txtsearch.Text.Trim().ToLower()))
                                                                    {

                                                                        dgv.Rows.Add(false, id, transNumber, dtTransDate.ToString("yyyy-MM-dd HH:mm"), referenceNumber, Convert.ToDecimal(string.Format("{0:0.00}", gross)), discType, Convert.ToDecimal(string.Format("{0:0.00}", discAmount)), Convert.ToDecimal(string.Format("{0:0.00}", docTotal)), customerCode, transType, remarks, processedBy);
                                                                    }
                                                                }
                                                                else if (cmbSearchType.Text.Equals("Cust. Code"))
                                                                {
                                                                    if (customerCode.ToLower().Trim().Contains(txtsearch.Text.ToLower().Trim()))
                                                                    {

                                                                        dgv.Rows.Add(false, id, transNumber, dtTransDate.ToString("yyyy-MM-dd HH:mm"), referenceNumber, Convert.ToDecimal(string.Format("{0:0.00}", gross)), discType, Convert.ToDecimal(string.Format("{0:0.00}", discAmount)), Convert.ToDecimal(string.Format("{0:0.00}", docTotal)), customerCode, transType, remarks, processedBy);
                                                                    }
                                                                }
                                                                else if (cmbSearchType.Text.Equals("Remarks"))
                                                                {
                                                                    if (!string.IsNullOrEmpty(remarks.Trim().ToLower()) && remarks.ToLower().Trim().Contains(txtsearch.Text.ToLower().Trim()))
                                                                    {
                                                                        dgv.Rows.Add(false, id, transNumber, dtTransDate.ToString("yyyy-MM-dd HH:mm"), referenceNumber, Convert.ToDecimal(string.Format("{0:0.00}", gross)), discType, Convert.ToDecimal(string.Format("{0:0.00}", discAmount)), Convert.ToDecimal(string.Format("{0:0.00}", docTotal)), customerCode, transType, remarks, processedBy);
                                                                    }
                                                                }
                                                            }
                                                            else
                                                            {
                                                                dgv.Rows.Add(false, id, transNumber, dtTransDate.ToString("yyyy-MM-dd HH:mm"), referenceNumber, Convert.ToDecimal(string.Format("{0:0.00}", gross)), discType, Convert.ToDecimal(string.Format("{0:0.00}", discAmount)), Convert.ToDecimal(string.Format("{0:0.00}", docTotal)), customerCode, transType, remarks, processedBy);
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    lblOrderCount.Text = "ORDERS (" + dgv.Rows.Count.ToString("N0") + ")";
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
                    Cursor.Current = Cursors.Default;
                }
                lblNoDataFound.Visible = (dgv.Rows.Count > 0 ? false : true);
                highlightHaveDiscount();
                searchFilter();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString(), ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public void loadCustomerType()
        {
            cmbCustomerType.Items.Clear();
            dtCustType = customertypec.loadCustomerTypes();
            if (dtCustType.Rows.Count > 0)
            {
                cmbCustomerType.Items.Add("All");
                foreach (DataRow row in dtCustType.Rows)
                {
                    cmbCustomerType.Items.Add(row["code"].ToString());
                }
                cmbCustomerType.SelectedIndex = 0;
            }
        }

        public void searchFilter()
        {
            AutoCompleteStringCollection auto = new AutoCompleteStringCollection();
            if (cmbSearchType.SelectedIndex == 0)
            {
                foreach (DataRow row in dtSearch.Rows)
                {
                    if (row["type"].ToString().Equals("Transnum"))
                    {
                        auto.Add(row["search"].ToString());
                    }
                }
            }
            else
            {
                foreach (DataRow row in dtSearch.Rows)
                {
                    if (row["type"].ToString().Equals("Customer"))
                    {
                        auto.Add(row["search"].ToString());
                    }
                    if (row["type"].ToString().Equals("Remarks"))
                    {
                        auto.Add(row["search"].ToString());
                    }
                }
            }

            txtsearch.AutoCompleteCustomSource = auto;
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
                foreach (DataRow row in dtBranch.Rows)
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


        private void cmbsales_SelectedValueChanged(object sender, EventArgs e)
        {
         
        }

        private void cmbBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cBranch <= 0)
            {
                loadWarehouse();
                loadSalesAgent();
                loadData();
            }
        }

        private void cmbFromTime_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cFromTime <= 0)
            {
                loadData();
            }
        }

        private void cmbWarehouse_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cWarehouse <= 0)
            {
                loadData();
            }
        }

        private void cmbBranch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                loadWarehouse();
                loadSalesAgent();
                loadData();
            }
        }

        private void cmbsales_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cUser <= 0)
            {
                loadData();
            }
        }

        private void cmbBranch_DropDownClosed(object sender, EventArgs e)
        {
           
        }

        private void cmbWarehouse_DropDownClosed(object sender, EventArgs e)
        {
        
        }

        private void cmbsales_DropDownClosed(object sender, EventArgs e)
        {
       
        }

        private void cmbTransType_DropDownClosed(object sender, EventArgs e)
        {
           
        }

        private void cmbBranch_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            loadData();
        }

        private void txtsearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                loadData();
            }
        }

        private void cmbSearchType_SelectedIndexChanged(object sender, EventArgs e)
        {
         
        }

        private void cmbCustomerType_DropDownClosed(object sender, EventArgs e)
        {
         
        }

        private void cmbWarehouse_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                loadData();
            }
        }

        private void cmbBranch_SelectionChangeCommitted(object sender, EventArgs e)
        {

        }

        private void cmbWarehouse_SelectionChangeCommitted(object sender, EventArgs e)
        {
       
        }

        private void cmbsales_SelectionChangeCommitted(object sender, EventArgs e)
        {

        }

        private void cmbTransType_SelectionChangeCommitted(object sender, EventArgs e)
        {
        
        }

        private void dtToDate_CloseUp(object sender, EventArgs e)
        {
            if (cToDate <= 0)
            {
                loadData();
            }
        }

        private void dtFromDate_CloseUp(object sender, EventArgs e)
        {
            if (cFromDate <= 0)
            {
                loadData();
            }
        }

        private void cmbCustomerType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cCustType <= 0)
            {
                loadData();
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cmbCustomerType_SelectionChangeCommitted(object sender, EventArgs e)
        {
     
        }

        private void cmbSearchType_DropDownClosed(object sender, EventArgs e)
        {
            searchFilter();
        }

        private void cmbToTime_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cToTime <= 0)
            {
                loadData();
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

                    if (value)
                    {
                        for (int i = 0; i < dgv.Rows.Count; i++)
                        {
                            dgv.Rows[i].Cells["selectt"].Value = checkSelectAll.Checked;
                        }
                    }
                    else
                    {
                        int isCheckAll_int = 0;
                        for (int i = 0; i < dgv.Rows.Count; i++)
                        {
                            if (Convert.ToBoolean(dgv.Rows[i].Cells["selectt"].Value.ToString()) == true)
                            {
                                isCheckAll_int += 1;
                            }
                        }
                        if (checkSelectAll.Checked && !isCheckAll_int.Equals(dgv.Rows.Count))
                        {
                            cCheck = 1;
                            checkSelectAll.Checked = false;
                        }
                        else if (!checkSelectAll.Checked && isCheckAll_int.Equals(dgv.Rows.Count))
                        {
                            checkSelectAll.Checked = true;
                        }
                    }

                    dgv.CommitEdit(DataGridViewDataErrorContexts.Commit);
                    JArray jarrayBody = new JArray();
                    for (int i = 0; i < dgv.Rows.Count; i++)
                    {

                        if (Convert.ToBoolean(dgv.Rows[i].Cells["selectt"].Value.ToString()) == true)
                        {
                            jarrayBody.Add(Convert.ToInt32(dgv.Rows[i].Cells["ID"].Value));
                        }
                    }
                    JObject jsonObjectBody = new JObject();
                    jsonObjectBody.Add("ids", jarrayBody);

                    string sTransType = cmbTransType.SelectedIndex == 0 ? "" : cmbTransType.Text;
                    Console.WriteLine(jsonObjectBody);
                    Console.WriteLine("/api/sales/summary_trans?transtype=" + sTransType + "&transdate=");
                    var client = new RestClient(utilityc.URL);
                    client.Timeout = -1;
                    var request = new RestRequest("/api/sales/summary_trans?transtype=" + sTransType + "&transdate=");
                    request.AddHeader("Authorization", "Bearer " + token);
                    request.AddParameter("application/json", jsonObjectBody, ParameterType.RequestBody);
                    request.Method = Method.PUT;
                    var response = client.Execute(request);
                    dgvitems.Rows.Clear();
                    if (response.ErrorMessage == null)
                    {
                        if (response.Content.ToString().Substring(0, 1).Equals("{"))
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
                                        if (x.Value.ToString() != "{}")
                                        {
                                            JObject jObjectData = JObject.Parse(x.Value.ToString());
                                            foreach (var y in jObjectData)
                                            {
                                                if (y.Key.Equals("header"))
                                                {
                                                    JObject jObjectHeader = JObject.Parse(y.Value.ToString());
                                                    foreach (var z in jObjectHeader)
                                                    {
                                                        if (z.Key.Equals("gross"))
                                                        {
                                                            txtGrossPrice.Text = string.IsNullOrEmpty(z.Value.ToString()) ? "0.00" : Convert.ToDouble(z.Value.ToString()).ToString("n2");
                                                        }
                                                        else if (z.Key.Equals("disc_amount"))
                                                        {
                                                            txtDiscountAmount.Text = string.IsNullOrEmpty(z.Value.ToString()) ? "0.00" : Convert.ToDouble(z.Value.ToString()).ToString("n2");
                                                        }
                                                        else if (z.Key.Equals("delfee"))
                                                        {
                                                            txtDelFee.Text = string.IsNullOrEmpty(z.Value.ToString()) ? "0.00" : Convert.ToDouble(z.Value.ToString()).ToString("n2");
                                                        }
                                                        else if (z.Key.Equals("disc_amount"))
                                                        {
                                                            txtDiscountAmount.Text = string.IsNullOrEmpty(z.Value.ToString()) ? "0.00" : Convert.ToDouble(z.Value.ToString()).ToString("n2");
                                                        }
                                                        else if (z.Key.Equals("doctotal"))
                                                        {
                                                            txtlAmountPayable.Text = string.IsNullOrEmpty(z.Value.ToString()) ? "0.00" : Convert.ToDouble(z.Value.ToString()).ToString("n2");
                                                        }
                                                        else if (z.Key.Equals("tenderamt"))
                                                        {
                                                            txtTenderAmount.Text = string.IsNullOrEmpty(z.Value.ToString()) ? "0.00" : Convert.ToDouble(z.Value.ToString()).ToString("n2");
                                                        }
                                                        else if (z.Key.Equals("change"))
                                                        {
                                                            txtChange.Text = string.IsNullOrEmpty(z.Value.ToString()) ? "0.00" : Convert.ToDouble(z.Value.ToString()).ToString("n2");
                                                        }
                                                    }
                                                }
                                                else if (y.Key.Equals("row"))
                                                {
                                                    JArray jArrayRow = JArray.Parse(y.Value.ToString());
                                                    for (int i = 0; i < jArrayRow.Count(); i++)
                                                    {
                                                        JObject data = JObject.Parse(jArrayRow[i].ToString());
                                                        String itemName = "";
                                                        double quantity = 0.00, price = 0.00, discountPercent = 0.00, totalPrice = 0.00, discamt = 0.00;
                                                        bool free = false;
                                                        foreach (var z in data)
                                                        {
                                                            if (z.Key.Equals("item_code"))
                                                            {
                                                                itemName = z.Value.ToString();
                                                            }
                                                            else if (z.Key.Equals("quantity"))
                                                            {
                                                                quantity = Convert.ToDouble(z.Value.ToString());
                                                            }
                                                            else if (z.Key.Equals("unit_price"))
                                                            {
                                                                price = Convert.ToDouble(z.Value.ToString());
                                                            }
                                                            else if (z.Key.Equals("discprcnt"))
                                                            {
                                                                discountPercent = Convert.ToDouble(z.Value.ToString());
                                                            }
                                                            else if (z.Key.Equals("linetotal"))
                                                            {
                                                                totalPrice = Convert.ToDouble(z.Value.ToString());
                                                            }
                                                            else if (z.Key.Equals("free"))
                                                            {
                                                                free = Convert.ToBoolean(z.Value.ToString());
                                                            }

                                                            else if (z.Key.Equals("disc_amount"))
                                                            {
                                                                discamt = Convert.ToDouble(z.Value.ToString());
                                                            }
                                                        }
                                                        dgvitems.Rows.Add(itemName, Convert.ToDecimal(string.Format("{0:0.00}", quantity)), Convert.ToDecimal(string.Format("{0:0.00}", price)), Convert.ToDecimal(string.Format("{0:0.00}", discountPercent)), Convert.ToDecimal(string.Format("{0:0.00}", discamt)), Convert.ToDecimal(string.Format("{0:0.00}", totalPrice)), free);
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                                lblItemsCount.Text = "ITEMS (" + dgvitems.Rows.Count.ToString("N0") + ")";
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
                            MessageBox.Show(response.Content.ToString(), "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
        }


        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {


                if (dgv.Rows.Count > 0)
                {
                    if (e.ColumnIndex == 0)
                    {
                        selectOrders(false);
                    }
                    else if (e.ColumnIndex == 13)
                    {
                        if (dgv.CurrentRow.Cells["transtype"].Value.ToString() == "AR Sales")
                        {
                            JArray jarrayBody = new JArray();
                            jarrayBody.Add(Convert.ToInt32(dgv.CurrentRow.Cells["ID"].Value));
                            JObject jsonObjectBody = new JObject();
                            jsonObjectBody.Add("ids", jarrayBody);

                            api_class apic = new api_class();
                            string sTransType = "?transtype=" + (cmbTransType.SelectedIndex == 0 ? "" : cmbTransType.Text);
                            Console.WriteLine(jsonObjectBody);
                            Console.WriteLine("/api/sales/summary_trans?transtype=" + sTransType + "&transdate=");
                            string sParams = sTransType + "&transdate=";
                            string sResult = apic.loadData("/api/sales/summary_trans", sParams, "application/json", jsonObjectBody.ToString(), Method.PUT, true);
                            if (!string.IsNullOrEmpty(sResult.Trim()))
                            {
                                if (sResult.StartsWith("{"))
                                {
                                    DataTable dt = new DataTable();
                                    dt.Columns.Add("cust_code", typeof(string));
                                    dt.Columns.Add("reference", typeof(string));
                                    dt.Columns.Add("transdate", typeof(string));
                                    dt.Columns.Add("item_code", typeof(string));

                                    dt.Columns.Add("quantity", typeof(double));
                                    dt.Columns.Add("price", typeof(double));
                                    dt.Columns.Add("discount_amount", typeof(double));
                                    dt.Columns.Add("net_amount", typeof(double));
                                    dt.Columns.Add("gross_amount", typeof(double));

                                    dt.Columns.Add("total_gross_amount", typeof(double));
                                    dt.Columns.Add("total_discount_amount", typeof(double));
                                    dt.Columns.Add("total_net_amount", typeof(double));

                                    JObject joResult = JObject.Parse(sResult);
                                    JObject joData = JObject.Parse(joResult["data"].ToString());
                                    JObject joHeader = JObject.Parse(joData["header"].ToString());
                                    string sCustCode = dgv.CurrentRow.Cells["customer_code"].Value.ToString();
                                    string sRef = dgv.CurrentRow.Cells["reference"].Value.ToString();


                                    string sTransDate = Convert.ToDateTime(dgv.CurrentRow.Cells["transdate"].Value.ToString()).ToString("MM/dd/yyyy");

                                    double doubleTemp = 0.00;
                                    double totalGross = double.TryParse(joHeader["gross"].ToString(), out doubleTemp) ? Convert.ToDouble(joHeader["gross"].ToString()) : doubleTemp;
                                    double totalDisc = double.TryParse(joHeader["disc_amount"].ToString(), out doubleTemp) ? Convert.ToDouble(joHeader["disc_amount"].ToString()) : doubleTemp;
                                    double totalNet = double.TryParse(joHeader["doctotal"].ToString(), out doubleTemp) ? Convert.ToDouble(joHeader["doctotal"].ToString()) : doubleTemp;




                                    JArray jaRow = JArray.Parse(joData["row"].ToString());
                                    DataTable dtRow = (DataTable)JsonConvert.DeserializeObject(jaRow.ToString(), (typeof(DataTable)));

                                    foreach (DataRow row in dtRow.Rows)
                                    {
                                        string sItemCode = row["item_code"].ToString();
                                        double quantity = double.TryParse(row["quantity"].ToString(), out doubleTemp) ? Convert.ToDouble(row["quantity"].ToString()) : doubleTemp;
                                        double unitPrice = double.TryParse(row["unit_price"].ToString(), out doubleTemp) ? Convert.ToDouble(row["unit_price"].ToString()) : doubleTemp;
                                        double discAmt = double.TryParse(row["disc_amount"].ToString(), out doubleTemp) ? Convert.ToDouble(row["disc_amount"].ToString()) : doubleTemp;
                                        double netAmt = double.TryParse(row["linetotal"].ToString(), out doubleTemp) ? Convert.ToDouble(row["linetotal"].ToString()) : doubleTemp;
                                        double grossAmt = double.TryParse(row["gross"].ToString(), out doubleTemp) ? Convert.ToDouble(row["gross"].ToString()) : doubleTemp;

                                        dt.Rows.Add(sCustCode, sRef, sTransDate, sItemCode, quantity, unitPrice, discAmt, netAmt, grossAmt, totalGross, totalDisc, totalNet);
                                    }
                                    print_toPay frm = new print_toPay();
                                    frm.dtResult = dt;
                                    frm.ShowDialog();
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Transaction Type is not valid!", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    

        private void dgvitems_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvitems.Rows.Count > 0 && dgv.Rows.Count > 0)
            {
                if (e.RowIndex >= 0)
                {
                    try
                    {
                        JArray jarrayBody = new JArray();
                        for (int i = 0; i < dgv.Rows.Count; i++)
                        {
                            if (Convert.ToBoolean(dgv.Rows[i].Cells["selectt"].Value.ToString()) == true)
                            {
                                jarrayBody.Add(Convert.ToInt32(dgv.Rows[i].Cells["ID"].Value));
                            }
                        }

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
                                JObject jsonObjectBody = new JObject();
                                jsonObjectBody.Add("ids", jarrayBody);
                                jsonObjectBody.Add("discount", Convert.ToDouble(dgvitems.CurrentRow.Cells["discpercent"].Value.ToString()));
                                jsonObjectBody.Add("item_code", dgvitems.CurrentRow.Cells["item"].Value.ToString());
                                var request = new RestRequest("/api/sales/item/transaction/details");
                                request.AddHeader("Authorization", "Bearer " + token);
                                Console.WriteLine(jsonObjectBody);
                                request.AddParameter("application/json", jsonObjectBody, ParameterType.RequestBody);
                                request.Method = Method.PUT;
                                var response = client.Execute(request);
                                ItemDiscount itemDisc = new ItemDiscount();
                                if (response.ErrorMessage == null)
                                {
                                    itemDisc.jsonResponse = response.Content.ToString();
                                }
                                else
                                {
                                    itemDisc.jsonResponse = response.ErrorMessage;
                                }
                                itemDisc.ShowDialog();
                                Cursor.Current = Cursors.Default;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
            }
        }


        private void checkSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            if (dgv.Rows.Count > 0)
            {
                //toggleSelectAll(checkSelectAll.Checked);
                //MessageBox.Show(cCheck.ToString());
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

        private void dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (dgv.Rows.Count > 0) 
            //{
            //    SalesReportItems salesReportItems = new SalesReportItems();
            //    salesReportItems.URLDetails = "/api/sales/details/" + dgv.CurrentRow.Cells["id"].Value.ToString();
            //    salesReportItems.ShowDialog();
            //}
        }



        private void cmbTransType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cTransType <= 0)
            {
                loadData();
            }
        }
    }
}
