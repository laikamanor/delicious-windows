using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeliciousPartnerApp.UI_Class;
using Newtonsoft.Json.Linq;
using System.Data;
using System.Threading;

namespace DeliciousPartnerApp.API_Class.Items
{
    class item_class
    {
        utility_class utilityc = new utility_class();
        public DataTable loadData()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("id");
            dt.Columns.Add("success");
            dt.Columns.Add("message");
            dt.Columns.Add("item_code");
            dt.Columns.Add("item_name");
            dt.Columns.Add("item_group");
            dt.Columns.Add("uom");
            dt.Columns.Add("price");
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
                        //string branch = "A1-S";
                        var request = new RestRequest("/api/item/getall");
                        request.AddHeader("Authorization", "Bearer " + token);
                        //Task<IRestResponse> t = client.ExecuteAsync(request);
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
                                        int id = 0;
                                        string itemName = "", itemCode = "", uOm = "", itemGroup = "";
                                        double pRice = 0.00;
                                        for (int i = 0; i < jsonArray.Count(); i++)
                                        {
                                            JObject data = JObject.Parse(jsonArray[i].ToString());
                                            foreach (var q in data)
                                            {
                                                if (q.Key.Equals("item_code"))
                                                {
                                                    itemCode = q.Value.ToString();
                                                }
                                                else if (q.Key.Equals("item_name"))
                                                {
                                                    itemName = q.Value.ToString();
                                                }
                                                else if (q.Key.Equals("item_group"))
                                                {
                                                    itemGroup = q.Value.ToString();
                                                }
                                                else if (q.Key.Equals("id"))
                                                {
                                                    id = Convert.ToInt32(q.Value.ToString());
                                                }
                                                else if (q.Key.Equals("uom"))
                                                {
                                                    uOm = q.Value.ToString();
                                                }
                                                else if (q.Key.Equals("price"))
                                                {
                                                    pRice = Convert.ToDouble(q.Value.ToString());
                                                }
                                            }
                                            dt.Rows.Add(id, isSuccess, "", itemCode, itemName, itemGroup, uOm, pRice);
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
                            dt.Rows.Add(0, isSuccess, msg, "", "", "", "", "");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                dt.Rows.Add(0, false, ex.Message, "", "", "", "", "");
            }
            return dt;
        }
    }
}
