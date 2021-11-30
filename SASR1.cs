using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using System.Globalization;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid;

namespace DeliciousPartnerApp
{
    public partial class SASR1 : Form
    {
        public SASR1(JArray ja, string arrayName, double dateDiff)
        {
            gDateDiff = dateDiff;
            jaBSR = ja;
            gArrayName = arrayName;
            InitializeComponent();
        }
        JArray jaBSR = new JArray();
        string gArrayName = "";
        double gDateDiff = 0.00;
        int avgIndex = 0, totalIndex = 0;
        private void SASR1_Load(object sender, EventArgs e)
        {
            lblTitle.Text = gArrayName.Equals("customer_summary_report") ? "Customer Summary" : "Branch Summary";
            DataTable dt = populateData();
            gridControl1.DataSource = dt;
            avgIndex = gridView1.DataRowCount - 1;
            totalIndex = gridView1.DataRowCount - 2;
            for (int i = 0; i < gridView1.Columns.Count; i++)
            {
                gridView1.Columns[i].SortMode = ColumnSortMode.Custom;
            }


            foreach (GridColumn col in gridView1.Columns)
            {
                if (col.Caption != "branch")
                {
                    col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                    col.DisplayFormat.FormatString = "n2";
                }
                string s = col.GetCaption().Replace("_", " ");
                col.Caption = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(s.ToLower());
                (gridControl1.MainView as GridView).Columns[col.AbsoluteIndex].ColumnEdit = repositoryItemTextEdit1;
            }
            //gridView1.Columns["branch"].GroupIndex = 1;
            GridColumn avgCol = gridView1.Columns["average (" + (Convert.ToDouble(gDateDiff.ToString("n2")) + 1) + ")"];
            if(avgCol != null)
            {
                gridView1.Columns.ColumnByFieldName("average (" + (Convert.ToDouble(gDateDiff.ToString("n2")) + 1) + ")").VisibleIndex = gridView1.Columns.Count;
            }

        }


        public DataTable populateData()
        {
            DataTable dt = new DataTable();
            if (gArrayName.Equals("customer_summary_report"))
            {
                dt.Columns.Add("cust_code", typeof(string));
                dt.Columns.Add("total_sales", typeof(double));
                dt.Columns.Add("average", typeof(double));
            }
            else
            {
                dt.Columns.Add("branch", typeof(string));
                dt.Columns.Add("total", typeof(double));
                dt.Columns.Add("average (" + (Convert.ToDouble(gDateDiff.ToString("n2")) + 1) + ")", typeof(double));
                dt.Columns.Add("cash_sales", typeof(double));
                dt.Columns.Add("ar_sales", typeof(double));
                dt.Columns.Add("agent_sales", typeof(double));
            }
            double stotal = 0.00, scashSales = 0.00, sarSales = 0.00, sagentSales = 0.00, sAverage = 0.00;
            for (int i = 0; i < jaBSR.Count(); i++)
            {
                JObject jo = JObject.Parse(jaBSR[i].ToString());
                string branch = "";
                double total = 0.00, doubleTemp = 0.00, cashSales = 0.00, arSales = 0.00, agentSales = 0.00, average = 0.00;
                if (gArrayName.Equals("customer_summary_report"))
                {
                    foreach (var q in jo)
                    {
                        if (q.Key.Equals("cust_code"))
                        {
                            branch = q.Value.ToString();
                        }
                        else if (q.Key.Equals("total_sales"))
                        {
                            total = double.TryParse(q.Value.ToString(), out doubleTemp) ? Double.Parse(q.Value.ToString(), CultureInfo.CurrentCulture) : doubleTemp;
                            stotal += total;
                        }
                    }
                }
                else;
                {
                    foreach (var q in jo)
                    {
                        if (q.Key.Equals("branch"))
                        {
                            branch = q.Value.ToString();
                        }
                        else if (q.Key.Equals("total"))
                        {
                            total = double.TryParse(q.Value.ToString(), out doubleTemp) ? Double.Parse(q.Value.ToString(), CultureInfo.CurrentCulture) : doubleTemp;
                            stotal += total;
                        }
                        else if (q.Key.Equals("cash_sales"))
                        {
                            cashSales = double.TryParse(q.Value.ToString(), out doubleTemp) ? Double.Parse(q.Value.ToString(), CultureInfo.CurrentCulture) : doubleTemp;
                            scashSales += cashSales;
                        }
                        else if (q.Key.Equals("ar_sales"))
                        {
                            arSales = double.TryParse(q.Value.ToString(), out doubleTemp) ? Double.Parse(q.Value.ToString(), CultureInfo.CurrentCulture) : doubleTemp;
                            sarSales += arSales;
                        }
                        else if (q.Key.Equals("agent_sales"))
                        {
                            agentSales = double.TryParse(q.Value.ToString(), out doubleTemp) ? Double.Parse(q.Value.ToString(), CultureInfo.CurrentCulture) : doubleTemp;
                            sagentSales += agentSales;
                        }
                    }
                }
                if (gArrayName.Equals("customer_summary_report"))
                {
                    dt.Rows.Add(branch, total, computeAverage(total));
                }
                else
                {
                    dt.Rows.Add(branch, total, computeAverage(total), cashSales, arSales, agentSales);
                }
                sAverage += computeAverage(total);
            }
            if (dt.Rows.Count > 0)
            {
                if (gArrayName.Equals("customer_summary_report"))
                {
                    dt.Rows.Add("Total", stotal);
                    dt.Rows.Add("Average (" + (Convert.ToDouble(gDateDiff.ToString("n2")) + 1) + ")", computeAverage(stotal));
                }
                else
                {
                    dt.Rows.Add("Total", stotal, null, scashSales, sarSales, sagentSales);
                    dt.Rows.Add("Average (" + (Convert.ToDouble(gDateDiff.ToString("n2")) + 1) + ")", computeAverage(stotal), null, computeAverage(scashSales), computeAverage(sarSales), computeAverage(sagentSales));
                }
            }
            return dt;
        }
        public double computeAverage(double value1)
        {
            double temp = Convert.ToDouble(gDateDiff.ToString("n2")) <= 0 ? 1 : gDateDiff + 1;
            return value1 / Convert.ToDouble(temp.ToString("n2"));
        }

        private void gridView1_CustomColumnSort(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnSortEventArgs e)
        {
            //if (e.Column.FieldName.Equals("branch"))
            //{
            //    if(e.Value1.Equals"")
            //}
            e.Handled = true;
            if (e.ListSourceRowIndex1 == avgIndex)
            {
                e.Result = (e.SortOrder == DevExpress.Data.ColumnSortOrder.Ascending ? 1 : -1);
            }
            else if (e.ListSourceRowIndex2 == avgIndex)
            {
                e.Result = (e.SortOrder == DevExpress.Data.ColumnSortOrder.Ascending ? -1 : 1);
            }
            else if (e.ListSourceRowIndex1 == totalIndex)
            {
                e.Result = (e.SortOrder == DevExpress.Data.ColumnSortOrder.Ascending ? 1 : -2);
            }
            else if (e.ListSourceRowIndex2 == totalIndex)
            {
                e.Result = (e.SortOrder == DevExpress.Data.ColumnSortOrder.Ascending ? -2 : 1);
            }
            else
            {
                e.Handled = false;
            }
        }
    }
}