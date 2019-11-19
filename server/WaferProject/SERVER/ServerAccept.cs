using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace WaferProject.SERVER
{
    public delegate void prt(string msg);

    class ServerAccept
    {
        TcpClient tc;
        NetworkStream stream;

        public event prt prt_Log;

        public ServerAccept(TcpClient tc, NetworkStream stream)
        {
            this.tc = tc;
            this.stream = stream;
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
                //Console.ForegroundColor = ConsoleColor.DarkGreen;
                prt_Log(ip + " ::: " + "CLIENT START");
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
                    Parser p = new Parser(buff, prt_Log);

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

                    prt_Log("보낼 데이터 : " + data);

                    // Echo 이기 때문에 다시 데이터를 클라이언트로 보내줌.
                    stream.Write(buff_recv, 0, buff_recv.Length);
                }
                else prt_Log("data format error , time out");

            }
            catch (Exception e)
            {
                prt_Log("Accept error!! : " + e.ToString());
            }
            finally
            {
                //Console.WriteLine();
                //Console.ForegroundColor = ConsoleColor.DarkGreen;
                prt_Log(ip + " ::: " + "CLIENT END");
                //Console.ForegroundColor = ConsoleColor.White;
                //Console.WriteLine();
                //stream.Close();
                tc.Close();
            }

        }
    }
}
