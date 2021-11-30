using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DeliciousPartnerApp.API_Class.SOA;
namespace DeliciousPartnerApp
{
    public partial class SOA : Form
    {
        public SOA(string docStatus)
        {
            InitializeComponent();
            gDocStatus = docStatus;
        }
        string gDocStatus = "";
        soa_class soac = new soa_class();
        DataTable dtSOA = new DataTable();
        int cDate = 1, cToDate = 1;
        public async Task loadSOA()
        {
            string fromDate = checkDate.Checked ? "&from_date=" + dtFromDate.Value.ToString("yyyy-MM-dd") : "&from_date=",
                toDate = checkToDate.Checked ? "&to_date=" + dtToDate.Value.ToString("yyyy-MM-dd") : "&to_date=";
            dtSOA = await Task.Run(() => soac.getSOA(gDocStatus, fromDate+toDate));
            AutoCompleteStringCollection auto = new AutoCompleteStringCollection();
            dgv.Rows.Clear();
            if (dtSOA.Rows.Count > 0)
            {
                foreach (DataRow row in dtSOA.Rows)
                {
                    auto.Add(row["cust_code"].ToString());
                    if (!string.IsNullOrEmpty(txtSearch.Text.ToString().Trim()))
                    {
                        if (txtSearch.Text.ToString().Trim().ToLower().Contains(row["cust_code"].ToString().ToLower()))
                        {
                            dgv.Rows.Add(row["id"].ToString(), row["transdate"].ToString(),row["reference"].ToString(), row["docstatus"].ToString(), Convert.ToInt32(row["age"].ToString()), row["cust_code"].ToString(), Convert.ToDecimal(string.Format("{0:0.00}", row["balance"].ToString())), Convert.ToDecimal(string.Format("{0:0.00}", row["total_amount"].ToString())));
                        }
                    }
                    else
                    {
                        dgv.Rows.Add(row["id"].ToString(), row["transdate"].ToString(), row["reference"].ToString(), row["docstatus"].ToString(), Convert.ToInt32(row["age"].ToString()), row["cust_code"].ToString(), Convert.ToDecimal(string.Format("{0:0.00}", row["balance"].ToString())), Convert.ToDecimal(string.Format("{0:0.00}", row["total_amount"].ToString())));
                    }
                }
                txtSearch.AutoCompleteCustomSource = auto;
            }
            dgv.Columns["balance"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv.Columns["total_amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            foreach (DataGridViewColumn col in dgv.Columns)
            {
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                int colw = col.Width;
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                col.Width = colw;
            }
        }

        private async void SOA_Load(object sender, EventArgs e)
        {
            checkDate.Checked = false;
            label1.Visible = false;
            dtFromDate.Visible = false;
            await loadSOA();
            cDate = 0;
            cToDate = 0;
        }

        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            await loadSOA();
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            await loadSOA();
        }

        private async void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                await loadSOA();
            }
        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2)
            {
                if(e.RowIndex >= 0)
                {
                    if(dgv.Rows.Count > 0)
                    {
                        SOA_Details frm = new SOA_Details();
                        int intTemp = 0;
                        frm.selectedID = int.TryParse(dgv.CurrentRow.Cells["id"].Value.ToString(), out intTemp) ? Convert.ToInt32(dgv.CurrentRow.Cells["id"].Value.ToString()) : 0;
                        frm.ShowDialog();
                    }
                }
            }
        }


        private async void dtFromDate_CloseUp(object sender, EventArgs e)
        {
            if(cDate <= 0)
            {
                await loadSOA();
            }
        }

        private async void dtToDate_CloseUp(object sender, EventArgs e)
        {
            if(cToDate <= 0)
            {
                await loadSOA();
            }
        }

        private void checkToDate_CheckedChanged(object sender, EventArgs e)
        {
            if(cToDate <= 0)
            {
                label4.Visible = checkToDate.Checked;
                dtToDate.Visible = checkToDate.Checked;
                loadSOA();
            }
        }

        private void checkDate_CheckedChanged(object sender, EventArgs e)
        {
            if (cDate <= 0)
            {
                label1.Visible = checkDate.Checked;
                dtFromDate.Visible = checkDate.Checked;
                loadSOA();
            }
        }
    }
}
