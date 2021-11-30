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
using RestSharp;
using DeliciousPartnerApp.API_Class.Customer_Type;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Globalization;

namespace DeliciousPartnerApp
{
    public partial class SAPARDone : Form
    {
        string gSalesType = "", gForType = "", gStatus = "";
        public SAPARDone(string salesType, string forType, string status)
        {
            gSalesType = salesType;
            gForType = forType;
            gStatus = status;
            InitializeComponent();
        }
        api_class apic = new api_class();
        utility_class utilityc = new utility_class();
        DataTable dtBranches = new DataTable();
        DataTable dtSalesAgent = new DataTable();
        DataTable dtSearch = new DataTable();
        DataTable dtCustType = new DataTable();
        customertype_class customertypec = new customertype_class();
        private void SAPARDone_Load(object sender, EventArgs e)
        {
            cmbSearchType.SelectedIndex = 0;
            dtFromDate.EditValue = DateTime.Now;
            dtToDate.EditValue = DateTime.Now;
            cmbFromTime.SelectedIndex = 0;
            cmbToTime.SelectedIndex = cmbToTime.Properties.Items.Count - 1;

            dtSearch = new DataTable();
            dtSearch.Rows.Clear();
            dtSearch.Columns.Add("search", typeof(string));
            dtSearch.Columns.Add("type", typeof(string));

            loadBranches();
            loadSalesAgent();
            loadCustomerType();
            bg();

        }

