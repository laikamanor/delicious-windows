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
    public partial class Production : Form
    {
        public Production()
        {
            InitializeComponent();
        }


        public void showForm(Panel panel, Form form)
        {
            panel.Controls.Clear();
            form.TopLevel = false;
            panel.Controls.Add(form);
            form.BringToFront();
            form.Show();
        }

        private void Production_Load(object sender, EventArgs e)
        {
            Production_ProductionOrder frm = new Production_ProductionOrder();
            showForm(panelForProdOrder, frm);
        }

        private void tcProd_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tcProd.SelectedIndex.Equals(0))
            {
                Production_ProductionOrder frm = new Production_ProductionOrder();
                showForm(panelForProdOrder, frm);
            }
            else if (tcProd.SelectedIndex.Equals(1))
            {
                Production_IssueProduction frm = new Production_IssueProduction("Issue for Production Order");
                showForm(panelIssueProd, frm);
            }
            else if (tcProd.SelectedIndex.Equals(2))
            {
                Production_ReceivedProduction frm = new Production_ReceivedProduction("Receipt from Production");
                showForm(panelReceivedProd, frm);
            }
        }
    }
}
