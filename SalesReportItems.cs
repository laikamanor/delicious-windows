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
    public partial class SalesReportItems : Form
    {
        utility_class utilityc = new utility_class();
        public string URLDetails = "";
        public SalesReportItems()
        {
            InitializeComponent();
        }

        private void SalesReport_Items_Load(object sender, EventArgs e)
        {
            loadData();
        }

        public void loadData()
        {
            Cursor.Current = Cursors.WaitCursor;
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
                    dgvitems.Rows.Clear();
                    var client = new RestClient(utilityc.URL);
                    client.Timeout = -1;

                    var request = new RestRequest(URLDetails);
                    request.AddHeader("Authorization", "Bearer " + token);
                    var response = client.Execute(request);
                    JObject jObject = JObject.Parse(response.Content);
                    bool isSuccess = false;
                    foreach(var x in jObject)
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
                                JObject jObjectData = JObject.Parse(x.Value.ToString());
                                foreach (var w in jObjectData)
                                {
                                    if (w.Key.Equals("salesrow"))
                                    {
                                        JArray jsonArraySalesRow = JArray.Parse(w.Value.ToString());
                                        for (int i = 0; i < jsonArraySalesRow.Count(); i++)
                                        {
                                            JObject jObjectSalesRow = JObject.Parse(jsonArraySalesRow[i].ToString());
                                            string itemCode = "", warehouseCode = "";
                                            double quantity = 0.00, price = 0.00, disc_amount = 0.00, discprcnt = 0.00, gross = 0.00, totalPrice = 0.00;
                                            bool free = false;
                                            foreach (var e in jObjectSalesRow)
                                            {
                                                if (e.Key.Equals("item_code"))
                                                {
                                                    itemCode = e.Value.ToString();
                                                }
                                                else if (e.Key.Equals("quantity"))
                                                {
                                                    quantity = Convert.ToDouble(e.Value.ToString());
                                                }
                                                else if (e.Key.Equals("quantity"))
                                                {
                                                    quantity = Convert.ToDouble(e.Value.ToString());
                                                }
                                                else if (e.Key.Equals("whsecode"))
                                                {
                                                    warehouseCode = e.Value.ToString();
                                                }
                                                else if (e.Key.Equals("unit_price"))
                                                {
                                                    price = Convert.ToDouble(e.Value.ToString());
                                                }
                                                else if (e.Key.Equals("disc_amount"))
                                                {
                                                    disc_amount = Convert.ToDouble(e.Value.ToString());
                                                }
                                                else if (e.Key.Equals("discprcnt"))
                                                {
                                                    discprcnt = Convert.ToDouble(e.Value.ToString());
                                                }
                                                else if (e.Key.Equals("gross"))
                                                {
                                                    gross = Convert.ToDouble(e.Value.ToString());
                                                }
                                                else if (e.Key.Equals("linetotal"))
                                                {
                                                    totalPrice = Convert.ToDouble(e.Value.ToString());
                                                }
                                                else if (e.Key.Equals("free"))
                                                {
                                                    free = Convert.ToBoolean(e.Value.ToString());
                                                }
                                            }
                                            dgvitems.Rows.Add(itemCode, Convert.ToDecimal(string.Format("{0:0.00}", quantity)), Convert.ToDecimal(string.Format("{0:0.00}", price)), Convert.ToDecimal(string.Format("{0:0.00}", discprcnt)), Convert.ToDecimal(string.Format("{0:0.00}", disc_amount)), Convert.ToDecimal(string.Format("{0:0.00}", totalPrice)), free);
                                        }
                                    }
                                    else if (w.Key.Equals("gross"))
                                    {
                                        txtGrossPrice.Text = Convert.ToDouble(w.Value.ToString()).ToString("n2");
                                    }
                                    else if (w.Key.Equals("disc_amount"))
                                    {
                                        txtDiscountAmount.Text = Convert.ToDouble(w.Value.ToString()).ToString("n2");
                                    }
                                    else if (w.Key.Equals("amount_due"))
                                    {
                                        txtlAmountPayable.Text = Convert.ToDouble(w.Value.ToString()).ToString("n2");
                                    }
                                    else if (w.Key.Equals("tenderamt"))
                                    {
                                        txtTenderAmount.Text = Convert.ToDouble(w.Value.ToString()).ToString("n2");
                                    }
                                    else if (w.Key.Equals("change"))
                                    {
                                        txtChange.Text = Convert.ToDouble(w.Value.ToString()).ToString("n2");
                                    }
                                    else if (w.Key.Equals("reference"))
                                    {
                                        txtReference.Text = w.Value.ToString();
                                    }
                                    else if (w.Key.Equals("transtype"))
                                    {
                                        txtTenderType.Text = w.Value.ToString();
                                    }
                                    else if (w.Key.Equals("cust_code"))
                                    {
                                        txtCustomerCode.Text = w.Value.ToString();
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
