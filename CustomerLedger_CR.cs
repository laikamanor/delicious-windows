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
    public partial class CustomerLedger_CR : Form
    {
        DataTable gDt;
        string gCustCode = "";
        public CustomerLedger_CR(DataTable dt,string custCode)
        {
            gDt = new DataTable();
            gDt = dt;
            gCustCode = custCode;
            InitializeComponent();
        }

        private void CustomerLedger_CR_Load(object sender, EventArgs e)
        {
            DataTable dtResult = gDt;
            CustomerLedgerDetailsReport finalReport = new CustomerLedgerDetailsReport();
            finalReport.Database.Tables["row"].SetDataSource(dtResult);
            finalReport.SetParameterValue("customer_code", gCustCode);
            crystalReportViewer1.ReportSource = null;
            crystalReportViewer1.ReportSource = finalReport;
        }
    }
}
