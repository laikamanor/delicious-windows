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
    public partial class AmountRemaks : Form
    {
        public AmountRemaks()
        {
            InitializeComponent();
        }
        public static bool isSubmit = false;
        public static string remarks = "";
        public static double amount = 0.00;
        private void AmountRemaks_Load(object sender, EventArgs e)
        {
            isSubmit = false;
            txtAmount.Text = "";
            txtRemarks.Text = "";
            txtAmount.Focus();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtAmount.Text.Trim()))
            {
                MessageBox.Show("Amount field is required", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (string.IsNullOrEmpty(txtRemarks.Text.Trim()))
            {
                MessageBox.Show("Remarks field is required", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                isSubmit = true;
                amount = string.IsNullOrEmpty(txtAmount.Text.Trim()) ? 0.00 : Convert.ToDouble(txtAmount.Text.Trim());
                remarks = txtRemarks.Text.Trim();
                this.Dispose();
            }
        }

        private void txtAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)
&& !char.IsDigit(e.KeyChar)
&& e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if (e.KeyChar == '.'
                && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }
    }
}
