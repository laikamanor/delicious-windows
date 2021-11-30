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
using AB.UI_Class;
namespace AB
{
    public partial class SalesPerCustomer : Form
    {
        public SalesPerCustomer()
        {
            InitializeComponent();
        }
        utility_class utilityc = new utility_class();
        private void SalesPerCustomer_Load(object sender, EventArgs e)
        {
            loadData();
        }

        public void loadData()
        {
            if (Login.jsonResult != null)
            {
                Cursor.Current = Cursors.WaitCursor;
                AutoCompleteStringCollection auto = new AutoCompleteStringCollection();
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
                    var request = new RestRequest("/api/report/customer/sales_summary");
                    request.AddHeader("Authorization", "Bearer " + token);
                    var response = client.Execute(request);
                    JObject jObject = new JObject();
                    if (response.ErrorMessage == null)
                    {
                        if (response.Content.ToString().Substring(0, 1).Equals("{"))
                        {
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
                                                double balance = 0.00;
                                                string customerCode = "";
                                                foreach (var q in data)
                                                {
                                                    if (q.Key.Equals("cust_code"))
                                                    {
                                                        customerCode = q.Value.ToString();
                                                        auto.Add(q.Value.ToString());
                                                    }
                                                    else if (q.Key.Equals("balance"))
                                                    {
                                                        balance = Convert.ToDouble(q.Value.ToString());
                                                    }
                                                }

                                                if (!string.IsNullOrEmpty(txtSearch.Text.ToString().Trim()))
                                                {
                                                    if (txtSearch.Text.ToString().Trim().ToLower().Contains(customerCode.ToLower()))
                                                    {
                                                        dgv.Rows.Add(customerCode, Convert.ToDecimal(string.Format("{0:0.00}", balance)));
                                                        break;
                                                    }
                                                }
                                                else
                                                {
                                                    dgv.Rows.Add(customerCode, Convert.ToDecimal(string.Format("{0:0.00}", balance)));
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
                                MessageBox.Show(msg, "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                        else
                        {
                            MessageBox.Show(response.Content.ToString(), "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show(response.ErrorMessage, "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                txtSearch.AutoCompleteCustomSource = auto;
                Cursor.Current = Cursors.Default;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            loadData();
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                loadData();
            }
        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv.Rows.Count > 0)
            {
                if (e.RowIndex >= 0)
                {
                    SalesPerCustomer_Details details = new SalesPerCustomer_Details();
                    details.lblCustomerCode.Text = dgv.CurrentRow.Cells["customer_code"].Value.ToString();
                    details.ShowDialog();
                }
            }
        }
    }
}
