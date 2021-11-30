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
    public partial class UOMGroup : Form
    {
        public UOMGroup()
        {
            InitializeComponent();
        }
        utility_class utilityc = new utility_class();
        private void UOMGroup_Load(object sender, EventArgs e)
        {
            dgv.Columns["base_qty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
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
                    var request = new RestRequest("/api/uom_grp/get_all");
                    request.AddHeader("Authorization", "Bearer " + token);
                    var response = client.Execute(request);
                    Console.WriteLine(response.Content);
                    if (response.ErrorMessage == null)
                    {
                        if (response.Content.Substring(0, 1).Equals("{"))
                        {
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
                                                int id = 0;
                                                double baseQty = 0.00;
                                                string code = "", name = "", baseUom = "";
                                                foreach (var q in data)
                                                {
                                                    if (q.Key.Equals("id"))
                                                    {
                                                        id = Convert.ToInt32(q.Value.ToString());
                                                    }
                                                    else if (q.Key.Equals("code"))
                                                    {
                                                        code = q.Value.ToString();
                                                        auto.Add(q.Value.ToString());
                                                    }
                                                    else if (q.Key.Equals("name"))
                                                    {
                                                        name = q.Value.ToString();
                                                    }
                                                    else if (q.Key.Equals("base_qty"))
                                                    {
                                                        baseQty = string.IsNullOrEmpty(q.Value.ToString()) ? 0.00 : Convert.ToDouble(q.Value.ToString());
                                                    }
                                                    else if (q.Key.Equals("base_uom"))
                                                    {
                                                        baseUom = q.Value.ToString();
                                                    }
                                                }

                                                if (!string.IsNullOrEmpty(txtSearch.Text.ToString().Trim()))
                                                {
                                                    if (txtSearch.Text.ToString().Trim().ToLower().Contains(code.ToLower()))
                                                    {
                                                        dgv.Rows.Add(id, code, name, Convert.ToDecimal(string.Format("{0:0.00}", baseQty)), baseUom);
                                                    }
                                                }
                                                else
                                                {
                                                    dgv.Rows.Add(id, code, name, Convert.ToDecimal(string.Format("{0:0.00}", baseQty)), baseUom);
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
                        else
                        {
                            MessageBox.Show(response.Content, "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show(response.ErrorMessage, "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                txtSearch.AutoCompleteCustomSource = auto;
                Cursor.Current = Cursors.Default;
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
                if(e.ColumnIndex== 1)
                {
                    if(e.RowIndex >= 0)
                    {
                        AltUOM frm = new AltUOM();
                        frm.baseUom = dgv.CurrentRow.Cells["base_uom"].Value.ToString();
                        frm.selectedID = string.IsNullOrEmpty(dgv.CurrentRow.Cells["id"].Value.ToString()) ? 0 : Convert.ToInt32(dgv.CurrentRow.Cells["id"].Value.ToString());
                        frm.ShowDialog();
                    }
                }
            }
        }

        private void btnAddUomGroup_Click(object sender, EventArgs e)
        {
            AddUOMGroup frm = new AddUOMGroup();
            frm.ShowDialog();
            if (AddUOMGroup.isSubmit)
            {
                loadData();
            }
        }
    }
}
