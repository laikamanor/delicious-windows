using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;
using DeliciousPartnerApp.UI_Class;
using RestSharp;
using Newtonsoft.Json.Linq;

namespace DeliciousPartnerApp.API_Class.Reports
{
    class finalCount_class
    {
        public DataTable loadFinalCount(DateTime dateEntered, string branchCode)
        {
            utility_class utilityc = new utility_class();
            DataTable dt = new DataTable();
            if (Login.jsonResult != null)
            {
                dt.Columns.Clear();
                dt.Columns.Add("item_code", typeof(string));
                dt.Columns.Add("quantity", typeof(double));
                dt.Columns.Add("ending_sales_count", typeof(double));
                dt.Columns.Add("ending_auditor_count", typeof(double));
                dt.Columns.Add("ending_manager_count", typeof(double));
                dt.Columns.Add("ending_final_count", typeof(double));
                dt.Columns.Add("po_sales_count", typeof(double));
                dt.Columns.Add("po_auditor_count", typeof(double));
                dt.Columns.Add("po_manager_count", typeof(double));
                dt.Columns.Add("po_final_count", typeof(double));
                dt.Columns.Add("variance", typeof(double));
                dt.Columns.Add("uom", typeof(string));

                dt.Columns.Add("sales_user", typeof(string));
                dt.Columns.Add("auditor_user", typeof(string));
                dt.Columns.Add("manager_user", typeof(string));

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
                    Cursor.Current = Cursors.WaitCursor;
                    var client = new RestClient(utilityc.URL);
                    client.Timeout = -1;
                    //string branch = (cmbBranch.Text.Equals("") || cmbBranch.Text == "All" ? "" : cmbBranch.Text);
                    var request = new RestRequest("/api/report/final_count?transdate=" + dateEntered.ToString("yyyy-MM-dd") + "&branch=" + branchCode);
                    request.AddHeader("Authorization", "Bearer " + token);
                    var response = client.Execute(request);
                    JObject jObject = new JObject();
                    jObject = JObject.Parse(response.Content.ToString());
                    bool isSuccess = false;
                    foreach (var x in jObject)
                    {
                        if (x.Key.Equals("success"))
                        {
                            isSuccess = Convert.ToBoolean(x.Value.ToString());
                        }
                    }
                    string sales_user = "", manager_user = "", auditor_user = "";
                    if (isSuccess)
                    {
                        foreach (var x in jObject)
                        {
                            if (x.Key.Equals("data"))
                            {
                                if (x.Value.ToString() != "{}")
                                {
                                    JObject joData = new JObject();
                                    joData = JObject.Parse(x.Value.ToString());
                                    foreach (var y in joData)
                                    {
                                        if (y.Key.Equals("sales_user"))
                                        {
                                            sales_user = y.Value.ToString();
                                        }
                                        else if (y.Key.Equals("auditor_user"))
                                        {
                                            auditor_user = y.Value.ToString();
                                        }
                                        else if (y.Key.Equals("manager_user"))
                                        {
                                            manager_user = y.Value.ToString();
                                        }
                                    }
                                }
                            }
                        }
                    }

                    if (isSuccess)
                    {
                        foreach (var x in jObject)
                        {
                            if (x.Key.Equals("data"))
                            {
                                if (x.Value.ToString() != "{}")
                                {
                                    JObject joData = new JObject();
                                    joData = JObject.Parse(x.Value.ToString());
                                    foreach (var y in joData)
                                    {
                                        if (y.Key.Equals("row"))
                                        {
                                            if (y.Value.ToString() != "[]")
                                            {
                                                JArray jsonArray = JArray.Parse(y.Value.ToString());
                                                for (int i = 0; i < jsonArray.Count(); i++)
                                                {
                                                    JObject data = JObject.Parse(jsonArray[i].ToString());

                                                    string itemCode = "", uom = "";
                                                    double quantity = 0.00, ending_sales_count = 0.00, ending_auditor_count = 0.00, ending_manager_count = 0.00, ending_final_count = 0.00, po_sales_count = 0.00, po_auditor_count = 0.00, po_manager_count = 0.00, po_final_count = 0.00, variance = 0.00;
                                                    foreach (var q in data)
                                                    {
                                                        if (q.Key.Equals("item_code"))
                                                        {
                                                            itemCode = q.Value.ToString();
                                                        }
                                                        else if (q.Key.Equals("uom"))
                                                        {
                                                            uom = q.Value.ToString();
                                                        }
                                                        else if (q.Key.Equals("quantity"))
                                                        {
                                                            quantity = Convert.ToDouble(q.Value.ToString());
                                                        }
                                                        else if (q.Key.Equals("ending_sales_count"))
                                                        {
                                                            ending_sales_count = Convert.ToDouble(q.Value.ToString());
                                                        }
                                                        else if (q.Key.Equals("ending_auditor_count"))
                                                        {
                                                            ending_auditor_count = Convert.ToDouble(q.Value.ToString());
                                                        }
                                                        else if (q.Key.Equals("ending_manager_count"))
                                                        {
                                                            ending_manager_count = Convert.ToDouble(q.Value.ToString());
                                                        }
                                                        else if (q.Key.Equals("ending_final_count"))
                                                        {
                                                            ending_final_count = Convert.ToDouble(q.Value.ToString());
                                                        }
                                                        else if (q.Key.Equals("po_sales_count"))
                                                        {
                                                            po_sales_count = Convert.ToDouble(q.Value.ToString());
                                                        }
                                                        else if (q.Key.Equals("po_auditor_count"))
                                                        {
                                                            po_auditor_count = Convert.ToDouble(q.Value.ToString());
                                                        }
                                                        else if (q.Key.Equals("po_manager_count"))
                                                        {
                                                            po_manager_count = Convert.ToDouble(q.Value.ToString());
                                                        }
                                                        else if (q.Key.Equals("po_final_count"))
                                                        {
                                                            po_final_count = Convert.ToDouble(q.Value.ToString());
                                                        }
                                                        else if (q.Key.Equals("variance"))
                                                        {
                                                            variance = Convert.ToDouble(q.Value.ToString());
                                                        }
                                                    }
                                                    //MessageBox.Show(auditor_user + Environment.NewLine + manager_user);
                                                    dt.Rows.Add(itemCode, quantity, ending_sales_count, ending_auditor_count, ending_manager_count, ending_final_count, po_sales_count, po_auditor_count, po_manager_count, po_final_count, variance, uom, sales_user, auditor_user, manager_user);
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        string msg = "No message response found";
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
                    Cursor.Current = Cursors.Default;
                }
            }

            //foreach(DataRow row in dt.Rows)
            //{
            //    MessageBox.Show(row["auditor_user"].ToString() + Environment.NewLine + row["manager_user"].ToString());
            //}

            return dt;
        }

        public DataTable loadCustomerDetails()
        {
            DataTable dt = new DataTable();
            return dt;
        }

        public DataTable loadPaymentMethod(DateTime dateEntered, string type,string branchCode)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("transtype", typeof(string));
            dt.Columns.Add("cash_sales", typeof(double));
            dt.Columns.Add("ar_sales", typeof(double));
            dt.Columns.Add("agent_sales", typeof(double));
            dt.Columns.Add("total", typeof(double));
            utility_class utilityc = new utility_class();
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
                    var client = new RestClient(utilityc.URL);
                    client.Timeout = -1;
                    string sURL = type.Equals("Final Report") ? "/api/report/final_report" : "/api/sales/final_report";
                    var request = new RestRequest(sURL + "?transdate=" + dateEntered.ToString("yyyy-MM-dd") + "&branch=" + branchCode);
                    Console.WriteLine(sURL + "?transdate=" + dateEntered.ToString("yyyy-MM-dd") + "&branch=" + branchCode);
                    request.AddHeader("Authorization", "Bearer " + token);
                    var response = client.Execute(request);
                    JObject jObject = new JObject();
                    jObject = JObject.Parse(response.Content.ToString());
                    bool isSuccess = false;
                    foreach (var x in jObject)
                    {
                        if (x.Key.Equals("success"))
                        {
                            isSuccess = Convert.ToBoolean(x.Value.ToString());
                        }
                    }

                    if (isSuccess)
                    {
                        foreach (var x in jObject)
                        {
                            if (x.Key.Equals("data"))
                            {
                                if (x.Value.ToString() != "{}")
                                {
                                    JObject joData = new JObject();
                                    joData = JObject.Parse(x.Value.ToString());
                                    foreach (var y in joData)
                                    {
                                        if (y.Key.Equals("payment_method"))
                                        {
                                            if (y.Value.ToString() != "[]")
                                            {
                                                JArray jsonArray = JArray.Parse(y.Value.ToString());
                                                string transtype = "";
                                                double cash_sales = 0.00, ar_sales = 0.00, agent_sales = 0.00, total = 0.00;
                                                for (int i = 0; i < jsonArray.Count(); i++)
                                                {
                                                    JObject data = JObject.Parse(jsonArray[i].ToString());
                                                    foreach (var q in data)
                                                    {
                                                        if (q.Key.Equals("transtype"))
                                                        {
                                                            transtype = q.Value.ToString();
                                                        }
                                                        else if (q.Key.Equals("cash_sales"))
                                                        {
                                                            cash_sales = Convert.ToDouble(q.Value.ToString());
                                                        }
                                                        else if (q.Key.Equals("ar_sales"))
                                                        {
                                                            ar_sales = Convert.ToDouble(q.Value.ToString());
                                                        }
                                                        else if (q.Key.Equals("agent_sales"))
                                                        {
                                                            agent_sales = Convert.ToDouble(q.Value.ToString());
                                                        }
                                                        else if (q.Key.Equals("total"))
                                                        {
                                                            total = Convert.ToDouble(q.Value.ToString());
                                                        }
                                                    }
                                                    dt.Rows.Add(transtype, cash_sales, ar_sales, agent_sales,total);
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }

                }
            }
            return dt;
        }

        public DataTable loadEmployeeCharge(DateTime dateEntered, string type, string branchCode)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("reference", typeof(string));
            dt.Columns.Add("transdate", typeof(string));
            dt.Columns.Add("cust_code", typeof(string));
            dt.Columns.Add("gl_account", typeof(string));
            dt.Columns.Add("doctotal", typeof(double));
            utility_class utilityc = new utility_class();
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
                    var client = new RestClient(utilityc.URL);
                    client.Timeout = -1;
                    string sURL = type.Equals("Final Report") ? "/api/report/final_report" : "/api/sales/final_report";
                    var request = new RestRequest(sURL + "?transdate=" + dateEntered.ToString("yyyy-MM-dd") + "&branch=" + branchCode);
                    Console.WriteLine(sURL + "?transdate=" + dateEntered.ToString("yyyy-MM-dd") + "&branch=" + branchCode);
                    request.AddHeader("Authorization", "Bearer " + token);
                    var response = client.Execute(request);
                    JObject jObject = new JObject();
                    jObject = JObject.Parse(response.Content.ToString());
                    bool isSuccess = false;
                    foreach (var x in jObject)
                    {
                        if (x.Key.Equals("success"))
                        {
                            isSuccess = Convert.ToBoolean(x.Value.ToString());
                        }
                    }

                    if (isSuccess)
                    {
                        foreach (var x in jObject)
                        {
                            if (x.Key.Equals("data"))
                            {
                                if (x.Value.ToString() != "{}")
                                {
                                    JObject joData = new JObject();
                                    joData = JObject.Parse(x.Value.ToString());
                                    foreach (var y in joData)
                                    {
                                        if (y.Key.Equals("ar_charge"))
                                        {
                                            if (y.Value.ToString() != "[]")
                                            {
                                                JArray jsonArray = JArray.Parse(y.Value.ToString());
                                                string reference = "", custCode = "", glAccount = "";
                                                DateTime dtTransDate = new DateTime();
                                                double docTotal = 0.00;
                                                for (int i = 0; i < jsonArray.Count(); i++)
                                                {
                                                    JObject data = JObject.Parse(jsonArray[i].ToString());
                                                    foreach (var q in data)
                                                    {
                                                        if (q.Key.Equals("reference"))
                                                        {
                                                            reference = q.Value.ToString();
                                                        }
                                                        else if (q.Key.Equals("transdate"))
                                                        {
                                                            string replaceT = q.Value.ToString().Replace("T", "");
                                                            dtTransDate = Convert.ToDateTime(replaceT);
                                                        }
                                                        else if (q.Key.Equals("cust_code"))
                                                        {
                                                            custCode = q.Value.ToString();
                                                        }
                                                        else if (q.Key.Equals("gl_account"))
                                                        {
                                                            glAccount = q.Value.ToString();
                                                        }
                                                        else if (q.Key.Equals("doctotal"))
                                                        {
                                                            docTotal = q.Value.ToString() == "" ? 0.00 : Convert.ToDouble(q.Value.ToString());
                                                        }
                                                    }
                                                    dt.Rows.Add(reference, dtTransDate.ToString("yyyy-MM-dd HH:mm"), custCode, glAccount, docTotal);
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }

                }
            }
            return dt;
        }


        public DataTable loadDiscountTypeSummary(DateTime dateEntered, string type, string branchCode)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("disctype", typeof(string));
            dt.Columns.Add("total", typeof(double));
            utility_class utilityc = new utility_class();
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
                    var client = new RestClient(utilityc.URL);
                    client.Timeout = -1;
                    string sURL = type.Equals("Final Report") ? "/api/report/final_report" : "/api/sales/final_report";
                    var request = new RestRequest(sURL + "?transdate=" + dateEntered.ToString("yyyy-MM-dd") + "&branch=" + branchCode);
                    request.AddHeader("Authorization", "Bearer " + token);
                    var response = client.Execute(request);
                    Console.WriteLine(response.Content.ToString());
                    JObject jObject = new JObject();
                    jObject = JObject.Parse(response.Content.ToString());
                    bool isSuccess = false;
                    foreach (var x in jObject)
                    {
                        if (x.Key.Equals("success"))
                        {
                            isSuccess = Convert.ToBoolean(x.Value.ToString());
                        }
                    }

                    if (isSuccess)
                    {
                        foreach (var x in jObject)
                        {
                            if (x.Key.Equals("data"))
                            {
                                if (x.Value.ToString() != "{}")
                                {
                                    JObject joData = new JObject();
                                    joData = JObject.Parse(x.Value.ToString());
                                    foreach (var y in joData)
                                    {
                                        if (y.Key.Equals("discount_summary"))
                                        {
                                            if (y.Value.ToString() != "[]")
                                            {
                                                JArray jsonArray = JArray.Parse(y.Value.ToString());
                                                string discType = "";
                                                double total = 0.00, doubleTemp = 0.00;
                                                for (int i = 0; i < jsonArray.Count(); i++)
                                                {
                                                    JObject data = JObject.Parse(jsonArray[i].ToString());
                                                    foreach (var q in data)
                                                    {
                                                        if (q.Key.Equals("description"))
                                                        {
                                                            discType = q.Value.ToString();
                                                        }
                                                        else if (q.Key.Equals("total"))
                                                        {
                                                            total = double.TryParse(q.Value.ToString(), out doubleTemp) ? Convert.ToDouble(q.Value.ToString()) : 0.00;
                                                        }
                                                    }
                                                    Console.WriteLine(discType + "/" + total);
                                                    dt.Rows.Add(discType, total);
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }

                }
            }
            return dt;
        }



        public DataTable loadFinal(DateTime dateEntered, string type, string branchCode)
        {
            utility_class utilityc = new utility_class();
            DataTable dt = new DataTable();
            if (Login.jsonResult != null)
            {
                //CASH

                dt.Columns.Add("total_cash_on_hand", typeof(double));
                dt.Columns.Add("total_cash_payment", typeof(double));
                dt.Columns.Add("total_cash_deposit", typeof(double));
                dt.Columns.Add("total_used_dep_payment", typeof(double));
                dt.Columns.Add("total_bank_dep_payment", typeof(double));
                dt.Columns.Add("total_epay_payment", typeof(double));
                dt.Columns.Add("total_gcert_payment", typeof(double));
                //SALES
                dt.Columns.Add("gross", typeof(double));
                dt.Columns.Add("net_sales", typeof(double));
                dt.Columns.Add("disc_amount", typeof(double));
                dt.Columns.Add("gross_cash_sales", typeof(double));
                dt.Columns.Add("disc_cash_sales", typeof(double));
                dt.Columns.Add("net_cash_sales", typeof(double));
                dt.Columns.Add("gross_ar_sales", typeof(double));
                dt.Columns.Add("disc_ar_sales", typeof(double));
                dt.Columns.Add("net_ar_sales", typeof(double));
                dt.Columns.Add("gross_agent_sales", typeof(double));
                dt.Columns.Add("disc_agent_sales", typeof(double));
                dt.Columns.Add("net_agent_sales", typeof(double));

                //ITEMS
               if(type.Equals("Final Report"))
                {
                    dt.Columns.Add("item_code", typeof(string));
                    dt.Columns.Add("actual_good", typeof(double));
                    dt.Columns.Add("actual_pullout", typeof(double));
                    dt.Columns.Add("system_bal", typeof(double));
                    dt.Columns.Add("variance", typeof(double));
                    dt.Columns.Add("price", typeof(double));
                    dt.Columns.Add("total_amount", typeof(double));


                    dt.Columns.Add("CPTransType", typeof(string));
                    dt.Columns.Add("CPCashSales", typeof(double));
                    dt.Columns.Add("CPARSales", typeof(double));
                    dt.Columns.Add("CPAgentSales", typeof(double));

                    dt.Columns.Add("EPAYTransType", typeof(string));
                    dt.Columns.Add("EPAYCashSales", typeof(double));
                    dt.Columns.Add("EPAYARSales", typeof(double));
                    dt.Columns.Add("EPAYAgentSales", typeof(double));

                    dt.Columns.Add("BDTransType", typeof(string));
                    dt.Columns.Add("BDCashSales", typeof(double));
                    dt.Columns.Add("BDARSales", typeof(double));
                    dt.Columns.Add("BDAgentSales", typeof(double));
                }

                dt.Columns.Add("actual_cash", typeof(double));
                if (type.Equals("Final Report"))
                {
                    dt.Columns.Add("remarks", typeof(string));
                }
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
                    Cursor.Current = Cursors.WaitCursor;
                    var client = new RestClient(utilityc.URL);
                    client.Timeout = -1;
                    string sURL = type.Equals("Final Report") ? "/api/report/final_report" : "/api/sales/final_report";
                    var request = new RestRequest(sURL + "?transdate=" + dateEntered.ToString("yyyy-MM-dd") + "&branch=" + branchCode);
                    Console.WriteLine(sURL + "?transdate=" + dateEntered.ToString("yyyy-MM-dd") + "&branch=" + branchCode);
                    request.AddHeader("Authorization", "Bearer " + token);
                    var response = client.Execute(request);
                    JObject jObject = new JObject();
                    jObject = JObject.Parse(response.Content.ToString());
                    bool isSuccess = false;
                    foreach (var x in jObject)
                    {
                        if (x.Key.Equals("success"))
                        {
                            isSuccess = Convert.ToBoolean(x.Value.ToString());
                        }
                    }
                    string CPTransType = "", EPAYTransType = "", BDTransType = "";
                    double CPCashSales = 0.00, CPARSales = 0.00, CPAgentSales = 0.00,
                        EPAYCashSales = 0.000, EPAYARSales = 0.00, EPAYAgentSales = 0.00,
                        BDCashSales = 0.00, BDARSales = 0.00, BDAgentSales = 0.00;
                    if (isSuccess)
                    {
                        foreach (var x in jObject)
                        {
                            if (x.Key.Equals("data"))
                            {
                                if (x.Value.ToString() != "{}")
                                {
                                    JObject joData = new JObject();
                                    joData = JObject.Parse(x.Value.ToString());
                                    foreach (var y in joData)
                                    {
                                        if (y.Key.Equals("payment_method"))
                                        {
                                            if (y.Value.ToString() != "[]")
                                            {
                                                JArray jsonArray = JArray.Parse(y.Value.ToString());
                                                for (int i = 0; i < jsonArray.Count(); i++)
                                                {
                                                    JObject data = JObject.Parse(jsonArray[i].ToString());
                                                    foreach (var q in data)
                                                    {
                                                        if (i.Equals(0))
                                                        {
                                                            if (q.Key.Equals("transtype"))
                                                            {
                                                                CPTransType = q.Value.ToString();
                                                            }
                                                            else if (q.Key.Equals("cash_sales"))
                                                            {
                                                                CPCashSales = Convert.ToDouble(q.Value.ToString());
                                                            }
                                                            else if (q.Key.Equals("ar_sales"))
                                                            {
                                                                CPARSales = Convert.ToDouble(q.Value.ToString());
                                                            }
                                                            else if (q.Key.Equals("agent_sales"))
                                                            {
                                                                CPAgentSales = Convert.ToDouble(q.Value.ToString());
                                                            }
                                                        }
                                                        else if (i.Equals(1))
                                                        {
                                                            if (q.Key.Equals("transtype"))
                                                            {
                                                                EPAYTransType = q.Value.ToString();
                                                            }
                                                            else if (q.Key.Equals("cash_sales"))
                                                            {
                                                                EPAYCashSales = Convert.ToDouble(q.Value.ToString());
                                                            }
                                                            else if (q.Key.Equals("ar_sales"))
                                                            {
                                                                EPAYARSales = Convert.ToDouble(q.Value.ToString());
                                                            }
                                                            else if (q.Key.Equals("agent_sales"))
                                                            {
                                                                EPAYAgentSales = Convert.ToDouble(q.Value.ToString());
                                                            }
                                                        }
                                                        else if (i.Equals(2))
                                                        {
                                                            if (q.Key.Equals("transtype"))
                                                            {
                                                                BDTransType = q.Value.ToString();
                                                            }
                                                            else if (q.Key.Equals("cash_sales"))
                                                            {
                                                                BDCashSales = Convert.ToDouble(q.Value.ToString());
                                                            }
                                                            else if (q.Key.Equals("ar_sales"))
                                                            {
                                                                BDARSales = Convert.ToDouble(q.Value.ToString());
                                                            }
                                                            else if (q.Key.Equals("agent_sales"))
                                                            {
                                                                BDAgentSales = Convert.ToDouble(q.Value.ToString());
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }

                    if (isSuccess)
                    {
                        foreach (var x in jObject)
                        {
                            if (x.Key.Equals("data"))
                            {
                                if (x.Value.ToString() != "{}")
                                {
                                    JObject joData = new JObject();
                                    joData = JObject.Parse(x.Value.ToString());
                                    //CASH
                                    double totalCashOnHand = 0.00, totalCashPayment = 0.00, totalCashDeposit = 0.00, totalUsedDepositPayment = 0.00, totalBankDepositPayment = 0.00, totalEpayPayment = 0.00, totalGcPayment = 0.00;
                                    //SALES
                                    double gross = 0.00, netSales = 0.00, discAmount = 0.00, grossCashSales = 0.00, discCashSales = 0.00, netCashSales = 0.00, grossARSales = 0.00, discARSales = 0.00, netARSales = 0.00, grossAgentSales = 0.00, discAgentSales = 0.00, netAgentSales = 0.00;



                                    foreach (var y in joData)
                                    {

                                        if (y.Key.Equals("cash"))
                                        {
                                            if (y.Value.ToString() != "[]")
                                            {
                                                JArray jsonArray = JArray.Parse(y.Value.ToString());
                                                for (int i = 0; i < jsonArray.Count(); i++)
                                                {
                                                    JObject data = JObject.Parse(jsonArray[i].ToString());
                                                    foreach (var q in data)
                                                    {
                                                        if (q.Key.Equals("total_cash_on_hand"))
                                                        {
                                                            totalCashOnHand = (q.Value.ToString() == "" ? 0.00 : Convert.ToDouble(q.Value.ToString()));
                                                        }
                                                        else if (q.Key.Equals("total_cash_payment"))
                                                        {
                                                            totalCashPayment = (q.Value.ToString() == "" ? 0.00 : Convert.ToDouble(q.Value.ToString()));
                                                        }
                                                        else if (q.Key.Equals("total_cash_deposit"))
                                                        {
                                                            totalCashDeposit = (q.Value.ToString() == "" ? 0.00 : Convert.ToDouble(q.Value.ToString()));
                                                        }
                                                        else if (q.Key.Equals("total_cash_deposit"))
                                                        {
                                                            totalCashDeposit = (q.Value.ToString() == "" ? 0.00 : Convert.ToDouble(q.Value.ToString()));
                                                        }
                                                        else if (q.Key.Equals("total_used_dep_payment"))
                                                        {
                                                            totalUsedDepositPayment = (q.Value.ToString() == "" ? 0.00 : Convert.ToDouble(q.Value.ToString()));
                                                        }
                                                        else if (q.Key.Equals("total_bank_dep_payment"))
                                                        {
                                                            totalBankDepositPayment = (q.Value.ToString() == "" ? 0.00 : Convert.ToDouble(q.Value.ToString()));
                                                        }
                                                        else if (q.Key.Equals("total_epay_payment"))
                                                        {
                                                            totalEpayPayment = (q.Value.ToString() == "" ? 0.00 : Convert.ToDouble(q.Value.ToString()));
                                                        }
                                                        else if (q.Key.Equals("total_gcert_payment"))
                                                        {
                                                            totalGcPayment = (q.Value.ToString() == "" ? 0.00 : Convert.ToDouble(q.Value.ToString()));
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                        if (y.Key.Equals("sales"))
                                        {
                                            if (y.Value.ToString() != "[]")
                                            {
                                                JArray jsonArray = JArray.Parse(y.Value.ToString());
                                                for (int i = 0; i < jsonArray.Count(); i++)
                                                {
                                                    JObject data = JObject.Parse(jsonArray[i].ToString());
                                                    foreach (var q in data)
                                                    {
                                                        if (q.Key.Equals("gross"))
                                                        {
                                                            gross = (q.Value.ToString() == "" ? 0.00 : Convert.ToDouble(q.Value.ToString()));
                                                        }
                                                        else if (q.Key.Equals("net_sales"))
                                                        {
                                                            netSales = (q.Value.ToString() == "" ? 0.00 : Convert.ToDouble(q.Value.ToString()));
                                                        }
                                                        else if (q.Key.Equals("disc_amount"))
                                                        {
                                                            discAmount = (q.Value.ToString() == "" ? 0.00 : Convert.ToDouble(q.Value.ToString()));
                                                        }
                                                        else if (q.Key.Equals("gross_cash_sales"))
                                                        {
                                                            grossCashSales = (q.Value.ToString() == "" ? 0.00 : Convert.ToDouble(q.Value.ToString()));
                                                        }
                                                        else if (q.Key.Equals("disc_cash_sales"))
                                                        {
                                                            discCashSales = (q.Value.ToString() == "" ? 0.00 : Convert.ToDouble(q.Value.ToString()));
                                                        }
                                                        else if (q.Key.Equals("net_cash_sales"))
                                                        {
                                                            netCashSales = (q.Value.ToString() == "" ? 0.00 : Convert.ToDouble(q.Value.ToString()));
                                                        }
                                                        else if (q.Key.Equals("gross_ar_sales"))
                                                        {
                                                            grossARSales = (q.Value.ToString() == "" ? 0.00 : Convert.ToDouble(q.Value.ToString()));
                                                        }
                                                        else if (q.Key.Equals("disc_ar_sales"))
                                                        {
                                                            discARSales = (q.Value.ToString() == "" ? 0.00 : Convert.ToDouble(q.Value.ToString()));
                                                        }
                                                        else if (q.Key.Equals("net_ar_sales"))
                                                        {
                                                            netARSales = (q.Value.ToString() == "" ? 0.00 : Convert.ToDouble(q.Value.ToString()));
                                                        }
                                                        else if (q.Key.Equals("gross_agent_sales"))
                                                        {
                                                            grossAgentSales = (q.Value.ToString() == "" ? 0.00 : Convert.ToDouble(q.Value.ToString()));
                                                        }
                                                        else if (q.Key.Equals("disc_agent_sales"))
                                                        {
                                                            discAgentSales = (q.Value.ToString() == "" ? 0.00 : Convert.ToDouble(q.Value.ToString()));
                                                        }
                                                        else if (q.Key.Equals("net_agent_sales"))
                                                        {
                                                            netAgentSales = (q.Value.ToString() == "" ? 0.00 : Convert.ToDouble(q.Value.ToString()));
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                        string itemCode = "", remarks = "";
                                        double actualGood = 0.00, actualPullOut = 0.00, systemBal = 0.00, variance = 0.00, price = 0.00, totalAmount = 0.00, actualCash = 0.00;
                                        if (y.Key.Equals("final_inv"))
                                        {
                                            if (y.Value.ToString() != "[]")
                                            {
                                                JArray jsonArray = JArray.Parse(y.Value.ToString());
                                                for (int i = 0; i < jsonArray.Count(); i++)
                                                {
                                                    JObject data = JObject.Parse(jsonArray[i].ToString());
                                                    foreach (var q in data)
                                                    {

                                                        if (q.Key.Equals("item_code"))
                                                        {
  
                                                            itemCode = q.Value.ToString();
                                                        }
                                                        else if (q.Key.Equals("actual_good"))
                                                        {
                                                            actualGood = (q.Value.ToString() == "" ? 0.00 : Convert.ToDouble(q.Value.ToString()));
                                                        }
                                                        else if (q.Key.Equals("actual_pullout"))
                                                        {
                                                            actualPullOut = (q.Value.ToString() == "" ? 0.00 : Convert.ToDouble(q.Value.ToString()));
                                                        }
                                                        else if (q.Key.Equals("system_bal"))
                                                        {
                                                            systemBal = (q.Value.ToString() == "" ? 0.00 : Convert.ToDouble(q.Value.ToString()));
                                                        }
                                                        else if (q.Key.Equals("variance"))
                                                        {
                                                            variance = (q.Value.ToString() == "" ? 0.00 : Convert.ToDouble(q.Value.ToString()));
                                                        }
                                                        else if (q.Key.Equals("price"))
                                                        {
                                                            price = (q.Value.ToString() == "" ? 0.00 : Convert.ToDouble(q.Value.ToString()));
                                                        }
                                                        else if (q.Key.Equals("total_amount"))
                                                        {
                                                            totalAmount = (q.Value.ToString() == "" ? 0.00 : Convert.ToDouble(q.Value.ToString()));
                                                        }
                                                        else if (q.Key.Equals("actual_cash"))
                                                        {
                                                            actualCash = (q.Value.ToString() == "" ? 0.00 : Convert.ToDouble(q.Value.ToString()));
                                                        }
                                                        else if (q.Key.Equals("remarks"))
                                                        {
                                                            remarks = q.Value.ToString();
                                                        }
                                                    }
                                                    dt.Rows.Add(totalCashOnHand, totalCashPayment, totalCashDeposit, totalUsedDepositPayment, totalBankDepositPayment, totalEpayPayment, totalGcPayment, gross, netSales, discAmount, grossCashSales, discCashSales, netCashSales, grossARSales, discARSales, netARSales, grossAgentSales, discAgentSales, netAgentSales, itemCode, actualGood, actualPullOut, systemBal, variance, price, totalAmount, CPTransType, CPCashSales, CPARSales, CPAgentSales, EPAYTransType, EPAYCashSales, EPAYARSales, EPAYAgentSales, BDTransType, BDCashSales, BDARSales, BDAgentSales, actualCash, remarks);
                                                }
                                            }
                                        }
                                        if (y.Key.Equals("actual_cash"))
                                        {
                                            if (type.Equals("Final Sales Report"))
                                            {
                                                actualCash  = (y.Value.ToString() == "" ? 0.00 : Convert.ToDouble(y.Value.ToString()));
                                                dt.Rows.Add(totalCashOnHand, totalCashPayment, totalCashDeposit, totalUsedDepositPayment, totalBankDepositPayment, totalEpayPayment, totalGcPayment, gross, netSales, discAmount, grossCashSales, discCashSales, netCashSales, grossARSales, discARSales, netARSales, grossAgentSales, discAgentSales, netAgentSales, actualCash);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        string msg = "No message response found";
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
                    Cursor.Current = Cursors.Default;
                }
            }
            return dt;
        }
    }
}
