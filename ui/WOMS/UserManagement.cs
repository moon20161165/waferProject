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
    public partial class UserManagement : UserControl
    {
        string selectUser = null;
        //등록된 사용자들을 테이블에 보여주는 함수
        public void init()
        {
            TcpSocket tcp = new TcpSocket(); //공통된 기능을 불러오기 위해 TcpSocket클래스 객체를 생성
            string send = "{\"users\":\"null\"}";
            tcp.ConnectServer(); //서버 연결 시작
            byte[] sendMsg = Encoding.UTF8.GetBytes(send);
            byte[] buff = tcp.DataParse(sendMsg);
            tcp.Request(buff); //서버로 데이터를 보내줌
            JObject recvMsg = tcp.Response(); //서버에서 보내주는 데이터를 받아서 응답하는 함수를 recvMsg 변수에 저장
            tcp.Close(); //서버 연결 해제

            DataTable user = new DataTable();
            //table의 칼럼 지정
            user.Columns.Add("사원번호", typeof(string));
            user.Columns.Add("비밀번호", typeof(string));
            user.Columns.Add("이름", typeof(string));
            user.Columns.Add("직급", typeof(string));
            user.Columns.Add("권한", typeof(string));
            //칼럼별 value값 지정
            JArray users = (JArray)recvMsg["users"]; //jsonarray형식의 변수지정 후 서버에서 받은 데이터를 저장
            int len = users.Count; //json배열의 길이

            for (int i = 0; i < len; i++) //배열의 길이만큼 반복문을 돌려 DB에 있는 이용자를 모두 user에 저장
            {
                user.Rows.Add(users[i]["user_id"], "*****", users[i]["user_name"], users[i]["user_pos"], users[i]["user_right"]);
            }
            User_Grid.Update();
            User_Grid.Refresh();
            //값들을 테이블에 표시
            User_Grid.DataSource = user;
        }
        //첫 화면에 등록된 사용자들을 테이블에 표시
        public UserManagement()
        {
            InitializeComponent();
            init();
        }
        //사용자추가버튼을 누르면 사용자추가화면으로 넘어감
        private void Add_Click(object sender, EventArgs e)
        {
            UserRegister userRegister = new UserRegister(this);
            userRegister.Show();
        }
        //삭제하고자하는 사용자를 선택
        private void User_Grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                selectUser = User_Grid.Rows[e.RowIndex].Cells[0].Value.ToString();
            }
            else
            {
                return;
            }
        }
        //삭제하고자하는 사용자를 선택 후 삭제 버튼을 누르면 삭제 후 새로고침
        private void UserDel_Click(object sender, EventArgs e)
        {
            TcpSocket tcp = new TcpSocket(); //공통된 기능을 불러오기 위해 TcpSocket클래스 객체를 생성
            string send = "{\"users_delete\":\"" + selectUser + "\"}";
            tcp.ConnectServer(); //서버 연결 시작
            byte[] sendMsg = Encoding.UTF8.GetBytes(send);
            byte[] buff = tcp.DataParse(sendMsg);
            tcp.Request(buff); //서버로 데이터를 보내줌
            JObject recvMsg = tcp.Response(); //서버에서 보내주는 데이터를 받아서 응답하는 함수를 recvMsg 변수에 저장
            tcp.Close(); //서버 연결 해제

            int val = Convert.ToInt32(recvMsg["users_del_state"]); //json형태의 데이터에 login_status라는 이름의 값을 찾아서 val변수에 저장

            if (val == 1) //val=1이면 로그인 성공
            {
                init();
                User_Grid.CurrentCell = null;
                MetroFramework.MetroMessageBox.Show(this, "삭제 성공하였습니다.", "SUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else //아니면 실패
            {
                User_Grid.CurrentCell = null;
                MetroFramework.MetroMessageBox.Show(this, "삭제 실패하였습니다.", "FAILED", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        //그리드뷰 띄워줄 때 셀 선택 지우기
        private void UserManagement_Shown(object sender, EventArgs e)
        {
            User_Grid.CurrentCell = null;
        }

        private void User_Grid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if(e.ColumnIndex == 1)
            {
                if(e.Value != null)
                {
                    e.Value = new string('*', e.Value.ToString().Length);
                }
            }
        }
    }
}
