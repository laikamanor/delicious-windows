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
    public partial class SOATab : Form
    {
        public SOATab()
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

        private void tcSOA_SelectedIndexChanged(object sender, EventArgs e)
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

        private void SOATab_Load(object sender, EventArgs e)
        {
            ForSOA frm = new ForSOA();
            showForm(panelForSOA, frm);
        }
    }
}
