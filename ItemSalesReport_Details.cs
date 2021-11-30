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
using Newtonsoft.Json.Linq;

namespace DeliciousPartnerApp
{
    public partial class ItemSalesReport_Details : Form
    {
        public ItemSalesReport_Details()
        {
            InitializeComponent();
        }
        public string URL = "";
        utility_class utilityc = new utility_class();
        private void ItemSalesReport_Details_Load(object sender, EventArgs e)
        {
            loadData();
        }

        public void loadData()
        {
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
                    //string branch = "A1-S";
                    Console.WriteLine(URL);
                    var request = new RestRequest(URL);
                    Console.WriteLine(URL);
                    request.AddHeader("Authorization", "Bearer " + token);
                    var response = client.Execute(request);
                    JObject jObject = new JObject();
                    jObject = JObject.Parse(response.Content.ToString());
                    dgv.Rows.Clear();
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
                                        string referenceNumber = "", itemCode = "", userName = "";
                                        double qty = 0.00, unitPrice = 0.00, discPrcnt = 0.00, discAmt = 0.00, grossAmt = 0.00, netAmt = 0.00;
                                        foreach (var q in data)
                                        {
                                            if (q.Key.Equals("reference"))
                                            {
                                                referenceNumber = q.Value.ToString();
                                            }
                                            else if (q.Key.Equals("item_code"))
                                            {
                                                itemCode = q.Value.ToString();
                                            }
                                            else if (q.Key.Equals("quantity"))
                                            {
                                                qty = Convert.ToDouble(q.Value.ToString());
                                            }
                                            else if (q.Key.Equals("unit_price"))
                                            {
                                                unitPrice = Convert.ToDouble(q.Value.ToString());
                                            }
                                            else if (q.Key.Equals("discprcnt"))
                                            {
                                                discPrcnt = Convert.ToDouble(q.Value.ToString());
                                            }
                                            else if (q.Key.Equals("disc_amount"))
                                            {
                                                discAmt = Convert.ToDouble(q.Value.ToString());
                                            }
                                            else if (q.Key.Equals("gross_amount"))
                                            {
                                                grossAmt = Convert.ToDouble(q.Value.ToString());
                                            }
                                            else if (q.Key.Equals("net_amount"))
                                            {
                                                netAmt = Convert.ToDouble(q.Value.ToString());
                                            }
                                            else if (q.Key.Equals("username"))
                                            {
                                                userName = q.Value.ToString();
                                            }
                                        }
                                        dgv.Rows.Add(referenceNumber, itemCode, Convert.ToDecimal(string.Format("{0:0.00}", qty)), Convert.ToDecimal(string.Format("{0:0.00}", unitPrice)), Convert.ToDecimal(string.Format("{0:0.00}", discPrcnt)), Convert.ToDecimal(string.Format("{0:0.00}", discAmt)), Convert.ToDecimal(string.Format("{0:0.00}", grossAmt)), Convert.ToDecimal(string.Format("{0:0.00}", netAmt)),userName);
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
                Cursor.Current = Cursors.Default;
            }
        }

    }
}
