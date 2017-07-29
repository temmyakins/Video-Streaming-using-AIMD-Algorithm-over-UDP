using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
       

        public Form1()
        {
            InitializeComponent();
        }


        public string videoFile { get; private set; }
        public string bitRate { get; private set; }
        public string serverIP { get; private set; }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            TextBox objTextBox = (TextBox)sender;
            serverIP = objTextBox.Text;
        }

        private void bitRateComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            bitRate = bitRateComboBox.Text;
        }

        private void ConnectServer_Click(object sender, EventArgs e)  //connect to server button
        {
            if (String.IsNullOrWhiteSpace(serverIP))
            {
                MessageBox.Show("Please enter an IP Address!!");
            }
            else
            {
                UdpClient udpClient = new UdpClient();
                udpClient.Connect(serverIP, 8080);
                Byte[] senddata = Encoding.ASCII.GetBytes("Hello World");
                udpClient.Send(senddata, senddata.Length);
                /*
                var client = new UdpClient();
                IPEndPoint ep = new IPEndPoint(IPAddress.Parse(serverIP), 1001); // endpoint where server is listening
                client.Connect(ep);

                // send data
                client.Send(new byte[] { 1, 2, 3, 4, 5 }, 5);

                // then receive data
                var receivedData = client.Receive(ref ep);

                Console.Write("receive data from " + ep.ToString());

                //Console.Read();
                */
            }
        }

        

        private void label4_Click(object sender, EventArgs e)
        {

        }
        private void label1_Click(object sender, EventArgs e)
        {

        }


        private void videoOption_SelectedIndexChanged(object sender, EventArgs e)
        {
            videoFile = videoOption.Text;
        }

        private void sendVideoBtn_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(serverIP))
            {
                MessageBox.Show("Please enter an IP Address!!");
            }
            else if (String.IsNullOrWhiteSpace(bitRate))
            {
                MessageBox.Show("Please enter a bit rate!!");
            }
            else if (String.IsNullOrWhiteSpace(videoFile))
            {
                MessageBox.Show("Please choose a video!!");
            }
            else
            {
                var client = new UdpClient();
                IPEndPoint ep = new IPEndPoint(IPAddress.Parse(serverIP), 1234); // endpoint where server is listening
                client.Connect(ep);

                // send data
                byte[] byData = System.Text.Encoding.ASCII.GetBytes("IP:" + serverIP + " VF: "+videoFile + " BR:"+ bitRate);
                client.Send(byData, byData.Count(),ep);

                // then receive data
                var receivedData = client.Receive(ref ep);

                Console.Write("receive data from " + ep.ToString());

                Console.Read();
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }


    }
}
