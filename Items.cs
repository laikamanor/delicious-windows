using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DeliciousPartnerApp.UI_Class;
using DeliciousPartnerApp.API_Class.Items;
namespace DeliciousPartnerApp
{
    public partial class Items : Form
    {
        public Items()
        {
            InitializeComponent();
        }
        utility_class utilityc = new utility_class();
        item_class itemc = new item_class();
        private  void Items_Load(object sender, EventArgs e)
        {
             loadData();
        }

        public  void loadData()
        {
            try
            {
                dgv.Rows.Clear();
                AutoCompleteStringCollection auto = new AutoCompleteStringCollection();
                DataTable dt = itemc.loadData();
                if(dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    if (row["success"].ToString() == "True")
                    {
                        foreach (DataRow row1 in dt.Rows)
                        {
                            auto.Add(row1["item_code"].ToString());
                            if (!string.IsNullOrEmpty(txtSearch.Text.ToString().Trim()))
                            {
                                if (txtSearch.Text.ToString().Trim().ToLower().Contains(row1["item_code"].ToString().ToLower()))
                                {
                                    dgv.Invoke(new Action(delegate ()
                                    {
                                        dgv.Rows.Add(row1["id"].ToString(), row1["item_code"].ToString(), row1["item_name"].ToString(), row1["uom"].ToString(), row1["item_group"].ToString(), row1["price"].ToString());
                                    }));
                                }
                            }
                            else
                            {
                                dgv.Invoke(new Action(delegate ()
                                {
                                    dgv.Rows.Add(row1["id"].ToString(), row1["item_code"].ToString(), row1["item_name"].ToString(), row1["uom"].ToString(), row1["item_group"].ToString(), row1["price"].ToString());
                                }));
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show(row["message"].ToString());
                    }
                }
                txtSearch.AutoCompleteCustomSource = auto;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private  void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                loadData();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            loadData();
        }

        private  void btnAddItem_Click(object sender, EventArgs e)
        {
            AddItem addItem = new AddItem();
            addItem.ShowDialog();
            if (AddItem.isSubmit)
            {
                loadData();
            }
        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dgv.Rows.Count > 0)
            {
                if (e.ColumnIndex == 6)
                {
                    if(e.RowIndex >= 0)
                    {
                        Barcodee frm = new Barcodee();
                        frm.ShowDialog();
                    }
                }
            }
        }

        private void Items_Activated(object sender, EventArgs e)
        {
        }
    }
}
