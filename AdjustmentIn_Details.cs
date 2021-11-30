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
    public partial class AdjustmentIn_Details : Form
    {
        utility_class utilityc = new utility_class();
        public int selectedID = 0;
        public static bool isSubmit=false;
        string gAdjTrans = "", gAdjType = "";
        public AdjustmentIn_Details(string adjTrans, string adjType)
        {
            gAdjType = adjType;
            gAdjTrans = adjTrans;
            InitializeComponent();
        }

        private void AdjustmentIn_Details_Load(object sender, EventArgs e)
        {
            btnUpdateSAP.Visible = gAdjTrans.Equals("For SAP") ? true : false;
            if (this.Text == "Adjustment Out Details")
            {
                loadAdjustmentOut();
            }
            else
            {
                loadData();
            }
            lblCount.Text = "Items (" + dgv.Rows.Count.ToString("N0") + ")";
            dgv.Columns["quantity"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        public void loadData()
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
              
                    var request = new RestRequest("/api/inv_adj/" + gAdjType + "/details/" + selectedID);
                    Console.WriteLine("/api/inv_adj/" + gAdjType + "/details/" + selectedID);
                    request.AddHeader("Authorization", "Bearer " + token);
                    var response = client.Execute(request);
                    JObject jObject = JObject.Parse(response.Content.ToString());
                    //Console.WriteLine(response.Content.ToString());
                    if (response.ErrorMessage == null)
                    {
                        bool isSuccess = false;
                        string msg = "";
                        foreach (var x in jObject)
                        {
                            if (x.Key.Equals("success"))
                            {
                                isSuccess = Convert.ToBoolean(x.Value.ToString());
                            }
                            if (x.Key.Equals("message"))
                            {
                                msg = x.Value.ToString();
                            }
                        }

                        if (isSuccess)
                        {
                            dgv.Rows.Clear();
                            foreach (var x in jObject)
                            {
                                if (x.Key.Equals("data"))
                                {
                                    if (x.Value.ToString() != "{}")
                                    {
                                        JObject data = JObject.Parse(x.Value.ToString());
                                        foreach (var q in data)
                                        {
                                            if (q.Key.Equals("rows"))
                                            {
                                                if (q.Value.ToString() != "[]")
                                                {
                                                    JArray jsonArrayRows = JArray.Parse(q.Value.ToString());
                                                    for (int ii = 0; ii < jsonArrayRows.Count(); ii++)
                                                    {
                                                        JObject rows = JObject.Parse(jsonArrayRows[ii].ToString());
                                                        int id = 0, adjusmentid = 0;
                                                        string itemCode = "", uOm = "";
                                                        double quantity = 0.00;
                                                        foreach (var w in rows)
                                                        {

                                                            if (w.Key.Equals("id"))
                                                            {
                                                                id = Convert.ToInt32(w.Value.ToString());
                                                            }
                                                            else if (w.Key.Equals("adjustin_id"))
                                                            {
                                                                adjusmentid = Convert.ToInt32(w.Value.ToString());
                                                            }
                                                            else if (w.Key.Equals("item_code"))
                                                            {
                                                                itemCode = w.Value.ToString();
                                                            }
                                                            else if (w.Key.Equals("uom"))
                                                            {
                                                                uOm = w.Value.ToString();
                                                            }
                                                            else if (w.Key.Equals("quantity"))
                                                            {
                                                                quantity = Convert.ToDouble(w.Value.ToString());
                                                            }
                                                            else if (w.Key.Equals("whsecode"))
                                                            {
                                                                lblWhse.Text = w.Value.ToString();
                                                            }
                                                        }
                                                        dgv.Rows.Add(id, adjusmentid, itemCode, quantity, uOm);
                                                    }
                                                }
                                            }
                                            else if (q.Key.Equals("remarks"))
                                            {
                                                lblRemarks.Text = q.Value.ToString();
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show(msg, "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }

                    }
                    else
                    {
                        MessageBox.Show(response.ErrorMessage, "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        public void loadAdjustmentOut()
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

                    var request = new RestRequest("/api/inv_adj/" + gAdjType + "/details/" + selectedID);
                    request.AddHeader("Authorization", "Bearer " + token);
                    var response = client.Execute(request);
                    JObject jObject = JObject.Parse(response.Content.ToString());
                    Console.WriteLine(response.Content.ToString());
                    if (response.ErrorMessage == null)
                    {
                        bool isSuccess = false;
                        string msg = "";
                        foreach (var x in jObject)
                        {
                            if (x.Key.Equals("success"))
                            {
                                isSuccess = Convert.ToBoolean(x.Value.ToString());
                            }
                            if (x.Key.Equals("message"))
                            {
                                msg = x.Value.ToString();
                            }
                        }
                        if (isSuccess)
                        {
                            dgv.Rows.Clear();
                            foreach (var x in jObject)
                            {
                                if (x.Key.Equals("data"))
                                {
                                    if (x.Value.ToString() != "[]")
                                    {
                                        JArray jsonArrayRows = JArray.Parse(x.Value.ToString());
                                        for (int ii = 0; ii < jsonArrayRows.Count(); ii++)
                                        {
                                            JObject rows = JObject.Parse(jsonArrayRows[ii].ToString());
                                            int id = 0, adjusmentid = 0;
                                            string itemCode = "", uOm = "";
                                            double quantity = 0.00;
                                            foreach (var w in rows)
                                            {

                                                if (w.Key.Equals("id"))
                                                {
                                                    id = Convert.ToInt32(w.Value.ToString());
                                                }
                                                else if (w.Key.Equals("adjust" + (this.Text == "Adjustment In Details" ? "in" : "out") + "_id"))
                                                {
                                                    adjusmentid = Convert.ToInt32(w.Value.ToString());
                                                }
                                                else if (w.Key.Equals("item_code"))
                                                {
                                                    itemCode = w.Value.ToString();
                                                }
                                                else if (w.Key.Equals("uom"))
                                                {
                                                    uOm = w.Value.ToString();
                                                }
                                                else if (w.Key.Equals("quantity"))
                                                {
                                                    quantity = Convert.ToDouble(w.Value.ToString());
                                                }
                                                else if (w.Key.Equals("whsecode"))
                                                {
                                                    lblWhse.Text = w.Value.ToString();
                                                }
                                            }
                                            dgv.Rows.Add(id, adjusmentid, itemCode, quantity, uOm);
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show(msg, "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }

                    }
                    else
                    {
                        MessageBox.Show(response.ErrorMessage, "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        private void btnUpdateSAP_Click(object sender, EventArgs e)
        {
            if (this.Text == "Adjusment In Details" || this.Text== "Adjustment Out Details")
            {
                if (gAdjTrans.Equals("For SAP"))
                {
                    SAP_Remarks sapRemarks = new SAP_Remarks();
                    sapRemarks.isOptional = false;
                    sapRemarks.ShowDialog();
                    int sapNumber = SAP_Remarks.sap_number;
                    string remarks = SAP_Remarks.rem;
                    if (SAP_Remarks.isSubmit)
                    {
                        JObject jObjectBody = new JObject();
                        JArray jArrayID = new JArray();
                        jArrayID.Add(selectedID);
                        jObjectBody.Add("ids", jArrayID);
                        if(sapNumber <= 0)
                        {
                            jObjectBody.Add("sap_number", null);
                        }
                        else
                        {
                            jObjectBody.Add("sap_number", sapNumber);
                        }
                        if (string.IsNullOrEmpty(remarks.Trim()))
                        {
                            jObjectBody.Add("remarks", null);
                        }
                        else
                        {
                            jObjectBody.Add("remarks", remarks);
                        }
                        Console.WriteLine(jObjectBody);
                        
                        apiPUT(jObjectBody, "/api/sap_num/adj_" + gAdjType +  "/update");
                        if (isSubmit)
                        {
                            this.Dispose();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Access Denied", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Access Denied", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        if (response.Content.ToString().Substring(0, 1).Equals("{"))
                        {
                            JObject jObjectResponse = JObject.Parse(response.Content);

                            foreach (var x in jObjectResponse)
                            {
                                if (x.Key.Equals("success"))
                                {
                                    isSubmit = true;
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
                            MessageBox.Show(msg, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

                }
            }
        }
    }
}
