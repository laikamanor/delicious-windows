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
using Newtonsoft.Json;

namespace DeliciousPartnerApp
{
    public partial class editCustomer : Form
    {
        public editCustomer()
        {
            InitializeComponent();
        }
        public int custType = 0;
        DataTable dtCustType = new DataTable();
        api_class apic = new api_class();
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            JObject joBody = new JObject();
            joBody.Add("code", txtCustCode.Text);
            joBody.Add("name", txtCustName.Text);
            string sCustType = apic.findValueInDataTable(dtCustType, cmbCustType.Text,"name", "id");
            int finalCustType = 0, intTemp = 0;
            finalCustType = int.TryParse(sCustType, out intTemp) ? Convert.ToInt32(sCustType) : intTemp;
            joBody.Add("cust_type", finalCustType);
            Console.WriteLine(joBody);
            string sResult = apic.loadData("/api/customer/update/", lblID.Text, "application/json", joBody.ToString(), Method.PUT, true);
            if (!string.IsNullOrEmpty(sResult) && sResult.Substring(0, 1).Equals("{"))
            {
                JObject joResponse = JObject.Parse(sResult);
                bool boolTemp = false;
                bool isSuccess = joResponse["success"] == null ? boolTemp : bool.TryParse(joResponse["success"].ToString(), out boolTemp) ? Convert.ToBoolean(joResponse["success"].ToString()) : boolTemp;
                string msg = joResponse["message"].ToString();
                apic.showCustomMsgBox(isSuccess ? "Message" : "Validation", msg);
                if (isSuccess)
                {
                    this.Hide();
                }
            }
        }

        private void editCustomer_Load(object sender, EventArgs e)
        {
            cmbCustType.Items.Clear();
            string sResult = apic.loadData("/api/custtype/get_all", "", "", "", Method.GET, true);
            if (!string.IsNullOrEmpty(sResult) && sResult.Substring(0, 1).Equals("{"))
            {
                JObject joResponse = JObject.Parse(sResult);
                JArray jaData = (JArray)joResponse["data"];
                dtCustType = (DataTable)JsonConvert.DeserializeObject(jaData.ToString(), (typeof(DataTable)));
                foreach(DataRow row in dtCustType.Rows)
                {
                    cmbCustType.Items.Add(row["name"].ToString());
                }
            }
            int i = cmbCustType.Items.IndexOf(apic.findValueInDataTable(dtCustType, custType.ToString(), "id", "name"));
            cmbCustType.SelectedIndex = i <= 0 ? 0 : i;

        }
    }
}
