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
    public partial class Branches : Form
    {
        utility_class utilityc = new utility_class();
        public Branches()
        {
            InitializeComponent();
        }
        private async void Branch_Load(object sender, EventArgs e)
        {
            await Task.Run(() => loadData());
        }

        public async void loadData()
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
                    var request = new RestRequest("/api/branch/get_all");
                    request.AddHeader("Authorization", "Bearer " + token);
                    Task<IRestResponse> t = client.ExecuteAsync(request);
                    t.Wait();
                    var response = await t;
                    JObject jObject = new JObject();
                    jObject = JObject.Parse(response.Content.ToString());
                    dgv.Invoke(new Action(delegate ()
                    {
                        dgv.Rows.Clear();
                    }));
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
                                        string userName = "",
            fullName = "";
                                        foreach (var q in data)
                                        {
                                            if (q.Key.Equals("code"))
                                            {
                                                userName = q.Value.ToString();
                                                auto.Add(q.Value.ToString());
                                            }
                                            else if (q.Key.Equals("name"))
                                            {
                                                fullName = q.Value.ToString();
                                            }
                                            else if (q.Key.Equals("id"))
                                            {
                                                id = Convert.ToInt32(q.Value.ToString());
                                            }
                                        }

                                        txtSearch.Invoke(new Action(delegate ()
                                        {
                                            if (!string.IsNullOrEmpty(txtSearch.Text.ToString().Trim()))
                                            {
                                                if (txtSearch.Text.ToString().Trim().ToLower().Contains(userName.ToLower()))
                                                {
                                                    dgv.Invoke(new Action(delegate ()
                                                    {
                                                        dgv.Rows.Add(id, userName, fullName);
                                                    }));
                                                }
                                            }
                                            else
                                            {
                                                dgv.Invoke(new Action(delegate ()
                                                {
                                                    dgv.Rows.Add(id, userName, fullName);
                                                }));
                                            }
                                        }));
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
                txtSearch.Invoke(new Action(delegate ()
                {
                    txtSearch.AutoCompleteCustomSource = auto;
                }));
                Cursor.Current = Cursors.Default;
            }
        }

        private async void btnAddUser_Click(object sender, EventArgs e)
        {
            AddBranch frm = new AddBranch();
            frm.ShowDialog();
            if (AddBranch.isSubmit)
            {
                await Task.Run(() => loadData());
            }
        }

        private async void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv.Rows.Count > 0)
            {
                if (e.ColumnIndex == 3)
                {
                    EditBranch editBranch = new EditBranch();
                    editBranch.selectedID = Convert.ToInt32(dgv.CurrentRow.Cells["id"].Value.ToString());
                    editBranch.selectedCode = dgv.CurrentRow.Cells["code"].Value.ToString();
                    editBranch.selectedName = dgv.CurrentRow.Cells["namee"].Value.ToString();
                    editBranch.ShowDialog();
                    if (EditBranch.isSubmit)
                    {
                        await Task.Run(() => loadData());
                    }
                }
                else if (e.ColumnIndex == 4)
                {
                    DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialogResult == DialogResult.Yes)
                    {
                        int id = Convert.ToInt32(dgv.CurrentRow.Cells["id"].Value.ToString());
                        await Task.Run(() => deleteBranch(id));
                    }
                }
            }
        }

        public async void deleteBranch(int id)
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
                    var request = new RestRequest("/api/branch/delete/" + id);
                    request.AddHeader("Authorization", "Bearer " + token);
                    request.Method = Method.DELETE;
                    Task<IRestResponse> t = client.ExecuteAsync(request);
                    t.Wait();
                    var response = await t;
                    JObject jObject = JObject.Parse(response.Content.ToString());
                    bool isSuccess = false;

                    string msg = "No message response found";
                    foreach (var x in jObject)
                    {
                        if (x.Key.Equals("message"))
                        {
                            msg = x.Value.ToString();
                        }
                    }

                    foreach (var x in jObject)
                    {
                        if (x.Key.Equals("success"))
                        {
                            isSuccess = Convert.ToBoolean(x.Value.ToString());
                            MessageBox.Show(msg, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            dgv.Invoke(new Action(delegate ()
                            {
                                dgv.Rows.RemoveAt(dgv.CurrentRow.Index);            
                            }));
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
                    Cursor.Current = Cursors.Default;
                }
            }
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            await Task.Run(() => loadData());
        }

        private async void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                await Task.Run(() => loadData());
            }
        }

        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            await Task.Run(() => loadData());
        }
    }
}
