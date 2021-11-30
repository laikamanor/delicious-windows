using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DeliciousPartnerApp.UI_Class;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace DeliciousPartnerApp
{
    public partial class ItemRequest_Items : Form
    {
        public static bool isSubmit=false;
        public int selectedID = 0;
        public string forType = "";
        utility_class utilityc = new utility_class();
       
        public ItemRequest_Items()
        {
            InitializeComponent();
        }

        private void ItemRequest_Items_Load(object sender, EventArgs e)
        {
            loadData();
            btn.BackColor = forType.Equals("For Confirmation") ?Color.ForestGreen : Color.DodgerBlue;
            btn.Text = forType.Equals("For Confirmation") ? "Confirm" : "Update SAP #";
            btnCancel.Visible = forType.Equals("For Confirmation") ? true : false;
            btn.Visible = forType.Equals("Logs") ? false : true;
        }

        public void loadData()
        {
            Cursor.Current = Cursors.WaitCursor;
            if (Login.jsonResult != null)
            {
                string token = "", branch = "";
                foreach (var x in Login.jsonResult)
                {
                    if (x.Key.Equals("token"))
                    {
                        token = x.Value.ToString();
                    }
                    else if (x.Key.Equals("data"))
                    {
                        JObject jObjectData = JObject.Parse(x.Value.ToString());
                        foreach (var y in jObjectData)
                        {
                            if (y.Key.Equals("branch"))
                            {
                                branch = y.Value.ToString();
                            }
                        }
                    }
                }
                if (!token.Equals(""))
                {
                    var client = new RestClient(utilityc.URL);
                    client.Timeout = -1;
                    var request = new RestRequest("/api/inv/item_request/details/" + selectedID);
                    request.AddHeader("Authorization", "Bearer " + token);
                    var response = client.Execute(request);
                    Console.WriteLine(response.Content);
                    JObject jObjectResponse = JObject.Parse(response.Content);
                    bool isSuccess = false;
                    AutoCompleteStringCollection auto = new AutoCompleteStringCollection();
                    dgv.Rows.Clear();
                    foreach (var x in jObjectResponse)
                    {
                        if (x.Key.Equals("success"))
                        {
                            isSuccess = Convert.ToBoolean(x.Value.ToString());
                        }
                    }
                    if (isSuccess)
                    {
                        int id = 0;
                        string referenceNumber = "", toWhse = "";
                        DateTime dtTransDate = new DateTime(), dtCreated = new DateTime();
                        foreach (var z in jObjectResponse)
                        {
                            if (z.Key.Equals("data"))
                            {
                                if (z.Value.ToString() != "{}")
                                {
                                    JObject jObjectData = JObject.Parse(z.Value.ToString());
                                    foreach (var y in jObjectData)
                                    {
                                        if (y.Key.Equals("request_rows"))
                                        {
                                            if (y.Value.ToString() != "[]")
                                            {
                                                JArray jsonArrayRows = JArray.Parse(y.Value.ToString());
                                                for (int ii = 0; ii < jsonArrayRows.Count(); ii++)
                                                {
                                                    int itemID = 0;
                                                    string itemName = "";
                                                    double quantity = 0.00;
                                                    JObject jObjectRequestRows = JObject.Parse(jsonArrayRows[ii].ToString());

                                                    foreach (var w in jObjectRequestRows)
                                                    {
      
                                                        if (w.Key.Equals("id"))
                                                        {
                                                            itemID = Convert.ToInt32(w.Value.ToString());
                                                        }
                                                        else if (w.Key.Equals("to_whse"))
                                                        {
                                                            toWhse = w.Value.ToString();
                                                        }
                                                        else if (w.Key.Equals("item_code"))
                                                        {
                                                            itemName = w.Value.ToString();
                                                        }
                                                        else if (w.Key.Equals("quantity"))
                                                        {
                                                            quantity = Convert.ToDouble(w.Value.ToString());
                                                        }
                                                    }
                                                    dgv.Rows.Add(itemID, itemName, quantity.ToString("n2"));
                                                }
                                            }
                                        }
                                        else if (y.Key.Equals("id"))
                                        {
                                            id = Convert.ToInt32(y.Value.ToString());
                                        }
                                        else if (y.Key.Equals("reference"))
                                        {
                                            referenceNumber = y.Value.ToString();
                                        }
                                        else if (y.Key.Equals("duedate"))
                                        {
                                            string replaceT = y.Value.ToString().Replace("T", "");
                                            dtTransDate = Convert.ToDateTime(replaceT);
                                        }
                                        else if (y.Key.Equals("date_created"))
                                        {
                                            string replaceT = y.Value.ToString().Replace("T", "");
                                            dtCreated = Convert.ToDateTime(replaceT);
                                        }
                                    }
                                    lblReference.Text = referenceNumber;
                                    lblDueDate.Text = dtTransDate.ToString("yyyy-MM-dd");
                                    lblRequestDate.Text = dtCreated.ToString("yyyy-MM-dd");
                                }   
                            }
                        }
                    }
                }
            }
        }

        private void btn_Click(object sender, EventArgs e)
        {
            if (forType.Equals("For Confirmation"))
            {
                forConfirmation();
            }
            else if (forType.Equals("For SAP"))
            {
                forUpdatingSAP();
            }
            else
            {
                forCancel();
            }
        }

        public void apiPUT(JObject body, string URL)
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
                    var request = new RestRequest(URL);
                    Console.WriteLine(URL);
                    request.AddHeader("Authorization", "Bearer " + token);
                    request.Method = Method.PUT;

                    
                    request.AddParameter("application/json", body, ParameterType.RequestBody);
                    var response = client.Execute(request);
                    Console.WriteLine(response.Content);
                    JObject jObjectResponse = JObject.Parse(response.Content);
                    
                    foreach (var x in jObjectResponse)
                    {
                        if (x.Key.Equals("success"))
                        {
                            isSubmit = true;
                            break;
                        }
                    }

                    string msg = "No message response found";
                    foreach (var x in jObjectResponse)
                    {
                        if (x.Key.Equals("message"))
                        {
                            msg = x.Value.ToString();
                        }
                    }
                    MessageBox.Show(msg,"", MessageBoxButtons.OK, isSubmit ? MessageBoxIcon.Information : MessageBoxIcon.Warning);

                    if (isSubmit)
                    {
                        this.Dispose();
                    }
                }
            }
        }

        public void forConfirmation()
        {
            string URL = "/api/inv/item_request/confirm/" + selectedID;
            Remarks remarkss = new Remarks();
            remarkss.ShowDialog();
            if (Remarks.isSubmit)
            {
                string remarks = Remarks.rem;
                JObject jObjectBody = new JObject();
                jObjectBody.Add("confirm", true);
                jObjectBody.Add("remarks", remarks);
                apiPUT(jObjectBody, URL);
            }
        }

        public void forUpdatingSAP()
        {
            string URL = "/api/inv/item_request/sap_update/" + selectedID;
            SAP_Remarks sAP_Remarks = new SAP_Remarks();
            sAP_Remarks.ShowDialog();
            if (SAP_Remarks.isSubmit)
            {
                string remarks = SAP_Remarks.rem;
                int sapNumber = SAP_Remarks.sap_number;
                JObject jObjectBody = new JObject();
                jObjectBody.Add("sap_number", sapNumber);
                jObjectBody.Add("remarks", remarks);
                apiPUT(jObjectBody, URL);
            }
        }

        public void forCancel()
        {
            string URL = "/api/inv/item_request/cancel/" + selectedID;
            Remarks remarkss = new Remarks();
            remarkss.ShowDialog();
            if (Remarks.isSubmit)
            {
                string remarks = Remarks.rem;
                JObject jObjectBody = new JObject();
                jObjectBody.Add("remarks", remarks);
                apiPUT(jObjectBody, URL);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            forCancel();
        }
    }
}
