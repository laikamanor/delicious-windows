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
    public partial class Production_ProductionOrder_Items : Form
    {
        public Production_ProductionOrder_Items()
        {
            InitializeComponent();
        }
        utility_class utilityc = new utility_class();
        public int selectedID = 0;
        public string referenceNumber = "";
        private void Production_ProductionOrder_Items_Load(object sender, EventArgs e)
        {
            dgv.Columns["planned_qty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv.Columns["received_qty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            lblReference.Text = referenceNumber;
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
                    var request = new RestRequest("/api/production/order/details/" + selectedID);
                    request.AddHeader("Authorization", "Bearer " + token);
                    var response = client.Execute(request);
                    Console.WriteLine(response.Content.ToString());
                    if (response.ErrorMessage == null)
                    {
                        if (response.Content.ToString().Substring(0, 1).Equals("{"))
                        {
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
                                                int id = 0, docID = 0, objType = 0;
                                                string itemCode = "", uom = "", whseCode = "", remarkss = "", sIsClosed = "";
                                                double plannedQty = 0.00, receivedQty = 0.00;
                                                bool isClose = false;
                                                DateTime dtDateCreated = new DateTime(), dtDateUpdated = new DateTime(), dtDateClosed = new DateTime();
                                                foreach (var q in data)
                                                {
                                                    if (q.Key.Equals("id"))
                                                    {
                                                        id = Convert.ToInt32(q.Value.ToString());
                                                    }
                                                    else if (q.Key.Equals("doc_id"))
                                                    {
                                                        docID = Convert.ToInt32(q.Value.ToString());
                                                    }
                                                    else if (q.Key.Equals("objtype"))
                                                    {
                                                        objType = Convert.ToInt32(q.Value.ToString());
                                                    }
                                                    else if (q.Key.Equals("item_code"))
                                                    {
                                                        itemCode = q.Value.ToString();
                                                        auto.Add(itemCode);
                                                    }
                                                    else if (q.Key.Equals("planned_qty"))
                                                    {
                                                        plannedQty = string.IsNullOrEmpty(q.Value.ToString().Trim()) ? 0.00 : Convert.ToDouble(q.Value.ToString());
                                                    }
                                                    else if (q.Key.Equals("received_qty"))
                                                    {
                                                        receivedQty = string.IsNullOrEmpty(q.Value.ToString().Trim()) ? 0.00 : Convert.ToDouble(q.Value.ToString());
                                                    }
                                                    else if (q.Key.Equals("whsecode"))
                                                    {
                                                        whseCode = q.Value.ToString();
                                                    }
                                                    else if (q.Key.Equals("uom"))
                                                    {
                                                        uom = q.Value.ToString();
                                                    }
                                                    else if (q.Key.Equals("date_created"))
                                                    {
                                                        string replaceT = q.Value.ToString().Replace("T", "");
                                                        dtDateCreated = string.IsNullOrEmpty(replaceT) ? DateTime.MinValue : Convert.ToDateTime(replaceT);
                                                    }
                                                    else if (q.Key.Equals("date_updated"))
                                                    {
                                                        string replaceT = q.Value.ToString().Replace("T", "");
                                                        dtDateUpdated = string.IsNullOrEmpty(replaceT) ? DateTime.MinValue : Convert.ToDateTime(replaceT);
                                                    }
                                                    else if (q.Key.Equals("date_closed"))
                                                    {
                                                        string replaceT = q.Value.ToString().Replace("T", "");
                                                        dtDateClosed = string.IsNullOrEmpty(replaceT) ? DateTime.MinValue : Convert.ToDateTime(replaceT);
                                                    }
                                                    else if (q.Key.Equals("close"))
                                                    {
                                                        isClose = string.IsNullOrEmpty(q.Value.ToString()) ? false : Convert.ToBoolean(q.Value.ToString());
                                                        sIsClosed = isClose ? "✔" : "";
                                                    }
                                                    else if (q.Key.Equals("remarks"))
                                                    {
                                                        remarkss = q.Value.ToString();
                                                    }
                                                }

                                                if (!string.IsNullOrEmpty(txtSearch.Text.ToString().Trim()))
                                                {
                                                    if (txtSearch.Text.ToString().Trim().ToLower().Contains(itemCode.ToLower()))
                                                    {
                                                        dgv.Rows.Add(id, docID, objType, itemCode, Convert.ToDecimal(string.Format("{0:0.00}", plannedQty)), Convert.ToDecimal(string.Format("{0:0.00}", receivedQty)), uom, whseCode, dtDateCreated.ToString("yyyy-MM-dd"), dtDateUpdated.ToString("yyyy-MM-dd"), (dtDateClosed.Equals(DateTime.MinValue) ? "" : dtDateClosed.ToString("yyyy-MM-dd")), sIsClosed, remarkss);
                                                    }
                                                }
                                                else
                                                {
                                                    dgv.Rows.Add(id, docID, objType, itemCode, Convert.ToDecimal(string.Format("{0:0.00}", plannedQty)), Convert.ToDecimal(string.Format("{0:0.00}", receivedQty)) , uom, whseCode, dtDateCreated.ToString("yyyy-MM-dd"), dtDateUpdated.ToString("yyyy-MM-dd"), (dtDateClosed.Equals(DateTime.MinValue) ? "" : dtDateClosed.ToString("yyyy-MM-dd")), sIsClosed, remarkss);
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
                        else
                        {
                            MessageBox.Show(response.Content.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show(response.ErrorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                txtSearch.AutoCompleteCustomSource = auto;
                Cursor.Current = Cursors.Default;
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
                    request.Method = Method.PUT;

                    Console.WriteLine(body);
                    request.AddParameter("application/json", body, ParameterType.RequestBody);
                    var response = client.Execute(request);
                    if (response.ErrorMessage == null)
                    {
                        JObject jObjectResponse = JObject.Parse(response.Content);
                        bool isSubmit = false;
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
                        MessageBox.Show(msg, "", MessageBoxButtons.OK, isSubmit ? MessageBoxIcon.Information : MessageBoxIcon.Warning);

                        //if (isSubmit)
                        //{
                        //    this.Dispose();
                        //}
                    }
                    else
                    {
                        MessageBox.Show(response.ErrorMessage, "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                }
            }
        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv.Rows.Count > 0)
            {
                if (e.RowIndex >= 0)
                {
                    if (e.ColumnIndex == 12)
                    {
                        if (dgv.CurrentRow.Cells["close"].Value.ToString() == "")
                        {
                            Remarks remarks = new Remarks();
                            remarks.ShowDialog();
                            if (Remarks.isSubmit)
                            {
                                string rem = Remarks.rem;
                                JObject joBody = new JObject();
                                joBody.Add("remarks", rem);
                                int iD = string.IsNullOrEmpty(dgv.CurrentRow.Cells["id"].Value.ToString()) ? 0 : Convert.ToInt32(dgv.CurrentRow.Cells["id"].Value.ToString());
                                string URL = "/api/production/order/details/close/" + iD;
                                apiPUT(joBody, URL);
                                loadData();
                            }
                        }
                        else
                        {
                            MessageBox.Show(dgv.CurrentRow.Cells["item_code"].Value.ToString() + " is already closed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            loadData();
        }

        private void txtSearch_ImeModeChanged(object sender, EventArgs e)
        {

        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                loadData();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            loadData();
        }
    }
}
