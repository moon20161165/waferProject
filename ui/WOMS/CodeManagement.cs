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
    public partial class CodeManagement : UserControl
    {
        string selectType = null;
        string selectCode = null;
        //코드종류를 선택해서 코드ID 테이블에 띄워주는 함수(새로고침)
        public void init()
        {
            TcpSocket tcp = new TcpSocket();
            string send = "{\"code_type_select\":\"" + selectType + "\"}";
            tcp.ConnectServer(); //서버 연결 시작
            byte[] sendMsg = Encoding.UTF8.GetBytes(send);
            byte[] buff = tcp.DataParse(sendMsg);
            tcp.Request(buff); //서버로 데이터를 보내줌
            JObject recvMsg = tcp.Response(); //서버에서 보내주는 데이터를 받아서 응답하는 함수를 recvMsg 변수에 저장
            tcp.Close(); //서버 연결 해제

            DataTable code = new DataTable();
            //table의 칼럼 지정
            code.Columns.Add("코드ID", typeof(string));
            //칼럼별 value값 지정
            JArray codes = (JArray)recvMsg["type_select_id"]; //jsonarray형식의 변수지정 후 서버에서 받은 데이터를 저장
            int len = codes.Count; //json배열의 길이

            for (int i = 0; i < len; i++) //배열의 길이만큼 반복문을 돌려 DB에 있는 이용자를 모두 user에 저장
            {
                code.Rows.Add(codes[i]);
            }
            //값들을 테이블에 표시
            codeId_select.DataSource = code;
        }
        //첫 화면에 코드종류테이블을 보여줌
        public CodeManagement()
        {
            InitializeComponent();
            TcpSocket tcp = new TcpSocket(); //공통된 기능을 불러오기 위해 TcpSocket클래스 객체를 생성
            string send = "{\"code_types\":\"null\"}";
            tcp.ConnectServer(); //서버 연결 시작
            byte[] sendMsg = Encoding.UTF8.GetBytes(send);
            byte[] buff = tcp.DataParse(sendMsg);
            tcp.Request(buff); //서버로 데이터를 보내줌
            JObject recvMsg = tcp.Response(); //서버에서 보내주는 데이터를 받아서 응답하는 함수를 recvMsg 변수에 저장
            tcp.Close(); //서버 연결 해제

            DataTable code = new DataTable();
            //table의 칼럼 지정
            code.Columns.Add("코드종류", typeof(string));
            //칼럼별 value값 지정
            JArray codes = (JArray)recvMsg["code_types"]; //jsonarray형식의 변수지정 후 서버에서 받은 데이터를 저장
            int len = codes.Count; //json배열의 길이

            for (int i = 0; i < len; i++) //배열의 길이만큼 반복문을 돌려 DB에 있는 이용자를 모두 user에 저장
            {
                code.Rows.Add(codes[i]);
            }
            //값들을 테이블에 표시
            codeType_select.DataSource = code;
            codeType_select.CurrentCell = null;
        }
        //추가 버튼 클릭시 생성하고자하는 코드가 추가되면서 테이블이 새로고침
        private void Add_Click(object sender, EventArgs e)
        {
            if (codeId.Text.Equals("코드ID") || codeId.Text.Equals("") || codeType.SelectedItem.Equals("종류") || codeComment.Text.Equals("설명") || codeComment.Text.Equals(""))
            {
                MetroFramework.MetroMessageBox.Show(this, "정보를 입력하세요 !!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                TcpSocket tcp = new TcpSocket(); //공통된 기능을 불러오기 위해 TcpSocket클래스 객체를 생성
                JsonParsing json = new JsonParsing(); //데이터를 받아오기 위해 클래스의 객체를 생성

                tcp.ConnectServer(); //서버 연결 시작

                byte[] code_data = json.CodeAddParse(codeId.Text, codeType.SelectedItem.ToString(), codeComment.Text); //아이디와 패스워드를 json형식으로 받아와서 바이트로 바꿔줌
                byte[] code_info = tcp.DataParse(code_data); //바이트로 바꾼 데이터를 파싱
                tcp.Request(code_info); //서버로 데이터를 보내줌
                JObject recvMsg = tcp.Response(); //서버에서 보내주는 데이터를 받아서 응답하는 함수를 recvMsg 변수에 저장

                tcp.Close(); //서버 연결 해제

                int val = Convert.ToInt32(recvMsg["code_add_status"]); //json형태의 데이터에 login_status라는 이름의 값을 찾아서 val변수에 저장

                if (val == 1) //val=1이면 로그인 성공
                {
                    init();
                    codeType_select.CurrentCell = null;
                    codeId_select.CurrentCell = null;
                    codeId.Text = string.Empty;
                    codeComment.Text = string.Empty;
                    codeType.Items[codeType.SelectedIndex] = string.Empty;
                    MetroFramework.MetroMessageBox.Show(this, "등록 성공하였습니다. ^ㅡ^", "GOOD", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else //아니면 실패
                {
                    codeType_select.CurrentCell = null;
                    codeId_select.CurrentCell = null;
                    MetroFramework.MetroMessageBox.Show(this, "등록 실패하였습니다. ㅠㅠ", "FAIL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        //코드종류 테이블의 행을 클릭하면 선택한 코드종류의 코드ID들이 조회
        private void CodeType_select_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                selectType = codeType_select.Rows[e.RowIndex].Cells[0].Value.ToString();
                TcpSocket tcp = new TcpSocket(); //공통된 기능을 불러오기 위해 TcpSocket클래스 객체를 생성
                string send = "{\"code_type_select\":\"" + selectType + "\"}";
                tcp.ConnectServer(); //서버 연결 시작
                byte[] sendMsg = Encoding.UTF8.GetBytes(send);
                byte[] buff = tcp.DataParse(sendMsg);
                tcp.Request(buff); //서버로 데이터를 보내줌
                JObject recvMsg = tcp.Response(); //서버에서 보내주는 데이터를 받아서 응답하는 함수를 recvMsg 변수에 저장
                tcp.Close(); //서버 연결 해제

                DataTable code = new DataTable();
                //table의 칼럼 지정
                code.Columns.Add("코드ID", typeof(string));
                //칼럼별 value값 지정
                JArray codes = (JArray)recvMsg["type_select_id"]; //jsonarray형식의 변수지정 후 서버에서 받은 데이터를 저장
                JObject codeAtt = (JObject)recvMsg["code_att"];

                int len = codes.Count; //json배열의 길이

                for (int i = 0; i < len; i++) //배열의 길이만큼 반복문을 돌려 DB에 있는 이용자를 모두 user에 저장
                {
                    code.Rows.Add(codes[i]);
                }
                //값들을 테이블에 표시
                codeId_select.DataSource = code;
                codeId_select.CurrentCell = null;
                att1.Text = codeAtt["att_fir"].ToString();
                att2.Text = codeAtt["att_sec"].ToString();
                att3.Text = codeAtt["att_thr"].ToString();
                att4.Text = codeAtt["att_four"].ToString();
                att5.Text = codeAtt["att_fif"].ToString();
                att6.Text = codeAtt["att_six"].ToString();
                att7.Text = codeAtt["att_sev"].ToString();
                att8.Text = codeAtt["att_eig"].ToString();
                att9.Text = codeAtt["att_nin"].ToString();
                att10.Text = codeAtt["att_ten"].ToString();
                codeAtt1.Text = string.Empty;
                codeAtt2.Text = string.Empty;
                codeAtt3.Text = string.Empty;
                codeAtt4.Text = string.Empty;
                codeAtt5.Text = string.Empty;
                codeAtt6.Text = string.Empty;
                codeAtt7.Text = string.Empty;
                codeAtt8.Text = string.Empty;
                codeAtt9.Text = string.Empty;
                codeAtt10.Text = string.Empty;
            }
            else
            {
                return;
            }
        }
        //코드ID 테이블의 행을 클릭하면 선택한 코드의 정보들을 텍스트박스에 보여줌
        private void CodeId_select_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                selectCode = codeId_select.Rows[e.RowIndex].Cells[0].Value.ToString();
                TcpSocket tcp = new TcpSocket(); //공통된 기능을 불러오기 위해 TcpSocket클래스 객체를 생성
                string send = "{\"code_id_select\":\"" + selectCode + "\"}";
                tcp.ConnectServer(); //서버 연결 시작
                byte[] sendMsg = Encoding.UTF8.GetBytes(send);
                byte[] buff = tcp.DataParse(sendMsg);
                tcp.Request(buff); //서버로 데이터를 보내줌
                JObject recvMsg = tcp.Response(); //서버에서 보내주는 데이터를 받아서 응답하는 함수를 recvMsg 변수에 저장
                tcp.Close(); //서버 연결 해제

                JObject codeView = (JObject)recvMsg["code_view"]; //json형식의 변수지정 후 서버에서 받은 데이터를 저장

                Comment.Text = codeView["code_comm"].ToString();
                codeAtt1.Text = codeView["code_att_fir"].ToString();
                codeAtt2.Text = codeView["code_att_sec"].ToString();
                codeAtt3.Text = codeView["code_att_thr"].ToString();
                codeAtt4.Text = codeView["code_att_four"].ToString();
                codeAtt5.Text = codeView["code_att_fif"].ToString();
                codeAtt6.Text = codeView["code_att_six"].ToString();
                codeAtt7.Text = codeView["code_att_sev"].ToString();
                codeAtt8.Text = codeView["code_att_eig"].ToString();
                codeAtt9.Text = codeView["code_att_nin"].ToString();
                codeAtt10.Text = codeView["code_att_ten"].ToString();
            }
            else
            {
                return;
            }
        }
        //추가를 위해 텍스트박스를 클릭하면 기존에 있던 글자가 사라짐
        private void CodeId_Click(object sender, EventArgs e)
        {
            if (codeId.Text.Equals("코드ID"))
            {
                codeId.Text = string.Empty;
            }
            if (codeComment.Text == string.Empty)
            {
                codeComment.Text = "설명";
            }
        }
        //추가를 위해 텍스트박스를 클릭하면 기존에 있던 글자가 사라짐
        private void CodeComment_Click(object sender, EventArgs e)
        {
            if (codeComment.Text.Equals("설명"))
            {
                codeComment.Text = string.Empty;
            }
            if (codeId.Text == string.Empty)
            {
                codeId.Text = "코드ID";
            }
        }
        //수정하고 싶은 코드를 테이블에서 선택 후 정보들을 수정하고 저장 버튼을 클릭시 수정이 되며 새로고침
        private void Save_Click(object sender, EventArgs e)
        {
            TcpSocket tcp = new TcpSocket(); //공통된 기능을 불러오기 위해 TcpSocket클래스 객체를 생성
            JsonParsing json = new JsonParsing(); //데이터를 받아오기 위해 클래스의 객체를 생성

            tcp.ConnectServer(); //서버 연결 시작
            byte[] code_data = json.CodeUpdateParse(selectCode, Comment.Text, codeAtt1.Text, codeAtt2.Text, codeAtt3.Text, codeAtt4.Text, codeAtt5.Text, codeAtt6.Text, codeAtt7.Text, codeAtt8.Text, codeAtt9.Text, codeAtt10.Text); //아이디와 패스워드를 json형식으로 받아와서 바이트로 바꿔줌
            byte[] code_info = tcp.DataParse(code_data); //바이트로 바꾼 데이터를 파싱
            tcp.Request(code_info); //서버로 데이터를 보내줌
            JObject recvMsg = tcp.Response(); //서버에서 보내주는 데이터를 받아서 응답하는 함수를 recvMsg 변수에 저장

            tcp.Close(); //서버 연결 해제

            int val = Convert.ToInt32(recvMsg["code_update_status"]); //json형태의 데이터에 login_status라는 이름의 값을 찾아서 val변수에 저장

            if (val == 1) //val=1이면 로그인 성공
            {
                init();
                codeType_select.CurrentCell = null;
                codeId_select.CurrentCell = null;
                MetroFramework.MetroMessageBox.Show(this, "수정 성공하였습니다. ^ㅡ^", "GOOD", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else //아니면 실패
            {
                codeType_select.CurrentCell = null;
                codeId_select.CurrentCell = null;
                MetroFramework.MetroMessageBox.Show(this, "수정 실패하였습니다. ㅠㅠ", "FAIL", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        //삭제하고 싶은 코드ID를 테이블에서 선택 후 삭제버튼 클릭시 삭제
        private void CodeDel_Click(object sender, EventArgs e)
        {
            TcpSocket tcp = new TcpSocket(); //공통된 기능을 불러오기 위해 TcpSocket클래스 객체를 생성
            string send = "{\"code_del_id\":\"" + selectCode + "\"}";
            tcp.ConnectServer(); //서버 연결 시작
            byte[] sendMsg = Encoding.UTF8.GetBytes(send);
            byte[] buff = tcp.DataParse(sendMsg);
            tcp.Request(buff); //서버로 데이터를 보내줌
            JObject recvMsg = tcp.Response(); //서버에서 보내주는 데이터를 받아서 응답하는 함수를 recvMsg 변수에 저장
            tcp.Close(); //서버 연결 해제

            int val = Convert.ToInt32(recvMsg["code_del_status"]); //json형태의 데이터에 login_status라는 이름의 값을 찾아서 val변수에 저장

            if (val == 1)
            {
                init();
                codeType_select.CurrentCell = null;
                codeId_select.CurrentCell = null;
                MetroFramework.MetroMessageBox.Show(this, "삭제 성공하였습니다. ^ㅡ^", "GOOD", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else //아니면 실패
            {
                codeType_select.CurrentCell = null;
                codeId_select.CurrentCell = null;
                MetroFramework.MetroMessageBox.Show(this, "삭제 실패하였습니다. ㅠㅠ", "FAIL", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        //추가를 위해 코드종류 콤보박스 클릭시 DB가 가지고있는 코드종류를 불러옴
        private void CodeType_Click(object sender, EventArgs e)
        {
            TcpSocket tcp = new TcpSocket(); //공통된 기능을 불러오기 위해 TcpSocket클래스 객체를 생성
            string send = "{\"code_types\":\"null\"}";
            tcp.ConnectServer(); //서버 연결 시작
            byte[] sendMsg = Encoding.UTF8.GetBytes(send);
            byte[] buff = tcp.DataParse(sendMsg);
            tcp.Request(buff); //서버로 데이터를 보내줌
            JObject recvMsg = tcp.Response(); //서버에서 보내주는 데이터를 받아서 응답하는 함수를 recvMsg 변수에 저장
            tcp.Close(); //서버 연결 해제

            DataTable code = new DataTable();
            //table의 칼럼 지정
            code.Columns.Add("코드종류", typeof(string));

            JArray codes = (JArray)recvMsg["code_types"]; //jsonarray형식의 변수지정 후 서버에서 받은 데이터를 저장
            codeType.Items.Clear();
            string[] selectCode = codes.ToObject<string[]>();
            codeType.Items.AddRange(selectCode);
        }

        private void CodeManagement_Shown(object sender, EventArgs e)
        {
            codeType_select.CurrentCell = null;
            codeId_select.CurrentCell = null;
        }

    }
}
