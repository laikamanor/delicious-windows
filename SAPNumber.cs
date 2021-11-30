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
    public partial class SAPNumber : Form
    {
        public static int sap_number = 0;
        public static bool isSubmit=false;
        public SAPNumber()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
           try
            {
                if (String.IsNullOrEmpty(txtSAP.Text.Trim()))
                {
                    MessageBox.Show("SAP # field is required", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    DialogResult dialogResult = MessageBox.Show("Are you sure you want to submit?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialogResult == DialogResult.Yes)
                    {
                        isSubmit = true;
                        sap_number = Convert.ToInt32(txtSAP.Text.Trim());
                        this.Dispose();
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void SAPNumber_Load(object sender, EventArgs e)
        {
            isSubmit = false;
        }

        private void txtSAP_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
