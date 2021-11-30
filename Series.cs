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
    public partial class Series : Form
    {
        public Series()
        {
            InitializeComponent();
        }
        utility_class utilityc = new utility_class();
        private void Series_Load(object sender, EventArgs e)
        {
            loadData();
        }

        public void loadData()
        {
            dgv.Rows.Clear();
            JObject jObject = new JObject();
            jObject = getObjectTypeResponse();
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
                                int id = 0, objType = 0, startNum = 0, nextNum = 0, endNum = 0;
                                string code = "", name = "";
                                foreach (var q in data)
                                {
                                    if (q.Key.Equals("id"))
                                    {
                                        id = Convert.ToInt32(q.Value.ToString());
                                    }
                                    else if (q.Key.Equals("code"))
                                    {
                                        auto.Add(q.Value.ToString());
                                        code = q.Value.ToString();
                                    }
                                    else if (q.Key.Equals("name"))
                                    {
                                        name = q.Value.ToString();
                                    }
                                    else if (q.Key.Equals("objtype"))
                                    {
                                        objType = Convert.ToInt32(q.Value.ToString());
                                    }
                                    else if (q.Key.Equals("start_num"))
                                    {
                                        startNum = Convert.ToInt32(q.Value.ToString());
                                    }
                                    else if (q.Key.Equals("next_num"))
                                    {
                                        nextNum = Convert.ToInt32(q.Value.ToString());
                                    }
                                    else if (q.Key.Equals("end_num"))
                                    {
                                        endNum = Convert.ToInt32(q.Value.ToString());
                                    }
                                }

                                if (!string.IsNullOrEmpty(txtSearch.Text.ToString().Trim()))
                                {
                                    if (txtSearch.Text.ToString().Trim().ToLower().Contains(code.ToLower()))
                                    {
                                        dgv.Rows.Add(id, code,name, objType, startNum,nextNum,endNum);
                                        return;
                                    }
                                }
                                else
                                {
                                    dgv.Rows.Add(id, code, name, objType, startNum, nextNum, endNum);
                                }
                            }
                        }
                    }
                }
                txtSearch.AutoCompleteCustomSource = auto;
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

        public JObject getObjectTypeResponse()
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
                    var request = new RestRequest("/api/series/get_all");
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddSeries add = new AddSeries();
            add.ShowDialog();
            if (AddSeries.isSubmit)
            {
                loadData();
            }
        }
    }
}
