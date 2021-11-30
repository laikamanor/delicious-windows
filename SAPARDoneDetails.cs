using DevExpress.XtraGrid.Columns;
using Newtonsoft.Json.Linq;
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

namespace DeliciousPartnerApp
{
    public partial class SAPARDoneDetails : Form
    {
        public SAPARDoneDetails()
        {
            InitializeComponent();
        }
        public DataTable dtRows = new DataTable();
        public JObject joHeader = new JObject();

        private void SAPARDoneDetails_Load(object sender, EventArgs e)
        {
            gridControl1.DataSource = dtRows;
            gridView1.OptionsView.ShowFooter = true;
            gridView1.Columns["item_code"].Summary.Clear();
            gridView1.Columns["item_code"].Summary.Add(DevExpress.Data.SummaryItemType.Count, "item_code", "Count: {0:N0}");

            foreach (GridColumn col in gridView1.Columns)
            {
                string a = col.FieldName;
                string v = col.GetCaption();
                string s = col.GetCaption().Replace("_", " ");
                col.Caption = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(s.ToLower());
                col.Caption = a.Equals("linetotal") ? "Total Amount" : col.GetCaption();
                col.Visible = a.Equals("free") ? false : true;
                col.ColumnEdit = repositoryItemTextEdit1;


                col.DisplayFormat.FormatType =a.Equals("item_code") || a.Equals("free") ? DevExpress.Utils.FormatType.None : DevExpress.Utils.FormatType.Numeric;

                col.DisplayFormat.FormatString = a.Equals("item_code") || a.Equals("free") ? "" : "n2";
            }
            gridView1.BestFitColumns();

            txtGrossPrice.Text = Convert.ToDouble((string)joHeader["gross"]).ToString("n2");
            txtDelFee.Text = Convert.ToDouble((string)joHeader["delfee"]).ToString("n2");
            txtDiscountAmount.Text = Convert.ToDouble((string)joHeader["disc_amount"]).ToString("n2");
            txtlAmountPayable.Text = Convert.ToDouble((string)joHeader["amount_due"]).ToString("n2");
            txtTotalPayment.Text = Convert.ToDouble((string)joHeader["tenderamt"]).ToString("n2");
            txtChange.Text = Convert.ToDouble((string)joHeader["change"]).ToString("n2");
        }

        private void gridView1_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                double doubleTemp = 0.00;
                double discAmt = double.TryParse(gridView1.GetRowCellValue(e.RowHandle, "disc_amount").ToString(), out doubleTemp) ? Convert.ToDouble(gridView1.GetRowCellValue(e.RowHandle, "disc_amount").ToString()) : doubleTemp;
                if (discAmt > 0)
                {
                    e.Appearance.BackColor = Color.Yellow;
                }
            }
        }
    }
}
