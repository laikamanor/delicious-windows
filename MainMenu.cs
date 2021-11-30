using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DeliciousPartnerApp.UI_Class;
using Newtonsoft.Json.Linq;
using Tulpep.NotificationWindow;
using System.Data.SqlClient;
using DeliciousPartnerApp.API_Class.Notification;
using System.Threading.Tasks;
using RestSharp;
using System.Threading;

namespace DeliciousPartnerApp
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }
        utility_class utilityc = new utility_class();
        bool isProductionAddress = false;
        private async void MainMenu_Load(object sender, EventArgs e)
        {
            this.Text = utilityc.appName + " - " + Login.fullName + " - v" + utilityc.versionName + " - " + utilityc.URL.Replace("http://", "");
            isProductionAddress = utilityc.URL.Contains(utilityc.getTextfromGithub(utilityc.abWindowsProdURLFile));
            await NotifcationAsync();
        }

        public bool isAdmin()
        {
            bool result = false;
            if (Login.jsonResult != null)
            {
                foreach (var x in Login.jsonResult)
                {
                    if (x.Key.Equals("data"))
                    {
                        JObject jObjectData = JObject.Parse(x.Value.ToString());
                        foreach (var y in jObjectData)
                        {
                            if (y.Key.Equals("isAdmin"))
                            {
                                if (y.Value.ToString().ToLower() == "true")
                                {
                                    result = true;
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            return result;
        }

        public void showForm(Form form)
        {
            form.TopLevel = false;
            panelchildform.Controls.Add(form);
            form.BringToFront();
            form.Show();
        }

        private void pendingOrdersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SalesTab frm = new SalesTab();
            showForm(frm);
            //PendingOrder pendingOrder = new PendingOrder();
            //showForm(pendingOrder);
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to logout?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                Login.jsonResult = null;
                this.Dispose();
                Login login = new Login();
                login.ShowDialog();
            }
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (isAdmin())
            {
                Users_DX users = new Users_DX();
                showForm(users);
            }
            else
            {
                MessageBox.Show("Access Denied", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void MainMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to logout?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.No)
            {
                e.Cancel = true;
            }
            else
            {
                Login.jsonResult = null;
                this.Dispose();
                Login login = new Login();
                login.ShowDialog();
            }
        }

        private void advancePaymentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AdvancePayment advancePayment = new AdvancePayment();
            showForm(advancePayment);
        }

        private void inventoryToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Inventory inventory = new Inventory();
            showForm(inventory);
        }

        private void itemRequestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ItemRequest itemRequest = new ItemRequest();
            showForm(itemRequest);
        }

        private void transferTransactionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Transfer transfer = new Transfer();
            transfer.Text = "Transfer Transactions";
            showForm(transfer);
        }

        private void cashTransactionReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CashTransactionReport cashTransactionReport = new CashTransactionReport();
            showForm(cashTransactionReport);
        }

        private void salesReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SalesReport salesReport = new SalesReport();
            showForm(salesReport);
        }

        private void receivedTransactionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Transfer transfer = new Transfer();
            transfer.Text = "Received Transactions";
            showForm(transfer);
        }

        private void branchesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (isAdmin())
            {
                Branches2 branch = new Branches2();
                showForm(branch);
            }
            else
            {
                MessageBox.Show("Access Denied", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void customersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (isAdmin())
            {
                Customers customers = new Customers();
                showForm(customers);
            }
            else
            {
                MessageBox.Show("Access Denied", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void inventoryCountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            printableReports("Final Count Report");
        }

        public void printableReports(string reportType)
        {
            EnterDate enterDate = new EnterDate(reportType);
            enterDate.ShowDialog();
        }

        private void inventorySummaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            printableReports("Final Report");
        }

        private void salesTransactionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SalesTransactions salesTransactions = new SalesTransactions();
            showForm(salesTransactions);
        }

        private void pulloutTransactionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Transfer transfer = new Transfer();
            transfer.Text = "Pullout Transactions";
            showForm(transfer);
        }

        private void adjustmentInToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AdjustmentIn adjustmentIn = new AdjustmentIn("in");
            showForm(adjustmentIn);
        }

        private void adjustmentOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AdjustmentIn adjustmentIn = new AdjustmentIn("out");
            showForm(adjustmentIn);
        }

        private void objectTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (isAdmin())
            {
                ObjectType adjustmentIn = new ObjectType();
                showForm(adjustmentIn);
            }
            else
            {
                MessageBox.Show("Access Denied", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void warehouseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (isAdmin())
            {
                Warehouse warehouse = new Warehouse();
                showForm(warehouse);
            }
            else
            {
                MessageBox.Show("Access Denied", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void itemsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (isAdmin())
            {
                Items_DX items = new Items_DX();
                showForm(items);
            }
            else
            {
                MessageBox.Show("Access Denied", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void cashVarianceTransactionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CashVariance items = new CashVariance();
            showForm(items);
        }

        private void itemSalesReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ItemSalesReport items = new ItemSalesReport();
            showForm(items);
        }

        private void seriesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (isAdmin())
            {
                Series items = new Series();
                showForm(items);
            }
            else
            {
                MessageBox.Show("Access Denied", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void priceListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (isAdmin())
            {
                PriceList items = new PriceList();
                showForm(items);
            }
            else
            {
                MessageBox.Show("Access Denied", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void salesReportsWoInventoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            printableReports("Final Sales Report");
        }

        private void notifications0ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //NotificationBar items = new NotificationBar();
            //items.Location = new Point(Cursor.Position.X - 50, Cursor.Position.Y + 20);
            //items.ShowDialog();
            //int notifBarSelectedID = NotificationBar.selectedID;
            //if (notifBarSelectedID > 0)
            //{
            //    Notification nf = new Notification();
            //    nf.selectedID = notifBarSelectedID;
            //    showForm(nf);
            //}
            NotificationTab nf = new NotificationTab();
            showForm(nf);
        }

        private void addActualCashToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddActualCash add = new AddActualCash();
            add.ShowDialog();
        }

        private void pOSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (isProductionAddress)
            {
                POS items = new POS();
                showForm(items);
            }
            else
            {
                MessageBox.Show("Under Development", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void uomGroupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (isAdmin())
            {
                UOMGroup items = new UOMGroup();
                showForm(items);
            }
            else
            {
                MessageBox.Show("Access Denied", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void uomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (isAdmin())
            {
                UOM items = new UOM();
                showForm(items);
            }
            else
            {
                MessageBox.Show("Access Denied", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void productionOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (isProductionAddress)
            {
                Production_ProductionOrder items = new Production_ProductionOrder();
                showForm(items);
            }
            else
            {
                MessageBox.Show("Under Development", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void issueForProductionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (isProductionAddress)
            {
                IssueForProduction items = new IssueForProduction();
                showForm(items);
            }
            else
            {
                MessageBox.Show("Under Development", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void receiptFromProductionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (isProductionAddress)
            {
                ReceiptFromProduction items = new ReceiptFromProduction();
                showForm(items);
            }
            else
            {
                MessageBox.Show("Under Development", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void gLAccountsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (isAdmin())
            {
                GLAccounts items = new GLAccounts();
                showForm(items);
            }
            else
            {
                MessageBox.Show("Accedd Denied", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private async void timer1_Tick(object sender, EventArgs e)
        {
            await NotifcationAsync();
        }

        public async Task NotifcationAsync()
        {
            //JObject joLogin = Login.jsonResult;
            //string selectedBranch = "", selectedWarehouse = "";
            //if (joLogin != null)
            //{
            //    foreach (var q in joLogin)
            //    {
            //        if (q.Key.Equals("data"))
            //        {
            //            JObject joData = JObject.Parse(q.Value.ToString());
            //            foreach (var x in joData)
            //            {
            //                if (x.Key.Equals("branch"))
            //                {
            //                    selectedBranch = x.Value.ToString();
            //                }
            //                else if (x.Key.Equals("whse"))
            //                {
            //                    selectedWarehouse = x.Value.ToString();
            //                }
            //            }
            //        }
            //    }
            //}
            notification_class notifc = new notification_class();
            //string sFromDate = "&from_date=",
            //    sToDate = "&to_date=" + DateTime.Now.ToString("yyyy-MM-dd"),
            //    sWarehouse = "&whsecode=" + selectedWarehouse;
            //Console.WriteLine(sFromDate + Environment.NewLine + sToDate + Environment.NewLine + sWarehouse + selectedBranch);
            DataTable dt = await Task.Run(() => notifc.getUnreadNotif("", "", "", "", 0));
            loadNotification(dt);
        }

        public async void loadNotification(DataTable dtUnread)
        {
            notification_class notifc = new notification_class();
            //dtUnread = await notifc.getUnreadNotif();
            int count = 0;
            if (dtUnread.Rows.Count > 0)
            {
                DataRow row = dtUnread.Rows[0];
                count = string.IsNullOrEmpty(row["count"].ToString()) ? 0 : Convert.ToInt32(row["count"].ToString());
            }
            notifications0ToolStripMenuItem.Text = "Notification (" + count.ToString("N0") + ")";

        }

        private void productionToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private async void timer2_Tick(object sender, EventArgs e)
        {
            notification_class notifc = new notification_class();
            await Task.Run(() => notifc.getAndPost());
        }

        private void salesAmountSummaryReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SASR0 frm = new SASR0();
            showForm(frm);
        }

        private void customerSalesReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CustomerSalesReport frm = new CustomerSalesReport();
            showForm(frm);
        }

        private void salesReturnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SalesReturn frm = new SalesReturn();
            showForm(frm);
        }

        private void customerLedgerToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SalesPerCustomer salesCustomer = new SalesPerCustomer();
            showForm( salesCustomer);
        }

        private void sOAToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SOATab frm = new SOATab();
            showForm(frm);
        }
    }
    public static class DataTableExtensions
    {
        public static void SetColumnsOrder(this DataTable table, params String[] columnNames)
        {
            int columnIndex = 0;
            foreach (var columnName in columnNames)
            {
                if (table.Columns.Contains(columnName))
                {
                    table.Columns[columnName].SetOrdinal(columnIndex);
                    columnIndex++;
                }
            }
        }
    }

    public static class JsonExtensions
    {
        public static bool IsNullOrEmpty(this JToken token)
        {
            return (token == null) ||
                   (token.Type == JTokenType.Array && !token.HasValues) ||
                   (token.Type == JTokenType.Object && !token.HasValues) ||
                   (token.Type == JTokenType.String && token.ToString() == String.Empty) ||
                   (token.Type == JTokenType.Null);
        }
    }
}

