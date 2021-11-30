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
    public partial class AdjustmentIn : Form
    {
        string gAdjType = "";
        public AdjustmentIn(string adjType)
        {
            InitializeComponent();
            gAdjType = adjType;
        }
        public void showForm(Panel panel, Form form)
        {
            panel.Controls.Clear();
            form.TopLevel = false;
            panel.Controls.Add(form);
            form.BringToFront();
            form.Show();
        }

        private void AdjustmentIn_Load(object sender, EventArgs e)
        {
            this.Text = gAdjType.Equals("in") ? "Adjusment In" : "Adjustment Out";
            AdjustmentIn2 adIn = new AdjustmentIn2(gAdjType, "For SAP");
            showForm(panelForSAP, adIn);
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex.Equals(0))
            {
                AdjustmentIn2 adIn = new AdjustmentIn2(gAdjType, "For SAP");
                showForm(panelForSAP, adIn);
            }
            else if (tabControl1.SelectedIndex.Equals(1))
            {
                AdjustmentIn2 adIn = new AdjustmentIn2(gAdjType, "Done");
                showForm(panelDone, adIn);
            }
        }
    }
}
