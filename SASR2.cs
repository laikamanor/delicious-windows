using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using System.Windows.Forms.DataVisualization.Charting;
namespace DeliciousPartnerApp
{
    public partial class SASR2 : Form
    {
        public SASR2(JArray ja, string gtype, bool isFullScreen, string tabName)
        {
            gIsFullScreen = isFullScreen;
            jaBSR = ja;
            type = gtype;
            gTabName = tabName;
            InitializeComponent();
        }
        JArray jaBSR = new JArray();
        string type = "", gTopBy = "", gTabName = "";
        bool gIsFullScreen = false;
        Point tl = Point.Empty;
        private void SASR2_Load(object sender, EventArgs e)
        {
            this.WindowState = gIsFullScreen ? FormWindowState.Maximized : FormWindowState.Normal;
            this.FormBorderStyle = gIsFullScreen ? FormBorderStyle.None : FormBorderStyle.Sizable;
            this.CenterToScreen();
            loadData();
            gIsFullScreen = !gIsFullScreen;
        }


        public void loadData()
        {
            List<Color> c = new List<Color>();
            c = topColors();
            Random rnd = new Random();
            chart1.Series["Series1"].Points.Clear();
            DataTable dt = populateData();
            string chartToolTipText = "";
            chart1.Legends.Clear();
            chart1.ChartAreas["ChartArea1"].AxisY.LabelStyle.Format = "{ 0.00} %";
            chart1.ChartAreas["ChartArea1"].AxisX.Interval = 1;
            int count = 0;
            if (dt.Rows.Count > 0)
            {
                double overAll = 0.00;
                foreach (DataRow row in dt.Rows)
                {
                    string branch = row["branch"].ToString();
                    double num1 = 0.00, num2 = 0.00, doubleTemp = 0.00, totalSales = 0.00;
                    num1 = Convert.ToDouble(row["num1"].ToString());
                    num2 = Convert.ToDouble(row["num2"].ToString());
                    totalSales = Convert.ToDouble(row["total_sales"].ToString());
                    overAll += Convert.ToDouble(row["total_sales"].ToString());

                    string s = branch;
                    //Console.WriteLine(num2);
                    int p = chart1.Series["Series1"].Points.AddXY(s, (num2 == double.NaN ? 0 : num2));
                    chartToolTipText += (string.IsNullOrEmpty(chartToolTipText.Trim()) ? "" : Environment.NewLine) + branch + " - " + totalSales.ToString("n2") + " (" + num2.ToString("n2") + "%)";

                    if (count < 10 && !branch.Trim().ToLower().Contains("others"))
                    {
                        chart1.Series["Series1"].Points[p].Color = c[count];
                    }
                    else if (branch.Trim().ToLower().Contains("others"))
                    {
                        chart1.Series["Series1"].Points[p].Color = Color.FromArgb(155, 255, 135);
                    }
                    else
                    {
                        Color randomColor = System.Drawing.Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
                        foreach (Color color in c)
                        {
                            while (color == randomColor)
                            {
                                randomColor = System.Drawing.Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
                            }
                        }
                        chart1.Series["Series1"].Points[p].Color = randomColor;
                    }

                    if (jaBSR.Count <= 11)
                    {
                        chart1.Series["Series1"].Points[p].ToolTip = "";


                        chart1.Series["Series1"].Points[p].LabelForeColor = Color.White;
                        chart1.Series["Series1"].Points[p].Font = new System.Drawing.Font("Arial", jaBSR.Count <=6 ? 12f : 7f);
                        //chart1.Series["Series1"].Points[p].Font = new System.Drawing.Font("Arial", 14f);
                        chart1.Series["Series1"].Points[p].Label = num2.ToString("n2") + "%" + Environment.NewLine + totalSales.ToString("n2");
                        chart1.Series["Series1"].Points[p].LabelToolTip = "";
                        chart1.Series["Series1"].LabelAngle = 90;
                        chart1.Series["Series1"]["LabelStyle"] = "Bottom";
                    }
                    else
                    {
                        toolTip1.SetToolTip(chart1, chartToolTipText);
                    }

                    if (!branch.Trim().ToLower().Contains("others"))
                    {
                        count += 1;
                    }
                }
                chart1.Titles["Title1"].Text = (count <= 10 ? "Top " + count.ToString("N0") : "All") + " " + gTabName + Environment.NewLine + type + " Sales: " + overAll.ToString("n2");
                if (count > 7)
                {
                    chart1.ChartAreas["ChartArea1"].AxisX.LabelStyle.Angle = -65;
                    chart1.ChartAreas["ChartArea1"].AxisX.IntervalAutoMode = IntervalAutoMode.VariableCount;
                    chart1.ChartAreas["ChartArea1"].AxisX.IsLabelAutoFit = false;
                }
            }
            else
            {
                chart1.Titles["Title1"].Text = (count <= 10 ? "Top " + count.ToString("N0") : "All") + " " + gTabName + Environment.NewLine + type + " Sales: 0.00";
                toolTip1.SetToolTip(chart1, "No data found :(");
            }
            //chart1.Series["Series1"].ToolTip = "#VALX [#PERCENT]";

            //chart1.ChartAreas["ChartArea1"].AxisX.Minimum = 0;
            //chart1.ChartAreas["ChartArea1"].AxisX.Maximum = 99999999;
        }

