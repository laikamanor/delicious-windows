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

namespace DeliciousPartnerApp.API_Class.SOA
{
    class soa_class
    {
        utility_class utilityc = new utility_class();
        public async Task<DataTable> getForSOA(string appendData)
        {
            DataTable dt = new DataTable();
            if (Login.jsonResult != null)
            {
                dt.Columns.Add("id");
                dt.Columns.Add("reference");
                dt.Columns.Add("cust_code");
                dt.Columns.Add("transdate");
                dt.Columns.Add("objtype");
                dt.Columns.Add("doctotal");
                dt.Columns.Add("remarks");
                dt.Columns.Add("docstatus");

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
                    //string branch = (cmbBranch.Text.Equals("") || cmbBranch.Text == "All" ? "" : cmbBranch.Text);
                    var request = new RestRequest("/soa/get_for_soa" + appendData);
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
                                                int id = 0, objType = 0, intTemp = 0;
                                                double docTotal = 0.00, doubleTemp = 0.00;
                                                string reference = "", custCode = "", remarks = "", docStatus = "";
                                                DateTime dtTransDate = new DateTime();
                                                foreach (var q in data)
                                                {
                                                    if (q.Key.Equals("id"))
                                                    {
                                                        id = int.TryParse(q.Value.ToString(), out intTemp) ? Convert.ToInt32(q.Value.ToString()) : 0;
                                                    }
                                                    else if (q.Key.Equals("reference"))
                                                    {
                                                        reference = q.Value.ToString();
                                                    }
                                                    else if (q.Key.Equals("cust_code"))
                                                    {
                                                        custCode = q.Value.ToString();
                                                    }
                                                    else if (q.Key.Equals("transdate"))
                                                    {
                                                        string replaceT = q.Value.ToString().Replace("T", "");
                                                        dtTransDate = Convert.ToDateTime(replaceT);
                                                    }
                                                    else if (q.Key.Equals("objtype"))
                                                    {
                                                        objType = int.TryParse(q.Value.ToString(), out intTemp) ? Convert.ToInt32(q.Value.ToString()) : 0;
                                                    }
                                                    else if (q.Key.Equals("doctotal"))
                                                    {
                                                        docTotal = Double.TryParse(q.Value.ToString(), out doubleTemp) ? Convert.ToDouble(q.Value.ToString()) : 0.00;
                                                    }
                                                    else if (q.Key.Equals("remarks"))
                                                    {
                                                        remarks = q.Value.ToString();
                                                    }
                                                    else if (q.Key.Equals("docstatus"))
                                                    {
                                                        docStatus = q.Value.ToString().Equals("O") ? "Open" : q.Value.ToString().Equals("C") ? "Closed" : q.Value.ToString().Equals("N") ? "Cancelled" : "";
                                                    }
                                                }
                                                dt.Rows.Add(id,reference,custCode, dtTransDate.ToString("yyyy-MM-dd HH:mm"), objType,docTotal.ToString("n2"), remarks, docStatus);
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
                Cursor.Current = Cursors.Default;
            }
            return dt;
        }
        public async Task<DataTable> getSOA(string paramDocStatus,string appendParams)
        {
            DataTable dt = new DataTable();
            if (Login.jsonResult != null)
            {
                dt.Columns.Add("id");
                dt.Columns.Add("reference");
                dt.Columns.Add("docstatus");
                dt.Columns.Add("transdate");
                dt.Columns.Add("age");
                dt.Columns.Add("cust_code");
                dt.Columns.Add("balance");
                dt.Columns.Add("total_amount");

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
                    var request = new RestRequest("/soa/get_all?docstatus=" + paramDocStatus + appendParams);
                    Console.WriteLine("/soa/get_all?docstatus=" + paramDocStatus + appendParams);
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
                                                int id = 0, intTemp = 0, age = 0;
                                                double totalAmount = 0.00, doubleTemp = 0.00, balance = 0.00;
                                                string reference = "", custCode = "", docStatus = "";
                                                DateTime dtTransDate = new DateTime();
                                                foreach (var q in data)
                                                {
                                                    if (q.Key.Equals("id"))
                                                    {
                                                        id = int.TryParse(q.Value.ToString(), out intTemp) ? Convert.ToInt32(q.Value.ToString()) : 0;
                                                    }
                                                    else if (q.Key.Equals("reference"))
                                                    {
                                                        reference = q.Value.ToString();
                                                    }
                                                    else if (q.Key.Equals("docstatus"))
                                                    {
                                                        docStatus = q.Value.ToString().Equals("O") ? "Open" : q.Value.ToString().Equals("C") ? "Closed" : q.Value.ToString().Equals("N") ? "Cancelled" : "";
                                                    }
                                                    else if (q.Key.Equals("transdate"))
                                                    {
                                                        string replaceT = q.Value.ToString().Replace("T", "");
                                                        dtTransDate = Convert.ToDateTime(replaceT);
                                                    }
                                                    else if (q.Key.Equals("age"))
                                                    {
                                                        age = int.TryParse(q.Value.ToString(), out intTemp) ? Convert.ToInt32(q.Value.ToString()) : 0;
                                                    }
                                                    else if (q.Key.Equals("cust_code"))
                                                    {
                                                        custCode = q.Value.ToString();
                                                    }
                                                    else if (q.Key.Equals("balance"))
                                                    {
                                                        balance = Double.TryParse(q.Value.ToString(), out doubleTemp) ? Convert.ToDouble(q.Value.ToString()) : 0.00;
                                                    }
                                                    else if (q.Key.Equals("total_amount"))
                                                    {
                                                        totalAmount = Double.TryParse(q.Value.ToString(), out doubleTemp) ? Convert.ToDouble(q.Value.ToString()) : 0.00;
                                                    }
                                                }
                                                dt.Rows.Add(id, reference, docStatus, dtTransDate.ToString("yyyy-MM-dd"), age, custCode, balance.ToString("n2"), totalAmount.ToString("n2"));
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
                Cursor.Current = Cursors.Default;
            }
            return dt;
        }

