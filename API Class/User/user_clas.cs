using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DeliciousPartnerApp.UI_Class;
using System.Data;
using Newtonsoft.Json.Linq;
using RestSharp;
using Newtonsoft.Json;

namespace DeliciousPartnerApp.API_Class.User
{
    class user_clas
    {
        UI_Class.utility_class utilityc = new utility_class();
        public DataTable returnUsers(string parameters)
        {
            DataTable dt = new DataTable();
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
                    var request = new RestRequest("/api/auth/user/get_all" + parameters);
                    request.AddHeader("Authorization", "Bearer " + token);
                    var response = client.Execute(request);
                    if (response.ErrorMessage == null)
                    {
                        if (response.Content.Substring(0, 1).Equals("{"))
                        {
                            JObject jObject = new JObject();
                            //Console.Write(response.Content.ToString());
                            jObject = JObject.Parse(response.Content.ToString());

                            bool isSuccess = false, boolTemp = false;
                            string data = "";
                            foreach (var x in jObject)
                            {
                                if (x.Key.Equals("success"))
                                {
                                    isSuccess = bool.TryParse(x.Value.ToString(), out boolTemp) ? Convert.ToBoolean(x.Value.ToString()) : boolTemp;
                                }
                                else if (x.Key.Equals("data"))
                                {
                                    data = x.Value.ToString();
                                }
                            }
                            if (isSuccess)
                            {
                                dt = (DataTable)JsonConvert.DeserializeObject(data, (typeof(DataTable)));
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
                Cursor.Current = Cursors.Default;
            }
            return dt;
        }
    }
}
