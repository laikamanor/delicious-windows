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
using DeliciousPartnerApp.API_Class.Payment_Type;
using DeliciousPartnerApp.API_Class.Branch;
using DeliciousPartnerApp.API_Class.Warehouse;
namespace DeliciousPartnerApp
{
    public partial class CashTransactionReport : Form
    {
        DataTable dtBranch = new DataTable(), dtWarehouse = new DataTable();
        branch_class branchc = new branch_class();
        warehouse_class warehousec = new warehouse_class();
        utility_class utilityc = new utility_class();
        paymenttype_class paymenttypec = new paymenttype_class();
        user_clas userc = new user_clas();
        DataTable dtUsers = new DataTable();
        DataTable dtCashier = new DataTable();
        int cBranch = 1, cWarehouse = 1, cUser = 1, cPaymentType = 1, cSalesType = 1;
        public CashTransactionReport()
        {
            InitializeComponent();
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
                    branchName = row["name"].ToString();
                    break;
                }
            }
            cmbBranch.SelectedIndex = cmbBranch.Items.IndexOf(branchName);  
            cmbBranch.AutoCompleteCustomSource = auto;
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
            dtWarehouse = await Task.Run(() => warehousec.returnWarehouse(branchCode,""));
            cmbWhse.Items.Clear();
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
                            else if (y.Key.Equals("isAdmin") || y.Key.Equals("isManager") || y.Key.Equals("isAccounting"))
                            {
                                if (y.Value.ToString().ToLower() == "true")
                                {
                                    cmbWhse.Items.Add("All");
                                    foreach (DataRow row in dtWarehouse.Rows)
                                    {
                                        auto.Add(row["whsename"].ToString());
                                        cmbWhse.Items.Add(row["whsename"].ToString());
                                        cmbWhse.SelectedIndex = 0;
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
                        cmbWhse.Items.Add(whseName);
                    }
                }
                cmbWhse.SelectedIndex = cmbWhse.Items.IndexOf(whseName);
                cmbWhse.AutoCompleteCustomSource = auto;
            }
        }

        public string findWarehouseCode()
        {
            string result = "";
            foreach(DataRow row in dtWarehouse.Rows)
            {
                if(row["whsename"].ToString() == cmbWhse.Text)
                {
                    result = row["whsecode"].ToString();
                    break;
                }
            }
            return result;
        }

        public string findBranchCode()
        {
            string result = "";
            foreach (DataRow row in dtBranch.Rows)
            {
                if (row["name"].ToString() == cmbBranch.Text)
                {
                    result = row["code"].ToString();
                    break;
                }
            }
            return result;
        }

        public void loadUsers(ComboBox cmb, bool isCashier)
        {
            DataTable adtUsers = new DataTable();
            string sBranch = "?branch=" + findBranchCode();
            string sWhse = "&whse=" +findWarehouseCode();
            string sCashier = "&isCashier=" + (isCashier ? "1" : "");
            adtUsers = userc.returnUsers(sBranch + sWhse + sCashier);
            if (isCashier)
            {
                dtUsers = userc.returnUsers(sBranch + sWhse + sCashier);
            }
            else if (isCashier)
            {
                dtCashier = userc.returnUsers(sBranch + sWhse + sCashier);
            }
    
            cmb.Items.Clear();
            cmb.Items.Add("All");
            foreach(DataRow r0w in adtUsers.Rows)
            {
                cmb.Items.Add(r0w["username"].ToString());
            }
            if(cmb.Items.Count > 0)
            {
                cmb.SelectedIndex = 0;
            }
        }

        private async void SalesReport_Load(object sender, EventArgs e)
        {
            dgv.Columns["amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            await loadBranch();
            loadWarehouse();
            loadUsers(cmbCashier, true);
            loadPaymentType("sales", cmbSalesType);
            loadPaymentType("payment", cmbPaymentType);
            bg();
            cBranch = 0;
            cWarehouse = 0;
            cUser = 0;
            cPaymentType = 0;
            cSalesType = 0;
        }

        public void bg()
        {
            if (!backgroundWorker1.IsBusy)
            {
                closeForm();
                Loading frm = new Loading();
                frm.BringToFront();
                frm.Show();
                Application.OpenForms[frm.Name].Activate();
                backgroundWorker1.RunWorkerAsync();
            }
        }

        public void loadPaymentType(string urlType, ComboBox cmb)
        {
            cmb.Items.Clear();
            cmb.Items.Add("All");
            DataTable dtPaymentTypes = new DataTable();
            dtPaymentTypes = paymenttypec.loadPaymentType(urlType);       
            if (dtPaymentTypes.Rows.Count > 0)
            {
                foreach (DataRow row in dtPaymentTypes.Rows)
                {
                    cmb.Items.Add(row["code"].ToString());
                }
            }
            cmb.SelectedIndex = 0;
        }

        public void loadData()
        {
            try
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
                        dgv.Invoke(new Action(delegate ()
                        {
                            dgv.Rows.Clear();
                        }));
                        var client = new RestClient(utilityc.URL);
                        client.Timeout = -1;

                        int cashierID = 0;
                        foreach (DataRow r0wSales in dtUsers.Rows)
                        {
                            cmbCashier.Invoke(new Action(delegate ()
                            {
                                if (r0wSales["username"].ToString() == cmbCashier.Text)
                                {
                                    cashierID = Convert.ToInt32(r0wSales["userid"].ToString());
                                }
                            }));

                        }

                        string sCashier = (cashierID <= 0 ? "&cashier_id=" : "&cashier_id=" + cashierID);

                        string sSalesType = "";
                        cmbSalesType.Invoke(new Action(delegate ()
                        {
                            sSalesType = (cmbSalesType.SelectedIndex <= 0 ? "&sales_type=" : "&sales_type=" + cmbSalesType.Text);
                        }));

                        string sPaymentType = "";
                        cmbPaymentType.Invoke(new Action(delegate ()
                        {
                            sPaymentType = (cmbPaymentType.SelectedIndex <= 0 ? "&payment_type=" : "&payment_type=" + cmbPaymentType.Text);
                        }));


                        string sBranch = "";
                        cmbBranch.Invoke(new Action(delegate ()
                        {
                            sBranch = "&branch=" + findBranchCode();
                        }));

                        string sWarehouse = "";
                        cmbWhse.Invoke(new Action(delegate ()
                        {
                            sWarehouse = "&whse=" + findWarehouseCode();
                        }));
                        string sFromDate = "";
                        dtFrom.Invoke(new Action(delegate ()
                        {
                            sFromDate = "?from_date=" + dtFrom.Value.ToString("yyyy-MM-dd");
                        }));
                        string sToDate = "";
                        dtTo.Invoke(new Action(delegate ()
                        {
                            sToDate = "&to_date=" + dtTo.Value.ToString("yyyy-MM-dd");
                        }));


                        var request = new RestRequest("/api/report/cs" + sFromDate + sToDate + sCashier + sSalesType + sPaymentType + sBranch + sWarehouse);
                        Console.WriteLine("/api/report/cs" + sFromDate + sToDate + sCashier + sSalesType + sPaymentType + sBranch + sWarehouse);
                        request.AddHeader("Authorization", "Bearer " + token);
                        var response = client.Execute(request);
                        //Console.WriteLine(response.Content);
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
                                            if (y.Key.Equals("cash_trans"))
                                            {
                                                JArray jArrayCashTans = JArray.Parse(y.Value.ToString());
                                                for (int aa = 0; aa < jArrayCashTans.Count(); aa++)
                                                {
                                                    JObject jObjectCashTans = JObject.Parse(jArrayCashTans[aa].ToString());
                                                    foreach (var z in jObjectCashTans)
                                                    {
                                                        if (z.Key.Equals("TotalCashOnHand"))
                                                        {
                                                            lblCashOnHand.Invoke(new Action(delegate ()
                                                            {
                                                                lblCashOnHand.Text = (z.Value.ToString() != "" ? Convert.ToDouble(z.Value.ToString()).ToString("n2") : "0.00");
                                                            }));
                                                        }
                                                        else if (z.Key.Equals("TotalCashPayment"))
                                                        {
                                                            lblCashSales.Invoke(new Action(delegate ()
                                                            {
                                                                lblCashSales.Text = (z.Value.ToString() != "" ? Convert.ToDouble(z.Value.ToString()).ToString("n2") : "0.00");
                                                            }));
                                                        }
                                                        else if (z.Key.Equals("DepositCash"))
                                                        {
                                                            lblADVCash.Invoke(new Action(delegate ()
                                                            {
                                                                lblADVCash.Text = (z.Value.ToString() != "" ? Convert.ToDouble(z.Value.ToString()).ToString("n2") : "0.00");
                                                            }));
                                                        }
                                                        else if (z.Key.Equals("FromDep"))
                                                        {
                                                            lblUsedADV.Invoke(new Action(delegate ()
                                                            {
                                                                lblUsedADV.Text = (z.Value.ToString() != "" ? Convert.ToDouble(z.Value.ToString()).ToString("n2") : "0.00");
                                                            }));
                                                        }
                                                        else if (z.Key.Equals("BankDep"))
                                                        {
                                                            lblBankDeposit.Invoke(new Action(delegate ()
                                                            {
                                                                lblBankDeposit.Text = (z.Value.ToString() != "" ? Convert.ToDouble(z.Value.ToString()).ToString("n2") : "0.00");
                                                            }));
                                                        }
                                                        else if (z.Key.Equals("EPAY"))
                                                        {
                                                            lblEpay.Invoke(new Action(delegate ()
                                                            {
                                                                lblEpay.Text = (z.Value.ToString() != "" ? Convert.ToDouble(z.Value.ToString()).ToString("n2") : "0.00");
                                                            }));
                                                        }
                                                        else if (z.Key.Equals("GCert"))
                                                        {
                                                            lblGCert.Invoke(new Action(delegate ()
                                                            {
                                                                lblGCert.Text = (z.Value.ToString() != "" ? Convert.ToDouble(z.Value.ToString()).ToString("n2") : "0.00");
                                                            }));
                                                        }
                                                        else if (z.Key.Equals("Commission"))
                                                        {
                                                            lblComission.Invoke(new Action(delegate ()
                                                            {
                                                                lblComission.Text = (z.Value.ToString() != "" ? Convert.ToDouble(z.Value.ToString()).ToString("n2") : "0.00");
                                                            }));
                                                        }
                                                        else if (z.Key.Equals("Cashout"))
                                                        {
                                                            lblCashOut.Invoke(new Action(delegate ()
                                                            {
                                                                lblCashOut.Text = (z.Value.ToString() != "" ? Convert.ToDouble(z.Value.ToString()).ToString("n2") : "0.00");
                                                            }));
                                                        }
                                                    }
                                                }
                                            }
                                            else if (y.Key.Equals("sales_rows"))
                                            {
                                                dgv.Rows.Clear();
                                                JArray jArraySalesRows = JArray.Parse(y.Value.ToString());
                                                for (int aa = 0; aa < jArraySalesRows.Count(); aa++)
                                                {

                                                    JObject jObjectSalesRows = JObject.Parse(jArraySalesRows[aa].ToString());

                                                    string referenceNumber = "", url = "", salesType = "", paymentType = "", custCode = "", username = "";
                                                    double amount = 0.00;
                                                    DateTime dtTransdate = new DateTime();
                                                    foreach (var z in jObjectSalesRows)
                                                    {
                                                        if (z.Key.Equals("reference"))
                                                        {
                                                            referenceNumber = z.Value.ToString();
                                                        }
                                                        else if (z.Key.Equals("url"))
                                                        {
                                                            url = z.Value.ToString();
                                                        }
                                                        else if (z.Key.Equals("amount"))
                                                        {
                                                            amount = Convert.ToDouble(z.Value.ToString());
                                                        }
                                                        else if (z.Key.Equals("cust_code"))
                                                        {
                                                            custCode = z.Value.ToString();
                                                        }
                                                        else if (z.Key.Equals("SalesType"))
                                                        {
                                                            salesType = z.Value.ToString();
                                                        }
                                                        else if (z.Key.Equals("username"))
                                                        {
                                                            username = z.Value.ToString();
                                                        }
                                                        else if (z.Key.Equals("PaymentType"))
                                                        {
                                                            paymentType = z.Value.ToString();
                                                        }
                                                        else if (z.Key.Equals("transdate"))
                                                        {
                                                            string replaceT = z.Value.ToString().Replace("T", "");
                                                            dtTransdate = Convert.ToDateTime(replaceT);
                                                        }
                                                    }
                                                    dgv.Invoke(new Action(delegate ()
                                                    {
                                                        dgv.Rows.Add(dtTransdate.ToString("yyyy-MM-dd HH:mm"),referenceNumber, Convert.ToDecimal(string.Format("{0:0.00}", amount)), custCode, salesType, paymentType, username, url);
                                                    }));
                                                }
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
                }
                lblNoDataFound.Invoke(new Action(delegate ()
                {
                    lblNoDataFound.Visible = (dgv.Rows.Count > 0 ? false : true);
                }));
                dgv.Invoke(new Action(delegate ()
                {
                    foreach (DataGridViewColumn col in dgv.Columns)
                    {
                        col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        int colw = col.Width;
                        col.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                        col.Width = colw;
                    }
                }));

            }
            catch
            {

            }
        }

        public void closeForm()
        {
            foreach (Form frm in Application.OpenForms)
            {
                if (frm.Name == "Loading")
                {
                    frm.Hide();
                }
            }
        }



        private void dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv.Rows.Count > 0)
            {
                CashTransactionReportItems cashTransactionReportItems = new CashTransactionReportItems();
                cashTransactionReportItems.URLDetails = dgv.CurrentRow.Cells["url"].Value.ToString();
                cashTransactionReportItems.ShowDialog();
                if (CashTransactionReportItems.isSubmit)
                {
                    loadData();
                }
            }
        }

        private void btnrefresh_Click(object sender, EventArgs e)
        {
            bg();
        }
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            loadData();
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            closeForm();
        }

        private void cmbWhse_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadUsers(cmbCashier, true);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bg();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bg();
        }

        private void cmbBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadWarehouse();
            loadUsers(cmbCashier, true);
        }

        private void cmbBranch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                if (cBranch <= 0)
                {
                    loadWarehouse();
                    loadUsers(cmbCashier, true);
                    bg();
                }
            }
        }
    }
}
