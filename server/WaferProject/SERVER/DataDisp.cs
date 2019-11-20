using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaferProject.INFO;
using WaferProject.DB;

namespace WaferProject.SERVER
{
    class DataDisp
    {
        MainForm mf;
        public DataDisp(MainForm mf)
        {
            this.mf = mf;
        }
        public delegate void MsgEvent(string strMsg);
        private void Data_MsgRun(string strMsg)
        {
            if (mf.InvokeRequired)
            {
                mf.Invoke(new MsgEvent(mf.Log), new object[] { strMsg });
            }
        }

        /*  <<클라이언트 -> 서버>>  요청 및 응답 처리  */
        public string ClientDataDisp(JObject json_data)
        {
            
            foreach (var item in json_data)
            {
                /* 로그인 */
                if (item.Key.Equals("login"))
                {
                    string userId = json_data["login"]["id"].ToString();
                    string userPw = json_data["login"]["pw"].ToString();

                    Data_MsgRun(userId + " " + userPw);

                    var json = new JObject();

                    Database db = new Database();
                    UserInfo ui = db.login_check(userId, userPw);
                    if (!ui.getUser_name().Equals(""))
                    {
                        Data_MsgRun("로그인 성공");
                        json.Add("login_name", ui.getUser_name());
                    }
                    else
                    {
                        Data_MsgRun("로그인 실패");
                        json.Add("login_name", "null");
                    }

                    return json.ToString();

                }
                /* 비밀번호 변경*/
                else if (item.Key.Equals("pw_update"))
                {
                    string id = json_data["pw_update"]["id"].ToString();
                    string pw = json_data["pw_update"]["pw"].ToString();

                    var json = new JObject();

                    Database db = new Database();
                    if (db.password_update(id, pw))
                    {
                        Data_MsgRun("패스워드 변경 성공");
                        json.Add("pw_update", "1");
                    }
                    else
                    {
                        Data_MsgRun("패스워드 변경 실패");
                        json.Add("pw_update", "0");
                    }

                    return json.ToString();
                }
                /* 회원 등록 */
                else if (item.Key.Equals("user_register"))
                {
                    string name = json_data["user_register"]["name"].ToString();
                    string id = json_data["user_register"]["id"].ToString();
                    string right = json_data["user_register"]["right"].ToString();
                    string position = json_data["user_register"]["position"].ToString();

                    var json = new JObject();

                    Database db = new Database();
                    if (db.sign_up(name, id, position, right))
                    {
                        Data_MsgRun("회원가입 성공");
                        json.Add("regis_status", "1");
                    }
                    else
                    {
                        Data_MsgRun("회원가입 실패");
                        json.Add("regis_status", "0");
                    }

                    return json.ToString();
                }
                /* 사용자 관리 */
                else if (item.Key.Equals("users"))
                {
                    Database db = new Database();
                    List<UserInfo> ui = new List<UserInfo>();
                    ui = db.user_select();

                    var jsonData = new JObject();
                    var jsonArray = new JArray();

                    foreach (UserInfo e in ui)
                    {
                        var json = new JObject();
                        json.Add("user_id", e.getUser_id());
                        json.Add("user_pw", e.getUser_pw());
                        json.Add("user_name", e.getUser_name());
                        json.Add("user_pos", e.getUser_pos());
                        json.Add("user_right", e.getUser_right());

                        jsonArray.Add(json);

                    }

                    jsonData.Add("users", jsonArray);

                    Data_MsgRun("전체 사용자 정보 응답");

                    return jsonData.ToString();

                }
                /* 사용자 삭제 */
                else if (item.Key.Equals("users_delete"))
                {
                    string id = json_data["users_delete"].ToString();

                    var json = new JObject();

                    Database db = new Database();
                    if (db.user_delete(id))
                    {
                        Data_MsgRun("사용자 삭제 성공");
                        json.Add("users_del_state", "1");
                    }
                    else
                    {
                        Data_MsgRun("사용자 삭제 실패");
                        json.Add("users_del_state", "0");
                    }

                    return json.ToString();
                }
                /* 장비 관리 */
                else if (item.Key.Equals("equips"))
                {
                    Database db = new Database();
                    List<OperInfo> oi = new List<OperInfo>();
                    oi = db.oper_select();

                    var jsonData = new JObject();
                    var jsonArray = new JArray();

                    foreach (OperInfo e in oi)
                    {
                        jsonArray.Add(e.getOperId());
                    }

                    jsonData.Add("equips_oper_id", jsonArray);

                    Data_MsgRun("장비 이름 정보 응답");

                    return jsonData.ToString();
                }
                /* 장비 등록 */
                else if (item.Key.Equals("equip_add"))
                {
                    string equipId = json_data["equip_add"]["equip_id"].ToString();
                    string equipType = json_data["equip_add"]["equip_type"].ToString();
                    string equipComm = json_data["equip_add"]["equip_comm"].ToString();
                    string equipManager = json_data["equip_add"]["equip_man"].ToString();
                    string operId = json_data["equip_add"]["oper_id"].ToString();

                    var json = new JObject();

                    Database db = new Database();
                    if (db.equip_insert(equipId, equipType, equipComm, equipManager, operId))
                    {
                        Data_MsgRun("장비 등록 성공");
                        json.Add("equip_add_status", "1");
                    }
                    else
                    {
                        Data_MsgRun("장비 등록 실패");
                        json.Add("equip_add_status", "0");
                    }
                    return json.ToString();
                }
                /* 공정에 따른 장비 검색 */
                else if (item.Key.Equals("oper_select_id"))
                {
                    string oper_select_id = json_data["oper_select_id"].ToString();

                    Database db = new Database();
                    List<EquipInfo> ei = new List<EquipInfo>();
                    ei = db.equip_select(oper_select_id);

                    var jsonData = new JObject();
                    var jsonArray = new JArray();

                    foreach (EquipInfo e in ei)
                    {
                        var json = new JObject();
                        json.Add("oper_equip_id", e.getEquipId());
                        json.Add("oper_equip_type", e.getEquipType());
                        json.Add("oper_equip_state", e.getEquipState());
                        json.Add("oper_equip_comm", e.getEquipComm());
                        json.Add("oper_equip_rec_date", e.getEquipRecDate());
                        json.Add("oper_equip_man", e.getEquipManager());
                        json.Add("oper_equip_update", e.getEquipUpdate());
                        jsonArray.Add(json);

                    }

                    jsonData.Add("oper_equip", jsonArray);

                    Data_MsgRun("공정 아이디로 장비 정보 응답");

                    return jsonData.ToString();

                }
                /* 장비로 장비 이벤트 검색 */
                else if (item.Key.Equals("equip_select"))
                {
                    string equip_select = json_data["equip_select"].ToString();

                    Database db = new Database();
                    List<EquipEventInfo> eei = new List<EquipEventInfo>();
                    eei = db.equip_event_select(equip_select);

                    var jsonData = new JObject();
                    var jsonArray = new JArray();

                    foreach (EquipEventInfo e in eei)
                    {
                        var json = new JObject();
                        json.Add("equip_event_id", e.getEquipEventId());
                        json.Add("equip_id", e.getEquipId());
                        json.Add("equip_event_type", e.getEquipEventType());
                        json.Add("equip_event_time", e.getEquipEvemtTime());
                        json.Add("equip_state", e.getEquipState());
                        json.Add("repair_man", e.getRepairManager());
                        jsonArray.Add(json);
                    }
                    jsonData.Add("equip_event_view", jsonArray);

                    Data_MsgRun("장비 아이디로 장비 정보 응답");

                    return jsonData.ToString();

                }
                /* 코드 관리 조회 */
                else if (item.Key.Equals("code_types"))
                {
                    Database db = new Database();
                    List<CodeNameInfo> cni = new List<CodeNameInfo>();
                    cni = db.code_select();
                    var jsonData = new JObject();
                    var jsonArray = new JArray();

                    foreach (CodeNameInfo e in cni)
                    {
                        jsonArray.Add(e.getCodeType());
                    }

                    jsonData.Add("code_types", jsonArray);

                    Data_MsgRun("코드 타입 정보 응답");

                    return jsonData.ToString();
                }
                /* 코드ID로 해당 코드 상세조회 */
                else if (item.Key.Equals("code_id_select"))
                {
                    var jsonData = new JObject();
                    Database db = new Database();
                    string code_id_select = json_data["code_id_select"].ToString();
                    //string codeType = null;
                    List<CodeNameInfo> cni = new List<CodeNameInfo>();
                    List<CodeInfo> ci = new List<CodeInfo>();

                    ci = db.code_view_select(code_id_select);


                    var json = new JObject();

                    foreach (CodeInfo e in ci)
                    {
                        json.Add("code_id", e.getCodeId());
                        json.Add("code_comm", e.getCodeComm());
                        json.Add("code_att_fir", e.getCodeAttFir());
                        json.Add("code_att_sec", e.getCodeAttSec());
                        json.Add("code_att_thr", e.getCodeAttThr());
                        json.Add("code_att_four", e.getCodeAttFour());
                        json.Add("code_att_fif", e.getCodeAttFif());
                        json.Add("code_att_six", e.getCodeAttSix());
                        json.Add("code_att_sev", e.getCodeAttSev());
                        json.Add("code_att_eig", e.getCodeAttEig());
                        json.Add("code_att_nin", e.getCodeAttNin());
                        json.Add("code_att_ten", e.getCodeAttTen());

                        //codeType = e.getCodeType();
                    }

                    jsonData.Add("code_view", json);

                    Data_MsgRun("코드 아이디로 해당 코드 상세 조회 응답");

                    return jsonData.ToString();
                }
                /* 코드 종류에 따른 코드ID 조회 */
                else if (item.Key.Equals("code_type_select"))
                {
                    string code_select = json_data["code_type_select"].ToString();

                    Database db = new Database();
                    List<CodeInfo> ci = new List<CodeInfo>();
                    List<CodeNameInfo> cni = new List<CodeNameInfo>();
                    ci = db.code_type_select(code_select);

                    var jsonData = new JObject();
                    var jsonArray = new JArray();

                    foreach (CodeInfo e in ci)
                    {
                        jsonArray.Add(e.getCodeId());
                    }
                    jsonData.Add("type_select_id", jsonArray);

                    cni = db.code_name_select(code_select);

                    var json2 = new JObject();

                    foreach (CodeNameInfo e in cni)
                    {
                        json2.Add("att_fir", e.getAttFirst());
                        json2.Add("att_sec", e.getAttSecond());
                        json2.Add("att_thr", e.getAttThird());
                        json2.Add("att_four", e.getAttFourth());
                        json2.Add("att_fif", e.getAttFifth());
                        json2.Add("att_six", e.getAttSixth());
                        json2.Add("att_sev", e.getAttSeventh());
                        json2.Add("att_eig", e.getAttEighth());
                        json2.Add("att_nin", e.getAttNinth());
                        json2.Add("att_ten", e.getAttTenth());
                    }

                    jsonData.Add("code_att", json2);

                    Data_MsgRun("코드 종류에 따른 코드 아이디 정보 응답");

                    return jsonData.ToString();
                }
                /* 코드 추가 */
                else if (item.Key.Equals("code_add"))
                {
                    string code_id = json_data["code_add"]["code_id"].ToString();
                    string code_type = json_data["code_add"]["code_type"].ToString();
                    string code_comm = json_data["code_add"]["code_comm"].ToString();

                    var json = new JObject();

                    Database db = new Database();
                    if (db.code_insert(code_id, code_type, code_comm))
                    {
                        Data_MsgRun("코드 정보 추가 성공");
                        json.Add("code_add_status", "1");
                    }
                    else
                    {
                        Data_MsgRun("코드 정보 추가 실패");
                        json.Add("code_add_status", "0");
                    }
                    return json.ToString();
                }
                /* 코드 수정 */
                else if (item.Key.Equals("code_update"))
                {
                    CodeInfo ci = new CodeInfo();

                    ci.setCodeId(json_data["code_update"]["code_id"].ToString());
                    ci.setCodeComm(json_data["code_update"]["code_comm"].ToString());
                    ci.setCodeAttFir(json_data["code_update"]["code_att_fir"].ToString());
                    ci.setCodeAttSec(json_data["code_update"]["code_att_sec"].ToString());
                    ci.setCodeAttThr(json_data["code_update"]["code_att_thr"].ToString());
                    ci.setCodeAttFour(json_data["code_update"]["code_att_four"].ToString());
                    ci.setCodeAttFif(json_data["code_update"]["code_att_fif"].ToString());
                    ci.setCodeAttSix(json_data["code_update"]["code_att_six"].ToString());
                    ci.setCodeAttSev(json_data["code_update"]["code_att_sev"].ToString());
                    ci.setCodeAttEig(json_data["code_update"]["code_att_eig"].ToString());
                    ci.setCodeAttNin(json_data["code_update"]["code_att_nin"].ToString());
                    ci.setCodeAttTen(json_data["code_update"]["code_att_ten"].ToString());

                    var json = new JObject();

                    Database db = new Database();
                    if (db.code_update(ci))
                    {
                        Data_MsgRun("코드 정보 수정 성공");
                        json.Add("code_update_status", "1");
                    }
                    else
                    {
                        Data_MsgRun("코드 정보 수정 실패");
                        json.Add("code_update_status", "0");
                    }
                    return json.ToString();
                }
                /* 코드 삭제 */
                else if (item.Key.Equals("code_del_id"))
                {
                    string id = json_data["code_del_id"].ToString();
                    Data_MsgRun(id);

                    var json = new JObject();

                    Database db = new Database();
                    if (db.code_delete(id))
                    {
                        Data_MsgRun("코드 정보 삭제 성공");
                        json.Add("code_del_status", "1");
                    }
                    else
                    {
                        Data_MsgRun("코드 정보 삭제 실패");
                        json.Add("code_del_status", "0");
                    }

                    return json.ToString();
                }
                /* 웨이퍼 관리(전체조회) */
                else if (item.Key.Equals("wafer_manage"))
                {
                    Database db = new Database();
                    List<WaferInfo> wi = new List<WaferInfo>();
                    wi = db.wafer_select();

                    var jsonData = new JObject();
                    var jsonArray = new JArray();

                    foreach (WaferInfo e in wi)
                    {
                        var json = new JObject();
                        json.Add("wafer_id", e.getWaferId());
                        json.Add("ingot_id", e.getIngotId());
                        json.Add("block_id", e.getBlockId());
                        json.Add("wafer_quant", e.getWaferQuant());
                        json.Add("wafer_create", e.getWaferCreate());
                        json.Add("wafer_start", e.getWaferStartT());
                        json.Add("wafer_finish", e.getWaferFinishT());
                        json.Add("wafer_comm", e.getWaferComm());
                        json.Add("wafer_fault", e.getWaferFaulty());
                        json.Add("oper_id", e.getOperId());
                        json.Add("mscode", e.getMsCode());
                        json.Add("equip_id", e.getEquipId());
                        json.Add("wafer_maker", e.getWaferMaker());

                        jsonArray.Add(json);

                    }

                    jsonData.Add("wafer", jsonArray);

                    Data_MsgRun("웨이퍼 전체 정보 응답");

                    return jsonData.ToString();

                }
                /* 웨이퍼 불량률 조회 */
                else if (item.Key.Equals("wafer_faulty_id"))
                {
                    string wafer_faulty_id = json_data["wafer_faulty_id"].ToString();

                    Data_MsgRun("테스트 중  : " + wafer_faulty_id);

                    Database db = new Database();
                    List<FaultyInfo> fi = new List<FaultyInfo>();
                    fi = db.wafer_faulty_select(wafer_faulty_id);

                    var jsonData = new JObject();
                    var jsonArray = new JArray();

                    foreach (FaultyInfo e in fi)
                    {
                        var json = new JObject();
                        json.Add("faulty_id", e.getFaultyId());
                        json.Add("faulty_quant", e.getFaultyQuant());

                        jsonArray.Add(json);

                    }

                    jsonData.Add("wafer_faulty", jsonArray);

                    Data_MsgRun("웨이퍼 불량 정보 응답");

                    return jsonData.ToString();
                }
                /* 제품 정보 루트 검색 */
                else if (item.Key.Equals("mscode_select"))
                {
                    string mscode_select = json_data["mscode_select"].ToString();

                    Database db = new Database();
                    List<RouteInfo> ri = new List<RouteInfo>();
                    ri = db.wafer_route_select(db.mscode_id_select(mscode_select));

                    var jsonData = new JObject();
                    var jsonArray = new JArray();

                    foreach (RouteInfo e in ri)
                    {
                        var json = new JObject();

                        json.Add("route_id", e.getRouteId());
                        json.Add("curr_route", e.getCurrRoute());
                        json.Add("next_route", e.getNextRoute());

                        jsonArray.Add(json);
                    }

                    jsonData.Add("route_view", jsonArray);

                    Data_MsgRun("MSCODE 루트 정보 응답");

                    return jsonData.ToString();
                }
                /* 웨이퍼 생성 */
                else if (item.Key.Equals("wafer_add"))
                {
                    string mscode = json_data["wafer_add"]["mscode"].ToString();
                    int qty = Convert.ToInt32(json_data["wafer_add"]["qty"]);
                    string wafer_comm = json_data["wafer_add"]["wafer_comm"].ToString();
                    string wafer_maker = json_data["wafer_add"]["wafer_maker"].ToString();

                    var json = new JObject();

                    Database db = new Database();
                    if (db.wafer_insert(mscode, qty, wafer_comm, wafer_maker))
                    {
                        db.start_stop_event("wafer", "START", "1");
                        Data_MsgRun("웨이퍼 생성 성공");
                        json.Add("wafer_add_status", "1");
                    }
                    else
                    {
                        Data_MsgRun("웨이퍼 생성 실패");
                        json.Add("wafer_add_status", "0");
                    }
                    return json.ToString();
                }
                /* 웨이퍼 측정정보 관리 */
                else if (item.Key.Equals("wafer_data"))
                {

                    Database db = new Database();
                    List<WaferDataInfo> wdi = new List<WaferDataInfo>();
                    wdi = db.wafer_data_select();

                    var jsonData = new JObject();
                    var jsonArray = new JArray();

                    foreach (WaferDataInfo e in wdi)
                    {
                        var json = new JObject();

                        json.Add("wafer_id", e.getWaferId());
                        json.Add("wafer_pX1", e.getWaferPX1());
                        json.Add("wafer_pY1", e.getWaferPY1());
                        json.Add("wafer_pX2", e.getWaferPX2());
                        json.Add("wafer_pY2", e.getWaferPY2());
                        json.Add("curr_ttv", e.getCurrTtv());
                        json.Add("curr_bow", e.getCurrBow());
                        json.Add("curr_warp", e.getCurrWarp());
                        json.Add("curr_thk", e.getCurrThk());
                        json.Add("mscode", e.getMsCode());
                        json.Add("equip_id", e.getEquipId());
                        json.Add("oper_id", e.getOperId());
                        json.Add("equip_rpm", e.getEquipRpm());

                        jsonArray.Add(json);
                    }

                    jsonData.Add("wafer_data", jsonArray);

                    Data_MsgRun("웨이퍼 측정 정보 응답");

                    return jsonData.ToString();
                }
                /* 웨이퍼id별 측정정보 조회 */
                else if (item.Key.Equals("wafer_select_data"))
                {
                    string wafer_select_data = json_data["wafer_select_data"].ToString();

                    Database db = new Database();
                    List<WaferDataInfo> wdi = new List<WaferDataInfo>();
                    wdi = db.wafer_id_select(wafer_select_data);

                    var jsonData = new JObject();
                    var jsonArray = new JArray();

                    foreach (WaferDataInfo e in wdi)
                    {
                        var json = new JObject();

                        json.Add("wafer_id", e.getWaferId());
                        json.Add("wafer_pX1", e.getWaferPX1());
                        json.Add("wafer_pY1", e.getWaferPY1());
                        json.Add("wafer_pX2", e.getWaferPX2());
                        json.Add("wafer_pY2", e.getWaferPY2());
                        json.Add("curr_ttv", e.getCurrTtv());
                        json.Add("curr_bow", e.getCurrBow());
                        json.Add("curr_warp", e.getCurrWarp());
                        json.Add("curr_thk", e.getCurrThk());
                        json.Add("mscode", e.getMsCode());
                        json.Add("equip_id", e.getEquipId());
                        json.Add("oper_id", e.getOperId());
                        json.Add("equip_rpm", e.getEquipRpm());

                        jsonArray.Add(json);
                    }

                    jsonData.Add("wafer_select_data", jsonArray);

                    Data_MsgRun("웨이퍼 아이디로 측정 정보 응답");

                    return jsonData.ToString();
                }
                /* 공정별 웨이퍼 검색 */
                else if (item.Key.Equals("wafer_oper_id"))
                {
                    string wafer_oper_id = json_data["wafer_oper_id"].ToString();

                    Database db = new Database();
                    List<WaferInfo> wi = new List<WaferInfo>();
                    wi = db.wafer_operid_select(wafer_oper_id);

                    var jsonData = new JObject();
                    var jsonArray = new JArray();

                    foreach (WaferInfo e in wi)
                    {
                        var json = new JObject();

                        json.Add("wafer_id", e.getWaferId());
                        json.Add("ingot_id", e.getIngotId());
                        json.Add("block_id", e.getBlockId());
                        json.Add("wafer_quant", e.getWaferQuant());
                        json.Add("wafer_create", e.getWaferCreate());
                        json.Add("wafer_start", e.getWaferStartT());
                        json.Add("wafer_finish", e.getWaferFinishT());
                        json.Add("wafer_comm", e.getWaferComm());
                        json.Add("wafer_fault", e.getWaferFaulty());
                        json.Add("mscode", e.getMsCode());
                        json.Add("equip_id", e.getEquipId());
                        json.Add("oper_id", e.getOperId());
                        json.Add("wafer_maker", e.getWaferMaker());

                        jsonArray.Add(json);
                    }

                    jsonData.Add("wafer_select", jsonArray);

                    Data_MsgRun("공정 아이디로 웨이퍼 정보 응답");

                    return jsonData.ToString();
                }
                /* 제품 정보 관리 */
                else if (item.Key.Equals("mscode"))
                {
                    Database db = new Database();
                    List<MsCodeInfo> ri = new List<MsCodeInfo>();
                    ri = db.mscode_select();

                    var jsonData = new JObject();
                    var jsonArray = new JArray();

                    foreach (MsCodeInfo e in ri)
                    {
                        var json = new JObject();

                        json.Add("mscode", e.getMsCode());
                        json.Add("corp_name", e.getCorpName());
                        json.Add("corp_comm", e.getCorpComm());
                        json.Add("corp_man", e.getCorpManager());
                        json.Add("route_id", e.getRouteId());
                        json.Add("mscode_create", e.getMsCodeCreate());
                        json.Add("mscode_update", e.getMsCodeUpdate());

                        jsonArray.Add(json);
                    }

                    jsonData.Add("mscode", jsonArray);

                    Data_MsgRun("MSCODE 전체 정보 응답");

                    return jsonData.ToString();
                }
                /* 제품 정보 추가 */
                else if (item.Key.Equals("mscode_add"))
                {
                    MsCodeInfo mi = new MsCodeInfo();

                    mi.setMsCode(json_data["mscode_add"]["mscode"].ToString());
                    mi.setCorpName(json_data["mscode_add"]["corp_name"].ToString());
                    mi.setCorpComm(json_data["mscode_add"]["corp_comm"].ToString());
                    mi.setCorpManager(json_data["mscode_add"]["corp_man"].ToString());
                    mi.setRouteId(json_data["mscode_add"]["route_id"].ToString());

                    var json = new JObject();

                    Database db = new Database();
                    if (db.mscode_insert(mi))
                    {
                        Data_MsgRun("MSCODE 정보 추가 성공");
                        json.Add("mscode_add_status", "1");
                    }
                    else
                    {
                        Data_MsgRun("MSCODE 정보 추가 실패");
                        json.Add("mscode_add_status", "0");
                    }
                    return json.ToString();
                }
                /* 제품 정보 삭제 */
                else if (item.Key.Equals("mscode_del"))
                {
                    string id = json_data["mscode_del"].ToString();
                    Data_MsgRun(id);

                    var json = new JObject();

                    Database db = new Database();
                    if (db.mscode_delete(id))
                    {
                        Data_MsgRun("MSCODE 정보 삭제 성공");
                        json.Add("mscode_del_status", "1");
                    }
                    else
                    {
                        Data_MsgRun("MSCODE 정보 삭제 실패");
                        json.Add("mscode_del_status", "0");
                    }

                    return json.ToString();
                }
                /* 경로 id에 따른 정보 조회 */
                else if (item.Key.Equals("route_id"))
                {
                    string route_id = json_data["route_id"].ToString();

                    Database db = new Database();
                    List<RouteInfo> ri = new List<RouteInfo>();
                    ri = db.route_id_select(route_id);

                    var jsonData = new JObject();
                    var jsonArray = new JArray();

                    foreach (RouteInfo e in ri)
                    {
                        var json = new JObject();

                        json.Add("route_id", e.getRouteId());
                        json.Add("curr_route", e.getCurrRoute());
                        json.Add("next_route", e.getNextRoute());

                        jsonArray.Add(json);
                    }

                    jsonData.Add("route", jsonArray);

                    Data_MsgRun("경로ID에 따른 정보 응답");

                    return jsonData.ToString();
                }
                /* 경로 id에 따른 정보 조회2 (DATABASE JOIN) */
                else if (item.Key.Equals("route_join_id"))
                {
                    string route_id = json_data["route_join_id"].ToString();

                    Database db = new Database();
                    List<RouteInfo> ri = new List<RouteInfo>();
                    ri = db.route_id_join_select(route_id);

                    var jsonData = new JObject();
                    var jsonArray = new JArray();

                    foreach (RouteInfo e in ri)
                    {
                        jsonArray.Add(e.getCurrRoute());
                    }

                    jsonData.Add("route", jsonArray);

                    Data_MsgRun("경로ID에 따른 정보 응답2 (DATABASE JOIN)");

                    return jsonData.ToString();
                }
                /* 경로 id 조회 */
                else if (item.Key.Equals("route"))
                {
                    Database db = new Database();
                    List<RouteInfo> ri = new List<RouteInfo>();
                    ri = db.route_select();

                    var jsonData = new JObject();
                    var jsonArray = new JArray();

                    foreach (RouteInfo e in ri)
                    {
                        jsonArray.Add(e.getRouteId());
                    }

                    jsonData.Add("route_id", jsonArray);

                    Data_MsgRun("전체 경로ID 응답");

                    return jsonData.ToString();
                }
                /* 경로 추가 */
                else if (item.Key.Equals("route_add"))
                {
                    string route_id = AutoIncrement.route_num();
                    string curr_route;
                    string next_route;

                    Database db = new Database();
                    var json = new JObject();

                    foreach (JObject jo in json_data["route_add"])
                    {
                        curr_route = jo["curr_route"].ToString();
                        next_route = jo["next_route"].ToString();


                        Data_MsgRun(route_id + " " + curr_route + " " + next_route);
                        if (!db.route_insert(route_id, curr_route, next_route))
                        {
                            Data_MsgRun("경로 추가 실패");
                            json.Add("route_add_status", "0");

                            return json.ToString();
                        }
                    }

                    Data_MsgRun("경로 추가 성공");
                    json.Add("route_add_status", "1");

                    return json.ToString();
                }
                /* 경로 삭제 */
                else if (item.Key.Equals("route_del"))
                {
                    string id = json_data["route_del"].ToString();
                    Data_MsgRun(id);

                    var json = new JObject();

                    Database db = new Database();
                    if (db.route_delete(id))
                    {
                        Data_MsgRun("ROUTE 정보 삭제 성공");
                        json.Add("route_del_status", "1");
                    }
                    else
                    {
                        Data_MsgRun("ROUTE 정보 삭제 실패");
                        json.Add("route_del_status", "0");
                    }

                    return json.ToString();
                }
                /* 잉곳 관리(조회) */
                else if (item.Key.Equals("ingot_manage"))
                {
                    Database db = new Database();
                    List<IngotInfo> ii = new List<IngotInfo>();
                    ii = db.ingot_select();

                    var jsonData = new JObject();
                    var jsonArray = new JArray();

                    foreach (IngotInfo e in ii)
                    {
                        var json = new JObject();

                        json.Add("ingot_id", e.getIngotId());
                        json.Add("ingot_state", e.getIngotState());
                        json.Add("ingot_create", e.getIngotCreate());
                        json.Add("ingot_start", e.getIngotStartT());
                        json.Add("ingot_finish", e.getIngotFinishT());
                        json.Add("equip_id", e.getEquipId());
                        json.Add("ingot_maker", e.getIngotMaker());
                        json.Add("ingot_flag", e.getIngotFlag());

                        jsonArray.Add(json);
                    }

                    jsonData.Add("ingot_manage", jsonArray);

                    Data_MsgRun("잉곳 전체 정보 응답");

                    return jsonData.ToString();
                }
                /* 해당 잉곳 모니터링 */
                else if (item.Key.Equals("ingot_id"))
                {
                    string ingot_id = json_data["ingot_id"].ToString();

                    Database db = new Database();
                    List<IngotDataInfo> list_ii = new List<IngotDataInfo>();
                    list_ii = db.ingot_id_select(ingot_id);

                    var jsonData = new JObject();
                    var jsonArray = new JArray();

                    foreach (IngotDataInfo e in list_ii)
                    {
                        var json = new JObject();

                        json.Add("ingot_id", e.getIngotId());
                        json.Add("curr_temp", e.getCurrTemp());
                        json.Add("curr_vel", e.getCurrVel());
                        json.Add("curr_len", e.getCurrLen());
                        json.Add("curr_time", e.getCurrTime());

                        jsonArray.Add(json);
                    }

                    jsonData.Add("ingot_data", jsonArray);

                    Data_MsgRun("잉곳아이디로 잉곳에 대한 정보 응답");

                    return jsonData.ToString();

                }
                /* 잉곳 생성가능한지 플래그 값 */
                else if (item.Key.Equals("ingot_make"))
                {
                    if (IngotFlagInfo.ingotMake.Equals("1"))
                    {
                        return "{ \"ingot_make\" : \"1\" }";
                    }
                    else
                    {
                        return " { \"ingot_make\" : \"0\" }";
                    }
                }
                /* 잉곳 생성 */
                else if (item.Key.Equals("ingot_start"))
                {
                    IngotFlagInfo.ingotMake = "0";
                    string ingot_maker = json_data["ingot_maker"].ToString();

                    var json = new JObject();

                    Database db = new Database();

                    if (db.ingot_create_insert(ingot_maker))
                    {
                        db.start_stop_event("ingot", "START", "1");
                        Data_MsgRun("잉곳 생산 성공");
                        json.Add("ingot_create_status", "1");
                        /* 잉곳 시작 플래그를 1로 바꿔줌 */
                        IngotFlagInfo.ingotFlag = "1";
                        IngotFlagInfo.ingotMake = "0";
                    }
                    else
                    {
                        Data_MsgRun("잉곳 생산 실패");
                        json.Add("ingot_create_status", "0");
                    }
                    return json.ToString();
                }
                /* 측정정보 관리 (★ 페이징 처리 필요 ★) */
                else if (item.Key.Equals("data_oper"))
                {
                    string dataOperId = json_data["data_oper"]["oper_id"].ToString();
                    int count = Convert.ToInt32(json_data["data_oper"]["cnt"]);
                    int page = Convert.ToInt32(json_data["data_oper"]["page"]);

                    Database db = new Database();

                    if (db.oper_type_select(dataOperId).Equals("웨이퍼"))
                    {
                        List<WaferDataInfo> wdi = new List<WaferDataInfo>();
                        wdi = db.wafer_data_operid_select(dataOperId, count, page);

                        var jsonData = new JObject();
                        var jsonArray = new JArray();

                        jsonData.Add("data_cnt", db.wafer_data_cnt());
                        foreach (WaferDataInfo e in wdi)
                        {
                            var json = new JObject();

                            json.Add("wafer_id", e.getWaferId());
                            json.Add("wafer_pX1", e.getWaferPX1());
                            json.Add("wafer_pY1", e.getWaferPY1());
                            json.Add("wafer_pX2", e.getWaferPX2());
                            json.Add("wafer_pY2", e.getWaferPY2());
                            json.Add("curr_ttv", e.getCurrTtv());
                            json.Add("curr_bow", e.getCurrBow());
                            json.Add("curr_warp", e.getCurrWarp());
                            json.Add("curr_thk", e.getCurrThk());
                            json.Add("mscode", e.getMsCode());
                            json.Add("equip_id", e.getEquipId());
                            json.Add("oper_id", e.getOperId());
                            json.Add("equip_rpm", e.getEquipRpm());

                            jsonArray.Add(json);
                        }

                        jsonData.Add("wafer_data_oper", jsonArray);

                        Data_MsgRun("공정아이디로 웨이퍼 정보 응답");

                        return jsonData.ToString();
                    }
                    else if (db.oper_type_select(dataOperId).Equals("잉곳"))
                    {

                        List<IngotDataInfo> list_ii = new List<IngotDataInfo>();
                        list_ii = db.ingot_data_select(count, page);

                        var jsonData = new JObject();
                        var jsonArray = new JArray();

                        jsonData.Add("data_cnt", db.ingot_data_cnt());

                        foreach (IngotDataInfo e in list_ii)
                        {
                            var json = new JObject();

                            json.Add("ingot_id", e.getIngotId());
                            json.Add("curr_temp", e.getCurrTemp());
                            json.Add("curr_vel", e.getCurrVel());
                            json.Add("curr_len", e.getCurrLen());
                            json.Add("curr_time", e.getCurrTime());

                            jsonArray.Add(json);
                        }

                        jsonData.Add("ingot_data_oper", jsonArray);

                        Data_MsgRun("공정아이디로 잉곳 정보 응답");

                        return jsonData.ToString();
                    }
                    else
                    {
                        return null;
                    }
                }

            }
            return null;
        }
        /*  <<라즈베리파이 -> 서버>>  요청 및 응답 처리  */
        public string RaspDataDisp(JObject json_data)
        {
            foreach (var item in json_data)
            {
                /* 1. 잉곳 */
                if (item.Key.Equals("ingot_pi"))
                {
                    //get value
                    string weight = json_data["ingot_pi"]["weight"].ToString();
                    string ultrasound = json_data["ingot_pi"]["ultrasound"].ToString();
                    string temperature = json_data["ingot_pi"]["temperature"].ToString();
                    string fan = json_data["ingot_pi"]["fan"].ToString();
                    string heat = json_data["ingot_pi"]["heat"].ToString();
                    string compFlag = json_data["ingot_pi"]["comp_flag"].ToString();

                    Database db = new Database();
                    
                    //ingot data log insert
                    if (Convert.ToDouble(ultrasound) != 0 || Convert.ToDouble(temperature) != 0)
                        db.ingot_data_insert(temperature, "30.0", ultrasound);

                    //fan 이벤트 삽입
                    if (fan != IngotFlagInfo.fan)
                    {
                        IngotFlagInfo.fan = fan;
                        //db 이벤트 삽입
                        db.fan_insert(fan);
                    }

                    //heat 이벤트 삽입
                    if (heat != IngotFlagInfo.heat)
                    {
                        IngotFlagInfo.heat = heat;
                        //db 이벤트 삽입
                        db.heat_insert(heat);
                    }

                    //give json
                    var json = new JObject();
                    json.Add("ingot_flag", IngotFlagInfo.ingotFlag);

                    //무게 판단
                    if(Convert.ToDouble(weight) >= 3 && IngotFlagInfo.ingotFlag.Equals("0"))
                    {
                        //IngotFlagInfo.ingotFlag = "1";
                        IngotFlagInfo.ingotMake = "1";
                    }
                    else
                    {
                        IngotFlagInfo.ingotMake = "0";
                    }

                    //완성 여부
                    if (compFlag.Equals("1"))
                    {
                        db.start_stop_event("ingot", "FINISH", "0");
                        db.ingot_finish();
                        db.block_id_insert(db.find_block_ingot());
                        IngotFlagInfo.ingotFlag = "0";
                        Data_MsgRun("잉곳 생산 완료 !");
                    }
                    Data_MsgRun("PI >> 잉곳 데이터");

                    return json.ToString();
                }
                /* 2. 폴리싱 하기전 웨이퍼 돌릴지 말지? 검사 */
                else if (item.Key.Equals("wafer_flag"))
                {
                    Database db = new Database();
                    if(db.wafer_check() != null)
                        return "{ \"wafer_flag\" : \"1\" }";
                    else
                        return "{ \"wafer_flag\" : \"0\" }";
                }
                /* 2-1. 높이 검사 */
                else if (item.Key.Equals("height_chk"))
                {
                    //get value
                    string firstUltra = json_data["height_chk"]["first_ultra"].ToString();
                    string secondUltra = json_data["height_chk"]["second_ultra"].ToString();
                    string degree = json_data["height_chk"]["degree"].ToString();   //평탄도

                    //wafer_data 삽입
                    Data_MsgRun("PI >> 웨이퍼 검사 데이터");

                    var json = new JObject();
                    Database db = new Database();
                    

                    if (db.height_data_insert(degree))
                    {
                        json.Add("height_chk_status", "1");
                        Data_MsgRun("높이 검사 데이터 삽입 성공");
                    }
                    else
                    {
                        json.Add("height_chk_status", "0");
                        Data_MsgRun("높이 검사 데이터 삽입 실패");
                    }
                    return json.ToString();
                }
                /* 2-2. 폴리싱 */
                else if(item.Key.Equals("pol_com_flag"))
                {
                    Database db = new Database();
                    if(json_data["pol_com_flag"].ToString().Equals("1"))
                    {
                        db.start_stop_event("wafer", "FINISH", "0");
                        db.wafer_finish();
                        Data_MsgRun("폴리싱 성공");
                        return "{ \"pol_status\" : \"1\" }";
                    }
                    else
                    {
                        Data_MsgRun("폴리싱 실패");
                        return "{ \"pol_status\" : \"0\" }";
                    }
                }
                else
                {
                    Data_MsgRun("message error");
                    return "{\"sd\":\"sd\"}";
                }
            }
            return "{\"sd\":\"sd\"}";
        }
    }
}
