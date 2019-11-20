using System;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using System.Net.Sockets;
using System.Drawing;

namespace WOMS
{
    //로그인 페이지
    public partial class LoginForm : MetroFramework.Forms.MetroForm
    {
        private bool isMove;
        private Point mousePoint;
        
        public LoginForm()
        {
            InitializeComponent();
        }

        //패스워드 입력후 엔터를 누르면 로그인 버튼 클릭효과
        private void PW_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.logIn_Click(sender, e);
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
        //아이디와 패스워드 입력후 로그인 버튼 클릭시 로그인
        private void logIn_Click(object sender, EventArgs e)
        {
            TcpSocket tcp = new TcpSocket(); //공통된 기능을 불러오기 위해 TcpSocket클래스 객체를 생성
            JsonParsing json = new JsonParsing(); //데이터를 받아오기 위해 클래스의 객체를 생성

            tcp.ConnectServer(); //서버 연결 시작
            byte[] login_data = json.LoginParse(ID.Text, AES256_PW.EncryptString(PW.Text)); //아이디와 패스워드를 json형식으로 받아와서 바이트로 바꿔줌
            byte[] log_info = tcp.DataParse(login_data); //바이트로 바꾼 데이터를 파싱
            tcp.Request(log_info); //서버로 데이터를 보내줌
            JObject recvMsg = tcp.Response(); //서버에서 보내주는 데이터를 받아서 응답하는 함수를 recvMsg 변수에 저장

            tcp.Close(); //서버 연결 해제

            string val = Convert.ToString(recvMsg["login_name"]); //json형태의 데이터에 login_status라는 이름의 값을 찾아서 val변수에 저장

            if (!val.Equals("null")) //val이 null이 아니면 로그인 성공
            {
                Person.name = val;

                this.Visible = false;
                Menu menu = new Menu();
                menu.ShowDialog();
            }
            else //아니면 실패
            {
                MetroFramework.MetroMessageBox.Show(this, "등록되지 않은 아이디이거나, 비밀번호가 틀렸습니다.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void close_Click(object sender, EventArgs e)
        {
            if (MetroFramework.MetroMessageBox.Show(this, "종료하시겠습니까?", "EXIT", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                Application.Exit();
            }
        }
    }
}
