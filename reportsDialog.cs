using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DeliciousPartnerApp.API_Class.Reports;
using System.IO;

namespace DeliciousPartnerApp
{
    public partial class reportsDialog : Form
    {
        string gReportType = "";
        finalCount_class finalCountc = new finalCount_class();
        public reportsDialog(string reportType)
        {
            gReportType = reportType;
            InitializeComponent();
        }

        private void reportsDialog_Load(object sender, EventArgs e)
        {
          try
            {
                this.Cursor = Cursors.WaitCursor;


                DataTable dtResult = new DataTable();
                if (gReportType.Equals("Final Count Report"))
                {
                    dtResult = loadFinalCount();
                    countReports finalCount = new countReports();
                    finalCount.Database.Tables["row"].SetDataSource(dtResult);
                    finalCount.SetParameterValue("date_report", EnterDate.dateEntered);
                    finalCount.SetParameterValue("branch", EnterDate.branchName);
                    crystalReportViewer1.ReportSource = null;
                    crystalReportViewer1.ReportSource = finalCount;
                }
                else if(gReportType.Equals("Final Report"))
                {
                    dtResult = loadFinal();
                    DeliciousPartnerApp.finalReport finalReport = new finalReport();
                    finalReport.Subreports[3].Database.Tables["sub_report1"].SetDataSource(loadFinal_SubQuery1());
                    finalReport.Subreports[4].Database.Tables["payment_method"].SetDataSource(loadPaymentMethod());
                    finalReport.Subreports[0].Database.Tables["discountTypeSummary"].SetDataSource(loadDiscountTypeSummary());
                    finalReport.Subreports[1].Database.Tables["employee_charge"].SetDataSource(loadEmployeeCharge());
                    finalReport.Subreports[2].Database.Tables["row"].SetDataSource(dtResult);
                    //finalReport.Database.Tables["row"].SetDataSource(dtResult);
                    finalReport.SetParameterValue("selectedBranch", EnterDate.branchName);
                    finalReport.SetParameterValue("date_report", EnterDate.dateEntered);
                    crystalReportViewer1.ReportSource = null;
                    crystalReportViewer1.ReportSource = finalReport;
                }
                else if (gReportType.Equals("Final Sales Report"))
                {
                    dtResult = loadFinal();
                    finalSales finalReport = new finalSales();
                    finalReport.Subreports[0].Database.Tables["discountTypeSummary"].SetDataSource(loadDiscountTypeSummary());
                    finalReport.Subreports[1].Database.Tables["row"].SetDataSource(loadFinal_SubQuery1());
                    finalReport.Subreports[2].Database.Tables["payment_method"].SetDataSource(loadPaymentMethod());
                    finalReport.SetParameterValue("date_report", EnterDate.dateEntered);
                    finalReport.SetParameterValue("branch", EnterDate.branchName);
                    crystalReportViewer1.ReportSource = null;
                    crystalReportViewer1.ReportSource = finalReport;
                }

                this.Cursor = Cursors.Default;
            }
            catch(Exception ex)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show(ex.ToString());
            }
        }

        public DataTable loadPaymentMethod()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("transtype", typeof(string));
            dt.Columns.Add("cash_sales", typeof(double));
            dt.Columns.Add("ar_sales", typeof(double));
            dt.Columns.Add("agent_sales", typeof(double));
            dt.Columns.Add("total", typeof(double));

