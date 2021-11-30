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
using DeliciousPartnerApp.API_Class.Advance_Payment;
namespace DeliciousPartnerApp
{
    public partial class AdvancePayment2 : Form
    {
        advancepayment_class advancepaymentc = new advancepayment_class();
        utility_class utilityc = new utility_class();
        string gType = "";
        public AdvancePayment2(string type)
        {
            gType = type;
            InitializeComponent();
        }

        private void AdvancePayment_Load(object sender, EventArgs e)
        {
            lblTotal.Visible = isAdmin();
            cmbStatus.SelectedIndex = 0;

            //kapag summary deposit
            cmbStatus.Visible = gType.Equals("Summary Deposit") ? false : true;
            label1.Visible = gType.Equals("Summary Deposit") ? false : true;
            txtSearch.Visible = gType.Equals("Summary Deposit") ? false : true;
            btnSearch.Visible = gType.Equals("Summary Deposit") ? false : true;
            btnAddUser.Visible = gType.Equals("Summary Deposit") || gType.Equals("Used Deposit") ? false : true;
            dgv.Columns["amountdue"].Visible = gType.Equals("Summary Deposit") ? false : true;
            dgv.Columns["remarks"].Visible = gType.Equals("Summary Deposit") ? false : true;
            dgv.Columns["referencenum"].Visible = gType.Equals("Summary Deposit") ? false : true;
            dgv.Columns["sap_number"].Visible = gType.Equals("Summary Deposit") ? false : true;
            dgv.Columns["status"].Visible = gType.Equals("Summary Deposit") ? false : true;
            dgv.Columns["transdate"].Visible = gType.Equals("Summary Deposit") ? false : true;
            dgv.Columns["btnEdit"].Visible = gType.Equals("Summary Deposit") || gType.Equals("Used Deposit") ? false : true;
            dgv.Columns["btnCancel"].Visible = gType.Equals("Summary Deposit") || gType.Equals("Used Deposit") ? false : true;
        }

