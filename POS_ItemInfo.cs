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
    public partial class POS_ItemInfo : Form
    {
        public POS_ItemInfo()
        {
            InitializeComponent();
        }

        private void POS_ItemInfo_Load(object sender, EventArgs e)
        {
            txtQuantity.Focus();
        }

        private void txtQuantity_KeyPress(object sender, KeyPressEventArgs e)
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

        private void btnMinus_Click(object sender, EventArgs e)
        {
            plusMinus("-");
        }

        public void plusMinus(string arithmethic)
        {
            double qty = Double.Parse(txtQuantity.Text.Trim());
            if(arithmethic == "+")
            {
                qty += 1;
            }else if(arithmethic == "-" && qty > 0)
            {
                qty -= 1;
            }
            txtQuantity.Text = qty.ToString("n2");
            txtQuantity.SelectionLength = txtQuantity.TextLength;
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            plusMinus("+");
        }
    }
}
