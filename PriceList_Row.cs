using Newtonsoft.Json.Linq;
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
namespace DeliciousPartnerApp
{
    public partial class PriceList_Row : Form
    {
        public PriceList_Row()
        {
            InitializeComponent();
        }
        utility_class utilityc = new utility_class();
        public int selectedID = 0;
        private void PriceList_Row_Load(object sender, EventArgs e)
        {
            dgv.Columns["price"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            loadData();
        }

        public void loadData()
        {
            if (Login.jsonResult != null)
            {
                Cursor.Current = Cursors.WaitCursor;
                AutoCompleteStringCollection auto = new AutoCompleteStringCollection();
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
                    //string branch = "A1-S";
                    var request = new RestRequest("/api/item/price_list/row/get_all/" + selectedID);
                    request.AddHeader("Authorization", "Bearer " + token);
                    var response = client.Execute(request);
                    JObject jObject = new JObject();
                    jObject = JObject.Parse(response.Content.ToString());
                    dgv.Rows.Clear();
                    bool isSuccess = false;
                    foreach (var x in jObject)
                    {
                        if (x.Key.Equals("success"))
                        {
                            isSuccess = Convert.ToBoolean(x.Value.ToString());
                        }
                    }
                    if (isSuccess)
                    {
                        foreach (var x in jObject)
                        {
                            if (x.Key.Equals("data"))
                            {
                                if (x.Value.ToString() != "[]")
                                {
                                    JArray jsonArray = JArray.Parse(x.Value.ToString());
                                    for (int i = 0; i < jsonArray.Count(); i++)
                                    {
                                        JObject data = JObject.Parse(jsonArray[i].ToString());
                                        int id = 0, pricelistID = 0;
                                        string itemCode = "";
                                        double pRice = 0.00;
                                        DateTime dtCreated = new DateTime(),
                                                        dtUpdated = new DateTime();
                                        foreach (var q in data)
                                        {
                                            if (q.Key.Equals("id"))
                                            {
                                                id = Convert.ToInt32(q.Value.ToString());
                                            }
                                            else if (q.Key.Equals("pricelist_id"))
                                            {
                                                pricelistID = Convert.ToInt32(q.Value.ToString());
                                            }
                                            else if (q.Key.Equals("item_code"))
                                            {
                                                itemCode = q.Value.ToString();
                                                auto.Add(q.Value.ToString());
                                            }
                                            else if (q.Key.Equals("price"))
                                            {
                                                pRice = Convert.ToDouble(q.Value.ToString());
                                            }
                                            else if (q.Key.Equals("date_created"))
                                            {
                                                string replaceT = q.Value.ToString().Replace("T", "");
                                                dtCreated = Convert.ToDateTime(replaceT);
                                            }
                                            else if (q.Key.Equals("date_updated"))
                                            {
                                                string replaceT = q.Value.ToString().Replace("T", "");
                                                dtUpdated = Convert.ToDateTime(replaceT);
                                            }
                                        }

                                        if (!string.IsNullOrEmpty(txtSearch.Text.ToString().Trim()))
                                        {
                                            if (txtSearch.Text.ToString().Trim().ToLower().Contains(itemCode.ToLower()))
                                            {
                                                dgv.Rows.Add(id, pricelistID, itemCode, Convert.ToDecimal(string.Format("{0:0.00}", pRice)), dtCreated.ToString("yyyy-MM-dd HH:mm"), dtUpdated.ToString("yyyy-MM-dd HH:mm"));
                                            }
                                        }
                                        else
                                        {
                                            dgv.Rows.Add(id,pricelistID, itemCode, Convert.ToDecimal(string.Format("{0:0.00}", pRice)), dtCreated.ToString("yyyy-MM-dd HH:mm"), dtUpdated.ToString("yyyy-MM-dd HH:mm"));
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        string msg = "No message response found";
                        foreach (var x in jObject)
                        {
                            if (x.Key.Equals("message"))
                            {
                                msg = x.Value.ToString();
                            }
                        }
                        MessageBox.Show(msg, "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                txtSearch.AutoCompleteCustomSource = auto;
                Cursor.Current = Cursors.Default;
            }
        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dgv.Rows.Count > 0)
            {
                if(e.ColumnIndex== 6)
                {
                    if (e.RowIndex >= 0)
                    {
                        PriceList_Items items = new PriceList_Items();
                        items.lblPriceList.Text = lblPriceList.Text;
                        items.selectedID = string.IsNullOrEmpty(dgv.CurrentRow.Cells["id"].Value.ToString()) ? 0 : Convert.ToInt32(dgv.CurrentRow.Cells["id"].Value.ToString());
                        items.ShowDialog();
                        if (PriceList_Items.isSubmit)
                        {
                            loadData();
                        }
                    }
                }
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
    }
}
