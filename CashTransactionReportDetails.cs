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
using Newtonsoft.Json;
using System.Globalization;

namespace DeliciousPartnerApp
{
    public partial class CashTransactionReportDetails : Form
    {
        public CashTransactionReportDetails()
        {
            InitializeComponent();
        }
        utility_class utilityc = new utility_class();
        public long selectedID = 0;
        public double totalAmount = 0.00;
        public string reference = "";
        private void CashTransactionReportDetails_Load(object sender, EventArgs e)
        {
            lblReference.Text = reference;
            lblTotalAmount.Text = totalAmount.ToString("n2");
            DataTable dt = getResponse();
            if(dt.Columns.Count > 0 && dt.Rows.Count > 0)
            {
                dgv.DataSource = dt;

                for(int i =0; i <dgv.Columns.Count; i++)
                {
                    dgv.Columns[i].ReadOnly = true;
                    string x = dgv.Columns[i].HeaderText.ToString().Replace("_", " ");
                    string v = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(x.ToLower());
                    dgv.Columns[i].HeaderText = v;

                    //format
                    dgv.Columns[i].DefaultCellStyle.Format = v.Equals("Doctotal") || v.Equals("Balance Due") || v.Equals("Total Payment") ? "n2" : "";
                    dgv.Columns[i].DefaultCellStyle.Alignment = v.Equals("Doctotal") || v.Equals("Balance Due") || v.Equals("Total Payment") ? DataGridViewContentAlignment.MiddleRight : DataGridViewContentAlignment.MiddleLeft;
                }
            }
        }



        public DataTable getResponse()
        {
            DataTable dt = new DataTable();
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
                    var request = new RestRequest("/api/payment/paidsales/" + selectedID);
                    Console.WriteLine("/api/payment/paidsales/" + selectedID);
                    request.AddHeader("Authorization", "Bearer " + token);
                    request.Method = Method.GET;
                    var response = client.Execute(request);
                    bool isSubmit = false;
                    if (response.ErrorMessage == null)
                    {
                        if (response.Content.ToString().Substring(0, 1).Equals("{"))
                        {
                            JObject jObjectResponse = JObject.Parse(response.Content);
                            string data = "";
                            foreach (var x in jObjectResponse)
                            {
                                if (x.Key.Equals("success"))
                                {
                                    isSubmit = true;
                                }else if (x.Key.Equals("data"))
                                {
                                    data = x.Value.ToString();
                                }
                            }
                            if (data.Substring(0, 1).Equals("["))
                            {
                                dt =(DataTable)JsonConvert.DeserializeObject(data, (typeof(DataTable)));
                            }
                            string msg = "No message response found";
                            foreach (var x in jObjectResponse)
                            {
                                if (x.Key.Equals("message"))
                                {
                                    msg = x.Value.ToString();
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show(response.Content.ToString(), "Error", MessageBoxButtons.OK, isSubmit ? MessageBoxIcon.Information : MessageBoxIcon.Warning);
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
    }
}
