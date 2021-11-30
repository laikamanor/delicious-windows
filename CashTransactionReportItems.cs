using DeliciousPartnerApp.UI_Class;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Linq;
using System.Windows.Forms;

namespace DeliciousPartnerApp
{
    public partial class CashTransactionReportItems : Form
    {
        utility_class utilityc = new utility_class();
        public string URLDetails = "";
        public int selectedID = 0;
        public static bool isSubmit = false;
        public CashTransactionReportItems()
        {
            InitializeComponent();
        }

        private void CashTransactionReportItems_Load(object sender, EventArgs e)
        {
            dgvitems.Columns["amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            btnCancel.Visible = canCancel();
            loadData();
        }

        public void loadData()
        {
            Cursor.Current = Cursors.WaitCursor;
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
                    dgvitems.Rows.Clear();
                    var client = new RestClient(utilityc.URL);
                    client.Timeout = -1;
                   
                    var request = new RestRequest(URLDetails);
                    request.AddHeader("Authorization", "Bearer " + token);
                    var response = client.Execute(request);
                    JObject jObject = JObject.Parse(response.Content);
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
                                JObject jObjectData = JObject.Parse(x.Value.ToString());
                                foreach (var w in jObjectData)
                                {
                                    if (w.Key.Equals("payrows"))
                                    {
                                        JArray jsonArraySalesRow = JArray.Parse(w.Value.ToString());
                                        for (int i = 0; i < jsonArraySalesRow.Count(); i++)
                                        {
                                            JObject jObjectSalesRow = JObject.Parse(jsonArraySalesRow[i].ToString());
                                            int ID = 0, paymentID = 0;
                                            string paymentType = "", referenceNumber = "", sapNumber = "";
                                            double amountt = 0.00;
                                            foreach (var e in jObjectSalesRow)
                                            {
                                                if (e.Key.Equals("id"))
                                                {
                                                    ID = Convert.ToInt32(e.Value.ToString());
                                                }
                                                else if (e.Key.Equals("payment_id"))
                                                {
                                                    paymentID = Convert.ToInt32(e.Value.ToString());
                                                }
                                                else if (e.Key.Equals("payment_type"))
                                                {
                                                    paymentType =e.Value.ToString();
                                                }
                                                else if (e.Key.Equals("reference"))
                                                {
                                                    referenceNumber = e.Value.ToString();
                                                }
                                                else if (e.Key.Equals("sap_number"))
                                                {
                                                    sapNumber = e.Value.ToString();
                                                }
                                                else if (e.Key.Equals("amount"))
                                                {
                                                    amountt = Convert.ToDouble(e.Value.ToString());
                                                }

                                            }
                                            dgvitems.Rows.Add(ID,paymentID,paymentType, Convert.ToDecimal(string.Format("{0:0.00}", amountt)), referenceNumber,sapNumber);
                                        }
                                    }
                                    else if (w.Key.Equals("reference"))
                                    {
                                        txtReference.Text = w.Value.ToString();
                                    }
                                    else if (w.Key.Equals("transdate"))
                                    {
                                        DateTime dtTransDate = new DateTime();
                                        string replaceT = w.Value.ToString().Replace("T", "");
                                        dtTransDate = Convert.ToDateTime(replaceT);
                                        txtTransDate.Text = dtTransDate.ToString("yyyy-MM-dd");
                                    }
                                    else if (w.Key.Equals("cust_code"))
                                    {
                                        txtCustomerCode.Text = w.Value.ToString();
                                    }
                                    else if (w.Key.Equals("docstatus"))
                                    {
                                        string decodeDocStatus = w.Value.ToString() == "O" ? "Open" : w.Value.ToString() == "C" ? "Closed" : "Cancelled";
                                        txtDocStatus.Text = decodeDocStatus;
                                    }
                                    else if (w.Key.Equals("sap_number"))
                                    {
                                        txtSAPNumber.Text = (string.IsNullOrEmpty(w.Value.ToString()) ? "N/A" : w.Value.ToString());
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (canCancel())
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure you want to cancel?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    JObject jObject = new JObject();
                    string id = URLDetails.Replace("/api/payment/details/", "");
                    apiPUT(jObject, "/api/payment/void/" + id.Trim());
                }
            }
            else
            {
                MessageBox.Show("Access Denied", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                    request.AddHeader("Authorization", "Bearer " + token);
                    request.Method = Method.PUT;

                    request.AddParameter("application/json", body, ParameterType.RequestBody);
                    var response = client.Execute(request);
                    if (response.ErrorMessage == null)
                    {
                        if (response.Content.ToString().Substring(0, 1).Equals("{"))
                        {
                            JObject jObjectResponse = JObject.Parse(response.Content);

                            foreach (var x in jObjectResponse)
                            {
                                if (x.Key.Equals("success"))
                                {
                                    isSubmit = true;
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
                            MessageBox.Show(msg, "Message", MessageBoxButtons.OK, isSubmit ? MessageBoxIcon.Information : MessageBoxIcon.Warning);

                            if (isSubmit)
                            {
                                this.Dispose();
                            }
                        }
                        else
                        {
                            MessageBox.Show(response.Content.ToString(), "Error", MessageBoxButtons.OK, isSubmit ? MessageBoxIcon.Information : MessageBoxIcon.Warning);
                        }
                       
                    }
                    else
                    {
                        MessageBox.Show(response.ErrorMessage, "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                }
            }
        }

        public bool canCancel()
        {
            bool isCanGenerateExcel = false;
            if (Login.jsonResult != null)
            {
                foreach (var x in Login.jsonResult)
                {
                    if (x.Key.Equals("data"))
                    {
                        JObject jObjectData = JObject.Parse(x.Value.ToString());
                        foreach (var y in jObjectData)
                        {
                            if (y.Key.Equals("isAdmin") || y.Key.Equals("isManager"))
                            {
                                if (y.Value.ToString().ToLower() == "true")
                                {
                                    isCanGenerateExcel = true;
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            return isCanGenerateExcel;
        }

        private void dgvitems_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dgvitems.Rows.Count > 0)
            {
                if (e.ColumnIndex == 2)
                {
                    long id=0,intTemp = 0;
                    double amount = 0.00, doubleTemp = 0.00;
                    id = long.TryParse(dgvitems.CurrentRow.Cells["payment_id"].Value.ToString(), out intTemp) ? Convert.ToInt64(dgvitems.CurrentRow.Cells["payment_id"].Value.ToString()) : intTemp;
                    amount = double.TryParse(dgvitems.CurrentRow.Cells["amount"].Value.ToString(), out doubleTemp) ? Convert.ToDouble(dgvitems.CurrentRow.Cells["amount"].Value.ToString()) : doubleTemp;
                    CashTransactionReportDetails frm = new CashTransactionReportDetails();
                    frm.selectedID = id;
                    frm.reference = txtReference.Text;
                    frm.totalAmount = amount;
                    frm.ShowDialog();
                }
            }
        }
    }
}
