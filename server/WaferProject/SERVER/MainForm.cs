using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WaferProject.INFO;

namespace WaferProject.SERVER
{
    public partial class MainForm : MetroFramework.Forms.MetroForm
    {
        public MainForm()
        {
            InitializeComponent();
            
        }
        public void Log(string msg)
        {
            //this.listBox1.Items.Add("[" + DateTime.Now.ToString() +  "] " + msg);
            //this.listBox1.SelectedIndex = this.listBox1.Items.Count - 1;
            //this.listBox1.SelectedIndex = -1;

            this.richTextBox1.AppendText("[" + DateTime.Now.ToString() + "]    " + msg +"\n");
            this.richTextBox1.ScrollToCaret();
        }
        public void Start_Tcp()
        {
            IngotFlagInfo.ingotFlag = "0";
            IngotFlagInfo.ingotMake = "0";
            IngotFlagInfo.fan = "0";
            IngotFlagInfo.heat = "0";

            String STR_IP = "220.69.249.241";
            int PORT = 23232;

            try
            {
                // TCP 리스너 연결 및 스타트
                TcpListener listener = new TcpListener(IPAddress.Parse(STR_IP), PORT);
                listener.Start();

                Thread.Sleep(1000);
                Log("서버 : " + STR_IP + ":" + PORT.ToString());
                Log("서버가 연결되었습니다.");
                while (true)
                {
                    TcpClient tc = listener.AcceptTcpClient();
                    NetworkStream stream = tc.GetStream();

                    ServerAccept sa = new ServerAccept(tc, stream);
                    sa.prt_Log += new prt(Log);
                    Thread t1 = new Thread(new ThreadStart(sa.Accept));
                    t1.IsBackground = true;
                    t1.Start();
                }
            }
            catch (SocketException e)
            {
                //Console.ForegroundColor = ConsoleColor.Red;
                Log("Main Error : " + e.ToString());
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Thread start_th = new Thread(new ThreadStart(Start_Tcp));
            start_th.IsBackground = true;
            start_th.Start();    
        }
    }
}
