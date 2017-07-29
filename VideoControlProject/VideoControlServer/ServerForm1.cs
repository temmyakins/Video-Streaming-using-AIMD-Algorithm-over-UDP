using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VideoControlServer
{
    public partial class ServerForm1 : Form
    {
        public string currentVideo { get; set; }
        public string mp4Path { get; set; }
        public string bitRate{ get; set; }
        public string serverPath { get; set; }
        public string outputPath { get; set; }
        public const int numOfClips = 6;
        public double videoDuration = 0.0;
        public string currentFile { get; set; }
        public int count = 0;
        public ServerForm1()
        {
            serverPath = Directory.GetCurrentDirectory();
            outputPath = Directory.GetCurrentDirectory() + "\\Output\\";
            InitializeComponent();

        }

        private void loadVideoBtn_Click(object sender, EventArgs e)
        {

            //User chooses video file
            OpenFileDialog fileChoose = new OpenFileDialog();

            //set filter properties
            fileChoose.SupportMultiDottedExtensions = false;
            fileChoose.Filter = "(*wmv)|*.wmv|(*avi)|*.avi|(*3gp)|*.3gp|(*mp4)|*.mp4";
            fileChoose.Multiselect = false;
            fileChoose.ShowDialog();


            //Copy video file to application directory
          

            var serverPath2 = serverPath + "\\Videos\\";
            
            var fileName = fileChoose.FileName;
            
            var fileName2 = Path.GetFileName(fileName);
            var fileNamewithoutExt = Path.GetFileNameWithoutExtension(fileName);
            currentFile = fileNamewithoutExt;

            serverPath += "\\Videos\\" + fileName2;
            //  this returns all the files in the video folder into an array of strings
            var files = Directory.GetFiles(serverPath2);
            var ouputFiles = Directory.GetFiles(outputPath);
            var outputFilePath = outputPath + fileNamewithoutExt + ".mp4";

            if(files.Contains(serverPath))
            {
                DialogResult result =  MessageBox.Show("This file has been uploaded already, Do you want to Load?", "File Exists", MessageBoxButtons.YesNo);
                if(result.Equals(DialogResult.Yes))
                {
                    axWindowsMediaPlayer1.URL = serverPath;
                    var mediaInfo = axWindowsMediaPlayer1.newMedia(serverPath);
                    videoDuration = mediaInfo.duration;
                    //MessageBox.Show(mediaInfo.duration.ToString());
                }
                else
                {

                }
            }
            else
            {
                File.Copy(fileName, serverPath);
                //To load the video on the media player
                axWindowsMediaPlayer1.URL = serverPath;
                var mediaInfo = axWindowsMediaPlayer1.newMedia(serverPath);
                videoDuration = mediaInfo.duration;
                //MessageBox.Show(mediaInfo.duration.ToString());
            }

            if(ouputFiles.Contains(outputFilePath))
            {
                mp4Path = outputFilePath;
            }

            currentVideo = serverPath;
           
        }

        private void encodeVideoBtn_Click(object sender, EventArgs e)
        {
            


           if(String.IsNullOrWhiteSpace(currentVideo))
            {
                MessageBox.Show("Please Load a video first!!");
                return;
            }

            var fileNamewithoutExt = Path.GetFileNameWithoutExtension(currentVideo);
            currentFile = fileNamewithoutExt;
            var ouputFiles = Directory.GetFiles(outputPath);
            var outputFilePath = outputPath + fileNamewithoutExt + ".mp4";
            if (ouputFiles.Contains(outputFilePath))
            {

                mp4Path = outputFilePath;
                MessageBox.Show("Video has already been encoded!!");
                return;
            }


            string appPath = Path.GetDirectoryName(Application.ExecutablePath);
           
            string ffmpegPath = Path.Combine(appPath, "ffmpeg.exe");
            Process p = new Process();
            p.StartInfo.FileName = "cmd.exe";

            bitRate = bitRateComboBox.Text;

            if(String.IsNullOrWhiteSpace(bitRate))
            {
                MessageBox.Show("Please choose a value for bit rate!!");
            }
            else
            {
                bitRate += "k";
                var outVideo = Path.GetFileNameWithoutExtension(currentVideo);
                outVideo = "Output\\" + outVideo +  ".mp4";
                mp4Path = outVideo;
                //string ffmpegArg = @" -y -i " + " " + " \"" + currentVideo + " \"" + " " + " -vn -ar 24000 -ac 1 -ab 320 -f wav ";
                string ffmpegArg = " -i " + " " + " \"" + currentVideo + " \"" + " " + " -codec:v libx264 -profile:v high -preset slow -b:v " + bitRate + " -maxrate 1800k -bufsize 1000k -vf scale=720:576 -threads 0 -r 25 " + outVideo ;


                //p.StartInfo.CreateNoWindow = true;
                //p.StartInfo.RedirectStandardOutput = true;
                //p.StartInfo.RedirectStandardError = true;

                p.StartInfo.Arguments = "/k" + ffmpegPath + ffmpegArg; // escape the quotes

                try
                {
                    p.Start();//Start ffmpeg  

                    //p.BeginErrorReadLine();
                    //p.WaitForExit();

                    p.Close();
                    p.Dispose();//Dispose Resource

                }

                catch (Exception ee)
                {
                    //result = ee.ToString();
                }
            }
            


        }

        private void sendVideoBtn_Click(object sender, EventArgs e)
        {
           

            if(String.IsNullOrWhiteSpace(mp4Path))
            {
                MessageBox.Show("Please encode video first!!");
                return;
            }
            
            Regex rgx = new Regex(@"((1?\d\d?|2[0-4]\d|25[0-5])\.){3}(1?\d\d?|2[0-4]\d|2‌​5[0-5])");
            if(String.IsNullOrWhiteSpace(Client_IP_txt.Text))
            {
                MessageBox.Show("Please enter a client IP Address!!");
                return;
            }
            if(!rgx.IsMatch(Client_IP_txt.Text))
            {
                MessageBox.Show("Please enter a valid Ip address!!");
                return;
            }



            PStream_Exited();

            //Receive reply from Client of number of clips received

            UdpClient udpClient = new UdpClient(1236);


            var remoteEP = new IPEndPoint(IPAddress.Any, 1236);
            //var msgBytes = ASCIIEncoding.ASCII.GetBytes("Video packets sent!!");

            //udpServer.Send(msgBytes, msgBytes.Length, remoteEP);
            var data = udpClient.Receive(ref remoteEP);
            string recievedData = "";
            if (data.Length > 0)
            {
                recievedData = Encoding.ASCII.GetString(data, 0, data.Length);
                int numClipsClientReceved = Convert.ToInt32(recievedData);

                MessageBox.Show(recievedData);
            }


            }
        public void serverThread()
        {
            UdpClient udpClient = new UdpClient(8080);
            while (true)
            {
                IPEndPoint RemoteIpEndPoint = new IPEndPoint(IPAddress.Any, 0);
                Byte[] receiveBytes = udpClient.Receive(ref RemoteIpEndPoint);
                string returnData = Encoding.ASCII.GetString(receiveBytes);
                string txt = RemoteIpEndPoint.Address.ToString() + ":" + returnData.ToString();
                util.log(txt);
               // lbConnections.Items.Add(RemoteIpEndPoint.Address.ToString() + ":" + returnData.ToString());
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Thread thdUDPServer = new Thread(new ThreadStart(serverThread));
            thdUDPServer.Start();
        }

        private void bitRateComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void connectClient_Click(object sender, EventArgs e)
        {
            UdpClient udpServer = new UdpClient(1234);

            while (true)
            {
                var remoteEP = new IPEndPoint(IPAddress.Any, 8080);
                var data = udpServer.Receive(ref remoteEP);
                string recievedData = Encoding.ASCII.GetString(data, 0, data.Length);
                util.log("receive data from " + remoteEP.ToString());
                util.log(recievedData);
                if (recievedData.Contains("IP:"))
                {
                    string[] subStrings = recievedData.Split(':');
                    currentVideo = subStrings[1];
                    bitRate = subStrings[2];
                }
                udpServer.Send(new byte[] { 1 }, 1, remoteEP); // reply back
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(String.IsNullOrWhiteSpace(currentFile))
            {
                MessageBox.Show("Load a Video First!!");
                return;
            }
            if(String.IsNullOrWhiteSpace(Client_IP_txt.Text))
            {
                MessageBox.Show("Please enter a valid IP address!!");
                return;
            }
            UdpClient udpClient = new UdpClient();
            var remoteEP = new IPEndPoint(IPAddress.Parse(Client_IP_txt.Text), 1236);
            //    udpClient.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);

            //var remoteEP = new IPEndPoint(IPAddress.Any, 1234);
            var msg = currentFile;
            Byte[] msgBytes = Encoding.ASCII.GetBytes(msg);

            udpClient.Send(msgBytes, msgBytes.Length, remoteEP);
            //var data = udpServer.Receive(ref remoteEP);
            //string recievedData = Encoding.ASCII.GetString(data, 0, data.Length);
            //util.log("receive data from " + remoteEP.ToString());
            //util.log(recievedData);
            //if (recievedData.Contains("IP:"))
            //{
            //    string[] subStrings = recievedData.Split(':');
            //    currentVideo = subStrings[1];
            //    bitRate = subStrings[2];
            //}
            //udpServer.Send(new byte[] { 1 }, 1, remoteEP); // reply back
            udpClient.Close();
        }

        public void SplitVideoIntoClips()
        {
            double offset = 0.0;
            offset = videoDuration / numOfClips;

            double[] startTime = new double[6];
            double stTime = 0.0;

            var directoryPath = Directory.GetCurrentDirectory() + "\\Output\\" + currentFile + "\\";
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            for (int i = 0; i < 6; i++)
            {
                stTime += offset;
                startTime[i] = stTime;

                Process pStream = new Process();
                pStream.StartInfo.FileName = "cmd.exe";//
                                                       //p.StartInfo.RedirectStandardError = true;
                                                       //p.StartInfo.UseShellExecute = false;
                                                       //p.StartInfo.Arguments = " -y -i " + filename + " -vn -ar 24000 -ac 1 -ab 320 -f wav " + audiofilename;//
                string appPath = Path.GetDirectoryName(Application.ExecutablePath); //AppDomain.CurrentDomain.BaseDirectory
                                                                                    //string appPath = AppDomain.CurrentDomain.BaseDirectory;

                var ffmpegPath = Path.Combine(appPath, "ffmpeg.exe");
                mp4Path = Path.Combine(appPath, mp4Path);
                //mp4Path = @"C:\Projects\VideoEncoder\VideoEncoder\bin\Debug\Videos\Hurricanenews.mp4";

                string ffmpegArg = " -i " + " " + " \"" + mp4Path + " \"" + " " + " -ss " + stTime + " -t " + offset + " Output/" + currentFile + "/" + currentFile + i.ToString() + ".mp4";


                pStream.StartInfo.Arguments = "/c " + ffmpegPath + ffmpegArg; // escape the quotes
                                                                              //pStream.Exited += P_Exited;

                try
                {
                    pStream.Start();//Start ffmpeg  

                    //p.BeginErrorReadLine();
                    //p.WaitForExit();

                    if(i == 5)
                    {
                        count = 5;
                    }
                    
                    pStream.Close();

                    //pStream.Exited += PStream_Exited;
                    pStream.Dispose();//Dispose Resource

                }

                catch (Exception ee)
                {
                    //result = ee.ToString();
                }
            }
        }

        private void PStream_Exited()
        {
            
                string client_IP = "";
                client_IP = Client_IP_txt.Text;

                for (int i = 0; i < 6; i++)
                {
                    Process pStream = new Process();
                    pStream.StartInfo.FileName = "cmd.exe";//
                                                           //p.StartInfo.RedirectStandardError = true;
                                                           //p.StartInfo.UseShellExecute = false;
                                                           //p.StartInfo.Arguments = " -y -i " + filename + " -vn -ar 24000 -ac 1 -ab 320 -f wav " + audiofilename;//
                    string appPath = Path.GetDirectoryName(Application.ExecutablePath); //AppDomain.CurrentDomain.BaseDirectory
                                                                                        //string appPath = AppDomain.CurrentDomain.BaseDirectory;

                    var ffmpegPath = Path.Combine(appPath, "ffmpeg.exe");
                    mp4Path = "Output\\" + currentFile + "\\" + currentFile + i.ToString() + ".mp4";
                    mp4Path = Path.Combine(appPath, mp4Path);
                    //mp4Path = @"C:\Projects\VideoEncoder\VideoEncoder\bin\Debug\Videos\Hurricanenews.mp4";

                    string ffmpegArg = " -i " + " " + " \"" + mp4Path + " \"" + " " + " -c copy -vcodec libx264 -profile:v high -g 60 -vb 150000 -b:v 1500k -strict experimental -acodec aac -ab 96000 -threads 4 -ar 48000 -ac 2 -vbsf h264_mp4toannexb -f mpegts udp://" + client_IP + ":1234";


                    pStream.StartInfo.Arguments = "/k " + ffmpegPath + ffmpegArg; // escape the quotes
                                                                                  //pStream.Exited += P_Exited;

                    try
                    {
                        pStream.Start();//Start ffmpeg  

                        //p.BeginErrorReadLine();
                        //p.WaitForExit();


                        pStream.Close();
                        pStream.Dispose();//Dispose Resource

                    }

                    catch (Exception ee)
                    {
                        //result = ee.ToString();
                    }
                
            }
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SplitVideoIntoClips();
        }
    }
}
