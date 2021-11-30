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
using Newtonsoft.Json;
using System.Globalization;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;

namespace DeliciousPartnerApp
{
    public partial class SalesPerCustomer_PaidDetails : Form
    {
        public SalesPerCustomer_PaidDetails()
        {
            InitializeComponent();
        }
        public int selectedID = 0;
        public string selectedCustCode = "", selectedReference = "", remarks = "";
        public DateTime dtTransDate = new DateTime();
        utility_class utilityc = new utility_class();
        private void SalesPerCustomer_PaidDetails_Load(object sender, EventArgs e)
        {
            //dgv.Columns["doc_total"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //dgv.Columns["balance_due"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //dgv.Columns["total_payment"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            lblCustomerCode.Text = selectedCustCode;
            lblReference.Text = selectedReference;
            loadData();
        }
        private int hotTrackRow = DevExpress.XtraGrid.GridControl.InvalidRowHandle;
        private int HotTrackRow
        {
            get
            {
                return hotTrackRow;
            }
            set
            {
                if (hotTrackRow != value)
                {
                    int prevHotTrackRow = hotTrackRow;
                    hotTrackRow = value;
                    gridView1.RefreshRow(prevHotTrackRow);
                    gridView1.RefreshRow(hotTrackRow);

                    if (hotTrackRow >= 0)
                        gridControl1.Cursor = Cursors.Hand;
                    else
                        gridControl1.Cursor = Cursors.Default;
                }
            }
        }
        private void gridView1_MouseMove(object sender, MouseEventArgs e)
        {
            GridView view = sender as GridView;
            GridHitInfo info = view.CalcHitInfo(new Point(e.X, e.Y));

            if (info.InRowCell)
                HotTrackRow = info.RowHandle;
            else
                HotTrackRow = DevExpress.XtraGrid.GridControl.InvalidRowHandle;
        }

        private void gridView1_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            if (e.RowHandle == HotTrackRow)
                e.Appearance.BackColor = gridView1.PaintAppearance.SelectedRow.BackColor;
            else
                e.Appearance.BackColor = e.Appearance.BackColor;
        }
        private int hotTrackRow2 = DevExpress.XtraGrid.GridControl.InvalidRowHandle;
        private int HotTrackRow2
        {
            get
            {
                return hotTrackRow2;
            }
            set
            {
                if (hotTrackRow2 != value)
                {
                    int prevHotTrackRow = hotTrackRow2;
                    hotTrackRow2 = value;
                    gridView2.RefreshRow(prevHotTrackRow);
                    gridView2.RefreshRow(hotTrackRow2);

                    if (hotTrackRow2 >= 0)
                        gridControl2.Cursor = Cursors.Hand;
                    else
                        gridControl2.Cursor = Cursors.Default;
                }
            }
        }
        private void gridView2_MouseMove(object sender, MouseEventArgs e)
        {
            GridView view = sender as GridView;
            GridHitInfo info = view.CalcHitInfo(new Point(e.X, e.Y));

            if (info.InRowCell)
                HotTrackRow2 = info.RowHandle;
            else
                HotTrackRow2 = DevExpress.XtraGrid.GridControl.InvalidRowHandle;
        }

        private void gridView2_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            if (e.RowHandle == HotTrackRow2)
                e.Appearance.BackColor = gridView1.PaintAppearance.SelectedRow.BackColor;
            else
                e.Appearance.BackColor = e.Appearance.BackColor;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt1 = new DataTable();
                dt1.Columns.Add("reference");
                dt1.Columns.Add("transdate");
                dt1.Columns.Add("doctotal", typeof(double));
                dt1.Columns.Add("total_payment",typeof(double));

                for (int i = 0; i < gridView1.DataRowCount; i++)
                {
                    string reference = gridView1.GetRowCellValue(i, "reference").ToString(),
                         transDate = gridView1.GetRowCellValue(i, "transdate").ToString();
                    double docTotal = 0.00, totalPayment = 0.00, doubleTemp = 0.00;
                    docTotal = double.TryParse(gridView1.GetRowCellValue(i, "doctotal").ToString(), out doubleTemp) ? Convert.ToDouble(gridView1.GetRowCellValue(i, "doctotal").ToString()) : doubleTemp;
                    totalPayment = double.TryParse(gridView1.GetRowCellValue(i, "total_payment").ToString(), out doubleTemp) ? Convert.ToDouble(gridView1.GetRowCellValue(i, "total_payment").ToString()) : doubleTemp;

                    dt1.Rows.Add(reference, transDate, Convert.ToDouble(docTotal.ToString("n2")), Convert.ToDouble(totalPayment.ToString("n2")));
                }

                DataTable dt2 = new DataTable();
                dt2.Columns.Add("payment_type");
                dt2.Columns.Add("amount", typeof(double));

                for (int i = 0; i < gridView2.DataRowCount; i++)
                {
                    string paymentType = gridView2.GetRowCellValue(i, "payment_type").ToString();
                    double amount = 0.00, doubleTemp = 0.00;
                    amount = double.TryParse(gridView2.GetRowCellValue(i, "amount").ToString(), out doubleTemp) ? Convert.ToDouble(gridView2.GetRowCellValue(i, "amount").ToString()) : doubleTemp;
                    dt2.Rows.Add(paymentType,Convert.ToDouble(amount.ToString("n2")));
                }

