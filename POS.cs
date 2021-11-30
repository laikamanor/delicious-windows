using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DeliciousPartnerApp.API_Class.POS;
namespace DeliciousPartnerApp
{
    public partial class POS : Form
    {
        public POS()
        {
            InitializeComponent();
        }
        sales_class salesc = new sales_class();
        int cItemGroup = 1, cDtItemGroup = 1;
        DataTable dtItemGroups = new DataTable();
        DataTable dt;
        private void POS_Load(object sender, EventArgs e)
        {
            dt = new DataTable();
            dtItemGroups.Columns.Add("code");
            loadInventory();
            dgv.Columns["stock"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv.Columns["price"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            cDtItemGroup = 0;
            cItemGroup = 0;
        }

        public void loadInventory()
        {
            Cursor.Current = Cursors.WaitCursor;
            dgv.Rows.Clear();
            dt = dt.Rows.Count > 0 ? dt : salesc.loadInventoryStock();
            AutoCompleteStringCollection auto = new AutoCompleteStringCollection();
            if(dt.Rows.Count > 0)
            {
                foreach(DataRow row in dt.Rows)
                {
                    dtItemGroups.Rows.Add(row["item_group"].ToString());

                    if (!string.IsNullOrEmpty(txtSearch.Text.ToString().Trim()))
                    {
                        if (txtSearch.Text.ToString().Trim().ToLower().Contains(row["item_code"].ToString().ToLower()))
                        {
                            if (checkHaveQty.Checked)
                            {
                                if (cmbItemGroup.Text != "All" && cmbItemGroup.Text != "")
                                {
                                    if (Convert.ToDouble(row["quantity"].ToString()) > 0 && cmbItemGroup.Text == row["item_group"].ToString())
                                    {
                                        auto.Add(row["item_code"].ToString());
                                        dgv.Rows.Add(row["item_code"].ToString(), Convert.ToDecimal(string.Format("{0:0.00}", row["quantity"].ToString())), row["uom"].ToString(), Convert.ToDecimal(string.Format("{0:0.00}", row["price"].ToString())), row["item_group"].ToString());
                                    }
                                }
                                else
                                {
                                    if (Convert.ToDouble(row["quantity"].ToString()) > 0)
                                    {
                                        auto.Add(row["item_code"].ToString());
                                        dgv.Rows.Add(row["item_code"].ToString(), Convert.ToDecimal(string.Format("{0:0.00}", row["quantity"].ToString())), row["uom"].ToString(), Convert.ToDecimal(string.Format("{0:0.00}", row["price"].ToString())), row["item_group"].ToString());
                                    }
                                }
                            }
                            else
                            {
                                auto.Add(row["item_code"].ToString());
                                dgv.Rows.Add(row["item_code"].ToString(), Convert.ToDecimal(string.Format("{0:0.00}", row["quantity"].ToString())), row["uom"].ToString(), Convert.ToDecimal(string.Format("{0:0.00}", row["price"].ToString())), row["item_group"].ToString());
                            }
                        }
                    }
                    else
                    {
                        if (checkHaveQty.Checked)
                        {
                            if (cmbItemGroup.Text != "All" && cmbItemGroup.Text != "")
                            {
                                if (Convert.ToDouble(row["quantity"].ToString()) > 0 && cmbItemGroup.Text == row["item_group"].ToString())
                                {
                                    auto.Add(row["item_code"].ToString());
                                    dgv.Rows.Add(row["item_code"].ToString(), Convert.ToDecimal(string.Format("{0:0.00}", row["quantity"].ToString())), row["uom"].ToString(), Convert.ToDecimal(string.Format("{0:0.00}", row["price"].ToString())), row["item_group"].ToString());
                                }
                            }
                            else
                            {
                                if (Convert.ToDouble(row["quantity"].ToString()) > 0)
                                {
                                    auto.Add(row["item_code"].ToString());
                                    dgv.Rows.Add(row["item_code"].ToString(), Convert.ToDecimal(string.Format("{0:0.00}", row["quantity"].ToString())), row["uom"].ToString(), Convert.ToDecimal(string.Format("{0:0.00}", row["price"].ToString())), row["item_group"].ToString());
                                }
                            }
                        }
                        else if (cmbItemGroup.Text != "All" && cmbItemGroup.Text != "")
                        {
                            if (cmbItemGroup.Text == row["item_group"].ToString())
                            {
                                auto.Add(row["item_code"].ToString());
                                dgv.Rows.Add(row["item_code"].ToString(), Convert.ToDecimal(string.Format("{0:0.00}", row["quantity"].ToString())), row["uom"].ToString(), Convert.ToDecimal(string.Format("{0:0.00}", row["price"].ToString())), row["item_group"].ToString());
                            }

                        }
                        else
                        {
                            auto.Add(row["item_code"].ToString());
                            dgv.Rows.Add(row["item_code"].ToString(), Convert.ToDecimal(string.Format("{0:0.00}", row["quantity"].ToString())), row["uom"].ToString(), Convert.ToDecimal(string.Format("{0:0.00}", row["price"].ToString())), row["item_group"].ToString());
                        }
                    }
                }
            }
            if(cDtItemGroup > 0)
            {
                cmbItemGroup.Items.Clear(); 
                if (dtItemGroups.Rows.Count > 0)
                {
                    cmbItemGroup.Items.Add("All");
                }
                DataView view = new DataView(dtItemGroups);
                DataTable distinctValues = view.ToTable(true, "code");
                foreach (DataRow row in distinctValues.Rows)
                {
                    cmbItemGroup.Items.Add(row["code"].ToString());
                }
                if (cmbItemGroup.Items.Count > 0)
                {
                    cmbItemGroup.SelectedIndex = 0;
                }
            }

            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                double quantity = string.IsNullOrEmpty(dgv.Rows[i].Cells["stock"].Value.ToString()) ? 0.00 : Convert.ToDouble(dgv.Rows[i].Cells["stock"].Value.ToString());
                if(quantity <=0.00)
                {
                    dgv.Rows[i].Cells["stock"].Style.ForeColor = Color.Red;
                }else if(quantity <= 10)
                {
                    dgv.Rows[i].Cells["stock"].Style.ForeColor = Color.FromArgb(250, 117, 0);
                }
            }

            txtSearch.AutoCompleteCustomSource = auto;
            Cursor.Current = Cursors.Default;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            dt = new DataTable();
            loadInventory();
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                loadInventory();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            loadInventory();
        }

        private void checkHaveQty_CheckedChanged(object sender, EventArgs e)
        {
            loadInventory();
        }

        private void POS_MaximumSizeChanged(object sender, EventArgs e)
        {
            //this.Refresh();
        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dgv.Rows.Count > 0)
            {
                if(e.ColumnIndex==0 && e.RowIndex >= 0)
                {
                    POS_ItemInfo frm = new POS_ItemInfo();
                    frm.ShowDialog();
                }
            }
        }

        private void cmbItemGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cItemGroup <= 0)
            {
                loadInventory();
            }
        }
    }
}
