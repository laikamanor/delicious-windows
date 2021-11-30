using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DeliciousPartnerApp.API_Class.Branch;
using DeliciousPartnerApp.API_Class.Warehouse;
using Newtonsoft.Json.Linq;
using RestSharp;
using DeliciousPartnerApp.UI_Class;
using DevExpress.XtraGrid.Columns;
using System.Globalization;
using DevExpress.XtraGrid.Views.Grid;

namespace DeliciousPartnerApp
{
    public partial class ItemSalesReport : Form
    {
        public ItemSalesReport()
        {
            InitializeComponent();
        }
        int cBranch = 1, cWhse = 1, cFromDate = 1, cTodate = 1, cFromTime = 1, cToTime = 1, cTransType = 1;
        warehouse_class warehousec = new warehouse_class();
        branch_class branchc = new branch_class();
        utility_class utilityc = new utility_class();
        DataTable dtBranch = new DataTable(), dtWhse = new DataTable();
        private void cmbFromTime_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cFromTime <= 0)
            {
                if (!backgroundWorker1.IsBusy)
                {
                    closeForm();
                    Loading frm = new Loading();
                    frm.Show();
                    backgroundWorker1.RunWorkerAsync();
                }
            }
        }

        private void cmbToTime_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cToTime <= 0)
            {
                if (!backgroundWorker1.IsBusy)
                {
                    closeForm();
                    Loading frm = new Loading();
                    frm.Show();
                    backgroundWorker1.RunWorkerAsync();
                }
            }
        }

        private void dtFromDate_ValueChanged(object sender, EventArgs e)
        {
        
        }

        private void dtToDate_ValueChanged(object sender, EventArgs e)
        {
            if(cTodate <= 0)
            {
                if (!backgroundWorker1.IsBusy)
                {
                    closeForm();
                    Loading frm = new Loading();
                    frm.Show();
                    backgroundWorker1.RunWorkerAsync();
                }
            }
        }

        private void cmbTransType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cTransType <= 0)
            {
                if (!backgroundWorker1.IsBusy)
                {
                    closeForm();
                    Loading frm = new Loading();
                    frm.Show();
                    backgroundWorker1.RunWorkerAsync();
                }
            }
        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
          
        }

        private void gridView1_RowStyle(object sender, RowStyleEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                double doubleTemp = 0.00;
                double discAmt = double.TryParse(gridView1.GetRowCellValue(e.RowHandle, "discount_amount").ToString(), out doubleTemp) ? Convert.ToDouble(gridView1.GetRowCellValue(e.RowHandle, "discount_amount").ToString()) : doubleTemp;
                if (discAmt > 0)
                {
                    e.Appearance.BackColor = Color.Yellow;
                }
            }
        }

        private async void cmbBranch_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cBranch <= 0)
            {
                await loadWarehouse();
                if (!backgroundWorker1.IsBusy)
                {
                    closeForm();
                    Loading frm = new Loading();
                    frm.Show();
                    backgroundWorker1.RunWorkerAsync();
                }
            }
        }

        private async void cmbBranch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                await loadWarehouse();
                if (!backgroundWorker1.IsBusy)
                {
                    closeForm();
                    Loading frm = new Loading();
                    frm.Show();
                    backgroundWorker1.RunWorkerAsync();
                }
            }
        }

        private void cmbWhse_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cWhse <= 0)
            {
                if (!backgroundWorker1.IsBusy)
                {
                    closeForm();
                    Loading frm = new Loading();
                    frm.Show();
                    backgroundWorker1.RunWorkerAsync();
                }
            }
        }

        private void cmbWhse_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                if (cWhse <= 0)
                {
                    if (!backgroundWorker1.IsBusy)
                    {
                        closeForm();
                        Loading frm = new Loading();
                        frm.Show();
                        backgroundWorker1.RunWorkerAsync();
                    }
                }
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            loadData();
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            closeForm();
        }


        private void repositoryItemTextEdit1_Click(object sender, EventArgs e)
        {
            string selectedItemCode = "", selectedDiscountAmount = "";
            int[] ids = gridView1.GetSelectedRows();
            foreach(int i in ids)
            {
                selectedDiscountAmount = gridView1.GetRowCellValue(i, "discount_percent").ToString();
                selectedItemCode = gridView1.GetRowCellValue(i, "item_code").ToString();
            }
            if (gridView1.RowCount > 0)
            {
                string sBranch = "?branch=" + findCode(cmbBranch.Text, "Branch");
                string sWhse = "&whsecode=" + findCode(cmbWhse.Text, "Warehouse");
                string sTransType = "&transtype=" + (cmbTransType.SelectedIndex == 0 || cmbTransType.Text == "All" ? "" : cmbTransType.Text);
                string sFromTime = "&from_time=" + cmbFromTime.Text;
                string sToTime = "&to_time=" + cmbToTime.Text;
                string sFromDate = "&from_date=" + dtFromDate.Value.ToString("yyyy-MM-dd");
                string sToDate = "&to_date=" + dtToDate.Value.ToString("yyyy-MM-dd");
                string sItemCode = "&item_code=" + selectedItemCode;
                string sDiscount = "&discount=" + selectedDiscountAmount;
                string URL = "/api/report/item/summary/details" + sBranch + sWhse + sTransType + sFromTime + sToTime + sFromDate + sToDate + sItemCode + sDiscount;
                ItemSalesReport_Details details = new ItemSalesReport_Details();
                details.URL = URL;
                details.ShowDialog();
            }
        }

        private void pictureBoxLoading_Click(object sender, EventArgs e)
        {

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

        private void dtFromDate_CloseUp(object sender, EventArgs e)
        {
            if (cFromDate <= 0)
            {
                if (!backgroundWorker1.IsBusy)
                {
                    closeForm();
                    Loading frm = new Loading();
                    frm.Show();
                    backgroundWorker1.RunWorkerAsync();
                }
            }
        }

        private void dtToDate_CloseUp(object sender, EventArgs e)
        {
            if (cTodate <= 0)
            {
                if (!backgroundWorker1.IsBusy)
                {
                    closeForm();
                    Loading frm = new Loading();
                    frm.Show();
                    backgroundWorker1.RunWorkerAsync();
                }
            }
        }

        private async void ItemSalesReport_Load(object sender, EventArgs e)
        {
            await loadBranch();
            await loadWarehouse();
            loadTenderType();
            cmbFromTime.SelectedIndex = 0;
            cmbToTime.SelectedIndex = cmbToTime.Items.Count - 1;
            if (!backgroundWorker1.IsBusy)
            {
                closeForm();
                Loading frm = new Loading();
                frm.Show();
                backgroundWorker1.RunWorkerAsync();
            }
            cBranch = 0;
            cWhse = 0;
            cFromDate = 0;
            cTodate = 0;
            cFromDate = 0;
            cToTime = 0;
            cFromTime = 0;
            cTransType = 0;
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
                    cmbBranch.Items.Add(row["name"].ToString());
                }
            }
            else
            {
                foreach (DataRow row in dtBranch.Rows)
                {
                    if (row["code"].ToString() == currentBranch)
                    {
                        auto.Add(row["name"].ToString());
                        cmbBranch.Items.Add(row["name"].ToString());
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

        public string findCode(string value, string typee)
        {
            string result = "";
            if (typee.Equals("Warehouse"))
            {
                foreach (DataRow row in dtWhse.Rows)
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

        public async Task loadWarehouse()
        {
            string branchCode = "";
            string warehouse = "";
            cmbWhse.Items.Clear();
            AutoCompleteStringCollection auto = new AutoCompleteStringCollection();
            cmbWhse.Items.Add("All-Good");
            foreach (DataRow row in dtBranch.Rows)
            {
                if (cmbBranch.Text.Equals(row["name"].ToString()))
                {
                    branchCode = row["code"].ToString();
                    break;
                }
            }
            dtWhse = await Task.Run(() => warehousec.returnWarehouse(branchCode, ""));
            foreach (DataRow row in dtWhse.Rows)
            {
                auto.Add(row["whsename"].ToString());
                cmbWhse.Items.Add(row["whsename"]);
            }
            if (cmbWhse.Items.Count > 0)
            {
                string whseName = "";
                foreach (DataRow row in dtWhse.Rows)
                {
                    if (row["whsecode"].ToString() == warehouse)
                    {
                        whseName = row["whsename"].ToString();
                        break;
                    }
                }
                cmbWhse.SelectedIndex = cmbWhse.Items.IndexOf(whseName);
                if (cmbWhse.Text == "")
                {
                    cmbWhse.SelectedIndex = 0;
                }
            }
            cmbWhse.AutoCompleteCustomSource = auto;
        }

        public void loadTenderType()
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
                    var request = new RestRequest("/api/sales/type/get_all");
                    request.AddHeader("Authorization", "Bearer " + token);
                    var response = client.Execute(request);
                    JObject jObject = new JObject();
                    cmbTransType.Items.Clear();
                    cmbTransType.Items.Add("All");
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
                                    JArray jsonArray = JArray.Parse(x.Value.ToString());
                                    for (int i = 0; i < jsonArray.Count(); i++)
                                    {
                                        JObject data = JObject.Parse(jsonArray[i].ToString());
                                        string code = "";
                                        foreach (var q in data)
                                        {
                                            if (q.Key.Equals("code"))
                                            {
                                                code = q.Value.ToString();
                                            }
                                        }
                                        cmbTransType.Items.Add(code);
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
                cmbTransType.SelectedIndex = 0;
                Cursor.Current = Cursors.Default;
            }
        }

        public void loadData()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("item_code", typeof(string));
            dt.Columns.Add("quantity", typeof(double));
            dt.Columns.Add("unit_price", typeof(double));
            dt.Columns.Add("discount_percent", typeof(double));
            dt.Columns.Add("discount_amount", typeof(double));
            dt.Columns.Add("gross_amount", typeof(double));
            dt.Columns.Add("net_amount", typeof(double));
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
                    string sBranch = "";
                    cmbBranch.Invoke(new Action(delegate ()
                    {
                        sBranch = "?branch=" + findCode(cmbBranch.Text, "Branch");
                    }));

                    string sWhse = "";
                    cmbWhse.Invoke(new Action(delegate ()
                    {
                        sWhse = "&whsecode=" + findCode(cmbWhse.Text, "Warehouse");
                    }));

                    string sTransType = "";
                    cmbTransType.Invoke(new Action(delegate ()
                    {
                        sTransType = "&transtype=" + (cmbTransType.SelectedIndex == 0 || cmbTransType.Text == "All" ? "" : cmbTransType.Text);
                    }));

                    string sFromTime = "";
                    cmbFromTime.Invoke(new Action(delegate ()
                    {
                        sFromTime = "&from_time=" + cmbFromTime.Text;
                    }));

                    string sToTime = "";
                    cmbToTime.Invoke(new Action(delegate ()
                    {
                        sToTime = "&to_time=" + cmbToTime.Text;
                    }));

                    string sFromDate = "";
                    dtFromDate.Invoke(new Action(delegate ()
                    {
                        sFromDate = "&from_date=" + dtFromDate.Value.ToString("yyyy-MM-dd");
                    }));
                    string sToDate = "";
                    dtFromDate.Invoke(new Action(delegate ()
                    {
                        sToDate = "&to_date=" + dtToDate.Value.ToString("yyyy-MM-dd");
                    }));
                    var request = new RestRequest("/api/report/item/sales/detailed" + sBranch + sWhse + sTransType + sFromTime + sToTime + sFromDate + sToDate);
                    Console.WriteLine("/api/report/item/sales/detailed" + sBranch + sWhse + sTransType + sFromTime + sToTime + sFromDate + sToDate);

                    //var request = new RestRequest("/api/report/item/summary" + sBranch + sWhse + sTransType + sFromTime + sToTime + sFromDate + sToDate);
                    //Console.WriteLine("/api/report/item/summary" + sBranch + sWhse + sTransType + sFromTime + sToTime + sFromDate + sToDate);

                    request.AddHeader("Authorization", "Bearer " + token);
                    var response = client.Execute(request);
                    Console.WriteLine(response.Content);
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
                                    JArray jsonArray = JArray.Parse(x.Value.ToString());
                                    for (int i = 0; i < jsonArray.Count(); i++)
                                    {
                                        JObject data = JObject.Parse(jsonArray[i].ToString());
                                        string itemCode = "";
                                        double qty = 0.00, unitPrice = 0.00, discPrcnt = 0.00, discAmt = 0.00, grossAmt = 0.00, netAmt = 0.00;
                                        foreach (var q in data)
                                        {

                                            if (q.Key.Equals("item_code"))
                                            {
                                                itemCode = q.Value.ToString();
                                            }
                                            else if (q.Key.Equals("unit_price"))
                                            {
                                                unitPrice = string.IsNullOrEmpty(q.Value.ToString()) ? 0.00 : Convert.ToDouble(q.Value.ToString());
                                            }
                                            else if (q.Key.Equals("quantity"))
                                            {
                                                qty = string.IsNullOrEmpty(q.Value.ToString()) ? 0.00 : Convert.ToDouble(q.Value.ToString());
                                            }
                                            else if (q.Key.Equals("discprcnt"))
                                            {
                                                discPrcnt = string.IsNullOrEmpty(q.Value.ToString()) ? 0.00 : Convert.ToDouble(q.Value.ToString());
                                            }
                                            else if (q.Key.Equals("disc_amount"))
                                            {
                                                discAmt = string.IsNullOrEmpty(q.Value.ToString()) ? 0.00 : Convert.ToDouble(q.Value.ToString());
                                            }
                                            else if (q.Key.Equals("gross_amount"))
                                            {
                                                grossAmt = string.IsNullOrEmpty(q.Value.ToString()) ? 0.00 : Convert.ToDouble(q.Value.ToString());
                                            }
                                            else if (q.Key.Equals("net_amount"))
                                            {
                                                netAmt = string.IsNullOrEmpty(q.Value.ToString()) ? 0.00 : Convert.ToDouble(q.Value.ToString());

                                            }
                                        }

                                        dt.Rows.Add(itemCode, Convert.ToDecimal(string.Format("{0:0.00}", qty)), Convert.ToDecimal(string.Format("{0:0.00}", unitPrice)), Convert.ToDecimal(string.Format("{0:0.00}", discPrcnt)), Convert.ToDecimal(string.Format("{0:0.00}", discAmt)), Convert.ToDecimal(string.Format("{0:0.00}", grossAmt)), Convert.ToDecimal(string.Format("{0:0.00}", netAmt)));
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
                gridControl1.Invoke(new Action(delegate ()
                {
                    gridControl1.DataSource = dt;

                    foreach (GridColumn col in gridView1.Columns)
                    {
                        if (col.Caption != "item_code")
                        {
                            col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                            col.DisplayFormat.FormatString = "n2";
                        }
                        string s = col.GetCaption().Replace("_", " ");
                        col.Caption = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(s.ToLower());
                        (gridControl1.MainView as GridView).Columns[col.AbsoluteIndex].ColumnEdit = repositoryItemTextEdit1;
                    }
                    gridView1.Columns["item_code"].GroupIndex = 1;
                    gridView1.Columns["quantity"].SortOrder = DevExpress.Data.ColumnSortOrder.Ascending;
                }));

                total();

                Cursor.Current = Cursors.Default;
            }
        }
        
        public void total()
        {
            double totalDiscAmount = 0.00, totalGrossAmount = 0.00, totalNetAmount = 0.00;

            for (int i = 0; i < gridView1.DataRowCount; i++)
            {
                totalDiscAmount += string.IsNullOrEmpty(gridView1.GetRowCellValue(i, "discount_amount").ToString()) ? 0.00 : Convert.ToDouble(gridView1.GetRowCellValue(i, "discount_amount").ToString());
                totalGrossAmount += string.IsNullOrEmpty(gridView1.GetRowCellValue(i, "gross_amount").ToString()) ? 0.00 : Convert.ToDouble(gridView1.GetRowCellValue(i, "gross_amount").ToString());
                totalNetAmount += string.IsNullOrEmpty(gridView1.GetRowCellValue(i, "net_amount").ToString()) ? 0.00 : Convert.ToDouble(gridView1.GetRowCellValue(i, "net_amount").ToString());

            }

            lblDiscAmount.Invoke(new Action(delegate ()
            {
                lblDiscAmount.Text = totalDiscAmount.ToString("n2");
            }));
            lblGrossAmount.Invoke(new Action(delegate ()
            {
                lblGrossAmount.Text = totalGrossAmount.ToString("n2");
            }));
            lblTotalNetAmount.Invoke(new Action(delegate ()
            {
                lblTotalNetAmount.Text = totalNetAmount.ToString("n2");
            }));

        }

    }
}
