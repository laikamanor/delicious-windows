using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DeliciousPartnerApp.API_Class.Items;
using DevExpress.XtraGrid.Views.Grid;
using System.Globalization;

namespace DeliciousPartnerApp
{
    public partial class Items_DX : Form
    {
        public Items_DX()
        {
            InitializeComponent();
        }
        item_class itemc = new item_class();
        private void Items_DX_Load(object sender, EventArgs e)
        {
            loadBgW();
        }

        public void closeForm()
        {
            foreach (Form frm in Application.OpenForms)
            {
                if (frm.Name == "Loading")
                {
                    frm.Hide();
                }
            }
        }

        public void loadBgW()
        {
            if (!backgroundWorker1.IsBusy)
            {
                closeForm();
                Loading frm = new Loading();
                frm.Show();
                backgroundWorker1.RunWorkerAsync();
            }
        }

        public void loadData()
        {
            DataTable dt = itemc.loadData();
            gridControl1.Invoke(new Action(delegate ()
            {
                gridControl1.DataSource = dt;
                gridView1.Columns["id"].Visible = gridView1.Columns["message"].Visible = gridView1.Columns["success"].Visible = false;

                for (int i = 0; i < gridView1.Columns.Count; i++)
                {
                    string x = gridView1.Columns[i].GetCaption().ToString().Replace("_", " ");
                    string v = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(x.ToLower());
                    gridView1.Columns[i].Caption = v;
                    (gridControl1.MainView as GridView).Columns[i].OptionsColumn.ReadOnly = true;
                    (gridControl1.MainView as GridView).Columns[i].DisplayFormat.FormatType = v.Equals("Price") ? DevExpress.Utils.FormatType.Numeric : DevExpress.Utils.FormatType.None;
                    (gridControl1.MainView as GridView).Columns[i].DisplayFormat.FormatString = v.Equals("Price") ? "n2" : "";
                }
                (gridControl1.MainView as GridView).Columns["price"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            }));
        }


        private void btnAddItem_Click(object sender, EventArgs e)
        {
            AddItem addItem = new AddItem();
            addItem.ShowDialog();
            if (AddItem.isSubmit)
            {
                loadBgW();
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            loadData();
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            closeForm();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            loadBgW();
        }
    }
}
