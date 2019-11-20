using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;

namespace WOMS
{
    public partial class EquipManagement : UserControl
    {
        string selectoper = null;
        string selectequip = null;
        //선택한 공정의 장비현황을 불러와서 테이블에 표시하는 함수(새로고침)
        public void init(string operselect)
        {
            TcpSocket tcp = new TcpSocket(); //공통된 기능을 불러오기 위해 TcpSocket클래스 객체를 생성
            string send = "{\"oper_select_id\":\"" + operselect + "\"}";
            tcp.ConnectServer(); //서버 연결 시작
            byte[] sendMsg = Encoding.UTF8.GetBytes(send);
            byte[] buff = tcp.DataParse(sendMsg);
            tcp.Request(buff); //서버로 데이터를 보내줌
            JObject recvMsg = tcp.Response(); //서버에서 보내주는 데이터를 받아서 응답하는 함수를 recvMsg 변수에 저장
            tcp.Close(); //서버 연결 해제

            DataTable oper = new DataTable();
            //table의 칼럼 지정
            oper.Columns.Add("장비ID", typeof(string));
            oper.Columns.Add("장비종류", typeof(string));
            oper.Columns.Add("장비상태", typeof(string));
            oper.Columns.Add("장비코멘트", typeof(string));
            oper.Columns.Add("장비입고날짜", typeof(string));
            oper.Columns.Add("장비관리자", typeof(string));
            oper.Columns.Add("장비수정날짜", typeof(string));
            //칼럼별 value값 지정
            JArray opers = (JArray)recvMsg["oper_equip"]; //jsonarray형식의 변수지정 후 서버에서 받은 데이터를 저장
            int len = opers.Count; //json배열의 길이
            string operState = null;

            for (int i = 0; i < len; i++) //배열의 길이만큼 반복문을 돌려 DB에 있는 이용자를 모두 user에 저장
            {
                if (Convert.ToInt32(opers[i]["oper_equip_state"]) == 0)
                {
                    operState = "대기중";
                }
                else
                {
                    operState = "사용중";
                }
                oper.Rows.Add(opers[i]["oper_equip_id"], opers[i]["oper_equip_type"], operState, opers[i]["oper_equip_comm"], opers[i]["oper_equip_rec_date"], opers[i]["oper_equip_man"], opers[i]["oper_equip_update"]);
            }
            //값들을 테이블에 표시
            Equip_Grid.DataSource = oper;
            Equip_Grid.CurrentCell = null;
            Eqiup_Event.CurrentCell = null;
        }
        //첫 화면에 공정테이블을 불러와서 보여줌
        public EquipManagement()
        {
            InitializeComponent();
            TcpSocket tcp = new TcpSocket(); //공통된 기능을 불러오기 위해 TcpSocket클래스 객체를 생성
            string send = "{\"equips\":\"null\"}";
            tcp.ConnectServer(); //서버 연결 시작
            byte[] sendMsg = Encoding.UTF8.GetBytes(send);
            byte[] buff = tcp.DataParse(sendMsg);
            tcp.Request(buff); //서버로 데이터를 보내줌
            JObject recvMsg = tcp.Response(); //서버에서 보내주는 데이터를 받아서 응답하는 함수를 recvMsg 변수에 저장
            tcp.Close(); //서버 연결 해제

            DataTable equip = new DataTable();
            //table의 칼럼 지정
            equip.Columns.Add("공정ID", typeof(string));
            //칼럼별 value값 지정
            JArray equips = (JArray)recvMsg["equips_oper_id"]; //jsonarray형식의 변수지정 후 서버에서 받은 데이터를 저장
            int len = equips.Count; //json배열의 길이

            for (int i = 0; i < len; i++) //배열의 길이만큼 반복문을 돌려 DB에 있는 이용자를 모두 user에 저장
            {
                equip.Rows.Add(equips[i]);
            }
            Oper_Grid.CurrentCell = null;
            
            //값들을 테이블에 표시
            Oper_Grid.DataSource = equip;
        }
        //공정 테이블에서 원하는 공정을 클릭하면 선택한 공정의 장비들을 테이블에 보여줌
        private void Oper_Grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                Eqiup_Event.DataSource = null;
                selectoper = Oper_Grid.Rows[e.RowIndex].Cells[0].Value.ToString();
                init(selectoper);
            }
            else
            {
                return;
            }
        }
        //원하는 장비를 클릭해서 선택한 장비의 이벤트를 테이블에 보여줌
        private void Equip_Grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                selectequip = Equip_Grid.Rows[e.RowIndex].Cells[0].Value.ToString();
                TcpSocket tcp = new TcpSocket(); //공통된 기능을 불러오기 위해 TcpSocket클래스 객체를 생성
                string send = "{\"equip_select\":\"" + selectequip + "\"}";
                tcp.ConnectServer(); //서버 연결 시작
                byte[] sendMsg = Encoding.UTF8.GetBytes(send);
                byte[] buff = tcp.DataParse(sendMsg);
                tcp.Request(buff); //서버로 데이터를 보내줌
                JObject recvMsg = tcp.Response(); //서버에서 보내주는 데이터를 받아서 응답하는 함수를 recvMsg 변수에 저장
                tcp.Close(); //서버 연결 해제

                DataTable equip = new DataTable();
                //table의 칼럼 지정
                equip.Columns.Add("이벤트ID", typeof(string));
                equip.Columns.Add("장비ID", typeof(string));
                equip.Columns.Add("이벤트종류", typeof(string));
                equip.Columns.Add("이벤트발생시간", typeof(string));
                equip.Columns.Add("장비상태", typeof(string));
                equip.Columns.Add("관리담당자", typeof(string));
                //칼럼별 value값 지정
                JArray equips = (JArray)recvMsg["equip_event_view"]; //jsonarray형식의 변수지정 후 서버에서 받은 데이터를 저장
                int len = equips.Count; //json배열의 길이

                for (int i = 0; i < len; i++) //배열의 길이만큼 반복문을 돌려 DB에 있는 이용자를 모두 user에 저장
                {
                    equip.Rows.Add(equips[i]["equip_event_id"], equips[i]["equip_id"], equips[i]["equip_event_type"], equips[i]["equip_event_time"], equips[i]["equip_state"], equips[i]["repair_man"]);
                }
                //값들을 테이블에 표시
                Eqiup_Event.DataSource = equip;
                Eqiup_Event.CurrentCell = null;
            }
            else
            {
                return;
            }
        }
        //추가하고자 하는 장비의 정보를 입력후 추가버튼을 누르면 추가가 되며 테이블 새로고침
        private void Add_Click(object sender, EventArgs e)
        {
            TcpSocket tcp = new TcpSocket(); //공통된 기능을 불러오기 위해 TcpSocket클래스 객체를 생성
            JsonParsing json = new JsonParsing(); //데이터를 받아오기 위해 클래스의 객체를 생성

            if (Equip_Name.Text.Equals("") || Equip_Type.SelectedItem == null)
            {
                MetroFramework.MetroMessageBox.Show(this, "정보를 입력하세요.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                byte[] equip_data = json.EquipParse(Equip_Name.Text, Equip_Type.SelectedItem.ToString(), Equip_Type.SelectedItem.ToString(), equip_Comment.Text, Person.name); //아이디와 패스워드를 json형식으로 받아와서 바이트로 바꿔줌
                tcp.ConnectServer(); //서버 연결 시작
                byte[] equip_info = tcp.DataParse(equip_data); //바이트로 바꾼 데이터를 파싱
                tcp.Request(equip_info); //서버로 데이터를 보내줌
                JObject recvMsg = tcp.Response(); //서버에서 보내주는 데이터를 받아서 응답하는 함수를 recvMsg 변수에 저장

                tcp.Close(); //서버 연결 해제

                int val = Convert.ToInt32(recvMsg["equip_add_status"]); //json형태의 데이터에 login_status라는 이름의 값을 찾아서 val변수에 저장

                if (val == 1)
                {
                    init(selectoper);
                    Oper_Grid.CurrentCell = null;
                    Equip_Grid.CurrentCell = null;
                    Eqiup_Event.CurrentCell = null;
                    Equip_Name.Text = string.Empty;
                    equip_Comment.Text = string.Empty;
                    Equip_Type.Items[Equip_Type.SelectedIndex] = string.Empty;
                    MetroFramework.MetroMessageBox.Show(this, "등록 성공했습니다.", "SUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else //아니면 실패
                {
                    Oper_Grid.CurrentCell = null;
                    Equip_Grid.CurrentCell = null;
                    Eqiup_Event.CurrentCell = null;
                    MetroFramework.MetroMessageBox.Show(this, "등록 실패했습니다.", "FAILED", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        //장비종류를 공정ID로 불러옴
        private void Equip_Type_Click(object sender, EventArgs e)
        {
            TcpSocket tcp = new TcpSocket(); //공통된 기능을 불러오기 위해 TcpSocket클래스 객체를 생성
            string send = "{\"equips\":\"null\"}";
            tcp.ConnectServer(); //서버 연결 시작
            byte[] sendMsg = Encoding.UTF8.GetBytes(send);
            byte[] buff = tcp.DataParse(sendMsg);
            tcp.Request(buff); //서버로 데이터를 보내줌
            JObject recvMsg = tcp.Response(); //서버에서 보내주는 데이터를 받아서 응답하는 함수를 recvMsg 변수에 저장
            tcp.Close(); //서버 연결 해제

            JArray equips = (JArray)recvMsg["equips_oper_id"];
            Equip_Type.Items.Clear();
            string[] selectType = equips.ToObject<string[]>();
            Equip_Type.Items.AddRange(selectType);
        }

        private void EquipManagement_Shown(object sender, EventArgs e)
        {
            Oper_Grid.CurrentCell = null;
            Equip_Grid.CurrentCell = null;
            Eqiup_Event.CurrentCell = null;
        }
    }
}
