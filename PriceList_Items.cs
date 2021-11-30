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
    public partial class PriceList_Items : Form
    {
        public PriceList_Items()
        {
            InitializeComponent();
        }
        public static bool isSubmit = false;
        public int selectedID = 0;
        utility_class utilityc = new utility_class();
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNewPrice.Text.Trim()))
            {
                MessageBox.Show("New Price field is required", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                JObject body = new JObject();
                if (string.IsNullOrEmpty(txtNewPrice.Text.Trim()))
                {
                    body.Add("price", null);
                }else
                {
                    body.Add("price", Convert.ToDouble(txtNewPrice.Text.Trim()));
                }
                apiPUT(body, "/api/item/price_list/row/update/" + selectedID);
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

                    Console.WriteLine(body);
                    request.AddParameter("application/json", body, ParameterType.RequestBody);
                    var response = client.Execute(request);
                    Console.WriteLine(response.Content.ToString());
                    if (response.ErrorMessage == null)
                    {
                        JObject jObjectResponse = JObject.Parse(response.Content);

                        foreach (var x in jObjectResponse)
                        {
                            if (x.Key.Equals("success"))
                            {
                                isSubmit = x.Value.ToString() == "" ? false : Convert.ToBoolean(x.Value.ToString());
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
                        MessageBox.Show(msg, "Message", MessageBoxButtons.OK, isSubmit ? MessageBoxIcon.Information : MessageBoxIcon.Warning);


                        if (isSubmit)
                        {
                            this.Dispose();
                        }
                    }
                    else
                    {
                        MessageBox.Show(response.ErrorMessage, "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                }
            }
        }

        private void PriceList_Items_Load(object sender, EventArgs e)
        {
            isSubmit = false;
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
                    var request = new RestRequest("/api/item/price_list/row/details/" + selectedID);
                    request.AddHeader("Authorization", "Bearer " + token);
                    var response = client.Execute(request);
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
                                if (x.Value.ToString() != "{}")
                                {
                                    string itemCode = "";
                                    double price = 0.00;
                                    JObject jData = JObject.Parse(x.Value.ToString());
                                    foreach (var q in jData)
                                    {
                                        if (q.Key.Equals("item_code"))
                                        {
                                            itemCode = q.Value.ToString();
                                        }
                                        else if (q.Key.Equals("price"))
                                        {
                                            price = Convert.ToDouble(q.Value.ToString());
                                        }
                                    }
                                    lblItemCode.Text = "Item Code: " + itemCode;
                                    lblCurrentPrice.Text = "Current Price: " + price.ToString("n2");
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

        private void txtNewPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)
      && !char.IsDigit(e.KeyChar)
      && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if (e.KeyChar == '.'
                && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }
    }
}
