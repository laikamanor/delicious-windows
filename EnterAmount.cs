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
    public partial class EnterAmount : Form
    {
        public EnterAmount()
        {
            InitializeComponent();
        }
        public string reference = "";
        public static double amount = 0.00;
        private void EnterAmount_Load(object sender, EventArgs e)
        {
            lblReference.Text = reference;
            txtAmount.Text = amount.ToString();
            txtAmount.Focus();
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

        private void txtAmount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                btnSubmit.PerformClick();
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtAmount.Text))
            {
                MessageBox.Show("Amount field is required", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                amount = Convert.ToDouble(txtAmount.Text.Trim());
                txtAmount.Text = "0.00";
                this.Dispose();
            }
        }
    }
}
