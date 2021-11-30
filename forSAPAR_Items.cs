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
    public partial class forSAPAR_Items : Form
    {
        utility_class utilityc = new utility_class();
        public string ids = "";
        public static bool isSubmit = false;
        public forSAPAR_Items()
        {
            InitializeComponent();
        }

        private void forSAPAR_Items_Load(object sender, EventArgs e)
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
                    var client = new RestClient(utilityc.URL);
                    client.Timeout = -1;
                    var request = new RestRequest("/api/sales/for_sap/get_total?ids=" + ids);
                    Console.WriteLine("/api/sales/for_sap/get_total?ids=" + ids);
                    request.AddHeader("Authorization", "Bearer " + token);
                    var response = client.Execute(request);
                    JObject jObjectResponse = JObject.Parse(response.Content);
                    dgv.Rows.Clear();
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
                        foreach (var z in jObjectResponse)
                        {
                            if (z.Key.Equals("count"))
                            {
                                lblCount.Text = "Total (" + Convert.ToInt32(z.Value.ToString()).ToString("N0") + ")";
                            }
                            if (z.Key.Equals("data"))
                            {
                                if (z.Value.ToString() != "[]")
                                {
                                    JArray jsonArray = JArray.Parse(z.Value.ToString());
                                    for (int i = 0; i < jsonArray.Count(); i++)
                                    {
                                        JObject jObjectData = JObject.Parse(jsonArray[i].ToString());
                                        string itemName = "";
                                        double quantity = 0.00;
                                        foreach (var y in jObjectData)
                                        {
                                            if (y.Key.Equals("item_code"))
                                            {
                                                itemName = y.Value.ToString();
                                            }
                                            else if (y.Key.Equals("quantity"))
                                            {
                                                quantity = Convert.ToDouble(y.Value.ToString());
                                            }
                                        }
                                        dgv.Rows.Add(itemName, quantity.ToString("n2"));
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("No data found", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                            }
                        }
                    }
                    else
                    {
                        foreach (var x in jObjectResponse)
                        {
                            if (x.Key.Equals("message"))
                            {
                                MessageBox.Show(x.Value.ToString(), "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                    }
                }
            }
            lblNoDataFound.Visible = (dgv.Rows.Count > 0 ? false : true);
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            //forSAPAR_SAPNumber forSAPAR_SAPNumber = new forSAPAR_SAPNumber();
            //forSAPAR_SAPNumber.ids = ids;
            //forSAPAR_SAPNumber.ShowDialog();
            //if (forSAPAR_SAPNumber.isSubmit)
            //{
            //    isSubmit = true;
            //    loadData();
            //}
        }
    }
}
