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
using System.Threading;

namespace WOMS
{
    //웨이퍼 모니터링 페이지
    public partial class WaferMonitering : Form
    {
        private bool isMove;
        private Point mousePoint;
        int[] coord = new int[4];
        public static bool threadFlag = false;
        Thread th;

        public delegate void MsgEvent(DataTable val);
        private void wafer_MsgRun(DataTable val)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new MsgEvent(this.Log), val);
            }
        }
        public void Log(DataTable strval)
        {
            this.WaferMonuter.DataSource = strval;
        }
        private void Run()
        {
            while (threadFlag)
            {
                TcpSocket tcp = new TcpSocket(); //공통된 기능을 불러오기 위해 TcpSocket클래스 객체를 생성
                string send = "{\"wafer_data\":\"null\"}";
                tcp.ConnectServer(); //서버 연결 시작
                byte[] sendMsg = Encoding.UTF8.GetBytes(send);
                byte[] buff = tcp.DataParse(sendMsg);
                tcp.Request(buff); //서버로 데이터를 보내줌
                JObject recvMsg = tcp.Response(); //서버에서 보내주는 데이터를 받아서 응답하는 함수를 recvMsg 변수에 저장
                tcp.Close(); //서버 연결 해제

                DataTable moniter = new DataTable();
                //table의 칼럼 지정
                moniter.Columns.Add("웨이퍼ID", typeof(string));
                moniter.Columns.Add("측정1(X좌표)", typeof(string));
                moniter.Columns.Add("측정1(Y좌표)", typeof(string));
                moniter.Columns.Add("측정2(X좌표)", typeof(string));
                moniter.Columns.Add("측정2(Y좌표)", typeof(string));
                moniter.Columns.Add("평탄도", typeof(string));
                moniter.Columns.Add("볼록함", typeof(string));
                moniter.Columns.Add("뒤틀림", typeof(string));
                moniter.Columns.Add("두께", typeof(string));
                moniter.Columns.Add("제품정보", typeof(string));
                moniter.Columns.Add("장비ID", typeof(string));
                moniter.Columns.Add("공정ID", typeof(string));
                moniter.Columns.Add("RPM", typeof(string));
                //칼럼별 value값 지정
                JArray moniters = (JArray)recvMsg["wafer_data"]; //jsonarray형식의 변수지정 후 서버에서 받은 데이터를 저장
                int len = moniters.Count; //json배열의 길이

                for (int i = 0; i < len; i++) //배열의 길이만큼 반복문을 돌려 DB에 있는 이용자를 모두 user에 저장
                {
                    moniter.Rows.Add(moniters[i]["wafer_id"], moniters[i]["wafer_pX1"], moniters[i]["wafer_pY1"], moniters[i]["wafer_pX2"], moniters[i]["wafer_pY2"],
                    moniters[i]["curr_ttv"], moniters[i]["curr_bow"], moniters[i]["curr_warp"], moniters[i]["curr_thk"], moniters[i]["mscode"],
                    moniters[i]["equip_id"], moniters[i]["oper_id"], moniters[i]["equip_rpm"]);
                }
                //값들을 테이블에 표시
                wafer_MsgRun(moniter);
                Thread.Sleep(1000);
            }
        }

        //첫 화면에 제작 중인 모든 웨이퍼를 불러와서 테이블에 표시
        public WaferMonitering()
        {
            InitializeComponent();
            threadFlag = true;
            th =  new Thread(Run);
            th.Start();
        }
        //테이블의 행 클릭시 행에 있는 값들을 텍스트 박스에 삽입하여 보여줌
        private void WaferMonuter_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                coord[0] = Convert.ToInt32(WaferMonuter.Rows[e.RowIndex].Cells[1].Value);
                coord[1] = Convert.ToInt32(WaferMonuter.Rows[e.RowIndex].Cells[2].Value);
                coord[2] = Convert.ToInt32(WaferMonuter.Rows[e.RowIndex].Cells[3].Value);
                coord[3] = Convert.ToInt32(WaferMonuter.Rows[e.RowIndex].Cells[4].Value);
                Wafer_Id.Text = WaferMonuter.Rows[e.RowIndex].Cells[0].Value.ToString();
                TTV.Text = WaferMonuter.Rows[e.RowIndex].Cells[5].Value.ToString();
                BOW.Text = WaferMonuter.Rows[e.RowIndex].Cells[6].Value.ToString();
                WARP.Text = WaferMonuter.Rows[e.RowIndex].Cells[7].Value.ToString();
                THK.Text = WaferMonuter.Rows[e.RowIndex].Cells[8].Value.ToString();
                MSCode.Text = WaferMonuter.Rows[e.RowIndex].Cells[9].Value.ToString();
                Cur_Equip.Text = WaferMonuter.Rows[e.RowIndex].Cells[10].Value.ToString();
                RPM.Text = WaferMonuter.Rows[e.RowIndex].Cells[12].Value.ToString();
                updateTTV.Text = (int.Parse(flagTTV.Text) - int.Parse(TTV.Text)).ToString();
                updateBOW.Text = (int.Parse(flagBOW.Text) - int.Parse(BOW.Text)).ToString();
                updateWARP.Text = (int.Parse(flagWARP.Text) - int.Parse(WARP.Text)).ToString();
                updateTHK.Text = (int.Parse(flagTHK.Text) - int.Parse(THK.Text)).ToString();

                Size size = new Size(225, 200);
                Bitmap myBitmap = new Bitmap(@".\image\waferimg.bmp");
                Bitmap bit = new Bitmap(myBitmap, size);
                curr_State.Image = bit;
            }
            else
            {
                return;
            }
        }
        //좌표값들을 받아와서 픽쳐박스 위에 점을 찍어줌
        private void Curr_State_Paint(object sender, PaintEventArgs e)
        {
            if (coord[0] != 0)
            {
                Rectangle currState1 = new Rectangle(coord[0], coord[1], 10, 10);
                using (Pen pen = new Pen(Color.Red, 2))
                {
                    e.Graphics.DrawRectangle(pen, currState1);
                }
                Rectangle currState2 = new Rectangle(coord[2], coord[3], 10, 10);
                using (Pen pen = new Pen(Color.Red, 2))
                {
                    e.Graphics.DrawRectangle(pen, currState2);
                }
            }
        }
        //웨이퍼ID를 입력 후 검색버튼 클릭시 검색하고자 하는 웨이퍼가 나옴
        private void LotSearch_Click(object sender, EventArgs e)
        {
            TcpSocket tcp = new TcpSocket(); //공통된 기능을 불러오기 위해 TcpSocket클래스 객체를 생성
            string send = "{\"wafer_select_data\":\"" + lotNum.Text.ToString() + "\"}";
            tcp.ConnectServer(); //서버 연결 시작
            byte[] sendMsg = Encoding.UTF8.GetBytes(send);
            byte[] buff = tcp.DataParse(sendMsg);
            tcp.Request(buff); //서버로 데이터를 보내줌
            JObject recvMsg = tcp.Response(); //서버에서 보내주는 데이터를 받아서 응답하는 함수를 recvMsg 변수에 저장
            tcp.Close(); //서버 연결 해제

            DataTable search = new DataTable();
            //table의 칼럼 지정
            search.Columns.Add("웨이퍼ID", typeof(string));
            search.Columns.Add("측정1(X좌표)", typeof(string));
            search.Columns.Add("측정1(Y좌표)", typeof(string));
            search.Columns.Add("측정2(X좌표)", typeof(string));
            search.Columns.Add("측정2(Y좌표)", typeof(string));
            search.Columns.Add("평탄도", typeof(string));
            search.Columns.Add("볼록함", typeof(string));
            search.Columns.Add("뒤틀림", typeof(string));
            search.Columns.Add("두께", typeof(string));
            search.Columns.Add("제품정보", typeof(string));
            search.Columns.Add("장비ID", typeof(string));
            search.Columns.Add("공정ID", typeof(string));
            search.Columns.Add("RPM", typeof(string));
            //칼럼별 value값 지정
            JArray searchs = (JArray)recvMsg["wafer_select_data"]; //jsonarray형식의 변수지정 후 서버에서 받은 데이터를 저장
            int len = searchs.Count; //json배열의 길이

            for (int i = 0; i < len; i++) //배열의 길이만큼 반복문을 돌려 DB에 있는 이용자를 모두 user에 저장
            {
                search.Rows.Add(searchs[i]["wafer_id"], searchs[i]["wafer_pX1"], searchs[i]["wafer_pY1"], searchs[i]["wafer_pX2"], searchs[i]["wafer_pY2"],
                searchs[i]["curr_ttv"], searchs[i]["curr_bow"], searchs[i]["curr_warp"], searchs[i]["curr_thk"], searchs[i]["mscode"],
                searchs[i]["equip_id"], searchs[i]["oper_id"], searchs[i]["equip_rpm"]);
            }
            //값들을 테이블에 표시
            WaferMonuter.DataSource = search;

            lotNum.Text = string.Empty;
        }
        //검색창에 웨이퍼ID 입력후 엔터를 누르면 검색버튼이 눌러지는 이벤트
        private void LotNum_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.LotSearch_Click(sender, e);
            }
        }

        private void WaferMonitering_Shown(object sender, EventArgs e)
        {
            WaferMonuter.CurrentCell = null;
        }

        private void exit_btn_Click(object sender, EventArgs e)
        {
            threadFlag = false;
            this.Visible = false;
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
