using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;
using RestSharp;
using Newtonsoft.Json.Linq;
using DeliciousPartnerApp.UI_Class;
namespace DeliciousPartnerApp.API_Class.Notification
{
    class notification_class
    {
        public async Task<DataTable> getUnreadNotif(string selectedBranch, string selectedFromDate, string selectedToDate, string selectedWarehouse, int isDone)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("count");
            dt.Columns.Add("id");
            dt.Columns.Add("item_code");
            dt.Columns.Add("age");
            dt.Columns.Add("branch");
            dt.Columns.Add("whsecode");
            dt.Columns.Add("quantity");
            dt.Columns.Add("date_created");
            dt.Columns.Add("date_updated");
            dt.Columns.Add("date_done");
            dt.Columns.Add("auto_done", typeof(bool));
            dt.Columns.Add("remarks_count", typeof(int));
            try
            {
                utility_class utilityc = new utility_class();
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
                        var request = new RestRequest("/api/notification/get_all_unread?branch=" + selectedBranch + selectedFromDate + selectedToDate + selectedWarehouse + "&done=" + isDone);
                        //Console.WriteLine("/api/notification/get_all_unread?branch=" + selectedBranch + selectedFromDate + selectedToDate + selectedWarehouse);
                        request.AddHeader("Authorization", "Bearer " + token);
                        Task<IRestResponse> t = client.ExecuteAsync(request);
                        t.Wait();
                        var response = await t;
                        //var response = client.Execute(request);

                        //Cursor.Current = Cursors.WaitCursor;
                        //var client = new RestClient();
                        //var request = new RestRequest("http://www.google.com");
                        //Task<IRestResponse> t = client.ExecuteAsync(request);
                        //t.Wait();
                        //var restResponse = await t;
                        //Console.WriteLine(restResponse.Content);
                        //Cursor.Current = Cursors.Default;
                        JObject jObject = new JObject();
                        if (response.ErrorMessage == null)
                        {
                            if (response.Content.Substring(0, 1).Equals("{"))
                            {
                                jObject = JObject.Parse(response.Content.ToString());
                                int count = 0;
                                bool isSuccess = false;
                                foreach (var x in jObject)
                                {
                                    if (x.Key.Equals("success"))
                                    {
                                        isSuccess = Convert.ToBoolean(x.Value.ToString());
                                    }
                                    else if (x.Key.Equals("count"))
                                    {
                                        count = string.IsNullOrEmpty(x.Value.ToString().Trim()) ? 0 : Convert.ToInt32(x.Value.ToString());
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
                                                    int id = 0, age = 0, remarksCount = 0, intTemp = 0;
                                                    string itemCode = "", branch = "", whsecode = "", dtCreated = "", dtUpdated = "", dtDone = "";
                                                    double quantity = 0;
                                                    bool autoDone = false, boolTemp = false;
                                                    foreach (var q in data)
                                                    {
                                                        if (q.Key.Equals("age"))
                                                        {
                                                            age = string.IsNullOrEmpty(q.Value.ToString().Trim()) ? 0 : Convert.ToInt32(q.Value.ToString());
                                                        }
                                                        else if (q.Key.Equals("remarks_count"))
                                                        {
                                                            remarksCount = Int32.TryParse(q.Value.ToString(), out intTemp) ? Convert.ToInt32(q.Value.ToString()) : intTemp;
                                                        }
                                                        else if (q.Key.Equals("id"))
                                                        {
                                                            id = string.IsNullOrEmpty(q.Value.ToString().Trim()) ? 0 : Convert.ToInt32(q.Value.ToString());
                                                        }
                                                        else if (q.Key.Equals("branch"))
                                                        {
                                                            branch = q.Value.ToString();
                                                        }
                                                        else if (q.Key.Equals("whsecode"))
                                                        {
                                                            whsecode = q.Value.ToString();
                                                        }
                                                        else if (q.Key.Equals("item_code"))
                                                        {
                                                            itemCode = q.Value.ToString();
                                                        }
                                                        else if (q.Key.Equals("quantity"))
                                                        {
                                                            quantity = string.IsNullOrEmpty(q.Value.ToString().Trim()) ? 0.00 : Convert.ToDouble(q.Value.ToString());
                                                        }
                                                        else if (q.Key.Equals("date_created"))
                                                        {
                                                            dtCreated = string.IsNullOrEmpty(q.Value.ToString().Trim()) ? "" : Convert.ToDateTime(q.Value.ToString()).ToString("yyyy-MM-dd HH:mm:ss");
                                                        }
                                                        else if (q.Key.Equals("date_updated"))
                                                        {
                                                            dtUpdated = string.IsNullOrEmpty(q.Value.ToString().Trim()) ? "" : Convert.ToDateTime(q.Value.ToString()).ToString("yyyy-MM-dd HH:mm:ss");
                                                        }
                                                        else if (q.Key.Equals("date_done"))
                                                        {
                                                            dtDone = string.IsNullOrEmpty(q.Value.ToString().Trim()) ? "" : Convert.ToDateTime(q.Value.ToString()).ToString("yyyy-MM-dd HH:mm:ss");
                                                        }
                                                        else if (q.Key.Equals("auto_done"))
                                                        {
                                                            autoDone = bool.TryParse(q.Value.ToString(), out boolTemp) ? Convert.ToBoolean(q.Value.ToString()) : boolTemp;
                                                        }
                                                    }
                                                    dt.Rows.Add(count, id, itemCode, age, branch, whsecode, quantity, dtCreated, dtUpdated, dtDone, autoDone, remarksCount);
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
                                        //MessageBox.Show("Your login session is expired. Please login again", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    }
                                    else
                                    {
                                        Console.WriteLine(msg);
                                        //MessageBox.Show(msg, "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    }
                                }
                            }
                            else
                            {
                                Console.WriteLine("response content: " + response.Content.ToString());
                            }
                        }
                        else
                        {
                            Console.WriteLine("error message: " + response.ErrorMessage);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("catch: " + ex.ToString());
            }
            return dt;
        }

        public async Task getAndPost()
        {
            utility_class utilityc = new utility_class();
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
                    var request = new RestRequest("/api/notification/get_and_post");
                    request.AddHeader("Authorization", "Bearer " + token);
                    Task<IRestResponse> t = client.ExecuteAsync(request);
                    t.Wait();
                    var response = await t;
                }
            }
        }

