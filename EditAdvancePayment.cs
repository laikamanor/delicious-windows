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
using RestSharp;

namespace DeliciousPartnerApp
{
    public partial class EditAdvancePayment : Form
    {
        utility_class utilityc = new utility_class();
        public static bool isSubmit = false;
        public int id = 0;
        public EditAdvancePayment()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtRemarks.Text.Trim())){
                MessageBox.Show("Remarks field is required", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
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
                        bool isSuccess = false;
                        var client = new RestClient(utilityc.URL);
                        client.Timeout = -1;
                        //string branch = (cmbBranch.Text.Equals("") || cmbBranch.Text == "All" ? "" : cmbBranch.Text);
                        var request = new RestRequest("/api/deposit/update/" + id);
                        request.AddHeader("Authorization", "Bearer " + token);
                        request.Method = Method.PUT;

                        JObject jObject = new JObject();
                        jObject.Add("remarks", txtRemarks.Text.Trim());
                        jObject.Add("reference", (txtReference.Text.Trim() == String.Empty ? null : txtReference.Text.Trim()));
                        request.AddParameter("application/json", jObject, ParameterType.RequestBody);
                        var response = client.Execute(request);
                        jObject = JObject.Parse(response.Content.ToString());
                        foreach (var x in jObject)
                        {
                            if (x.Key.Equals("success"))
                            {
                                isSuccess = Convert.ToBoolean(x.Value.ToString());
                            }
                        }
                        string msg = "";
                        foreach (var x in jObject)
                        {
                            if (x.Key.Equals("message"))
                            {
                                msg = x.Value.ToString();
                            }
                        }
                        Cursor.Current = Cursors.Default;
                        if (isSuccess)
                        {
                            MessageBox.Show("Advance Payment Updated", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            isSubmit = true;
                            clearFields();
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
                }
            }
        }

        public void clearFields()
        {
            txtReference.Clear();
            txtRemarks.Clear();
        }

        private void EditAdvancePayment_FormClosing(object sender, FormClosingEventArgs e)
        {
            isSubmit = false;
        }

        private void EditAdvancePayment_Load(object sender, EventArgs e)
        {

        }
    }
}
