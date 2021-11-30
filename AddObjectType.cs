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
    public partial class AddObjectType : Form
    {
        public AddObjectType()
        {
            InitializeComponent();
        }
        utility_class utilityc = new utility_class();
        public static bool isSubmit = false;
        public void insertObjectType()
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
                    var request = new RestRequest("/api/objtype/new");
                    request.AddHeader("Authorization", "Bearer " + token);
                    request.Method = Method.POST;

                    JObject jObject = new JObject();
                    jObject.Add("code", (txtCode.Text == String.Empty ? null : txtCode.Text));
                    jObject.Add("objtype", (txtObjType.Text == String.Empty ? null : txtObjType.Text));
                    jObject.Add("description", (txtDescription.Text == String.Empty ? null : txtDescription.Text));
                    jObject.Add("table", (txtTable.Text == String.Empty ? null : txtTable.Text));

                    Console.WriteLine(jObject);
                    request.AddParameter("application/json", jObject, ParameterType.RequestBody);
                    var response = client.Execute(request);

                    if(response.ErrorMessage == null)
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
                            txtTable.Clear();
                            txtDescription.Clear();
                            isSubmit = true;
                            MessageBox.Show(msg, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Dispose();
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

        private void btnSubmit_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCode.Text.Trim()))
            {
                MessageBox.Show("Code field is required", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCode.Focus();
            }

            else if (string.IsNullOrEmpty(txtObjType.Text.Trim()))
            {
                MessageBox.Show("txtObjType field is required", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtObjType.Focus();
            }

            else if (string.IsNullOrEmpty(txtDescription.Text.Trim()))
            {
                MessageBox.Show("Description field is required", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDescription.Focus();
            }
            else if (string.IsNullOrEmpty(txtTable.Text.Trim()))
            {
                MessageBox.Show("Table field is required", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTable.Focus();
            }
            else
            {
                insertObjectType();
            }
        }
    }
}
