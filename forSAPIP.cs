using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DeliciousPartnerApp.API_Class.Payment_Type;
namespace DeliciousPartnerApp
{
    public partial class forSAPIP : Form
    {
        paymenttype_class paymenttypec = new paymenttype_class();
        DataTable dtPaymentTypes;
        string gForType = "", gSalesType = "";
        int cTabs = 1;
        public forSAPIP(string salesType, string forType)
        {
            gForType = forType;
            gSalesType = salesType;
            InitializeComponent();
        }

        private void forSAPIP_Load(object sender, EventArgs e)
        {
            dtPaymentTypes = new DataTable();
            loadPaymentTypes();
        }

        public void loadPaymentTypes()
        {
            tcPaymentTypes.TabPages.Clear();
            dtPaymentTypes = paymenttypec.loadPaymentType("payment");
            foreach (DataRow row in dtPaymentTypes.Rows)
            {
                TabPage tp = new TabPage();
                tp.Text = row["description"].ToString();
                tp.Name = "tp_" + row["description"].ToString().Replace(" ", "");


                Panel panel = new Panel();
                panel.Name = "pn_" + row["description"].ToString().Replace(" ", "");
                panel.Dock = DockStyle.Fill;

                tp.Controls.Add(panel);
                tcPaymentTypes.TabPages.Add(tp);
            }

            DataRow row2 = dtPaymentTypes.Rows[0];
            string pnName = "pn_" + row2["description"].ToString().Replace(" ", "");
            Panel panelFind = this.Controls.Find(pnName, true).FirstOrDefault() as Panel;
            forSAPIP2 forsapip2 = new forSAPIP2(gSalesType,gForType);
            forsapip2.TopLevel = false;
            panelFind.Controls.Clear();
            panelFind.Controls.Add(forsapip2);
            forsapip2.BringToFront();
            forsapip2.Show();
            cTabs = 0;

        }

        public string findPaymentTypesData(string value)
        {
            string result = "";
            foreach(DataRow row in dtPaymentTypes.Rows)
            {
                if(value == row["description"].ToString())
                {
                    result = row["code"].ToString();
                }
            }
            return result;
        }

        private void tcPaymentTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            //loop mo tabpages then pass mo sa forsapip2 yung text
            if(cTabs <= 0)
            {
                string description = tcPaymentTypes.SelectedTab.Text;
                string pnName = "pn_" + description.Replace(" ", "");
                string code = findPaymentTypesData(description);
                Panel panelFind = this.Controls.Find(pnName, true).FirstOrDefault() as Panel;
                forSAPIP2 forsapip2 = new forSAPIP2(gSalesType, gForType);
                forsapip2.TopLevel = false;
                panelFind.Controls.Clear();
                panelFind.Controls.Add(forsapip2);
                forsapip2.BringToFront();
                forsapip2.Show();
            }

        }

        public int findIndexTabPages(string value)
        {
            int result = 0;
            foreach (TabPage tp in tcPaymentTypes.TabPages)
            {
                //if (value.Equals(tp.Text))
                //{
                //    result = tcPaymentTypes.TabPages.IndexOf(tp);
                //    break;
                //}
                
            }
            return result;
        }
    }
}