        public void bg()
        {
            if (!backgroundWorker1.IsBusy)
            {
                closeForm();
                Loading frm = new Loading();
                frm.Show();
                backgroundWorker1.RunWorkerAsync();
            }
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

        public void loadData()
        {
            //Loading frm = new Loading();
            //frm.ShowDialog();
            string userID = apic.findValueInDataTable(dtSalesAgent, cmbsales.Text, "username", "id");
            string sBranch = apic.findValueInDataTable(dtBranches, cmbBranch.Text, "name", "code");
            string sCustType = apic.findValueInDataTable(dtCustType, cmbCustomerType.Text, "code", "id");

            dgvOrders.Invoke(new Action(delegate ()
            {
                dgvOrders.Columns.Clear();
                dgvOrders.DataSource = null;
            }));

            //Console.WriteLine("/api/sales/for_sap/get_all", "?from_date=" + (!checkDate.Checked ? "" : dtFromDate.Text) + "&to_date=" + (!checkToDate.Checked ? "" : dtToDate.Text) + "&transtype=" + gSalesType + "&search=" + txtsearch.Text + "&created_by=" + userID + "&from_time=" + cmbFromTime.Text + "&to_time=" + cmbToTime.Text + "&branch=" + sBranch + "&has_sap_num=1&cust_type=" + sCustType, "");
            string sResult = apic.loadData("/api/sales/for_sap/get_all", "?from_date=" + (!checkDate.Checked ? "" : dtFromDate.Text) + "&to_date=" + (!checkToDate.Checked ? "" : dtToDate.Text) + "&transtype=" + gSalesType + "&search=" + (txtsearch.Text.Trim().ToLower().Equals("search trans. #") || txtsearch.Text.Trim().ToLower().Equals("search cust. code") ? "" : txtsearch.Text) + "&created_by=" + userID + "&from_time=" + cmbFromTime.Text + "&to_time=" + cmbToTime.Text + "&branch=" + sBranch + "&has_sap_num=1&cust_type=" + sCustType, "", "", Method.GET, true);
            if (!string.IsNullOrEmpty(sResult.Trim()))
            {
                if (sResult.Substring(0, 1).Equals("{"))
                {
                    JObject joResult = JObject.Parse(sResult);
                    JArray jaData = (JArray)joResult["data"];
                    DataTable dt = JsonConvert.DeserializeObject<DataTable>(joResult["data"].ToString());
                    DataTable dt2 = new DataTable();
                    dt2.Columns.Add("selectt", typeof(bool));
                    dt2.Columns.Add("id", typeof(int));
                    dt2.Columns.Add("reference", typeof(string));
                    dt2.Columns.Add("cust_code", typeof(string));
                    dt2.Columns.Add("transdate", typeof(string));
                    dt2.Columns.Add("doctotal", typeof(double));
                    dt2.Columns.Add("ar_number", typeof(string));
                    dt2.Columns.Add("transdate_close", typeof(string));

                    foreach(DataRow row in dt.Rows)
                    {
                        DateTime dtTransDate = new DateTime(), dtTransdateClose = new DateTime(), dtTemp = new DateTime();
                        dtTransDate = DateTime.TryParse(row["transdate"].ToString(), out dtTemp) ? Convert.ToDateTime(row["transdate"].ToString().Replace("T", " ")) : new DateTime();
                        dtTransdateClose = DateTime.TryParse(row["sap_date_updated"].ToString(), out dtTemp) ? Convert.ToDateTime(row["sap_date_updated"].ToString().Replace("T", " ")) : new DateTime();
                        //Console.WriteLine(dtTransDate.ToString("yyyy-MM-dd HH:mm:ss") + "/" + dtTransdateClose.ToString("yyyy-MM-dd HH:mm:ss"));
                        dt2.Rows.Add(false, Convert.ToInt32(row["id"].ToString()), row["reference"], row["cust_code"].ToString(), dtTransDate==DateTime.MinValue ? "" : dtTransDate.ToString("yyyy-MM-dd HH:mm:ss"), row["doctotal"].ToString(), row["sap_number"].ToString(), dtTransdateClose == DateTime.MinValue ? "" : dtTransdateClose.ToString("yyyy-MM-dd HH:mm:ss"));
                    }

                    dgvOrders.Invoke(new Action(delegate ()
                    {
                        dgvOrders.DataSource = dt2;

                        for(int i =0; i < dgvOrders.Columns.Count; i++)
                        {
                            string q = dgvOrders.Columns[i].Name;
                            dgvOrders.Columns[i].Visible = dgvOrders.Columns[i].Name.Equals("id") ? false : true;
                            dgvOrders.Columns[i].MinimumWidth = dgvOrders.Columns[i].Name.Equals("selectt") ? 100 :  150;
                            dgvOrders.Columns[i].ReadOnly = q.Equals("selectt") ? false : true;

                            string w = q.Replace("_", " ");
                            string e = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(w.ToLower());
                            dgvOrders.Columns[i].HeaderText = e;


                            //fomat
                            dgvOrders.Columns[i].DefaultCellStyle.Format = q.Equals("disc_amount") || q.Equals("doctotal") || q.Equals("tender_amount") || q.Equals("aging") || q.Equals("other_fee") || q.Equals("balance_due") ? "n2" : "";

                            //align
                            dgvOrders.Columns[i].DefaultCellStyle.Alignment = q.Equals("disc_amount") || q.Equals("doctotal") || q.Equals("tender_amount") || q.Equals("aging") || q.Equals("other_fee") || q.Equals("balance_due") ? DataGridViewContentAlignment.MiddleRight : q.Equals("selectt") ? DataGridViewContentAlignment.MiddleCenter : DataGridViewContentAlignment.MiddleLeft;
                        }

                        highlightHaveDiscount();

                    }));


                    foreach (DataRow dr in dt.Rows)
                    {
                        dtSearch.Rows.Add(dr["cust_code"], "Customer");
                        dtSearch.Rows.Add(dr["reference"], "Transnum");
                    }
                    searchFilter();
                }
                else
                {
                    MessageBox.Show(sResult, "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show(sResult, "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public void highlightHaveDiscount()
        {
            if (dgvOrders.Rows.Count > 0)
            {
                for (int i = 0; i < dgvOrders.Rows.Count; i++)
                {
                    if (dgvOrders.Columns.Contains("disc_amount"))
                    {
                        if (Convert.ToDouble(dgvOrders.Rows[i].Cells["disc_amount"].Value.ToString()) > 0)
                        {
                            dgvOrders.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;
                            dgvOrders.Rows[i].Cells["selectt"].Style.BackColor = Color.White;
                        }
                    }
                }
            }
        }

        public void searchFilter()
        {
            AutoCompleteStringCollection auto = new AutoCompleteStringCollection();
            if (cmbSearchType.SelectedIndex == 0)
            {
                foreach (DataRow row in dtSearch.Rows)
                {
                    if (row["type"].ToString().Equals("Transnum"))
                    {
                        auto.Add(row["search"].ToString());
                    }
                }
            }
            else
            {
                foreach (DataRow row in dtSearch.Rows)
                {
                    if (row["type"].ToString().Equals("Customer"))
                    {
                        auto.Add(row["search"].ToString());
                    }
                }
            }
            txtsearch.Invoke(new Action(delegate ()
            {
                txtsearch.AutoCompleteCustomSource = auto;
            }));
            txtsearch.Text = cmbSearchType.SelectedIndex <= 0 ? "Search Trans. #" : "Search Cust. Code";
            txtsearch.ForeColor = string.IsNullOrEmpty(txtsearch.Text.Trim()) ? Color.DimGray : Color.Black;
        }

        public void loadCustomerType()
        {
            cmbCustomerType.Properties.Items.Clear();
            dtCustType = customertypec.loadCustomerTypes();
            if (dtCustType.Rows.Count > 0)
            {
                cmbCustomerType.Properties.Items.Add("All");
                foreach (DataRow row in dtCustType.Rows)
                {
                    cmbCustomerType.Properties.Items.Add(row["code"].ToString());
                }
                cmbCustomerType.SelectedIndex = 0;
            }
        }

       

        private void checkSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < dgvOrders.Rows.Count; i++)
            {
                dgvOrders.Rows[i].Cells["selectt"].Value = checkSelectAll.Checked;
            }
        }

        private void btnViewItem_Click(object sender, EventArgs e)
        {
            JArray jarrayBody = new JArray();
            for (int i = 0; i < dgvOrders.Rows.Count; i++)
            {
                bool isSelect = false, boolTemp = false;
                isSelect = dgvOrders.Rows[i].Cells["selectt"].Value == null ? false : bool.TryParse(dgvOrders.Rows[i].Cells["selectt"].Value.ToString(), out boolTemp) ? Convert.ToBoolean(dgvOrders.Rows[i].Cells["selectt"].Value.ToString()) : boolTemp;
                if (isSelect)
                {
                    //totalPendingAmount += Convert.ToDouble(dgvOrders.Rows[i].Cells[forSAPAmountColumnName].Value.ToString());
                    //ids += dgvOrders.Rows[i].Cells["base_id"].Value.ToString() + ",";
                    jarrayBody.Add(Convert.ToInt32(dgvOrders.Rows[i].Cells["id"].Value));
                    //isCheckAll_int += 1;
                }
            }
            if(jarrayBody.Count > 0)
            {
                JObject jsonObjectBody = new JObject();
                jsonObjectBody.Add("ids", jarrayBody);
                string sResult = apic.loadData("/api/sales/summary_trans", "?transtype=" + gSalesType + "&transdate=" + dtFromDate.Text, "application/json", jsonObjectBody.ToString(), Method.PUT, true);
                if (!string.IsNullOrEmpty(sResult.Trim()))
                {
                    if (sResult.Substring(0, 1).Equals("{"))
                    {
                        JObject joResult = JObject.Parse(sResult);
                        JObject joData =(JObject) joResult["data"];
                        JObject joHeader = (JObject)joData["header"];
                        JArray jaRows = (JArray)joData["row"];
                        SAPARDoneDetails frm = new SAPARDoneDetails();
                        frm.dtRows = (DataTable)JsonConvert.DeserializeObject(jaRows.ToString(), (typeof(DataTable)));
                        frm.joHeader = joHeader;
                        frm.ShowDialog();
                    }
                }
            }
            else
            {
                MessageBox.Show("No data found", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void btnRefresh_Click(object sender, EventArgs e)
        {
            bg();
        }


        private void checkDate_CheckedChanged(object sender, EventArgs e)
        {
            dtFromDate.Visible = checkDate.Checked;
        }

        private void checkToDate_CheckedChanged(object sender, EventArgs e)
        {
            dtToDate.Visible = checkToDate.Checked;
        }


        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            loadData();
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            closeForm();
        }

        private void cmbSearchType_SelectedIndexChanged(object sender, EventArgs e)
        {
            searchFilter();
        }

        private void txtsearch_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtsearch.Text.Trim()))
            {
                txtsearch.Text = cmbSearchType.Text.Equals("Trans. #") ? "Search Trans. #" : "Search Cust. Code";
                txtsearch.ForeColor = Color.DimGray;
            }
        }

        private void txtsearch_Enter(object sender, EventArgs e)
        {
            if (txtsearch.Text.ToLower().Equals("search trans. #") || txtsearch.Text.ToLower().Equals("search cust. code"))
            {
                txtsearch.Text = string.Empty;
                txtsearch.ForeColor = Color.Black;
            }
        }

        private void btnSearchQuery2_Click(object sender, EventArgs e)
        {
            bg();
        }

        private void btnSearchQuery_Click(object sender, EventArgs e)
        {
            bg();
        }


        public void loadSalesAgent()
        {
            string sBranch = "";
            cmbBranch.Invoke(new Action(delegate ()
            {
                sBranch = cmbBranch.Text;
            }));

            string sResult = apic.loadData("/api/auth/user/get_all", "?isSales=1&branch=" + apic.findValueInDataTable(dtBranches,sBranch, "name", "code"), "", "", Method.GET, true);
            if (sResult.Substring(0, 1).Equals("{"))
            {
                dtSalesAgent = apic.getDtDownloadResources(sResult, "data");
                cmbsales.Invoke(new Action(delegate ()
                {
                    cmbsales.Properties.Items.Add("All");
                }));

                foreach (DataRow row in dtSalesAgent.Rows)
                {
                    cmbsales.Invoke(new Action(delegate ()
                    {
                        cmbsales.Properties.Items.Add(row["username"].ToString());
                    }));
                }
                cmbsales.SelectedIndex = cmbsales.Properties.Items.Count > 0 ? 0 : -1;
            }
            else
            {
                apic.showCustomMsgBox("Validation", sResult);
            }
        }

        public void loadBranches()
        {
            try
            {
                cmbBranch.Invoke(new Action(delegate ()
                {
                    cmbBranch.Properties.Items.Clear();
                }));
                if (apic.haveAccess())
                {
                    string sResult = "";
                    sResult = apic.loadData("/api/branch/get_all", "", "", "", Method.GET, true);
                    if (sResult.Substring(0, 1).Equals("{"))
                    {
                        //DataTable dtData = apic.getDtDownloadResources(sResult, "data");
                        //string sBranch = apic.getFirstRowDownloadResources(dtData, "data");

                        dtBranches = apic.getDtDownloadResources(sResult, "data");
                        cmbBranch.Invoke(new Action(delegate ()
                        {
                            cmbBranch.Properties.Items.Add("All");
                        }));

                        foreach (DataRow row in dtBranches.Rows)
                        {
                            cmbBranch.Invoke(new Action(delegate ()
                            {
                                cmbBranch.Properties.Items.Add(row["name"].ToString());
                            }));
                        }
                        cmbBranch.Invoke(new Action(delegate ()
                        {
                            string branch = (string)Login.jsonResult["data"]["branch"];
                            string s = apic.findValueInDataTable(dtBranches, branch, "code", "name");
                            cmbBranch.SelectedIndex = cmbBranch.Properties.Items.IndexOf(s);
                        }));
                    }
                    else
                    {
                        apic.showCustomMsgBox("Validation", sResult);
                    }
                }
                else
                {
                    cmbBranch.Invoke(new Action(delegate ()
                    {
                        cmbBranch.Properties.Items.Add(Login.jsonResult["data"]["branch"]);
                        cmbBranch.SelectedIndex = 0;
                    }));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
