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
    public partial class EditBranch : Form
    {
        utility_class utilityc = new utility_class();
        public int selectedID = 0;
        public static bool isSubmit = false;
        public string selectedCode = "", selectedName = "";
        public EditBranch()
        {
            InitializeComponent();
        }

        private void EditBranch_Load(object sender, EventArgs e)
        {
            lblCode.Text = selectedCode;
            txtName.Text = selectedName;
        }

        private async void btnSubmit_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to remove?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                if (string.IsNullOrEmpty(txtName.Text))
                {
                    MessageBox.Show("Name field is required", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtName.Focus();
                }
                else
                {
                    Cursor.Current = Cursors.WaitCursor;
                    await Task.Run(() => updateBranch());
                    Cursor.Current = Cursors.Default;
                }
            }
        }

        public async void updateBranch()
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
                    var request = new RestRequest("/api/branch/update/" + selectedID);
                    request.AddHeader("Authorization", "Bearer " + token);
                    request.Method = Method.PUT;

                    JObject jObject = new JObject();

                    if (txtName.Text != selectedName && !string.IsNullOrEmpty(txtName.Text.Trim()))
                    {
                        jObject.Add("name", txtName.Text.Trim());
                    }
                    Console.WriteLine(jObject);
                    request.AddParameter("application/json", jObject, ParameterType.RequestBody);
                    Task<IRestResponse> t = client.ExecuteAsync(request);
                    t.Wait();
                    var response = await t;
                    if (response.ErrorMessage == null)
                    {
                        if (response.Content.Substring(0, 1).Equals("{"))
                        {
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
                                    isSuccess = true;
                                    isSubmit = true;
                                }
                            }
                            if (!isSuccess)
                            {
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
                            else
                            {
                                DialogResult dialogResult = MessageBox.Show(msg, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                if (dialogResult == DialogResult.OK)
                                {
                                    this.Invoke(new Action(delegate ()
                                    {
                                        this.Dispose();
                                    }));
                                }
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
            }
        }
    }
}
