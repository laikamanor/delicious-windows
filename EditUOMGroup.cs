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
    public partial class EditUOMGroup : Form
    {
        public EditUOMGroup()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtQty.Text.Trim()))
            {
                MessageBox.Show("Alt Quantity field is required", "Valdation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (Convert.ToDouble(txtQty.Text.Trim()) <= 0)
            {
                MessageBox.Show("Quantity atleast 1", "Valdation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (string.IsNullOrEmpty(cmbUOM.Text.Trim()))
            {
                MessageBox.Show("UOM field is required", "Valdation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {

            }
        }

        private void EditUOMGroup_Load(object sender, EventArgs e)
        {

        }
    }
}
