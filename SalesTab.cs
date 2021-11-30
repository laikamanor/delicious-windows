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
    public partial class SalesTab : Form
    {
        public SalesTab()
        {
            InitializeComponent();
        }

        private void SalesTab_Load(object sender, EventArgs e)
        {
            this.Icon =Properties.Resources.abc_logo;
            Sales frm = new Sales("CASH","for Payment");
            showForm(panelCSPayment, frm);
           
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
                tcCashSales.SelectedIndex = 0;
                Sales pendingOrder = new Sales("CASH", "for Payment");
                showForm(panelCSPayment, pendingOrder);
            }
            else if (tabControl1.SelectedIndex.Equals(1))
            {
                tcARSales.SelectedIndex = 0;
                Sales pendingOrder = new Sales("AR Sales", "for Confirmation");
                showForm(panelARSalesConfirmation, pendingOrder);
            }
            else if (tabControl1.SelectedIndex.Equals(2))
            {
                tcAgentSales.SelectedIndex = 0;
                Sales pendingOrder = new Sales("Agent AR Sales", "for Confirmation");
                showForm(panelAgentSalesConfirmation, pendingOrder);
            }
        }

        private void tcCashSales_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tcCashSales.SelectedIndex.Equals(0))
            {
                tcCashSales.SelectedIndex = 0;
                Sales pendingOrder = new Sales("CASH", "for Payment");
                showForm(panelCSPayment, pendingOrder);
            }
            else if (tcCashSales.SelectedIndex.Equals(1))
            {
                PendingOrder_SAPAR pendingOrder = new PendingOrder_SAPAR("CASH", "for SAP");
                showForm(panelCSSAP, pendingOrder);
            }
            else if (tcCashSales.SelectedIndex.Equals(2))
            {
                forSAPIP forsapip = new forSAPIP("CASH", "for SAP IP");
                showForm(panelCSIP, forsapip);
            }
        }

        private void tcARSales_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tcARSales.SelectedIndex.Equals(0))
            {
                tcCashSales.SelectedIndex = 0;
                Sales pendingOrder = new Sales("AR Sales", "for Confirmation");
                showForm(panelARSalesConfirmation, pendingOrder);
            }
            else if (tcARSales.SelectedIndex.Equals(1))
            {
                Sales pendingOrder = new Sales("AR Sales", "for Payment");
                showForm(panelARSalesPayment, pendingOrder);
            }
            else if (tcARSales.SelectedIndex.Equals(2))
            {
                PendingOrder_SAPAR pendingOrder = new PendingOrder_SAPAR("AR Sales", "for SAP");
                showForm(panelARSalesSAP, pendingOrder);
            }
            else if (tcARSales.SelectedIndex.Equals(3))
            {
                forSAPIP forsapip = new forSAPIP("AR Sales", "for SAP IP");
                showForm(panelARSalesSAPIP, forsapip);
            }
        }

        private void tcAgentSales_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tcAgentSales.SelectedIndex.Equals(0))
            {
                Sales pendingOrder = new Sales("Agent AR Sales", "for Confirmation");
                showForm(panelAgentSalesConfirmation, pendingOrder);

            }
            else if (tcAgentSales.SelectedIndex.Equals(1))
            {
                Sales pendingOrder = new Sales("Agent AR Sales", "for Payment");
                showForm(panelAgentSalesPayment, pendingOrder);
            }
            else if (tcAgentSales.SelectedIndex.Equals(2))
            {
                PendingOrder_SAPAR pendingOrder = new PendingOrder_SAPAR("Agent AR Sales", "for SAP");
                showForm(panelAgentSalesSAP, pendingOrder);
            }
            else if (tcAgentSales.SelectedIndex.Equals(3))
            {
                forSAPIP forsapip = new forSAPIP("Agent AR Sales", "for SAP IP");
                showForm(panelAgentSalesSAPIP, forsapip);
            }
        }
    }
}
