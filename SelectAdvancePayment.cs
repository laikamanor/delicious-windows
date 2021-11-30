using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DeliciousPartnerApp.API_Class.Advance_Payment;
using Newtonsoft.Json.Linq;

namespace DeliciousPartnerApp
{
    public partial class SelectAdvancePayment : Form
    {
        advancepayment_class advancepaymentc = new advancepayment_class();
        public SelectAdvancePayment(string moduleName)
        {
            InitializeComponent();
            this.moduleName = moduleName;
        }
        string moduleName = "";
        private void SelectAdvancePayment_Load(object sender, EventArgs e)
        {
            loadData();
        }

        public void loadData()
        {
            DataTable dtResponse = new DataTable();
            dtResponse = advancepaymentc.loadData("O", "In Deposit");
            dgv.Rows.Clear();
            if (dtResponse.Rows.Count > 0)
            {
                AutoCompleteStringCollection auto = new AutoCompleteStringCollection();
                foreach (DataRow r0w in dtResponse.Rows)
                {
                    double amount = Convert.ToDouble(r0w["amount"].ToString());
                    double balance = Convert.ToDouble(r0w["balance"].ToString());

                    auto.Add(r0w["reference"].ToString());
                    auto.Add(r0w["cust_code"].ToString());
                    auto.Add(r0w["remarks"].ToString());

                    bool selectValue = false;
                    double totalPayment = 0.00;
                    DataRowCollection row1 = moduleName.Equals("PendingOrder2") ? PendingOrder2.dtSelectedDeposit.Rows : Sales.dtSelectedDeposit.Rows;
                    foreach (DataRow row in row1)
                    {
                        if (row["id"].ToString() == r0w["id"].ToString() && row["type"].ToString() == "Deposit")
                        {
                            selectValue = true;
                            totalPayment = Convert.ToDouble(row["amount"].ToString());
                        }
                    }
                    if (totalPayment <= 0)
                    {
                        totalPayment = balance;
                    }


                    if (!string.IsNullOrEmpty(txtSearch.Text.ToString().Trim()))
                    {
                        if (txtSearch.Text.ToString().Trim().ToLower().Contains(r0w["reference"].ToString().ToLower()))
                        {
                            dgv.Rows.Add(selectValue, r0w["id"], r0w["cust_code"], Convert.ToDecimal(string.Format("{0:0.00}", amount)), Convert.ToDecimal(string.Format("{0:0.00}", balance)), Convert.ToDecimal(string.Format("{0:0.00}", totalPayment)), r0w["reference"], r0w["sap_number"]);
                        }
                        else if (txtSearch.Text.ToString().Trim().ToLower().Contains(r0w["cust_code"].ToString().ToLower()))
                        {
                            dgv.Rows.Add(selectValue, r0w["id"], r0w["cust_code"], Convert.ToDecimal(string.Format("{0:0.00}", amount)), Convert.ToDecimal(string.Format("{0:0.00}", balance)), Convert.ToDecimal(string.Format("{0:0.00}", totalPayment)), r0w["reference"], r0w["sap_number"]);
                        }
                    }
                    else
                    {
                        dgv.Rows.Add(selectValue, r0w["id"], r0w["cust_code"], Convert.ToDecimal(string.Format("{0:0.00}", amount)), Convert.ToDecimal(string.Format("{0:0.00}", balance)), Convert.ToDecimal(string.Format("{0:0.00}", totalPayment)), r0w["reference"], r0w["sap_number"]);
                    }
                }
                //for(int i = 0; i < dgv.Rows.Count; i++)
                //{
                //    foreach (DataRow row in PendingOrder2.dtSelectedDeposit.Rows)
                //    {
                //        if (row["id"].ToString() == dgv.CurrentRow.Cells["id"].Value.ToString() && row["type"].ToString() == "Deposit")
                //        {
                //            dgv.Rows[i].Cells["selectt"].Value = true;
                //            dgv.Rows[i].Cells["total_payment"].Value = row["amount"].ToString();
                //        }
                //    }
                //}
                txtSearch.AutoCompleteCustomSource = auto;
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            //PendingOrder2.dtSelectedDeposit.Rows.Clear();
            int count = moduleName.Equals("PendingOrder2") ? PendingOrder2.dtSelectedDeposit.Rows.Count : Sales.dtSelectedDeposit.Rows.Count;
            for (int i = 0; i < count; i++)
            {
                DataRow row = moduleName.Equals("PendingOrder2") ? PendingOrder2.dtSelectedDeposit.Rows[i] : Sales.dtSelectedDeposit.Rows[i];
                if (row["type"].ToString() == "Deposit")
                {
                    if (moduleName.Equals("PendingOrder2"))
                    {
                        PendingOrder2.dtSelectedDeposit.Rows.RemoveAt(i);
                    }
                    else
                    {
                        Sales.dtSelectedDeposit.Rows.RemoveAt(i);
                    }
                }
            }
            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                if (Convert.ToBoolean(dgv.Rows[i].Cells["selectt"].Value.ToString()))
                {
                    if (moduleName.Equals("PendingOrder2"))
                    {
                        PendingOrder2.dtSelectedDeposit.Rows.Add(Convert.ToInt32(dgv.Rows[i].Cells["id"].Value.ToString()), Convert.ToDouble(dgv.Rows[i].Cells["total_payment"].Value.ToString()), "FDEPS", dgv.Rows[i].Cells["sapnumber"].Value.ToString(), dgv.Rows[i].Cells["reference"].Value.ToString(), "Deposit");
                    }
                    else
                    {
                        Sales.dtSelectedDeposit.Rows.Add(Convert.ToInt32(dgv.Rows[i].Cells["id"].Value.ToString()), Convert.ToDouble(dgv.Rows[i].Cells["total_payment"].Value.ToString()), "FDEPS", dgv.Rows[i].Cells["sapnumber"].Value.ToString(), dgv.Rows[i].Cells["reference"].Value.ToString(), "Deposit");
                    }
                }
            }
            this.Dispose();
        }

        private void btnAddAdvancePayment_Click(object sender, EventArgs e)
        {
            AddAdvancePayment addAdvancePayment = new AddAdvancePayment();
            addAdvancePayment.ShowDialog();
            if (AddAdvancePayment.isSubmit)
            {
                loadData();
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

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dgv.Rows.Count > 0)
            {
                if (e.ColumnIndex == 8)
                {
                    dgv.CurrentCell = dgv[0, dgv.CurrentRow.Index];
                    dgv.ClearSelection();
                    dgv.CurrentRow.Cells["total_payment"].Selected = true;
                    EnterAmount frm = new EnterAmount();
                    EnterAmount.amount = 0.00;
                    EnterAmount.amount = Convert.ToDouble(dgv.CurrentRow.Cells["total_payment"].Value.ToString());
                    frm.reference = dgv.CurrentRow.Cells["cust_code"].Value.ToString();
                    frm.ShowDialog();
                    dgv.CurrentRow.Cells["total_payment"].Value = Convert.ToDecimal(string.Format("{0:0.00}", EnterAmount.amount));
                }
            }
        }
    }
}
