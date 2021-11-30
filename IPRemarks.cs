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
    public partial class IPRemarks : Form
    {
        public IPRemarks()
        {
            InitializeComponent();
        }
        public static bool isSubmit = false;
        public static int sap_number = 0;
        public static string rem = "";
        private void IPRemarks_Load(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtSAP.Text.Trim()))
            {
                MessageBox.Show(label2.Text.Replace(":","").Replace("*","")  + "field is required", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure you want to submit?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    isSubmit = true;
                    sap_number = string.IsNullOrEmpty(txtSAP.Text.Trim()) ? 0 : Convert.ToInt32(txtSAP.Text.Trim());
                    rem = txtRemarks.Text.Trim();
                    this.Dispose();
                }
            }
        }
    }
}
