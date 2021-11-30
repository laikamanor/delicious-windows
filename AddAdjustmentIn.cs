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
    public partial class AddAdjustmentIn : Form
    {
        string gAdjType = "";
        public AddAdjustmentIn(string adjType)
        {
            gAdjType = adjType;
            InitializeComponent();
        }
        utility_class utilityc = new utility_class();
        JObject jObjectResponse = new JObject();
        DataTable dtItems;
        public static DataTable dtSelectedItems;
        public DataTable dtSelectedItems2 = new DataTable();
        private void btnDone_Click(object sender, EventArgs e)
        {
            if (dtSelectedItems.Rows.Count > 0)
            {
                this.Hide();
                SelectedItem selectedItem = new SelectedItem(gAdjType);
                selectedItem.dtSelectedItems = dtSelectedItems;
                selectedItem.ShowDialog();
            }
            else
            {
                MessageBox.Show("No data selected", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            ItemInfo itemInfo = new ItemInfo();
            itemInfo.ShowDialog();
        }

        private void AddAdjustmentIn_Load(object sender, EventArgs e)
        {
            dtSelectedItems = new DataTable();
            dtSelectedItems.Columns.Add("item_code");
            dtSelectedItems.Columns.Add("quantity");
            dtSelectedItems.Columns.Add("uom");
            dtSelectedItems.Rows.Clear();
            if(dtSelectedItems2.Rows.Count > 0)
            {
                dtSelectedItems = dtSelectedItems2;
            }
            loadData();
        }

        public void loadData()
        {
            Cursor.Current = Cursors.WaitCursor;
            dtItems = new DataTable();
            dtItems.Columns.Add("id");
            dtItems.Columns.Add("item_code");
            dtItems.Columns.Add("uom");
            dtItems.Rows.Clear();
            JObject jObject = new JObject();
            if (jObjectResponse.ToString() != "{}")
            {
                jObject = jObjectResponse;
            }
            else
            {
                jObject = getItems();
            }

            flowLayoutPanel1.Controls.Clear();
            AutoCompleteStringCollection auto = new AutoCompleteStringCollection();
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
                                int id = 0;
                                string itemCode = "", uom = "";
                                foreach (var q in data)
                                {
                                    if (q.Key.Equals("item_code"))
                                    {
                                        itemCode = q.Value.ToString();
                                        auto.Add(q.Value.ToString());
                                    }
                                    else if (q.Key.Equals("uom"))
                                    {
                                        uom = q.Value.ToString();
                                    }
                                    else if (q.Key.Equals("id"))
                                    {
                                        id = Convert.ToInt32(q.Value.ToString());
                                    }
                                }
                                dtItems.Rows.Add(id,itemCode,uom);
                            }
                            txtSearch.AutoCompleteCustomSource = auto;
                            this.Refresh();
                        }
                    }
                }
                if(dtItems.Rows.Count > 0)
                {
                    foreach(DataRow row in dtItems.Rows)
                    {
                        string itemCode = row["item_code"].ToString();
                        string uom = row["uom"].ToString();

                        if (!string.IsNullOrEmpty(txtSearch.Text.ToString().Trim()))
                        {
                            if (txtSearch.Text.ToString().Trim().Contains(itemCode))
                            {
                                uiItems(itemCode, uom);
                            }
                        }
                        else
                        {
                            uiItems(itemCode, uom);
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
            Cursor.Current = Cursors.Default;
        }

        public void uiItems(string itemCode, string uom)
        {
            JObject jObjectData = new JObject();
            jObjectData.Add("item_code", itemCode);
            jObjectData.Add("uom", uom);
            Panel panel = new Panel();
            panel.Name = "panel" + itemCode.Replace(" ", "");
            panel.Tag = jObjectData;
            panel.Size = new Size(155, 166);
            panel.BackColor = Color.WhiteSmoke;
            Label labelItem = new Label();
            labelItem.AutoSize = false;
            labelItem.Text = itemCode;
            labelItem.Name = "item" + itemCode.Replace(" ", "");
            labelItem.Tag = jObjectData;
            labelItem.Location = new Point(13, 13);
            labelItem.Size = new Size(130, 143);
            labelItem.ForeColor = Color.Black;
            labelItem.Font = new Font("Arial", 15, FontStyle.Bold);
            panel.Click += new EventHandler(panelnfo_click);
            labelItem.Click += new EventHandler(labelnfo_click);

            panel.Controls.Add(labelItem);
            flowLayoutPanel1.Controls.Add(panel);

            if (dtSelectedItems.Rows.Count > 0)
            {
                foreach (DataRow row in dtSelectedItems.Rows)
                {
                    if (itemCode.Equals(row["item_code"].ToString()))
                    {
                        Panel panelItem = (Panel)this.Controls.Find("panel" + itemCode.Replace(" ", ""), true).FirstOrDefault();
                        panelItem.BackColor = Color.Red;
                        Label label = (Label)this.Controls.Find("item" + itemCode.Replace(" ", ""), true).FirstOrDefault();
                        label.BackColor = Color.Red;
                        label.ForeColor = Color.White;
                    }
                }
            }
        }

        private void labelnfo_click(object sender, EventArgs e)
        {
            Label label = sender as Label;
            JObject jObject = JObject.Parse(label.Tag.ToString());
            gotoInformation(jObject);
        }

        private void panelnfo_click(object sender, EventArgs e)
        {
            Panel panel = sender as Panel;
            JObject jObject = JObject.Parse(panel.Tag.ToString());
            gotoInformation(jObject);
        }

        public void gotoInformation(JObject jObject)
        {


            string itemCode = "", uom = "";
            foreach (var x in jObject)
            {
                if (x.Key.Equals("item_code"))
                {
                    itemCode = x.Value.ToString();
                }
                else if (x.Key.Equals("uom"))
                {
                    uom = x.Value.ToString();
                }
            }

            bool isNotExist = false;
            foreach (DataRow row in dtSelectedItems.Rows)
            {
                if (row["item_code"].ToString() == itemCode)
                {
                    isNotExist = true;
                    break;
                }
            }

            if (!isNotExist)
            {
                ItemInfo itemInfo = new ItemInfo();
                itemInfo.itemCode = itemCode;
                itemInfo.uom = uom;
                itemInfo.ShowDialog();
                if (ItemInfo.isSubmit)
                {
                    //MessageBox.Show(ItemInfo.isSubmit.ToString());
                    Panel panel = (Panel)this.Controls.Find("panel" + itemCode.Replace(" ", ""), true).FirstOrDefault();
                    panel.BackColor = Color.Red;
                    Label label = (Label)this.Controls.Find("item" + itemCode.Replace(" ", ""), true).FirstOrDefault();
                    label.BackColor = Color.Red;
                    label.ForeColor = Color.White;
                }
            }
            else
            {
                MessageBox.Show(itemCode + " is already selected", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public JObject getItems()
        {
            JObject jObject = new JObject();
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
                    //string branch = "A1-S";
                    string sURL = gAdjType.Equals("in") ? "/api/item/getall" : "/api/inv/whseinv/getall";
                    var request = new RestRequest(sURL);
                    request.AddHeader("Authorization", "Bearer " + token);
                    var response = client.Execute(request);
                    if (response.Content.ToString().Substring(0, 1).Equals("{"))
                    {
                        jObject = JObject.Parse(response.Content.ToString());
                    }
                    else
                    {
                        MessageBox.Show(response.Content.ToString(), "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    jObjectResponse = jObject;
                }
            }
            return jObject;
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
