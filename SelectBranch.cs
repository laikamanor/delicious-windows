using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DeliciousPartnerApp.API_Class.Customer_Type;
using DeliciousPartnerApp.API_Class.Customer;
namespace DeliciousPartnerApp
{
    public partial class SelectBranch : Form
    {
        public SelectBranch(string type)
        {
            InitializeComponent();
            gType = type;
        }
        customertype_class customerctypec = new customertype_class();
        customer_class customerc = new customer_class();
        public DataTable dt = new DataTable();
        public DataTable dtSelected = new DataTable();
        DataTable dtCustomerType = new DataTable();
        int cCustType = 1;
        string gType = "";
        private void SelectBranch_Load(object sender, EventArgs e)
        {
            loadData();
            if (gType.Equals("Customer"))
            {
                loadCustomerType();
                if(dtSelected.Rows.Count > 0)
                {
                    DataRow row = dtSelected.Rows[0];
                    int isAll = 0, intTemp = 0;
                    isAll = Int32.TryParse(row["isAll"].ToString() , out intTemp) ? Convert.ToInt32(row["isAll"].ToString()) : intTemp;
                    checkSelectAll.Checked = isAll > 0 ? true : false;
                }
                label15.Visible = true;
                cmbCustomerType.Visible = true;
            }
            else
            {
                label15.Visible = false;
                cmbCustomerType.Visible = false;
            }
            cCustType = 0;
        }

        public void loadCustomerType()
        {
            cmbCustomerType.Items.Clear();
            dtCustomerType = customerctypec.loadCustomerTypes();
            if (dtCustomerType.Rows.Count > 0)
            {
                cmbCustomerType.Items.Add("All");
                foreach (DataRow row in dtCustomerType.Rows)
                {
                    cmbCustomerType.Items.Add(row["code"].ToString());
                }
                cmbCustomerType.SelectedIndex = 0;
            }
        }

        public void loadData()
        {
            dgv.Rows.Clear();

            if (gType.Equals("Customer"))
            {
                int custTypeID = 0, intTemp = 0;
                string sCustType = "";
                foreach(DataRow row in dtCustomerType.Rows)
                {
                    if(row["code"].ToString() == cmbCustomerType.Text)
                    {
                        custTypeID = Int32.TryParse(row["id"].ToString(), out intTemp) ? Convert.ToInt32(row["id"].ToString()) : intTemp;
                        break;
                    }
                }
                sCustType = custTypeID > 0 ? "?cust_type=" + custTypeID : "";

                dt = customerc.loadCustomers(sCustType);
            }

            AutoCompleteStringCollection auto = new AutoCompleteStringCollection();
            string columnName = gType.Equals("Customer") ? "code" : "branch";
            foreach (DataRow row in dt.Rows)
            {
                auto.Add(row["name"].ToString());
                DataRow[] foundBranch = dtSelected.Select(columnName + " = '" + row["code"].ToString() + "'");
                if (!string.IsNullOrEmpty(txtSearch.Text.ToString().Trim()))
                {
                    if (txtSearch.Text.ToString().Trim().ToLower().Contains(row["name"].ToString().ToLower()))
                    {

                        dgv.Rows.Add(foundBranch.Length <= 0 ? false : true, row["code"].ToString(), row["name"].ToString());
                    }
                }
                else
                {
                    dgv.Rows.Add(foundBranch.Length <= 0 ? false : true, row["code"].ToString(), row["name"].ToString());
                }
            }
            txtSearch.AutoCompleteCustomSource = auto;
        }
    
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            dtSelected.Rows.Clear();

            if (gType.Equals("Customer"))
            {
                int dtCount = 0, custTypeID = 0, intTemp = 0;
                for (int i = 0; i < dgv.Rows.Count; i++)
                {
                    if (Convert.ToBoolean(dgv.Rows[i].Cells["selectt"].Value.ToString()))
                    {
                        dtCount += 1;
                    }
                }
                foreach (DataRow row in dtCustomerType.Rows)
                {
                    if (row["code"].ToString() == cmbCustomerType.Text)
                    {
                        custTypeID = Int32.TryParse(row["id"].ToString(), out intTemp) ? Convert.ToInt32(row["id"].ToString()) : intTemp;
                        break;
                    }
                }

                int isAll = dtCount == dt.Rows.Count ? 1 : 0;
                for (int i = 0; i < dgv.Rows.Count; i++)
                {
                    if (Convert.ToBoolean(dgv.Rows[i].Cells["selectt"].Value.ToString()))
                    {
                        dtSelected.Rows.Add(dgv.Rows[i].Cells["code"].Value.ToString(), isAll, custTypeID);
                    }
                }
                string columnName = gType.Equals("Customer") ? "code" : "branch";
                dtSelected.DefaultView.Sort = columnName + " ASC";
                dtSelected = dtSelected.DefaultView.ToTable();


                salesAmountSummaryReport_customer.dtSelectedCustomer = dtSelected;
                this.Close();
            }
            else
            {

                for (int i = 0; i < dgv.Rows.Count; i++)
                {
                    if (Convert.ToBoolean(dgv.Rows[i].Cells["selectt"].Value.ToString()))
                    {
                        dtSelected.Rows.Add(dgv.Rows[i].Cells["code"].Value.ToString(), dgv.Rows[i].Cells["name"].Value.ToString());
                    }
                }

                string columnName = gType.Equals("Customer") ? "code" : "branch";
                dtSelected.DefaultView.Sort = columnName + " ASC";
                dtSelected = dtSelected.DefaultView.ToTable();


                salesAmountSummaryReport.dtSelectedBranches = dtSelected;
                this.Close();
            }
        }


        private void dgv_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            dgv.CommitEdit(DataGridViewDataErrorContexts.Commit);
            //dgv.CurrentRow.Cells["branch"].Style.BackColor = foundBranch.Length <= 0 ? Color.Yellow : Color.White;
        }

        private void checkSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                dgv.Rows[i].Cells["selectt"].Value = checkSelectAll.Checked;
            }
        }

        private void btnSearch_Click_1(object sender, EventArgs e)
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

        private void cmbCustomerType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cCustType <= 0)
            {
                checkSelectAll.Checked = false;
                loadData();
            }
        }
    }
}
