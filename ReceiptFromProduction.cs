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
    public partial class ReceiptFromProduction : Form
    {
        public ReceiptFromProduction()
        {
            InitializeComponent();
        }

        private void ReceiptFromProduction_Load(object sender, EventArgs e)
        {
            Production_ReceivedProduction frm = new Production_ReceivedProduction("Receipt from Production");
            showForm(panelIssueProdOrder, frm);
        }

        public void showForm(Panel panel, Form form)
        {
            panel.Controls.Clear();
            form.TopLevel = false;
            panel.Controls.Add(form);
            form.BringToFront();
            form.Show();
        }

        private void tcProd_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tcProd.SelectedIndex.Equals(0))
            {
                Production_ReceivedProduction frm = new Production_ReceivedProduction("Receipt from Production");
                showForm(panelIssueProdOrder, frm);
            }
            else if (tcProd.SelectedIndex.Equals(1))
            {
                Production_ReceivedProduction frm = new Production_ReceivedProduction("For SAP");
                showForm(panelForSAP, frm);
            }
        }
    }
}
