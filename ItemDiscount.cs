using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeliciousPartnerApp
{
    public partial class ItemDiscount : Form
    {
        public ItemDiscount()
        {
            InitializeComponent();
        }
        public string jsonResponse = "";
        private void ItemDiscount_Load(object sender, EventArgs e)
        {
            loadData();
            dgvitems.Columns["item_code"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvitems.Columns["reference"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvitems.Columns["processed_by"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
        }

        public void loadData()
        {
            dgvitems.Rows.Clear();
            Cursor.Current = Cursors.WaitCursor;
            JObject jsonObject= new JObject();
            if (jsonResponse.Substring(0, 1).Equals("{"))
            {
                jsonObject = JObject.Parse(jsonResponse);
                foreach (var x in jsonObject)
                {
                    if (x.Key.Equals("data"))
                    {
                        if (x.Value.ToString() != "[]")
                        {
                            JArray jsonArray = JArray.Parse(x.Value.ToString());
                            for (int i = 0; i < jsonArray.Count(); i++)
                            {
                                JObject jObjectData = JObject.Parse(jsonArray[i].ToString());
                                string reference = "", itemCode = "", userName = "";
                                double unitPrice = 0.00, discPrcnt = 0.00, quantity = 0.00, discAmount = 0.00, gross = 0.00, lineTotal = 0.00;
                                foreach (var y in jObjectData)
                                {
                                    if (y.Key.Equals("reference"))
                                    {
                                        reference = y.Value.ToString();
                                    }
                                    else if (y.Key.Equals("item_code"))
                                    {
                                        itemCode = y.Value.ToString();
                                    }
                                    else if (y.Key.Equals("unit_price"))
                                    {
                                        unitPrice = string.IsNullOrEmpty(y.Value.ToString()) ? 0.00 : Convert.ToDouble(y.Value.ToString());
                                    }
                                    else if (y.Key.Equals("discprcnt"))
                                    {
                                        discPrcnt = string.IsNullOrEmpty(y.Value.ToString()) ? 0.00 : Convert.ToDouble(y.Value.ToString());
                                    }
                                    else if (y.Key.Equals("quantity"))
                                    {
                                        quantity = string.IsNullOrEmpty(y.Value.ToString()) ? 0.00 : Convert.ToDouble(y.Value.ToString());
                                    }
                                    else if (y.Key.Equals("disc_amount"))
                                    {
                                        discAmount = string.IsNullOrEmpty(y.Value.ToString()) ? 0.00 : Convert.ToDouble(y.Value.ToString());
                                    }
                                    else if (y.Key.Equals("gross"))
                                    {
                                        gross = string.IsNullOrEmpty(y.Value.ToString()) ? 0.00 : Convert.ToDouble(y.Value.ToString());
                                    }
                                    else if (y.Key.Equals("linetotal"))
                                    {
                                        lineTotal = string.IsNullOrEmpty(y.Value.ToString()) ? 0.00 : Convert.ToDouble(y.Value.ToString());
                                    }
                                    else if (y.Key.Equals("username"))
                                    {
                                        userName = y.Value.ToString();
                                    }
                                }
                                dgvitems.Rows.Add(reference, itemCode, Convert.ToDecimal(string.Format("{0:0.00}", unitPrice)), Convert.ToDecimal(string.Format("{0:0.00}", discPrcnt)), Convert.ToDecimal(string.Format("{0:0.00}", quantity)), Convert.ToDecimal(string.Format("{0:0.00}", discAmount)), Convert.ToDecimal(string.Format("{0:0.00}", gross)), Convert.ToDecimal(string.Format("{0:0.00}", lineTotal)),userName);
                            }
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show(jsonResponse, "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            lblItemsCount.Text = "Count (" + dgvitems.Rows.Count.ToString("N0") + ")";
        }
    }
}
