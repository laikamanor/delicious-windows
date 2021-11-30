using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DeliciousPartnerApp.API_Class.Notification;
using Newtonsoft.Json.Linq;
namespace DeliciousPartnerApp
{
    public partial class Notification : Form
    {
        public Notification()
        {
            InitializeComponent();
        }
        public int selectedID = 0;
        private async void Notification_Load(object sender, EventArgs e)
        {
            await loadData();
        }

        public async Task loadData()
        {
            notification_class notifc = new notification_class();
            DataTable dt = await notifc.getReadNotifByID(selectedID);
            string header = "", remarks = "", message = "";
            DateTime dtRead = new DateTime();
            foreach (DataRow row in dt.Rows)
            {
                header = row["header"].ToString();
                dtRead = string.IsNullOrEmpty(row["date_read"].ToString()) ? new DateTime() : Convert.ToDateTime(row["date_read"].ToString());
                message = row["message"].ToString();
                remarks = row["remarks"].ToString();
            }
            lblHeader.Text = header;
            lblBody.Text = message;
            lblDateRead.Text = "Date Read: " + dtRead.ToString("yyyy-MM-dd hh:mm:ss tt");
            if (remarks.Substring(0, 1).Equals("["))
            {
                dgv.Rows.Clear();
                JArray jaRemarks = JArray.Parse(remarks);
                for (int i = 0; i < jaRemarks.Count; i++)
                {
                    JObject data = JObject.Parse(jaRemarks[i].ToString());
                    string description = "";
                    DateTime dtCreated = new DateTime();
                    Console.WriteLine(jaRemarks[i].ToString());
                    foreach (var q in data)
                    {
                        Console.WriteLine(q.Key.ToString());
                        if (q.Key.Equals("remarks"))
                        {
                            description = q.Value.ToString();
                        }
                        else if (q.Key.Equals("date_created"))
                        {
                            string replaceT = q.Value.ToString().Replace("T", "");
                            dtCreated = Convert.ToDateTime(replaceT);
                        }
                    }
                    dgv.Rows.Add(description, dtCreated.ToString("yyyy-MM-dd HH:mm:ss"));
                }
            }
        }

        private async void btnDone_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to Mark as Done?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                notification_class notifc = new notification_class();
                string msgDone = "";
                msgDone = await notifc.markAsRead(selectedID);
                MessageBox.Show(msgDone, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        private async void btnAadd_Click(object sender, EventArgs e)
        {
            Remarks.isSubmit = false;
            Remarks rem = new Remarks();
            rem.ShowDialog();
            if (Remarks.isSubmit)
            {
                string value = Remarks.rem;
                notification_class notifc = new notification_class();
                string msg = await notifc.addRemarks(selectedID, value);
                MessageBox.Show(msg, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await loadData();
            }
        }
    }
}
