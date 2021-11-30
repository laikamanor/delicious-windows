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
using DeliciousPartnerApp.API_Class.Warehouse;
namespace DeliciousPartnerApp
{
    public partial class AddSeries : Form
    {
        public AddSeries()
        {
            InitializeComponent();
        }
        DataTable dtObjType = new DataTable();
        DataTable dtWarehouses = new DataTable();
        utility_class utilityc = new utility_class();
        warehouse_class warehousec = new warehouse_class();
        public static bool isSubmit = false;
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCode.Text.Trim()))
            {
                MessageBox.Show("Code field is required", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCode.Focus();
            }
            else if (string.IsNullOrEmpty(txtName.Text.Trim()))
            {
                MessageBox.Show("Name field is required", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
            }
            else if (string.IsNullOrEmpty(cmbWhse.Text.Trim()))
            {
                MessageBox.Show("Name field is required", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbWhse.Focus();
            }
            else if (string.IsNullOrEmpty(cmbObjType.Text.Trim()))
            {
                MessageBox.Show("Obj. Type field is required", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbObjType.Focus();
            }
            else if (string.IsNullOrEmpty(txtStart.Text.Trim()))
            {
                MessageBox.Show("Start Num field is required", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtStart.Focus();
            }
            else if (string.IsNullOrEmpty(txtNext.Text.Trim()))
            {
                MessageBox.Show("Next Num field is required", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
            }
            else if (string.IsNullOrEmpty(txtEnd.Text.Trim()))
            {
                MessageBox.Show("End Num field is required", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEnd.Focus();
            }
            else
            {
                insertSeries();
            }
        }

        public async 
        Task
loadWarehouses()
        {
            dtWarehouses = new DataTable();
            dtWarehouses = await Task.Run(() => warehousec.returnWarehouse("", ""));
            if (dtWarehouses.Rows.Count > 0)
            {
                cmbWhse.Items.Clear();
                foreach (DataRow row in dtWarehouses.Rows)
                {
                    cmbWhse.Items.Add(row["whsename"].ToString());
                }
            }
        }

        public void insertSeries()
        {
            if (Login.jsonResult != null)
            {
                Cursor.Current = Cursors.WaitCursor;
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
                    int selectedObjID = 0;
                    foreach(DataRow row in dtObjType.Rows)
                    {
                        if(row["description"].ToString() == cmbObjType.Text)
                        {
                            selectedObjID = Convert.ToInt32(row["objtype"].ToString());
                        }
                    }
                    string whseCode = "";
                    foreach (DataRow row in dtWarehouses.Rows)
                    {
                        if (row["whsename"].ToString() == cmbWhse.Text)
                        {
                            whseCode = row["whsecode"].ToString();
                        }
                    }

                    var client = new RestClient(utilityc.URL);
                    client.Timeout = -1;
                    //string branch = (cmbBranch.Text.Equals("") || cmbBranch.Text == "All" ? "" : cmbBranch.Text);
                    var request = new RestRequest("/api/series/new");
                    Console.WriteLine("/api/item/new");
                    request.AddHeader("Authorization", "Bearer " + token);
                    request.Method = Method.POST;
                    JObject jObject = new JObject();
                    jObject.Add("code", (txtCode.Text == String.Empty ? null : txtCode.Text));
                    jObject.Add("name", (txtName.Text == String.Empty ? null : txtName.Text));
                    jObject.Add("whsecode", whseCode) ;
                    if (selectedObjID <= 0)
                    {
                        jObject.Add("objtype", null);
                    }
                    else
                    {
                        jObject.Add("objtype", selectedObjID);
                    }

                    if (string.IsNullOrEmpty(txtStart.Text.Trim()))
                    {
                        jObject.Add("start_num", null);
                    }
                    else
                    {
                        jObject.Add("start_num", Convert.ToInt32(txtStart.Text));
                    }

                    if (string.IsNullOrEmpty(txtNext.Text.Trim()))
                    {
                        jObject.Add("next_num", null);
                    }
                    else
                    {
                        jObject.Add("next_num", Convert.ToInt32(txtNext.Text));
                    }

                    if (string.IsNullOrEmpty(txtEnd.Text.Trim()))
                    {
                        jObject.Add("end_num", null);
                    }
                    else
                    {
                        jObject.Add("end_num", Convert.ToInt32(txtEnd.Text));
                    }
                    Console.WriteLine(jObject);
                    request.AddParameter("application/json", jObject, ParameterType.RequestBody);
                    var response = client.Execute(request);
                    jObject = JObject.Parse(response.Content.ToString());
                    Console.WriteLine(response.Content.ToString());
                    bool isSuccess = false;

                    string msg = "No message response found";
                    foreach (var x in jObject)
                    {
                        if (x.Key.Equals("message"))
                        {
                            msg = x.Value.ToString();
                        }
                        else if (x.Key.Equals("success"))
                        {
                            isSuccess = Convert.ToBoolean(x.Value.ToString());
                        }
                    }

                    if (!isSuccess)
                    {
                        if (msg.Equals("Token is invalid"))
                        {
                            MessageBox.Show("Your login session is expired. Please login again", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {
                            MessageBox.Show(msg, "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        foreach (var x in jObject)
                        {
                            if (x.Key.Equals("success"))
                            {
                                isSuccess = Convert.ToBoolean(x.Value.ToString());
                                isSubmit = true;
                                MessageBox.Show(msg, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Dispose();
                            }
                        }
                    }
                    Cursor.Current = Cursors.Default;
                }
            }
        }

        private async void AddSeries_Load(object sender, EventArgs e)
        {
            isSubmit = false;
            dtObjType = new DataTable();
            dtObjType.Columns.Add("id");
            dtObjType.Columns.Add("objtype");
            dtObjType.Columns.Add("description");
            dtObjType.Columns.Add("table");
            dtObjType.Rows.Clear();
            loadObjTypes();
            await loadWarehouses();
        }

        public void loadObjTypes()
        {
            if (Login.jsonResult != null)
            {
                Cursor.Current = Cursors.WaitCursor;
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
                    var request = new RestRequest("/api/objtype/get_all");
                    request.AddHeader("Authorization", "Bearer " + token);
                    var response = client.Execute(request);
                    JObject jObject = new JObject();
                    jObject = JObject.Parse(response.Content.ToString());
                    cmbObjType.Items.Clear();
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
                                        int id = 0, objtype = 0;
                                        string description = "", table = "";
                                        foreach (var q in data)
                                        {
                                            if (q.Key.Equals("id"))
                                            {
                                                id = Convert.ToInt32(q.Value.ToString());
                                            }
                                            else if (q.Key.Equals("objtype"))
                                            {
                                                objtype = Convert.ToInt32(q.Value.ToString());
                                            }
                                            else if (q.Key.Equals("description"))
                                            {
                                                description = q.Value.ToString();
                                            }
                                            else if (q.Key.Equals("table"))
                                            {
                                                table = q.Value.ToString();
                                            }
                                        }
                                        dtObjType.Rows.Add(id, objtype, description, table);
                                        cmbObjType.Items.Add(description);
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
                Cursor.Current = Cursors.Default;
            }
        }

        private void txtStart_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void cmbObjType_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = 0, intTemp = 0;
            foreach(DataRow row in dtObjType.Rows)
            {
                if(row["description"].ToString() == cmbObjType.Text)
                {
                    id = Int32.TryParse(row["id"].ToString(), out intTemp) ? Convert.ToInt32(row["id"].ToString()) : intTemp;
                }
            }
            MessageBox.Show(id.ToString());
        }
    }
}
