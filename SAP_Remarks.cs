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
    public partial class SAP_Remarks : Form
    {
        public static int sap_number = 0;
        public static string rem = "";
        public static bool isSubmit = false;
        public bool isOptional = false;
        public SAP_Remarks()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (!isOptional)
            {
                if (string.IsNullOrEmpty(txtSAP.Text.Trim()))
                {
                    MessageBox.Show("SAP # field is required", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (string.IsNullOrEmpty(txtRemarks.Text.Trim()))
                {
                    MessageBox.Show("Remarks field is required", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void txtSAP_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void SAP_Remarks_Load(object sender, EventArgs e)
        {
            label2.Text = isOptional ? "SAP #:" : "*SAP #:";
            label1.Text = isOptional ? "Remarks:" : "*Remarks";
            this.Text = isOptional ? "Enter SAP # & Remarks (Optional)" : "Enter SAP # & Remarks";
            isSubmit = false;
        }
    }
}
