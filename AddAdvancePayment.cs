using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DeliciousPartnerApp.API_Class.Customer;
using Newtonsoft.Json.Linq;
using RestSharp;
using DeliciousPartnerApp.UI_Class;
namespace DeliciousPartnerApp
{
    public partial class AddAdvancePayment : Form
    {
        customer_class customerc = new customer_class();
        utility_class utilityc = new utility_class();
        public static bool isSubmit = false;
        public AddAdvancePayment()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            insertAdvancePayment();
        }

        public void insertAdvancePayment()
        {
            if (String.IsNullOrEmpty(txtCustomer.Text.Trim()))
            {
                MessageBox.Show("Code field is required", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCustomer.Focus();

            }
            else if (String.IsNullOrEmpty(txtRemarks.Text.Trim()))
            {
                MessageBox.Show("Remarks field is required", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtRemarks.Focus();
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure you want to add?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
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
                            var request = new RestRequest("/api/deposit/new");
                            request.AddHeader("Authorization", "Bearer " + token);
                            request.Method = Method.POST;

                            JObject jObject = new JObject();
                            jObject.Add("transdate", DateTime.Now.ToString("yyy-MM-dd HH:mm"));
                            jObject.Add("cust_code", txtCustomer.Text.Trim());
                            jObject.Add("amount", Convert.ToDouble(txtAmount.Text));
                            jObject.Add("remarks", txtRemarks.Text.Trim());
                            jObject.Add("reference2", (txtReference.Text.Trim() == String.Empty ? null : txtReference.Text.Trim()));
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
        }

        public void clearFields()
        {
            txtCustomer.Clear();
            txtAmount.Clear();
            txtReference.Clear();
            txtRemarks.Clear();
            txtSAPNumber.Clear();
        }

        private void AddAdvancePayment_Load(object sender, EventArgs e)
        {
            fillCustomer();
        }

        public void fillCustomer()
        {
            DataTable dtCustomers = new DataTable();
            dtCustomers = customerc.loadCustomers("");
            AutoCompleteStringCollection auto = new AutoCompleteStringCollection();
            foreach(DataRow r0w in dtCustomers.Rows)
            {
                auto.Add(r0w["code"].ToString());
            }
            txtCustomer.AutoCompleteCustomSource = auto;
        }

        private void txtSAPNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)
   && !char.IsDigit(e.KeyChar)
   && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if (e.KeyChar == '.'
                && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }
    }
}
