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
    public partial class AdvancePayment : Form
    {
        public AdvancePayment()
        {
            InitializeComponent();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex.Equals(0))
            {
                AdvancePayment2 advancePayment2 = new AdvancePayment2("In Deposit");
                showForm(panelInDeposit, advancePayment2);
            }
            else if (tabControl1.SelectedIndex.Equals(1))
            {
                AdvancePayment2 advancePayment2 = new AdvancePayment2("Used Deposit");
                showForm(panelUsedDeposit, advancePayment2);
            }
            else if (tabControl1.SelectedIndex.Equals(2))
            {
                AdvancePayment2 advancePayment2 = new AdvancePayment2("Summary Deposit");
                showForm(panelSummaryDeposit, advancePayment2);
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

        private void AdvancePayment_Load(object sender, EventArgs e)
        {
            AdvancePayment2 advancePayment2 = new AdvancePayment2("In Deposit");
            showForm(panelInDeposit, advancePayment2);
        }
    }
}
