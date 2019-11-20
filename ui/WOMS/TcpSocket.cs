using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WOMS
{
    //Tcp통신을 위한 클래스
    class TcpSocket
    {
        TcpClient sockClient;
        NetworkStream stream;
        //서버와의 연결을 시작하는 함수
        public TcpClient ConnectServer()
        {
            try
            {
                // 해당 서버의 아이피주소와 포트번호 설정.
                sockClient = new TcpClient("220.69.249.241", 23232);

                return sockClient;
            }
            catch (SocketException e)
            {
                Console.WriteLine(e.ToString());
            }
            return sockClient;
        }
        //받아오는 데이터를 파싱하는 함수
        public byte[] DataParse(byte[] json_data)
        {
            byte[] buff;
            byte[] type_data = new byte[1] { 0x50 };
            byte[] length_data = BitConverter.GetBytes(IPAddress.HostToNetworkOrder(json_data.Length));

            buff = new byte[type_data.Length + json_data.Length + length_data.Length];

            System.Buffer.BlockCopy(type_data, 0, buff, 0, type_data.Length);
            System.Buffer.BlockCopy(length_data, 0, buff, type_data.Length, length_data.Length);
            System.Buffer.BlockCopy(json_data, 0, buff, (type_data.Length + length_data.Length), json_data.Length);

            return buff;
        }
        //파싱한 데이트를 서버로 보내는 함수
        public void Request(byte[] buff)
        {
            stream = sockClient.GetStream();
            stream.Write(buff, 0, buff.Length);
        }
        //서버와의 연결을 해제하는 함수
        public int Close()
        {
            try
            {
                if (sockClient != null && stream != null)
                {
                    stream.Close();
                    sockClient.Close();
                    return 1;
                }
            }
            catch (SocketException e)
            {
                Console.WriteLine(e.ToString());
            }
            return 0;
        }
        //서버가 보내주는 데이터를 받아서 응답하는 함수
        public JObject Response()
        {

            byte[] lenBuf = new byte[5];
            stream.Read(lenBuf, 0, lenBuf.Length);
            int type_data = lenBuf[0]; //0x80
            /* ★ 빅 엔디안 // 리틀 엔디안 자동 변환 ★ */
            int len_data = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(lenBuf, 1));

            byte[] outbuf = new byte[len_data];
            int nbytes = 0;
            int num = 0;
            while(true)
            {
                nbytes += stream.Read(outbuf, num, outbuf.Length - num);
                
                if (nbytes == len_data)
                    break;
                else
                    num = nbytes;
            }
            string json_data = Encoding.UTF8.GetString(outbuf, 0, nbytes);
            JObject json = null;
            if (type_data != 128)
            {
                Console.WriteLine("시부럴");
                return json;
            }
            Console.WriteLine("받은 데이터 : {0}", json_data);

            json = JObject.Parse(json_data);
            return json;
        }
    }
}
