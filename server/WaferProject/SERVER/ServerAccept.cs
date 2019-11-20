using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace WaferProject.SERVER
{
    class ServerAccept
    {
        TcpClient tc;
        MainForm mf;
        public ServerAccept(TcpClient tc, MainForm mf)
        {
            this.tc = tc;
            this.mf = mf;
        }
        public delegate void MsgEvent(string strMsg);
        private void Accept_MsgRun(string strMsg)
        {
            if (mf.InvokeRequired)
            {
                mf.Invoke(new MsgEvent(mf.Log), new object[] { strMsg });
            }
        }
        public void Accept()
        {
            // 읽어올 데이터를 버퍼로 저장하기 위해 1024크기로 초기화
            byte[] buff = new byte[4096];

            Socket c = tc.Client;
            IPEndPoint ip_point = (IPEndPoint)c.RemoteEndPoint;
            string ip = ip_point.Address.ToString();

            /* 스트림 대기 시간 */
            //stream.ReadTimeout = 5000;

            try
            {
                NetworkStream stream = tc.GetStream();
                //Console.ForegroundColor = ConsoleColor.DarkGreen;
                Accept_MsgRun(ip + " ::: " + "CLIENT START");
                //Console.ForegroundColor = ConsoleColor.White;
                // 클라이언트에서 받은 메시지 크기를 설정한다.
                int nbytes;

                nbytes = stream.Read(buff, 0, buff.Length);

                //prt_Log("<<< DATA >>>");
                //prt_Log(Encoding.UTF8.GetString(buff, 0, nbytes));
                //Console.WriteLine("하쒸");
                // 데이터 파싱
                //if (buff.Length > 5 || nbytes != 0)
                if (buff.Length > 5)
                {
                    Parser p = new Parser(buff, mf);

                    byte[] type_data = new byte[1] { 0x80 };
                    // data  
                    string data = p.parsing();
                    // data를 바이트형태로 변환
                    byte[] json_data = Encoding.UTF8.GetBytes(data);
                    /* data 길이를 바이트형태로 저장
                    ★ 빅 엔디안 // 리틀 엔디안 자동 변환 ★ */
                    byte[] length_data = BitConverter.GetBytes(IPAddress.HostToNetworkOrder(json_data.Length));

                    byte[] buff_recv = new byte[type_data.Length + length_data.Length + json_data.Length];

                    System.Buffer.BlockCopy(type_data, 0, buff_recv, 0, type_data.Length);
                    System.Buffer.BlockCopy(length_data, 0, buff_recv, type_data.Length, length_data.Length);
                    System.Buffer.BlockCopy(json_data, 0, buff_recv, (type_data.Length + length_data.Length), json_data.Length);

                    //IPAddress.NetworkToHostOrder();
                    //IPAddress.HostToNetworkOrder();

                    Accept_MsgRun("보낼데이터: " + data);

                    // Echo 이기 때문에 다시 데이터를 클라이언트로 보내줌.
                    stream.Write(buff_recv, 0, buff_recv.Length);
                }
                else Accept_MsgRun("data format error , time out");

            }
            catch (Exception e)
            {
                Accept_MsgRun("Accept error!! : " + e.ToString());
            }
            finally
            {
                //Console.WriteLine();
                //Console.ForegroundColor = ConsoleColor.DarkGreen;
                Accept_MsgRun(ip + " ::: " + "CLIENT END");
                //Console.ForegroundColor = ConsoleColor.White;
                //Console.WriteLine();
                //stream.Close();
                tc.Close();
            }

        }
    }
}
