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
using System.Drawing.Imaging;

namespace DeliciousPartnerApp
{
    public partial class Barcodee : Form
    {
        public Barcodee()
        {
            InitializeComponent();
        }
        EAN13Class ean = new EAN13Class();
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string barrcode, Check12Digits;
            if(textBox1.Text != "")
            {
                Check12Digits = textBox1.Text.PadRight(12, '0');
                barrcode = EAN13Class.EAN13(Check12Digits);
                label4.Text = barrcode;

                if(string.Equals(EAN13Class.Barcode13Digits, "") || (EAN13Class.Barcode13Digits != ""))
                {
                    textBox2.Text = EAN13Class.Barcode13Digits.ToString();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Bitmap bitmap = DrawControlBitMap(label4);
                bitmap.Save(saveFileDialog1.FileName + DateTime.Now.ToString("_yyyy_MM_dd_HH_mm_ss") + ".png");
                MessageBox.Show("Saved","Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private static Bitmap DrawControlBitMap(Control control)
        {
            Bitmap bitmap = new Bitmap(control.Width, control.Height);
            Graphics graphics = Graphics.FromImage(bitmap);
            Rectangle rect = control.RectangleToScreen(control.ClientRectangle);
            graphics.CopyFromScreen(rect.Location, Point.Empty, control.Size);
            return bitmap;
        }

        private void Barcodee_Load(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            label4.Text = textBox3.Text;
        }
    }
}