        public List<Color> topColors()
        {
            Color[] colors = { Color.Green, //1 
            Color.Blue,//2
            Color.Red,//3
            Color.Orange,//4
            Color.FromArgb(232, 217, 0),//5
            Color.FromArgb(247, 116, 116), //6
            Color.Brown, //7
            Color.Violet, //8
            Color.Gray, // 9
            Color.FromArgb(157, 160, 252) //10
            };

            List<Color> c = new List<Color>();
            c.AddRange(colors);
            return c;
        }

        public DataTable populateData()
        {

            DataTable dt = new DataTable();
            dt.Columns.Add("branch", typeof(string));
            dt.Columns.Add("total_sales", typeof(double));
            dt.Columns.Add("overall_total_sales", typeof(double));
            dt.Columns.Add("num1", typeof(double));
            dt.Columns.Add("num2", typeof(double));


            DataTable dtOther = new DataTable();
            dtOther.Columns.Add("branch", typeof(string));
            dtOther.Columns.Add("total_sales", typeof(double));
            dtOther.Columns.Add("overall_total_sales", typeof(double));
            dtOther.Columns.Add("num1", typeof(double));
            dtOther.Columns.Add("num2", typeof(double));


            for (int i = 0; i < jaBSR.Count(); i++)
            {
                JObject jo = JObject.Parse(jaBSR[i].ToString());
                string branch = "";
                double totalSales = 0.00, overAllTotalSales = 0.00, doubleTemp = 0.00;
                if (gTabName.Equals("Branch"))
                {
                    foreach (var q in jo)
                    {
                        if (q.Key.Equals("branch"))
                        {
                            branch = q.Value.ToString();
                        }
                        else if (q.Key.Equals("total_sales"))
                        {
                            totalSales = double.TryParse(q.Value.ToString(), out doubleTemp) ? Convert.ToDouble(q.Value.ToString()) : doubleTemp;
                        }
                        else if (q.Key.Equals("overall_total_sales"))
                        {
                            overAllTotalSales = double.TryParse(q.Value.ToString(), out doubleTemp) ? Convert.ToDouble(q.Value.ToString()) : doubleTemp;
                        }
                    }
                }
                else
                {
                    foreach (var q in jo)
                    {
                        if (q.Key.Equals("cust_code"))
                        {
                            branch = q.Value.ToString();
                        }
                        else if (q.Key.Equals("total_sales"))
                        {
                            totalSales = double.TryParse(q.Value.ToString(), out doubleTemp) ? Convert.ToDouble(q.Value.ToString()) : doubleTemp;
                        }
                        else if (q.Key.Equals("overall_total_sales"))
                        {
                            overAllTotalSales = double.TryParse(q.Value.ToString(), out doubleTemp) ? Convert.ToDouble(q.Value.ToString()) : doubleTemp;
                        }
                    }
                }

                double num1 = 0.00, num2 = 0.00;
                num1 = totalSales / overAllTotalSales;
                num2 = num1 * 100;

                if (branch.ToLower().Contains("other"))
                {
                    dtOther.Rows.Add(branch, totalSales, overAllTotalSales, num1, num2);
                }
                else
                {
                    dt.Rows.Add(branch, totalSales, overAllTotalSales, num1, num2);
                }
            }

            dt.DefaultView.Sort = "num2 DESC";
            dt = dt.DefaultView.ToTable();

            foreach (DataRow row in dtOther.Rows)
            {
                dt.Rows.Add(row["branch"].ToString(), Convert.ToDouble(row["total_sales"].ToString()), Convert.ToDouble(row["overall_total_sales"].ToString()), Convert.ToDouble(row["num1"].ToString()), Convert.ToDouble(row["num2"].ToString()));
            }

            return dt;
        }

        private void chart1_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void SASR2_SizeChanged(object sender, EventArgs e)
        {
            foreach (var q in chart1.Series["Series1"].Points)
            {
                if(this.WindowState == FormWindowState.Normal)
                {
                    q.Font = new System.Drawing.Font("Arial", jaBSR.Count <= 6 ? 9f : 6f);
                }
                else
                {
                    q.Font = new System.Drawing.Font("Arial", jaBSR.Count <= 6 ? 12f : 9f);
                }
            }
        }

        private void btnFullScreen_Click(object sender, EventArgs e)
        {
            if (gIsFullScreen)
            {
                this.Close();
            }
            else
            {
                SASR2 frm = new SASR2(jaBSR, type, false, gTabName);
                frm.ShowDialog();
            }
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }
    }
}
