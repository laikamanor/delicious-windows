using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DeliciousPartnerApp.UI_Class;
using DeliciousPartnerApp.API_Class.Branch;
using DeliciousPartnerApp.API_Class.Warehouse;
using DeliciousPartnerApp.API_Class.Customer_Type;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DeliciousPartnerApp
{
    public partial class PendingOrder2 : Form
    {
        UI_Class.utility_class utilityc = new utility_class();
        customertype_class customertypec = new customertype_class();
        DataTable dtSalesAgent = new DataTable();
        public static DataTable dtSelectedDeposit;
        DataTable dtPayment = new DataTable();
        string gSalesType = "", gForType = "";
        int cCheck = 0, cFromTime = 1, cToTime = 1, cCustType = 1;

        branch_class branchc = new branch_class();
        warehouse_class warehousec = new warehouse_class();
        DataTable dtBranches = new DataTable();
        DataTable dtWarehouse = new DataTable();
        DataTable dtSearch = new DataTable();
        DataTable dtCustType = new DataTable();
        int cBranch = 1, cDate = 1, cSales = 1, cToDate = 1;
        int currentMouseOverRow = 0;
        public PendingOrder2(string salesType, string forType)
        {
            gSalesType = salesType;
            gForType = forType;
            InitializeComponent();
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

        private async void PendingOrder_Load(object sender, EventArgs e)
        {

            dtSearch = new DataTable();
            dtSearch.Rows.Clear();
            dtSearch.Columns.Add("search", typeof(string));
            dtSearch.Columns.Add("type", typeof(string));

            dgvOrders.Columns["days_due"].Visible = gForType.Equals("for Payment") ? true : false;
            dgvOrders.Columns["btnEditTotalPayment"].Visible = gForType.Equals("for Payment") ? true : false;

            dgvOrders.Columns["btnPrint"].Visible = gForType.Equals("for Confirmation") && gSalesType.Equals("AR Sales") ? true : false;

            dtFromDate.Visible = true;
            label1.Visible = true;
            dtFromDate.Value = DateTime.Now;
            dtToDate.Value = DateTime.Now;
            checkDate.Checked = true;
            checkToDate.Checked = true;

            cmbSearchType.SelectedIndex = 0;
            cmbFromTime.SelectedIndex = 0;
            cmbToTime.SelectedIndex = cmbToTime.Items.Count - 1;
            if (gForType == "for Payment")
            {
                btnConfirm.Text = "PAY";
                button1.Visible = true;
                //btnVoid.Visible = true;
                btnPaymentMethod.Visible = true;
            }
            else
            {
                btnConfirm.Text = "CONFIRM";
                button1.Visible = false;
                //btnVoid.Visible = false;
                btnPaymentMethod.Visible = false;
            }
            if (gForType.Equals("for Payment") || gForType.Equals("for Confirmation"))
            {
                btnVoid.Visible = true;
            }
            else
            {
                btnVoid.Visible = false;
            }
            dtSelectedDeposit = new DataTable();
            dtSelectedDeposit.Columns.Clear();
            dtSelectedDeposit.Columns.Add("id");
            dtSelectedDeposit.Columns.Add("amount");
            dtSelectedDeposit.Columns.Add("payment_type");
            dtSelectedDeposit.Columns.Add("sapnum");
            dtSelectedDeposit.Columns.Add("reference2");
            dtSelectedDeposit.Columns.Add("type");
            dtPayment.Columns.Add("id");
            dtPayment.Columns.Add("amount");
            dtPayment.Columns.Add("payment_type");
            dtPayment.Columns.Add("sapnum");
            dtPayment.Columns.Add("reference2");

            dtSelectedDeposit.Rows.Clear();
            label7.Visible = true;
            cmbBranches.Visible = true;
            await loadBranch();

            loadSalesAgent();
            loadCustomerType();
            string subURL = gForType == "for Payment" ? "/api/payment/new" : "/api/sales/for_confirm";
            loadData(subURL);
            searchFilter();
            cBranch = 0;
            cDate = 0;
            cSales = 0;
            cFromTime = 0;
            cToTime = 0;
            cToDate = 0;
            cCustType = 0;

            dgvitems.Columns["item"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvOrders.Columns["amountdue"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvOrders.Columns["delfee"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        public void loadSalesAgent()
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
                    dtSalesAgent.Columns.Clear();
                    dtSalesAgent.Columns.Add("id");
                    dtSalesAgent.Columns.Add("username");
                    dtSalesAgent.Rows.Clear();
                    cmbsales.Items.Clear();
                    var client = new RestClient(utilityc.URL);
                    client.Timeout = -1;
                    var request = new RestRequest("/api/auth/user/get_all?isSales=1&branch=" + findCode(cmbBranches.Text, "Branch"));
                    request.AddHeader("Authorization", "Bearer " + token);
                    var response = client.Execute(request);
                    if (response.ErrorMessage == null)
                    {
                        JObject jObjectResponse = JObject.Parse(response.Content);
                        cmbsales.Items.Add("All");

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
                                        lblNoDataFound.Visible = false;
                                        JArray jsonArray = JArray.Parse(x.Value.ToString());
                                        for (int i = 0; i < jsonArray.Count(); i++)
                                        {
                                            JObject jObjectData = JObject.Parse(jsonArray[i].ToString());
                                            int id = 0;
                                            string username = "";
                                            foreach (var y in jObjectData)
                                            {
                                                if (y.Key.Equals("id"))
                                                {
                                                    id = Convert.ToInt32(y.Value.ToString());
                                                }
                                                else if (y.Key.Equals("username"))
                                                {
                                                    username = y.Value.ToString();
                                                }
                                            }
                                            dtSalesAgent.Rows.Add(id, username);
                                            cmbsales.Items.Add(username);

                                        }
                                    }
                                }
                            }
                            cmbsales.SelectedIndex = 0;
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
                    else
                    {
                        Cursor.Current = Cursors.Default;
                        MessageBox.Show(response.ErrorMessage, "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            Cursor.Current = Cursors.Default;
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

        public void loadData(string subURL)
        {
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
                    dgvitems.Rows.Clear();
                    var client = new RestClient(utilityc.URL);
                    client.Timeout = -1;

                    int selectedSalesAgentID = 0;
                    foreach (DataRow r0w in dtSalesAgent.Rows)
                    {
                        if (r0w["username"].Equals(cmbsales.Text))
                        {
                            selectedSalesAgentID = Convert.ToInt32(r0w["id"]);
                        }
                    }
                    string sUserID = "";
                    if (selectedSalesAgentID != 0)
                    {
                        sUserID = selectedSalesAgentID.ToString();
                    }
                    string arSalesDate = "";
                    string sSearch = "";
                    if (gSalesType == "AR Sales" && label1.Visible == true && dtFromDate.Visible == true)
                    {
                        arSalesDate = !checkDate.Checked ? "&from_date=" : "&from_date=" + dtFromDate.Value.ToString("yyyy-MM-dd");
                        arSalesDate += !checkToDate.Checked ? "&to_date=" : "&to_date=" + dtToDate.Value.ToString("yyyy-MM-dd");
                    }
                    else if (gForType.ToLower().Equals("for payment"))
                    {
                        arSalesDate = !checkDate.Checked ? "&from_date=" : "&from_date=" + dtFromDate.Value.ToString("yyyy-MM-dd");
                        arSalesDate += !checkToDate.Checked ? "&to_date=" : "&to_date=" + dtToDate.Value.ToString("yyyy-MM-dd");
                    }
                    sSearch = "&search=" + txtsearch.Text.Trim();
                    string sBranch = "&branch=" + findCode(cmbBranches.Text, "Branch");

                    string sFromTime = cFromTime > 0 ? "&from_time=" : "&from_time=" + cmbFromTime.Text;

                    string sToTime = cToTime > 0 ? "&to_time=" : "&to_time=" + cmbToTime.Text;

                    string forQuery = subURL + "?transtype=" + gSalesType + "&user_id=" + sUserID + sSearch + arSalesDate + sBranch + sFromTime + sToTime;

                    string sCustType = "";
                    if (cmbCustomerType.Text == "All" || cmbCustomerType.SelectedIndex == 0)
                    {
                        sCustType = "&cust_type=";
                    }
                    else
                    {
                        foreach (DataRow row in dtCustType.Rows)
                        {
                            if (row["code"].ToString() == cmbCustomerType.Text)
                            {
                                sCustType = "&cust_type=" + row["id"].ToString();
                                break;
                            }
                        }
                    }

                    string resultQuery;
                    if (gForType.Equals("for SAP"))
                    {
                        resultQuery = "/api/sales/for_sap/get_all?from_date=" + (!checkDate.Checked ? "" : dtFromDate.Value.ToString("yyyy-MM-dd")) + "&to_date=" + (!checkToDate.Checked ? "" : dtToDate.Value.ToString("yyyy-MM-dd")) + "&transtype=" + gSalesType + "&search=" + txtsearch.Text + "&created_by=" + sUserID + sFromTime + sToTime + sBranch;
                    }
                    else
                    {
                        resultQuery = forQuery;
                    }
                    resultQuery += sCustType;
                    Console.WriteLine(resultQuery);
                    var request = new RestRequest(resultQuery);
                    request.AddHeader("Authorization", "Bearer " + token);
                    var response = client.Execute(request);
                    //Console.WriteLine(response.Content.ToString());
                    //MessageBox.Show(response.Content.ToString());
                    JObject jObject = new JObject();

                    if (response.ErrorMessage == null)
                    {
                        jObject = JObject.Parse(response.Content.ToString());
                        dgvOrders.Rows.Clear();
                        dgvitems.Rows.Clear();
                        clearBillsField();
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
                                        lblNoDataFound.Visible = false;
                                        JArray jsonArray = JArray.Parse(x.Value.ToString());
                                        for (int i = 0; i < jsonArray.Count(); i++)
                                        {
                                            string forSAPAmountColumnName = (gForType.Equals("for SAP") ? "doctotal" : "amount_due");
                                            JObject data = JObject.Parse(jsonArray[i].ToString());
                                            int id = 0, transNumber = 0, daysDue = 0;
                                            string referenceNumber = "", salesAgent = "N/A", cust_code = "", discType = "", remarks = "", custName = "", transtype = "", reference2 = "", sapNumber = "";
                                            decimal amountDue = 0, tenderAmount = 0, discAmt = 0, delFee = 0, decimalTemp = 0, discprcntt = 0;
                                            DateTime dtTransDate = new DateTime();
                                            foreach (var q in data)
                                            {
                                                if (q.Key.Equals("reference"))
                                                {
                                                    referenceNumber = q.Value.ToString();
                                                }
                                                else if (q.Key.Equals("disctype"))
                                                {
                                                    discType = q.Value.ToString();
                                                }
                                                else if (q.Key.Equals("disc_amount"))
                                                {
                                                    discAmt = decimal.Round(Convert.ToDecimal(q.Value.ToString()), 2, MidpointRounding.AwayFromZero);
                                                }
                                                else if (q.Key.Equals("cust_code"))
                                                {
                                                    cust_code = q.Value.ToString();
                                                }
                                                else if (q.Key.Equals("cust_name"))
                                                {
                                                    custName = q.Value.ToString();
                                                }
                                                if (q.Key.Equals(forSAPAmountColumnName))
                                                {
                                                    //Console.WriteLine(q.Value);
                                                    amountDue = decimal.TryParse(q.Value.ToString(), out decimalTemp) ? decimal.Round(Convert.ToDecimal(q.Value.ToString()), 2, MidpointRounding.AwayFromZero) : decimalTemp;
                                                }
                                                else if (q.Key.Equals("id"))
                                                {
                                                    id = Convert.ToInt32(q.Value.ToString());
                                                }

                                                else if (q.Key.Equals("transnumber"))
                                                {
                                                    transNumber = Convert.ToInt32(q.Value.ToString());
                                                }
                                                else if (q.Key.Equals("tenderamt"))
                                                {
                                                    tenderAmount = decimal.TryParse(q.Value.ToString(), out decimalTemp) ? decimal.Round(Convert.ToDecimal(q.Value.ToString()), 2, MidpointRounding.AwayFromZero) : decimalTemp;
                                                }
                                                else if (q.Key.Equals("delfee"))
                                                {
                                                    delFee = decimal.TryParse(q.Value.ToString(), out decimalTemp) ? decimal.Round(Convert.ToDecimal(q.Value.ToString()), 2, MidpointRounding.AwayFromZero) : decimalTemp;
                                                }
                                                else if (q.Key.Equals("user"))
                                                {
                                                    salesAgent = q.Value.ToString();
                                                }
                                                else if (q.Key.Equals("remarks"))
                                                {
                                                    remarks = q.Value.ToString();
                                                }
                                                else if (q.Key.Equals("transtype"))
                                                {
                                                    transtype = q.Value.ToString();
                                                }
                                                else if (q.Key.Equals("sap_number"))
                                                {
                                                    sapNumber = q.Value.ToString();
                                                }
                                                else if (q.Key.Equals("reference2"))
                                                {
                                                    reference2 = q.Value.ToString();
                                                }
                                                else if (q.Key.Equals("days_due"))
                                                {
                                                    double toDouble = Convert.ToDouble(q.Value.ToString());
                                                    daysDue = Convert.ToInt32(toDouble);
                                                }
                                                else if (q.Key.Equals("discprcnt"))
                                                {
                                                    double toDouble = Convert.ToDouble(q.Value.ToString());
                                                    discprcntt = Convert.ToInt32(toDouble);
                                                }
                                                else if (q.Key.Equals("transdate"))
                                                {
                                                    string replaceT = q.Value.ToString().Replace("T", "");
                                                    dtTransDate = Convert.ToDateTime(replaceT);
                                                }
                                            }
                                            dgvOrders.Rows.Add(false, id, transNumber, dtTransDate.ToString("yyyy-MM-dd HH:mm"), referenceNumber, Convert.ToDecimal(string.Format("{0:0.00}", amountDue)), Convert.ToDecimal(string.Format("{0:0.00}", tenderAmount)), discType, Convert.ToDecimal(string.Format("{0:0.00}", discAmt)), Convert.ToDecimal(string.Format("{0:0.00}", amountDue)), Convert.ToDecimal(string.Format("{0:0.00}", delFee)), cust_code, remarks, salesAgent, "", daysDue, null, null, custName, reference2, transtype, sapNumber, Convert.ToDecimal(string.Format("{0:0.00}", discprcntt)));
                                            dtSearch.Rows.Add(cust_code, "Customer");
                                            dtSearch.Rows.Add(referenceNumber, "Transnum");
                                        }
                                        foreach (DataGridViewColumn col in dgvOrders.Columns)
                                        {
                                            col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                                            int colw = col.Width;
                                            col.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                                            col.Width = colw;
                                        }
                                    }
                                    else
                                    {
                                        lblNoDataFound.Visible = true;
                                        lblOrderCount.Text = "Orders (0)";
                                        lblpendingamount.Text = "Selected Amount: 0.00";
                                        dgvitems.Rows.Clear();
                                        clearBillsField();
                                    }
                                }
                            }
                        }
                        else
                        {
                            lblOrderCount.Text = "Orders (0)";
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
                                lblOrderCount.Text = "Orders (0)";
                                lblpendingamount.Text = "Selected Amount: 0.00";
                                dgvitems.Rows.Clear();
                                clearBillsField();
                            }
                            else
                            {
                                Cursor.Current = Cursors.Default;
                                MessageBox.Show(msg, "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                lblOrderCount.Text = "Orders (0)";
                                lblpendingamount.Text = "Selected Amount: 0.00";
                                dgvitems.Rows.Clear();
                                clearBillsField();
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show(response.ErrorMessage, "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            dgvOrders.Columns["amountdue"].HeaderText = (gForType.Equals("for SAP") ? "Doc. Total" : "Balance Due");
            highlightHaveDiscount();
            searchFilter();
            lblOrderCount.Text = "Orders (" + dgvOrders.Rows.Count.ToString("N0") + ")";
            Cursor.Current = Cursors.Default;
        }

        public void highlightHaveDiscount()
        {
            if (dgvOrders.Rows.Count > 0)
            {
                for (int i = 0; i < dgvOrders.Rows.Count; i++)
                {
                    if (Convert.ToDouble(dgvOrders.Rows[i].Cells["discount_amount"].Value.ToString()) > 0)
                    {
                        dgvOrders.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;
                        dgvOrders.Rows[i].Cells["btnEditTotalPayment"].Style.BackColor = Color.FromArgb(192, 0, 192);
                        dgvOrders.Rows[i].Cells["selectt"].Style.BackColor = Color.White;
                    }
                }
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
                }
            }
            txtsearch.AutoCompleteCustomSource = auto;
        }

        public void clearBillsField()
        {
            txtGrossPrice.Text = "0.00";
            txtDiscountAmount.Text = "0.00";
            txtlAmountPayable.Text = "0.00";
            txtTotalPayment.Text = "0.00";
            txtChange.Text = "0.00";
            checkSelectAll.Checked = false;
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

                    double totalPendingAmount = 0.00;
                    //string ids /*= "";*/
                    //int isCheckAll_int = 0;
                    if (value)
                    {
                        for (int i = 0; i < dgvOrders.Rows.Count; i++)
                        {
                            dgvOrders.Rows[i].Cells["selectt"].Value = checkSelectAll.Checked;
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
                        if (checkSelectAll.Checked && !isCheckAll_int.Equals(dgvOrders.Rows.Count))
                        {
                            cCheck = 1;
                            checkSelectAll.Checked = false;
                        }
                        else if (!checkSelectAll.Checked && isCheckAll_int.Equals(dgvOrders.Rows.Count))
                        {
                            checkSelectAll.Checked = true;
                        }
                    }

                    JArray jarrayBody = new JArray();
                    for (int i = 0; i < dgvOrders.Rows.Count; i++)
                    {
                        if (Convert.ToBoolean(dgvOrders.Rows[i].Cells["selectt"].Value.ToString()) == true)
                        {
                            totalPendingAmount += Convert.ToDouble(dgvOrders.Rows[i].Cells["amountdue"].Value.ToString());
                            jarrayBody.Add(Convert.ToInt32(dgvOrders.Rows[i].Cells["base_id"].Value));
                        }
                    }
                    lblpendingamount.Text = "Pending Amount: " + totalPendingAmount.ToString("n2");
                    dgvitems.Rows.Clear();
                    string sDate = gForType.Equals("for Payment") ? "&transdate=" : "&transdate=" + dtFromDate.Value.ToString("yyyy-MM-dd");
                    JObject jsonObjectBody = new JObject();
                    jsonObjectBody.Add("ids", jarrayBody);
                    var client = new RestClient(utilityc.URL);
                    client.Timeout = -1;
                    var request = new RestRequest("/api/sales/summary_trans?transtype=" + gSalesType + sDate);
                    Console.WriteLine("/api/sales/summary_trans?transtype=" + gSalesType + sDate);
                    Console.WriteLine(jarrayBody);
                    request.AddHeader("Authorization", "Bearer " + token);
                    request.AddParameter("application/json", jsonObjectBody, ParameterType.RequestBody);
                    request.Method = Method.PUT;
                    var response = client.Execute(request);
                    //Console.WriteLine("/api/sales/summary_trans?transtype=" + gSalesType + sDate);
                    //Console.WriteLine(jsonObjectBody);
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
                            string forSAPAmountColumnName = (gForType.Equals("for SAP") ? "doctotal" : "amount_due");
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
                                                    else if (z.Key.Equals("delfee"))
                                                    {
                                                        txtDelFee.Text = string.IsNullOrEmpty(z.Value.ToString()) ? "0.00" : Convert.ToDouble(z.Value.ToString()).ToString("n2");
                                                    }
                                                    else if (z.Key.Equals("disc_amount"))
                                                    {
                                                        txtDiscountAmount.Text = string.IsNullOrEmpty(z.Value.ToString()) ? "0.00" : Convert.ToDouble(z.Value.ToString()).ToString("n2");
                                                    }
                                                    else if (z.Key.Equals("disc_amount"))
                                                    {
                                                        txtDiscountAmount.Text = string.IsNullOrEmpty(z.Value.ToString()) ? "0.00" : Convert.ToDouble(z.Value.ToString()).ToString("n2");
                                                    }
                                                    else if (z.Key.Equals(forSAPAmountColumnName))
                                                    {
                                                        txtlAmountPayable.Text = string.IsNullOrEmpty(z.Value.ToString()) ? "0.00" : Convert.ToDouble(z.Value.ToString()).ToString("n2");
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
            computeChange("POS", "Cell Click");

            //int int_selectAll = 0;
            //for (int i = 0; i < dgvOrders.Rows.Count; i++)
            //{
            //    if (Convert.ToBoolean(dgvOrders.Rows[i].Cells["selectt"].Value.ToString()) == true)
            //    {
            //        int_selectAll += 1;
            //    }
            //}
            //if (int_selectAll <= 0 && checkSelectAll.Checked)
            //{
            //    checkSelectAll.Checked = false;
            //}
        }

        private void dgvOrders_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvOrders.Rows.Count > 0)
            {
                if (e.ColumnIndex == 0)
                {
                    selectOrders(false);
                }
                else if (e.ColumnIndex == 16)
                {
                    dgvOrders.CurrentCell = dgvOrders[0, dgvOrders.CurrentRow.Index];
                    dgvOrders.ClearSelection();
                    dgvOrders.CurrentRow.Cells["total_payment"].Selected = true;
                    EnterAmount frm = new EnterAmount();
                    EnterAmount.amount = 0.00;
                    EnterAmount.amount = Convert.ToDouble(dgvOrders.CurrentRow.Cells["total_payment"].Value.ToString());
                    frm.reference = dgvOrders.CurrentRow.Cells["ordernum"].Value.ToString();
                    frm.ShowDialog();
                    dgvOrders.CurrentRow.Cells["total_payment"].Value = Convert.ToDecimal(string.Format("{0:0.00}", EnterAmount.amount));
                    computeChange("POS", "");
                }
                else if (e.ColumnIndex == 17)
                {
                    int id = 0, intTemp = 0;
                    id = Int32.TryParse(dgvOrders.CurrentRow.Cells["base_id"].Value.ToString(), out intTemp) ? Convert.ToInt32(dgvOrders.CurrentRow.Cells["base_id"].Value.ToString()) : intTemp;
                    JObject jo = JObject.Parse(salesDetails(id));

                    DataTable dt = populateToPay(jo);
                    print_toPay frm = new print_toPay();
                    frm.dtResult = dt;
                    frm.ShowDialog();
                }
            }
        }

        public DataTable populateToPay(JObject jo)
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


            bool isSuccess = false, boolTemp = false;
            foreach (var q in jo)
            {
                if (q.Key.Equals("success"))
                {
                    isSuccess = bool.TryParse(q.Value.ToString(), out boolTemp) ? Convert.ToBoolean(q.Value.ToString()) : boolTemp;
                    break;
                }
            }
            if (isSuccess)
            {
                JArray jaSalesRow = new JArray();
                string customerCode = "", referenceNumber = "";
                DateTime dtTransDate = new DateTime(), dateTImeTemp = new DateTime();
                double totalGross = 0.00, totalDiscount = 0.00, totalNet = 0.00, doubleTemp = 0.00;
                foreach (var q in jo)
                {
                    if (q.Key.Equals("data"))
                    {
                        if (q.Value.ToString().Substring(0, 1).Equals("{"))
                        {
                            JObject joData = JObject.Parse(q.Value.ToString());
                            foreach (var w in joData)
                            {
                                if (w.Key.Equals("salesrow"))
                                {
                                    if (w.Value.ToString().Substring(0, 1).Equals("["))
                                    {
                                        jaSalesRow = JArray.Parse(w.Value.ToString());
                                    }
                                }
                                else if (w.Key.Equals("reference"))
                                {
                                    referenceNumber = w.Value.ToString();
                                }
                                else if (w.Key.Equals("transdate"))
                                {
                                    string replaceT = w.Value.ToString().Replace("T", "");
                                    dtTransDate = DateTime.TryParse(replaceT, out dateTImeTemp) ? Convert.ToDateTime(replaceT) : new DateTime();
                                }
                                else if (w.Key.Equals("cust_code"))
                                {
                                    customerCode = w.Value.ToString();
                                }
                                else if (w.Key.Equals("gross"))
                                {
                                    totalGross = double.TryParse(w.Value.ToString(), out doubleTemp) ? Convert.ToDouble(w.Value.ToString()) : doubleTemp;
                                }
                                else if (w.Key.Equals("disc_amount"))
                                {
                                    totalDiscount = double.TryParse(w.Value.ToString(), out doubleTemp) ? Convert.ToDouble(w.Value.ToString()) : doubleTemp;
                                }
                                else if (w.Key.Equals("gross"))
                                {
                                    totalGross = double.TryParse(w.Value.ToString(), out doubleTemp) ? Convert.ToDouble(w.Value.ToString()) : doubleTemp;
                                }
                                else if (w.Key.Equals("doctotal"))
                                {
                                    totalNet = double.TryParse(w.Value.ToString(), out doubleTemp) ? Convert.ToDouble(w.Value.ToString()) : doubleTemp;
                                }
                            }
                        }
                    }
                }

                for (int i = 0; i < jaSalesRow.Count(); i++)
                {
                    JObject joData = JObject.Parse(jaSalesRow[i].ToString());
                    string itemCode = "";
                    double quantity = 0.00, price = 0.00, discAmount = 0.00, netAmount = 0.00, grossAmount = 0.00;
                    foreach (var q in joData)
                    {
                        if (q.Key.Equals("item_code"))
                        {
                            itemCode = q.Value.ToString();
                        }
                        else if (q.Key.Equals("quantity"))
                        {
                            quantity = double.TryParse(q.Value.ToString(), out doubleTemp) ? Convert.ToDouble(q.Value.ToString()) : doubleTemp;
                        }
                        else if (q.Key.Equals("unit_price"))
                        {
                            price = double.TryParse(q.Value.ToString(), out doubleTemp) ? Convert.ToDouble(q.Value.ToString()) : doubleTemp;
                        }
                        else if (q.Key.Equals("disc_amount"))
                        {
                            discAmount = double.TryParse(q.Value.ToString(), out doubleTemp) ? Convert.ToDouble(q.Value.ToString()) : doubleTemp;
                        }
                        else if (q.Key.Equals("gross"))
                        {
                            grossAmount = double.TryParse(q.Value.ToString(), out doubleTemp) ? Convert.ToDouble(q.Value.ToString()) : doubleTemp;
                        }
                        else if (q.Key.Equals("linetotal"))
                        {
                            netAmount = double.TryParse(q.Value.ToString(), out doubleTemp) ? Convert.ToDouble(q.Value.ToString()) : doubleTemp;
                        }
                    }
                    dt.Rows.Add(customerCode, referenceNumber, dtTransDate.ToString("MM/dd/yyyy"), itemCode, quantity, price, discAmount, netAmount, grossAmount, totalGross, totalDiscount, totalNet);
                }
            }
            return dt;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (dgvOrders.Rows.Count <= 0)
            {
                MessageBox.Show("No order found", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                int countSelected = 0;
                for (int i = 0; i < dgvOrders.Rows.Count; i++)
                {
                    if (Convert.ToBoolean(dgvOrders.Rows[i].Cells["selectt"].Value.ToString()))
                    {
                        countSelected += 1;
                    }
                }
                if (countSelected <= 0)
                {
                    MessageBox.Show("No order selected", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    DialogResult dialogResult = MessageBox.Show("Are you sure you want to " + (gForType == "for Payment" ? "pay" : "confirm") + "?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialogResult == DialogResult.Yes)
                    {
                        if (gForType == "for Payment")
                        {
                            if (insertTransaction(true, 0))
                            {
                                dtSelectedDeposit.Rows.Clear();
                                string subURL = gForType == "for Payment" ? "/api/payment/new" : "/api/sales/for_confirm";
                                loadData(subURL);
                            }
                        }
                        else if (gForType == "for Confirmation")
                        {
                            confirmARSales();
                        }
                        else if (gForType == "for SAP")
                        {
                            string ids = "";
                            int int_hasSelected = 0;
                            for (int i = 0; i < dgvOrders.Rows.Count; i++)
                            {
                                if (Convert.ToBoolean(dgvOrders.Rows[i].Cells["selectt"].Value.ToString()) == true)
                                {
                                    ids = ids + "," + dgvOrders.Rows[i].Cells["base_id"].Value.ToString();
                                    int_hasSelected += 1;
                                }
                            }
                            ids = (string.IsNullOrEmpty(ids) ? "" : ids.Substring(1));
                            if (int_hasSelected > 0)
                            {
                                forSAPAR_SAPNumber forSAPAR_SAPNumber = new forSAPAR_SAPNumber();
                                forSAPAR_SAPNumber.ids = ids;
                                forSAPAR_SAPNumber.ShowDialog();
                                if (forSAPAR_SAPNumber.isSubmit)
                                {
                                    string subURL = gForType == "for Payment" ? "/api/payment/new" : "/api/sales/for_confirm";
                                    loadData(subURL);
                                }
                            }
                        }
                    }
                }
            }
        }

        public string salesDetails(int selectedID)
        {
            string result = "";
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

                    var request = new RestRequest("/api/sales/details/" + selectedID);
                    request.AddHeader("Authorization", "Bearer " + token);
                    request.Method = Method.GET;

                    var response = client.Execute(request);

                    if (response.ErrorMessage == null)
                    {
                        result = response.Content;
                    }
                    else
                    {
                        result = response.ErrorMessage;
                    }
                }
            }
            return result;
        }

        public void confirmARSales()
        {
            if (dgvOrders.Rows.Count <= 0)
            {
                MessageBox.Show("No order found", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                int countSelected = 0;
                for (int i = 0; i < dgvOrders.Rows.Count; i++)
                {
                    if (Convert.ToBoolean(dgvOrders.Rows[i].Cells["selectt"].Value.ToString()))
                    {
                        countSelected += 1;
                    }
                }
                if (countSelected <= 0)
                {
                    MessageBox.Show("No order selected", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    string ids = "";
                    for (int i = 0; i < dgvOrders.Rows.Count; i++)
                    {
                        if (Convert.ToBoolean(dgvOrders.Rows[i].Cells["selectt"].Value.ToString()) == true)
                        {
                            //totalPendingAmount += Convert.ToDouble(dgvOrders.Rows[i].Cells["amountdue"].Value.ToString());
                            ids = ids + "," + dgvOrders.Rows[i].Cells["base_id"].Value.ToString();
                        }
                    }
                    ids = (string.IsNullOrEmpty(ids) ? "" : ids.Substring(1));

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
                            var request = new RestRequest("/api/sales/confirm?ids=%5B" + ids + "%5D");
                            request.AddHeader("Authorization", "Bearer " + token);
                            request.Method = Method.PUT;

                            var response = client.Execute(request);

                            if (response.ErrorMessage == null)
                            {
                                JObject jObjectResponse = JObject.Parse(response.Content);
                                bool isSuccess = false;
                                foreach (var x in jObjectResponse)
                                {
                                    if (x.Key.Equals("success"))
                                    {
                                        isSuccess = true;
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
                                MessageBox.Show(msg, isSuccess ? "Success" : "Validation", MessageBoxButtons.OK, isSuccess ? MessageBoxIcon.Information : MessageBoxIcon.Warning);
                                if (isSuccess)
                                {
                                    string subURL = gForType == "for Payment" ? "/api/payment/new" : "/api/sales/for_confirm";
                                    loadData(subURL);
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

        public bool insertTransaction(bool isMultipleTransaction, double ARSalesAmount)
        {
            bool result = false;
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
                    var request = new RestRequest("/api/payment/new");
                    request.AddHeader("Authorization", "Bearer " + token);
                    request.Method = Method.POST;
                    JObject joBody = new JObject();
                    if (isMultipleTransaction)
                    {
                        DataTable dtSelectedDepositTEMP = new DataTable();
                        dtSelectedDepositTEMP.Columns.Add("id");
                        dtSelectedDepositTEMP.Columns.Add("amount");
                        dtSelectedDepositTEMP.Columns.Add("payment_type");
                        dtSelectedDepositTEMP.Columns.Add("sapnum");
                        dtSelectedDepositTEMP.Columns.Add("reference2");

                        foreach (DataRow row in dtSelectedDeposit.Rows)
                        {
                            dtSelectedDepositTEMP.Rows.Add(row["id"], row["amount"], row["payment_type"], row["sapnum"], row["reference2"]);
                        }
                        JObject joHeader = new JObject();
                        JArray jaPaymentRows = new JArray();
                        JArray jaSalesDetails = new JArray();
                        string headerCustCode = "";
                        //LOOP payment types
                        double paymentMethodAmount = 0.00;
                        foreach (DataRow row in dtSelectedDepositTEMP.Rows)
                        {
                            JObject joPaymentRows = new JObject();
                            if (row["id"].ToString() != "")
                            {
                                string keyNameID = row["payment_type"].ToString() == "FDEPS" ? "deposit_id" : "return_id";
                                joPaymentRows.Add(keyNameID, Convert.ToInt32(row["id"].ToString()));
                            }
                            joPaymentRows.Add("payment_type", row["payment_type"].ToString());
                            double amt = string.IsNullOrEmpty(row["amount"].ToString()) ? 0.00 : Convert.ToDouble(row["amount"].ToString());

                            joPaymentRows.Add("amount", amt);
                            paymentMethodAmount += Convert.ToDouble(row["amount"].ToString());
                            if (string.IsNullOrEmpty(row["sapnum"].ToString()))
                            {
                                joPaymentRows.Add("sap_number", null);
                            }
                            else
                            {
                                joPaymentRows.Add("sap_number", Convert.ToInt32(row["sapnum"].ToString()));
                            }
                            joPaymentRows.Add("reference2", string.IsNullOrEmpty(row["reference2"].ToString()) ? null : row["reference2"].ToString());
                            jaPaymentRows.Add(joPaymentRows);
                        }
                        double totalAmount = 0.00;
                        int firstLoop = 0;
                        for (int i = 0; i < dgvOrders.Rows.Count; i++)
                        {
                            if (Convert.ToBoolean(dgvOrders.Rows[i].Cells["selectt"].Value.ToString()))
                            {
                                firstLoop += 1;
                                if (firstLoop == 1)
                                {
                                    //MessageBox.Show(dgvOrders.Rows[i].Cells["cust_code"].Value.ToString());
                                    headerCustCode = dgvOrders.Rows[i].Cells["cust_code"].Value.ToString();
                                }
                                JObject joSalesDetails = new JObject();
                                joSalesDetails.Add("sales_id", Convert.ToInt32(dgvOrders.Rows[i].Cells["base_id"].Value.ToString()));
                                joSalesDetails.Add("total_payment", Convert.ToDouble(dgvOrders.Rows[i].Cells["total_payment"].Value.ToString()));
                                totalAmount += Convert.ToDouble(dgvOrders.Rows[i].Cells["total_payment"].Value.ToString());
                                jaSalesDetails.Add(joSalesDetails);
                            }
                        }
                        joHeader.Add("cust_code", headerCustCode);
                        joHeader.Add("transdate", DateTime.Now.ToString("yyyy/MM/dd HH:mm"));
                        joHeader.Add("remarks", null);
                        joHeader.Add("reference", null);
                        joBody.Add("header", joHeader);
                        joBody.Add("payment_rows", jaPaymentRows);
                        joBody.Add("sales_details", jaSalesDetails);
                    }
                    Console.WriteLine(joBody);
                    request.AddParameter("application/json", joBody, ParameterType.RequestBody);
                    var response = client.Execute(request);
                    JObject jObjectResponse = JObject.Parse(response.Content);

                    foreach (var x in jObjectResponse)
                    {
                        if (x.Key.Equals("success"))
                        {
                            if (Convert.ToBoolean(x.Value.ToString()))
                            {
                                result = true;
                            }
                        }
                    }

                    if (!result)
                    {
                        string msg = "Object message key not found";
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
                    else
                    {
                        string msg = "Object message key not found";
                        foreach (var x in jObjectResponse)
                        {
                            if (x.Key.Equals("message"))
                            {
                                msg = x.Value.ToString();
                            }
                        }
                        Cursor.Current = Cursors.Default;
                        MessageBox.Show(msg, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            Cursor.Current = Cursors.Default;
            return result;
        }

        private void txtsearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                string subURL = gForType == "for Payment" ? "/api/payment/new" : "/api/sales/for_confirm";
                loadData(subURL);
            }
        }

        private void cmbsales_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (cSales <= 0)
            //{
            //    string subURL = gForType == "for Payment" ? "/api/payment/new" : "/api/sales/for_confirm";
            //    loadData(subURL);
            //}
        }

        private void btnrefresh_Click(object sender, EventArgs e)
        {
            string subURL = gForType == "for Payment" ? "/api/payment/new" : "/api/sales/for_confirm";
            loadData(subURL);
        }

        private void btnVoid_Click(object sender, EventArgs e)
        {
            if (dgvOrders.Rows.Count <= 0)
            {
                MessageBox.Show("No order found", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                int countSelected = 0;
                for (int i = 0; i < dgvOrders.Rows.Count; i++)
                {
                    if (Convert.ToBoolean(dgvOrders.Rows[i].Cells["selectt"].Value.ToString()))
                    {
                        countSelected += 1;
                    }
                }
                if (countSelected <= 0)
                {
                    MessageBox.Show("No order selected", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    string ids = "";
                    int count = 0;
                    string selectedRef = "Selected #: " + Environment.NewLine;
                    for (int i = 0; i < dgvOrders.Rows.Count; i++)
                    {
                        if (Convert.ToBoolean(dgvOrders.Rows[i].Cells["selectt"].Value.ToString()) == true)
                        {
                            //totalPendingAmount += Convert.ToDouble(dgvOrders.Rows[i].Cells["amountdue"].Value.ToString());
                            ids = ids + "," + dgvOrders.Rows[i].Cells["base_id"].Value.ToString();
                            selectedRef += dgvOrders.Rows[i].Cells["ordernum"].Value.ToString() + Environment.NewLine;
                            count += 1;
                        }
                    }
                    ids = (string.IsNullOrEmpty(ids) ? "" : ids.Substring(1));

                    voidForm voidd = new voidForm();
                    //voidd.baseNum = Convert.ToInt32(dgvOrders.CurrentRow.Cells["transnumber"].Value.ToString());
                    voidd.lblOrderNumber.Text = "(" + count.ToString("N0") + ")";
                    voidd.selectedReference = selectedRef;
                    voidd.selectedID = ids;
                    voidd.ShowDialog();
                    if (voidForm.isSubmit)
                    {
                        string subURL = gForType == "for Payment" ? "/api/payment/new" : "/api/sales/for_confirm";
                        loadData(subURL);
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SelectAdvancePayment selectAdvancePayment = new SelectAdvancePayment("");
            selectAdvancePayment.ShowDialog();
            computeChange("POS", "");
        }

        public void computeChange(string type, string type2)
        {
            //dtSelectedDeposit.Columns.Add("id");
            //dtSelectedDeposit.Columns.Add("amount");
            //dtSelectedDeposit.Columns.Add("payment_type");
            //dtSelectedDeposit.Columns.Add("sapnum");
            //dtSelectedDeposit.Columns.Add("reference2");
            DataTable dtTemp = dtSelectedDeposit;
            double selectedAmount = 0.00, totalAmtPayable = 0.00;
            if (type.Equals("POS"))
            {
                for (int i = 0; i < dgvOrders.Rows.Count; i++)
                {
                    if (Convert.ToBoolean(dgvOrders.Rows[i].Cells["selectt"].Value.ToString()))
                    {
                        selectedAmount += string.IsNullOrEmpty(dgvOrders.Rows[i].Cells["tenderamount"].Value.ToString()) ? 0.00 : Convert.ToDouble(dgvOrders.Rows[i].Cells["tenderamount"].Value.ToString());
                        totalAmtPayable += string.IsNullOrEmpty(dgvOrders.Rows[i].Cells["total_payment"].Value.ToString()) ? 0.00 : Convert.ToDouble(dgvOrders.Rows[i].Cells["total_payment"].Value.ToString());
                    }
                }
            }
            else
            {
                for (int i = 0; i < dgvOrders.Rows.Count; i++)
                {
                    if (Convert.ToBoolean(dgvOrders.Rows[i].Cells["selectt"].Value.ToString()))
                    {
                        totalAmtPayable += string.IsNullOrEmpty(dgvOrders.Rows[i].Cells["total_payment"].Value.ToString()) ? 0.00 : Convert.ToDouble(dgvOrders.Rows[i].Cells["total_payment"].Value.ToString());
                    }
                }
                foreach (DataRow row in dtTemp.Rows)
                {
                    if (row["type"].ToString().Equals("POS"))
                    {
                        selectedAmount += string.IsNullOrEmpty(row["amount"].ToString()) ? 0.00 : Convert.ToDouble(row["amount"].ToString());
                    }
                }
            }
            txtlAmountPayable.Text = totalAmtPayable.ToString("n2");
            double deletedAmount = 0.00;
            bool hasPOS = false;
            if (dtTemp.Rows.Count > 0)
            {
                for (int i = 0; i < dtTemp.Rows.Count; i++)
                {
                    DataRow row = dtTemp.Rows[i];
                    if (row["type"].ToString().Equals("POS"))
                    {
                        deletedAmount = Convert.ToDouble(row["amount"].ToString());
                        dtSelectedDeposit.Rows.RemoveAt(i);
                        hasPOS = true;
                    }
                }
            }

            if (type2.Equals("Cell Click") && selectedAmount > 0)
            {
                dtSelectedDeposit.Rows.Add(null, selectedAmount, "CASH", "", "", "POS");
            }
            else if ((selectedAmount > 0 && hasPOS))
            {
                selectedAmount -= deletedAmount == selectedAmount ? 0.00 : deletedAmount;
                dtSelectedDeposit.Rows.Add(null, selectedAmount, "CASH", "", "", "POS");
            }

            double totalPayment = 0.00;
            if (dtTemp.Rows.Count > 0)
            {
                foreach (DataRow row in dtTemp.Rows)
                {
                    totalPayment += (string.IsNullOrEmpty(row["amount"].ToString()) ? 0.00 : Convert.ToDouble(row["amount"].ToString()));
                }
            }
            txtTotalPayment.Text = totalPayment.ToString("n2");
            double num1 = (string.IsNullOrEmpty(txtTotalPayment.Text) ? 0.00 : Convert.ToDouble(txtTotalPayment.Text));
            double amountDue = (string.IsNullOrEmpty(txtlAmountPayable.Text) ? 0.00 : Convert.ToDouble(txtlAmountPayable.Text));
            double change = num1 - amountDue;
            txtChange.Text = (change > 0 ? change : 0.00).ToString("n2");
        }

        private void cmbFromTime_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cFromTime <= 0)
            {
                string subURL = gForType == "for Payment" ? "/api/payment/new" : "/api/sales/for_confirm";
                loadData(subURL);
            }
        }

        private void cmbToTime_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cToTime <= 0)
            {
                string subURL = gForType == "for Payment" ? "/api/payment/new" : "/api/sales/for_confirm";
                loadData(subURL);
            }
        }

        private void cmbBranches_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dgvitems_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvitems.Rows.Count > 0 && dgvOrders.Rows.Count > 0)
            {
                if (e.RowIndex >= 0)
                {
                    try
                    {
                        JArray jarrayBody = new JArray();
                        for (int i = 0; i < dgvOrders.Rows.Count; i++)
                        {
                            if (Convert.ToBoolean(dgvOrders.Rows[i].Cells["selectt"].Value.ToString()) == true)
                            {
                                jarrayBody.Add(Convert.ToInt32(dgvOrders.Rows[i].Cells["base_id"].Value));
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

        private void checkDate_CheckedChanged(object sender, EventArgs e)
        {
            dtFromDate.Visible = checkDate.Checked;
            //string subURL = gForType == "for Payment" ? "/api/payment/new" : "/api/sales/for_confirm";
            //loadData(subURL);
        }

        private void cmbFromTime_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void checkToDate_CheckedChanged(object sender, EventArgs e)
        {
            dtToDate.Visible = checkToDate.Checked;
            //string subURL = gForType == "for Payment" ? "/api/payment/new" : "/api/sales/for_confirm";
            //loadData(subURL);
        }

        private void PendingOrder2_Leave(object sender, EventArgs e)
        {

        }

        public bool IsNumeric(string text)
        {
            double test;
            return double.TryParse(text, out test);
        }

        private void dgvOrders_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 6)
            {
                if (!IsNumeric(dgvOrders.CurrentRow.Cells["total_payment"].Value.ToString()))
                {
                    MessageBox.Show("Total Payment must be a number", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dgvOrders.CurrentRow.Cells["total_payment"].Value = "0.00";
                }
            }
        }

        private void cmbBranches_SelectionChangeCommitted(object sender, EventArgs e)
        {

        }

        private void cmbSearchType_SelectionChangeCommitted(object sender, EventArgs e)
        {

        }

        private void cmbsales_SelectionChangeCommitted(object sender, EventArgs e)
        {

        }

        private void cmbCustomerType_SelectionChangeCommitted(object sender, EventArgs e)
        {

        }

        private void cmbBranches_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                if (cBranch <= 0)
                {
                    loadSalesAgent();
                    string subURL = gForType == "for Payment" ? "/api/payment/new" : "/api/sales/for_confirm";
                    loadData(subURL);
                }
            }
        }

        private void btnSearchQuery_Click(object sender, EventArgs e)
        {
            string subURL = gForType == "for Payment" ? "/api/payment/new" : "/api/sales/for_confirm";
            loadData(subURL);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string subURL = gForType == "for Payment" ? "/api/payment/new" : "/api/sales/for_confirm";
            loadData(subURL);
        }

        private void cmbToTime_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dtToDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dgvOrders_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (dgvOrders.HitTest(e.X, e.Y).ColumnIndex == 4 && gForType == "for Payment")
                {

                    ContextMenu m = new ContextMenu();
                    m.MenuItems.Add(new MenuItem("Create Sales Return", MenuItemNew_Click));

                    currentMouseOverRow = dgvOrders.HitTest(e.X, e.Y).RowIndex;
                    if(currentMouseOverRow >= 0)
                    {
                        m.Show(dgvOrders, new Point(e.X, e.Y));
                    }
                }
            }
        }

        private void MenuItemNew_Click(object sender, EventArgs e)
        {

            if(currentMouseOverRow >= 0)
            {
                int baseID = 0, intTemp = 0;
                baseID = int.TryParse(dgvOrders.Rows[currentMouseOverRow].Cells["base_id"].Value.ToString(), out intTemp) ? Convert.ToInt32(dgvOrders.Rows[currentMouseOverRow].Cells["base_id"].Value.ToString()) : intTemp;


                JObject joFromResponse = JObject.Parse(dtLoadSales(baseID));
                JObject joData = JObject.Parse(joFromResponse["data"].ToString());
                JArray jaSalesRows = (JArray)joData["salesrow"];
                DataTable dt = (DataTable)JsonConvert.DeserializeObject(jaSalesRows.ToString(), (typeof(DataTable)));

                string currentRef = joFromResponse["data"]["reference"].IsNullOrEmpty() ? "" : joFromResponse["data"]["reference"].ToString();
                string custCode = joFromResponse["data"]["cust_code"].IsNullOrEmpty() ? "" : joFromResponse["data"]["cust_code"].ToString();
                string custName = joFromResponse["data"]["cust_name"].IsNullOrEmpty() ? "" : joFromResponse["data"]["cust_code"].ToString();
                string remarks = joFromResponse["data"]["remarks"].IsNullOrEmpty() ? "" : joFromResponse["data"]["remarks"].ToString();
                string transType = joFromResponse["data"]["transtype"].IsNullOrEmpty() ? "" : joFromResponse["data"]["transtype"].ToString();
                string reference2 = joFromResponse["data"]["reference2"].IsNullOrEmpty() ? "" : joFromResponse["data"]["reference2"].ToString();
                string sap_number = joFromResponse["data"]["sap_number"].IsNullOrEmpty() ? "" : joFromResponse["data"]["sap_number"].ToString();

                double discprcnt = 0.0, doubleTemp = 0.00, GCAmount = 0.00;
                discprcnt = joFromResponse["data"]["discprcnt"].IsNullOrEmpty() ? 0.00 : double.TryParse(joFromResponse["data"]["discprcnt"].ToString(), out doubleTemp) ? Convert.ToDouble(joFromResponse["data"]["discprcnt"].ToString()) : doubleTemp;

                GCAmount = joFromResponse["data"]["gc_amount"].IsNullOrEmpty() ? 0.00 : double.TryParse(joFromResponse["data"]["gc_amount"].ToString(), out doubleTemp) ? Convert.ToDouble(joFromResponse["data"]["gc_amount"].ToString()) : doubleTemp;

                JObject joHeader = new JObject();
                joHeader.Add("transdate", DateTime.Now);
                joHeader.Add("cust_code", custCode);
                joHeader.Add("cust_name", custCode);
                joHeader.Add("base_id", baseID);
                joHeader.Add("base_ref", currentRef);
                joHeader.Add("discprcnt", discprcnt);
                joHeader.Add("remarks", string.IsNullOrEmpty(remarks.Trim()) ? null : remarks);
                joHeader.Add("transtype", transType);
                joHeader.Add("reference2", reference2);
                joHeader.Add("gc_amount", GCAmount);
                joHeader.Add("sap_number", string.IsNullOrEmpty(sap_number.Trim()) ? null : sap_number);

                JArray jaRows = new JArray();


                foreach (DataRow row in dt.Rows)
                {
                   
                    JObject joRow = new JObject();
                    joRow.Add("item_code", row["item_code"].ToString());
                    joRow.Add("quantity", double.TryParse(row["quantity"].ToString(), out doubleTemp) ? Convert.ToDouble(row["quantity"].ToString()) : (double?)null);
                    joRow.Add("unit_price", double.TryParse(row["unit_price"].ToString(), out doubleTemp) ? Convert.ToDouble(row["unit_price"].ToString()) : (double?)null);
                    joRow.Add("uom", row["uom"].ToString());
                    joRow.Add("whsecode", row["whsecode"].ToString());
                    joRow.Add("sales_row_id", int.TryParse(row["id"].ToString(), out intTemp) ? Convert.ToDouble(row["id"].ToString()) : intTemp);
                    jaRows.Add(joRow);
                }
                JObject joBody = new JObject();
                joBody.Add("header", joHeader);
                joBody.Add("rows", jaRows);

                SalesReturn_Form frm = new SalesReturn_Form(joBody);
                frm.ShowDialog();
            }
        }
        

        public string dtLoadSales(int baseID)
        {
            api_class apic = new api_class();
            string sParams = baseID.ToString();
            string sResult = apic.loadData("/api/sales/details/", sParams, "", "", Method.GET, true);
            if (!string.IsNullOrEmpty(sResult) && sResult.Substring(0, 1).Equals("{"))
            {
                return sResult;
            }
            return "{}";
        }

        private void btnSalesReturn_Click(object sender, EventArgs e)
        {
            Select_SalesReturn frm = new Select_SalesReturn();
            frm.ShowDialog();
            computeChange("POS", "");
        }

        private void cmbCustomerType_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (cCustType <= 0)
            //{
            //    string subURL = gForType == "for Payment" ? "/api/payment/new" : "/api/sales/for_confirm";
            //    loadData(subURL);
            //}
        }

        private void cmbSearchType_SelectedIndexChanged(object sender, EventArgs e)
        {
            searchFilter();
        }

        public void pay(JObject jObjectPay, DataTable dtDeposit)
        {
            int id = 0;
            double amount = 0.00;
            foreach (var q in jObjectPay)
            {
                if (q.Key.Equals("id"))
                {
                    id = Convert.ToInt32(q.Value.ToString());
                }
                else if (q.Key.Equals("amount"))
                {
                    amount = Convert.ToDouble(q.Value.ToString());
                }
            }
            //DataTable dtRows = new DataTable();
            //dtRows.Columns.Add("id");
            //dtRows.Columns.Add("amount");

            while (amount > 0)
            {
                foreach (DataRow row in dtDeposit.Rows)
                {
                    if (Convert.ToDouble(row["amount"].ToString()) != 0.00)
                    {
                        double payment = 0.00;
                        if (Convert.ToDouble(row["amount"]) >= amount)
                        {
                            payment += amount;
                            row["amount"] = (Convert.ToDouble(row["amount"].ToString()) - amount);
                            dtPayment.Rows.Add(row["id"], payment, row["payment_type"], row["sapnum"], row["reference2"]);
                            amount = 0;
                            break;
                        }
                        else if (Convert.ToDouble(row["amount"]) < amount)
                        {
                            payment += Convert.ToDouble(row["amount"]);
                            amount -= Convert.ToDouble(row["amount"].ToString());
                            dtPayment.Rows.Add(row["id"], payment, row["payment_type"], row["sapnum"], row["reference2"]);
                            row["amount"] = 0;
                        }
                    }
                }
                break;
            }
        }

        private void cmbBranches_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cBranch <= 0)
            {
                loadSalesAgent();
                //string subURL = gForType == "for Payment" ? "/api/payment/new" : "/api/sales/for_confirm";
                //loadData(subURL);
            }
        }

        public DataTable getSelectedRows()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("base_id");
            dt.Columns.Add("base_num");
            dt.Columns.Add("cust_code");
            dt.Columns.Add("amountdue");
            dt.Columns.Add("tenderamount");
            dt.Columns.Add("tendertype");
            for (int i = 0; i < dgvOrders.Rows.Count; i++)
            {
                if (Convert.ToBoolean(dgvOrders.Rows[i].Cells["selectt"].Value.ToString()))
                {
                    dt.Rows.Add(Convert.ToInt32(dgvOrders.Rows[i].Cells["base_id"].Value.ToString()), dgvOrders.Rows[i].Cells["transnumber"].Value.ToString(), dgvOrders.Rows[i].Cells["cust_code"].Value.ToString(), Convert.ToDouble(dgvOrders.Rows[i].Cells["amountdue"].Value.ToString()), Convert.ToDouble(dgvOrders.Rows[i].Cells["tenderamount"].Value.ToString()), dgvOrders.Rows[i].Cells["tendertype"].Value.ToString());
                }
            }
            return dt;
        }

        //private void btnForPayment_Click(object sender, EventArgs e)
        //{
        //    btnForPayment.ForeColor = Color.Black;
        //    btnForConfirmation.ForeColor = Color.White;
        //    counts();
        //    string subURL = btnForPayment.ForeColor == Color.Black ? "/api/payment/new" : "/api/sales/for_confirm";
        //    btnConfirm.Text = "PAY";
        //    button1.Visible = true;
        //    btnVoid.Visible = true;
        //    btnPaymentMethod.Visible=true;
        //    loadData(subURL);
        //}

        //private void btnForConfirmation_Click(object sender, EventArgs e)
        //{
        //    btnForPayment.ForeColor = Color.White;
        //    btnForConfirmation.ForeColor = Color.Black;
        //    counts();
        //    string subURL = btnForPayment.ForeColor == Color.Black ? "/api/payment/new" : "/api/sales/for_confirm";
        //    btnConfirm.Text = "CONFIRM";
        //    button1.Visible = false;
        //    btnVoid.Visible = false;
        //    btnPaymentMethod.Visible = false;
        //    loadData(subURL);
        //}

        private void btnPaymentMethod_Click(object sender, EventArgs e)
        {
            PaymentMethodList paymentMethodList = new PaymentMethodList("");
            paymentMethodList.ShowDialog();
            computeChange("Payment Method", "");
        }

        private void checkSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            if (dgvOrders.Rows.Count > 0)
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
    }
}