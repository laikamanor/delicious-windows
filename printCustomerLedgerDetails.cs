using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeliciousPartnerApp
{
    public partial class printCustomerLedgerDetails : Form
    {
        public printCustomerLedgerDetails(DataTable dt1, DataTable dt2)
        {
            InitializeComponent();
            gDt1 = dt1;
            gDt2 = dt2;
        }
        DataTable gDt1 = new DataTable(),
            gDt2 = new DataTable();
        public string reference = "", customerCode = "", remarks = "";
        public DateTime dtTransDate = new DateTime();
        private void printCustomerLedgerDetails_Load(object sender, EventArgs e)
        {
            try
            {
                DataTable dtResult = gDt1;
                crPrintCustomerLedgerDetails finalReport = new crPrintCustomerLedgerDetails();
                finalReport.Database.Tables["paid_sales"].SetDataSource(dtResult);
                finalReport.Subreports[0].Database.Tables["payment_method"].SetDataSource(gDt2);
                finalReport.SetParameterValue("reference", reference);
                finalReport.SetParameterValue("customer_code", customerCode);
                finalReport.SetParameterValue("transdate", dtTransDate);
                finalReport.SetParameterValue("remarks", remarks);
                crystalReportViewer1.ReportSource = null;
                crystalReportViewer1.ReportSource = finalReport;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
