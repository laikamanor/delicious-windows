using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DeliciousPartnerApp.API_Class.Branch;
using DeliciousPartnerApp.API_Class.Warehouse;
using DeliciousPartnerApp.API_Class.Transfer;
using DeliciousPartnerApp.API_Class.User;
using Newtonsoft.Json.Linq;
namespace DeliciousPartnerApp
{
    public partial class Transfer2 : Form
    {

        DataTable dtBranch = new DataTable(), dtWarehouse = new DataTable();
        branch_class branchc = new branch_class();
        warehouse_class warehousec = new warehouse_class();
        transfer_class transferc = new transfer_class();
        user_clas userc = new user_clas();
        string gForType = "";

        int cBranch = 1, cWarehouse = 1, cStatus = 1, cToDate = 1, cToWarehouse = 1, cFromDate = 1;
        public Transfer2(string forType)
        {
            gForType = forType;
            InitializeComponent();
        }

        private async void Transfer2_Load(object sender, EventArgs e)
        {
            cmbStatusTransactions.SelectedIndex = 0;
            await loadBranch();
            loadWarehouse(cmbWhse, this.Text.Equals("Received Transactions") ? true : false);
            loadWarehouse(cmbToWhse, this.Text.Equals("Received Transactions") ? false : true);
            loadData();
            cBranch = 0;
            cWarehouse = 0;
            cStatus = 0;
            cToDate = 0;
            cFromDate = 0;
            cToWarehouse = 0;
            label5.Visible = (this.Text.Equals("Pullout Transactions") ? false : true);
            cmbToWhse.Visible = (this.Text.Equals("Pullout Transactions") ? false : true);
            cmbStatusTransactions.Visible = this.Text != "Pull Out Transactions" ? false : true;
            Label2.Visible = this.Text != "Pull Out Transactions" ? false : true;
            //txtsearchTransactions.Visible = this.Text != "Pull Out Transactions" ? false : true;
            //btnsearch.Visible = this.Text != "Pull Out Transactions" ? false : true;
            //MessageBox.Show(this.Text);
            dgvTransactions.Columns["btnViewReceive"].Visible = this.Text.Equals("Transfer Transactions") ? true : false;
            dgvTransactions.Columns["rec_count"].Visible = false;
        }

        public void checkVariance()
        {
            for (int i = 0; i < dgvTransactions.Rows.Count; i++)
            {
                if (Convert.ToDouble(dgvTransactions.Rows[i].Cells["variance_count"].Value.ToString()) != 0)
                {
                    dgvTransactions.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;
                    dgvTransactions.Rows[i].Cells["btnViewReceive"].Style.BackColor = Color.ForestGreen;
                }
                else if (Convert.ToDouble(dgvTransactions.Rows[i].Cells["rec_count"].Value.ToString()) != 0)
                {
                    dgvTransactions.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(255, 94, 92);
                    dgvTransactions.Rows[i].Cells["btnViewReceive"].Style.BackColor = Color.ForestGreen;
                }
            }
        }

