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
    public partial class SAP_RemarksDate : Form
    {
        public static int sap_number = 0;
        public static string rem = "";
        public static bool isSubmit = false;
        public static DateTime prodDate = new DateTime();
        public bool isOptional = false;
        public SAP_RemarksDate()
        {
            InitializeComponent();
        }

        private void SAP_RemarksDate_Load(object sender, EventArgs e)
        {
            dtProdDate.Value = DateTime.Now;
            label2.Text = isOptional ? "SAP #:" : "*SAP #:";
            this.Text = isOptional ? "Enter SAP # (Optional) & Remarks" : "Enter SAP # & Remarks";
            isSubmit = false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (!isOptional)
            {
                if (string.IsNullOrEmpty(txtSAP.Text.Trim()) || !isOptional)
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
                        prodDate = dtProdDate.Value;
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
                    prodDate = dtProdDate.Value;
                    rem = txtRemarks.Text.Trim();
                    this.Dispose();
                }
            }
        }
    }
}