        public async Task<DataTable> getReadNotifByID(int selectedID)
        {
            utility_class utilityc = new utility_class();
            DataTable dt = new DataTable();
            if (Login.jsonResult != null)
            {
                dt.Columns.Add("id");
                dt.Columns.Add("header");
                dt.Columns.Add("message");
                dt.Columns.Add("date_read");
                dt.Columns.Add("remarks");
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
                    var request = new RestRequest("/api/notification/read_message/" + selectedID);
                    request.AddHeader("Authorization", "Bearer " + token);
                    Task<IRestResponse> t = client.ExecuteAsync(request);
                    t.Wait();
                    var response = await t;
                    JObject jObject = new JObject();
                    if (response.ErrorMessage == null)
                    {
                        if (response.Content.Substring(0, 1).Equals("{"))
                        {
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
                                        string header = "", remarks = "", message = "";
                                        DateTime dtRead = new DateTime();
                                        int id = 0;
                                        JObject joData = JObject.Parse(x.Value.ToString());
                                        foreach (var c in joData)
                                        {
                                            if (c.Key.Equals("message"))
                                            {
                                                JObject joMessage = JObject.Parse(c.Value.ToString());
                                                foreach (var v in joMessage)
                                                {
                                                    if (v.Key.Equals("username"))
                                                    {
                                                        header = v.Value.ToString();
                                                    }
                                                    else if (v.Key.Equals("id"))
                                                    {
                                                        id = string.IsNullOrEmpty(v.Value.ToString().Trim()) ? 0 : Convert.ToInt32(v.Value.ToString());
                                                    }
                                                    else if (v.Key.Equals("branch"))
                                                    {
                                                        header += Environment.NewLine + v.Value.ToString();
                                                    }
                                                    else if (v.Key.Equals("message"))
                                                    {
                                                        message = v.Value.ToString();
                                                    }
                                                    else if (v.Key.Equals("date_read"))
                                                    {
                                                        string replaceT = v.Value.ToString().Replace("T", "");
                                                        dtRead = Convert.ToDateTime(replaceT);
                                                    }
                                                }
                                            }
                                            else if (c.Key.Equals("remarks"))
                                            {
                                                remarks = c.Value.ToString();
                                            }
                                            dt.Rows.Add(id, header, message, dtRead.ToString("yyyy-MM-dd hh:mm:ss"), remarks);
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
                        else
                        {
                            Console.WriteLine("getReadNotifByID response content: " + response.Content);
                        }
                    }
                    else
                    {
                        Console.WriteLine("getReadNotifByID response errormessage: " + response.ErrorMessage);
                    }
                }
            }
            return dt;
        }

        public async Task<DataTable> getRemarksDetails(int selectedID)
        {
            utility_class utilityc = new utility_class();
            DataTable dt = new DataTable();
            if (Login.jsonResult != null)
            {
                dt.Columns.Add("id");
                dt.Columns.Add("doc_id");
                dt.Columns.Add("remarks");
                dt.Columns.Add("date_created");
                dt.Columns.Add("created_by");
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
                    var request = new RestRequest("/api/notification/view/remarks/" + selectedID);
                    request.AddHeader("Authorization", "Bearer " + token);
                    Task<IRestResponse> t = client.ExecuteAsync(request);
                    t.Wait();
                    var response = await t;
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
                                        if (x.Value.ToString() != "[]")
                                        {
                                            JArray jsonArray = JArray.Parse(x.Value.ToString());
                                            for (int i = 0; i < jsonArray.Count(); i++)
                                            {
                                                JObject data = JObject.Parse(jsonArray[i].ToString());
                                                int id = 0, docID = 0, createdBy = 0;
                                                string remarks = "", dtCreated = "";
                                                foreach (var q in data)
                                                {
                                                    if (q.Key.Equals("id"))
                                                    {
                                                        id = string.IsNullOrEmpty(q.Value.ToString().Trim()) ? 0 : Convert.ToInt32(q.Value.ToString());
                                                    }
                                                    else if (q.Key.Equals("doc_id"))
                                                    {
                                                        docID = string.IsNullOrEmpty(q.Value.ToString().Trim()) ? 0 : Convert.ToInt32(q.Value.ToString());
                                                    }
                                                    else if (q.Key.Equals("remarks"))
                                                    {
                                                        remarks = q.Value.ToString();
                                                    }
                                                    else if (q.Key.Equals("date_created"))
                                                    {
                                                        dtCreated = string.IsNullOrEmpty(q.Value.ToString().Trim()) ? "" : Convert.ToDateTime(q.Value.ToString()).ToString("yyyy-MM-dd HH:mm:ss");
                                                    }
                                                    else if (q.Key.Equals("created_by"))
                                                    {
                                                        createdBy = string.IsNullOrEmpty(q.Value.ToString().Trim()) ? 0 : Convert.ToInt32(q.Value.ToString());
                                                    }
                                                }
                                                dt.Rows.Add(id, docID, remarks, dtCreated, createdBy);
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

        public async Task<string> markAsRead(int id)
        {
            string result = "";
            utility_class utilityc = new utility_class();
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
                var request = new RestRequest("/api/notification/update/done/" + id);
                request.Method = Method.PUT;
                request.AddHeader("Authorization", "Bearer " + token);
                var response = client.Execute(request);
                if (response.ErrorMessage == null)
                {
                    if (response.Content.ToString().Substring(0, 1).Equals("{"))
                    {
                        JObject joResponse = new JObject();
                        joResponse = JObject.Parse(response.Content.ToString());
                        foreach (var x in joResponse)
                        {
                            if (x.Key.Equals("message"))
                            {
                                result = x.Value.ToString();
                            }
                        }
                    }
                    else
                    {
                        result = response.Content.ToString();
                    }
                }
                else
                {
                    result = response.ErrorMessage;
                }
            }
            await Task.Delay(10);
            return result;
        }

        public async Task<string> addRemarks(int id, string remarks)
        {
            string result = "";
            utility_class utilityc = new utility_class();
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
                var request = new RestRequest("/api/notification/add/remarks/" + id);
                request.Method = Method.POST;
                request.AddHeader("Authorization", "Bearer " + token);
                JObject joBody = new JObject();
                joBody.Add("remarks", remarks);
                request.AddParameter("application/json", joBody, ParameterType.RequestBody);
                var response = client.Execute(request);
                if (response.ErrorMessage == null)
                {
                    if (response.Content.ToString().Substring(0, 1).Equals("{"))
                    {
                        JObject joResponse = new JObject();
                        joResponse = JObject.Parse(response.Content.ToString());
                        foreach (var x in joResponse)
                        {
                            if (x.Key.Equals("message"))
                            {
                                result = x.Value.ToString();
                            }
                        }
                    }
                    else
                    {
                        result = response.Content.ToString();
                    }
                }
                else
                {
                    result = response.ErrorMessage;
                }
            }
            await Task.Delay(10);
            return result;
        }
    }
}
