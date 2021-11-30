using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace DeliciousPartnerApp.UI_Class
{

    class utility_class
    {
        public string appName = "Delicious Partner App";
        public string versionName = "2.0";
        public string abWindowsProdURLFile = "dpa_prodURL.txt";
        public string URL = System.IO.File.ReadAllText("URL.txt");
        public string abWindowsVersionFile = "dpa_window_file.txt";
        public string githubVersionFileLink = @"https://raw.githubusercontent.com/laikamanor/files/master/";
        public string githubDownload32FileLink = @"https://github.com/laikamanor/mobile-pos-v2/releases/download/v1.17/DPA.Setup.exe";
        public string githubDownload64FileLink = @"https://github.com/laikamanor/mobile-pos-v2/releases/download/v1.17/DPA.Setup64.exe";

        public string localDirectory32Exe = @"C:\DPA Installer\DPASetup.exe";
        public string localDirectory64Exe = @"C:\DPA Installer\DPASetup64.exe";
        public string localDirectoryFolder = @"C:\DPA Installer";
        public string getTextfromGithub(string value)
        {
            var strContent = "";
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                ServicePointManager.Expect100Continue = true;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

                var webRequest = WebRequest.Create(githubVersionFileLink + value);
                Console.WriteLine(githubVersionFileLink + value);

                using (var response = webRequest.GetResponse())
                using (var content = response)
                using (var reader = new StreamReader(content.GetResponseStream()))
                {
                    strContent = reader.ReadToEnd();
                }
                Cursor.Current = Cursors.Default;
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
            return strContent;
        }
    }
}
