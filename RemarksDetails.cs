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
namespace DeliciousPartnerApp
{
    public partial class RemarksDetails : Form
    {
        public RemarksDetails(int isDone)
        {
            InitializeComponent();
            gIsDone = isDone;
        }
        public int selectedID = 0;
        int gIsDone = 0;
        private  async void RemarksDetails_Load(object sender, EventArgs e)
        {
            btnAadd.Visible = gIsDone <= 0 ? true : false;
            await loadData();
        }

        public async Task loadData()
        {
            try
            {
                notification_class notifc = new notification_class();
                DataTable dt = await Task.Run(() => notifc.getRemarksDetails(selectedID));
                dgv.Invoke(new Action(delegate ()
                {
                    dgv.Rows.Clear();
                }));
                foreach (DataRow row in dt.Rows)
                {
                    dgv.Rows.Add(row["id"].ToString(), row["doc_id"].ToString(), row["remarks"].ToString(), row["date_created"].ToString(), row["created_by"].ToString());
                }
            }
            catch
            {

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

        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            await loadData();
        }
    }
}
