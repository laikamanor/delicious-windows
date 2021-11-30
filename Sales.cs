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
using RestSharp;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Globalization;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.Utils.Menu;

namespace DeliciousPartnerApp
{
    public partial class Sales : Form
    {
        public Sales(string tabName1,string tabName2)
        {
            InitializeComponent();
            this.tabName1 = tabName1;
            this.tabName2 = tabName2;
        }
        string tabName1 = "", tabName2 = "";
        api_class apic = new api_class();
        ui_class uic = new ui_class();
        devexpress_class devc = new devexpress_class();
        DataTable dtBranch = new DataTable(), dtUser = new DataTable(), dtCustType = new DataTable();
        DataTable dtOrders = new DataTable(), dtItems = new DataTable();
        BackgroundWorker bgItems = new BackgroundWorker();
        public static DataTable dtSelectedDeposit;
        public void loadCustType()
        {
            try
            {
                cmbCustomerType.Invoke(new Action(delegate ()
                {
                    cmbCustomerType.Properties.Items.Clear();
                }));
                string sResult = "";
                sResult = apic.loadData("/api/custtype/get_all", "", "", "", Method.GET, true);
                if (sResult.Substring(0, 1).Equals("{"))
                {
                    dtCustType = apic.getDtDownloadResources(sResult, "data");
                    if (IsHandleCreated)
                    {
                        cmbCustomerType.Invoke(new Action(delegate ()
                        {
                            cmbCustomerType.Properties.Items.Add("All");
                        }));
                    }
                    foreach (DataRow row in dtCustType.Rows)
                    {
                        if (IsHandleCreated)
                        {
                            cmbCustomerType.Invoke(new Action(delegate ()
                            {
                                cmbCustomerType.Properties.Items.Add(row["name"].ToString());
                            }));
                        }

                    }
                    if (IsHandleCreated)
                    {
                        cmbCustomerType.Invoke(new Action(delegate ()
                        {
                            cmbCustomerType.SelectedIndex = 0;
                        }));
                    }
                }
                else
                {
                    apic.showCustomMsgBox("Validation", sResult);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public void loadSalesAgent()
        {
            try
            {
                cmbUser.Invoke(new Action(delegate ()
                {
                    cmbUser.Properties.Items.Clear();
                }));
                string sIsSales = "?isSales=1", sBranch = "&branch=" + apic.findValueInDataTable(dtBranch, cmbBranch.Text, "name", "code");
                string sParams = sIsSales + sBranch;
                string sResult = "";
                sResult = apic.loadData("/api/auth/user/get_all", sParams, "", "", Method.GET, true);
                if (sResult.Substring(0, 1).Equals("{"))
                {
                    dtUser = apic.getDtDownloadResources(sResult, "data");
                    if (IsHandleCreated)
                    {
                        cmbUser.Invoke(new Action(delegate ()
                        {
                            cmbUser.Properties.Items.Add("All");
                        }));
                    }
                    foreach (DataRow row in dtUser.Rows)
                    {
                        if (IsHandleCreated)
                        {
                            cmbUser.Invoke(new Action(delegate ()
                            {
                                cmbUser.Properties.Items.Add(row["username"].ToString());
                            }));
                        }

                    }
                    if (IsHandleCreated)
                    {
                        cmbUser.Invoke(new Action(delegate ()
                        {
                            cmbUser.SelectedIndex = 0;
                        }));
                    }
                }
                else
                {
                    apic.showCustomMsgBox("Validation", sResult);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public void loadBranches()
        {
            try
            {
                cmbBranch.Invoke(new Action(delegate ()
                {
                    cmbBranch.Properties.Items.Clear();
                }));
                if (apic.haveAccess())
                {
                    string sResult = "";
                    sResult = apic.loadData("/api/branch/get_all", "", "", "", Method.GET, true);
                    if (sResult.Substring(0, 1).Equals("{"))
                    {
                        dtBranch = apic.getDtDownloadResources(sResult, "data");
                        if (IsHandleCreated)
                        {
                            cmbBranch.Invoke(new Action(delegate ()
                            {
                                cmbBranch.Properties.Items.Add("All");
                            }));
                        }
                        foreach (DataRow row in dtBranch.Rows)
                        {
                            if (IsHandleCreated)
                            {
                                cmbBranch.Invoke(new Action(delegate ()
                                {
                                    cmbBranch.Properties.Items.Add(row["name"].ToString());
                                }));
                            }

                        }
                        if (IsHandleCreated)
                        {
                            cmbBranch.Invoke(new Action(delegate ()
                            {
                                string branch = (string)Login.jsonResult["data"]["branch"];
                                string s = apic.findValueInDataTable(dtBranch, branch, "code", "name");
                                cmbBranch.SelectedIndex = cmbBranch.Properties.Items.IndexOf(s) <= 0 ? 0 : cmbBranch.Properties.Items.IndexOf(s);
                            }));
                        }
                    }
                    else
                    {
                        apic.showCustomMsgBox("Validation", sResult);
                    }
                }
                else
                {
                    if (IsHandleCreated)
                    {
                        cmbBranch.Invoke(new Action(delegate ()
                        {
                            cmbBranch.Properties.Items.Add(Login.jsonResult["data"]["branch"]);
                            cmbBranch.SelectedIndex = 0;
                        }));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public void loadData()
        {
            gridControl2.Invoke(new Action(delegate ()
            {
                gridControl2.DataSource = null;
                gridView1.Columns.Clear();
                clearBills();
            }));
            string sBranch = "?branch=" + apic.findValueInDataTable(dtBranch, uic.delegateControl(cmbBranch), "name", "code");
            string sUserID = "&user_id=" + apic.findValueInDataTable(dtUser, uic.delegateControl(cmbUser), "username", "id");
            string sCustID = "&cust_type=" + apic.findValueInDataTable(dtCustType, uic.delegateControl(cmbCustomerType), "name", "id");
            string sTransType = "&transtype=" + tabName1;
            bool cCheckFromDate = false, cCheckToDate = false;
            checkFromDate.Invoke(new Action(delegate ()
            {
                cCheckFromDate = checkFromDate.Checked;
            }));
            checkToDate.Invoke(new Action(delegate ()
            {
                cCheckToDate = checkToDate.Checked;
            }));
            string sFromDate = "&from_date=" + (cCheckFromDate ? uic.delegateControl(dtFromDate) : "");
            string sToDate = "&to_date=" + (cCheckToDate ? uic.delegateControl(dtToDate) : "");
            string sFromTime = "&from_time=" + uic.delegateControl(cmbFromTime);
            string sToTime = "&to_time=" + uic.delegateControl(cmbToTime);

            string sParams = sBranch + sUserID + sCustID + sTransType + sFromDate + sToDate + sFromTime + sToTime;

            string finalUrl = tabName2.Equals("for Payment") ? "/api/payment/new" : tabName2.Equals("for Confirmation") ? "/api/sales/for_confirm" : "/api/sales/for_sap/get_all";

            string sResult = apic.loadData(finalUrl, sParams, "", "", Method.GET, true);
            if (!string.IsNullOrEmpty(sResult.Trim()))
            {
                if (sResult.Substring(0, 1).Equals("{"))
                {
                    JObject joResponse = JObject.Parse(sResult);
                    JArray jaData = (JArray)joResponse["data"];
                    dtOrders = (DataTable)JsonConvert.DeserializeObject(jaData.ToString(), (typeof(DataTable)));
                    //if (dtData.Rows.Count > 0)
                    //{
                    //    dtData.Columns.Add("edit_pricelist");
                    //    dtData.Columns.Add("edit");
                    //}
                    gridControl1.Invoke(new Action(delegate ()
                    {
                        gridControl1.DataSource = null;
                        string forSAPAmountColumnName = (tabName2.Equals("for SAP") ? "doctotal" : "amount_due");
                        if(dtOrders.Rows.Count > 0)
                        {
                            gridView1.OptionsSelection.MultiSelect = true;
                            gridView1.OptionsSelection.MultiSelectMode = GridMultiSelectMode.CheckBoxRowSelect;
                            DataColumn dc = new DataColumn("balance_due", typeof(double));
                            dtOrders.Columns.Add(dc);
                            dtOrders.Columns.Add("edit_amount_payable");

                            if(tabName1.Equals("AR Sales") && tabName2.Equals("for Confirmation"))
                            {
                                dtOrders.Columns.Add("print");
                            }

                            foreach (DataRow dr in dtOrders.Rows)
                            {
                                dr["balance_due"] = dr[forSAPAmountColumnName];
                            }
                        }else
                        {
                            gridView1.OptionsSelection.MultiSelect = false;
                            gridView1.OptionsSelection.MultiSelectMode = GridMultiSelectMode.RowSelect;
                        }



                        dtOrders.SetColumnsOrder("transdate", "reference", "balance_due", "cust_code", "tenderamt", "disctype", "disc_amount", "amount_due", "delfee", "remarks", "days_due", "user", "edit_amount_payable","print");

                        gridControl1.DataSource = dtOrders;
                        gridView1.OptionsView.ColumnAutoWidth = false;
                        gridView1.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.True;
                        foreach (GridColumn col in gridView1.Columns)
                        {
                            string fieldName = col.FieldName;
                            string v = col.GetCaption();
                            string s = v.Replace("_", " ");
                            col.Caption = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(s.ToLower());
                            col.Caption = fieldName.Equals("delfee") ? "Delivery Fee" : fieldName.Equals("days_due") ? "Aging" : fieldName.Equals("amount_due") ? "Amount Payable" : col.Caption;
                            col.ColumnEdit = fieldName.Equals("edit_amount_payable") ? repositoryItemButtonEdit2 : fieldName.Equals("transdate") || fieldName.Equals("reference") || fieldName.Equals("remarks") || fieldName.Equals("cust_code") ? repositoryItemMemoEdit2 : fieldName.Equals("print") ? repositoryItemButtonEdit5 : repositoryItemTextEdit1;

                            col.DisplayFormat.FormatType = fieldName.Equals("amount_due") || fieldName.Equals("balance_due") || fieldName.Equals("tenderamt") || fieldName.Equals("disc_amount") || fieldName.Equals("delfee") || fieldName.Equals("days_due") ? DevExpress.Utils.FormatType.Numeric : fieldName.Equals("transdate") ? DevExpress.Utils.FormatType.DateTime : DevExpress.Utils.FormatType.None;

                            col.Fixed = fieldName.Equals("transdate") || fieldName.Equals("reference") ? FixedStyle.Left : FixedStyle.None;


                            col.DisplayFormat.FormatString = fieldName.Equals("amount_due") || fieldName.Equals("balance_due") || fieldName.Equals("tenderamt") || fieldName.Equals("disc_amount") || fieldName.Equals("delfee") || fieldName.Equals("days_due") ? "n2" : fieldName.Equals("transdate") ? "yyyy-MM-dd HH:mm:ss" : "";

                            col.Visible = fieldName.Equals("reference") || fieldName.Equals("balance_due") || fieldName.Equals("amount_due") || fieldName.Equals("cust_code") || fieldName.Equals("tenderamt") || fieldName.Equals("disctype") || fieldName.Equals("disc_amount") || fieldName.Equals("delfee") || fieldName.Equals("remarks") || fieldName.Equals("user") || fieldName.Equals("days_due") || fieldName.Equals("transdate") || fieldName.Equals("edit_amount_payable") || fieldName.Equals("print");

                            //fonts
                            FontFamily fontArial = new FontFamily("Arial");
                            col.AppearanceHeader.Font = new Font(fontArial, 11, FontStyle.Regular);
                            col.AppearanceCell.Font = new Font(fontArial, 10, FontStyle.Regular);
                        }
                        //auto complete
                        string[] suggestions = {"cust_code", "reference","remarks" };
                        string suggestConcat = string.Join(";", suggestions);
                        gridView1.OptionsFind.FindFilterColumns = suggestConcat;
                        devc.loadSuggestion(gridView1, gridControl1, suggestions);
                        gridView1.BestFitColumns();
                        var colRemarks = gridView1.Columns["remarks"];
                        var colTransDate = gridView1.Columns["transdate"];
                        var colReference = gridView1.Columns["reference"];
                        var colCustCode = gridView1.Columns["cust_code"];
                        if (colRemarks != null)
                        {
                            colRemarks.Width = 100 ;
                        }
                        if (colTransDate != null)
                        {
                            colTransDate.Width = 100;
                        }
                        if (colReference != null)
                        {
                            colReference.Width = 100;
                        }
                        if (colCustCode != null)
                        {
                            colCustCode.Width = 100;
                        }
                    }));
                }
            }
        }

        public void delegateControlAssignText(Control c,string value)
        {
            if (IsHandleCreated)
            {
                c.Invoke(new Action(delegate ()
                {
                    c.Text = value;
                }));
            }
        }


        public void clearBills()
        {
            string sZero = "0.00";
            delegateControlAssignText(txtGrossPrice, sZero);
            delegateControlAssignText(txtDelFee, sZero);
            delegateControlAssignText(txtDiscountAmount, sZero);
            delegateControlAssignText(txtlAmountPayable, sZero);
            delegateControlAssignText(txtTotalPayment, sZero);
            delegateControlAssignText(txtChange, sZero);
        }

        public string checkDouble(string value)
        {
            double result = 0.00, doubleTemp = 0.00;
            result = double.TryParse(value, out doubleTemp) ? Convert.ToDouble(value) : doubleTemp;
            return result.ToString("n2");
        }

        public void computeChange()
        {
            int[] ids = gridView1.GetSelectedRows();
            double totalPayment = 0.00, amountPayable = 0.00, doubleTemp = 0.00;
            JObject jo = new JObject();
            JArray ja = new JArray();
            foreach (int id in ids)
            {
                amountPayable += gridView1.GetRowCellValue(id, "amount_due") == null ? doubleTemp : double.TryParse(gridView1.GetRowCellValue(id, "amount_due").ToString(), out doubleTemp) ? Convert.ToDouble(gridView1.GetRowCellValue(id, "amount_due").ToString()) : doubleTemp;
                totalPayment += gridView1.GetRowCellValue(id, "tenderamt") == null ? doubleTemp : double.TryParse(gridView1.GetRowCellValue(id, "tenderamt").ToString(), out doubleTemp) ? Convert.ToDouble(gridView1.GetRowCellValue(id, "tenderamt").ToString()) : doubleTemp;
            }
            if (dtSelectedDeposit.Rows.Count > 0)
            {
                DataTable dtTemp = dtSelectedDeposit;
                foreach (DataRow row in dtTemp.Rows)
                {
                    if (row["type"].ToString() == "Payment Method" || row["type"].ToString() == "Deposit")
                    {
                        totalPayment += double.TryParse(row["amount"].ToString(), out doubleTemp) ? Convert.ToDouble(row["amount"].ToString()) : doubleTemp;
                    }
                }
            }

            delegateControlAssignText(txtlAmountPayable, checkDouble(amountPayable.ToString()));
            delegateControlAssignText(txtTotalPayment, checkDouble(totalPayment.ToString()));
            double change = totalPayment - amountPayable;
            delegateControlAssignText(txtChange, (change > 0 ? change : 0.00).ToString("n2"));
        }

        public void loadItems(JObject jo)
        {
            string forSAPAmountColumnName = (tabName2.Equals("for SAP") ? "doctotal" : "amount_due");
            //string sBranch = "?branch=" + apic.findValueInDataTable(dtBranches, uic.delegateControl(cmbBranch), "name", "code");
            string sTransType = "?transtype=" + tabName1;
            string sParams = sTransType;
            string sResult = apic.loadData("/api/sales/summary_trans", sParams, "application/json", jo.ToString(), Method.PUT, true);
            if (!string.IsNullOrEmpty(sResult.Trim()))
            {
                if (sResult.Substring(0, 1).Equals("{"))
                {
                    JObject joResponse = JObject.Parse(sResult);
                    JObject joData = (JObject)joResponse["data"];

                    JObject joHeader = (JObject)joData["header"];
                    //header

                    double doubleTemp = 0.00;

                    delegateControlAssignText(txtGrossPrice, joHeader["gross"].IsNullOrEmpty() ? "0.00" : checkDouble(joHeader["gross"].ToString()));
                    delegateControlAssignText(txtDelFee, joHeader["delfee"].IsNullOrEmpty() ? "0.00" : checkDouble(joHeader["delfee"].ToString()));
                    delegateControlAssignText(txtDiscountAmount, joHeader["disc_amount"].IsNullOrEmpty() ? "0.00" : checkDouble(joHeader["disc_amount"].ToString()));
                    //delegateControlAssignText(txtlAmountPayable, joHeader[forSAPAmountColumnName].IsNullOrEmpty() ? "0.00" : checkDouble(joHeader[forSAPAmountColumnName].ToString()));
                    delegateControlAssignText(txtlAmountPayable, joHeader[forSAPAmountColumnName].IsNullOrEmpty() ? "0.00" : checkDouble(joHeader[forSAPAmountColumnName].ToString()));
                    delegateControlAssignText(txtChange, joHeader["change"].IsNullOrEmpty() ? "0.00" : checkDouble(joHeader["change"].ToString()));


                    computeChange();

                    JArray jaRow = (JArray)joData["row"];
                    dtItems = (DataTable)JsonConvert.DeserializeObject(jaRow.ToString(), (typeof(DataTable)));
                    //if (dtData.Rows.Count > 0)
                    //{
                    //    dtData.Columns.Add("edit_pricelist");
                    //    dtData.Columns.Add("edit");
                    //}
                    gridControl2.Invoke(new Action(delegate ()
                    {
                        gridControl2.DataSource = null;
                        //string forSAPAmountColumnName = (tabName.Equals("for SAP") ? "doctotal" : "amount_due");
                        //DataColumn dc = new DataColumn("balance_due", typeof(double));
                        //dtData.Columns.Add(dc);
                        //foreach (DataRow dr in dtData.Rows)
                        //{
                        //    dr["balance_due"] = dr[forSAPAmountColumnName];
                        //}

                        dtItems.SetColumnsOrder("item_code", "quantity", "unit_price", "discprcnt", "disc_amount", "linetotal");

                        gridControl2.DataSource = dtItems;
                        gridView2.OptionsView.ColumnAutoWidth = false;
                        gridView2.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.True;
                        foreach (GridColumn col in gridView2.Columns)
                        {
                            string fieldName = col.FieldName;
                            string v = col.GetCaption();
                            string s = v.Replace("_", " ");
                            col.Caption = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(s.ToLower());
                            col.Caption = fieldName.Equals("unit_price") ? "Price" : fieldName.Equals("discprcnt") ? "Disc. %" : fieldName.Equals("linetotal") ? "Total Amt." : fieldName.Equals("disc_amount") ? "Disc. Amt" : col.Caption;
                            col.ColumnEdit = fieldName.Equals("item_code") ? repositoryItemMemoEdit1 : repositoryItemTextEdit1;

                            col.DisplayFormat.FormatType = fieldName.Equals("quantity") || fieldName.Equals("unit_price") || fieldName.Equals("discprcnt") || fieldName.Equals("disc_amount") || fieldName.Equals("linetotal") ? DevExpress.Utils.FormatType.Numeric : DevExpress.Utils.FormatType.None;

                            col.DisplayFormat.FormatString = fieldName.Equals("quantity") || fieldName.Equals("unit_price") || fieldName.Equals("discprcnt") || fieldName.Equals("disc_amount") || fieldName.Equals("linetotal") ? "n2" : "";

                            col.Fixed = fieldName.Equals("item_code") ? FixedStyle.Left : FixedStyle.None;

                            col.Visible = fieldName.Equals("item_code") || fieldName.Equals("quantity") || fieldName.Equals("unit_price") || fieldName.Equals("discprcnt") || fieldName.Equals("disc_amount") || fieldName.Equals("linetotal");

                            //fonts
                            FontFamily fontArial = new FontFamily("Arial");
                            col.AppearanceHeader.Font = new Font(fontArial, 11, FontStyle.Regular);
                            col.AppearanceCell.Font = new Font(fontArial, 10, FontStyle.Regular);
                        }
                        //auto complete
                        string[] suggestions = { "item_code" };
                        string suggestConcat = string.Join(";", suggestions);
                        gridView2.OptionsFind.FindFilterColumns = suggestConcat;
                        devc.loadSuggestion(gridView2, gridControl2, suggestions);
                        gridView2.BestFitColumns();
                        var col2 = gridView2.Columns["item_code"];
                        if (col2 != null)
                        {
                            col2.Width = 100;
                        }
                    }));
                }
            }
        }

        public void bg(BackgroundWorker bg1)
        {
            if (!bg1.IsBusy)
            {
                closeForm();
                Loading frm = new Loading();
                frm.Show();
                bg1.RunWorkerAsync();
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


        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            loadData();
        }

        private void Sales_Load(object sender, EventArgs e)
        {
            this.Icon = Properties.Resources.abc_logo;
            dtFromDate.EditValue = DateTime.Now;
            dtToDate.EditValue = DateTime.Now;
            cmbFromTime.SelectedIndex = 0;
            cmbToTime.SelectedIndex = cmbToTime.Properties.Items.Count - 1;
            Console.WriteLine("tabname2 " + tabName2);
            btnConfirm.Text = tabName2.Equals("for SAP") ? "Close" : tabName2.Equals("for Payment") ? "Pay" : tabName2.Equals("for Confirmation") ? "Confirm" : "";
            //btnConfirm.Text = tabName2.Equals("for Payment") ? "PAY" : "CONFIRM";
            dtSelectedDeposit = new DataTable();
            dtSelectedDeposit.Columns.Clear();
            dtSelectedDeposit.Columns.Add("id");
            dtSelectedDeposit.Columns.Add("amount");
            dtSelectedDeposit.Columns.Add("payment_type");
            dtSelectedDeposit.Columns.Add("sapnum");
            dtSelectedDeposit.Columns.Add("reference2");
            dtSelectedDeposit.Columns.Add("type");

            dtSelectedDeposit.Rows.Clear();

            loadBranches();
            loadCustType();
            bg(backgroundWorker1);
        }
        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            closeForm();
        }

        private void checkFromDate_CheckedChanged(object sender, EventArgs e)
        {
            dtFromDate.Visible = checkFromDate.Checked;
        }

        private void checkToDate_CheckedChanged(object sender, EventArgs e)
        {
            dtToDate.Visible = checkToDate.Checked;
        }

        private void gridView1_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            int[] ids = gridView1.GetSelectedRows();
            JObject jo = new JObject();
            JArray ja = new JArray();
            double selectedAmount = 0.00, doubleTemp = 0.00;

            string forSAPAmountColumnName = (tabName2.Equals("for SAP") ? "doctotal" : "amount_due");
            foreach (int id in ids)
            {
                int idd = 0, intTemp = 0;
                idd = gridView1.GetRowCellValue(id, "id") == null ? intTemp : int.TryParse(gridView1.GetRowCellValue(id, "id").ToString(), out intTemp) ? Convert.ToInt32(gridView1.GetRowCellValue(id, "id").ToString()) : intTemp;

                selectedAmount += double.TryParse(gridView1.GetRowCellValue(id, forSAPAmountColumnName).ToString(), out doubleTemp) ? Convert.ToDouble(gridView1.GetRowCellValue(id, forSAPAmountColumnName).ToString()) : doubleTemp;

                ja.Add(idd);
            }

            lblpendingamount.Text = "Selected Amount: " + selectedAmount.ToString("n2");

            jo.Add("ids", ja);
            //loadItems(jo,totalPayment);
            computeChange();
            bgItems = new BackgroundWorker();
            bgItems.DoWork += delegate
            {
                loadItems(jo);
            };
            bgItems.RunWorkerCompleted += delegate
            {
                closeForm();
            };
            bg(bgItems);
        }

        private void repositoryItemButtonEdit2_Click(object sender, EventArgs e)
        {
            string forSAPAmountColumnName = (tabName2.Equals("for SAP") ? "doctotal" : "amount_due");
            var col = gridView1.Columns[forSAPAmountColumnName];
            var colRef = gridView1.Columns["reference"];

            double amount = 0.00, doubleTemp = 0.00;
            string reference= "";
            if(col != null)
            {
                amount = gridView1.GetFocusedRowCellValue(col) == null ? doubleTemp : double.TryParse(gridView1.GetFocusedRowCellValue(col).ToString(), out doubleTemp) ? Convert.ToDouble(gridView1.GetFocusedRowCellValue(col).ToString()) : doubleTemp;
            }
            if(colRef != null)
            {
                reference = gridView1.GetFocusedRowCellValue(colRef).ToString();
            }
            EnterAmount frm = new EnterAmount();
            EnterAmount.amount = 0.00;
            EnterAmount.amount = amount;
            frm.reference = reference;
            frm.ShowDialog();
            gridView1.SetRowCellValue(gridView1.FocusedRowHandle, forSAPAmountColumnName, EnterAmount.amount);
            computeChange();
        }

        private void btnVoid_Click(object sender, EventArgs e)
        {
            try
            {
                string selectedRefs = "";
                int[] ids = gridView1.GetSelectedRows();
                int[] selectedIds = new int[ids.Count()];
                MessageBox.Show(selectedIds.Count().ToString());
                int intTemp = 0;
                if (ids.Count() > 0)
                {
                    int counter = 0;
                    foreach (int id in ids)
                    {
                        Console.WriteLine("id " + gridView1.GetRowCellValue(id, "id").ToString());
                        selectedRefs = gridView1.GetRowCellValue(id, "reference").ToString() + Environment.NewLine;
                        int idd = int.TryParse(gridView1.GetRowCellValue(id, "id").ToString(), out intTemp) ? Convert.ToInt32(gridView1.GetRowCellValue(id, "id").ToString()) : intTemp;
                        selectedIds[counter] = idd;
                        counter++;
                    }
                    string sIds = string.Join("", selectedIds);
                    voidForm.isSubmit = false;
                    voidForm voidd = new voidForm();
                    //voidd.baseNum = Convert.ToInt32(dgvOrders.CurrentRow.Cells["transnumber"].Value.ToString());
                    voidd.lblOrderNumber.Text = "(" + ids.Count().ToString("N0") + ")";
                    voidd.selectedReference = selectedRefs;
                    voidd.selectedID = sIds;
                    voidd.ShowDialog();
                    if (voidForm.isSubmit)
                    {
                        bg(backgroundWorker1);
                    }
                }
                else
                {
                    MessageBox.Show("No reference selected!", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString(), ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnPaymentMethod_Click(object sender, EventArgs e)
        {
            PaymentMethodList paymentMethodList = new PaymentMethodList(this.Name);
            paymentMethodList.ShowDialog();
            computeChange();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SelectAdvancePayment selectAdvancePayment = new SelectAdvancePayment(this.Name);
            selectAdvancePayment.ShowDialog();
            computeChange();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to " + (tabName2 == "for Payment" ? "pay" : tabName2.Equals("for SAP") ? "close" : "confirm") + "?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                string forSAPAmountColumnName = (tabName2.Equals("for SAP") ? "doctotal" : "amount_due");
                int[] ids = gridView1.GetSelectedRows();
                if (ids.Count() > 0)
                {
                    if (tabName2.Equals("for Payment"))
                    {
                        string custCodeHeader = "";
                        int firstLoop = 0, intTemp = 0;
                        double doubleTemp = 0.00, totalTenderAmount = 0.00;
                        JArray jaSalesDetails = new JArray(), jaPaymentRows = new JArray();
                        JObject joBody = new JObject();
                        foreach (int id in ids)
                        {
                            firstLoop++;
                            if (firstLoop == 1)
                            {
                                custCodeHeader = gridView1.GetRowCellValue(id, "cust_code").ToString();
                            }
                            totalTenderAmount += double.TryParse(gridView1.GetRowCellValue(id, "tenderamt").ToString(), out doubleTemp) ? Convert.ToDouble(gridView1.GetRowCellValue(id, "tenderamt").ToString()) : doubleTemp;
                            int idd = int.TryParse(gridView1.GetRowCellValue(id, "id").ToString(), out intTemp) ? Convert.ToInt32(gridView1.GetRowCellValue(id, "id").ToString()) : intTemp;
                            double totalPayment = double.TryParse(gridView1.GetRowCellValue(id, forSAPAmountColumnName).ToString(), out doubleTemp) ? Convert.ToDouble(gridView1.GetRowCellValue(id, forSAPAmountColumnName).ToString()) : doubleTemp;

                            JObject joSalesDetails = new JObject();
                            joSalesDetails.Add("sales_id", idd);
                            joSalesDetails.Add("total_payment", totalPayment);
                            jaSalesDetails.Add(joSalesDetails);
                        }


                        dtSelectedDeposit.Rows.Add(null, totalTenderAmount, "CASH", "", "", "POS");

                        foreach (DataRow row in dtSelectedDeposit.Rows)
                        {
                            JObject joPaymentRows = new JObject();

                            double amount = double.TryParse(row["amount"].ToString(), out doubleTemp) ? Convert.ToDouble(row["amount"].ToString()) : doubleTemp;

                            joPaymentRows.Add("payment_type", string.IsNullOrEmpty(row["payment_type"].ToString().Trim()) ? null : row["payment_type"].ToString().Trim());
                            joPaymentRows.Add("amount", amount);
                            joPaymentRows.Add("sap_number", string.IsNullOrEmpty(row["sapnum"].ToString().Trim()) ? null : row["sapnum"].ToString().Trim());
                            joPaymentRows.Add("reference2", string.IsNullOrEmpty(row["reference2"].ToString().Trim()) ? null : row["reference2"].ToString().Trim());
                            jaPaymentRows.Add(joPaymentRows);
                        }
                        JObject joHeader = new JObject();
                        joHeader.Add("cust_code", string.IsNullOrEmpty(custCodeHeader.Trim()) ? null : custCodeHeader.Trim());
                        joHeader.Add("transdate", DateTime.Now.ToString("yyyy/MM/dd HH:mm"));
                        joHeader.Add("remarks", null);
                        joHeader.Add("reference", null);
                        joBody.Add("header", joHeader);
                        joBody.Add("payment_rows", jaPaymentRows);
                        joBody.Add("sales_details", jaSalesDetails);
                        string sResult = "";

                        sResult = apic.loadData("/api/payment/new", "", "application/json", joBody.ToString(), Method.POST, true);
                        if (!string.IsNullOrEmpty(sResult.Trim()))
                        {
                            if (sResult.Substring(0, 1).Equals("{"))
                            {

                                JObject joResponse = JObject.Parse(sResult);
                                string msg = joResponse["message"].ToString();
                                bool isSuccess = false, boolTemp = false;
                                isSuccess = bool.TryParse(joResponse["success"].ToString(), out boolTemp) ? Convert.ToBoolean(joResponse["success"].ToString()) : boolTemp;
                                MessageBox.Show(msg, isSuccess ? "Message" : "Validation", MessageBoxButtons.OK, isSuccess ? MessageBoxIcon.Information : MessageBoxIcon.Warning);
                                if (isSuccess)
                                {
                                    bg(backgroundWorker1);
                                }
                            }
                        }
                    }
                    else if(tabName2.Equals("for Confirmation"))
                    {
                        int[] baseIds = new int[ids.Count()];
                        int counter = 0;
                        foreach(int  id in ids)
                        {
                            int baseId = 0, intTemp = 0;
                            baseId = int.TryParse(gridView1.GetRowCellValue(counter, "id").ToString(), out intTemp) ? Convert.ToInt32(gridView1.GetRowCellValue(counter, "id").ToString()) : intTemp;
                            baseIds[counter] = baseId;
                            counter++;
                        }
                        if(baseIds.Count() > 0)
                        {
                            string result = string.Join("", baseIds);

                            string sResult = apic.loadData("/api/sales/confirm?ids=%5B" + result + "%5D", "", "", "", Method.PUT, true);
                            if (sResult.Substring(0, 1).Equals("{"))
                            {

                                JObject joResponse = JObject.Parse(sResult);
                                string msg = joResponse["message"].ToString();
                                bool isSuccess = false, boolTemp = false;
                                isSuccess = bool.TryParse(joResponse["success"].ToString(), out boolTemp) ? Convert.ToBoolean(joResponse["success"].ToString()) : boolTemp;
                                MessageBox.Show(msg, isSuccess ? "Message" : "Validation", MessageBoxButtons.OK, isSuccess ? MessageBoxIcon.Information : MessageBoxIcon.Warning);
                                if (isSuccess)
                                {
                                    bg(backgroundWorker1);
                                }
                            }
                        }
                    }else if(tabName2.Equals("for SAP"))
                    {
                        int[] baseIds = new int[ids.Count()];
                        int counter = 0;
                        foreach (int id in ids)
                        {
                            int baseId = 0, intTemp = 0;
                            baseId = int.TryParse(gridView1.GetRowCellValue(counter, "id").ToString(), out intTemp) ? Convert.ToInt32(gridView1.GetRowCellValue(counter, "id").ToString()) : intTemp;
                            baseIds[counter] = baseId;
                            counter++;
                        }
                        string result = string.Join("", baseIds);
                        forSAPAR_SAPNumber.isSubmit = false;
                        forSAPAR_SAPNumber frm = new forSAPAR_SAPNumber();
                        frm.ids = result;
                        frm.ShowDialog();
                        if (forSAPAR_SAPNumber.isSubmit)
                        {
                            bg(backgroundWorker1);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("No order selected found!", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }


        private void btnrefresh_Click(object sender, EventArgs e)
        {
            bg(backgroundWorker1);
        }

        public string salesDetails(int selectedID)
        {
            utility_class utilityc = new utility_class();
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

        private void repositoryItemButtonEdit5_Click(object sender, EventArgs e)
        {
            int id = 0, intTemp = 0;
            id = Int32.TryParse(gridView1.GetFocusedRowCellValue("id").ToString(), out intTemp) ? Convert.ToInt32(gridView1.GetFocusedRowCellValue("id").ToString()) : intTemp;
            JObject jo = JObject.Parse(salesDetails(id));

            DataTable dt = populateToPay(jo);
            print_toPay frm = new print_toPay();
            frm.dtResult = dt;
            frm.ShowDialog();
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

        private void gridView1_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            if (e.MenuType == DevExpress.XtraGrid.Views.Grid.GridMenuType.Row && tabName2.Equals("for Payment") && e.HitInfo.Column.FieldName.Equals("reference"))
            {
                DXMenuItem item = new DXMenuItem("Create Sales Return");
                item.Click += (o, args) =>
                {
                    int intTemp = 0;
                    int baseID = gridView1.GetFocusedRowCellValue("id") == null ? 0 : Int32.TryParse(gridView1.GetFocusedRowCellValue("id").ToString(), out intTemp) ? Convert.ToInt32(gridView1.GetFocusedRowCellValue("id")) : intTemp;


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

                };
                e.Menu.Items.Add(item);
            }
        }

        private void repositoryItemTextEdit2_Click(object sender, EventArgs e)
        {
  
        }

        private void repositoryItemMemoEdit1_Click(object sender, EventArgs e)
        {
            string selectedColumnfieldName = gridView2.FocusedColumn.FieldName;
            if (selectedColumnfieldName.Equals("item_code"))
            {

                int[] ids = gridView1.GetSelectedRows();
                int[] baseIds = new int[ids.Count()];
                int counter = 0;
                foreach (int id in ids)
                {
                    int baseId = 0, intTemp = 0;
                    baseId = int.TryParse(gridView1.GetRowCellValue(counter, "id").ToString(), out intTemp) ? Convert.ToInt32(gridView1.GetRowCellValue(counter, "id").ToString()) : intTemp;
                    baseIds[counter] = baseId;
                    counter++;
                }
                JArray jaIds = new JArray();
                foreach (int id in baseIds)
                {
                    jaIds.Add(id);
                }

                if (baseIds.Count() > 0)
                {
                    string sItemCode = gridView2.GetFocusedRowCellValue("item_code").ToString();

                    double disc = 0.00, doubleTemp = 0.00;
                    disc = double.TryParse(gridView2.GetFocusedRowCellValue("disc_amount").ToString(), out doubleTemp) ? Convert.ToDouble(gridView2.GetFocusedRowCellValue("disc_amount").ToString()) : doubleTemp;

                    JObject jsonObjectBody = new JObject();
                    jsonObjectBody.Add("ids", jaIds);
                    jsonObjectBody.Add("discount", disc);
                    jsonObjectBody.Add("item_code", sItemCode);

                    string sResult = apic.loadData("/api/sales/item/transaction/details", "", "application/json", jsonObjectBody.ToString(), Method.PUT, true);
                    if (!string.IsNullOrEmpty(sResult.Trim()))
                    {
                        if (sResult.Substring(0, 1).Equals("{"))
                        {

                            JObject joResponse = JObject.Parse(sResult);
                            string msg = joResponse["message"].ToString();
                            bool isSuccess = false, boolTemp = false;
                            isSuccess = bool.TryParse(joResponse["success"].ToString(), out boolTemp) ? Convert.ToBoolean(joResponse["success"].ToString()) : boolTemp;
                            if (isSuccess)
                            {
                                ItemDiscount itemDisc = new ItemDiscount();
                                itemDisc.jsonResponse = joResponse.ToString();
                                itemDisc.ShowDialog();
                            }
                        }
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bg(backgroundWorker1);
        }

        private void btnSearchQuery_Click(object sender, EventArgs e)
        {
            bg(backgroundWorker1);
        }

        private void cmbBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadSalesAgent();
        }

        private void gridView1_RowStyle(object sender, RowStyleEventArgs e)
        {
            double discAmount = 0.00, doubleTemp = 0.00;
            discAmount = gridView1.GetRowCellValue(e.RowHandle, "disc_amount") == null ? doubleTemp : double.TryParse(gridView1.GetRowCellValue(e.RowHandle, "disc_amount").ToString(), out doubleTemp) ? Convert.ToDouble(gridView1.GetRowCellValue(e.RowHandle, "disc_amount").ToString()) : doubleTemp;
            if(discAmount > 0)
            {
                e.Appearance.BackColor = Color.FromArgb(252, 255, 166);
            }
        }
    }
}
