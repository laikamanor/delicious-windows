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
    public partial class CashVariance : Form
    {
        public CashVariance()
        {
            InitializeComponent();
        }

        private void CashVariance_Load(object sender, EventArgs e)
        {
            CashVariance2 pendingOrder = new CashVariance2("For SAP");
            showForm(panelForSAP, pendingOrder);
        }

        public void showForm(Panel panel, Form form)
        {
            panel.Controls.Clear();
            form.TopLevel = false;
            panel.Controls.Add(form);
            form.BringToFront();
            form.Show();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex.Equals(0))
            {
                CashVariance2 pendingOrder = new CashVariance2("For SAP");
                showForm(panelForSAP, pendingOrder);
            }
            else if (tabControl1.SelectedIndex.Equals(1))
            {
                CashVariance2 pendingOrder = new CashVariance2("Done");
                showForm(panelDone, pendingOrder);
            }
        }


    }
}
