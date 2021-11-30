using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DeliciousPartnerApp.API_Class.Branch;
using DeliciousPartnerApp.API_Class.Warehouse;
namespace DeliciousPartnerApp
{
    public partial class Warehouse : Form
    {
        public Warehouse()
        {
            InitializeComponent();
        }
        DataTable dtBranches = new DataTable(), dtWarehouse = new DataTable();
        branch_class branchc = new branch_class();
        warehouse_class warehousec = new warehouse_class();
        int cBranch = 1;
        private async void Warehouse_Load(object sender, EventArgs e)
        {
            dtBranches = new DataTable();
            dtWarehouse = new DataTable();
            loadBranches();
            await loadData();
            cBranch = 0;
        }

        public async void loadBranches()
        {
            dtBranches = await Task.Run(() => branchc.returnBranches());
            cmbBranches.Items.Clear();
            cmbBranches.Items.Add("All");
            foreach (DataRow row in dtBranches.Rows)
            {
                cmbBranches.Items.Add(row["name"].ToString());
            }
            cmbBranches.SelectedIndex = 0;
        }

        public string findCode(string value, string typee)
        {
            string result = "";
            if (typee.Equals("Warehouse"))
            {
                foreach (DataRow row in dtWarehouse.Rows)
                {
                    if (row["whsename"].ToString() == value)
                    {
                        result = row["whsecode"].ToString();
                        break;
                    }
                }
            }
            else
            {
                foreach (DataRow row in dtBranches.Rows)
                {
                    if (row["name"].ToString() == value)
                    {
                        result = row["code"].ToString();
                        break;
                    }
                }
            }
            return result;
        }

        private async void cmbBranches_SelectedValueChanged(object sender, EventArgs e)
        {
            if(cBranch <= 0)
            {
                await loadData();
            }
        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv.Rows.Count > 0)
            {
                if (e.RowIndex >= 0)
                {
                    if (e.ColumnIndex == 9)
                    {
                        PriceList_Row row = new PriceList_Row();
                        row.selectedID = string.IsNullOrEmpty(dgv.CurrentRow.Cells["pricelist_id"].Value.ToString()) ? 0 : Convert.ToInt32(dgv.CurrentRow.Cells["pricelist_id"].Value.ToString());
                        row.lblPriceList.Text = dgv.CurrentRow.Cells["pricelist"].Value.ToString();
                        row.ShowDialog();
                    }
                    else if (e.ColumnIndex == 10)
                    {
                        int intTemp = 0;
                        EditWarehouse frm = new EditWarehouse();
                        frm.selectedID = Int32.TryParse(dgv.CurrentRow.Cells["id"].Value.ToString(), out intTemp) ? Convert.ToInt32(dgv.CurrentRow.Cells["id"].Value.ToString()) : intTemp;
                        frm.ShowDialog();
                    }
                }

            }
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            AddWarehouse add = new AddWarehouse();
            add.ShowDialog();
            if (AddWarehouse.isSubmit)
            {
                await loadData();
            }
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            await loadData();
        }

        private async void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                await loadData();
            }
        }

        private void cmbBranches_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public async Task loadData()
        {
            string branchCode = findCode(cmbBranches.Text, "Branch");
            dtWarehouse = await Task.Run(() => warehousec.returnWarehouse(branchCode, ""));
            AutoCompleteStringCollection auto = new AutoCompleteStringCollection();
            dgv.Rows.Clear();
            foreach (DataRow row in dtWarehouse.Rows)
            {
                auto.Add(row["whsename"].ToString());

                if (!string.IsNullOrEmpty(txtSearch.Text.ToString().Trim()))
                {
                    if (txtSearch.Text.ToString().Trim().ToLower().Contains(row["whsename"].ToString().ToLower()))
                    {
                        dgv.Rows.Add(row["id"].ToString(), row["pricelist"].ToString(), row["pricelist_id"].ToString(), row["branch"].ToString(), row["whsecode"].ToString(), row["whsename"].ToString(), row["cash_account"].ToString(), row["short_account"].ToString(), row["pullout_whse"].ToString());
                    }
                }
                else
                {
                    dgv.Rows.Add(row["id"].ToString(), row["pricelist"].ToString(), row["pricelist_id"].ToString(), row["branch"].ToString(), row["whsecode"].ToString(), row["whsename"].ToString(), row["cash_account"].ToString(), row["short_account"].ToString(), row["pullout_whse"].ToString());
                }
            }
            txtSearch.AutoCompleteCustomSource = auto;
        }

    }
}
