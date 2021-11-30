using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DeliciousPartnerApp.API_Class.Notification;
using DeliciousPartnerApp.API_Class.Branch;
using Newtonsoft.Json.Linq;
using DeliciousPartnerApp.API_Class.Warehouse;
namespace DeliciousPartnerApp
{
    public partial class Notification2 : Form
    {
        public Notification2(int isDone)
        {
            InitializeComponent();
            gIsDone = isDone;
        }
        int gIsDone = 0;
        DataTable dtBranches = new DataTable(), dtWarehouse = new DataTable();
        branch_class branchc = new branch_class();
        warehouse_class warehousec = new warehouse_class();
        int cBranch = 1, cWhse = 1, cDate = 1, cToDate = 1, cCheckDate = 1, cCheckToDate = 1;
        private async void Notification2_Load(object sender, EventArgs e)
        {
            dgv.Columns["date_updated"].HeaderText = gIsDone <= 0 ? "Date Updated" : "Date Done";
            checkDate.Checked = gIsDone <= 0 ? false : true;
            dtFromDate.Visible = gIsDone <= 0 ? false : true;
            dgv.Columns["btnAction"].Visible = gIsDone > 0 ? false : true;
            label1.Visible = gIsDone <= 0 ? false : true;
            dtFromDate.Value = DateTime.Now;
            dtToDate.Value = DateTime.Now;
            await loadBranches();
            loadWarehouse();
            loadData();
            cBranch = 0;
            cWhse = 0;
            cDate = 0;
            cToDate = 0;
            cCheckDate = 0;
            cCheckToDate = 0;
        }


        public async Task loadBranches()
        {
            bool isAdmin = false;
            string branch = "";
            string currentBranch = "";
            dtBranches = await Task.Run(() => branchc.returnBranches());
            cmbBranches.Items.Clear();
            cmbBranches.Items.Add("All");
            AutoCompleteStringCollection auto = new AutoCompleteStringCollection();
            //get muna whse and check kung admin , superadmin or manager
            if (Login.jsonResult != null)
            {
                foreach (var x in Login.jsonResult)
                {
                    if (x.Key.Equals("data"))
                    {
                        JObject jObjectData = JObject.Parse(x.Value.ToString());
                        foreach (var y in jObjectData)
                        {
                            if (y.Key.Equals("branch"))
                            {
                                branch = y.Value.ToString();
                            }
                            else if (y.Key.Equals("isAdmin") || y.Key.Equals("isSuperAdmin") || y.Key.Equals("isAccounting") || y.Key.Equals("isManager"))
                            {
                                isAdmin = string.IsNullOrEmpty(y.Value.ToString()) ? false : Convert.ToBoolean(y.Value.ToString());
                                if (isAdmin)
                                {
                                    break;
                                }
                            }
                        }
                    }
                }

                foreach (DataRow row in dtBranches.Rows)
                {
                    if (row["code"].ToString() == branch)
                    {
                        currentBranch = row["name"].ToString();
                    }
                }
                if (isAdmin)
                {
                    foreach (DataRow row in dtBranches.Rows)
                    {
                        auto.Add(row["name"].ToString());
                        cmbBranches.Items.Add(row["name"].ToString());
                    }
                }
                else
                {
                    auto.Add(currentBranch);
                    cmbBranches.Items.Add(currentBranch);
                }
                cmbBranches.SelectedIndex = cmbBranches.Items.IndexOf(currentBranch);
                cmbBranches.AutoCompleteCustomSource = auto;
            }
        }

        public async void loadWarehouse()
        {
            cmbWarehouse.Items.Clear();
            cmbWarehouse.Items.Add("All");
            string branch = "";
            foreach (DataRow row in dtBranches.Rows)
            {
                if (cmbBranches.Text == row["name"].ToString())
                {
                    branch = row["code"].ToString();
                    break;
                }
            }
            dtWarehouse = await Task.Run(() => warehousec.returnWarehouse(branch, ""));
            foreach (DataRow row in dtWarehouse.Rows)
            {
                cmbWarehouse.Items.Add(row["whsename"].ToString());
            }
            cmbWarehouse.SelectedIndex = 0;
        }


