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
    public partial class DataManagement : UserControl
    {
        int cur_page = 1;
        int totalPage = 1;
        string oper;

        public DataManagement()
        {
            InitializeComponent();
        }

        public void WaferOper(JObject recvMsg)
        {
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
            JArray moniters = (JArray)recvMsg["wafer_data_oper"]; //jsonarray형식의 변수지정 후 서버에서 받은 데이터를 저장
            int len = moniters.Count; //json배열의 길이

            for (int i = 0; i < len; i++) //배열의 길이만큼 반복문을 돌려 DB에 있는 이용자를 모두 user에 저장
            {
                moniter.Rows.Add(moniters[i]["wafer_id"], moniters[i]["wafer_pX1"], moniters[i]["wafer_pY1"], moniters[i]["wafer_pX2"], moniters[i]["wafer_pY2"],
                moniters[i]["curr_ttv"], moniters[i]["curr_bow"], moniters[i]["curr_warp"], moniters[i]["curr_thk"], moniters[i]["mscode"],
                moniters[i]["equip_id"], moniters[i]["oper_id"], moniters[i]["equip_rpm"]);
            }
            //값들을 테이블에 표시
            Data_Grid.DataSource = moniter;
            Data_Grid.CurrentCell = null;
        }
        //잉곳 공정 선택시 잉곳 공정을 테이블에 표시하는 함수
        public void IngotOper(JObject recvMsg)
        {
            DataTable ingot = new DataTable();
            //table의 칼럼 지정
            ingot.Columns.Add("잉곳ID", typeof(string));
            ingot.Columns.Add("현재온도", typeof(string));
            ingot.Columns.Add("현재속도", typeof(string));
            ingot.Columns.Add("현재길이", typeof(string));
            ingot.Columns.Add("현재시간", typeof(string));
            //칼럼별 value값 지정
            JArray ingots = (JArray)recvMsg["ingot_data_oper"]; //jsonarray형식의 변수지정 후 서버에서 받은 데이터를 저장
            int len = ingots.Count; //json배열의 길이

            for (int i = 0; i < len; i++) //배열의 길이만큼 반복문을 돌려 DB에 있는 이용자를 모두 user에 저장
            {
                ingot.Rows.Add(ingots[i]["ingot_id"], ingots[i]["curr_temp"], ingots[i]["curr_vel"], ingots[i]["curr_len"],
                ingots[i]["curr_time"]);
            }
            //값들을 테이블에 표시
            Data_Grid.DataSource = ingot;
            Data_Grid.CurrentCell = null;
        }

        public void SelectOper(string _oper, int _page)
        {
            TcpSocket tcp = new TcpSocket();
            JsonParsing json = new JsonParsing();

            tcp.ConnectServer();
            byte[] data_oper = json.DataOperParse(oper, Convert.ToInt32(count.Text), cur_page);
            byte[] oper_info = tcp.DataParse(data_oper);
            tcp.Request(oper_info); //서버로 데이터를 보내줌
            JObject recvMsg = tcp.Response(); //서버에서 보내주는 데이터를 받아서 응답하는 함수를 recvMsg 변수에 저장
            int cnt = Convert.ToInt32(count.Text);
            totalPage = Convert.ToInt32(recvMsg["data_cnt"]) / cnt;
            if (totalPage % cnt != 0)
            {
                totalPage += 1;
            }
            tcp.Close();

            if (recvMsg.ContainsKey("ingot_data_oper"))
            {
                Data_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                IngotOper(recvMsg);
            }
            else if (recvMsg.ContainsKey("wafer_data_oper"))
            {
                Data_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                WaferOper(recvMsg);
            }
            page.Text = cur_page.ToString() + " / " + totalPage.ToString();
        }
        //원하는 공정을 선택하기 위해 콤보박스 클릭시 DB에 있는 공정테이블을 불러옴
        private void Select_Oper_Click(object sender, EventArgs e)
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
            select_Oper.Items.Clear();
            string[] selectOper = equips.ToObject<string[]>();
            select_Oper.Items.AddRange(selectOper);
            select_Oper.Items.Remove("BLOCK");
        }
        //원하는 공정 선택시 웨이퍼 공정이면 웨이퍼 테이블, 잉곳 공정이면 잉곳 테이블을 보여줌
        private void Select_Oper_SelectedIndexChanged(object sender, EventArgs e)
        {
            cur_page = 1;
            oper = select_Oper.SelectedItem.ToString();
            SelectOper(oper, cur_page);
        }

        private void DataManagement_Shown(object sender, EventArgs e)
        {
            Data_Grid.CurrentCell = null;
        }

        private void Next_Click(object sender, EventArgs e)
        {
            if(cur_page == totalPage)
            {
                MetroFramework.MetroMessageBox.Show(this, "다음 페이지가 없습니다.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            cur_page += 1;
            SelectOper(oper, cur_page);
        }

        private void Before_Click(object sender, EventArgs e)
        {
            if(cur_page == 1)
            {
                MetroFramework.MetroMessageBox.Show(this, "이전 페이지가 없습니다.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            cur_page -= 1;
            SelectOper(oper, cur_page);
        }

        private void End_Click(object sender, EventArgs e)
        {
            cur_page = totalPage;
            SelectOper(oper, cur_page);
        }

        private void First_Click(object sender, EventArgs e)
        {
            cur_page = 1;
            SelectOper(oper, cur_page);
        }
    }
}
