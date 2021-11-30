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

namespace DeliciousPartnerApp
{
    public partial class ItemRequest : Form
    {
     
        public ItemRequest()
        {
            InitializeComponent();
        }

        private void ItemRequest_Load(object sender, EventArgs e)
        {
            ItemRequest2 itemRequest = new ItemRequest2("For Confirmation");
            showForm(panelConfirmation, itemRequest);
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
            if (tabControl1.SelectedIndex.Equals(0))
            {
                ItemRequest2 itemRequest = new ItemRequest2("For Confirmation");
                showForm(panelConfirmation, itemRequest);
            }
            else if (tabControl1.SelectedIndex.Equals(1))
            {
                ItemRequest_ForProduction itemRequest = new ItemRequest_ForProduction();
                showForm(panelProduction, itemRequest);
            }
            else if (tabControl1.SelectedIndex.Equals(2))
            {
                ItemRequest2 itemRequest = new ItemRequest2("Logs");
                showForm(panelLogs, itemRequest);
            }
        }
    }
}
