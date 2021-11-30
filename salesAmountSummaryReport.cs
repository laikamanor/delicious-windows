using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using RestSharp;
using DeliciousPartnerApp.UI_Class;
using DeliciousPartnerApp.API_Class.Branch;
using System.Threading;

namespace DeliciousPartnerApp
{
    public partial class salesAmountSummaryReport : Form
    {
        public salesAmountSummaryReport()
        {
            InitializeComponent();
        }
        JObject joResponse = new JObject();
        utility_class utilityc = new utility_class();
        branch_class branchc = new branch_class();
        public static DataTable dtSelectedBranches = new DataTable();
        DataTable dtBranch = new DataTable();
        int cTopBy = 1;
        private void salesAmountSummaryReport_Load(object sender, EventArgs e)
        {
            dtSelectedBranches.Columns.Clear();
            dtSelectedBranches.Columns.Add("code");
            dtSelectedBranches.Columns.Add("branch");

            cmbFromTime.SelectedIndex = 0;
            cmbToTime.SelectedIndex = cmbToTime.Items.Count - 1;

            if (!backgroundWorker1.IsBusy)
            {
                closeForm();
                Loading frm = new Loading();
                frm.Show();
                backgroundWorker1.RunWorkerAsync();
            }

            cmbByTop.SelectedIndex = 0;
            cTopBy = 0;
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

        public JArray getArray(string arrayName)
        {
            JArray result = new JArray();
            foreach (var q in joResponse)
            {
                if (q.Key.Equals("data"))
                {
                    if (q.Value.ToString().Substring(0,1).Equals("{"))
                    {
                        JObject joData = JObject.Parse(q.Value.ToString());
                        foreach(var w in joData)
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


                        string branches = "";
                        for (int i = 0; i < dgvSelectedBranch.Rows.Count; i++)
                        {
                            branches = branches + "," + dgvSelectedBranch.Rows[i].Cells["code"].Value.ToString();
                        }
                        branches = (string.IsNullOrEmpty(branches) ? "" : branches.Substring(1));

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

                        string appendParam = "?from_date=" + sFromDate + "&to_date=" + sToDate + "&branch=%5B" + branches + "%5D" + sFromTime + sToTime + sTopBy;

                        var request = new RestRequest("/api/report/branch/sales/amount/summary" + appendParam);
                        request.AddHeader("Authorization", "Bearer " + token);
                        //Console.WriteLine("/api/report/branch/sales/amount/summary" + appendParam);
                      
                        var response = client.Execute(request);
                        //Console.WriteLine(response.Content.ToString());
                        if (response.ErrorMessage == null)
                        {
                            if (response.Content.Substring(0, 1).Equals("{"))
                            {
                                JObject joTemp = JObject.Parse(response.Content.ToString());
                                bool isSuccess = false, boolTemp = false;
                                foreach(var q in joTemp)
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
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            Thread.Sleep(1000);
            bool isSomeInvisible = dtFromDate.Visible || dtToDate.Visible ? false : true;
            double diff = isSomeInvisible ? 1 : (dtToDate.Value - dtFromDate.Value).TotalDays;
            SASR1 s1 = new SASR1(getArray("branch_summary_report"), "branch_summary_report",diff);
            panel1.Invoke(new Action(delegate ()
            {
                showForm(s1, panel1);
            }));
        }

  

        private void checkToDate_CheckedChanged(object sender, EventArgs e)
        {
            dtToDate.Visible = checkToDate.Checked;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void checkDate_CheckedChanged(object sender, EventArgs e)
        {
            dtFromDate.Visible = checkDate.Checked;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dtFromDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private async void btnSelectBranch_Click(object sender, EventArgs e)
        {
            if(dtBranch.Rows.Count <= 0)
            { 
                dtBranch = await branchc.returnBranches();
            }
            SelectBranch frm = new SelectBranch("Branch");
            frm.dt = dtBranch;
            frm.dtSelected = dtSelectedBranches;
            frm.ShowDialog();

            dtSelectedBranches.DefaultView.Sort = "branch ASC";
            dtSelectedBranches = dtSelectedBranches.DefaultView.ToTable();

            dgvSelectedBranch.DataSource = dtSelectedBranches;
            dgvSelectedBranch.Columns["branch"].HeaderText = "Branch";
            dgvSelectedBranch.Columns["branch"].ReadOnly = true;
            dgvSelectedBranch.Columns["code"].Visible = false;

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (!backgroundWorker1.IsBusy)
            {
                closeForm();
                Loading frm = new Loading();
                frm.Show();
                backgroundWorker1.RunWorkerAsync();
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

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

        public void showForm(Form form, Panel pn)
        {
            form.TopLevel = false;

            pn.Controls.Add(form);


            form.BringToFront();
            form.Show();
        }

        private void btnFullScreen_Click(object sender, EventArgs e)
        {
            SASR2 s2 = new SASR2(getArray("overall_top_sales"), "", false,"Branch");


            showForm(s2, panel7);
        }

        private void btnFullScreen2_Click(object sender, EventArgs e)
        {
            SASR2 s2 = new SASR2(getArray("top_cash_sales"), "Cash", false, "Branch");
            showForm(s2, panel7);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SASR2 s3 = new SASR2(getArray("top_ar_sales"), "AR", false, "Branch");
            showForm(s3, panel7);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SASR2 s4 = new SASR2(getArray("top_agent_sales"), "Agent", false, "Branch");
            showForm(s4, panel7);
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                loadData();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            closeForm();
        }

        private void dgvSelectedBranch_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
