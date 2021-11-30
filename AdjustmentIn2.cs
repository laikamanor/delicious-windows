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
using RestSharp;
using Newtonsoft.Json.Linq;
using DeliciousPartnerApp.API_Class.Warehouse;
namespace DeliciousPartnerApp
{
    public partial class AdjustmentIn2 : Form
    {
        DataTable dtWarehouse;
        string gAdjType = "", gAdjTrans = "";
        utility_class utilityc = new utility_class();
        warehouse_class warehousec = new warehouse_class();
        int cWhse = 1, cDate = 1;
        public AdjustmentIn2(string adjType, string adjTrans)
        {
            gAdjType = adjType;
            gAdjTrans = adjTrans;
            InitializeComponent();
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            AddAdjustmentIn addAdjustmentIn = new AddAdjustmentIn(gAdjType);
            addAdjustmentIn.ShowDialog();
            loadData();
        }

        private async void AdjustmentIn_Load(object sender, EventArgs e)
        {
            dtDate.Value = DateTime.Now;
            this.Text = gAdjType.Equals("in") ? "Adjusment In" : "Adjustment Out";
            btnAddUser.Visible = gAdjTrans.Equals("Done") ? false : true;
            await loadWarehouse();
            loadData();
            cWhse = 0;
            cDate = 0;
        }

