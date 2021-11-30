using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DeliciousPartnerApp.API_Class.SOA;
namespace DeliciousPartnerApp
{
    public partial class SOA_Details : Form
    {
        public SOA_Details()
        {
            InitializeComponent();
        }
        soa_class soac = new soa_class();
        DataTable dtForSOA = new DataTable();
        public int selectedID = 0;
        private void SOA_Details_Load(object sender, EventArgs e)
        {
            loadData();
        }

        public async void loadData()
        {
            dtForSOA = await Task.Run(() => soac.getSOADetails(selectedID));
            dgv.Rows.Clear();
            foreach(DataRow row in dtForSOA.Rows)
            {
                dgv.Rows.Add(row["base_transdate"].ToString(), row["base_reference"].ToString(), row["sales_remarks"].ToString(), row["amount"].ToString());
                lblReference.Text = row["reference"].ToString();
                lblCustomerCode.Text = row["cust_code"].ToString();
                lblDateTransaction.Text = row["transdate"].ToString();
                lblTotalAmount.Text = row["total_amount"].ToString();
            }
            dgv.Columns["amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            printSOA frm = new printSOA();
            frm.dtResult = dtForSOA;
            frm.ShowDialog();
        }
    }
}
