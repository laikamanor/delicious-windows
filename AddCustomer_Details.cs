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
    public partial class AddCustomer_Details : Form
    {
        public AddCustomer_Details()
        {
            InitializeComponent();
        }
        public static bool isSubmit=false;
        public static string firstName = "",
            middleName = "", lastName = "", landlineNo = "", mobileNo = "", email = "", address = "", birthDate = "";
        int cBday = 0;
        private void dtBirthDate_ValueChanged(object sender, EventArgs e)
        {
            cBday += 1;
        }

        private void txtLandlineNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        public bool checkEmail()
        {
            bool isEmailValid = false;
            try
            {
                isEmailValid = true;
                var eMailValidator = new System.Net.Mail.MailAddress(txtEmail.Text);
            }
            catch
            {
                isEmailValid = false;
                // wrong e-mail address
            }
            return isEmailValid;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txtFirstName.Text.Trim()))
            {
                MessageBox.Show("First Name field is required", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtFirstName.Focus();
            }
            else if (string.IsNullOrEmpty(txtLastName.Text.Trim()))
            {
                MessageBox.Show("Last Name field is required", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLastName.Focus();
            }
            else if (string.IsNullOrEmpty(txtLandlineNo.Text.Trim()))
            {
                MessageBox.Show("Landline No field is required", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLandlineNo.Focus();
            }
            else if (string.IsNullOrEmpty(txtMobileNo.Text.Trim()))
            {
                MessageBox.Show("Mobile No field is required", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMobileNo.Focus();
            }
            else
            {
                isSubmit = true;
                firstName = txtFirstName.Text.Trim();
                middleName = txtMiddleInitial.Text.Trim();
                lastName = txtLastName.Text.Trim();
                
                landlineNo = txtLandlineNo.Text.Trim();
                mobileNo = txtMobileNo.Text.Trim();

                birthDate = cBday > 0 ? dtBirthDate.Value.ToString("yyyy-MM-dd") : "";
                email = txtEmail.Text.Trim();
                address = txtAddress.Text.Trim();
                this.Dispose();
            }
        }

        private void AddCustomer_Details_Load(object sender, EventArgs e)
        {
            isSubmit = false;   
        }
    }
}
