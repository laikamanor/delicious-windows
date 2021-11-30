using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DeliciousPartnerApp.UI_Class;
using System.Diagnostics;

namespace DeliciousPartnerApp
{
    public partial class linkPassword : Form
    {
        public linkPassword()
        {
            InitializeComponent();
        }
        utility_class utilityc = new utility_class();
        public static bool isSubmit = false;
        private void txtPin_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtPin.Text.Trim()))
            {
                MessageBox.Show("PIN field is required", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPin.Focus();
            }
            else if(txtPin.Text.Trim() != "010203")
            {
                MessageBox.Show("PIN is wrong", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPin.Focus();
            }
            else
            {
                isSubmit = true;
                this.Hide();
            }
        }

        private void txtPin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                btnSubmit.PerformClick();
            }
        }

        private void linkPassword_Load(object sender, EventArgs e)
        {
            txtPin.Focus();
        }
    }
}
