using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using DeliciousPartnerApp.UI_Class;
namespace DeliciousPartnerApp
{
    public partial class forSAPAR_SAPNumber : Form
    {
        public static bool isSubmit = false;
        public string ids = "";
        utility_class utilityc = new utility_class();
        public forSAPAR_SAPNumber()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtRemarks.Text))
            {
                MessageBox.Show("Remarks field is required", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtRemarks.Focus();
            }
            else
            {
                updateSAPNumber();
            }
        }

        public void updateSAPNumber()
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
                    JArray jArrayIDs = new JArray();
                    var query = from val in ids.Split(',')
                                select int.Parse(val);
                    foreach (int num in query)
                    {
                        jArrayIDs.Add(num);
                    }

                    bool isSuccess = false;
                    var client = new RestClient(utilityc.URL);
                    client.Timeout = -1;
                    //string branch = (cmbBranch.Text.Equals("") || cmbBranch.Text == "All" ? "" : cmbBranch.Text);
                    var request = new RestRequest("/api/sales/for_sap/update");
                    request.AddHeader("Authorization", "Bearer " + token);
                    request.Method = Method.PUT;

                    JObject jObject = new JObject();
                    jObject.Add("ids", jArrayIDs);
                    jObject.Add("remarks", txtRemarks.Text.Trim());
                    jObject.Add("sap_number", (txtSAPNumber.Text.Trim() == String.Empty ? null : txtSAPNumber.Text.Trim()));
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
                        MessageBox.Show(msg, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        isSubmit = true;
                        clearFields();
                        this.Dispose();
                        this.Hide();
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

        public void clearFields()
        {
            txtSAPNumber.Clear();
            txtRemarks.Clear();
        }

        private void txtSAPNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
