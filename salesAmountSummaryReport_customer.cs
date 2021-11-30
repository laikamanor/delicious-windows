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
using DeliciousPartnerApp.UI_Class;
using DeliciousPartnerApp.API_Class.Branch;
using System.Threading;
using RestSharp;
using DeliciousPartnerApp.API_Class.Customer_Type;
using DeliciousPartnerApp.API_Class.Customer;
namespace DeliciousPartnerApp
{
    public partial class salesAmountSummaryReport_customer : Form
    {
        public salesAmountSummaryReport_customer()
        {
            InitializeComponent();
        }
        JObject joResponse = new JObject();
        utility_class utilityc = new utility_class();
        branch_class branchc = new branch_class();
        customer_class customerc = new customer_class();
        customertype_class customertypec = new customertype_class();
        int cTopBy = 1, cFromDate = 1, cToDate = 1, cFromTime = 1, cToTime = 1, cCustType = 1;
        DataTable dtCustomer = new DataTable();

        public static DataTable dtSelectedCustomer = new DataTable();
        DataTable dtBranch = new DataTable();

        private void salesAmountSummaryReport_customer_Load(object sender, EventArgs e)
        {
            dtSelectedCustomer.Columns.Clear();
            dtSelectedCustomer.Columns.Add("code", typeof(string));
            dtSelectedCustomer.Columns.Add("isAll",typeof(int));
            dtSelectedCustomer.Columns.Add("cust_type",typeof(string));
            if (!backgroundWorker1.IsBusy)
            {
                closeForm();
                Loading frm = new Loading();
                frm.Show();
                backgroundWorker1.RunWorkerAsync();
            }

            cmbFromTime.SelectedIndex = 0;
            cmbToTime.SelectedIndex = cmbToTime.Items.Count - 1;

            cmbByTop.SelectedIndex = 0;
            cTopBy = 0;
            cFromDate = 0;
            cToDate = 0;
            cFromTime = 0;
            cToTime = 0;
            cCustType = 0;
        }

