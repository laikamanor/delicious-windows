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
    public partial class AddGLAccount : Form
    {
        public AddGLAccount()
        {
            InitializeComponent();
        }
        utility_class utilityc = new utility_class();
        public static bool isSubmit = false;
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCode.Text.Trim()))
            {
                MessageBox.Show("Code field is required", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (string.IsNullOrEmpty(txtDescription.Text.Trim()))
            {
                MessageBox.Show("Description field is required", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                JObject joBody = new JObject();
                joBody.Add("code", txtCode.Text.Trim());
                joBody.Add("description", txtDescription.Text.Trim());
                apiPUT(joBody, "/api/glaccount/new");
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
                    request.AddHeader("Authorization", "Bearer " + token);
                    request.Method = Method.POST;

                    Console.WriteLine(body);
                    request.AddParameter("application/json", body, ParameterType.RequestBody);
                    var response = client.Execute(request);
                    if (response.ErrorMessage == null)
                    {
                        JObject jObjectResponse = JObject.Parse(response.Content);

                        foreach (var x in jObjectResponse)
                        {
                            if (x.Key.Equals("success"))
                            {
                                isSubmit = string.IsNullOrEmpty(x.Value.ToString()) ? false : Convert.ToBoolean(x.Value.ToString());
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
                    else
                    {
                        MessageBox.Show(response.ErrorMessage, "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                }
            }
        }

        private void txtCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                btnSubmit.PerformClick();
            }
        }
    }
}
