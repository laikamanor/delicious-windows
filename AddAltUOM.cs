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
    public partial class AddAltUOM : Form
    {
        public AddAltUOM()
        {
            InitializeComponent();
        }
        utility_class utilityc = new utility_class();
        public int selectedID = 0;
        public string baseUom = "";
        public static bool isSubmit = false;
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtAltQuantity.Text.Trim()))
            {
                MessageBox.Show("Alt Qty field is required", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAltQuantity.Focus();
            }
            else if (Convert.ToDouble(txtAltQuantity.Text.Trim()) <= 0)
            {
                MessageBox.Show("Alt Qty field must be atleast 1", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAltQuantity.Focus();
            }
            else if (string.IsNullOrEmpty(cmbAltUOM.Text.Trim()))
            {
                MessageBox.Show("Alt UOM field is required", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbAltUOM.Focus();
            }
            else if (string.IsNullOrEmpty(txtBaseQty.Text.Trim()))
            {
                MessageBox.Show("Alt UOM field is required", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtBaseQty.Focus();
            }
            else if (Convert.ToDouble(txtBaseQty.Text.Trim()) <= 0)
            {
                MessageBox.Show("Base Qty field must be atleast 1", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtBaseQty.Focus();
            }
            else
            {
                JObject joBody = new JObject();
                joBody.Add("alt_qty", string.IsNullOrEmpty(txtAltQuantity.Text.Trim()) ? (double?)null : Convert.ToDouble(txtAltQuantity.Text.Trim()));
                joBody.Add("alt_uom", string.IsNullOrEmpty(cmbAltUOM.Text.Trim()) ? null : cmbAltUOM.Text.Trim());
                joBody.Add("base_qty", string.IsNullOrEmpty(txtBaseQty.Text.Trim()) ? (double?)null : Convert.ToDouble(txtBaseQty.Text.Trim()));
                joBody.Add("base_uom", string.IsNullOrEmpty(lblBaseUom.Text.Trim()) ? null : lblBaseUom.Text.Trim());
                joBody.Add("default", checkDefault.Checked);
                apiPUT(joBody, "/api/uom_grp/alt_uom/new/" + selectedID);
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
                    Console.WriteLine(URL);
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
                        MessageBox.Show(msg, isSubmit ? "Message" : "Validation" , MessageBoxButtons.OK, isSubmit ? MessageBoxIcon.Information : MessageBoxIcon.Warning);

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

        private void txtBaseQty_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                btnSubmit.PerformClick();
            }
        }

        private void txtBaseQty_KeyPress(object sender, KeyPressEventArgs e)
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

        public void loadBaseUOM()
        {
            if (Login.jsonResult != null)
            {
                Cursor.Current = Cursors.WaitCursor;
                cmbAltUOM.Items.Clear();
                DataTable dtUom = new DataTable();
                dtUom.Columns.Add("data");
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
                    //string branch = "A1-S";
                    var request = new RestRequest("/api/item/uom/getall");
                    request.AddHeader("Authorization", "Bearer " + token);
                    var response = client.Execute(request);
                    if (response.ErrorMessage == null)
                    {
                        if (response.Content.Substring(0, 1).Equals("{"))
                        {
                            JObject jObject = new JObject();
                            jObject = JObject.Parse(response.Content.ToString());
                            AutoCompleteStringCollection auto = new AutoCompleteStringCollection();
                            bool isSuccess = false;
                            foreach (var x in jObject)
                            {
                                if (x.Key.Equals("success"))
                                {
                                    isSuccess = Convert.ToBoolean(x.Value.ToString());
                                }
                            }
                            if (isSuccess)
                            {
                                foreach (var x in jObject)
                                {
                                    if (x.Key.Equals("data"))
                                    {
                                        if (x.Value.ToString() != "[]")
                                        {
                                            JArray jsonArray = JArray.Parse(x.Value.ToString());
                                            for (int i = 0; i < jsonArray.Count(); i++)
                                            {
                                                JObject data = JObject.Parse(jsonArray[i].ToString());
                                                string code = "";
                                                foreach (var q in data)
                                                {
                                                    if (q.Key.Equals("code"))
                                                    {
                                                        code = q.Value.ToString();
                                                    }
                                                }
                                                dtUom.Rows.Add(code);
                                            }
                                        }
                                    }
                                }
                            }
                            else
                            {
                                string msg = "No message response found";
                                foreach (var x in jObject)
                                {
                                    if (x.Key.Equals("message"))
                                    {
                                        msg = x.Value.ToString();
                                    }
                                }
                                MessageBox.Show(msg, "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                }
                foreach(DataRow row in dtUom.Rows)
                {
                    cmbAltUOM.Items.Add(row["data"].ToString());
                }
                Cursor.Current = Cursors.Default;
            }
        }

        private void AddAltUOM_Load(object sender, EventArgs e)
        {
            loadBaseUOM();
            lblBaseUom.Text = baseUom;
        }
    }
}
