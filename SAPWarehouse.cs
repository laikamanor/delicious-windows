using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DeliciousPartnerApp.API_Class.Warehouse;
namespace DeliciousPartnerApp
{
    public partial class SAPWarehouse : Form
    {
        public SAPWarehouse()
        {
            InitializeComponent();
        }
        public static bool isSubmit = false;
        public static string warehouseCode = "";
        public static int sapNumber = 0;
        warehouse_class warehousec = new warehouse_class();
        DataTable dtWarehouse = new DataTable();
        private async void SAPWarehouse_Load(object sender, EventArgs e)
        {
            await loadWarehouse();
        }

        private void txtSAP_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        public async Task loadWarehouse()
        {
            cmbWarehouse.Items.Clear();
            dtWarehouse = await Task.Run(() => warehousec.returnWarehouse("", ""));
            foreach (DataRow row in dtWarehouse.Rows)
            {
                cmbWarehouse.Items.Add(row["whsename"]);
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSAP.Text.Trim()))
            {
                MessageBox.Show("SAP # field is required", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSAP.Focus();
            }
            else if (cmbWarehouse.Text.Equals(""))
            {
                MessageBox.Show("Warehouse field is required", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbWarehouse.Focus();
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure you want to submit?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    isSubmit = true;
                    sapNumber = Convert.ToInt32(txtSAP.Text.Trim());
                    warehouseCode = findWarehouseCode();
                    this.Hide();
                }
            }
        }

        public string findWarehouseCode()
        {
            string result = "";
            foreach (DataRow row in dtWarehouse.Rows)
            {
                if (row["whsename"].ToString() == cmbWarehouse.Text)
                {
                    result = row["whsecode"].ToString();
                    break;
                }
            }
            return result;
        }
    }
}
