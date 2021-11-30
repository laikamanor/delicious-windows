using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DeliciousPartnerApp.UI_Class;
namespace DeliciousPartnerApp.API_Class.Item_Group
{
    class itemgroup_class
    {
        utility_class utilityc = new utility_class();
        public async Task <DataTable> returnItemGroup()
        {
            DataTable dt = new DataTable();
            if (Login.jsonResult != null)
            {
                dt.Columns.Add("id");
                dt.Columns.Add("code");
                dt.Columns.Add("description");
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
                    var request = new RestRequest("/api/item/item_grp/getall");
                    request.AddHeader("Authorization", "Bearer " + token);
                    Task<IRestResponse> t = client.ExecuteAsync(request);
                    t.Wait();
                    var response = await t;
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
                                        string code = "", description = "";
                                        int id = 0;
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
                                                description = q.Value.ToString();
                                            }
                                        }
                                        dt.Rows.Add(id,code, description);
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
            return dt;
        }
    }
}
