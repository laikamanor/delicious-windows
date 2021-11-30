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
using DeliciousPartnerApp.UI_Class;
namespace DeliciousPartnerApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        utility_class utilityc = new utility_class();
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool isContains = textBox1.Text.ToLower().Contains(textBox2.Text.ToLower());
            MessageBox.Show(isContains.ToString());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var client = new RestClient(utilityc.URL);
            var request = new RestRequest("/api/sales/summary_trans");
            client.Timeout = -1;
            request.AddHeader("Authorization", "Bearer eyJhbGciOiJIUzUxMiIsImlhdCI6MTYwNzc0MjU5OSwiZXhwIjoxNjA3OTE1Mzk5fQ.eyJ1c2VyX2lkIjoxfQ.pNjO5H2W19AO_1cpJmwNyJqWCCPgtQeUSvdcbsmyWkieDw96I94WIhIw3GR2McZNygJu36p1SpJtwvsvBIKS6g");
            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody("application/json", "{\r\n    \"ids\": [1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,66,42,43,46,51,53,56,61,64,44,50,52,58,62,63,65,45,47,54,57,48,49,55,59,60,67,68,69,70,71,72,73,74,75,76,77,78,79,80,81,82,83,84,85,86,87,88,89,90,91,92,93,94,95,96,97,98,99,101,102,103,104,105,106,107,108,109,110,111,112,113,114,115,116,117,118,119,120,121,123,124,125,128,127,129,130,131,132,133,134,135,136,137,138,139,140,141,142,143,144,145,146,147,148,149,150,151,152,153,154,155,156,157,158,159,161,160,163,165,166,167,168,169,170,171,172,173,174,175,176,177,178,179,180,181,182,183,184,185,186,187,188,189,190,191,192,193,194,195,196,197,198,199,201,202,203,204,205,206,207,210,211,212,214,215,216,208,209,213,217,218,219,220,221,222,223,224,225,226,227,228,229,230,232,233,234,235,236,237,238,239,240,241,242,244,245,246,247,248,249,250,251,252,253,256,257,258,259,276,277,261,264,268,274,263,269,265,266,270,271,275,278,279,280,281,282,283,284,285,286,290,291,292,293,294,295,296,297,298,299,300,301,302,303,306,307,308,309,310,311,312,313,314,315,316,317,318,319,320,321,322,328,329,331,335,338,339,340,341,345,323,324,332,334,337,343,346,325,342,326,327,330,336,344,333,347,348,349,350,351,352,353,354,355,356,357,358,359,360,361,362,363,364,365,366,367,368,369,370,371,372,373,374,375,376,378,379,380,381,382,383,384,385,386,387,388,389,390,391,392,393,395,400,402,405,406,407,410,396,397,398,399,401,403,404,409,411,412,413,414,415,416,417,418,419,420,421,422,423,424,425,426,427,428,429,430,431,432,437,438,440,442,447,451,454,463,465,466,467,468,471,473,479,433,434,435,439,441,443,444,446,448,449,450,452,453,455,456,457,458,459,460,461,462,464,469,470,472,474,475,476,477,478]\r\n}");
            var response = client.Execute(request);
            if(response.ErrorMessage == null)
            {
                Console.WriteLine("response: " +  response.Content.ToString());
            }
            else
            {
                Console.WriteLine("error: " + response.ErrorMessage);
            }
        }

        private void btnSAD_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(Convert.ToDouble(textBox1.Text));
        }
    }
}
