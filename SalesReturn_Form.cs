using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms;
using DeliciousPartnerApp.UI_Class;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Columns;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System.Globalization;
namespace DeliciousPartnerApp
{
    public partial class SalesReturn_Form : Form
    {
        public SalesReturn_Form(JObject joBody)
        {
            InitializeComponent();
            this.joBody = joBody;
        }
        devexpress_class devc = new devexpress_class();
        api_class apic = new api_class();
        JObject joBody = new JObject();
        private void SalesReturn_Form_Load(object sender, EventArgs e)
        {
            this.Icon = Properties.Resources.delicious1;
            loadData();
        }

        public void loadData()
        {
            JObject joResponse = JObject.Parse(joBody.ToString());

            lblReference.Text = "Reference #: " + (joResponse["header"]["base_ref"].IsNullOrEmpty() ? "" : joResponse["header"]["base_ref"].ToString());
            lblCustCode.Text = "Cust. Code: " + (joResponse["header"]["cust_code"].IsNullOrEmpty() ? "" : joResponse["header"]["cust_code"].ToString());

            JArray jaRows = (JArray)joResponse["rows"];
            DataTable dt = (DataTable)JsonConvert.DeserializeObject(jaRows.ToString(), (typeof(DataTable)));
            dt.Columns.Add("actual_quantity", typeof(double));
            dt.Columns.Add("variance", typeof(double));

            double doubleTemp = 0.00;
            foreach (DataRow row in dt.Rows)
            {
                row["actual_quantity"] = row["quantity"].ToString();
                double quantity = double.TryParse(row["quantity"].ToString(), out doubleTemp) ? Convert.ToDouble(row["quantity"].ToString()) : doubleTemp;
                double actualQuantity = double.TryParse(row["actual_quantity"].ToString(), out doubleTemp) ? Convert.ToDouble(row["actual_quantity"].ToString()) : doubleTemp;
                double variance = actualQuantity - quantity;
                row["variance"] = variance;
            }

            dt.SetColumnsOrder("item_code", "uom", "unit_price", "whsecode", "quantity", "actual_quantity", "variance");
            if (IsHandleCreated)
            {
                gridControl1.Invoke(new Action(delegate ()
                {
                gridControl1.DataSource = null;
                gridControl1.DataSource = dt;
                gridView1.OptionsView.ColumnAutoWidth = false;
                gridView1.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.True;
                foreach (GridColumn col in gridView1.Columns)
                {
                    string fieldName = col.FieldName;
                    string v = col.GetCaption();
                    string s = col.GetCaption().Replace("_", " ");
                    col.Caption = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(s.ToLower());
                    col.DisplayFormat.FormatType = fieldName.Equals("item_code") || fieldName.Equals("uom") || fieldName.Equals("whsecode") ? DevExpress.Utils.FormatType.None : DevExpress.Utils.FormatType.Numeric;
                    col.DisplayFormat.FormatString = fieldName.Equals("item_code") || fieldName.Equals("uom") || fieldName.Equals("whsecode") ? "" : "n2";
                    col.ColumnEdit = fieldName.Equals("actual_quantity") ? repositoryItemTextEdit2 : repositoryItemTextEdit1;

                    col.Visible = !(fieldName.Equals("sales_row_id"));

                        //fonts
                        FontFamily fontArial = new FontFamily("Arial");
                        col.AppearanceHeader.Font = new Font(fontArial, 11, FontStyle.Regular);
                        col.AppearanceCell.Font = new Font(fontArial, 10, FontStyle.Regular);
                    }
                    //auto complete
                    string[] suggestions = { "item_code" };
                    string suggestConcat = string.Join(";", suggestions);
                    gridView1.OptionsFind.FindFilterColumns = suggestConcat;
                    devc.loadSuggestion(gridView1, gridControl1, suggestions);
                    gridView1.BestFitColumns();
                    //var col2 = gridView1.Columns["remarks"];
                    //if (col2 != null)
                    //{
                    //    col2.Width = 200;
                    //}
                }));
            }
        }