        public async Task loadWarehouse()
        {
            string warehouse = "", branchCode = "";

            if (Login.jsonResult != null)
            {
                foreach (var x in Login.jsonResult)
                {
                    if (x.Key.Equals("data"))
                    {
                        JObject jObjectData = JObject.Parse(x.Value.ToString());
                        foreach (var y in jObjectData)
                        {
                            if (y.Key.Equals("branch"))
                            {
                                branchCode = y.Value.ToString();
                            }
                        }
                    }
                }
            }

            int isAdmin = 0;
            dtWarehouse = await Task.Run(() => warehousec.returnWarehouse(branchCode, ""));
            foreach (DataRow row in dtWarehouse.Rows)
            {
                cmbWhse.Items.Add(row["whsename"]);
            }
            cmbWhse.Items.Clear();
            if (Login.jsonResult != null)
            {
                foreach (var x in Login.jsonResult)
                {
                    if (x.Key.Equals("data"))
                    {
                        JObject jObjectData = JObject.Parse(x.Value.ToString());
                        foreach (var y in jObjectData)
                        {
                            if (y.Key.Equals("whse"))
                            {
                                warehouse = y.Value.ToString();
                            }
                            else if (y.Key.Equals("isAdmin"))
                            {

                                if (y.Value.ToString().ToLower() == "false" || y.Value.ToString() == "")
                                {
                                    foreach (DataRow row in dtWarehouse.Rows)
                                    {
                                        if (row["whsecode"].ToString() == warehouse)
                                        {
                                            cmbWhse.Items.Add(row["whsename"].ToString());
                                            if (cmbWhse.Items.Count > 0)
                                            {
                                                cmbWhse.SelectedIndex = 0;
                                            }
                                            return;
                                        }
                                    }
                                }
                                else
                                {
                                    isAdmin += 1;
                                    break;
                                }
                            }
                            else if (y.Key.Equals("isAccounting"))
                            {
                                if (y.Value.ToString().ToLower() == "false" || y.Value.ToString() == "")
                                {
                                    foreach (DataRow row in dtWarehouse.Rows)
                                    {
                                        if (row["whsecode"].ToString() == warehouse && isAdmin <= 0)
                                        {
                                            cmbWhse.Items.Add(row["whsename"].ToString());
                                            break;
                                        }
                                        else
                                        {
                                            isAdmin += 1;
                                            break;
                                        }
                                    }
                                }
                            }
                            else if (y.Key.Equals("isManager"))
                            {
                                if (y.Value.ToString().ToLower() == "false" || y.Value.ToString() == "")
                                {
                                    foreach (DataRow row in dtWarehouse.Rows)
                                    {
                                        if (row["whsecode"].ToString() == warehouse && isAdmin <= 0)
                                        {
                                            cmbWhse.Items.Add(row["whsename"].ToString());
                                            break;
                                        }
                                        else
                                        {
                                            isAdmin += 1;
                                            break;
                                        }
                                    }
                                }
                            }
                            else if (y.Key.Equals("isCashier"))
                            {
                                if (y.Value.ToString().ToLower() == "false" || y.Value.ToString() == "")
                                {
                                    foreach (DataRow row in dtWarehouse.Rows)
                                    {
                                        if (row["whsecode"].ToString() == warehouse && isAdmin <= 0)
                                        {
                                            cmbWhse.Items.Add(row["whsename"].ToString());
                                            break;
                                        }
                                        else
                                        {
                                            isAdmin += 1;
                                            break;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                if (cmbWhse.Items.Count <= 0)
                {
                    cmbWhse.Items.Add("All");
                    foreach (DataRow row in dtWarehouse.Rows)
                    {
                        cmbWhse.Items.Add(row["whsename"]);
                    }
                }
            }
            if (cmbWhse.Items.Count > 0)
            {
                string whseName = "";
                foreach (DataRow row in dtWarehouse.Rows)
                {
                    if (row["whsecode"].ToString() == warehouse)
                    {
                        whseName = row["whsename"].ToString();
                        break;
                    }
                }
                cmbWhse.SelectedIndex = cmbWhse.Items.IndexOf(whseName);
                if (cmbWhse.Text == "")
                {
                    cmbWhse.SelectedIndex = 0;
                }
            }
        }

        public string findWarehouseCode()
        {
            string result = "";
            foreach (DataRow row in dtWarehouse.Rows)
            {
                if (row["whsename"].ToString() == cmbWhse.Text)
                {
                    result = row["whsecode"].ToString();
                    break;
                }
            }
            return result;
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
                    string whseCode = findWarehouseCode();
                    string sWhse = string.IsNullOrEmpty(whseCode) ? "" : "&whsecode=" + whseCode;
                    string sDate = "?transdate=" + dtDate.Value.ToString("yyyy-MM-dd");
                    string sSAP = gAdjTrans.Equals("Done") ? "&sap_number=1" : "&sap_number=";
                    var request = new RestRequest("/api/inv_adj/" + gAdjType + "/get_all" + sDate + sWhse + sSAP);
                    Console.WriteLine("/api/inv_adj/" + gAdjType + "/get_all" + sDate + sWhse + sSAP);
                    request.AddHeader("Authorization", "Bearer " + token);
                    var response = client.Execute(request);
                    //MessageBox.Show(response.Content.ToString());
                    if (response.ErrorMessage == null)
                    {
                        JObject jObject = JObject.Parse(response.Content.ToString());
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
                                        int labelY = 20, lineY = 65;
                                        JArray jsonArray = JArray.Parse(x.Value.ToString());
                                        for (int i = 0; i < jsonArray.Count(); i++)
                                        {
                                            JObject data = JObject.Parse(jsonArray[i].ToString());
                                            Label labelReference = new Label();
                                            labelReference.AutoSize = true;
                                            labelReference.Location = new Point(16, labelY);
                                            labelReference.Cursor = Cursors.Hand;
                                            labelReference.Font = new Font("Arial", 13, FontStyle.Bold);
                                            Panel panelLine = new Panel();
                                            panelLine.BackColor = Color.Black;
                                            panelLine.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
                                            panelLine.Size = new Size(734, 3);
                                            panelLine.Location = new Point(4, lineY);
                                            string reference = "", sapNumber = "";
                                            int id = 0;
                                            foreach (var q in data)
                                            {
                                                if (q.Key.Equals("id"))
                                                {
                                                    id = Convert.ToInt32(q.Value.ToString());
                                                }
                                                else if (q.Key.Equals("reference"))
                                                {
                                                    reference = q.Value.ToString();
                                                }
                                                if (q.Key.Equals("sap_number"))
                                                {
                                                    sapNumber = q.Value.ToString();
                                                }

                                            }
                                            dgv.Rows.Add(id, reference, sapNumber);
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

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dgv.Rows.Count > 0)
            {
                if(e.RowIndex >= 0)
                {
                    AdjustmentIn_Details ajdDetails = new AdjustmentIn_Details(gAdjTrans, gAdjType);
                    ajdDetails.Text = this.Text + " Details";
                    ajdDetails.selectedID = Convert.ToInt32(dgv.CurrentRow.Cells["id"].Value.ToString());
                    ajdDetails.lblReference.Text = dgv.CurrentRow.Cells["reference"].Value.ToString();
                    ajdDetails.ShowDialog();
                    loadData();
                }
            }
        }

        private void cmbWhse_SelectedValueChanged(object sender, EventArgs e)
        {
            if(cWhse <= 0)
            {
                loadData();
            }
        }


        private void dtDate_ValueChanged(object sender, EventArgs e)
        {
           if(cDate <= 0)
            {
                loadData();
            }
        }
    }
}
