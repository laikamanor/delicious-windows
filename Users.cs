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
using DeliciousPartnerApp.API_Class.Branch;
namespace DeliciousPartnerApp
{
    public partial class Users : Form
    {
        UI_Class.utility_class utilityc = new utility_class();
        branch_class branchc = new branch_class();
        DataTable dtBranch = new DataTable();
        int cBranch = 1;
        public Users()
        {
            InitializeComponent();
        }

        private async void Users_Load(object sender, EventArgs e)
        {
            await loadBranch();
            loadData();
            cBranch = 0;
        }

        public async 
        Task
loadBranch()
        {
            int isAdmin = 0;
            string branch = "";
            dtBranch = await Task.Run(() => branchc.returnBranches());
            cmbBranch.Invoke(new Action(delegate ()
            {
                cmbBranch.Items.Clear();
            }));
            if (Login.jsonResult != null)
            {
                foreach (var x in Login.jsonResult)
                {
                    if (x.Key.Equals("data"))
                    {
                        JObject jObjectData = JObject.Parse(x.Value.ToString());
                        foreach (var y in jObjectData)
                        {
                            if (y.Key.Equals("branch"))
                            {
                                branch = y.Value.ToString();
                            }
                            else if (y.Key.Equals("isAdmin"))
                            {

                                if (y.Value.ToString().ToLower() == "false" || y.Value.ToString() == "")
                                {
                                    foreach (DataRow row in dtBranch.Rows)
                                    {
                                        if (row["code"].ToString() == branch)
                                        {
                                            cmbBranch.Invoke(new Action(delegate ()
                                            {
                                                cmbBranch.Items.Add(row["name"].ToString());
                                                if (cmbBranch.Items.Count > 0)
                                                {
                                                    cmbBranch.SelectedIndex = 0;
                                                }
                                            }));
                                            return;
                                        }
                                    }
                                }
                                else
                                {
                                    isAdmin += 1;
                                    break;
                                }
                            }
                            else if (y.Key.Equals("isAccounting"))
                            {
                                if (y.Value.ToString().ToLower() == "false" || y.Value.ToString() == "")
                                {
                                    foreach (DataRow row in dtBranch.Rows)
                                    {
                                        if (row["code"].ToString() == branch && isAdmin <= 0)
                                        {
                                            cmbBranch.Invoke(new Action(delegate ()
                                            {
                                                cmbBranch.Items.Add(row["name"].ToString());
                                            }));
                                            break;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                cmbBranch.Invoke(new Action(delegate ()
                {
                    if (cmbBranch.Items.Count <= 0)
                    {
                        foreach (DataRow row in dtBranch.Rows)
                        {
                            cmbBranch.Items.Add(row["name"]);
                        }
                    }
                }));
            }
            cmbBranch.Invoke(new Action(delegate ()
            {
                if (cmbBranch.Items.Count > 0)
                {
                    string branchName = "";
                    foreach (DataRow row in dtBranch.Rows)
                    {
                        if (row["code"].ToString() == branch)
                        {
                            branchName = row["name"].ToString();
                            break;
                        }
                        else
                        {
                            cmbBranch.SelectedIndex = 0;
                        }
                    }
                    cmbBranch.SelectedIndex = cmbBranch.Items.IndexOf(branchName);
                }
            }));
            await Task.Delay(2000);
        }


        public string findBranchCode(string value)
        {
            string result = "";
            foreach (DataRow row in dtBranch.Rows)
            {
                if (row["name"].ToString() == value)
                {
                    result = row["code"].ToString();
                    break;
                }
            }
            return result;
        }

        public async void loadData()
        {
            try
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
                        string branchValue = "", search = "";
                        cmbBranch.Invoke(new Action(delegate ()
                        {
                            branchValue = cmbBranch.Text;
                        }));
                        txtSearch.Invoke(new Action(delegate ()
                        {
                            search = txtSearch.Text.ToString().Trim();
                        }));
                        string branch = (branchValue.Equals("") || branchValue == "All" ? "" : findBranchCode(branchValue));
                        //string branch = "A1-S";
                        var request = new RestRequest("/api/auth/user/get_all?branch=" + branch + "&search=" + search);
                        Console.WriteLine("/api/auth/user/get_all?branch=" + branch + "&search=" + search);
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
                                                if (q.Key.Equals("username"))
                                                {
                                                    userName = q.Value.ToString();
                                                    auto.Add(q.Value.ToString());
                                                }
                                                else if (q.Key.Equals("fullname"))
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
            catch
            {

            }
        }

        private async void btnAddUser_Click(object sender, EventArgs e)
        {
            AddUser addUser = new AddUser();
            addUser.Text = "Add User";
            addUser.ShowDialog();
            if (AddUser.isSubmit)
            {
                await Task.Run(() => loadData());
            }
        }

        private async void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dgv.Rows.Count > 0)
            {
                if (e.ColumnIndex == 3)
                {
                    AddUser addUser = new AddUser();
                    addUser.userID = Convert.ToInt32(dgv.CurrentRow.Cells["id"].Value.ToString());
                    addUser.Text = "Edit User";
                    addUser.ShowDialog();
                    if (AddUser.isSubmit)
                    {
                        await Task.Run(() => loadData());
                    }
                }
            }
        }

        private async void cmbBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cBranch <= 0)
            {
                await Task.Run(() => loadData());
            }
        }

        private async void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                await Task.Run(() => loadData());
            }
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            await Task.Run(() => loadData());
        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
