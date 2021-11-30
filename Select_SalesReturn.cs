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
    public partial class Select_SalesReturn : Form
    {
        public Select_SalesReturn()
        {
            InitializeComponent();
        }
        int id = 0;
        api_class apic = new api_class();
        devexpress_class devc = new devexpress_class();
        private void Select_SalesReturn_Load(object sender, EventArgs e)
        {
            this.Icon = DeliciousPartnerApp.Properties.Resources.delicious1;
            bg();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            loadData();
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            closeForm();
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

                    dtData.SetColumnsOrder("reference", "cust_code", "doctotal", "remarks", "created_by");

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

                                col.Visible = fieldName.Equals("reference") || fieldName.Equals("cust_code") || fieldName.Equals("doctotal");
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
                            //for (int i = 0; i < PendingOrder2.dtSelectedDeposit.Rows.Count; i++)
                            //{
                            //    DataRow row = PendingOrder2.dtSelectedDeposit.Rows[i];
                            //    if (row["type"].ToString() == "Sales Return")
                            //    {
                                  
                            //    }
                            //}

                        }));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.ToString());
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

        private void btnSubmit_Click(object sender, EventArgs e)
        {

            //PendingOrder2.dtSelectedDeposit.Rows.Clear();
            for (int i = 0; i < PendingOrder2.dtSelectedDeposit.Rows.Count; i++)
            {
                DataRow row = PendingOrder2.dtSelectedDeposit.Rows[i];
                if (row["type"].ToString() == "Sales Return")
                {
                    PendingOrder2.dtSelectedDeposit.Rows.RemoveAt(i);
                }
            }
            //for (int i = 0; i < dgv.Rows.Count; i++)
            //{
            //    if (Convert.ToBoolean(dgv.Rows[i].Cells["selectt"].Value.ToString()))
            //    {
            //        PendingOrder2.dtSelectedDeposit.Rows.Add(Convert.ToInt32(dgv.Rows[i].Cells["id"].Value.ToString()), Convert.ToDouble(dgv.Rows[i].Cells["total_payment"].Value.ToString()), "FDEPS", dgv.Rows[i].Cells["sapnumber"].Value.ToString(), dgv.Rows[i].Cells["reference"].Value.ToString(), "Deposit");
            //    }
            //}

            if (gridView1.DataRowCount > 0)
            {
                int[] ids = gridView1.GetSelectedRows();
                foreach (int id in ids)
                {
                    int returnID = 0, intTemp = 0;
                    returnID = int.TryParse(gridView1.GetRowCellValue(id, "id").ToString(), out intTemp) ? Convert.ToInt32(gridView1.GetRowCellValue(id, "id").ToString()) : intTemp;
                    
                    double docTotal = 0.00, doubleTemp = 0.00;
                    docTotal = double.TryParse(gridView1.GetRowCellValue(id, "doctotal").ToString(), out doubleTemp) ? Convert.ToDouble(gridView1.GetRowCellValue(id, "doctotal").ToString()) : doubleTemp;

                    string reference = gridView1.GetRowCellValue(id, "reference").ToString();

                    PendingOrder2.dtSelectedDeposit.Rows.Add(returnID, docTotal, "SRETURN", null, reference, "Sales Return");

                }

                foreach(DataRow row in PendingOrder2.dtSelectedDeposit.Rows)
                {
                    Console.WriteLine(row["id"].ToString() + "/" + row["reference2"].ToString());
                }
                
            }

            this.Dispose();


        }
    }
}