        public async void loadData()
        {
            string sBranch = "", sWarehouse = "";
            foreach (DataRow row in dtBranches.Rows)
            {
                if (row["name"].ToString() == cmbBranches.Text)
                {
                    sBranch = row["code"].ToString();
                }
            }
            foreach (DataRow row in dtWarehouse.Rows)
            {
                if (row["whsename"].ToString() == cmbWarehouse.Text)
                {
                    sWarehouse = row["whsecode"].ToString();
                }
            }

            notification_class notifc = new notification_class();
            txtSearch.AutoCompleteCustomSource = null;
            AutoCompleteStringCollection auto = new AutoCompleteStringCollection();
            string fromDate = checkDate.Checked ? "&from_date=" + dtFromDate.Value.ToString("MM/dd/yyyy") : "&from_date=";
            string toDate = checkToDate.Checked ? "&to_date=" + dtToDate.Value.ToString("MM/dd/yyyy") : "&to_date=";

            DataTable dt = await notifc.getUnreadNotif(sBranch, fromDate, toDate, "&whsecode=" + sWarehouse, gIsDone);
            dgv.Rows.Clear();
            int count = 0, intTemp = 0;
            double doubleTemp = 0;
            if (dt.Rows.Count > 0 && dt.Columns.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    //Console.WriteLine(row["item_code"].ToString() + "/" + row["remarks_count"].ToString() + "/" + row["auto_done"].ToString());
                    auto.Add(row["item_code"].ToString());
                    int remarksCount = Convert.ToInt32(row["remarks_count"].ToString());
                    if (!string.IsNullOrEmpty(txtSearch.Text.ToString().Trim()))
                    {
                        if (txtSearch.Text.ToString().Trim().ToLower().Contains(row["item_code"].ToString().ToLower()))
                        {
                            count = Int32.TryParse(row["count"].ToString(), out intTemp) ? Convert.ToInt32(row["count"].ToString()) : 0;
                            int age = Int32.TryParse(row["age"].ToString(), out intTemp) ? Convert.ToInt32(row["age"].ToString()) : 0;
                            double qty = double.TryParse(row["quantity"].ToString(), out doubleTemp) ? Convert.ToDouble(row["quantity"].ToString()) : doubleTemp;

                            dgv.Rows.Add(row["id"].ToString(), row["whsecode"].ToString(), row["item_code"].ToString(), Convert.ToDecimal(string.Format("{0:0.00}", qty)), row["branch"].ToString(), age, row["date_created"].ToString(), row[(gIsDone <= 0 ? "date_updated" : "date_done")].ToString());
                        }
                    }
                    else
                    {
                        count = Int32.TryParse(row["count"].ToString(), out intTemp) ? Convert.ToInt32(row["count"].ToString()) : 0;
                        int age = Int32.TryParse(row["age"].ToString(), out intTemp) ? Convert.ToInt32(row["age"].ToString()) : 0;
                        double qty = double.TryParse(row["quantity"].ToString(), out doubleTemp) ? Convert.ToDouble(row["quantity"].ToString()) : doubleTemp;
                        dgv.Rows.Add(row["id"].ToString(), row["whsecode"].ToString(), row["item_code"].ToString(), Convert.ToDecimal(string.Format("{0:0.00}", qty)), row["branch"].ToString(), age, row["date_created"].ToString(), row[(gIsDone <= 0 ? "date_updated" : "date_done")].ToString());
                    }

                    if (gIsDone > 0)
                    {
                        dgv.Rows[dgv.Rows.Count - 1].DefaultCellStyle.BackColor = Convert.ToBoolean(row["auto_done"].ToString()) ? Color.White : Color.FromArgb(255, 249, 161);
                    }
                    dgv.Rows[dgv.Rows.Count - 1].Cells["view_remarks"].Style.BackColor = Convert.ToInt32(row["remarks_count"].ToString()) > 0 ? Color.FromArgb(40, 82, 122) : Color.FromArgb(192, 0, 192);
                    dgv.Rows[dgv.Rows.Count - 1].Cells["btnAction"].Style.BackColor = Color.ForestGreen;
                }
                dgv.Columns["date_updated"].HeaderText = gIsDone <= 0 ? "Date Updated" : "Date Done";
            }
            lblCount.Text = "Count: " + count.ToString("N0");
            txtSearch.AutoCompleteCustomSource = auto;
        }

