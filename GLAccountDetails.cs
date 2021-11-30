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
    public partial class GLAccountDetails : Form
    {
        public GLAccountDetails()
        {
            InitializeComponent();
        }
        public int selectedID = 0;
        utility_class utilityc = new utility_class();
        private void GLAccountDetails_Load(object sender, EventArgs e)
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
                    var request = new RestRequest("/api/glaccount/get_by_id/" + selectedID);
                    request.AddHeader("Authorization", "Bearer " + token);
                    var response = client.Execute(request);
                    JObject jObject = new JObject();
                    jObject = JObject.Parse(response.Content.ToString());
                    lblCode.Text = "";
                    lblDateCreated.Text = "";
                    lblDescription.Text = "";
                    lblAmount.Text = "0.00";
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
                                if (x.Value.ToString() != "{}")
                                {
                                    int id = 0;
                                    double amount = 0.00;
                                    string code = "", description = "";
                                    DateTime dtCreated = new DateTime();
                                    JObject data = JObject.Parse(x.Value.ToString());
                                    foreach (var q in data)
                                    {
                                        if (q.Key.Equals("id"))
                                        {
                                            id = q.Value.ToString() == "" ? 0 : Convert.ToInt32(q.Value.ToString());
                                            auto.Add(q.Value.ToString());
                                        }
                                        else if (q.Key.Equals("code"))
                                        {
                                            code = q.Value.ToString();
                                            auto.Add(q.Value.ToString());
                                        }
                                        else if (q.Key.Equals("description"))
                                        {
                                            description = q.Value.ToString();
                                            auto.Add(q.Value.ToString());
                                        }
                                        else if (q.Key.Equals("amount"))
                                        {
                                            amount = q.Value.ToString() == "" ? 0.00 : Convert.ToDouble(q.Value.ToString());
                                        }
                                        else if (q.Key.Equals("date_created"))
                                        {
                                            string replaceT = q.Value.ToString().Replace("T", "");
                                            dtCreated = Convert.ToDateTime(replaceT);
                                        }
                                    }
                                    lblCode.Text = code;
                                    lblDescription.Text = description;
                                    lblAmount.Text = amount.ToString("n2");
                                    lblDateCreated.Text = dtCreated.ToString("yyyy-MM-dd") + Environment.NewLine + dtCreated.ToString("hh:mm:ss tt");
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
    }
}
