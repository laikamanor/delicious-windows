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
using System.IO;

namespace DeliciousPartnerApp
{
    public partial class Read_URL : Form
    {
        public Read_URL()
        {
            InitializeComponent();
        }
        utility_class utilityc = new utility_class();
        private void  Read_URL_Load(object sender, EventArgs e)
        {
            loadSaveAddress();
            txt.Text = utilityc.URL;
            txt.Focus();
        }

        public void loadSaveAddress()
        {
            if(!File.Exists(Directory.GetCurrentDirectory() + "/saveAddress.txt"))
            {
                File.Create(Directory.GetCurrentDirectory() + "/saveAddress.txt").Close();
            }
            string[] lines = File.ReadAllLines("saveAddress.txt");
            panelSavedAddress.Controls.Clear();
            int x = 13;
            foreach (string line in lines)
            {
                Button btn = new Button();
                btn.Size = new Size(183, 34);
                btn.Location = new Point(x, 5);
                btn.BackColor = Color.ForestGreen;
                btn.ForeColor = Color.White;
                btn.Font = new Font("Arial", 10, FontStyle.Bold);
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 0;
                btn.Cursor = Cursors.Hand;
                btn.Text = line;
                toolTip1.SetToolTip(btn, btn.Text);
                btn.Click += new EventHandler(btnAddresses_click);
                x += 187;
                panelSavedAddress.Controls.Add(btn);
            }
        }

        private void btnAddresses_click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            foreach (Control c in panelSavedAddress.Controls)
            {
                if (c is Button)
                {
                    ((Button)c).FlatAppearance.BorderSize = 0;
                    ((Button)c).FlatAppearance.BorderColor = Color.White;

                }
            }

            btn.FlatAppearance.BorderSize = 2;
            btn.FlatAppearance.BorderColor = Color.Red;
            txt.Clear();
            txt.Text = btn.Text;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt.Text.Trim())) {
                MessageBox.Show("URL field is required", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt.Focus();
            }
            else
            {
                linkPassword.isSubmit = false;
                linkPassword frm = new linkPassword();
                frm.ShowDialog();
                if (linkPassword.isSubmit)
                {
                    this.Hide();


                    if (!File.Exists(Directory.GetCurrentDirectory() + "/saveAddress.txt"))
                    {
                        File.Create(Directory.GetCurrentDirectory() + "/saveAddress.txt").Close();
                    }
                    string[] lines = File.ReadAllLines("saveAddress.txt");

                    string allLines = System.IO.File.ReadAllText("saveAddress.txt").Trim();
                    panelSavedAddress.Controls.Clear();
                    int isExist = 0;
                    foreach (string line in lines)
                    {
                        if (txt.Text.Trim().ToLower().Equals(line.Trim().ToLower()))
                        {
                            isExist += 1;
                        }
                    }
                    if (isExist <= 0)
                    {
                        File.AppendAllText("saveAddress.txt", (string.IsNullOrEmpty(allLines) ? "" : Environment.NewLine) + txt.Text.Trim());
                    }

                    File.WriteAllText(System.Environment.CurrentDirectory + @"\URL.txt", txt.Text.Trim());
                }
            }
        }

        private void txt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                btnSubmit.PerformClick();
            }
        }
    }
}
