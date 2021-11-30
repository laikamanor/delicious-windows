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
    public partial class AddUOM : Form
    {
        public AddUOM()
        {
            InitializeComponent();
        }
        utility_class utilityc = new utility_class();
        public static  bool isSubmit = false;
        private void AddUOM_Load(object sender, EventArgs e)
        {

        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (txtCode.Text.ToString().Trim() == "")
            {
                MessageBox.Show("Code field is required", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCode.Focus();
            }
            else if (txtDescription.Text.ToString().Trim() == "")
            {
                MessageBox.Show("Name field is required", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDescription.Focus();
            }
            else
            {
                insertUOM();
            }
        }

        public void insertUOM()
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
                    var request = new RestRequest("/api/item/uom/create");
                    request.AddHeader("Authorization", "Bearer " + token);
                    request.Method = Method.POST;

                    JObject jObject = new JObject();
                    jObject.Add("code", (txtCode.Text == String.Empty ? null : txtCode.Text));
                    jObject.Add("description", (txtDescription.Text == String.Empty ? null : txtDescription.Text));

                    Console.WriteLine(jObject);
                    request.AddParameter("application/json", jObject, ParameterType.RequestBody);
                    var response = client.Execute(request);
                    if(response.ErrorMessage == null)
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
                                    isSuccess = Convert.ToBoolean(x.Value.ToString());
                                }
                            }

                            if (isSuccess)
                            {
                                txtCode.Clear();
                                txtDescription.Clear();
                                isSubmit = true;
                                MessageBox.Show(msg, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Dispose();
                            }
                            else
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
                            MessageBox.Show(response.Content, "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show(response.ErrorMessage, "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    Cursor.Current = Cursors.Default;
                }
            }
        }
    }
}
