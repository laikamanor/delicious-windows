using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DeliciousPartnerApp.UI_Class;
using DeliciousPartnerApp.API_Class.Pricelist;
namespace DeliciousPartnerApp
{
    public partial class PriceList : Form
    {
        public PriceList()
        {
            InitializeComponent();
        }
        utility_class utilityc = new utility_class();
        pricelist_class pricelistc = new pricelist_class();
        private void PriceList_Load(object sender, EventArgs e)
        {
            loadData();
        }

        public void loadData()
        {
            DataTable dt = pricelistc.loadData();
            if(dt.Columns.Count > 0 && dt.Rows.Count > 0)
            {
                dgv.Rows.Clear();
                foreach(DataRow row in dt.Rows)
                {
                    dgv.Rows.Add(Convert.ToInt32(row["id"].ToString()), row["code"].ToString(), row["description"].ToString());
                }
            }
        }

       

        private void btnSearch_Click(object sender, EventArgs e)
        {
            loadData();
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                loadData();
            }
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            AddPriceList add = new AddPriceList();
            add.ShowDialog();
            if (AddPriceList.isSubmit)
            {
                loadData();
            }
        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dgv.Rows.Count > 0)
            {
                if(e.RowIndex >=0)
                {
                    PriceList_Row row = new PriceList_Row();
                    row.selectedID = string.IsNullOrEmpty(dgv.CurrentRow.Cells["id"].Value.ToString()) ? 0 : Convert.ToInt32(dgv.CurrentRow.Cells["id"].Value.ToString());
                    row.lblPriceList.Text = dgv.CurrentRow.Cells["description"].Value.ToString();
                    row.ShowDialog();
                }
            }
        }
    }
}
