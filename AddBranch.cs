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
    public partial class AddBranch : Form
    {
        utility_class utilityc = new utility_class();
        public static bool isSubmit = false;
        public AddBranch()
        {
            InitializeComponent();
        }

        private async void btnSubmit_Click(object sender, EventArgs e)
        {
            if (txtCode.Text.ToString().Trim() == "")
            {
                MessageBox.Show("Code field is required", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCode.Focus();
            }
            else if (txtName.Text.ToString().Trim() == "")
            {
                MessageBox.Show("Name field is required", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure you want to submit?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    await Task.Run(() => insertBranch());
                }
            }
        }

        public async void insertBranch()
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
                    var request = new RestRequest("/api/branch/new");
                    request.AddHeader("Authorization", "Bearer " + token);
                    request.Method = Method.POST;

                    JObject jObject = new JObject();
                    jObject.Add("code", (txtCode.Text == String.Empty ? null : txtCode.Text));
                    jObject.Add("name", (txtName.Text == String.Empty ? null : txtName.Text));

                    Console.WriteLine(jObject);
                    request.AddParameter("application/json", jObject, ParameterType.RequestBody);
                    Task<IRestResponse> t = client.ExecuteAsync(request);
                    t.Wait();
                    var response = await t;
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
                            isSuccess = isSubmit = Convert.ToBoolean(x.Value.ToString());
                        }
                    }

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
                    else
                    {
                        DialogResult dialogResult = MessageBox.Show(msg, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if(dialogResult == DialogResult.OK)
                        {
                            this.Invoke(new Action(delegate ()
                            {
                                this.Dispose();
                            }));
                        }
                    }
                    Cursor.Current = Cursors.Default;
                }
            }
        }

        private void AddBranch_Load(object sender, EventArgs e)
        {

        }
    }
}
