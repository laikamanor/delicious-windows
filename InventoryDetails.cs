using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
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
    public partial class InventoryDetails : Form
    {
        public InventoryDetails(DataTable dt, int id)
        {
            gDt = dt;
            selectedID = id;
            InitializeComponent();
        }
        DataTable gDt = new DataTable();
        int selectedID = 0;
        private void InventoryDetails_Load(object sender, EventArgs e)
        {
            if (!backgroundWorker1.IsBusy)
            {
                backgroundWorker1.RunWorkerAsync();
            }
        }

        public void loadData()
        {
            gridControl1.Invoke(new Action(delegate ()
            {
                gridControl1.DataSource = gDt;
                foreach (GridColumn col in gridView1.Columns)
                {
                    col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                    col.DisplayFormat.FormatString = "n2";
                    string s = col.GetCaption().Replace("_", " ");
                    col.Caption = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(s.ToLower());

                    col.Caption = selectedID >= 7 && col.Caption.Equals("Warehouse") ? "From Warehouse" : selectedID >= 7 && col.Caption.Equals("Warehouse2") ? "To Warehouse" : col.Caption;

                    col.Caption = selectedID <= 6 && col.Caption.Equals("Warehouse") ? "To Warehouse" : selectedID <= 6 && col.Caption.Equals("Warehouse2") ? "From Warehouse" : col.Caption;

                    switch (col.Caption)
                    {
                        case "Cust Code":
                            col.Caption = "Cust. Code";
                            col.Visible = this.Text.Equals("Sold") ? true : false;
                            break;
                        case "Discprcnt":
                            col.Caption = "Disc. %";
                            col.Visible = this.Text.Equals("Sold") ? true : false;
                            break;
                        case "Unit Price":
                            col.Visible = this.Text.Equals("Sold") ? true : false;
                            break;
                        case "Disc Amount":
                            col.Caption = "Disc. Amount";
                            col.Visible = this.Text.Equals("Sold") ? true : false;
                            break;
                        case "Net Amount":
                            col.Visible = this.Text.Equals("Sold") ? true : false;
                            break;
                        case "Trans Id":
                            col.Visible = false;
                            break;
                        case "From Warehouse":
                            //col.Visible = this.Text.Equals("Sold") ? true : false;
                            col.Caption = this.Text.Equals("Sold") ? "Warehouse" : col.Caption;
                            break;
                        case "Username":
                            col.Caption = "Processed By";
                            break;
                        case "To Warehouse":
                            col.Visible = this.Text.Equals("Sold") ? false : true;
                            break;
                        case "Sap Number":
                            col.DisplayFormat.FormatString = "";
                            break;
                        default:
                            col.Visible = true;
                            break;
                    }

                    col.Width = 100;

                    (gridControl1.MainView as GridView).Columns[col.AbsoluteIndex].ColumnEdit = repositoryItemTextEdit1;
                }
                if(gridView1.DataRowCount > 0)
                {
                    if (this.Text == "Sold")
                    {
                        gridView1.Columns.ColumnByFieldName("cust_code").VisibleIndex = gridView1.Columns.ColumnByFieldName("item_code").VisibleIndex;

                        gridView1.Columns.ColumnByFieldName("item_code").VisibleIndex = gridView1.Columns.ColumnByFieldName("quantity").VisibleIndex;

                        gridView1.Columns.ColumnByFieldName("unit_price").VisibleIndex = gridView1.Columns.ColumnByFieldName("warehouse").VisibleIndex;

                        gridView1.Columns.ColumnByFieldName("discprcnt").VisibleIndex = gridView1.Columns.ColumnByFieldName("warehouse").VisibleIndex;

                        gridView1.Columns.ColumnByFieldName("disc_amount").VisibleIndex = gridView1.Columns.ColumnByFieldName("warehouse").VisibleIndex;

                        gridView1.Columns.ColumnByFieldName("net_amount").VisibleIndex = gridView1.Columns.ColumnByFieldName("warehouse").VisibleIndex;
                        lblDiscAmount.Visible = true;
                        lblNetAmount.Visible = true;
                    }
                    else
                    {
                        lblDiscAmount.Visible = false;
                        lblNetAmount.Visible = false;
                    }
                }
            }));
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            loadData();
        }

        private void gridView1_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            int[] array1;
            double quantity = 0.00, discAmount=0.00,netAmount=0.00, doubleTemp = 0.00;
            array1 = gridView1.GetSelectedRows();
            foreach (int a in array1)
            {
                quantity += double.TryParse(gridView1.GetRowCellValue(a, "quantity").ToString(), out doubleTemp) ? Convert.ToDouble(gridView1.GetRowCellValue(a, "quantity").ToString()) : doubleTemp;
                discAmount += double.TryParse(gridView1.GetRowCellValue(a, "disc_amount").ToString(), out doubleTemp) ? Convert.ToDouble(gridView1.GetRowCellValue(a, "disc_amount").ToString()) : doubleTemp;
                netAmount += double.TryParse(gridView1.GetRowCellValue(a, "net_amount").ToString(), out doubleTemp) ? Convert.ToDouble(gridView1.GetRowCellValue(a, "net_amount").ToString()) : doubleTemp;
            }
            lblTotalQuantity.Text = "Total Quantity: " + quantity.ToString("n2");
            lblDiscAmount.Text = "Total Disc. Amount: " + discAmount.ToString("n2");
            lblNetAmount.Text = "Total Net Amount: " + netAmount.ToString("n2");
        }

        private void gridView1_RowStyle(object sender, RowStyleEventArgs e)
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