            DataTable dtFromAPI = new DataTable();
            dtFromAPI = finalCountc.loadPaymentMethod(EnterDate.dateEntered,gReportType, EnterDate.branchCode);
            foreach (DataRow row in dtFromAPI.Rows)
            {
                dt.Rows.Add(row["transtype"].ToString(), Convert.ToDouble(row["cash_sales"].ToString()), Convert.ToDouble(row["ar_sales"].ToString()), Convert.ToDouble(row["agent_sales"].ToString()), Convert.ToDouble(row["total"].ToString()));
            }
            return dt;
        }

        public DataTable loadDiscountTypeSummary()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("disctype", typeof(string));
            dt.Columns.Add("total", typeof(double));

            DataTable dtFromAPI = new DataTable();
            dtFromAPI = finalCountc.loadDiscountTypeSummary(EnterDate.dateEntered, gReportType, EnterDate.branchCode);
            foreach (DataRow row in dtFromAPI.Rows)
            {
                Console.WriteLine(row["disctype"].ToString() + "/" + row["total"].ToString());
                dt.Rows.Add(row["disctype"].ToString(), Convert.ToDouble(row["total"].ToString()));
            }
            return dt;
        }

        public DataTable loadEmployeeCharge()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("reference", typeof(string));
            dt.Columns.Add("transdate", typeof(string));
            dt.Columns.Add("cust_code", typeof(string));
            dt.Columns.Add("gl_account", typeof(string));
            dt.Columns.Add("doctotal", typeof(double));

            DataTable dtFromAPI = new DataTable();
            dtFromAPI = finalCountc.loadEmployeeCharge(EnterDate.dateEntered, gReportType, EnterDate.branchCode);
            foreach (DataRow row in dtFromAPI.Rows)
            {
                dt.Rows.Add(row["reference"].ToString(), row["transdate"].ToString(), row["cust_code"].ToString(), row["gl_account"].ToString(), Convert.ToDouble(row["doctotal"].ToString()));
            }
            return dt;
        }

        public DataTable loadFinal_SubQuery1()
        {
            DataTable dt = new DataTable();
            //CASH
            dt.Columns.Add("total_cash_on_hand", typeof(double));
            dt.Columns.Add("total_cash_payment", typeof(double));
            dt.Columns.Add("total_cash_deposit", typeof(double));
            dt.Columns.Add("total_used_dep_payment", typeof(double));
            dt.Columns.Add("total_bank_dep_payment", typeof(double));
            dt.Columns.Add("total_epay_payment", typeof(double));
            dt.Columns.Add("total_gcert_payment", typeof(double));
            //SALES
            dt.Columns.Add("gross", typeof(double));
            dt.Columns.Add("net_sales", typeof(double));
            dt.Columns.Add("disc_amount", typeof(double));
            dt.Columns.Add("gross_cash_sales", typeof(double));
            dt.Columns.Add("disc_cash_sales", typeof(double));
            dt.Columns.Add("net_cash_sales", typeof(double));
            dt.Columns.Add("gross_ar_sales", typeof(double));
            dt.Columns.Add("disc_ar_sales", typeof(double));
            dt.Columns.Add("net_ar_sales", typeof(double));
            dt.Columns.Add("gross_agent_sales", typeof(double));
            dt.Columns.Add("disc_agent_sales", typeof(double));
            dt.Columns.Add("net_agent_sales", typeof(double));

            //ITEMS
            if(gReportType.Equals("Final Report"))
            {
                dt.Columns.Add("total_amount", typeof(double));
            }
            dt.Columns.Add("actual_cash", typeof(double));
            if (gReportType.Equals("Final Report"))
            {
                dt.Columns.Add("remarks", typeof(string));
            }

            DataTable dtFromAPI = new DataTable();
            dtFromAPI = finalCountc.loadFinal(EnterDate.dateEntered, gReportType, EnterDate.branchCode);
            foreach (DataRow row in dtFromAPI.Rows)
            {
                if(gReportType.Equals("Final Report"))
                {
                    dt.Rows.Add(Convert.ToDouble(row["total_cash_on_hand"].ToString()).ToString("n2"), Convert.ToDouble(row["total_cash_payment"].ToString()).ToString("n2"), Convert.ToDouble(row["total_cash_deposit"].ToString()).ToString("n2"), Convert.ToDouble(row["total_used_dep_payment"].ToString()).ToString("n2"), Convert.ToDouble(row["total_bank_dep_payment"].ToString()).ToString("n2"), Convert.ToDouble(row["total_epay_payment"].ToString()).ToString("n2"), Convert.ToDouble(row["total_gcert_payment"].ToString()).ToString("n2"), Convert.ToDouble(row["gross"].ToString()).ToString("n2"), Convert.ToDouble(row["net_sales"].ToString()).ToString("n2"), Convert.ToDouble(row["disc_amount"].ToString()).ToString("n2"), Convert.ToDouble(row["gross_cash_sales"].ToString()).ToString("n2"), Convert.ToDouble(row["disc_cash_sales"].ToString()).ToString("n2"), Convert.ToDouble(row["net_cash_sales"].ToString()).ToString("n2"), Convert.ToDouble(row["gross_ar_sales"].ToString()).ToString("n2"), Convert.ToDouble(row["disc_ar_sales"].ToString()).ToString("n2"), Convert.ToDouble(row["net_ar_sales"].ToString()).ToString("n2"), Convert.ToDouble(row["gross_agent_sales"].ToString()).ToString("n2"), Convert.ToDouble(row["disc_agent_sales"].ToString()).ToString("n2"), Convert.ToDouble(row["net_agent_sales"].ToString()).ToString("n2"), Convert.ToDouble(row["total_amount"].ToString()), Convert.ToDouble(row["actual_cash"].ToString()), row["remarks"].ToString());
                }else
                {
                    dt.Rows.Add(Convert.ToDouble(row["total_cash_on_hand"].ToString()).ToString("n2"), Convert.ToDouble(row["total_cash_payment"].ToString()).ToString("n2"), Convert.ToDouble(row["total_cash_deposit"].ToString()).ToString("n2"), Convert.ToDouble(row["total_used_dep_payment"].ToString()).ToString("n2"), Convert.ToDouble(row["total_bank_dep_payment"].ToString()).ToString("n2"), Convert.ToDouble(row["total_epay_payment"].ToString()).ToString("n2"), Convert.ToDouble(row["total_gcert_payment"].ToString()).ToString("n2"), Convert.ToDouble(row["gross"].ToString()).ToString("n2"), Convert.ToDouble(row["net_sales"].ToString()).ToString("n2"), Convert.ToDouble(row["disc_amount"].ToString()).ToString("n2"), Convert.ToDouble(row["gross_cash_sales"].ToString()).ToString("n2"), Convert.ToDouble(row["disc_cash_sales"].ToString()).ToString("n2"), Convert.ToDouble(row["net_cash_sales"].ToString()).ToString("n2"), Convert.ToDouble(row["gross_ar_sales"].ToString()).ToString("n2"), Convert.ToDouble(row["disc_ar_sales"].ToString()).ToString("n2"), Convert.ToDouble(row["net_ar_sales"].ToString()).ToString("n2"), Convert.ToDouble(row["gross_agent_sales"].ToString()).ToString("n2"), Convert.ToDouble(row["disc_agent_sales"].ToString()).ToString("n2"), Convert.ToDouble(row["net_agent_sales"].ToString()).ToString("n2"), Convert.ToDouble(row["actual_cash"].ToString()));
                }
            }
            return dt;
        }
       

        public DataTable loadFinal()
        {
            DataTable dt = new DataTable();
            //CASH
            dt.Columns.Add("total_cash_on_hand", typeof(double));
            dt.Columns.Add("total_cash_payment", typeof(double));
            dt.Columns.Add("total_cash_deposit", typeof(double));
            dt.Columns.Add("total_used_dep_payment", typeof(double));
            dt.Columns.Add("total_bank_dep_payment", typeof(double));
            dt.Columns.Add("total_epay_payment", typeof(double));
            dt.Columns.Add("total_gcert_payment", typeof(double));
            //SALES
            dt.Columns.Add("gross", typeof(double));
            dt.Columns.Add("net_sales", typeof(double));
            dt.Columns.Add("disc_amount", typeof(double));
            dt.Columns.Add("gross_cash_sales", typeof(double));
            dt.Columns.Add("disc_cash_sales", typeof(double));
            dt.Columns.Add("net_cash_sales", typeof(double));
            dt.Columns.Add("gross_ar_sales", typeof(double));
            dt.Columns.Add("disc_ar_sales", typeof(double));
            dt.Columns.Add("net_ar_sales", typeof(double));
            dt.Columns.Add("gross_agent_sales", typeof(double));
            dt.Columns.Add("disc_agent_sales", typeof(double));
            dt.Columns.Add("net_agent_sales", typeof(double));

            //ITEMS
            if(gReportType.Equals("Final Report"))
            {
                dt.Columns.Add("item_code", typeof(string));
                dt.Columns.Add("actual_good", typeof(double));
                dt.Columns.Add("actual_pullout", typeof(double));
                dt.Columns.Add("system_bal", typeof(double));
                dt.Columns.Add("variance", typeof(double));
                dt.Columns.Add("price", typeof(double));
                dt.Columns.Add("total_amount", typeof(double));
            }
            dt.Columns.Add("actual_cash", typeof(double));
            if(gReportType.Equals("Final Report"))
            {
                dt.Columns.Add("remarks", typeof(string));
            }
            DataTable dtFromAPI = new DataTable();
            dtFromAPI = finalCountc.loadFinal(EnterDate.dateEntered, gReportType, EnterDate.branchCode);
            foreach (DataRow row in dtFromAPI.Rows)
            {
                if(gReportType.Equals("Final Report"))
                {
                    if (Convert.ToDouble(row["variance"].ToString()) != 0.00)
                    {
                        dt.Rows.Add(Convert.ToDouble(row["total_cash_on_hand"].ToString()).ToString("n2"), Convert.ToDouble(row["total_cash_payment"].ToString()).ToString("n2"), Convert.ToDouble(row["total_cash_deposit"].ToString()).ToString("n2"), Convert.ToDouble(row["total_used_dep_payment"].ToString()).ToString("n2"), Convert.ToDouble(row["total_bank_dep_payment"].ToString()).ToString("n2"), Convert.ToDouble(row["total_epay_payment"].ToString()).ToString("n2"), Convert.ToDouble(row["total_gcert_payment"].ToString()).ToString("n2"), Convert.ToDouble(row["gross"].ToString()).ToString("n2"), Convert.ToDouble(row["net_sales"].ToString()).ToString("n2"), Convert.ToDouble(row["disc_amount"].ToString()).ToString("n2"), Convert.ToDouble(row["gross_cash_sales"].ToString()).ToString("n2"), Convert.ToDouble(row["disc_cash_sales"].ToString()).ToString("n2"), Convert.ToDouble(row["net_cash_sales"].ToString()).ToString("n2"), Convert.ToDouble(row["gross_ar_sales"].ToString()).ToString("n2"), Convert.ToDouble(row["disc_ar_sales"].ToString()).ToString("n2"), Convert.ToDouble(row["net_ar_sales"].ToString()).ToString("n2"), Convert.ToDouble(row["gross_agent_sales"].ToString()).ToString("n2"), Convert.ToDouble(row["disc_agent_sales"].ToString()).ToString("n2"), Convert.ToDouble(row["net_agent_sales"].ToString()).ToString("n2"), row["item_code"].ToString(), Convert.ToDouble(row["actual_good"].ToString()).ToString("n2"), Convert.ToDouble(row["actual_pullout"].ToString()).ToString("n2"), Convert.ToDouble(row["system_bal"].ToString()).ToString("n2"), Convert.ToDouble(row["variance"].ToString()).ToString("n2"), Convert.ToDouble(row["price"].ToString()).ToString("n2"), Convert.ToDouble(row["total_amount"].ToString()).ToString("n2"), Convert.ToDouble(row["actual_cash"].ToString()), row["remarks"].ToString());
                    }
                }
                else
                {
                    dt.Rows.Add(Convert.ToDouble(row["total_cash_on_hand"].ToString()).ToString("n2"), Convert.ToDouble(row["total_cash_payment"].ToString()).ToString("n2"), Convert.ToDouble(row["total_cash_deposit"].ToString()).ToString("n2"), Convert.ToDouble(row["total_used_dep_payment"].ToString()).ToString("n2"), Convert.ToDouble(row["total_bank_dep_payment"].ToString()).ToString("n2"), Convert.ToDouble(row["total_epay_payment"].ToString()).ToString("n2"), Convert.ToDouble(row["total_gcert_payment"].ToString()).ToString("n2"), Convert.ToDouble(row["gross"].ToString()).ToString("n2"), Convert.ToDouble(row["net_sales"].ToString()).ToString("n2"), Convert.ToDouble(row["disc_amount"].ToString()).ToString("n2"), Convert.ToDouble(row["gross_cash_sales"].ToString()).ToString("n2"), Convert.ToDouble(row["disc_cash_sales"].ToString()).ToString("n2"), Convert.ToDouble(row["net_cash_sales"].ToString()).ToString("n2"), Convert.ToDouble(row["gross_ar_sales"].ToString()).ToString("n2"), Convert.ToDouble(row["disc_ar_sales"].ToString()).ToString("n2"), Convert.ToDouble(row["net_ar_sales"].ToString()).ToString("n2"), Convert.ToDouble(row["gross_agent_sales"].ToString()).ToString("n2"), Convert.ToDouble(row["disc_agent_sales"].ToString()).ToString("n2"), Convert.ToDouble(row["net_agent_sales"].ToString()).ToString("n2"), Convert.ToDouble(row["actual_cash"].ToString()));
                }
            }
            return dt;
        }

        public DataTable loadFinalCount()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("item_code", typeof(string));
            dt.Columns.Add("quantity", typeof(double));
            dt.Columns.Add("ending_sales_count", typeof(double));
            dt.Columns.Add("ending_auditor_count", typeof(double));
            dt.Columns.Add("ending_manager_count", typeof(double));
            dt.Columns.Add("ending_final_count", typeof(double));
            dt.Columns.Add("po_sales_count", typeof(double));
            dt.Columns.Add("po_auditor_count", typeof(double));
            dt.Columns.Add("po_manager_count", typeof(double));
            dt.Columns.Add("po_final_count", typeof(double));
            dt.Columns.Add("variance", typeof(double));
            dt.Columns.Add("uom", typeof(string));

            dt.Columns.Add("sales_user", typeof(string));
            dt.Columns.Add("auditor_user", typeof(string));
            dt.Columns.Add("manager_user", typeof(string));

            DataTable dtFromAPI = new DataTable();
            dtFromAPI = finalCountc.loadFinalCount(EnterDate.dateEntered,EnterDate.branchCode);
            foreach (DataRow row in dtFromAPI.Rows)
            {
                //MessageBox.Show("Auditor: " +  row["auditor_user"].ToString() + Environment.NewLine + "Manager: " + row["manager_user"].ToString());
                dt.Rows.Add(row["item_code"].ToString(), Convert.ToInt32(row["quantity"]).ToString("N0"), Convert.ToInt32(row["ending_sales_count"]).ToString("N0"), Convert.ToInt32(row["ending_auditor_count"]).ToString("N0"), Convert.ToInt32(row["ending_manager_count"]).ToString("N0"), Convert.ToInt32(row["ending_final_count"]).ToString("N0"), Convert.ToInt32(row["po_sales_count"]).ToString("N0"), Convert.ToInt32(row["po_auditor_count"]).ToString("N0"), Convert.ToInt32(row["po_manager_count"]).ToString("N0"), Convert.ToInt32(row["po_final_count"]).ToString("N0"), Convert.ToInt32(row["variance"]).ToString("N0"), row["uom"].ToString(), row["sales_user"].ToString(), row["auditor_user"].ToString(), row["manager_user"].ToString());
            }
            return dt;
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }

        private void crystalReportViewer1_Load_1(object sender, EventArgs e)
        {

        }
    }
}
