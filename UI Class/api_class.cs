using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DeliciousPartnerApp.UI_Class
{
    class api_class
    {

        public string loadData(string url, string urlParams, string bodyName, string body, Method method,bool isNeedBearerToken)
        {
            string result = "";
            try
            {
                var client = new RestClient(loadTextFile("URL"));
                client.Timeout = -1;
                var request = new RestRequest(url + urlParams);
                Console.WriteLine(url + urlParams);
                if (isNeedBearerToken)
                {
                    request.AddHeader("Authorization", "Bearer " + loadToken());
                }
                request.Method = method;
                if (method.Equals(Method.POST) || method.Equals(Method.PUT) || method.Equals(Method.DELETE))
                {
                    request.AddParameter(bodyName, body, ParameterType.RequestBody);
                }
                var response = client.Execute(request);
                if (response.ErrorMessage == null)
                {
                    if (response.Content.Substring(0, 1).Equals("{"))
                    {
                        //StringBuilder sb = new StringBuilder();
                        //StringWriter sw = new StringWriter(sb);

                        //using (JsonWriter writer = new JsonTextWriter(sw))
                        //{
                        //    var serializer = new JsonSerializer();
                        //    serializer.Serialize(writer, response.Content);
                        //    string jsonString = JsonSerializer.Serialize(weatherForecast);

                        //}

                        JObject joResponse = JObject.Parse(response.Content);
                        bool isSuccess = false, boolTemp = false;
                        string msg = "";
                        foreach(var q in joResponse)
                        {
                            if (q.Key.Equals("success"))
                            {
                                isSuccess = bool.TryParse(q.Value.ToString(), out boolTemp) ? Convert.ToBoolean(q.Value.ToString()) : boolTemp;
                            }else if (q.Key.Equals("message"))
                            {
                                msg = q.Value.ToString();
                            }
                        }
                        if (!isSuccess)
                        {
                            showCustomMsgBox("Back-end Error", msg);
                        }
                        else
                        {
                            result = response.Content;
                        }
                    }
                    else
                    {
                        showCustomMsgBox("Back-end Error", response.Content);
                    }

                }
                else
                {
                    showCustomMsgBox("Back-end Error", response.ErrorMessage);
                }
            }
            catch (Exception ex)
            {
                showCustomMsgBox(ex.Message, ex.ToString());
            }
            return result;
        }

        public  string encodeValue(string value)
        {
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(value));
        }

        public  string decodeValue(string value)
        {
            return Encoding.UTF8.GetString(Convert.FromBase64String(value));
        }


        public List<string> downloadResourcesName()
        {
            List<string> result = new List<string>()
            {
                "Branch",
                "Warehouse"
            };
            return result;
        }

        public List<string> downloadResourcesPath()
        {
            List<string> result = new List<string>()
            {
                "/api/branch/get_all",
                "/api/whse/get_all"
            };
            return result;
        }

        public string loadTextFile(string value)
        {
            string result = "";
            try {
                result = System.IO.File.ReadAllText(value + ".txt");
            }
            catch(Exception ex)
            {
                showCustomMsgBox(ex.Message, ex.ToString());
            }
            return result;
        }

        public DataTable getDtDownloadResources(string result, string arrayName)
        {
            utility_class utilityc = new utility_class();
            DataTable dt = new DataTable();
            try
            {
                JObject joResult = JObject.Parse(result);
                JArray jData = (JArray)joResult[arrayName];
                dt = (DataTable)JsonConvert.DeserializeObject(jData.ToString(), (typeof(DataTable)));
            }
            catch(Exception ex)
            {
                showCustomMsgBox(ex.Message,ex.ToString());
            }
            return dt;
        }

        public string loadToken()
        {
            string token = "";
            try
            {
                foreach (var x in Login.jsonResult)
                {
                    if (x.Key.Equals("token"))
                    {
                        token = x.Value.ToString();
                    }
                }
            }
            catch(Exception ex)
            {
                showCustomMsgBox(ex.Message, ex.ToString());
            }
            return token;
        }

        public string getFirstRowDownloadResources(DataTable dt, string arrayName)
        {
            string result = "";
            if (dt.Rows.Count > 0)
            {
                DataRow row1 = dt.Rows[0];
                result = row1[arrayName].ToString();
            }
            else
            {
                showCustomMsgBox("Validation", "No resources found!");
            }
            return result;
        }

        public void showCustomMsgBox(string title, string body)
        {
            customMessageBox frm = new customMessageBox();
            frm.lblTitle.Text = title;
            frm.lblBody.Text = body;
            frm.ShowDialog();
        }


        public string findValueInDataTable(DataTable dt, string valueCondition, string valueConditionName, string valueFind)
        {
            string result = "";
            foreach (DataRow row in dt.Rows)
            {
                if (valueCondition.Equals(row[valueConditionName].ToString()))
                {
                    result = row[valueFind].ToString();
                }
            }
            return result;
        }

        public bool haveAccessAdmin()
        {
            JObject joLogin = Login.jsonResult;
            string[] lists = { "isAdmin", "isSuperAdmin" };
            int counterInt = 0;
            bool boolTemp = false;
            foreach (string a in lists)
            {
                bool b = bool.TryParse((string)joLogin["data"][a], out boolTemp) ? (bool)joLogin["data"][a] : false;
                counterInt += b ? 1 : 0;
            }
            return counterInt > 0 ? true : false;
        }

        public bool haveAccess()
        {
            JObject joLogin = Login.jsonResult;
            string[] lists = { "isAdmin", "isSuperAdmin", "isManager", "isAccounting"};
            int counterInt = 0;
            bool boolTemp = false;
            foreach (string a in lists)
            {
                bool b = bool.TryParse((string)joLogin["data"][a], out boolTemp) ? (bool)joLogin["data"][a] : false;
                counterInt += b ? 1 : 0;
            }
            return counterInt > 0 ? true : false;
        }
    }
}