        public void loadData()
        {
            joResponse = new JObject();
            try
            {
                if (Login.jsonResult != null)
                {
                    string token = "";
                    foreach (var x in Login.jsonResult)
                    {
                        if (x.Key.Equals("token"))
                        {
                            token = x.Value.ToString();
                        }
                    }
                    if (!token.Equals(""))
                    {
                        var client = new RestClient(utilityc.URL);
                        client.Timeout = -1;

                        string sFromDate = checkDate.Checked ? dtFromDate.Value.ToString("yyyy-MM-dd") : "";
                        string sToDate = checkToDate.Checked ? dtToDate.Value.ToString("yyyy-MM-dd") : "";

                        string sFromTime = "";
                        cmbFromTime.Invoke(new Action(delegate ()
                        {
                            sFromTime = cmbFromTime.Text == "" ? "&from_time=" : "&from_time=" + cmbFromTime.Text;
                        }));

                        string sToTime = "";
                        cmbToTime.Invoke(new Action(delegate ()
                        {
                            sToTime = cmbToTime.Text == "" ? "&to_time=" : "&to_time=" + cmbToTime.Text;
                        }));

                        int topIndex = 0;

                        cmbByTop.Invoke(new Action(delegate ()
                        {
                            topIndex = cmbByTop.SelectedIndex == 1 ? 5 : cmbByTop.SelectedIndex == 2 ? 10 : 0;
                        }));

                        string sTopBy = cTopBy <= 0 && topIndex > 0 ? "&top=" + topIndex : "";

                        string branches = "";
                        if(dtSelectedCustomer.Rows.Count > 0)
                        {
                            DataRow row1 = dtSelectedCustomer.Rows[0];
                            int isAll = 0, intTemp = 0, iCusTypeID = 0;
                            isAll = Int32.TryParse(row1["isAll"].ToString(), out intTemp) ? Convert.ToInt32(row1["isAll"].ToString()) : intTemp;
                            iCusTypeID = Int32.TryParse(row1["cust_type"].ToString(), out intTemp) ? Convert.ToInt32(row1["cust_type"].ToString()) : intTemp;
                            Console.WriteLine(isAll + "/" + iCusTypeID);
                            if (isAll > 0 && iCusTypeID > 0)
                            {
                                branches = "&cust_type=" + iCusTypeID;
                            }else if(isAll > 0 && iCusTypeID <= 0)
                            {
                                branches = "&cust_code=&cust_type=";
                            }
                            else
                            {
                                for (int i = 0; i < dgvSelectedBranch.Rows.Count; i++)
                                {
                                    branches = branches + "," + dgvSelectedBranch.Rows[i].Cells["code"].Value.ToString();
                                }
                                branches = "&cust_code=%5B" + (string.IsNullOrEmpty(branches) ? "" : branches.Substring(1)) + "%5D";
                            }
                        }
                        else
                        {
                            branches = "&cust_code=&cust_type=";
                        }

                        string appendParam = "?from_date=" + sFromDate + "&to_date=" + sToDate + sFromTime + sToTime + sTopBy + branches;



                        var request = new RestRequest("/api/report/customer/sales/amount/summary" + appendParam);
                        request.AddHeader("Authorization", "Bearer " + token);
                        //Console.WriteLine("/api/report/customer/sales/amount/summary" + appendParam);

                        var response = client.Execute(request);
                        //Console.WriteLine(response.Content.ToString());
                        if (response.ErrorMessage == null)
                        {
                            if (response.Content.Substring(0, 1).Equals("{"))
                            {
                                JObject joTemp = JObject.Parse(response.Content.ToString());
                                bool isSuccess = false, boolTemp = false;
                                foreach (var q in joTemp)
                                {
                                    if (q.Key.Equals("success"))
                                    {
                                        isSuccess = bool.TryParse(q.Value.ToString(), out boolTemp) ? Convert.ToBoolean(q.Value.ToString()) : boolTemp;
                                        break;
                                    }
                                }
                                if (isSuccess)
                                {
                                    joResponse = JObject.Parse(response.Content.ToString());
                                }
                            }
                            else
                            {
                                MessageBox.Show(response.Content, "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                        else
                        {
                            MessageBox.Show(response.ErrorMessage, "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            Thread.Sleep(1000);
            bool isSomeInvisible = dtFromDate.Visible || dtToDate.Visible ? false : true;
            double diff = isSomeInvisible ? 1 : (dtToDate.Value - dtFromDate.Value).TotalDays;
            SASR1 s1 = new SASR1(getArray("customer_summary_report"), "customer_summary_report", diff);
            SASR2 s2 = new SASR2(getArray("overall_top_sales"), "Sales", true, "");
            panel1.Invoke(new Action(delegate ()
            {
                showForm(s1, panel1);
            }));
            panel2.Invoke(new Action(delegate ()
            {
                showForm(s2, panel2);
            }));
        }

        public void showForm(Form form, Panel pn)
        {
            form.TopLevel = false;

            pn.Controls.Add(form);


            form.BringToFront();
            form.Show();
        }

        private void checkToDate_CheckedChanged(object sender, EventArgs e)
        {
            dtToDate.Visible = checkToDate.Checked;
        }

        private void checkDate_CheckedChanged(object sender, EventArgs e)
        {
            dtFromDate.Visible = checkDate.Checked;
        }

        private void dtToDate_ValueChanged(object sender, EventArgs e)
        {
        }

        private void dtFromDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void cmbFromTime_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        public JArray getArray(string arrayName)
        {
            JArray result = new JArray();
            foreach (var q in joResponse)
            {
                if (q.Key.Equals("data"))
                {
                    if (q.Value.ToString().Substring(0, 1).Equals("{"))
                    {
                        JObject joData = JObject.Parse(q.Value.ToString());
                        foreach (var w in joData)
                        {
                            if (w.Key.Equals(arrayName))
                            {
                                if (!string.IsNullOrEmpty(w.Value.ToString()))
                                {
                                    if (w.Value.ToString().Substring(0, 1).Equals("["))
                                    {
                                        result = JArray.Parse(w.Value.ToString());
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return result;
        }

        private void cmbToTime_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                if (!backgroundWorker1.IsBusy)
                {
                    closeForm();
                    backgroundWorker1.RunWorkerAsync();
                }
            }
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnSelectBranch_Click(object sender, EventArgs e)
        {
            SelectBranch frm = new SelectBranch("Customer");
            frm.dtSelected = dtSelectedCustomer;
            frm.ShowDialog();

            dtSelectedCustomer.DefaultView.Sort = "code ASC";
            dtSelectedCustomer = dtSelectedCustomer.DefaultView.ToTable();

            dgvSelectedBranch.DataSource = dtSelectedCustomer;
            dgvSelectedBranch.Columns["code"].HeaderText = "Name";
            dgvSelectedBranch.Columns["code"].ReadOnly = true;
            dgvSelectedBranch.Columns["isAll"].Visible = false;
            dgvSelectedBranch.Columns["cust_type"].Visible = false;
        }

        private void dgvSelectedBranch_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnSearch_Click_1(object sender, EventArgs e)
        {
            if (!backgroundWorker1.IsBusy)
            {
                closeForm();
                Loading frm = new Loading();
                frm.Show();
                backgroundWorker1.RunWorkerAsync();
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            loadData();
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            closeForm();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

        }

        public void closeForm()
        {
            foreach (Form frm in Application.OpenForms)
            {
                if (frm.Name == "Loading")
                {
                    frm.Hide();
                }
            }
        }

        private void cmbByTop_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cTopBy <= 0)
            {
                if (!backgroundWorker1.IsBusy)
                {
                    closeForm();
                    Loading frm = new Loading();
                    frm.Show();
                    backgroundWorker1.RunWorkerAsync();
                }
            }
        }

        private void btnFullScreen_Click(object sender, EventArgs e)
        {
            SASR2 s2 = new SASR2(getArray("overall_top_sales"), "Sales", false,"");
            showForm(s2, panel7);
        }
    }
}
