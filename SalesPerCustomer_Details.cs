using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RestSharp;
using DeliciousPartnerApp.UI_Class;
using Newtonsoft.Json.Linq;
namespace DeliciousPartnerApp
{
    public partial class SalesPerCustomer_Details : Form
    {
        public SalesPerCustomer_Details()
        {
            InitializeComponent();
        }
        utility_class utilityc = new utility_class();
        int cFromDate = 1, cToDate = 1;
        private void SalesPerCustomer_Details_Load(object sender, EventArgs e)
        {
            dgv.Columns["amt_in"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv.Columns["amt_out"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv.Columns["running_balance"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtFromDate.Value = DateTime.Now;
            dtToDate.Value = DateTime.Now;
            loadData();
            cFromDate = 0;
            cToDate = 0;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            DataTable dtResult = new DataTable();
            dtResult.Columns.Add("transdate");
            dtResult.Columns.Add("reference");
            dtResult.Columns.Add("reference2");
            dtResult.Columns.Add("transtype");
            dtResult.Columns.Add("sales");
            dtResult.Columns.Add("payment");
            dtResult.Columns.Add("running_balance");
            dtResult.Columns.Add("remarks");
            dtResult.Columns.Add("beginning_balance");
            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                string transdate = dgv.Rows[i].Cells["transdate"].Value.ToString(),
                    reference = dgv.Rows[i].Cells["reference"].Value.ToString(),
                    reference2 = dgv.Rows[i].Cells["reference2"].Value.ToString(),
                    transtype = dgv.Rows[i].Cells["transtype"].Value.ToString(),
                    sales = dgv.Rows[i].Cells["amt_in"].Value.ToString(),
                    payment = dgv.Rows[i].Cells["amt_out"].Value.ToString(),
                    runningBalance = dgv.Rows[i].Cells["running_balance"].Value.ToString(),
                    remarks = dgv.Rows[i].Cells["remarks"].Value.ToString(),
                    begBal = lblBalance.Text;
                dtResult.Rows.Add(transdate, reference, reference2, transtype, sales, payment, runningBalance, remarks,begBal);
            }
            CustomerLedger_CR rpt = new CustomerLedger_CR(dtResult,lblCustomerCode.Text);
            rpt.ShowDialog();
        }

        private void dtFromDate_CloseUp(object sender, EventArgs e)
        {
            if (cFromDate <= 0)
            {
                loadData();
            }
        }

        private void dtToDate_CloseUp(object sender, EventArgs e)
        {
            if (cToDate <= 0)
            {
                loadData();
            }
        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv.Rows.Count > 0)
            {
               
                if (e.ColumnIndex == 2 && e.RowIndex >=0)
                {
                    string transType = dgv.CurrentRow.Cells["transtype"].Value.ToString();
                    if (transType.Equals("Payment"))
                    {
                        int intTemp = 0;
                        double doubleTemp = 0.00;
                        SalesPerCustomer_PaidDetails frm = new SalesPerCustomer_PaidDetails();
                        frm.selectedID = int.TryParse(dgv.CurrentRow.Cells["id"].Value.ToString(), out intTemp) ? Convert.ToInt32(dgv.CurrentRow.Cells["id"].Value.ToString()) : intTemp;
                        frm.Text = dgv.CurrentRow.Cells["transtype"].Value.ToString();
                        frm.selectedReference = dgv.CurrentRow.Cells["reference"].Value.ToString();
                        frm.selectedCustCode = lblCustomerCode.Text;
                        frm.ShowDialog();
                    }
                    else if (transType.Equals("Sales"))
                    {
                        int intTemp = 0;
                        SalesTransactions_Items frm = new SalesTransactions_Items();
                        frm.selectedID = int.TryParse(dgv.CurrentRow.Cells["id"].Value.ToString(), out intTemp) ? Convert.ToInt32(dgv.CurrentRow.Cells["id"].Value.ToString()) : intTemp;
                        frm.Text = dgv.CurrentRow.Cells["transtype"].Value.ToString();
                        frm.lblTransdate.Text = dgv.CurrentRow.Cells["transdate"].Value.ToString();
                        frm.lblReference.Text = dgv.CurrentRow.Cells["reference"].Value.ToString();
                        frm.ShowDialog();
                    }else if (transType.Equals("Return"))
                    {
                        int id = 0, intTemp = 0;
                        id = int.TryParse(dgv.CurrentRow.Cells["id"].Value.ToString(), out intTemp) ? Convert.ToInt32(dgv.CurrentRow.Cells["id"].Value.ToString()) : intTemp;
                        SalesReturn_Details frm = new DeliciousPartnerApp.SalesReturn_Details(id);
                        frm.ShowDialog();
                    }
                }
            }
        }

        public void loadData()
        {
            dgv.Rows.Clear();
            if (Login.jsonResult != null)
            {
                Cursor.Current = Cursors.WaitCursor;
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
                    bool isSuccess = false;
                    var client = new RestClient(utilityc.URL);
                    client.Timeout = -1;
                    var request = new RestRequest("/api/report/customer/sales_summary/details/" + lblCustomerCode.Text + "?from_date=" + dtFromDate.Value.ToString("yyyy-MM-dd") + "&to_date=" + dtToDate.Value.ToString("yyyy-MM-dd"));
                    Console.WriteLine("/api/report/customer/sales_summary/details/" + lblCustomerCode.Text + "?from_date=" + dtFromDate.Value.ToString("yyyy-MM-dd") + "&to_date=" + dtToDate.Value.ToString("yyyy-MM-dd"));
                    request.AddHeader("Authorization", "Bearer " + token);
                    request.Method = Method.GET;
                    var response = client.Execute(request);
                    if (response.ErrorMessage == null)
                    {
                        if (response.Content.ToString().Substring(0, 1).Equals("{"))
                        {
                            JObject jObject = JObject.Parse(response.Content.ToString());
                            foreach (var x in jObject)
                            {
                                if (x.Key.Equals("success"))
                                {
                                    if (Convert.ToBoolean(x.Value.ToString()))
                                    {
                                        isSuccess = true;
                                        break;
                                    }
                                }
                            }
                            if (isSuccess)
                            {
                                double totalRunningBalance = 0.00;
                                foreach (var x in jObject)
                                {
                                    if (x.Key.Equals("data"))
                                    {
                                        if (x.Value.ToString() != "{}")
                                        {
                                            JObject data = JObject.Parse(x.Value.ToString());
                                            string ref1 = "", ref2 = "", transType = "", remarks = "", ipNum = "", arNum = "";
                                            double amtIn = 0.00, amtOut = 0.00;
                                            int id = 0;
                                            DateTime dtTransDate = new DateTime();
                                            foreach (var q in data)
                                            {
                                                if (q.Key.Equals("bal_result"))
                                                {
                                                    JObject balResult = JObject.Parse(q.Value.ToString());
                                                    foreach (var w in balResult)
                                                    {
                                                        totalRunningBalance = string.IsNullOrEmpty(w.Value.ToString().Trim()) ? 0.00 : Convert.ToDouble(w.Value.ToString());
                                                        lblBalance.Text = totalRunningBalance.ToString("n2");
                                                    }
                                                }
                                                else if (q.Key.Equals("row_result"))
                                                {
                                                    JArray jsonArray = JArray.Parse(q.Value.ToString());
                                                    for (int i = 0; i < jsonArray.Count(); i++)
                                                    {
                                                        JObject rowResult = JObject.Parse(jsonArray[i].ToString());
                                                        foreach (var w in rowResult)
                                                        {
                                                            if (w.Key.Equals("id"))
                                                            {
                                                                id = w.Value.ToString() == "" ? 0 : Convert.ToInt32(w.Value.ToString());
                                                            }
                                                            if (w.Key.Equals("reference"))
                                                            {
                                                                ref1 = w.Value.ToString();
                                                            }
                                                            else if (w.Key.Equals("reference2"))
                                                            {
                                                                ref2 = w.Value.ToString();
                                                            }
                                                            else if (w.Key.Equals("transtype"))
                                                            {
                                                                transType = w.Value.ToString();
                                                            }
                                                            else if (w.Key.Equals("amount_in"))
                                                            {
                                                                amtIn = string.IsNullOrEmpty(w.Value.ToString().Trim()) ? 0.00 : Convert.ToDouble(w.Value.ToString());
                                                            }
                                                            else if (w.Key.Equals("amount_out"))
                                                            {
                                                                amtOut = string.IsNullOrEmpty(w.Value.ToString().Trim()) ? 0.00 : Convert.ToDouble(w.Value.ToString());
                                                            }
                                                            else if (w.Key.Equals("transdate"))
                                                            {
                                                                dtTransDate = Convert.ToDateTime(w.Value.ToString());
                                                            }
                                                            else if (w.Key.Equals("remarks"))
                                                            {
                                                                remarks = w.Value.ToString();
                                                            }
                                                            else if (w.Key.Equals("ip_num"))
                                                            {
                                                                ipNum = w.Value.ToString();
                                                            }
                                                            else if (w.Key.Equals("ar_num"))
                                                            {
                                                                arNum = w.Value.ToString();
                                                            }
                                                        }
                                                        totalRunningBalance += amtIn;
                                                        totalRunningBalance -= amtOut;
                                                        dgv.Rows.Add(id, dtTransDate.ToString("yyyy-MM-dd"), ref1, ref2, transType, Convert.ToDecimal(string.Format("{0:0.00}", amtIn)), Convert.ToDecimal(string.Format("{0:0.00}", amtOut)), Convert.ToDecimal(string.Format("{0:0.00}", totalRunningBalance)), arNum, ipNum, remarks);
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show(response.Content.ToString(), "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                        else
                        {
                            JObject jObject = JObject.Parse(response.Content.ToString());
                            string msg = "";
                            foreach (var x in jObject)
                            {
                                if (x.Key.Equals("message"))
                                {
                                    msg = x.Value.ToString();
                                }
                            }
                            if (msg.Equals("Token is invalid"))
                            {
                                MessageBox.Show("Your login session is expired. Please login again", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                            else
                            {
                                MessageBox.Show(msg, "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show(response.ErrorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                }
            }
            foreach (DataGridViewColumn col in dgv.Columns)
            {
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                int colw = col.Width;
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                col.Width = colw;
            }
        }

    }
}
