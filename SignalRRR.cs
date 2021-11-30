using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.AspNetCore.SignalR.Client;
namespace DeliciousPartnerApp
{
    public partial class SignalRRR : Form
    {
        HubConnection connection;
        public SignalRRR()
        {
            InitializeComponent();

            connection = new HubConnectionBuilder()
               .WithUrl("http://localhost:53353/ChatHub")
               .Build();

            connection.Closed += async (error) =>
            {
                await Task.Delay(new Random().Next(0, 5) * 1000);
                await connection.StartAsync();
            };
        }



        private async void SignalRRR_Load(object sender, EventArgs e)
        {
            connection.On<string,string, string>("ReceiveMessage", (user,to, message) =>
            {
                this.Invoke((Action)(() =>
                {
                    if(to == txtFrom.Text)
                    {
                        var newMessage = $"{user}: {message}";
                        listBox1.Items.Add(newMessage);
                    }
                }));
            });

            try
            {
                await connection.StartAsync();
                listBox1.Items.Add("Connection started");
                //sendButton.IsEnabled = true;
            }
            catch (Exception ex)
            {
                listBox1.Items.Add(ex.Message);
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                await connection.InvokeAsync("SendMessage",
                    txtFrom.Text, txtTo.Text, txtMessage.Text);
                listBox1.Items.Add($"{txtFrom.Text}: {txtMessage.Text}");
            }
            catch (Exception ex)
            {
                listBox1.Items.Add(ex.Message);
            }
        }
    }
}