        public async Task<DataTable> getSOADetails(int selectedID)
        {
            DataTable dt = new DataTable();
            if (Login.jsonResult != null)
            {
                dt.Columns.Add("reference");
                dt.Columns.Add("transdate");
                dt.Columns.Add("cust_code");
                dt.Columns.Add("docstatus");
                dt.Columns.Add("total_amount");
                dt.Columns.Add("id");
                dt.Columns.Add("doc_id");
                dt.Columns.Add("base_transdate");
                dt.Columns.Add("base_id");
                dt.Columns.Add("base_reference");
                dt.Columns.Add("base_objtype");
                dt.Columns.Add("sales_remarks");
                dt.Columns.Add("amount");

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
                    var request = new RestRequest("/soa/get_by_id/" + selectedID);
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
                                string  reference = "", customerCode = "", docStatus = "";
                                DateTime dtTransDate = new DateTime();
                                double total = 0.00, doubleTemp = 0.00;
                                foreach (var q in jObject)
                                {
                                     if (q.Key.Equals("data"))
                                    {
                                        JObject joData = JObject.Parse(q.Value.ToString());
                                        foreach (var x in joData)
                                        {
                                            if (x.Key.Equals("reference"))
                                            {
                                                reference = x.Value.ToString();
                                            }
                                            else if (x.Key.Equals("transdate"))
                                            {
                                                string replaceT = x.Value.ToString().Replace("T", "");
                                                dtTransDate = string.IsNullOrEmpty(replaceT) ? new DateTime() : Convert.ToDateTime(replaceT);
                                            }
                                            else if (x.Key.Equals("cust_code"))
                                            {
                                                customerCode = x.Value.ToString();
                                            }
                                            else if (x.Key.Equals("total_amount"))
                                            {
                                                total = Convert.ToDouble(x.Value.ToString());
                                            }
                                            else if (x.Key.Equals("docstatus"))
                                            {
                                                docStatus = q.Value.ToString().Equals("O") ? "Open" : q.Value.ToString().Equals("C") ? "Closed" : q.Value.ToString().Equals("N") ? "Cancelled" : "";
                                            }
                                            else if (x.Key.Equals("soa_rows"))
                                            {
                                                if (x.Value.ToString() != "[]")
                                                {
                                                    JArray jsonArray = JArray.Parse(x.Value.ToString());
                                                    for (int i = 0; i < jsonArray.Count(); i++)
                                                    {
                                                        int soaID = 0, soaDocID = 0, soaBaseID = 0, soaBaseObjType = 0;
                                                        double soaAmount = 0.00;
                                                        string soaBaseReference = "", soaSalesRemarks = "";
                                                        DateTime soaBaseTransDate = new DateTime();
                                                        JObject joSoaRows = JObject.Parse(jsonArray[i].ToString());
                                                        foreach (var y in joSoaRows)
                                                        {
                                                            if (y.Key.Equals("id"))
                                                            {
                                                                soaID = Convert.ToInt32(y.Value.ToString());
                                                            }
                                                            else if (y.Key.Equals("doc_id"))
                                                            {
                                                                soaDocID = Convert.ToInt32(y.Value.ToString());
                                                            }

                                                            else if (y.Key.Equals("base_transdate"))
                                                            {
                                                                string replaceT = y.Value.ToString().Replace("T", "");
                                                                soaBaseTransDate = !string.IsNullOrEmpty(y.Value.ToString()) ? Convert.ToDateTime(replaceT) : new DateTime();
                                                            }
                                                            else if (y.Key.Equals("base_id"))
                                                            {
                                                                soaBaseID = Convert.ToInt32(y.Value.ToString());
                                                            }
                                                            else if (y.Key.Equals("base_reference"))
                                                            {
                                                                soaBaseReference = y.Value.ToString();
                                                            }
                                                            else if (y.Key.Equals("base_objtype"))
                                                            {
                                                                soaBaseObjType = Convert.ToInt32(y.Value.ToString());
                                                            }
                                                            else if (y.Key.Equals("sales_remarks"))
                                                            {
                                                                soaSalesRemarks = y.Value.ToString();
                                                            }
                                                            else if (y.Key.Equals("amount"))
                                                            {
                                                                soaAmount = Convert.ToDouble(y.Value.ToString());
                                                            }
                                                        }

                                                        dt.Rows.Add(reference, dtTransDate.ToString("MM/dd/yyyy"), customerCode, docStatus, total.ToString("n2"), soaID, soaDocID, soaBaseTransDate.ToString("MM/dd/yyyy"), soaBaseID, soaBaseReference, soaBaseObjType, soaSalesRemarks, soaAmount.ToString("n2"));
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

        public string createSOA(JObject body)
        {
            string result = "";
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
                    var request = new RestRequest("/soa/create_soa");
                    Console.WriteLine("/soa/create_soa");
                    request.AddHeader("Authorization", "Bearer " + token);
                    request.Method = Method.POST;

                    Console.WriteLine(body);
                    request.AddParameter("application/json", body, ParameterType.RequestBody);
                    var response = client.Execute(request);
                    if (response.ErrorMessage == null)
                    {
                        if (response.Content.Substring(0, 1).Equals("{"))
                        {
                            JObject jObjectResponse = JObject.Parse(response.Content);
                            bool isSuccess = false;
                            string msg = "";
                            foreach (var x in jObjectResponse)
                            {
                                if (x.Key.Equals("success"))
                                {
                                    isSuccess = string.IsNullOrEmpty(x.Value.ToString()) ? false : Convert.ToBoolean(x.Value.ToString());
                                }
                                else if (x.Key.Equals("message"))
                                {
                                    msg = x.Value.ToString();
                                }
                            }
                            if (isSuccess)
                            {
                                result = response.Content.ToString();
                            }
                            else
                            {
                                result = msg;
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
            }
            return result;
        }
    }
}
