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
    //메뉴페이지
    public partial class Menu : Form
    {
        private bool isMove;
        private Point mousePoint;
        public Menu()
        {
            InitializeComponent();
            panel2.Controls.Clear();
            home_index user = new home_index();
            panel2.Controls.Add(user);
        }
        private void close_Click(object sender, EventArgs e)
        {
            if (MetroFramework.MetroMessageBox.Show(this, "종료하시겠습니까?", "EXIT", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                Application.Exit();
            }
        }
        //데이터관리 페이지
        private void dataM_Click(object sender, EventArgs e)
        {
            panel2.Controls.Clear();
            IngotCreate.threadFlag = false;
            DataManagement data = new DataManagement();
            panel2.Controls.Add(data);
        }
        //코드관리페이지
        private void codeM_Click(object sender, EventArgs e)
        {
            panel2.Controls.Clear();
            IngotCreate.threadFlag = false;
            CodeManagement data = new CodeManagement();
            panel2.Controls.Add(data);
        }
        //장비관리페이지
        private void equipM_Click(object sender, EventArgs e)
        {
            panel2.Controls.Clear();
            IngotCreate.threadFlag = false;
            EquipManagement data = new EquipManagement();
            panel2.Controls.Add(data);
        }
        //제품관리페이지
        private void productM_Click(object sender, EventArgs e)
        {
            panel2.Controls.Clear();
            IngotCreate.threadFlag = false;
            MsCodeManagement data = new MsCodeManagement();
            panel2.Controls.Add(data);
        }
        //사용자관리페이지
        private void userM_Click(object sender, EventArgs e)
        {
            panel2.Controls.Clear();
            IngotCreate.threadFlag = false;
            UserManagement data = new UserManagement();
            panel2.Controls.Add(data);
        }
        //잉곳페이지
        private void ingotM_Click(object sender, EventArgs e)
        {
            panel2.Controls.Clear();
            IngotCreate data = new IngotCreate();
            panel2.Controls.Add(data);
        }
        //웨이퍼관리페이지
        private void waferM_Click(object sender, EventArgs e)
        {
            panel2.Controls.Clear();
            IngotCreate.threadFlag = false;
            WaferManagement data = new WaferManagement();
            panel2.Controls.Add(data);
        }
        //경로관리페이지
        private void routeM_Click(object sender, EventArgs e)
        {
            panel2.Controls.Clear();
            IngotCreate.threadFlag = false;
            RouteManagement data = new RouteManagement();
            panel2.Controls.Add(data);
        }
        //로그아웃 버튼 클릭시 로그인 페이지로 돌아감
        private void logOut_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            IngotCreate.threadFlag = false;
            LoginForm loginForm = new LoginForm();
            loginForm.ShowDialog();
        }
        //홈
        private void home_Click(object sender, EventArgs e)
        {
            panel2.Controls.Clear();
            IngotCreate.threadFlag = false;
            home_index user = new home_index();
            panel2.Controls.Add(user);
            
        }
        // 창 이동 시키는 것
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
