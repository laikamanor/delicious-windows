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
    public partial class ItemInfo : Form
    {
        public string itemCode = "", uom = "";
        public static bool isSubmit = false;    
        public ItemInfo()
        {
            InitializeComponent();
        }

        private void btnAddCart_Click(object sender, EventArgs e)
        {
            bool isNotExist = false;
            foreach (DataRow row in AddAdjustmentIn.dtSelectedItems.Rows)
            {
                if (row["item_code"].ToString() == itemCode)
                {
                    isNotExist = true;
                    break;
                }
            }
            if (AddAdjustmentIn.dtSelectedItems.Rows.Count <= 0)
            {
                AddAdjustmentIn.dtSelectedItems.Rows.Add(itemCode, txtQuantity.Text, uom);
                isSubmit = true;
                this.Hide();
            }
            else if (!isNotExist)
            {
                AddAdjustmentIn.dtSelectedItems.Rows.Add(itemCode, txtQuantity.Text, uom);
                isSubmit = true;
                this.Hide();
            }
            else
            {
                MessageBox.Show(itemCode + " is already selected", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtQuantity.Text))
            {
                txtQuantity.Text = "0";
            }
            else if (Convert.ToInt32(txtQuantity.Text) <= 0)
            {
                txtQuantity.Text = "0";
            }
            else
            {
                int qty = Convert.ToInt32(txtQuantity.Text);
                qty -= 1;
                txtQuantity.Text = qty.ToString("N0");
            }
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtQuantity.Text))
            {
                txtQuantity.Text = "0";
            }
            else
            {
                int qty = Convert.ToInt32(txtQuantity.Text);
                qty += 1;
                txtQuantity.Text = qty.ToString("N0");
            }
        }

        private void txtQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void ItemInfo_Load(object sender, EventArgs e)
        {
            isSubmit = false;
            lblItem.Text = itemCode;
            txtQuantity.Text = "0";
        }
    }
}
