using System;
using System.Windows.Forms;
using System.Diagnostics;

namespace vpn
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string comboBoxText = comboBox1.GetItemText(comboBox1.Text);
            bool serverSelected = comboBoxText != "Select your server";

            if (serverSelected && radioButton1.Checked)
            {
                Process process = new Process();
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.WindowStyle = ProcessWindowStyle.Hidden;
                startInfo.FileName = @"C:\Program Files\OpenVPN\bin\openvpn.exe";
                startInfo.Arguments = "--config " + comboBoxText + "ukudp.ovpn";
                startInfo.Verb = "runas";
                process.StartInfo = startInfo;
                process.Start();
                MessageBox.Show("You've connected to " + comboBoxText + " with udp");

            }
            else if (serverSelected && radioButton2.Checked)
            {
                Process process = new Process();
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.WindowStyle = ProcessWindowStyle.Hidden;
                startInfo.FileName = @"C:\Program Files\OpenVPN\bin\openvpn.exe";
                startInfo.Arguments = "--config " + comboBoxText + "uktcp.ovpn";
                startInfo.Verb = "runas";
                process.StartInfo = startInfo;
                process.Start();
                MessageBox.Show("You've connected to " + comboBoxText + " with tcp");
            }
            else
            {
                MessageBox.Show("Please select a server and protocol before connecting");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            disconnect();
            MessageBox.Show("You've disconnected from the server");
        }

        private void disconnect()
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = "taskkill",
                Arguments = $"/f /im openvpn.exe",
                CreateNoWindow = true,
                UseShellExecute = false
            }).WaitForExit();
        }
    }
}
