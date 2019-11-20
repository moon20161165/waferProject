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
using System.Threading;

namespace WOMS
{
    public partial class IngotCreate : UserControl
    {
        public static bool threadFlag = false;
        string selectIngot = null;
        string endTime = null;
        private Thread threadIngotStart;
        ProgressInfo pr = new ProgressInfo();

        private void Run()
        {
            while (threadFlag)
            {
                Console.WriteLine("스레드 반복 시작");
                TcpSocket tcp = new TcpSocket(); //공통된 기능을 불러오기 위해 TcpSocket클래스 객체를 생성
                string send = "{\"ingot_make\":\"null\"}";
                tcp.ConnectServer(); //서버 연결 시작
                byte[] sendMsg = Encoding.UTF8.GetBytes(send);
                byte[] buff = tcp.DataParse(sendMsg);
                tcp.Request(buff); //서버로 데이터를 보내줌
                JObject recvMsg = tcp.Response(); //서버에서 보내주는 데이터를 받아서 응답하는 함수를 recvMsg 변수에 저장
                tcp.Close(); //서버 연결 해제

                int makes = Convert.ToInt32(recvMsg["ingot_make"]);
                if (makes == 1)
                {
                    Add.Enabled = true;
                }
                else
                {
                    Add.Enabled = false;
                }
                if (selectIngot == null) //아무것도 클릭 안했을 때
                {
                    ingotMoniter.Value = 0;
                    ingotNum.Text = ingotMoniter.Value.ToString();
                }
                else if (endTime == null) //현재 진행 중인 잉곳을 클릭했을 때
                {
                    ingotMoniter.Value = ProgressInfo.status;
                    ingotNum.Text = ingotMoniter.Value.ToString();
                    if (ingotMoniter.Value == 100)
                    {
                        MetroFramework.MetroMessageBox.Show(this, "잉곳생성이 완료되었습니다.", "GOOD", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else //완료된 잉곳을 클릭했을 때
                {
                    ingotMoniter.Value = pr.getFullStatus();
                    ingotNum.Text = ingotMoniter.Value.ToString();
                }
                Thread.Sleep(1000);
            }
        }

        private void StartThread()
        {
            if (!threadFlag)
            {
                threadFlag = true;
                threadIngotStart = new Thread(new ThreadStart(Run));
                threadIngotStart.IsBackground = true;
                threadIngotStart.Start();
            }
        }

        private void StopThread()
        {
            if (threadFlag)
            {
                threadFlag = false;
                threadIngotStart.Join();
            }
        }
        //잉곳 테이블을 조회하는 함수(새로고침)
        public void init()
        {
            TcpSocket tcp = new TcpSocket(); //공통된 기능을 불러오기 위해 TcpSocket클래스 객체를 생성
            string send = "{\"ingot_manage\":\"null\"}";
            tcp.ConnectServer(); //서버 연결 시작
            byte[] sendMsg = Encoding.UTF8.GetBytes(send);
            byte[] buff = tcp.DataParse(sendMsg);
            tcp.Request(buff); //서버로 데이터를 보내줌
            JObject recvMsg = tcp.Response(); //서버에서 보내주는 데이터를 받아서 응답하는 함수를 recvMsg 변수에 저장
            tcp.Close(); //서버 연결 해제

            DataTable ingot = new DataTable();
            //table의 칼럼 지정
            ingot.Columns.Add("잉곳ID", typeof(string));
            ingot.Columns.Add("생성진행현황", typeof(string));
            ingot.Columns.Add("생성 일 수", typeof(string));
            ingot.Columns.Add("시작시간", typeof(string));
            ingot.Columns.Add("완료시간", typeof(string));
            ingot.Columns.Add("장비ID", typeof(string));
            ingot.Columns.Add("생성자", typeof(string));
            //칼럼별 value값 지정
            JArray ingots = (JArray)recvMsg["ingot_manage"]; //jsonarray형식의 변수지정 후 서버에서 받은 데이터를 저장
            int len = ingots.Count; //json배열의 길이

            for (int i = 0; i < len; i++) //배열의 길이만큼 반복문을 돌려 DB에 있는 이용자를 모두 user에 저장
            {
                ingot.Rows.Add(ingots[i]["ingot_id"], ingots[i]["ingot_state"], ingots[i]["ingot_create"], ingots[i]["ingot_start"],
                ingots[i]["ingot_finish"], ingots[i]["equip_id"], ingots[i]["ingot_maker"]);
            }
            //값들을 테이블에 표시
            Ingot_Grid.DataSource = ingot;
        }
        //첫화면에 잉곳 테이블 조회
        public IngotCreate()
        {
            InitializeComponent();
            init();
            StartThread();
        }

        private void IngotCreate_Shown(object sender, EventArgs e)
        {
            Ingot_Grid.CurrentCell = null;
            //ingotMoniter.Value = 0;
        }
        //테이블의 행 클릭시 행에 있는 값을 받아와서 텍스트박스에 보여줌
        private void Ingot_Grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                endTime = null;
                selectIngot = Ingot_Grid.Rows[e.RowIndex].Cells[0].Value.ToString();
                TcpSocket tcp = new TcpSocket(); //공통된 기능을 불러오기 위해 TcpSocket클래스 객체를 생성
                string send = "{\"ingot_id\":\"" + selectIngot + "\"}";
                tcp.ConnectServer(); //서버 연결 시작
                byte[] sendMsg = Encoding.UTF8.GetBytes(send);
                byte[] buff = tcp.DataParse(sendMsg);
                tcp.Request(buff); //서버로 데이터를 보내줌
                JObject recvMsg = tcp.Response(); //서버에서 보내주는 데이터를 받아서 응답하는 함수를 recvMsg 변수에 저장
                tcp.Close(); //서버 연결 해제

                JArray ingots = (JArray)recvMsg["ingot_data"];
                int len = ingots.Count - 1;
                if (ingots.Count == 0)
                {
                    Ingot_Id.Text = string.Empty;
                    Cur_Temp.Text = string.Empty;
                    Cur_Vel.Text = string.Empty;
                    Cur_Len.Text = string.Empty;
                    StartTime.Text = string.Empty;
                    RestTime.Text = string.Empty;
                    User_Name.Text = string.Empty;
                    //MetroFramework.MetroMessageBox.Show(this, "데이터가 없습니다.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    Ingot_Id.Text = ingots[len]["ingot_id"].ToString();
                    Cur_Temp.Text = ingots[len]["curr_temp"].ToString() + "℃";
                    Cur_Vel.Text = ingots[len]["curr_vel"].ToString() + "rpm";
                    Cur_Len.Text = ingots[len]["curr_len"].ToString() + "m";
                    StartTime.Text = Ingot_Grid.Rows[e.RowIndex].Cells[3].Value.ToString();
                    endTime = Ingot_Grid.Rows[e.RowIndex].Cells[4].Value.ToString();
                    if (endTime.Equals(""))
                    {
                        RestTime.Text = "진행중...";
                    }
                    else
                    {
                        TimeSpan date = DateTime.Parse(endTime) - DateTime.Parse(StartTime.Text);
                        RestTime.Text = date.Days.ToString() + "일" + date.Hours.ToString() + "시간" + date.Minutes.ToString() + "분" + date.Seconds.ToString() + "초";
                    }
                    User_Name.Text = Person.name;
                }
            }
            else
            {
                return;
            }
        }
        //생성버튼 클릭시 생성과 함께 테이블 새로고침
        private void Add_Click(object sender, EventArgs e)
        {
            TcpSocket tcp = new TcpSocket(); //공통된 기능을 불러오기 위해 TcpSocket클래스 객체를 생성
            string send = "{\"ingot_start\":" + 1 + ", \"ingot_maker\":\"" + Person.name + "\"}";
            tcp.ConnectServer(); //서버 연결 시작
            byte[] sendMsg = Encoding.UTF8.GetBytes(send);
            byte[] buff = tcp.DataParse(sendMsg);
            tcp.Request(buff); //서버로 데이터를 보내줌
            JObject recvMsg = tcp.Response(); //서버에서 보내주는 데이터를 받아서 응답하는 함수를 recvMsg 변수에 저장
            tcp.Close(); //서버 연결 해제

            int val = Convert.ToInt32(recvMsg["ingot_create_status"]);

            if (val == 1) //val=1이면 로그인 성공
            {
                init();
                Ingot_Grid.CurrentCell = null;
                MetroFramework.MetroMessageBox.Show(this, "잉곳을 생성합니다.", "GOOD", MessageBoxButtons.OK, MessageBoxIcon.Information);
                pr.Start();
            }
            else //아니면 실패
            {
                Ingot_Grid.CurrentCell = null;
                MetroFramework.MetroMessageBox.Show(this, "잉곳 생산에 실패하였습니다..", "FAILED", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
