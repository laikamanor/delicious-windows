using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DeliciousPartnerApp.UI_Class;
using System.Data;
namespace DeliciousPartnerApp.API_Class.Advance_Payment
{
    class advancepayment_class
    {
        utility_class utilityc = new utility_class();

        public DataTable loadData(string status,string type)
        {
            DataTable result = new DataTable();
            result.Columns.Add("id");
            result.Columns.Add("cust_code");
            result.Columns.Add("amount");
            result.Columns.Add("balance");
            result.Columns.Add("remarks");
            result.Columns.Add("sap_number");
            result.Columns.Add("reference");
            result.Columns.Add("status");
            result.Columns.Add("transdate");
            result.Columns.Add("reference2");
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
                    string sUsedDeposit = type.Equals("In Deposit") ? "&used=" : "&used=1";
                    string sURL = type.Equals("Summary Deposit") ? "/api/deposit/summary" : "/api/deposit/get_all?&status=" + status + sUsedDeposit;
                    var request = new RestRequest(sURL);
                    Console.WriteLine(sURL);
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
                                if (x.Value.ToString() != "[]")
                                {
                                    JArray jsonArray = JArray.Parse(x.Value.ToString());
                                    for (int i = 0; i < jsonArray.Count(); i++)
                                    {
                                        JObject data = JObject.Parse(jsonArray[i].ToString());
                                        int id = 0;
                                        string custCode = "",
            remarks = "", referenceNumber = "", aStatus = "", sapNumber = "", referenceNumber2 = "";
                                        double amount = 0.00, balance = 0.00;
                                        DateTime dtTransDate = new DateTime();
                                        foreach (var q in data)
                                        {
                                            if (q.Key.Equals("id"))
                                            {
                                                id = Convert.ToInt32(q.Value.ToString());
                                            }
                                            else if (q.Key.Equals("cust_code"))
                                            {
                                                custCode = q.Value.ToString();
                                            }
                                            else if (q.Key.Equals("amount"))
                                            {
                                                amount = Convert.ToDouble(q.Value.ToString());
                                            }
                                            else if (q.Key.Equals("balance"))
                                            {
                                                balance = Convert.ToDouble(q.Value.ToString());
                                            }
                                            else if (q.Key.Equals("sap_number"))
                                            {
                                                sapNumber = q.Value.ToString();
                                            }
                                            else if (q.Key.Equals("remarks"))
                                            {
                                                remarks = q.Value.ToString();
                                            }
                                            else if (q.Key.Equals("reference"))
                                            {
                                                referenceNumber = q.Value.ToString();
                                            }
                                            else if (q.Key.Equals("reference2"))
                                            {
                                                referenceNumber2 = q.Value.ToString();
                                            }
                                            else if (q.Key.Equals("status"))
                                            {
                                                aStatus = q.Value.ToString();
                                            }
                                            else if (q.Key.Equals("transdate"))
                                            {
                                                string replaceT = q.Value.ToString().Replace("T", "");
                                                dtTransDate = Convert.ToDateTime(replaceT);
                                            }
                                        }
                                        if (aStatus.Equals("O"))
                                        {
                                            aStatus = "Open";
                                        }
                                        else if (aStatus.Equals("C"))
                                        {
                                            aStatus = "Closed";
                                        }
                                        else if (aStatus.Equals("N"))
                                        {
                                            aStatus = "Cancelled";
                                        }
                                        result.Rows.Add(id, custCode, amount, balance, remarks, sapNumber, referenceNumber, aStatus, dtTransDate.ToString("yyyy-MM-dd HH:mm"),referenceNumber2);
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
                }
                Cursor.Current = Cursors.Default;
            }
            return result;
        }
    }
}
