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
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Columns;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System.Globalization;

namespace DeliciousPartnerApp
{
    public partial class SalesReturn : Form
    {
        public SalesReturn()
        {
            InitializeComponent();
        }
        api_class apic = new api_class();
        devexpress_class devc = new devexpress_class();
        private void SalesReturn_Load(object sender, EventArgs e)
        {
            this.Icon = Properties.Resources.delicious1;
            bg();
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

        public void loadData()
        {
            try
            {
                string sParams = "";
                string sResult = apic.loadData("/api/sales_return/get_all", sParams, "", "", Method.GET, true);
                if (!string.IsNullOrEmpty(sResult) && sResult.Substring(0, 1).Equals("{"))
                {
                    JObject joResponse = JObject.Parse(sResult);
                    JArray jaData = (JArray)joResponse["data"];
                    DataTable dtData = (DataTable)JsonConvert.DeserializeObject(jaData.ToString(), (typeof(DataTable)));
                    if (IsHandleCreated)
                    {
                        gridControl1.Invoke(new Action(delegate ()
                        {
                            gridControl1.DataSource = null;
                            gridControl1.DataSource = dtData;
                            gridView1.OptionsView.ColumnAutoWidth = false;
                            gridView1.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.True;
                            foreach (GridColumn col in gridView1.Columns)
                            {
                                string fieldName = col.FieldName;
                                string v = col.GetCaption();
                                string s = col.GetCaption().Replace("_", " ");
                                col.Caption = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(s.ToLower());
                                col.DisplayFormat.FormatType = fieldName.Equals("transdate") ? DevExpress.Utils.FormatType.DateTime : fieldName.Equals("doctotal") ? DevExpress.Utils.FormatType.Numeric : DevExpress.Utils.FormatType.None;
                                col.DisplayFormat.FormatString = fieldName.Equals("transdate") ? "yyyy-MM-dd HH:mm:ss" : fieldName.Equals("doctotal") ? "n2" : "";
                                col.ColumnEdit = fieldName.Equals("remarks") ? repositoryItemMemoEdit1 : repositoryItemTextEdit1;

                                col.Visible = !(fieldName.Equals("id") || fieldName.Equals("docstatus"));
                                //fonts
                                FontFamily fontArial = new FontFamily("Arial");
                                col.AppearanceHeader.Font = new Font(fontArial, 11, FontStyle.Regular);
                                col.AppearanceCell.Font = new Font(fontArial, 10, FontStyle.Regular);
                            }
                            //auto complete
                            string[] suggestions = { "reference" };
                            string suggestConcat = string.Join(";", suggestions);
                            gridView1.OptionsFind.FindFilterColumns = suggestConcat;
                            devc.loadSuggestion(gridView1, gridControl1, suggestions);
                            gridView1.BestFitColumns();
                            var col2 = gridView1.Columns["remarks"];
                            if (col2 != null)
                            {
                                col2.Width = 200;
                            }
                        }));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.ToString());
            }
        }


        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            closeForm();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            loadData();
        }
        private void SalesReturn_MouseMove(object sender, MouseEventArgs e)
        {
        }

        private void gridView1_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {

        }

        private void repositoryItemTextEdit1_Click(object sender, EventArgs e)
        {
            string selectedColumnfieldName = gridView1.FocusedColumn.FieldName;
           if(selectedColumnfieldName.Equals("reference"))
            {
                int id = 0, intTemp = 0;
                id = gridView1.GetFocusedRowCellValue("id") == null ? 0 : Int32.TryParse(gridView1.GetFocusedRowCellValue("id").ToString(), out intTemp) ? Convert.ToInt32(gridView1.GetFocusedRowCellValue("id")) : intTemp;
                SalesReturn_Details frm = new DeliciousPartnerApp.SalesReturn_Details(id);
                frm.ShowDialog();
            }
        }
    }
}
