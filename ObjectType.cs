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
    public partial class ObjectType : Form
    {
        public ObjectType()
        {
            InitializeComponent();
        }
        utility_class utilityc = new utility_class();
        JObject jObjectResponse = new JObject();
        private void ObjectType_Load(object sender, EventArgs e)
        {
            loadData(); 
        }

        public void loadData()
        {
            dgv.Rows.Clear();
            JObject jObject = new JObject();
            if (jObjectResponse.ToString() != "{}")
            {
                jObject = jObjectResponse;
            }
            else
            {
                jObject = getObjectTypeResponse();
            }
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
                                int id = 0, objType = 0;
                                string description = "", table = "";
                                foreach (var q in data)
                                {
                                    if (q.Key.Equals("id"))
                                    {
                                        id = Convert.ToInt32(q.Value.ToString());
                                    }
                                    else if (q.Key.Equals("objtype"))
                                    {
                                        objType = Convert.ToInt32(q.Value.ToString());
                                    }
                                    else if (q.Key.Equals("description"))
                                    {
                                        auto.Add(q.Value.ToString());
                                        description = q.Value.ToString();
                                    }
                                    else if (q.Key.Equals("table"))
                                    {
                                        table = q.Value.ToString();
                                    }
                                }

                                if (!string.IsNullOrEmpty(txtSearch.Text.ToString().Trim()))
                                {
                                    if (txtSearch.Text.ToString().Trim().ToLower().Contains(description.ToLower()))
                                    {
                                        dgv.Rows.Add(id, objType, description, table);
                                    }
                                }
                                else
                                {
                                    dgv.Rows.Add(id, objType, description, table);
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
                    var request = new RestRequest("/api/objtype/get_all");
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

        private void btnAddObjectType_Click(object sender, EventArgs e)
        {
            AddObjectType addObjType = new AddObjectType();
            addObjType.ShowDialog();
            if (AddObjectType.isSubmit)
            {
                loadData();
            }
        }
    }
}
