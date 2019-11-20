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
    //비밀번호변경페이지
    public partial class PwChange : Form
    {
        private bool isMove;
        private Point mousePoint;
        public PwChange()
        {
            InitializeComponent();
        }
        //정보를 입력 후 변경버튼을 클릭하면 변경됨
        private void Update_Click(object sender, EventArgs e)
        {
            Menu menu = new Menu();
            if (userPw.Text == pwChk.Text)
            {
                TcpSocket tcp = new TcpSocket(); //공통된 기능을 불러오기 위해 TcpSocket클래스 객체를 생성
                JsonParsing json = new JsonParsing(); //데이터를 받아오기 위해 클래스의 객체를 생성

                tcp.ConnectServer(); //서버 연결 시작
                byte[] update_data = json.UpdateParse(userID.Text, AES256_PW.EncryptString(userPw.Text)); //아이디와 패스워드를 json형식으로 받아와서 바이트로 바꿔줌
                byte[] update_info = tcp.DataParse(update_data); //바이트로 바꾼 데이터를 파싱
                tcp.Request(update_info); //서버로 데이터를 보내줌
                JObject recvMsg = tcp.Response(); //서버에서 보내주는 데이터를 받아서 응답하는 함수를 recvMsg 변수에 저장

                tcp.Close(); //서버 연결 해제

                int val = Convert.ToInt32(recvMsg["pw_update"]); //json형태의 데이터에 login_status라는 이름의 값을 찾아서 val변수에 저장

                if (val == 1) //val이 null이 아니면 로그인 성공
                {
                    MessageBox.Show("변경되었습니다.");
                    this.Visible = false;
                }
                else //아니면 실패
                {
                    MessageBox.Show("비밀번호 변경실패~!");
                }
            }
            else
            {
                MessageBox.Show("비밀번호가 일치하지 않습니다.");
            }
        }
        //패스워드입력후 엔터를 누르면 변경버튼 클릭효과
        private void PwChk_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.Update_Click(sender, e);
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

        private void exit_btn_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }
    }
}
