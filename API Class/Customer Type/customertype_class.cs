using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DeliciousPartnerApp.UI_Class;
using Newtonsoft.Json.Linq;
using RestSharp;
using System.Data;
namespace DeliciousPartnerApp.API_Class.Customer_Type
{
    class customertype_class
    {
        utility_class utilityc = new utility_class();

        public DataTable loadCustomerTypes()
        {
            DataTable dt = new DataTable();
            if (Login.jsonResult != null)
            {
                dt.Columns.Add("id");
                dt.Columns.Add("code");
                dt.Columns.Add("name");
                dt.Columns.Add("date_created");
                dt.Columns.Add("date_updated");
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
                    var request = new RestRequest("/api/custtype/get_all");
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

                                        string code = "", name = "", date_created = "", date_updated = "";
                                        foreach (var q in data)
                                        {
                                            if (q.Key.Equals("id"))
                                            {
                                                id = Convert.ToInt32(q.Value.ToString());
                                            }
                                            else if (q.Key.Equals("code"))
                                            {
                                                code = q.Value.ToString();
                                            }
                                            else if (q.Key.Equals("name"))
                                            {
                                                name = q.Value.ToString();
                                            }
                                            else if (q.Key.Equals("date_created"))
                                            {
                                                date_created = q.Value.ToString();
                                            }
                                            else if (q.Key.Equals("date_updated"))
                                            {
                                                date_updated = q.Value.ToString();
                                            }
                                        }
                                        dt.Rows.Add(id, code, name, date_created, date_updated);
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
