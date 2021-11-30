using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DeliciousPartnerApp.UI_Class;
using System.Data;
using RestSharp;
using Newtonsoft.Json.Linq;

namespace DeliciousPartnerApp.API_Class.Customer
{

    class customer_class
    {
        UI_Class.utility_class utilityc = new utility_class();

        public DataTable loadCustomers(string appendURL)
        {
            DataTable dt = new DataTable();
            if (Login.jsonResult != null)
            {
                dt.Columns.Add("id");
                dt.Columns.Add("code");
                dt.Columns.Add("name");
                dt.Columns.Add("cust_type");
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
                    var request = new RestRequest("/api/customer/get_all" + appendURL);
                    Console.WriteLine("/api/customer/get_all" + appendURL);
                    request.AddHeader("Authorization", "Bearer " + token);
                    var response = client.Execute(request);
                    if (response.ErrorMessage == null)
                    {
                        if (response.Content.Substring(0, 1).Equals("{"))
                        {
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
                                        JArray jsonArray = JArray.Parse(x.Value.ToString());
                                        for (int i = 0; i < jsonArray.Count(); i++)
                                        {
                                            JObject data = JObject.Parse(jsonArray[i].ToString());
                                            string code = "", name = "";
                                            int id = 0, custType = 0;
                                            foreach (var q in data)
                                            {
                                                if (q.Key.Equals("id"))
                                                {
                                                    id = string.IsNullOrEmpty(q.Value.ToString()) ? 0 : Convert.ToInt32(q.Value.ToString());
                                                }
                                                else if (q.Key.Equals("code"))
                                                {
                                                    code = q.Value.ToString();
                                                }
                                                else if (q.Key.Equals("name"))
                                                {
                                                    name = q.Value.ToString();
                                                }
                                                else if (q.Key.Equals("cust_type"))
                                                {
                                                    custType = Convert.ToInt32(q.Value.ToString());
                                                }
                                            }
                                            dt.Rows.Add(id, code, name, custType);
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
            return dt;
        }
    }
}
