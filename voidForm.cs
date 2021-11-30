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
    public partial class voidForm : Form
    {
        public static bool isSubmit = false;
        public string selectedID = "";
        public string selectedReference = "";

        utility_class utilityc = new utility_class();
        public voidForm()
        {
            InitializeComponent();
        }

        private void voidForm_Load(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(lblOrderNumber, selectedReference);
            toolTip1.SetToolTip(label2, selectedReference);
        }

        private void voidForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            isSubmit = false;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtRemarks.Text.Trim()))
            {
                MessageBox.Show("Remarks field is required", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtRemarks.Focus();
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure you want to void?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                   voidFunction();
                }
            }
        }

        public void voidFunction()
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
                    var request = new RestRequest("/api/sales/void?ids=%5B" + selectedID + "%5D");
                    Console.WriteLine("/api/sales/void?ids=%5B" + selectedID + "%5D");
                    request.AddHeader("Authorization", "Bearer " + token);
                    request.Method = Method.PUT;

                    JObject jObjectBody = new JObject();
                    jObjectBody.Add("remarks", txtRemarks.Text.Trim());
                    request.AddParameter("application/json", jObjectBody, ParameterType.RequestBody);
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
                    MessageBox.Show(msg, isSubmit ? "Success" : "Validation", MessageBoxButtons.OK, isSubmit ? MessageBoxIcon.Information : MessageBoxIcon.Warning);

                    if (isSubmit)
                    {
                        this.Hide();
                    }
                }
            }
        }
    }
}
