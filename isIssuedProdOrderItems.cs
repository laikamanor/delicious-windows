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
    public partial class isIssuedProdOrderItems : Form
    {
        public isIssuedProdOrderItems(string prodType)
        {
            gProdType = prodType;
            InitializeComponent();
        }
        utility_class utilityc = new utility_class();
        public int selectedID = 0;
        string gProdType = "";
        private void isIssuedProdOrderItems_Load(object sender, EventArgs e)
        {
            this.Text = gProdType;
            dgv.Columns["confirm"].Visible = gProdType.Equals("Issue for Production Order") ? true : false;
            dgv.Columns["prod_order_ref"].Visible = gProdType.Equals("Issue for Production Order") ? true : false;
            dgv.Columns["date_confirmed"].HeaderText = gProdType.Equals("Issue for Production Order") ? "Date Confirmed" : "Date Created";
            loadData();
        }

        public void loadData()
        {
            if (Login.jsonResult != null)
            {
                Cursor.Current = Cursors.WaitCursor;
                AutoCompleteStringCollection auto = new AutoCompleteStringCollection();
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
                    string sURL = gProdType == "Issue for Production Order" ? "/api/production/issue_for_prod/get_all?mode&prod_order_id=" : "/api/production/rec_from_prod/get_all?prod_order_id=";
                    var request = new RestRequest(sURL+ selectedID);
                    request.AddHeader("Authorization", "Bearer " + token);
                    var response = client.Execute(request);
                    JObject jObject = new JObject();
                    jObject = JObject.Parse(response.Content.ToString());
                    dgv.Rows.Clear();
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
                                        int id = 0;
                                        string reference = "", docStatus = "", sDocStatus = "", sapNumber = "", remarks = "", sConfirm = "", prodOrderRef = "";
                                        DateTime dtTransDate = new DateTime(), dtConfirmedDate = new DateTime();
                                        bool isConfirm = false;
                                        foreach (var q in data)
                                        {
                                            if (q.Key.Equals("id"))
                                            {
                                                id = q.Value.ToString() == "" ? 0 : Convert.ToInt32(q.Value.ToString());
                                            }
                                            else if (q.Key.Equals("transdate"))
                                            {
                                                string replaceT = q.Value.ToString().Replace("T", "");
                                                dtTransDate = Convert.ToDateTime(replaceT);
                                            }
                                            else if (q.Key.Equals("reference"))
                                            {
                                                reference = q.Value.ToString();
                                                auto.Add(reference);
                                            }
                                            else if (q.Key.Equals("docstatus"))
                                            {
                                                docStatus = q.Value.ToString();
                                                sDocStatus = q.Value.ToString() == "" ? "" : q.Value.ToString() == "O" ? "Open" : q.Value.ToString() == "C" ? "Closed" : q.Value.ToString() == "N" ? "Cancelled" : q.Value.ToString();
                                            }
                                            else if (q.Key.Equals("sap_number"))
                                            {
                                                sapNumber = q.Value.ToString();
                                            }
                                            else if (q.Key.Equals("remarks"))
                                            {
                                                remarks = q.Value.ToString();
                                            }
                                            else if (q.Key.Equals("confirm"))
                                            {
                                                isConfirm = q.Value.ToString() == "" ? false : Convert.ToBoolean(q.Value.ToString());
                                                sConfirm = isConfirm ? "✓" : "";
                                            }
                                            else if (q.Key.Equals("prod_order_ref"))
                                            {
                                                prodOrderRef = q.Value.ToString();
                                            }
                                            else if (gProdType.Equals("Issue for Production Order")  ? q.Key.Equals("date_confirmed") : q.Key.Equals("date_created"))
                                            {
                                                string replaceT = q.Value.ToString().Replace("T", "");
                                                dtConfirmedDate = Convert.ToDateTime(replaceT);
                                            }
                                        }
                                        if (!string.IsNullOrEmpty(txtSearch.Text.ToString().Trim()))
                                        {
                                            if (txtSearch.Text.ToString().Trim().ToLower().Contains(reference.ToLower()))
                                            {
                                                dgv.Rows.Add(id, dtTransDate.ToString("yyyy-MM-dd HH:mm"), reference, sDocStatus, sapNumber, remarks, sConfirm, prodOrderRef, dtConfirmedDate.ToString("yyyy-MM-dd HH:mm"));
                                            }
                                        }
                                        else
                                        {
                                            dgv.Rows.Add(id, dtTransDate.ToString("yyyy-MM-dd HH:mm"), reference, sDocStatus, sapNumber, remarks, sConfirm, prodOrderRef, dtConfirmedDate.ToString("yyyy-MM-dd HH:mm"));
                                        }
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
                txtSearch.AutoCompleteCustomSource = auto;
                Cursor.Current = Cursors.Default;
            }
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                loadData();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            loadData();
        }
    }
}
