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
    public partial class AddPriceList : Form
    {
        public AddPriceList()
        {
            InitializeComponent();
        }
        public static bool isSubmit = false;
        utility_class utilityc = new utility_class();
        private void AddPriceList_Load(object sender, EventArgs e)
        {
            isSubmit = false;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCode.Text.Trim()))
            {
                MessageBox.Show("Code field is required", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (string.IsNullOrEmpty(txtName.Text.Trim()))
            {
                MessageBox.Show("Description field is required", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                insertPriceList();
            }
        }

        public void insertPriceList()
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
                    //string branch = (cmbBranch.Text.Equals("") || cmbBranch.Text == "All" ? "" : cmbBranch.Text);
                    var request = new RestRequest("/api/item/pricelist/new");
                    request.AddHeader("Authorization", "Bearer " + token);
                    request.Method = Method.POST;

                    JObject jObject = new JObject();
                    jObject.Add("code", (txtCode.Text == String.Empty ? null : txtCode.Text));
                    jObject.Add("description", (txtName.Text == String.Empty ? null : txtName.Text));

                    Console.WriteLine(jObject);
                    request.AddParameter("application/json", jObject, ParameterType.RequestBody);
                    var response = client.Execute(request);
                    jObject = JObject.Parse(response.Content.ToString());
                    bool isSuccess = false;

                    string msg = "No message response found";
                    foreach (var x in jObject)
                    {
                        if (x.Key.Equals("message"))
                        {
                            msg = x.Value.ToString();
                        }
                    }

                    foreach (var x in jObject)
                    {
                        if (x.Key.Equals("success"))
                        {
                            isSuccess = Convert.ToBoolean(x.Value.ToString());
                            txtCode.Clear();
                            txtName.Clear();
                            isSubmit = true;
                            MessageBox.Show(msg, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            if (!isSuccess)
                            {
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
                    }
                    Cursor.Current = Cursors.Default;
                }
            }
        }
    }
}
