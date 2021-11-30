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

namespace DeliciousPartnerApp
{
    public partial class Customers : Form
    {
        DeliciousPartnerApp.UI_Class.utility_class utilityc = new DeliciousPartnerApp.UI_Class.utility_class();
        public Customers()
        {
            InitializeComponent();
        }

        private void Customers_Load(object sender, EventArgs e)
        {
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
                    var request = new RestRequest("/api/customer/get_all");
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
                                        int id = 0;
                                        string _code = "", name = "", custType = "";
                                        foreach (var q in data)
                                        {
                                            if (q.Key.Equals("id"))
                                            {
                                                id = Convert.ToInt32(q.Value.ToString());
                                            }
                                            else if (q.Key.Equals("code"))
                                            {
                                                _code = q.Value.ToString();
                                                auto.Add(q.Value.ToString());
                                            }
                                            else if (q.Key.Equals("name"))
                                            {
                                                name = q.Value.ToString();
                                            }
                                            else if (q.Key.Equals("cust_type"))
                                            {
                                                custType = q.Value.ToString();
                                            }
                                        }

                                        if (!string.IsNullOrEmpty(txtSearch.Text.ToString().Trim()))
                                        {
                                            if (txtSearch.Text.ToString().Trim().ToLower().Contains(_code.ToLower()))
                                            {

                                                dgv.Rows.Add(id, _code, name,custType);
                                                return;
                                            }
                                        }
                                        else
                                        {
                                            dgv.Rows.Add(id, _code, name, custType);
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

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            AddCustomer addCustomer = new AddCustomer("Add");
            addCustomer.ShowDialog();
            if (AddCustomer.isSubmit)
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

        private void dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (dgv.Rows.Count > 0)
            //{
            //    if (e.RowIndex >= 0)
            //    {
            //        if (e.ColumnIndex == 3)
            //        {
            //            AddCustomer add = new AddCustomer("Edit");
            //            add.ShowDialog();
            //        }
            //    }
            //}
        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv.Rows.Count > 0)
            {
                if (e.RowIndex >= 0)
                {
                    if (e.ColumnIndex == 4)
                    {
                        editCustomer frm = new editCustomer();
                        frm.custType = Convert.ToInt32(dgv.CurrentRow.Cells["cust_type"].Value.ToString());
                        frm.lblID.Text = dgv.CurrentRow.Cells["id"].Value.ToString();
                        frm.txtCustCode.Text = dgv.CurrentRow.Cells["code"].Value.ToString();
                        frm.txtCustName.Text = dgv.CurrentRow.Cells["name"].Value.ToString();
                        frm.ShowDialog();
                    }
                }
            }
        }
    }
}
