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
    public partial class PendingOrder : Form
    {
        public PendingOrder()
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

        private void tcCashSales_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(tcCashSales.SelectedIndex.Equals(0))
            {
                PendingOrder2 pendingOrder = new PendingOrder2("CASH", "for Payment");
                showForm(panelCSPayment, pendingOrder);
            }
            else if (tcCashSales.SelectedIndex.Equals(1))
            {
                PendingOrder2 pendingOrder = new PendingOrder2("CASH", "for SAP");
                showForm(panelCSSAP, pendingOrder);
            }
            else if (tcCashSales.SelectedIndex.Equals(2))
            {
                forSAPIP2 forsapip = new forSAPIP2("CASH", "for SAP IP");
                showForm(panelCSIP, forsapip);
            }
        }

        private void PendingOrder_Load(object sender, EventArgs e)
        {
            PendingOrder2 pendingOrder = new PendingOrder2("CASH", "for Payment");
            showForm(panelCSPayment, pendingOrder);
        }

        private void tcARSales_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tcARSales.SelectedIndex.Equals(1))
            {
                PendingOrder2 pendingOrder = new PendingOrder2("AR Sales", "for Payment");
                showForm(panelARSalesPayment, pendingOrder);
            }else if (tcARSales.SelectedIndex.Equals(0))
            {
                PendingOrder2 pendingOrder = new PendingOrder2("AR Sales", "for Confirmation");
                showForm(panelARSalesConfirmation, pendingOrder);
            }
            else if (tcARSales.SelectedIndex.Equals(2))
            {
                PendingOrder2 pendingOrder = new PendingOrder2("AR Sales", "for SAP");
                showForm(panelARSalesSAP, pendingOrder);
            }
            else if (tcARSales.SelectedIndex.Equals(3))
            {
                forSAPIP2 forsapip = new forSAPIP2("AR Sales", "for SAP IP");
                showForm(panelARSalesSAPIP, forsapip);
            }
        }

        private void tcAgentSales_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tcAgentSales.SelectedIndex.Equals(1))
            {
                PendingOrder2 pendingOrder = new PendingOrder2("Agent AR Sales", "for Payment");
                showForm(panelAgentSalesPayment, pendingOrder);
            }
            else if (tcAgentSales.SelectedIndex.Equals(0))
            {
                PendingOrder2 pendingOrder = new PendingOrder2("Agent AR Sales", "for Confirmation");
                showForm(panelAgentSalesConfirmation, pendingOrder);
            }
            else if (tcAgentSales.SelectedIndex.Equals(2))
            {
                PendingOrder2 pendingOrder = new PendingOrder2("Agent AR Sales", "for SAP");
                showForm(panelAgentSalesSAP, pendingOrder);
            }
            else if (tcAgentSales.SelectedIndex.Equals(3))
            {
                forSAPIP2 forsapip = new forSAPIP2("Agent AR Sales", "for SAP IP");
                showForm(panelAgentSalesSAPIP, forsapip);
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex.Equals(0))
            {
                tcCashSales.SelectedIndex = 0;
                PendingOrder2 pendingOrder = new PendingOrder2("CASH", "for Payment");
                showForm(panelCSPayment, pendingOrder);
            }
            else if (tabControl1.SelectedIndex.Equals(1))
            {
                tcARSales.SelectedIndex = 0;
                PendingOrder2 pendingOrder = new PendingOrder2("AR Sales", "for Confirmation");
                showForm(panelARSalesConfirmation, pendingOrder);
            }
            else if (tabControl1.SelectedIndex.Equals(2))
            {
                tcAgentSales.SelectedIndex = 0;
                PendingOrder2 pendingOrder = new PendingOrder2("Agent AR Sales", "for Confirmation");
                showForm(panelAgentSalesConfirmation, pendingOrder);
            }
            else if (tabControl1.SelectedIndex.Equals(3))
            {
                SalesPerCustomer salesCustomer = new SalesPerCustomer();
                showForm(panelPerCustomer, salesCustomer);
            }
            else if (tabControl1.SelectedIndex.Equals(4))
            {
                tcSOA.SelectedIndex = 0;
                ForSOA frm = new ForSOA();
                showForm(panelForSOA, frm);
            }
        }

        private void tabControl2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tcSOA.SelectedIndex.Equals(0))
            {
                ForSOA frm = new ForSOA();
                showForm(panelForSOA, frm);
            }
            else if (tcSOA.SelectedIndex.Equals(1))
            {
                SOA frm = new SOA("O");
                showForm(panelSOA, frm);
            }
            else if (tcSOA.SelectedIndex.Equals(2))
            {
                SOA frm = new SOA("C");
                showForm(panelClosedSOA, frm);
            }
        }
    }
}
