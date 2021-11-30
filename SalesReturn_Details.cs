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
    public partial class SalesReturn_Details : Form
    {
        public SalesReturn_Details(int id)
        {
            InitializeComponent();
            this.id = id;
        }
        int id = 0;
        api_class apic = new api_class();
        devexpress_class devc = new devexpress_class();
        private void SalesReturn_Details_Load(object sender, EventArgs e)
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

        public void delegateControl(Control c, string value)
        {
            gridControl1.Invoke(new Action(delegate ()
            {
                c.Text = c.Name.Replace("lbl","")+ ": " + value;
            }));
        }

        public void loadData()
        {
            try
            {
                string sParams = id.ToString();
                string sResult = apic.loadData("/api/sales_return/get_by_id/", sParams, "", "", Method.GET, true);
                if (!string.IsNullOrEmpty(sResult) && sResult.Substring(0, 1).Equals("{"))
                {
                    JObject joResponse = JObject.Parse(sResult);
                    JObject joData = JObject.Parse(joResponse["data"].ToString());
                    JArray jaData = JArray.Parse(joData["rows"].ToString());

                    //headers
                    lblReference.Invoke(new Action(delegate ()
                    {
                        lblReference.Text = "Reference #: " + joData["reference"].ToString();
                    }));
                    lblCustCode.Invoke(new Action(delegate ()
                    {
                        lblCustCode.Text = "Cust. Code: " + joData["cust_code"].ToString();
                    }));
                    lblReference.Invoke(new Action(delegate ()
                    {
                        double docTotal = 0.00, doubleTemp = 0.00;
                        docTotal = double.TryParse(joData["doctotal"].ToString(), out doubleTemp) ? Convert.ToDouble(joData["doctotal"].ToString()) : doubleTemp;
                        lblDocTotal.Text = "Doc. Total: " + docTotal.ToString("n2");
                    }));

                    DataTable dtData = (DataTable)JsonConvert.DeserializeObject(jaData.ToString(), (typeof(DataTable)));
                    dtData.SetColumnsOrder("item_code", "quantity", "unit_price", "disc_amount", "discprcnt", "gross", "linetotal", "uom", "whsecode");
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
                                col.DisplayFormat.FormatType = fieldName.Equals("quantity") || fieldName.Equals("unit_price") || fieldName.Equals("disc_amount") || fieldName.Equals("discprcnt") || fieldName.Equals("gross") || fieldName.Equals("linetotal") ? DevExpress.Utils.FormatType.Numeric : DevExpress.Utils.FormatType.None;
                                col.DisplayFormat.FormatString = fieldName.Equals("quantity") || fieldName.Equals("unit_price") || fieldName.Equals("disc_amount") || fieldName.Equals("discprcnt") || fieldName.Equals("gross") || fieldName.Equals("linetotal") ? "n2" : "";
                                col.ColumnEdit = fieldName.Equals("remarks") ? repositoryItemMemoEdit1 : repositoryItemTextEdit1;

                                col.Fixed = fieldName.Equals("item_code") ? FixedStyle.Left : FixedStyle.None;

                                col.Visible = !(fieldName.Equals("id") || fieldName.Equals("return_id") || fieldName.Equals("sales_row_type") || fieldName.Equals("gl_account") || fieldName.Equals("sales_row_id"));
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
                        }));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.ToString());
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
    }
}
