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
using RestSharp;
using Newtonsoft.Json.Linq;
using DeliciousPartnerApp.UI_Class;
using DeliciousPartnerApp.API_Class.Notification;
namespace DeliciousPartnerApp
{
    public partial class NotificationBar : Form
    {
        public NotificationBar()
        {
            InitializeComponent();
        }
        utility_class utilityc = new utility_class();
        public static int selectedID = 0;
        private async void Notification_Load(object sender, EventArgs e)
        {
            selectedID = 0;
            Cursor.Current = Cursors.WaitCursor;
            lblTitle.Text = "NOTIFICATION (Loading...)";
            panelBody.Controls.Clear();
            notification_class notifc = new notification_class();
            DataTable dtUnread = await Task.Run(() => notifc.getUnreadNotif("","","","",0));
            loopDt(dtUnread);
        }


        public void loopDt(DataTable dtUnread)
        {
            int y = 3, count = 0;
            foreach (DataRow row in dtUnread.Rows)
            {
                string code = row["code"].ToString();
                int id = string.IsNullOrEmpty(row["id"].ToString().Trim()) ? 0 : Convert.ToInt32(row["id"].ToString());
                if (id > 0)
                {
                    count = string.IsNullOrEmpty(row["count"].ToString().Trim()) ? 0 : Convert.ToInt32(row["count"].ToString());
                    DateTime dtCreated = string.IsNullOrEmpty(row["date_created"].ToString().Trim()) ? new DateTime() : Convert.ToDateTime(row["date_created"].ToString());
                    string displayDateCreated = computeDate(dtCreated);
                    string readBy = row["read_by"].ToString();
                    Panel pn = loadUI(id, code, y, displayDateCreated, readBy);
                    panelBody.Controls.Add(pn);
                    y += 112;
                }
                else
                {
                    Console.WriteLine("code: " + code + "/" + id);
                }
            }
            lblTitle.Text = "NOTIFICATION (" + count.ToString("N0") + ")";
            Cursor.Current = Cursors.Default;
        }

        public string computeDate(DateTime dt)
        {
            string result = "";
            TimeSpan span = DateTime.Now.Subtract(dt);
            if (span.Days >= 1)
            {
                bool isLeapYearNow = DateTime.IsLeapYear(DateTime.Now.Year);
                int oneYearTotalDaysNow = 0;
                if (isLeapYearNow)
                {
                    oneYearTotalDaysNow = 366;
                }
                else
                {
                    oneYearTotalDaysNow = 365;
                }
                if (oneYearTotalDaysNow <= span.Days)
                {
                    result = (span.Days / oneYearTotalDaysNow) + (span.Days == oneYearTotalDaysNow ? " year" : " years") + " ago";
                }
                else
                {
                    result = span.Days + (span.Days == 1 ? " day" : " days") + " ago";
                }
            }
            else if (span.Hours >= 1)
            {
                result = span.Hours + (span.Hours == 1 ? " hour" : " hours") + " ago";
            }
            else if (span.Minutes >= 1)
            {
                result = span.Minutes + (span.Minutes == 1 ? " minute" : " minutes") + " ago";
            }
            else if (span.Seconds >= 1)
            {
                result = span.Seconds + (span.Seconds == 1 ? " second" : " seconds") + " ago";
            }
            else
            {
                result = span.Milliseconds + (span.Milliseconds <= 1 ? " milisecond" : " miliseconds") + " ago";
            }
            return result;
        }

        public Panel loadUI(int id,string description, int panelY, string dateCreated, string readBy)
        {
            Panel panel = new Panel();
            panel.Cursor = Cursors.Hand;
            panel.Width = 352;
            panel.Height = 106;
            panel.Location = new Point(1, panelY);
            panel.Tag = id;
            panel.BorderStyle = BorderStyle.FixedSingle;

            CheckBox check = new CheckBox();
            check.Text = "Mark as Done";
            check.Location = new Point(15, 11);
            check.Tag = id;
            check.Font = new Font("Arial", 9, FontStyle.Regular);
            check.CheckedChanged += new EventHandler(checkDone_check);
            panel.Controls.Add(check);

            Label lblDescription = new Label();
            lblDescription.AutoSize = true;
            lblDescription.Size = new Size(325, 40);
            lblDescription.Location = new Point(12, 36);
            lblDescription.Text = description;
            lblDescription.Tag = id;
            lblDescription.Font = new Font("Arial", 10, FontStyle.Regular);
            lblDescription.ForeColor = string.IsNullOrEmpty(readBy.Trim()) ? Color.Black : Color.Green;
            lblDescription.TextAlign = ContentAlignment.MiddleLeft;
            lblDescription.Click += new EventHandler(panelSub_Click);
            panel.Controls.Add(lblDescription);

            Label lblDate = new Label();
            lblDate.AutoSize = true;
            lblDate.Size = new Size(325, 17);
            lblDate.Location = new Point(12,82);
            lblDate.ForeColor = Color.DimGray;
            lblDate.Tag = id;
            lblDate.Font = new Font("Arial", 9, FontStyle.Regular);
            lblDate.TextAlign = ContentAlignment.BottomRight;
            lblDate.Text = dateCreated;
            lblDate.Click += new EventHandler(panelSub_Click);
            panel.Controls.Add(lblDate);

            panel.Click += new EventHandler(panelSub_Click);
            return panel;
        }

        private async void checkDone_check(object sender, EventArgs e)
        {
            CheckBox check = (CheckBox)sender;
            if (check.Checked)
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure you want to done?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    notification_class notifc = new notification_class();
                    selectedID = string.IsNullOrEmpty(check.Tag.ToString()) ? 0 : Convert.ToInt32(check.Tag.ToString());
                    string msg = await notifc.markAsRead(selectedID);
                    MessageBox.Show(msg, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    selectedID = 0;

                    Cursor.Current = Cursors.WaitCursor;
                    lblTitle.Text = "NOTIFICATION (Loading...)";
                    panelBody.Controls.Clear();
                    DataTable dtUnread = await Task.Run(() => notifc.getUnreadNotif("", "", "","",0));
                    loopDt(dtUnread);
                }
                else
                {
                    check.Checked = false;
                }
            }
        }

        private async void panelSub_Click(object sender, EventArgs e)
        {
            Control pn = (Control)sender;
            selectedID = string.IsNullOrEmpty(pn.Tag.ToString()) ? 0 : Convert.ToInt32(pn.Tag.ToString());
            this.Hide();
            await Task.Delay(10);
        }

        private void btnClose_MouseEnter(object sender, EventArgs e)
        {
            btnClose.ForeColor = Color.Red;
            btnClose.BackColor = Color.White;
        }

        private void btnClose_MouseLeave(object sender, EventArgs e)
        {
            btnClose.ForeColor = Color.Black;
            btnClose.BackColor = Color.FromArgb(240, 240, 240);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            notification_class notifc = new notification_class();
            lblTitle.Text = "NOTIFICATION (Loading...)";
            panelBody.Controls.Clear();
            DataTable dtUnread = await Task.Run(() => notifc.getUnreadNotif("", "", "","",0));
            loopDt(dtUnread);
        }

        private void panelBody_Scroll(object sender, ScrollEventArgs e)
        {
         
        }
    }
}
