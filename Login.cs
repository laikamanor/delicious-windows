using System;
using System.Windows.Forms;
using RestSharp;
using Newtonsoft.Json.Linq;
using DeliciousPartnerApp.UI_Class;
using System.Net;
using System.Threading;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;

namespace DeliciousPartnerApp
{
    public partial class Login : Form
    {
        public static JObject jsonResult = new JObject();
        UI_Class.utility_class utilityc = new utility_class();
        public static string fullName = "";
        public Login()
        {
            InitializeComponent();
        }
        bool is32Bit = false;
        private async void btnLogin_Click(object sender, EventArgs e)
        {
            var strContent = utilityc.getTextfromGithub(utilityc.abWindowsVersionFile);
            //double tempDouble = 0;
            //double serverVersion = double.TryParse(strContent, out tempDouble) ? double.Parse(strContent) : 0;
            //double currentVersion = double.TryParse(utilityc.versionName, out tempDouble) ? double.Parse(utilityc.versionName) : 0;
            //MessageBox.Show(strContent + Environment.NewLine + utilityc.versionName);
            int intTemp = 0;
            bool isNumeric = Int32.TryParse(strContent.Substring(0, 1).ToString(), out intTemp) ? true : false;
            if (isNumeric)
            {
                if (strContent.Trim() != utilityc.versionName.Trim())
                {
                    txtUsername.Enabled = false;
                    txtPassword.Enabled = false;
                    btnLogin.Enabled = false;
                    progressBarsss.Visible = true;
                    linkLabel1.Visible = false;
                    DialogResult dialogResult = MessageBox.Show("There is a version (v" + strContent.Trim() + ") available do you want to update now?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (dialogResult == DialogResult.Yes)
                    {
                        string URL = "";
                        DialogResult dialogResult2 = MessageBox.Show("Do you want to install 32 bit (Click Yes) or 64 bit (Click No)?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (dialogResult2 == DialogResult.Yes)
                        {
                            is32Bit = true;
                            URL = utilityc.githubDownload32FileLink;
                        }
                        else
                        {
                            is32Bit = false;
                            URL = utilityc.githubDownload64FileLink;
                        }
                        using (var client = new WebClient())
                        {
                            string path = utilityc.localDirectoryFolder;
                            if (!Directory.Exists(path))
                            {
                                Directory.CreateDirectory(path);
                            }
                            client.DownloadProgressChanged += wc_DownloadProgressChanged;
                            //MessageBox.Show("URL: " + URL + Environment.NewLine + "is 32 bit: " + is32Bit.ToString() + Environment.NewLine + (is32Bit ? utilityc.localDirectory32Exe : utilityc.localDirectory64Exe));
                            client.DownloadFileAsync(new Uri(URL), is32Bit ? utilityc.localDirectory32Exe : utilityc.localDirectory64Exe);
                        }
                    }
                    else
                    {
                        txtUsername.Enabled = true;
                        txtPassword.Enabled = true;
                        btnLogin.Enabled = true;
                        progressBarsss.Visible = false;
                        linkLabel1.Visible = true;
                    }
                }
                else
                {
                    login();
                }
            }
            else
            {
                MessageBox.Show(strContent, "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            //     https://github.com/laikamanor/mobile-pos-v2/releases/download/v1.17/ab2_v1_18.exe
        }

        private void wc_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            if (e.ProgressPercentage == 100)
            {
                DialogResult dialogResult = MessageBox.Show("Downloaded", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (dialogResult == DialogResult.OK)
                {
                    try
                    {
                        Process.Start(is32Bit ? utilityc.localDirectory32Exe : utilityc.localDirectory64Exe);
                        this.Dispose();
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message, " Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            else
            {
                progressBarsss.Value = e.ProgressPercentage;
            }
        }

        public void login()
        {
            try
            {
                var client = new RestClient(System.IO.File.ReadAllText("URL.txt"));
                client.AddDefaultHeader("Content-Type", "application/json");
                client.Timeout = -1;
                var request = new RestRequest("/api/auth/login?username=" + txtUsername.Text.ToString().Trim() + "&password=" + txtPassword.Text.ToString().Trim());
                var response = client.Execute(request);
                if (response.ErrorMessage == null)
                {
                    if (response.Content.Substring(0, 1).Equals("{"))
                    {
                        jsonResult = JObject.Parse(response.Content.ToString());
                        string msg = "";
                        bool temp = false;
                        bool isSuccess = false;
                        foreach (var q in jsonResult)
                        {
                            if (q.Key.Equals("message"))
                            {
                                msg = q.Value.ToString();
                            }
                            if (q.Key.Equals("success"))
                            {
                                isSuccess = Boolean.TryParse(q.Value.ToString(), out temp) ? bool.Parse(q.Value.ToString()) : temp;
                            }
                        }
                        foreach (var q in jsonResult)
                        {
                            if (q.Key.Equals("data"))
                            {
                                JObject joData = string.IsNullOrEmpty(q.Value.ToString()) || !q.Value.ToString().Substring(0,1).Equals("{") ? new JObject() : JObject.Parse(q.Value.ToString());
                                foreach (var y in joData)
                                {
                                    if (y.Key.Equals("fullname"))
                                    {
                                        fullName = y.Value.ToString();
                                        break;
                                    }
                                }
                            }
                        }
                        MessageBox.Show(msg,isSuccess ? "Message" : "Validation", MessageBoxButtons.OK, isSuccess ? MessageBoxIcon.Information : MessageBoxIcon.Warning);
                        if (isSuccess)
                        {
                            Cursor.Current = Cursors.Default;
                            Action action = () => this.Hide();
                            this.BeginInvoke(action);
                            MainMenu mainMenu = new MainMenu();
                            mainMenu.ShowDialog();
                        }
                    }
                    else
                    {
                        MessageBox.Show(response.Content, "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }else
                {
                    MessageBox.Show(response.ErrorMessage, "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtUsername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin.PerformClick();
            }
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin.PerformClick();
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {
            linkLabel1.Text = utilityc.URL;
            this.Text = "Login - v" + utilityc.versionName;
        }

        private void Login_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void checkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = checkShowPassword.Checked ? '\0' : '*';
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Read_URL frm = new Read_URL();
            frm.ShowDialog();
            linkLabel1.Text= System.IO.File.ReadAllText("URL.txt");
            txtUsername.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var client = new RestClient("http://localhost:58546");
                client.AddDefaultHeader("Content-Type", "application/json");
                client.Timeout = -1;
                var request = new RestRequest("/api/weather");
                var response = client.Execute(request);
                if (response.ErrorMessage == null)
                {
                    MessageBox.Show(response.Content.ToString());
                }
                else
                {
                    MessageBox.Show(response.ErrorMessage, "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
