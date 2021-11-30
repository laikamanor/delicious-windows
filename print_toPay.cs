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
    public partial class print_toPay : Form
    {
        public print_toPay()
        {
            InitializeComponent();
        }
        public DataTable dtResult = new DataTable();
        private void print_toPay_Load(object sender, EventArgs e)
        {
            ToPayPrint report = new ToPayPrint();
            report.Database.Tables["to_pay"].SetDataSource(dtResult);
            crystalReportViewer1.ReportSource = null;
            crystalReportViewer1.ReportSource = report;
            crystalReportViewer1.Refresh();
        }
    }
}