        public async Task loadBranch()
        {
            string currentBranch = "";
            bool isAdmin = false;
            cmbBranch.Items.Clear();

            //get muna whse and check kung admin , superadmin or manager
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
                                currentBranch = y.Value.ToString();
                            }
                            else if (y.Key.Equals("isAdmin") || y.Key.Equals("isSuperAdmin") || y.Key.Equals("isManager") || y.Key.Equals("isCashier") || y.Key.Equals("isAccounting") || y.Key.Equals("isSalesAgent"))
                            {
                                isAdmin = string.IsNullOrEmpty(y.Value.ToString()) ? false : Convert.ToBoolean(y.Value.ToString());
                                if (isAdmin)
                                {
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            dtBranch = await branchc.returnBranches();
            if (isAdmin)
            {
                dtBranch =await branchc.returnBranches();
                cmbBranch.Items.Add("All");
                foreach (DataRow row in dtBranch.Rows)
                {
                    cmbBranch.Items.Add(row["name"]);
                }
            }
            else
            {
                foreach (DataRow row in dtBranch.Rows)
                {
                    if(row["code"].ToString() == currentBranch)
                    {
                        cmbBranch.Items.Add(row["name"]);
                        break;
                    }
                }
            }
            //default text 
            //kapag admin or to whse all yung lalabas
            //kapag hindi kung ano yung current whse nya yun yung lalabas
            string branchName = "";
            foreach (DataRow row in dtBranch.Rows)
            {
                if (row["code"].ToString().Trim().ToLower() == currentBranch.Trim().ToLower())
                {
                    branchName = row["name"].ToString();
                    break;
                }
            }
            cmbBranch.SelectedIndex = cmbBranch.Items.IndexOf(branchName);
        }

        public async void loadWarehouse(ComboBox cmb, bool isTo)
        {
            string warehouse = "";
            bool isAdmin = false;
            string whse = "", branch = "";
            cmb.Items.Clear();

            //get muna whse and check kung admin , superadmin or manager
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
                                whse = y.Value.ToString();
                            }
                            else if (y.Key.Equals("isAdmin") || y.Key.Equals("isSuperAdmin") || y.Key.Equals("isManager") || y.Key.Equals("isCashier") || y.Key.Equals("isAccounting") || y.Key.Equals("isSalesAgent"))
                            {
                                isAdmin = string.IsNullOrEmpty(y.Value.ToString()) ? false : Convert.ToBoolean(y.Value.ToString());
                                if (isAdmin)
                                {
                                    break;
                                }
                            }
                        }
                    }
                }
            }

            //kunin yung branch code ng combobox branch text
            foreach (DataRow row in dtBranch.Rows)
            {
                if (row["name"].ToString() == cmbBranch.Text)
                {
                    branch = row["code"].ToString();
                    break;
                }
            }
            // kunin warehouse base kung to or from whse
            dtWarehouse = await Task.Run(() => warehousec.returnWarehouse(isTo ? "" : branch, ""));
            //kapag admin kunin lahat ng warehouse 
            // kapag di admin kukunin lang yung current wareheouse nya
            if (isAdmin)
            {
                cmb.Items.Add("All");
                foreach (DataRow row in dtWarehouse.Rows)
                {
                    cmb.Items.Add(row["whsename"]);
                }
            }
            else
            {
                string currentWhse = "";
                foreach (DataRow row in dtWarehouse.Rows)
                {
                    if (row["whsecode"].ToString() == whse)
                    {
                        currentWhse = row["whsename"].ToString();
                    }
                }
                cmb.Items.Add(currentWhse);
            }
            //default text 
            //kapag admin or to whse all yung lalabas
            //kapag hindi kung ano yung current whse nya yun yung lalabas
            if (isAdmin || isTo)
            {
                cmb.SelectedIndex = 0;
            }
            else
            {
                string whseName = "";
                foreach (DataRow row in dtWarehouse.Rows)
                {
                    if (row["whsecode"].ToString() == whse)
                    {
                        whseName = row["whsename"].ToString();
                        break;
                    }
                }
                cmb.SelectedIndex = cmb.Items.IndexOf(whseName);
            }
        }

        private void btnSearchQuery_Click(object sender, EventArgs e)
        {
            loadData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            loadData();
        }

        public void loadData()
        {
            dgvTransactions.Rows.Clear();
            string statusCode = cmbStatusTransactions.SelectedIndex <= 0 ? "" : cmbStatusTransactions.SelectedIndex == 1 ? "O" :
    cmbStatusTransactions.SelectedIndex == 2 ? "C" :
    cmbStatusTransactions.SelectedIndex == 3 ? "N" : "";
            statusCode = this.Text.Equals("Transfer Transactions") && gForType.Equals("For Transactions") ? "O" : this.Text.Equals("Transfer Transactions") && gForType.Equals("For SAP") ? "C" : this.Text.Equals("Transfer Transactions") && gForType.Equals("Cancelled") ? "N" : statusCode;
            DataTable dtTransfers = new DataTable();


            string url = "trfr";
            if (this.Text == "Transfer Transactions")
            {
                url = "trfr";
            }
            else if (this.Text == "Pullout Transactions")
            {
                url = "pullout";
            }
            else
            {
                url = "recv";
            }
            //MessageBox.Show("TRANSFER 2: "  +url);

            string warehouseCode = "", branchCode = "", toWarehouseCode = "";
            //WAREHOUSE
            foreach (DataRow row in dtWarehouse.Rows)
            {
                if (cmbWhse.Text.Equals(row["whsename"].ToString()))
                {
                    warehouseCode = row["whsecode"].ToString();
                    break; 
                }
            }
            //TO WAREHOUSE
            foreach (DataRow row in dtWarehouse.Rows)
            {
                if (cmbToWhse.Text.Equals(row["whsename"].ToString()))
                {
                    toWarehouseCode = row["whsecode"].ToString();
                    break;
                }
            }
            //BRANCH
            foreach (DataRow row in dtBranch.Rows)
            {
                if (cmbBranch.Text.Equals(row["name"].ToString()))
                {
                    branchCode = row["code"].ToString();
                    break;
                }
            }
            string whseName = (url.Equals("pullout") ? "whsecode" : "from_whse");
          
            string sWarehouse = string.IsNullOrEmpty(warehouseCode) ? "" : "&" + whseName + "=" + warehouseCode;
            string sToWarehouse = string.IsNullOrEmpty(toWarehouseCode) ? "" : "&to_whse=" + toWarehouseCode;
            string sBranch = string.IsNullOrEmpty(branchCode) ? "" : "&branch=" + branchCode;
            string sUnderScore = "", sURL = "";
            if (url.Equals("recv") || url.Equals("pullout"))
            {
                sUnderScore = "_";
            }
            if (url.Equals("pullout"))
            {
                sURL = "/api/";
            }
            else
            {
                sURL = "/api/inv/";
            }
            //MessageBox.Show("class: " + URL);
            dtTransfers = transferc.loadData(sURL + url + "/get" + sUnderScore + "all", statusCode, txtsearchTransactions.Text.Trim(), dtToDate.Value.ToString("yyyy-MM-dd"), gForType , sBranch , sWarehouse, sToWarehouse,dtFromDate.Value.ToString("yyyy-MM-dd"));
            if (dtTransfers.Rows.Count > 0)
            {
                AutoCompleteStringCollection auto = new AutoCompleteStringCollection();
                foreach (DataRow row in dtTransfers.Rows)
                {
                    string decodeDocStatus = row["docstatus"].ToString() == "O" ? "Open" : row["docstatus"].ToString() == "C" ? "Closed" : "Cancelled";
                    auto.Add(row["sap_number"].ToString());

                    string replaceT = row["transdate"].ToString().Replace("T", "");
                   DateTime  dtTransDate = Convert.ToDateTime(replaceT);
                    double recCount = 0.00;
                    if (this.Text.Equals("Transfer Transactions"))
                    {
                        recCount = Convert.ToDouble(row["rec_count"].ToString());
                    }

                    if (!string.IsNullOrEmpty(txtsearchTransactions.Text.ToString().Trim()))
                    {
                        if (txtsearchTransactions.Text.ToString().Trim().ToLower().Contains(row["sap_number"].ToString().ToLower()))
                        {
                            dgvTransactions.Rows.Add(row["id"], row["transnumber"], dtTransDate.ToString("yyyy-MM-dd"), row["reference"], row["remarks"], decodeDocStatus, row["sap_number"], row["variance_count"].ToString(), recCount);
                        }
                    }
                    else
                    {
                        dgvTransactions.Rows.Add(row["id"], row["transnumber"], dtTransDate.ToString("yyyy-MM-dd"), row["reference"], row["remarks"], decodeDocStatus, row["sap_number"], row["variance_count"].ToString(),recCount);
                    }
                }
                txtsearchTransactions.AutoCompleteCustomSource = auto;
            }
            lblNoDataFound.Visible = (dgvTransactions.Rows.Count <= 0 ? true : false);


            if (this.Text == "Transfer Transactions")
            {
                checkVariance();
            }
        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            loadData();
        }

        private void txtsearchTransactions_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                loadData();
            }
        }

        private void dtFromDate_ValueChanged(object sender, EventArgs e)
        {
            if (cFromDate <= 0)
            {
                loadData();
            }
        }

        private void dgvTransactions_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvTransactions.Rows.Count > 0)
            {
                if (e.ColumnIndex == 9)
                {
                    int id = 0, intTemp = 0;
                    id = int.TryParse(dgvTransactions.CurrentRow.Cells["id"].Value.ToString(), out intTemp) ? Convert.ToInt32(dgvTransactions.CurrentRow.Cells["id"].Value.ToString()) : intTemp;
                    if(id > 0)
                    {
                        ViewReceive frm = new ViewReceive();
                        frm.baseReference = dgvTransactions.CurrentRow.Cells["reference"].Value.ToString();
                        frm.selectedID = id;
                        frm.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("No receive found", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else if(e.ColumnIndex==3)
                {
                    string sText = "";
                    if (this.Text.Equals("Transfer Transactions"))
                    {
                        sText = "Transfer Items";
                    }
                    else if (this.Text.Equals("Received Transactions"))
                    {
                        sText = "Received Items";
                    }
                    else
                    {
                        sText = "Pullout Items";

                    }
                    TransferItems transferItems = new TransferItems(gForType);
                    transferItems.selectedID = Convert.ToInt32(dgvTransactions.CurrentRow.Cells["id"].Value.ToString());

                    transferItems.Text = sText;
                    transferItems.ShowDialog();
                    if (TransferItems.isSubmit)
                    {
                        loadData();
                    }
                }
            }
        }

        private  void cmbBranch_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cBranch <= 0)
            {
                loadWarehouse(cmbWhse, true);
            }
        }
    }
}
