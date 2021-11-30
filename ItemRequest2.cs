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
using RestSharp;
using DeliciousPartnerApp.API_Class.Warehouse;
namespace DeliciousPartnerApp
{
    public partial class ItemRequest2 : Form
    {
        utility_class utilityc = new utility_class();
        warehouse_class wahousesc = new warehouse_class();
        string gForType = "";
        DataTable dtWarehouse;
        int cStatus = 1, cfromWhse = 1, cToWhse = 1, cDueDate = 1, cCheck = 1, cTransDate = 1;
        public ItemRequest2(string forType)
        {
            gForType = forType;
            InitializeComponent();
        }

        public async Task loadWarehouses(bool value, ComboBox cmb)
        {
            cmbToWhse.Items.Clear();
            string ownWhse = "", branch = "";
            dtWarehouse = new DataTable();
            if (value)
            {
                cmb.Items.Add("All");
                dtWarehouse = await Task.Run(() => wahousesc.returnWarehouse("", ""));
                foreach (DataRow row in dtWarehouse.Rows)
                {
                    cmb.Items.Add(row["whsename"]);
                }
            }
            else
            {
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
                                    branch = y.Value.ToString();
                                }
                            }
                        }
                    }
                    dtWarehouse = await Task.Run(() => wahousesc.returnWarehouse(branch, "&is_production=1"));
                    cmb.Items.Add("All");
                    foreach (DataRow row in dtWarehouse.Rows)
                    {
                        cmb.Items.Add(row["whsename"].ToString());
                    }
                }
            }
            if (cmb.Items.Count > 0 && !value)
            {
                string whseName = "";
                foreach (DataRow row in dtWarehouse.Rows)
                {
                    if (row["whsecode"].ToString() == ownWhse)
                    {
                        whseName = row["whsename"].ToString();
                        break;
                    }
                }
                cmb.SelectedIndex = cmb.Items.IndexOf(whseName);
                if (cmb.Text == "")
                {
                    cmb.SelectedIndex = 0;
                }
            }
            else if (cmb.Items.Count > 0 && value)
            {
                cmb.SelectedIndex = 0;
            }
        }

        private async void ItemRequest2_Load(object sender, EventArgs e)
        {
            await loadWarehouses(false, cmbFromWhse);
            await loadWarehouses(true, cmbToWhse);
            fillDocStatus();
            dtDueDate.Visible = checkDueDate.Checked;
            cmbDocStatus.Visible = gForType.Equals("For Confirmation") || gForType.Equals("For SAP") ? false : true;
            label1.Visible = gForType.Equals("For Confirmation") || gForType.Equals("For SAP") ? false : true;
            dtDueDate.Value = DateTime.Now;
            dtTransDate.Value = DateTime.Now; 
            if (gForType.Equals("For Confirmation") || gForType.Equals("For SAP") || gForType.Equals("Logs"))
            {
                //checkDueDate.Checked = true;
                checkTransDate.Checked = true;
            }
            loadData();
            cStatus = 0;
            cfromWhse = 0;
            cToWhse = 0;
            cDueDate = 0;
            cCheck = 0;
            cTransDate = 0;
        }

        public void fillDocStatus()
        {
            cmbDocStatus.Items.Clear();
            if (gForType.Equals("For Confirmation") || gForType.Equals("For SAP"))
            {
                cmbDocStatus.Items.Add("Open");
            }
            else
            {
                cmbDocStatus.Items.Add("Closed");
                cmbDocStatus.Items.Add("Cancelled");
            }
            if(cmbDocStatus.Items.Count > 0)
            {
                cmbDocStatus.SelectedIndex = 0;
            }
        }

        public void loadData()
        {
            Cursor.Current = Cursors.WaitCursor;
            if (Login.jsonResult != null)
            {
                string token = "", branch = "";
                foreach (var x in Login.jsonResult)
                {
                    if (x.Key.Equals("token"))
                    {
                        token = x.Value.ToString();
                    }
                    else if (x.Key.Equals("data"))
                    {
                        JObject jObjectData = JObject.Parse(x.Value.ToString());
                        foreach (var y in jObjectData)
                        {
                            if (y.Key.Equals("branch"))
                            {
                                branch = y.Value.ToString();
                            }
                        }
                    }
                }
                if (!token.Equals(""))
                {
                    var client = new RestClient(utilityc.URL);
                    client.Timeout = -1;

                    string sDocStatus = (cmbDocStatus.Text.Equals("Open") ? "?docstatus=O" : cmbDocStatus.Text.Equals("Closed") ? "?docstatus=C" : "?docstatus=N");
                    string sConfirmed = (gForType.Equals("For SAP") ? "&confirm=1" : gForType.Equals("Logs") ? "&confirm=true" : "&confirm=");
                    string sDueDate = (!checkDueDate.Checked ? "&duedate=" : "&duedate=" + dtDueDate.Value.ToString("yyyy-MM-dd"));
                    string sTransDate = (!checkTransDate.Checked ? "&transdate=" : "&transdate=" + dtTransDate.Value.ToString("yyyy-MM-dd"));
                    string sSAPNumber = (gForType.Equals("For SAP") ? "&sap_number=" : "");
                    string sfromWarehouse = (cmbFromWhse.SelectedIndex.Equals(-1) ? "" : cmbFromWhse.SelectedIndex.Equals(0) || cmbFromWhse.Text.ToLower() == "all" ? "&from_whse=" : "&from_whse=" + findWarehouseName(cmbFromWhse.Text));
                    string stoWarehouse = (cmbToWhse.SelectedIndex.Equals(-1) ? "" : cmbToWhse.SelectedIndex.Equals(0) || cmbToWhse.Text.ToLower() == "all" ? "&to_whse=" : "&to_whse=" + findWarehouseName(cmbToWhse.Text));
                    var request = new RestRequest("/api/inv/item_request/get_all" + sDocStatus + sConfirmed + sDueDate + sSAPNumber + sfromWarehouse + stoWarehouse + sTransDate);
                    Console.WriteLine("/api/inv/item_request/get_all" + sDocStatus + sConfirmed + sDueDate + sSAPNumber + sfromWarehouse + stoWarehouse + sTransDate);
                    request.AddHeader("Authorization", "Bearer " + token);
                    var response = client.Execute(request);
                    JObject jObjectResponse = JObject.Parse(response.Content);

                    bool isSuccess = false;
                    //AutoCompleteStringCollection auto = new AutoCompleteStringCollection();
                    dgv.Rows.Clear();
                    foreach (var x in jObjectResponse)
                    {
                        if (x.Key.Equals("success"))
                        {
                            isSuccess = Convert.ToBoolean(x.Value.ToString());
                        }
                    }
                    if (isSuccess)
                    {
                        foreach (var z in jObjectResponse)
                        {
                            if (z.Key.Equals("data"))
                            {
                                if (z.Value.ToString() != "[]")
                                {
                                    int id = 0;
                                    string referenceNumber = "", toWhse = "", fromWhse = "", docStatus = "", remarks = "";
                                    DateTime dtTransDate = new DateTime(), dtDueDate = new DateTime();
                                    JArray jsonArray = JArray.Parse(z.Value.ToString());
                                    for (int i = 0; i < jsonArray.Count(); i++)
                                    {
                                        JObject jObjectData = JObject.Parse(jsonArray[i].ToString());
                                        foreach (var y in jObjectData)
                                        {
                                            if (y.Key.Equals("request_rows"))
                                            {
                                                if (y.Value.ToString() != "[]")
                                                {
                                                    JArray jsonArrayRows = JArray.Parse(y.Value.ToString());
                                                    for (int ii = 0; ii < jsonArrayRows.Count(); ii++)
                                                    {
                                                        JObject jObjectRequestRows = JObject.Parse(jsonArrayRows[ii].ToString());

                                                        foreach (var w in jObjectRequestRows)
                                                        {
                                                            if (w.Key.Equals("to_whse"))
                                                            {
                                                                toWhse = w.Value.ToString();
                                                            }
                                                            else if (w.Key.Equals("from_whse"))
                                                            {
                                                                fromWhse = w.Value.ToString();
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                            else if (y.Key.Equals("id"))
                                            {
                                                id = Convert.ToInt32(y.Value.ToString());
                                            }
                                            else if (y.Key.Equals("reference"))
                                            {
                                                referenceNumber = y.Value.ToString();
                                            }
                                            else if (y.Key.Equals("transdate"))
                                            {
                                                string replaceT = y.Value.ToString().Replace("T", "");
                                                dtTransDate = Convert.ToDateTime(replaceT);
                                            }
                                            else if (y.Key.Equals("duedate"))
                                            {
                                                string replaceT = y.Value.ToString().Replace("T", "");
                                                dtDueDate = Convert.ToDateTime(replaceT);
                                            }
                                            else if (y.Key.Equals("docstatus"))
                                            {
                                                docStatus = (y.Value.ToString() == "O" ? "Open" : (y.Value.ToString() == "C" ? "Closed" : "Cancelled"));
                                            }
                                            else if (y.Key.ToString() == "remarks")
                                            {
                                                remarks = y.Value.ToString();
                                            }
                                        }
                                        dgv.Rows.Add(id, dtTransDate.ToString("yyyy-MM-dd"), referenceNumber, fromWhse, toWhse, dtDueDate.ToString("yyyy-MM-dd"), docStatus, remarks);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            lblNoDataFound.Visible = (dgv.Rows.Count > 0 ? false : true);
        }


        public string findWarehouseName(string value)
        {
            string result = "";
            foreach (DataRow row in dtWarehouse.Rows)
            {
                if (row["whsename"].ToString() == value)
                {
                    result = row["whsecode"].ToString();
                    break;
                }
            }
            return result;
        }


        private void checkDueDate_CheckedChanged(object sender, EventArgs e)
        {
            dtDueDate.Visible = checkDueDate.Checked;
            if (cCheck <= 0)
            {
                loadData();
            }
        }

        private void cmbDocStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cStatus <= 0)
            {
                loadData();
            }
        }

        private void dtDueDate_ValueChanged(object sender, EventArgs e)
        {
            if (cDueDate <= 0)
            {
                loadData();
            }
        }

        private void cmbToWhse_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void checkTransDate_CheckedChanged(object sender, EventArgs e)
        {
            dtTransDate.Visible = checkTransDate.Checked;
            if (cTransDate <= 0)
            {
                loadData();
            }
        }

        private void dtTransDate_ValueChanged(object sender, EventArgs e)
        {
            if (cTransDate <= 0)
            {
                loadData();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            loadData();
        }

        private void cmbFromWhse_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbFromWhse_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cfromWhse <= 0)
            {
                loadData();
            }
        }

        private void cmbToWhse_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cToWhse <= 0)
            {
                loadData();
            }
        }

        private void dgv_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv.Rows.Count > 0)
            {
                if(e.RowIndex >= 0)
                {
                    if (e.ColumnIndex == 1)
                    {
                        ItemRequest_Items itemRequestItems = new ItemRequest_Items();
                        itemRequestItems.selectedID = Convert.ToInt32(dgv.CurrentRow.Cells["id"].Value.ToString());
                        itemRequestItems.forType = gForType;
                        itemRequestItems.ShowDialog();
                        loadData();
                    }
                }
            }
        }
    }
}
