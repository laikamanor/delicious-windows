using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DeliciousPartnerApp.API_Class.Customer_Type;
using DeliciousPartnerApp.API_Class.Warehouse;
using DeliciousPartnerApp.UI_Class;
using Newtonsoft.Json.Linq;
using RestSharp;
namespace DeliciousPartnerApp
{
    public partial class AddCustomer : Form
    {
        customertype_class customertypec = new customertype_class();
        utility_class utilityc = new utility_class();
        DataTable dtCustomerTypes;
        public string gType = "";
        public static bool isSubmit = false;
        public AddCustomer(string type)
        {
            gType = type;
            InitializeComponent();
        }

        private void AddCustomer_Load(object sender, EventArgs e)
        {
            loadCustomerTypes();
        }

        public void loadCustomerTypes()
        {
            dtCustomerTypes = new DataTable();
            dtCustomerTypes = customertypec.loadCustomerTypes();
            if(dtCustomerTypes.Rows.Count > 0)
            {
                cmbCustomerType.Items.Clear();
                foreach(DataRow row in dtCustomerTypes.Rows)
                {
                    cmbCustomerType.Items.Add(row["name"].ToString());
                }
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCode.Text.Trim()))
            {
                MessageBox.Show("Code field is required", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCode.Focus();
            }
            else if (string.IsNullOrEmpty(txtName.Text.Trim()))
            {
                MessageBox.Show("Name field is required", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
            }
            else if (string.IsNullOrEmpty(cmbCustomerType.Text.Trim()))
            {
                MessageBox.Show("Customer Type field is required", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbCustomerType.Focus();
            }
            else if (gType.Equals("Add"))
            {
                insertCustomer();
            }
            else if (gType.Equals("Edit"))
            {
                insertCustomer();
            }
        }

        public void insertCustomer()
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
                    var request = new RestRequest("/api/customer/new");
                    request.AddHeader("Authorization", "Bearer " + token);
                    request.Method = Method.POST;

                    JObject jObject = new JObject();
                    JObject joHeader = new JObject();
                    joHeader.Add("code", (txtCode.Text == String.Empty ? null : txtCode.Text));
                    joHeader.Add("name", (txtName.Text == String.Empty ? null : txtName.Text));

                    int cust_id = 0;
                    foreach(DataRow row in dtCustomerTypes.Rows)
                    {
                        if(cmbCustomerType.Text == row["name"].ToString())
                        {
                            cust_id = Convert.ToInt32(row["id"].ToString());
                        }
                    }
                    joHeader.Add("cust_type", cust_id);

                    JArray jarrayDetails = new JArray();

                    for (int i = 0; i < dgv.Rows.Count; i++)
                    {
                        JObject joDetails = new JObject();

                        string firstName = dgv.Rows[i].Cells["first_name"].Value.ToString(),
                            middleName = dgv.Rows[i].Cells["middle_initial"].Value.ToString(),
                            lastName = dgv.Rows[i].Cells["last_name"].Value.ToString(),
                            birthDate = dgv.Rows[i].Cells["birthdate"].Value.ToString(),
                            landLineNumber = dgv.Rows[i].Cells["landline_number"].Value.ToString(),
                            mobileNumber = dgv.Rows[i].Cells["mobile_number"].Value.ToString(),
                           aDdress = dgv.Rows[i].Cells["address"].Value.ToString(),
                           emailAddress = dgv.Rows[i].Cells["email_address"].Value.ToString();

                        joDetails.Add("first_name", firstName);
                        joDetails.Add("middle_initial", middleName);
                        joDetails.Add("last_name", lastName);

                        if (string.IsNullOrEmpty(birthDate))
                        {
                            joDetails.Add("birthdate", null);
                        }
                        else
                        {
                            joDetails.Add("birthdate", birthDate);
                        }
                        joDetails.Add("landline_number", Convert.ToInt32(landLineNumber));
                        joDetails.Add("mobile_number", Convert.ToInt32(mobileNumber));

                        if (string.IsNullOrEmpty(aDdress))
                        {
                            joDetails.Add("address", null);
                        }
                        else
                        {
                            joDetails.Add("address", aDdress);
                        }

                        if (string.IsNullOrEmpty(emailAddress))
                        {
                            joDetails.Add("email", null);
                        }
                        else
                        {
                            joDetails.Add("email", emailAddress);
                        }
                        jarrayDetails.Add(joDetails);
                    }
                    jObject.Add("header", joHeader);
                    jObject.Add("details", jarrayDetails);

                    Console.WriteLine(jObject);
                    request.AddParameter("application/json", jObject, ParameterType.RequestBody);
                    var response = client.Execute(request);
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
                                    isSuccess = Convert.ToBoolean(x.Value.ToString());
                                    txtCode.Clear();
                                    txtName.Clear();
                                    isSubmit = true;
                                    MessageBox.Show(msg, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    txtCode.Clear();
                                    txtName.Clear();
                                    cmbCustomerType.SelectedIndex = -1;
                                    this.Dispose();
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
                    Cursor.Current = Cursors.Default;
                }
            }
        }

        private void btnAddCustomerDetails_Click(object sender, EventArgs e)
        {
            AddCustomer_Details details = new AddCustomer_Details();
            details.ShowDialog();
            if (AddCustomer_Details.isSubmit)
            {
                string firstName = AddCustomer_Details.firstName,
    middleName = AddCustomer_Details.middleName, lastName = AddCustomer_Details.lastName, landlineNo = AddCustomer_Details.landlineNo, mobileNo = AddCustomer_Details.mobileNo, email = AddCustomer_Details.email, address = AddCustomer_Details.address, birthDate = AddCustomer_Details.birthDate;

                dgv.Rows.Add(firstName, middleName, lastName, birthDate, landlineNo, mobileNo, email, address);
            }
        }

        private void AddCustomer_SizeChanged(object sender, EventArgs e)
        {
            dgv.AutoSizeColumnsMode = this.WindowState == FormWindowState.Maximized ? DataGridViewAutoSizeColumnsMode.Fill : DataGridViewAutoSizeColumnsMode.None;
        }
    }
}
