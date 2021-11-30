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
using RestSharp;
using Newtonsoft.Json.Linq;

namespace DeliciousPartnerApp
{
    public partial class SalesTransactions_Items : Form
    {
        public int selectedID = 0;
        utility_class utilityc = new utility_class();
        public SalesTransactions_Items()
        {
            InitializeComponent();
        }

        private void SalesTransactions_Items_Load(object sender, EventArgs e)
        {
            loadData();
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
                    dgv.Rows.Clear();
                    var request = new RestRequest("/api/sales/details/" + selectedID);
                    request.AddHeader("Authorization", "Bearer " + token);
                    var response = client.Execute(request);
                    JObject jObjectResponse = JObject.Parse(response.Content);
                    //Console.Write(jObjectResponse);
                    bool isSuccess = false;
                    //AutoCompleteStringCollection auto = new AutoCompleteStringCollection();
                    dgv.Rows.Clear();
                    string msg = "";
                    foreach (var x in jObjectResponse)
                    {
                        if (x.Key.Equals("success"))
                        {
                            isSuccess = Convert.ToBoolean(x.Value.ToString());
                        }
                        else if (x.Key.Equals("message"))
                        {
                            msg = x.Value.ToString();
                        }

                    }
                    if (isSuccess)
                    {
                        foreach (var e in jObjectResponse)
                        {
                            if (e.Key.Equals("data"))
                            {
                                if (e.Value.ToString() != "{}")
                                {                    
                                    foreach (var y in JObject.Parse(e.Value.ToString()))
                                    {
                                        if (y.Key.Equals("gross"))
                                        {
                                            lblGross.Text = Convert.ToDouble(y.Value.ToString()).ToString("n2");
                                        }
                                        else if (y.Key.Equals("disc_amount"))
                                        {
                                            lblDiscAmount.Text = Convert.ToDouble(y.Value.ToString()).ToString("n2");
                                        }
                                        else if (y.Key.Equals("doctotal"))
                                        {
                                            lblDocTotal.Text = Convert.ToDouble(y.Value.ToString()).ToString("n2");
                                        }
                                        else if (y.Key.Equals("appliedamt"))
                                        {
                                            lblAppliedAmount.Text = Convert.ToDouble(y.Value.ToString()).ToString("n2");
                                        }
                                        else if (y.Key.Equals("tenderamt"))
                                        {
                                            lblTenderAmount.Text = Convert.ToDouble(y.Value.ToString()).ToString("n2");
                                        }
                                        else if (y.Key.Equals("amount_due"))
                                        {
                                            lblAmountDue.Text = Convert.ToDouble(y.Value.ToString()).ToString("n2");
                                        }
                                        else if (y.Key.Equals("salesrow"))
                                        {
                                            JArray jArrayRow = JArray.Parse(y.Value.ToString());
                                            for (int i = 0; i < jArrayRow.Count(); i++)
                                            {
                                                JObject data = JObject.Parse(jArrayRow[i].ToString());
                                                //Console.Write(data);
                                                string itemName = "";
                                                double quantity = 0.00, price = 0.00, discountPercent = 0.00, totalPrice = 0.00, discamt = 0.00, gross = 0.00;
                                                foreach (var z in data)
                                                {
                                                    if (z.Key.Equals("item_code"))
                                                    {
                                                        itemName = z.Value.ToString();
                                                    }
                                                    else if (z.Key.Equals("quantity"))
                                                    {
                                                        quantity = Convert.ToDouble(z.Value.ToString());
                                                    }
                                                    else if (z.Key.Equals("unit_price"))
                                                    {
                                                        price = Convert.ToDouble(z.Value.ToString());
                                                    }
                                                    else if (z.Key.Equals("discprcnt"))
                                                    {
                                                        discountPercent = Convert.ToDouble(z.Value.ToString());
                                                    }
                                                    else if (z.Key.Equals("gross"))
                                                    {
                                                        gross = Convert.ToDouble(z.Value.ToString());
                                                    }
                                                    else if (z.Key.Equals("linetotal"))
                                                    {
                                                        totalPrice = Convert.ToDouble(z.Value.ToString());
                                                    }

                                                    else if (z.Key.Equals("disc_amount"))
                                                    {
                                                        discamt = Convert.ToDouble(z.Value.ToString());
                                                    }
                                                }
                                                dgv.Rows.Add(itemName, quantity.ToString("n2"), price.ToString("n2"), gross.ToString("n2"), discamt.ToString("n2"), discountPercent.ToString("n2"), totalPrice.ToString("n2"));
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show(msg, "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            lblNoDataFound.Visible = (dgv.Rows.Count > 0 ? false : true);
        }
    }
}