        //public void loadUI(DataTable dt)
        //{
        //    dgv.Invoke(new Action(delegate ()
        //    {

        //    }));

        //    foreach (DataRow row in dt.Rows)
        //    {
        //        dgv.Invoke(new Action(delegate ()
        //        {

        //        }));
        //    }

        //}

        private async void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv.Rows.Count > 0)
            {
                if (e.RowIndex >= 0)
                {
                    if (e.ColumnIndex == 1)
                    {
                        Notification frm = new Notification();
                        int temp = 0;
                        frm.selectedID = int.TryParse(dgv.CurrentRow.Cells["id"].Value.ToString(), out temp) ? Convert.ToInt32(dgv.CurrentRow.Cells["id"].Value.ToString()) : 1;
                        frm.ShowDialog();
                    }
                    else if (e.ColumnIndex == 8)
                    {
                        RemarksDetails frm = new RemarksDetails(gIsDone);
                        int temp = 0;
                        frm.selectedID = int.TryParse(dgv.CurrentRow.Cells["id"].Value.ToString(), out temp) ? Convert.ToInt32(dgv.CurrentRow.Cells["id"].Value.ToString()) : 1;
                        frm.ShowDialog();
                        if (gIsDone <= 0)
                        {
                            loadData();
                        }
                    }
                    else if (e.ColumnIndex == 9)
                    {
                        DialogResult dialogResult = MessageBox.Show("Are you sure you want to Mark as Done?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dialogResult == DialogResult.Yes)
                        {
                            int temp = 0;
                            int selectedID = int.TryParse(dgv.CurrentRow.Cells["id"].Value.ToString(), out temp) ? Convert.ToInt32(dgv.CurrentRow.Cells["id"].Value.ToString()) : 1;
                            notification_class notifc = new notification_class();
                            string msgDone = "";
                            msgDone = await notifc.markAsRead(selectedID);
                            MessageBox.Show(msgDone, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            loadData();
                        }
                    }
                }
            }
        }

        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            loadData();
        }

        private void checkDate_CheckedChanged(object sender, EventArgs e)
        {
            if (cCheckDate <= 0)
            {
                dtFromDate.Visible = checkDate.Checked;
                label1.Visible = checkDate.Checked;
                btnRefresh.PerformClick();
            }
        }

        private void checkToDate_CheckedChanged(object sender, EventArgs e)
        {
            if (cCheckToDate <= 0)
            {
                dtToDate.Visible = checkToDate.Checked;
                label2.Visible = checkToDate.Checked;
                btnRefresh.PerformClick();
            }
        }

        private async void dtFromDate_CloseUp(object sender, EventArgs e)
        {
            if (cDate <= 0)
            {
                loadData();
            }
        }

        private void cmbBranches_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cBranch <= 0)
            {
                loadWarehouse();
            }
        }

        private void cmbBranches_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                if (cBranch <= 0)
                {
                    loadWarehouse();
                }
            }
        }

        private async void dtToDate_CloseUp(object sender, EventArgs e)
        {
            if (cToDate <= 0)
            {
                loadData();
            }
        }

        private void cmbWarehouse_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cWhse <= 0)
            {
                loadData();
            }
        }

        private void dtToDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private async void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                loadData();
            }
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            loadData();
        }

        private void dtFromDate_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
