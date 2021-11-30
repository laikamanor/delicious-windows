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
    public partial class PendingOrder_SAPAR : Form
    {
        public PendingOrder_SAPAR(string salesType, string forType)
        {
            gSalesType = salesType;
            gForType = forType;
            InitializeComponent();
        }
        string gSalesType = "", gForType = "";

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string status = tabControl1.SelectedIndex <= 0 ? "Open" : "Close";

            if (status.Equals("Close"))
            {
                SAPARDone pendingOrder = new SAPARDone(gSalesType, gForType, status);
                showForm(panelClose, pendingOrder);
                //PendingOrder2 pendingOrder = new PendingOrder2(gSalesType, gForType, status);
                //showForm(panelClose, pendingOrder);
            }
            else
            {

                Sales pendingOrder = new Sales(gSalesType, gForType);
                showForm(panelOpen, pendingOrder);

                //PendingOrder2 pendingOrder = new PendingOrder2(gSalesType, gForType, status);
                //showForm(panelOpen, pendingOrder);
            }

        }

        public void showForm(Panel panel, Form form)
        {
            panel.Controls.Clear();
            form.TopLevel = false;
            panel.Controls.Add(form);
            form.BringToFront();
            form.Show();
        }

        private void PendingOrder_SAPAR_Load(object sender, EventArgs e)
        {
            Sales pendingOrder = new Sales(gSalesType, gForType);
            showForm(panelOpen, pendingOrder);
        }
    }
}
