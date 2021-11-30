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
using AB.UI_Class;
using Newtonsoft.Json.Linq;
namespace AB
{
    public partial class CustomerLedger_Details : Form
    {
        public CustomerLedger_Details()
        {
            InitializeComponent();
        }
        utility_class utilityc = new utility_class();
        int cFromDate = 1, cToDate = 1;
        private void SalesPerCustomer_Details_Load(object sender, EventArgs e)
        {
            dtFromDate.Value = DateTime.Now;
            dtToDate.Value = DateTime.Now;
            loadData();
            cFromDate = 0;
            cToDate = 0;
        }

        private void dtFromDate_ValueChanged(object sender, EventArgs e)
        {
            if (cFromDate <= 0)
            {
                loadData();
            }
        }

        private void dtToDate_ValueChanged(object sender, EventArgs e)
        {
            if (cToDate <= 0)
            {
                loadData();
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
                    Console.WriteLine("RESULT: " + response.Content.ToString());
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
                                            string ref1 = "", ref2 = "", transType = "", remaks = "";
                                            double amtIn = 0.00, amtOut = 0.00;
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
                                                                remaks = w.Value.ToString();
                                                            }
                                                        }
                                                        totalRunningBalance += amtIn;
                                                        totalRunningBalance -= amtOut;
                                                        dgv.Rows.Add(dtTransDate.ToString("yyyy-MM-dd"), ref1, ref2, transType, Convert.ToDecimal(string.Format("{0:0.00}", amtIn)), Convert.ToDecimal(string.Format("{0:0.00}", amtOut)), Convert.ToDecimal(string.Format("{0:0.00}", totalRunningBalance)),remaks);
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
        }

    }
}
