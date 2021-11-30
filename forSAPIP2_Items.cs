using Newtonsoft.Json.Linq;
using RestSharp;
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
namespace DeliciousPartnerApp
{
    public partial class forSAPIP2_Items : Form
    {
        public string ids = "", urls = "";
        utility_class utilityc = new utility_class();
        public static bool isSubmit = false;
        public forSAPIP2_Items()
        {
            InitializeComponent();
        }

        private void forSAPIP2_Items_Load(object sender, EventArgs e)
        {
            loadData();
        }

        private void btnUpdateSAP_Click(object sender, EventArgs e)
        {
            SAPNumber sapNumber = new SAPNumber();
            sapNumber.ShowDialog();
            if (SAPNumber.isSubmit)
            {
                string sIDs = "?ids=%5B" + ids + "%5D";
                string URL = "/api/sap_num/payment/update" + sIDs;
                int sapnum = SAPNumber.sap_number;
                JObject jObjectBody = new JObject();
                jObjectBody.Add("sap_number", sapnum);
                apiPUT(jObjectBody, URL);
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
                    MessageBox.Show(msg, "", MessageBoxButtons.OK, isSubmit ? MessageBoxIcon.Information : MessageBoxIcon.Warning);

                    if (isSubmit)
                    {
                        this.Dispose();
                    }
                }
            }
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

                    var request = new RestRequest(urls);
                    request.AddHeader("Authorization", "Bearer " + token);
                    var response = client.Execute(request);
                    JObject jObjectResponse = JObject.Parse(response.Content);
                    bool isSuccess = false;
                    AutoCompleteStringCollection auto = new AutoCompleteStringCollection();
                    dgv.Rows.Clear();
                    double totalAmount = 0.00;
                    foreach (var x in jObjectResponse)
                    {
                        if (x.Key.Equals("success"))
                        {
                            isSuccess = Convert.ToBoolean(x.Value.ToString());
                        }
                    }
                    if (isSuccess)
                    {
                        foreach (var z in jObjectResponse)
                        {
                            if (z.Key.Equals("data"))
                            {
                                if (z.Value.ToString() != "[]")
                                {
                                    JArray jsonArray = JArray.Parse(z.Value.ToString());
                                    for (int i = 0; i < jsonArray.Count(); i++)
                                    {
                                        JObject jObjectData = JObject.Parse(jsonArray[i].ToString());
                                        int id = 0, paymentID = 0;
                                        string paymentType = "";
                                        double amount = 0.00;
                                        foreach (var y in jObjectData)
                                        {
                                            if (y.Key.Equals("id"))
                                            {
                                                id = Convert.ToInt32(y.Value.ToString());
                                            }
                                            else if (y.Key.Equals("payment_id"))
                                            {
                                                paymentID = Convert.ToInt32(y.Value.ToString());
                                            }
                                            else if (y.Key.Equals("payment_type"))
                                            {
                                                paymentType = y.Value.ToString();
                                            }
                                            else if (y.Key.Equals("amount"))
                                            {
                                                amount = Convert.ToDouble(y.Value.ToString());
                                                totalAmount += amount;
                                            }                                       
                                        }
                                        dgv.Rows.Add(id, paymentID, paymentType, amount);                                        
                                    }
                                }
                            }
                        }
                    }
                    lblTotalAmount.Text = totalAmount.ToString("n2");
                }
            }
            lblNoDataFound.Visible = (dgv.Rows.Count > 0 ? false : true);
        }
    }
}
