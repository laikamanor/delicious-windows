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
    public partial class Remarks : Form
    {
        public static string rem = "";
        public static bool isSubmit = false;
        public Remarks()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtRemarks.Text))
            {
                MessageBox.Show("Remarks field is required", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure you want to submit?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    rem = txtRemarks.Text.Trim();
                    isSubmit = true;
                    this.Dispose();
                }
            }
        }

        private void txtRemarks_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                btnCancel.PerformClick();
            }
        }

        private void Remarks_Load(object sender, EventArgs e)
        {
            isSubmit = false;
        }
    }
}
