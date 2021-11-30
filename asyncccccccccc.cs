using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
namespace DeliciousPartnerApp
{
    public partial class asyncccccccccc : Form
    {
        public asyncccccccccc()
        {
            InitializeComponent();
        }


        private async void button1_Click(object sender, EventArgs e)
        {
     
        }


        private async void asyncccccccccc_Load(object sender, EventArgs e)
        {
            AutoCompleteStringCollection auto = new AutoCompleteStringCollection();
            auto.Add("gord");
            auto.Add("joyce");
            this.textBox1.AutoCompleteCustomSource = auto;
            this.textBox1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.textBox1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
        }
    }
}
