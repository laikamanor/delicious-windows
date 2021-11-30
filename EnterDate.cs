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
using Newtonsoft.Json.Linq;
namespace DeliciousPartnerApp
{
    public partial class EnterDate : Form
    {
        string gReportType = "";
        public static DateTime dateEntered = new DateTime();
        public static string branchCode = "", branchName = "";
        public DataTable dtBranch = new DataTable();
        branch_class branchc = new branch_class();
        public EnterDate(string reportType)
        {
            gReportType = reportType;
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            dateEntered = dateTimePicker1.Value;
            foreach(DataRow row in dtBranch.Rows)
            {
                if (row["name"].Equals(cmbBranches.Text))
                {
                    branchCode = row["code"].ToString();
                    break;
                }
            }
            branchName = cmbBranches.Text;
            reportsDialog reportDialog = new reportsDialog(gReportType);
            reportDialog.ShowDialog();
        }

        private void EnterDate_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Value = DateTime.Now;
            loadBranches();
        }

        public async void loadBranches()
        {
            int isAdmin = 0;
            string branch = "";
            dtBranch = await Task.Run(() => branchc.returnBranches());
            cmbBranches.Items.Clear();
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
                            else if (y.Key.Equals("isAdmin") || y.Key.Equals("isManager"))
                            {

                                if (y.Value.ToString().ToLower() == "false" || y.Value.ToString() == "")
                                {
                                    foreach (DataRow row in dtBranch.Rows)
                                    {
                                        if (row["code"].ToString() == branch)
                                        {
                                            cmbBranches.Items.Add(row["name"].ToString());
                                            if (cmbBranches.Items.Count > 0)
                                            {
                                                cmbBranches.SelectedIndex = 0;
                                            }
                                            return;
                                        }
                                    }
                                }
                                else
                                {
                                    isAdmin += 1;
                                    break;
                                }
                            }
                        }
                    }
                }
                if (cmbBranches.Items.Count <= 0)
                {
                    foreach (DataRow row in dtBranch.Rows)
                    {
                        cmbBranches.Items.Add(row["name"]);
                    }
                }
            }
            if (cmbBranches.Items.Count > 0)
            {
                string branchName = "";
                foreach (DataRow row in dtBranch.Rows)
                {
                    if (row["code"].ToString() == branch)
                    {
                        branchName = row["name"].ToString();
                        break;
                    }
                }
                cmbBranches.SelectedIndex = cmbBranches.Items.IndexOf(branchName);
            }
        }
    }
}
