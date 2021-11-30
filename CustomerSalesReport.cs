using DevExpress.XtraGrid.Columns;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DeliciousPartnerApp.UI_Class;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid.Views.Grid;

namespace DeliciousPartnerApp
{
    public partial class CustomerSalesReport : Form
    {
        public CustomerSalesReport()
        {
            InitializeComponent();
        }
        api_class apic = new api_class();
        devexpress_class devc = new devexpress_class();
        private void newReport_Load(object sender, EventArgs e)
        {
            dtFromDate.EditValue = DateTime.Now;
            DateTime dtDate = new DateTime(), dtTemp = new DateTime();
            dtDate = DateTime.TryParse(dtFromDate.Text, out dtTemp) ? Convert.ToDateTime(dtFromDate.Text) : new DateTime();
            dtToDate.EditValue = dtDate.AddMonths(1).AddDays(-1);
            bg();
        }

        public void loadData()
        {
            try
            {
                string sFromDate = "?from_date=", sToDate = "&to_date=";
                dtFromDate.Invoke(new Action(delegate ()
                {
                    sFromDate += dtFromDate.Text;
                }));
                dtToDate.Invoke(new Action(delegate ()
                {
                    sToDate += dtToDate.Text;
                }));
                string sParams = sFromDate + sToDate;
                string sResult = apic.loadData("/api/report/customer/sales", sParams, "", "", Method.GET, true);
                if (!string.IsNullOrEmpty(sResult) && sResult.Substring(0, 1).Equals("{"))
                {
                    JObject joResponse = JObject.Parse(sResult);
                    JArray jaData = (JArray)joResponse["data"];
                    DataTable dtData = (DataTable)JsonConvert.DeserializeObject(jaData.ToString(), (typeof(DataTable)));

                    string[] items = dtData.AsEnumerable().Select(x => x.Field<string>("item_code")).Distinct().ToArray();
                    string[] custCodes = dtData.AsEnumerable().Select(x => x.Field<string>("cust_code")).Distinct().ToArray();

                    JObject jo = new JObject();
                    foreach (string custCode in custCodes)
                    {
                        JArray ja = new JArray();
                        JObject joItems = new JObject();
                        foreach (string item in items)
                        {
                            joItems.Add(item, null);
                        }
                        joItems.Add("total_quantity", null);
                        joItems.Add("avg_quantity", null);
                        joItems.Add("total_doctotal", null);
                        joItems.Add("avg_doctotal", null);
                        ja.Add(joItems);
                        jo.Add(custCode, ja);
                    }
                    //
                    DataTable dt2 = new DataTable();
                    dt2.Columns.Add("cust_code", typeof(string));
                    foreach (string item in items)
                    {
                        dt2.Columns.Add(item, typeof(double));
                    }
                    dt2.Columns.Add("total_quantity", typeof(double));
                    dt2.Columns.Add("avg_quantity", typeof(double));
                    dt2.Columns.Add("total_doctotal", typeof(double));
                    dt2.Columns.Add("avg_doctotal", typeof(double));

                    var groups = dtData.AsEnumerable()
                  .GroupBy(x => new
                  {
                      cust_code = x.Field<dynamic>("cust_code"),
                      days = x.Field<dynamic>("days"),
                      quantity = x.Field<dynamic>("quantity"),
                      avg_quantity = x.Field<dynamic>("avg_quantity"),
                      doctotal = x.Field<dynamic>("doctotal"),
                      avg_doctotal = x.Field<dynamic>("avg_doctotal"),
                      item_code = x.Field<dynamic>("item_code")
                  }).ToList();

                    foreach (var q in jo)
                    {
                        double quantity = 0.00, doctotal = 0.00, avgQuantity = 0.00, avgDocTotal = 0.00;
                        foreach (var group in groups)
                        {
                            if (q.Key.Equals(group.Key.cust_code))
                            {
                                JArray ja = JArray.Parse(q.Value.ToString());
                                for (int i = 0; i < ja.Count(); i++)
                                {
                                    JObject data = JObject.Parse(ja[i].ToString());
                                    foreach (var w in data)
                                    {
                                        if (w.Key.Equals(group.Key.item_code))
                                        {
                                            quantity += group.Key.quantity;
                                            doctotal += group.Key.doctotal;
                                            avgQuantity += group.Key.avg_quantity;
                                            avgDocTotal += group.Key.avg_doctotal;
                                            jo[q.Key][i][w.Key] = group.Key.quantity;
                                        }
                                    }
                                    jo[q.Key][i]["total_quantity"] = quantity;
                                    jo[q.Key][i]["total_doctotal"] = doctotal;
                                    jo[q.Key][i]["avg_quantity"] = avgQuantity;
                                    jo[q.Key][i]["avg_doctotal"] = avgDocTotal;
                                    lblDays.Invoke(new Action(delegate ()
                                    {
                                        lblDays.Text = "Days: " + group.Key.days;
                                    }));
                                }
                            }
                        }
                        quantity = doctotal = avgQuantity = avgDocTotal = 0.00;
                    }

                    foreach (var q in jo)
                    {
                        if (!string.IsNullOrEmpty(q.Value.ToString()))
                        {
                            if (q.Value.ToString().StartsWith("["))
                            {
                                JArray ja = JArray.Parse(q.Value.ToString());
                                DataTable dtItems = new DataTable();
                                dtItems = (DataTable)JsonConvert.DeserializeObject(ja.ToString(), (typeof(DataTable)));
                                dtItems.Columns.Add("cust_code", typeof(string));
                                foreach (DataRow row in dtItems.Rows)
                                {
                                    row["cust_code"] = q.Key.ToString();
                                    dt2.ImportRow(row);
                                }
                            }
                        }
                    }


                    if (dt2.Rows.Count > 0)
                    {
                        if (IsHandleCreated)
                        {
                            gridControl1.Invoke(new Action(delegate ()
                            {
                                gridControl1.DataSource = null;
                                gridControl1.DataSource = dt2;
                                gridView1.OptionsView.ColumnAutoWidth = false;
                                gridView1.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.True;
                                foreach (GridColumn col in gridView1.Columns)
                                {
                                    string v = col.GetCaption();
                                    string s = col.GetCaption().Replace("_", " ");
                                    col.Caption = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(s.ToLower());
                                    col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                                    col.DisplayFormat.FormatString = "{0:#,0.000}";
                                    //fonts
                                    FontFamily fontArial = new FontFamily("Arial");
                                    col.AppearanceHeader.Font = new Font(fontArial, 11, FontStyle.Regular);
                                    col.AppearanceCell.Font = new Font(fontArial, 10, FontStyle.Regular);
                                }
                                foreach (GridColumn col in gridView1.Columns)
                                {
                                    string fieldName = col.FieldName;
                                    string fieldName2 = fieldName.Replace("_", " ");
                                    string finalName = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(fieldName2);
                                    if (!(fieldName.Equals("cust_code") || fieldName.Contains("avg")))
                                    {
                                        gridView1.Columns[col.FieldName].Summary.Clear();
                                        gridView1.Columns[col.FieldName].Summary.Add(DevExpress.Data.SummaryItemType.Sum, fieldName, (fieldName.Contains("total") ? "Overall " : "Total ") + finalName.Replace("Total ", "") + " {0:n2}");
                                    }
                                }
                                //auto complete
                                string[] suggestions = { "cust_code" };
                                string suggestConcat = string.Join(";", suggestions);
                                gridView1.OptionsFind.FindFilterColumns = suggestConcat;
                                devc.loadSuggestion(gridView1, gridControl1, suggestions);
                                gridView1.BestFitColumns();
                            }));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.ToString());
            }
        }

        private void gridView1_ShowingEditor(object sender, CancelEventArgs e)
        {
            e.Cancel = true;
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

        public void bg()
        {
            if (!backgroundWorker1.IsBusy)
            {
                closeForm();
                Loading frm = new Loading();
                frm.Show();
                backgroundWorker1.RunWorkerAsync();
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

        private void dtFromDate_EditValueChanged(object sender, EventArgs e)
        {
            DateTime dtDate = new DateTime(), dtTemp = new DateTime();
            dtDate = DateTime.TryParse(dtFromDate.Text, out dtTemp) ? Convert.ToDateTime(dtFromDate.Text) : new DateTime();
            dtToDate.EditValue = dtDate.AddMonths(1).AddDays(-1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bg();
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

        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (e.RowHandle == HotTrackRow)
                e.Appearance.BackColor = gridView1.PaintAppearance.SelectedRow.BackColor;
            else
                e.Appearance.BackColor = e.Appearance.BackColor;
        }
    }
}
