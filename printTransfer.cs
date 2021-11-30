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
    public partial class printTransfer : Form
    {
        public printTransfer(DataTable dt)
        {
            InitializeComponent();
            gDt = dt;
        }
        DataTable gDt = new DataTable();
        private void printTransfer_Load(object sender, EventArgs e)
        {
         try
            {
                DataTable dtResult = gDt;
                crPrintTransfer finalReport = new crPrintTransfer();
                //finalReport.Database.Tables["transfer"].SetDataSource(dtResult);
                finalReport.Subreports[0].Database.Tables["transfer"].SetDataSource(dtResult);
                finalReport.Subreports[1].Database.Tables["transfer"].SetDataSource(dtResult);
                crystalReportViewer1.ReportSource = null;
                crystalReportViewer1.ReportSource = finalReport;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString(),"Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
