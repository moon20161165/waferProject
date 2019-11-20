using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace WOMS
{
    //서버에 보낼 JSON형식의 데이터를 파싱하는 클래스
    class JsonParsing
    {
        //비밀번호 변경시 서버에 보내는 데이터를 파싱하는 함수
        public byte[] UpdateParse(string id, string pw)
        {
            var json = new JObject();
            json.Add("id", id);
            json.Add("pw", pw);
            var pwUpdate = new JObject();
            pwUpdate.Add("pw_update", json);
            return JtoB(pwUpdate);
        }
        //로그인시 서버에 보내는 데이터를 파싱하는 함수
        public byte[] LoginParse(string id, string pw)
        {
            var json = new JObject();
            json.Add("id", id);
            json.Add("pw", pw);
            var login = new JObject();
            login.Add("login", json);
            return JtoB(login);
        }
        //사용자를 추가할 때 서버에 보내는 데이터를 파싱하는 함수
        public byte[] UserParse(string name, string id, string right, string position)
        {
            var json = new JObject();
            json.Add("name", name);
            json.Add("id", id);
            json.Add("right", right);
            json.Add("position", position);
            var user = new JObject();
            user.Add("user_register", json);
            return JtoB(user);
        }

        public byte[] DataOperParse(string operId, int cnt, int page)
        {
            var json = new JObject();
            json.Add("oper_id", operId);
            json.Add("cnt", cnt);
            json.Add("page", page);
            var data = new JObject();
            data.Add("data_oper", json);
            return JtoB(data);
        }
        //장비를 추가할 때 서버에 보내는 데이터를 파싱하는 함수
        public byte[] EquipParse(string equip_Id, string equip_Type, string oper_Id, string equip_Comm, string equip_Man)
        {
            var json = new JObject();
            json.Add("equip_id", equip_Id);
            json.Add("equip_type", equip_Type);
            json.Add("oper_id", oper_Id);
            json.Add("equip_comm", equip_Comm);
            json.Add("equip_man", equip_Man);
            var equip = new JObject();
            equip.Add("equip_add", json);
            return JtoB(equip);
        }
        //코드관리에서 코드 수정시 서버에 보내는 데이터를 파싱하는 함수
        public byte[] CodeUpdateParse(string code_id, string code_comm, string code_att_fir, string code_att_sec, string code_att_thr, string code_att_four, string code_att_fif, string code_att_six, string code_att_sev, string code_att_eig, string code_att_nin, string code_att_ten)
        {
            var json = new JObject();
            json.Add("code_id", code_id);
            json.Add("code_comm", code_comm);
            json.Add("code_att_fir", code_att_fir);
            json.Add("code_att_sec", code_att_sec);
            json.Add("code_att_thr", code_att_thr);
            json.Add("code_att_four", code_att_four);
            json.Add("code_att_fif", code_att_fif);
            json.Add("code_att_six", code_att_six);
            json.Add("code_att_sev", code_att_sev);
            json.Add("code_att_eig", code_att_eig);
            json.Add("code_att_nin", code_att_nin);
            json.Add("code_att_ten", code_att_ten);
            var codeUpdate = new JObject();
            codeUpdate.Add("code_update", json);
            return JtoB(codeUpdate);
        }
        //코드관리에서 코드 추가시 서버에 보내는 데이터를 파싱하는 함수
        public byte[] CodeAddParse(string code_Id, string code_Type, string code_Comm)
        {
            var json = new JObject();
            json.Add("code_id", code_Id);
            json.Add("code_type", code_Type);
            json.Add("code_comm", code_Comm);
            var codeAdd = new JObject();
            codeAdd.Add("code_add", json);
            return JtoB(codeAdd);
        }
        //제품정보관리에서 제품정보 추가시 서버에 보내는 데이터를 파싱하는 함수
        public byte[] MSCodeAddParse(string mscodeId, string corpName, string corpComm, string corpMan, string routeId)
        {
            var json = new JObject();
            json.Add("mscode", mscodeId);
            json.Add("corp_name", corpName);
            json.Add("corp_comm", corpComm);
            json.Add("corp_man", corpMan);
            json.Add("route_id", routeId);
            var mscode = new JObject();
            mscode.Add("mscode_add", json);
            return JtoB(mscode);
        }
        //웨이퍼관리에서 웨이퍼 제작시 서버에 보내는 데이터를 파싱하는 함수
        public byte[] WaferMakeParse(string mscode, string qty, string wafer_comm, string maker)
        {
            var json = new JObject();
            json.Add("mscode", mscode);
            json.Add("qty", qty);
            json.Add("wafer_comm", wafer_comm);
            json.Add("wafer_maker", maker);
            var waferMake = new JObject();
            waferMake.Add("wafer_add", json);
            return JtoB(waferMake);
        }
        //경로관리에서 경로 추가시 서버에 보내는 데이터를 파싱하는 함수
        public byte[] RouteParse(params string[] route)
        {
            var routeAdd = new JArray();
            for(int i = 0; i < route.Length; i++)
            {
                var json = new JObject();
                json.Add("curr_route", route[i]);
                if (i == route.Length - 1)
                {
                    json.Add("next_route", "");
                }
                else
                {
                    json.Add("next_route", route[i + 1]);
                }
                routeAdd.Add(json);
            }
            var routeJson = new JObject();
            routeJson.Add("route_add", routeAdd);
            return JtoB(routeJson);
        }
        //모든 파싱함수의 JSON형식을 매개변수로 받아서 JSON혁식을 byte[]형식으로 바꿔주는 함수
        public byte[] JtoB(JObject json)
        {
            string str_json = json.ToString();
            byte[] json_data = Encoding.UTF8.GetBytes(str_json);

            return json_data;
        }
    }
}
