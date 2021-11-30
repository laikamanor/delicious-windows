using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeliciousPartnerApp
{
    public partial class NotificationTab : Form
    {
        public NotificationTab()
        {
            InitializeComponent();
        }

        private void NotificationTab_Load(object sender, EventArgs e)
        {
            Notification2 notif = new Notification2(0);
            showForm(panelPending, notif);
        }

        public void showForm(Panel panel, Form form)
        {
            panel.Controls.Clear();
            form.TopLevel = false;
            panel.Controls.Add(form);
            form.BringToFront();
            form.Show();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int isDone = tabControl1.SelectedIndex.Equals(0) ? 0 : tabControl1.SelectedIndex;
            Panel pn = isDone > 0 ? panelDone : panelPending;
            Notification2 notif = new Notification2(isDone);
            showForm(pn, notif);
        }
    }
}
