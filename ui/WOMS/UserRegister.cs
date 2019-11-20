using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WOMS
{
    //사용자추가 페이지
    public partial class UserRegister : Form
    {
        UserManagement userM;
        private bool isMove;
        private Point mousePoint;

        public UserRegister()
        {
            InitializeComponent();
        }
        //사용자등록 페이지에서 사용자 관리페이지를 불러옴
        public UserRegister(UserManagement um)
        {
            InitializeComponent();
            userM = um;
        }
        //나가기 버튼 클릭시 사용자관리페이지로 돌아감
        private void Back_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }
        //정보 입력 후 추가버튼을 누르면 추가되고 사용자관리 페이지의 init함수를 실행하여 새로고침
        private void Add_Click(object sender, EventArgs e)
        {
            if(UserName.Text.Equals("") || userId.Text.Equals("") || right.Text.Equals("") || position.Text.Equals(""))
            {
                MessageBox.Show("정보를 모두 입력하고 등록해주세요");
            }
            else
            {
                TcpSocket tcp = new TcpSocket(); //공통된 기능을 불러오기 위해 TcpSocket클래스 객체를 생성
                JsonParsing json = new JsonParsing(); //데이터를 받아오기 위해 클래스의 객체를 생성

                tcp.ConnectServer(); //서버 연결 시작
                byte[] user_data = json.UserParse(UserName.Text, userId.Text, right.Text, position.Text); //아이디와 패스워드를 json형식으로 받아와서 바이트로 바꿔줌
                byte[] user_info = tcp.DataParse(user_data); //바이트로 바꾼 데이터를 파싱
                tcp.Request(user_info); //서버로 데이터를 보내줌
                JObject recvMsg = tcp.Response(); //서버에서 보내주는 데이터를 받아서 응답하는 함수를 recvMsg 변수에 저장
                tcp.Close(); //서버 연결 해제

                int val = Convert.ToInt32(recvMsg["regis_status"]); //json형태의 데이터에 login_status라는 이름의 값을 찾아서 val변수에 저장

                if (val == 1) //val=1이면 로그인 성공
                {
                    userM.init();
                    UserName.Text = string.Empty;
                    userId.Text = string.Empty;
                    right.Text = string.Empty;
                    position.Text = string.Empty;
                    MessageBox.Show("사용자가 등록이 되었습니다."); 
                }
                else //아니면 실패
                {
                    MessageBox.Show("이미 존재하는 사원번호입니다.");
                }
            }
        }
        //엔터로 추가
        private void Position_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.Add_Click(sender, e);
            }
        }

        private void pnlTop_MouseDown(object sender, MouseEventArgs e)
        {
            isMove = true;
            mousePoint = new Point(e.X, e.Y);
        }

        private void pnlTop_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMove && (e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                Location = new Point(this.Left - (mousePoint.X - e.X),
                    this.Top - (mousePoint.Y - e.Y));
            }
        }

        private void pnlTop_MouseUp(object sender, MouseEventArgs e)
        {
            isMove = false;
        }
    }
}