        public void submit(string body)
        {
            api_class apic = new api_class();
            string sResult = apic.loadData("/api/sales_return/add", "", "application/json", body, Method.POST, true);
            if (!string.IsNullOrEmpty(sResult) && sResult.Substring(0, 1).Equals("{"))
            {
                JObject joResponse = JObject.Parse(sResult.Trim());
                bool isSuccess = false, boolTemp = false;
                isSuccess = bool.TryParse(joResponse["success"].ToString(), out boolTemp) ? Convert.ToBoolean(joResponse["success"].ToString()) : boolTemp;
                string msg = joResponse["message"].ToString();
                MessageBox.Show(msg, isSuccess ? "Message" : "Validation", MessageBoxButtons.OK, isSuccess ? MessageBoxIcon.Information : MessageBoxIcon.Warning);
                if (isSuccess)
                {
                    this.Close();
                }
            }
        }

        private void gridView1_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                double doubleTemp = 0.00;
                double balance = Convert.ToDouble(gridView1.GetFocusedRowCellValue("quantity").ToString());

                var varCol = gridView1.Columns["variance"];
                if (e.Value.ToString().Trim() == "")
                {
                    gridView1.SetRowCellValue(e.RowHandle, varCol, null);
                    //if (e.RowHandle >= 0)
                    //{
                    //    joBody["rows"]["quantity"]
                    //}
                }
                else
                {
                    double actualCount = double.TryParse(e.Value.ToString(), out doubleTemp) ? Convert.ToDouble(e.Value.ToString()) : doubleTemp;

                    double variance = actualCount - balance;

                    //if (e.RowHandle >= 0)
                    //{
                    //    jaSelected[e.RowHandle]["actual_quantity"] = actualCount;
                    //}
                    gridView1.SetRowCellValue(e.RowHandle, varCol, variance.ToString("n3"));
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void gridView1_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            if (e.Column.FieldName.Equals("variance"))
            {
                double doubleTemp = 0.00;
                double variance = double.TryParse(e.CellValue.ToString(), out doubleTemp) ? Convert.ToDouble(e.CellValue.ToString()) : doubleTemp;
                e.Appearance.ForeColor = variance == 0 ? Color.Black : variance < 0 ? Color.Red : Color.Blue;
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure you want to submit?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    JObject joFinalBody = new JObject();
                    joBody["header"]["remarks"] = txtRemarks.Text.Trim();
                    JObject joFinalHeader = JObject.Parse(joBody["header"].ToString());
                    JArray jaFinalRows = new JArray();
                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        JObject joFinalRows = new JObject();

                        int salesRowID = 0, intTemp = 0;
                        salesRowID = int.TryParse(gridView1.GetRowCellValue(i, "sales_row_id").ToString(), out intTemp) ? Convert.ToInt32(gridView1.GetRowCellValue(i, "sales_row_id").ToString()) : intTemp;

                        joFinalRows.Add("sales_row_id", salesRowID);

                        joFinalRows.Add("item_code", gridView1.GetRowCellValue(i, "item_code").ToString());
                        joFinalRows.Add("uom", gridView1.GetRowCellValue(i, "uom").ToString());
                        joFinalRows.Add("whsecode", gridView1.GetRowCellValue(i, "whsecode").ToString());

                        double unitPrice = 0.00, quantity = 0.00, doubleTemp = 0.00;
                        unitPrice = double.TryParse(gridView1.GetRowCellValue(i, "unit_price").ToString(), out doubleTemp) ? Convert.ToDouble(gridView1.GetRowCellValue(i, "unit_price").ToString()) : doubleTemp;
                        quantity = double.TryParse(gridView1.GetRowCellValue(i, "actual_quantity").ToString(), out doubleTemp) ? Convert.ToDouble(gridView1.GetRowCellValue(i, "actual_quantity").ToString()) : doubleTemp;

                        joFinalRows.Add("quantity", quantity);
                        joFinalRows.Add("unit_price", unitPrice);
                        jaFinalRows.Add(joFinalRows);
                    }
                    joFinalBody.Add("header", joFinalHeader);
                    joFinalBody.Add("rows", jaFinalRows);
                    if (string.IsNullOrEmpty(txtRemarks.Text.Trim()))
                    {
                        MessageBox.Show("Remarks field is required!", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    else
                    {
                        Console.WriteLine(joFinalBody.ToString());
                        submit(joFinalBody.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
