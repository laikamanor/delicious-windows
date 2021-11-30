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
    public partial class IssueForProduction : Form
    {
        public IssueForProduction()
        {
            InitializeComponent();
        }

        private void IssueForProduction_Load(object sender, EventArgs e)
        {
            Production_IssueProduction frm = new Production_IssueProduction("Issue for Production Order");
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
                Production_IssueProduction frm = new Production_IssueProduction("Issue for Production Order");
                showForm(panelIssueProdOrder, frm);
            }
            else if (tcProd.SelectedIndex.Equals(1))
            {
                Production_IssueProduction frm = new Production_IssueProduction("For SAP");
                showForm(panelForSAP, frm);
            }
        }
    }
}