                printCustomerLedgerDetails frm = new printCustomerLedgerDetails(dt1, dt2);
                frm.reference = lblReference.Text;
                frm.customerCode = lblCustomerCode.Text;
                frm.dtTransDate = dtTransDate;
                frm.remarks = remarks;
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public void loadData()
        {
            gridControl1.DataSource = null;
            gridControl2.DataSource = null;
            gridView1.OptionsView.ColumnAutoWidth = gridView2.OptionsView.ColumnAutoWidth = false;
            gridView1.OptionsView.ColumnHeaderAutoHeight = gridView2.OptionsView.ColumnHeaderAutoHeight= DevExpress.Utils.DefaultBoolean.True;
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
                    bool isSuccess = false;
                    var client = new RestClient(utilityc.URL);
                    client.Timeout = -1;
                    var request = new RestRequest("/api/payment/paidsales/" + selectedID);
                    Console.WriteLine("/api/payment/paidsales/" + selectedID);
                    request.AddHeader("Authorization", "Bearer " + token);
                    request.Method = Method.GET;
                    var response = client.Execute(request);
                    if (response.ErrorMessage == null)
                    {
                        if (response.Content.ToString().Substring(0, 1).Equals("{"))
                        {
                            JObject jObject = JObject.Parse(response.Content.ToString());
                            foreach (var x in jObject)
                            {
                                if (x.Key.Equals("success"))
                                {
                                    if (Convert.ToBoolean(x.Value.ToString()))
                                    {
                                        isSuccess = true;
                                        break;
                                    }
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
                                            JObject joData = JObject.Parse(x.Value.ToString());
                                            foreach (var z in joData)
                                            {
                                                if (z.Key.Equals("paid_sales"))
                                                {
                                                    DataTable dt = (DataTable)JsonConvert.DeserializeObject(z.Value.ToString(), (typeof(DataTable)));
                                                    gridControl1.DataSource = dt;
                                                    gridView1.OptionsView.ShowFooter = true;
                                                    foreach (GridColumn col in gridView1.Columns)
                                                    {

                                                        string v = col.GetCaption();
                                                        string s = col.GetCaption().Replace("_", " ");
                                                        col.Caption = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(s.ToLower());
                                                        if (v.Equals("doctotal") || v.Equals("balance_due") || v.Equals("total_payment"))
                                                        {
                                                            col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                                                            col.DisplayFormat.FormatString = "n2";
                                                            //col.Width = v.Equals("total_payment") ? 100 : 70;
                                                            if (v.Equals("total_payment"))
                                                            {
                                                                col.Summary.Add(DevExpress.Data.SummaryItemType.Sum, "total_payment", "Total: {0:n2}");
                                                            }
                                                        }else if (v.Equals("cust_code"))
                                                        {
                                                            col.Visible = false;
                                                        }
                                                        else
                                                        {
                                                            //col.Width = v.Equals("reference") ? 150 : 130;
                                                        }
                                                        if (v.Equals("reference"))
                                                        {
                                                            col.Summary.Add(DevExpress.Data.SummaryItemType.Count, "reference", "Count: {0:N0}");
                                                        }
                                                        col.ColumnEdit = repositoryItemTextEdit1;
                                                        //fonts
                                                        FontFamily fontArial = new FontFamily("Arial");
                                                        col.AppearanceHeader.Font = new Font(fontArial, 11, FontStyle.Regular);
                                                        col.AppearanceCell.Font = new Font(fontArial, 10, FontStyle.Regular);
                                                    }
                                                    gridView1.BestFitColumns();

                                                }
                                                else if (z.Key.Equals("payment_method"))
                                                {
                                                    DataTable dt = (DataTable)JsonConvert.DeserializeObject(z.Value.ToString(), (typeof(DataTable)));
                                                    gridControl2.DataSource = dt;
                                                    gridView2.OptionsView.ShowFooter = true;
                                                    foreach (GridColumn col in gridView2.Columns)
                                                    {
                                                        string v = col.GetCaption();
                                                        string s = col.GetCaption().Replace("_", " ");
                                                        col.Caption = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(s.ToLower());
                                                        if (v.Equals("amount"))
                                                        {
                                                            col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                                                            col.DisplayFormat.FormatString = "n2";
                                                            col.Summary.Add(DevExpress.Data.SummaryItemType.Sum, "amount", "Total: {0:n2}");
                                                        }
                                                        if (v.Equals("payment_type"))
                                                        {
                                                            col.Summary.Add(DevExpress.Data.SummaryItemType.Count, "payment_type", "Count: {0:N0}");
                                                        }
                                                        col.ColumnEdit = repositoryItemTextEdit1;
                                                        //fonts
                                                        FontFamily fontArial = new FontFamily("Arial");
                                                        col.AppearanceHeader.Font = new Font(fontArial, 11, FontStyle.Regular);
                                                        col.AppearanceCell.Font = new Font(fontArial, 10, FontStyle.Regular);
                                                    }
                                                    gridView2.BestFitColumns();
                                                }
                                            }
                                        }
                                    }

                                }
                            }
                            else
                            {
                                MessageBox.Show(response.Content.ToString(), "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                        else
                        {
                            JObject jObject = JObject.Parse(response.Content.ToString());
                            string msg = "";
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
                        MessageBox.Show(response.ErrorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                }
            }
        }
    }
}
