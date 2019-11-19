
/* 참조 -> NuGet 패키지 관리 -> Newtonsoft.Json 패키지 다운로드 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using WaferProject.DB;
using WaferProject.INFO;

namespace WaferProject.SERVER
{
    class Parser
    {
        byte[] buff;
        public event prt prt_Log;
        public Parser(byte[] buff, prt prt_Log)
        {
            this.buff = buff;
            this.prt_Log = prt_Log;
        }
        public string parsing()
        {
            string data;
            /* 요청 & 응답 */
            string _type = Convert.ToString(buff[0], 16);
            /* 메시지 길이 */
            int data_len = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buff, 1));
            /* 메시지 내용 */
            byte[] json_buff = new byte[data_len];


            DataDisp data_disp = new DataDisp(prt_Log);

            /* 라즈베리파이 -> 서버 */
            if (_type.Equals("40")) // request
            {
                // buff -> json_buff copy
                System.Buffer.BlockCopy(buff, 5, json_buff, 0, data_len);
                // data : byte -> string 
                data = Encoding.UTF8.GetString(json_buff, 0, data_len);

                JObject json_data = JObject.Parse(data);

                prt_Log(json_data.ToString());

                return data_disp.RaspDataDisp(json_data);
            }
            /* 클라이언트 -> 서버 */
            else if (_type.Equals("50"))
            {
                /* 메시지 내용 -> BYTE배열로 COPY */
                System.Buffer.BlockCopy(buff, 5, json_buff, 0, data_len);
                /* 메시지 내용 형 변환 */
                data = Encoding.UTF8.GetString(json_buff, 0, data_len);

                JObject json_data = JObject.Parse(data);

                return data_disp.ClientDataDisp(json_data);
            }
            /* 에러 처리 */
            else
            {
                prt_Log("message type error.");
            }

            return null;
        }
    }
}
