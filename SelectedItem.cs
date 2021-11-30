using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using RestSharp;
using DeliciousPartnerApp.UI_Class;
namespace DeliciousPartnerApp
{
    public partial class SelectedItem : Form
    {
        string gAdjType = "";
        public SelectedItem(string adjType)
        {
            gAdjType = adjType;
            InitializeComponent();
        }
        utility_class utilityc = new utility_class();
        public DataTable dtSelectedItems = new DataTable();
        private void SelectedItem_Load(object sender, EventArgs e)
        {
            dgv.Columns["quantity"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            loadData();

        }

        public void loadData()
        {
            if (dtSelectedItems.Rows.Count > 0)
            {
                dgv.Rows.Clear();
                foreach (DataRow row in dtSelectedItems.Rows)
                {
                    dgv.Rows.Add(row["item_code"].ToString(), Convert.ToDouble(row["quantity"].ToString()), row["uom"].ToString());
                }
            }
        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv.Rows.Count > 0)
            {
                if (e.ColumnIndex == 3)
                {
                    DialogResult dialogResult = MessageBox.Show("Are you sure you want to remove?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialogResult == DialogResult.Yes)
                    {
                        dgv.Rows.RemoveAt(dgv.CurrentRow.Index);
                    }
                }
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            DataTable dtDgv = new DataTable();
            dtDgv.Columns.Add("item_code");
            dtDgv.Columns.Add("quantity");
            dtDgv.Columns.Add("uom");
            dtDgv.Rows.Clear();
            for(int i =0; i < dgv.Rows.Count; i++)
            {
                string itemName = dgv.Rows[i].Cells["item_code"].Value.ToString();
                string quantity = dgv.Rows[i].Cells["quantity"].Value.ToString();
                string uom = dgv.Rows[i].Cells["uom"].Value.ToString();
                dtDgv.Rows.Add(itemName, quantity, uom);
            }
            AddAdjustmentIn addAdjustmentIn = new AddAdjustmentIn(gAdjType);
            addAdjustmentIn.dtSelectedItems2 = dtDgv;
            addAdjustmentIn.ShowDialog();
            this.Hide();
        }

        private void btnProceed_Click(object sender, EventArgs e)
        {
            if (dgv.Rows.Count > 0)
            {
                SAP_Remarks sAP_Remarks = new SAP_Remarks();
                sAP_Remarks.isOptional = true;
                sAP_Remarks.ShowDialog();
                if (SAP_Remarks.isSubmit)
                {
                    int sap_number = SAP_Remarks.sap_number;
                    string remarks = SAP_Remarks.rem;
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

                            var client = new RestClient(utilityc.URL);
                            client.Timeout = -1;
                            var request = new RestRequest("/api/inv_adj/" + gAdjType + "/new");
                            //MessageBox.Show("/api/inv_adj/" + gAdjType + "/new");
                            request.AddHeader("Authorization", "Bearer " + token);
                            request.Method = Method.POST;
                            JObject jObjectBody = new JObject();
                            JArray jArrayRows = new JArray();
                            JObject jObjectHeader = new JObject();
                            jObjectHeader.Add("transdate", DateTime.Now.ToString("yyyy-MM-dd hh:mm"));
                            if (sap_number <= 0)
                            {
                                jObjectHeader.Add("sap_number", null);
                            }
                            else
                            {
                                jObjectHeader.Add("sap_number", sap_number);
                            }
                            jObjectHeader.Add("remarks", remarks);
                            jObjectBody.Add("header", jObjectHeader);
                            if(dgv.Rows.Count > 0)
                            {
                                for (int i = 0; i < dgv.Rows.Count; i++)
                                {
                                    JObject jObjectRows = new JObject();
                                    string itemCode = dgv.Rows[i].Cells["item_code"].Value.ToString();
                                    double quantity = Convert.ToDouble(dgv.Rows[i].Cells["quantity"].Value.ToString());
                                    string uom = dgv.Rows[i].Cells["uom"].Value.ToString();
                                    jObjectRows.Add("item_code", itemCode);
                                    jObjectRows.Add("quantity", quantity);
                                    jObjectRows.Add("uom", uom);
                                    jArrayRows.Add(jObjectRows);
                                }
                                jObjectBody.Add("rows", jArrayRows);
                                request.AddParameter("application/json", jObjectBody, ParameterType.RequestBody);
                                var response = client.Execute(request);
                                if (response.Content.ToString().Substring(0, 1).Equals("{"))
                                {
                                    JObject jObjectResponse = JObject.Parse(response.Content);
                                    bool isSuccess = false;
                                    foreach (var x in jObjectResponse)
                                    {
                                        if (x.Key.Equals("success"))
                                        {
                                            isSuccess = Convert.ToBoolean(x.Value.ToString());
                                        }
                                    }

                                    if (isSuccess)
                                    {
                                        string msg = "Object message key not found";
                                        foreach (var x in jObjectResponse)
                                        {
                                            if (x.Key.Equals("message"))
                                            {
                                                msg = x.Value.ToString();
                                            }
                                        }
                                        Cursor.Current = Cursors.Default;
                                        MessageBox.Show(msg, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        this.Hide();
                                    }
                                    else
                                    {
                                        string msg = "Object message key not found";
                                        foreach (var x in jObjectResponse)
                                        {
                                            if (x.Key.Equals("message"))
                                            {
                                                msg = x.Value.ToString();
                                            }
                                        }
                                        if (msg.Equals("Token is invalid"))
                                        {
                                            Cursor.Current = Cursors.Default;
                                            MessageBox.Show("Your login session is expired. Please login again", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        }
                                        else
                                        {
                                            Cursor.Current = Cursors.Default;
                                            MessageBox.Show(msg, "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        }
                                    }

                                }
                                else
                                {
                                    MessageBox.Show(response.Content.ToString(), "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("No data selected", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