        public bool isAdmin()
        {
            bool result = false;
            if (Login.jsonResult != null)
            {
                foreach (var x in Login.jsonResult)
                {
                    if (x.Key.Equals("data"))
                    {
                        JObject jObjectData = JObject.Parse(x.Value.ToString());
                        foreach (var y in jObjectData)
                        {
                            if (y.Key.Equals("isAdmin"))
                            {
                                if (y.Value.ToString().ToLower() == "true")
                                {
                                    result = true;
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            return result;
        }

        public void loadData()
        {
            DataTable dtResponse = new DataTable();
            string status = "";
             if (cmbStatus.SelectedIndex.Equals(1))
            {
                status = "O";
            }
            else if (cmbStatus.SelectedIndex.Equals(2))
            {
                status = "C";
            }
            else if (cmbStatus.SelectedIndex.Equals(3))
            {
                status = "N";
            }
            else
            {
                status = "";
            }

            dtResponse = advancepaymentc.loadData(status,gType);
            dgv.Rows.Clear();
            if(dtResponse.Rows.Count > 0)
            {
                lblNoDataFound.Visible = false;
                AutoCompleteStringCollection auto = new AutoCompleteStringCollection();
                foreach (DataRow r0w in dtResponse.Rows)
                {
                    double amount = Convert.ToDouble(r0w["amount"].ToString());
                    double balance = Convert.ToDouble(r0w["balance"].ToString());
                    auto.Add(r0w["reference"].ToString());
                    auto.Add(r0w["cust_code"].ToString());
                    auto.Add(r0w["remarks"].ToString());
                    if (!string.IsNullOrEmpty(txtSearch.Text.ToString().Trim()))
                    {
                        if (txtSearch.Text.ToString().Trim().ToLower().Contains(r0w["reference"].ToString().ToLower()))
                        {
                            dgv.Rows.Add(r0w["id"], r0w["transdate"], r0w["reference"], r0w["cust_code"], Convert.ToDecimal(string.Format("{0:0.00}", amount)), Convert.ToDecimal(string.Format("{0:0.00}", balance)), r0w["remarks"], r0w["sap_number"], r0w["reference2"], r0w["status"]);
                        }
                        else if (txtSearch.Text.ToString().Trim().ToLower().Contains(r0w["cust_code"].ToString().ToLower()))
                        {
                            dgv.Rows.Add(r0w["id"], r0w["transdate"], r0w["reference"], r0w["cust_code"], Convert.ToDecimal(string.Format("{0:0.00}", amount)), Convert.ToDecimal(string.Format("{0:0.00}", balance)), r0w["remarks"], r0w["sap_number"], r0w["reference2"], r0w["status"]);
                        }
                        else if (txtSearch.Text.ToString().Trim().ToLower().Contains(r0w["remarks"].ToString().ToLower()))
                        {
                            dgv.Rows.Add(r0w["id"], r0w["transdate"], r0w["reference"], r0w["cust_code"], Convert.ToDecimal(string.Format("{0:0.00}", amount)), Convert.ToDecimal(string.Format("{0:0.00}", balance)), r0w["remarks"], r0w["sap_number"], r0w["reference2"], r0w["status"]);
                        }
                    }
                    else
                    {
                        dgv.Rows.Add(r0w["id"], r0w["transdate"], r0w["reference"] ,r0w["cust_code"], Convert.ToDecimal(string.Format("{0:0.00}", amount)), Convert.ToDecimal(string.Format("{0:0.00}", balance)), r0w["remarks"], r0w["sap_number"] ,r0w["reference2"], r0w["status"]);
                    }
                }
                txtSearch.AutoCompleteCustomSource = auto;
                dgv.Columns["amountdue"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgv.Columns["balance"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
            else
            {
                lblNoDataFound.Visible = true;
            }
            getTotal();
        }

        public void getTotal()
        {
            if (gType.Equals("Summary Deposit"))
            {
                if (dgv.Rows.Count > 0)
                {
                    double total = 0.00;
                    for (int i = 0; i < dgv.Rows.Count; i++)
                    {
                        total += string.IsNullOrEmpty(dgv.Rows[i].Cells["balance"].Value.ToString()) ? 0.00 : Convert.ToDouble(dgv.Rows[i].Cells["balance"].Value.ToString());
                    }
                    lblTotal.Text = "Total: " + total.ToString("n2");
                }
                else
                {
                    lblTotal.Text = "Total: 0.00";
                }
            }
            else
            {
                lblTotal.Visible = false;
            }
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            AddAdvancePayment addAdvancePayment = new AddAdvancePayment();
            addAdvancePayment.ShowDialog();
            if (AddAdvancePayment.isSubmit)
            {
                loadData();
            }
        }

        private void cmbBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadData();
        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dgv.Rows.Count > 0)
            {
                int id = Convert.ToInt32(dgv.CurrentRow.Cells["id"].Value.ToString());
                if (e.ColumnIndex.Equals(10))
                {
                    EditAdvancePayment editAdvancePayment = new EditAdvancePayment();
                    editAdvancePayment.id = id;
                    editAdvancePayment.ShowDialog();
                    if (EditAdvancePayment.isSubmit)
                    {
                        loadData();
                    }
                }
                else if (e.ColumnIndex.Equals(11))
                {
                    cancelAP(id);
                }
                else if (e.ColumnIndex.Equals(3) && gType.Equals("Summary Deposit"))
                {
                    SummaryDeposit_Details summaryDeposit_Details = new SummaryDeposit_Details();
                    summaryDeposit_Details.lblCustomerCode.Text = dgv.CurrentRow.Cells["cust_code"].Value.ToString();
                    summaryDeposit_Details.ShowDialog();
                }
                else if (e.ColumnIndex.Equals(2) && gType.Equals("Used Deposit"))
                {
                    ItemDeposit itemDeposit = new ItemDeposit();
                    itemDeposit.selectedID = String.IsNullOrEmpty(dgv.CurrentRow.Cells["id"].Value.ToString()) ? 0 : Convert.ToInt32(dgv.CurrentRow.Cells["id"].Value.ToString());
                    itemDeposit.ShowDialog();
                }
            }
        }

        public void cancelAP(int id)
        {
            string remarks = "";
            double amount = 0.00;
            AmountRemaks amountRemarks = new AmountRemaks();
            amountRemarks.ShowDialog();
            if (AmountRemaks.isSubmit)
            {
                remarks = AmountRemaks.remarks;
                amount = AmountRemaks.amount;
                DialogResult dialogResult = MessageBox.Show("Are you sure you want to cashout?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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
                            JObject body = new JObject();
                            body.Add("amount", amount);
                            body.Add("remarks", remarks);
                            bool isSuccess = false;
                            var client = new RestClient(utilityc.URL);
                            client.Timeout = -1;
                            var request = new RestRequest("/api/deposit/cancel/" + id);
                            request.AddHeader("Authorization", "Bearer " + token);
                            request.Method = Method.PUT;
                            Console.WriteLine(body);
                            request.AddParameter("application/json", body, ParameterType.RequestBody);
                            var response = client.Execute(request);
                            JObject jObject = JObject.Parse(response.Content.ToString());
                            foreach (var x in jObject)
                            {
                                if (x.Key.Equals("success"))
                                {
                                    if (Convert.ToBoolean(x.Value.ToString()))
                                    {
                                        isSuccess = true;
                                        break;
                                    }
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
                            if (isSuccess)
                            {
                                MessageBox.Show(msg, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                loadData();
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
                        Cursor.Current = Cursors.Default;
                    }
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            loadData();
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                loadData();
            }
        }
    }
}
