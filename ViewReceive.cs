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
using Newtonsoft.Json.Linq;

namespace DeliciousPartnerApp
{
    public partial class ViewReceive : Form
    {
        public ViewReceive()
        {
            InitializeComponent();
        }
        public int selectedID = 0;
        public string baseReference = "";
        utility_class utilityc = new utility_class();
        private void ViewReceive_Load(object sender, EventArgs e)
        {
            label1.Text = baseReference;
            loadData();
        }

        public void loadData()
        {
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
                    dgv.Rows.Clear();
                    var client = new RestClient(utilityc.URL);
                    client.Timeout = -1;
                    var request = new RestRequest("/api/inv/trfr/get_receive/by_transfer_id/" + selectedID);
                    request.AddHeader("Authorization", "Bearer " + token);
                    request.Method = Method.GET;

                    var response = client.Execute(request);
                    Console.WriteLine(response.Content);
                    if (response.ErrorMessage == null)
                    {
                        if (response.Content.Substring(0, 1).Equals("{"))
                        {
                            JObject jObjectResponse = JObject.Parse(response.Content);
                            bool isSubmit = false;
                            foreach (var x in jObjectResponse)
                            {
                                if (x.Key.Equals("success"))
                                {
                                    isSubmit = string.IsNullOrEmpty(x.Value.ToString()) ? false : Convert.ToBoolean(x.Value.ToString());
                                    break;
                                }
                            }

                            string msg = "No message response found";
                            foreach (var x in jObjectResponse)
                            {
                                if (x.Key.Equals("message"))
                                {
                                    msg = x.Value.ToString();
                                }
                            }

                            if (isSubmit)
                            {
                                foreach (var x in jObjectResponse)
                                {
                                    if (x.Key.Equals("data"))
                                    {
                                        JArray jsonArray = JArray.Parse(x.Value.ToString());
                                        for (int i = 0; i < jsonArray.Count(); i++)
                                        {
                                            JObject data = JObject.Parse(jsonArray[i].ToString());
                                            string docStatus = "", reference = "";
                                            DateTime dtTransDate = new DateTime();
                                            foreach (var q in data)
                                            {
                                                if (q.Key.Equals("docstatus"))
                                                {
                                                    docStatus = q.Value.ToString() == "O" ? "Open" : q.Value.ToString() == "C" ? "Closed" : "Cancelled";
                                                }
                                                else if (q.Key.Equals("transdate"))
                                                {
                                                    string replaceT = q.Value.ToString().Replace("T", "");
                                                    dtTransDate = Convert.ToDateTime(replaceT);
                                                }
                                                else if (q.Key.Equals("reference"))
                                                {
                                                    reference = q.Value.ToString();
                                                }
                                            }
                                            dgv.Rows.Add(docStatus, dtTransDate.ToString("yyyy-MM-dd HH:mm tt"), reference);

                                        }
                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show(msg, "", MessageBoxButtons.OK, isSubmit ? MessageBoxIcon.Information : MessageBoxIcon.Warning);
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
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            loadData();
        }
    }
}
