using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeliciousPartnerApp.UI_Class;
using System.Data;
using System.Windows.Forms;

namespace DeliciousPartnerApp.API_Class.POS
{
    class sales_class
    {
        utility_class utilityc = new utility_class();
        public DataTable loadInventoryStock()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("item_code");
            dt.Columns.Add("item_group");
            dt.Columns.Add("quantity");
            dt.Columns.Add("price");
            dt.Columns.Add("uom");
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
                    //string branch = "A1-S";
                    var request = new RestRequest("/api/inv/whseinv/getall");
                    Console.WriteLine("/api/inv/whseinv/getall");
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
                                        double price = 0.00, quantity = 0.00;
                                        string itemCode = "", itemGroup = "", uOm = "";
                                        foreach (var q in data)
                                        {
                                            if (q.Key.Equals("price"))
                                            {
                                                price = q.Value.ToString() == "" ? 0.00 : Convert.ToDouble(q.Value.ToString());
                                            }
                                            else if (q.Key.Equals("uom"))
                                            {
                                                uOm = q.Value.ToString();
                                            }
                                            else if (q.Key.Equals("item_group"))
                                            {
                                                itemGroup = q.Value.ToString();
                                            }
                                            else if (q.Key.Equals("item_code"))
                                            {
                                                itemCode = q.Value.ToString();
                                            }
                                            else if (q.Key.Equals("quantity"))
                                            {
                                                quantity = q.Value.ToString() == "" ? 0.00 : Convert.ToDouble(q.Value.ToString());
                                            }
                                        }
                                        dt.Rows.Add(itemCode, itemGroup, quantity, price, uOm);
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
                        MessageBox.Show(msg, "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            return dt;
        }
    }
}
