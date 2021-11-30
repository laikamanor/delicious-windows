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
using System.Data.SqlClient;
namespace DeliciousPartnerApp
{
    public partial class APIIIIIIII : Form
    {
        public APIIIIIIII()
        {
            InitializeComponent();
        }

        private void APIIIIIIII_Load(object sender, EventArgs e)
        {
            dgv.Rows.Add("ASSA");
            dgv.Rows.Add("ASSA");
            dgv.Rows.Add("ASSA");

            ComboBox CB = new ComboBox();
            CB.Items.Add("A");
            CB.Items.Add("B");
            CB.Items.Add("C");
            CB.Items.Add("D");
            CB.Items.Add("E");
            //((DataGridViewComboBoxColumn)dgv.Columns["cmbAction"]).DataSource = CB.Items;


        }

        private void button1_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            var client = new RestClient("https://quote-garden.herokuapp.com/");
            client.AddDefaultHeader("Content-Type", "application/json");
            client.Timeout = -1;

            var request = new RestRequest("/api/v3/quotes");
            var response = client.Execute(request);
            if (response.ErrorMessage == null)
            {
                if (response.Content.ToString().Substring(0, 1).Equals("{"))
                {
                    JObject jsonResult = JObject.Parse(response.Content.ToString());
                    String msg = "Object message key is empty";
                    //bool isSuccess = false;
                    foreach (var x in jsonResult)
                    {
                        if (x.Key.Equals("message"))
                        {
                            msg = x.Value.ToString();
                        }
                    }
                    string dataResult = "";
                    foreach (var x in jsonResult)
                    {
                        if (x.Key.Equals("data"))
                        {
                            if (x.Value.ToString() != "[]")
                            {
                                JArray jsonArray = JArray.Parse(x.Value.ToString());
                                for (int i = 0; i < jsonArray.Count(); i++)
                                {
                                    JObject jObjectData = JObject.Parse(jsonArray[i].ToString());
                                    string quotesAuthor = "", quotesText = "";
                                    foreach (var y in jObjectData)
                                    {
                                        if (y.Key.Equals("quoteAuthor"))
                                        {
                                            quotesAuthor = y.Value.ToString();
                                        }
                                        else if (y.Key.Equals("quoteText"))
                                        {
                                            quotesText = y.Value.ToString();
                                        }
                                    }
                                    dataResult += "Author: " + quotesAuthor + Environment.NewLine + "'" + quotesText + "'" + Environment.NewLine + Environment.NewLine;
                                }
                            }
                        }
                    }
                    MessageBox.Show(dataResult, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(response.Content.ToString(), "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show(response.ErrorMessage, "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string msg = "";
            //string conString = "Data Source=DESKTOP-K0HGRCE;Network Library=DBMSSOCN;Initial Catalog=db_test;User ID=DESKTOP-K0HGRCE\admin;Password=;";
            string conString = "Server=DESKTOP-K0HGRCE;Database=db_test;Trusted_Connection=True;";
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM tblusers", con);
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                msg += "id: " + rdr["id"].ToString() + Environment.NewLine + "name: " + rdr["name"].ToString() + Environment.NewLine + Environment.NewLine;
            }
            con.Close();
            MessageBox.Show(msg, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dgv_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            //foreach (DataGridViewRow row in dgv.Rows)
            //{
            //    if (row.Cells[0] is DataGridViewComboBoxCell && row.Index == 1)
            //        (row.Cells[0] as DataGridViewComboBoxCell).Items.Add("A");
            //    else
            //        (row.Cells[0] as DataGridViewComboBoxCell).Items.Add("B");
            //}
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv.Rows.Count > 0)
            {
                if (e.ColumnIndex == 1)
                {
                    if(e.RowIndex >= 0)
                    {
                        DataGridViewComboBoxCell combo = this.dgv.CurrentRow.Cells["cmbAction"] as DataGridViewComboBoxCell;
                        if(combo.Items.Count <= 0)
                        {
                            string[] data = { "item A1", "item B1", "item C1" };
                            combo.DataSource = data;
                        }
                    }
                }
            }
        }
    }
}
