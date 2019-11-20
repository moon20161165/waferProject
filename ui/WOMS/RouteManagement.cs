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
using System.Collections;

namespace WOMS
{
    public partial class RouteManagement : UserControl
    {
        string selectRoute = null;
        //등록된 경로들을 테이블에 표시하는 함수(새로고침)
        public void init()
        {
            TcpSocket tcp = new TcpSocket(); //공통된 기능을 불러오기 위해 TcpSocket클래스 객체를 생성
            string send = "{\"route\":\"null\"}";
            tcp.ConnectServer(); //서버 연결 시작
            byte[] sendMsg = Encoding.UTF8.GetBytes(send);
            byte[] buff = tcp.DataParse(sendMsg);
            tcp.Request(buff); //서버로 데이터를 보내줌
            JObject recvMsg = tcp.Response(); //서버에서 보내주는 데이터를 받아서 응답하는 함수를 recvMsg 변수에 저장
            tcp.Close(); //서버 연결 해제

            DataTable route = new DataTable();
            //table의 칼럼 지정
            route.Columns.Add("경로ID", typeof(string));

            //칼럼별 value값 지정
            JArray routes = (JArray)recvMsg["route_id"]; //jsonarray형식의 변수지정 후 서버에서 받은 데이터를 저장
            int len = routes.Count; //json배열의 길이

            for (int i = 0; i < len; i++) //배열의 길이만큼 반복문을 돌려 DB에 있는 이용자를 모두 user에 저장
            {
                route.Rows.Add(routes[i]);
            }
            //값들을 테이블에 표시
            SelectRt.DataSource = route;
        }
        //첫 화면에 등록된 경로들을 테이블에 보여줌
        public RouteManagement()
        {
            InitializeComponent();
            init();
        }
        //나가기 버튼 클릭시 메뉴화면으로 돌아감
        private void Back_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Menu menu = new Menu();
            menu.ShowDialog();
        }
        //원하는 경로를 테이블에서 선택시 해당 경로들을 텍스트박스에 표시
        private void SelectRt_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                selectRoute = SelectRt.Rows[e.RowIndex].Cells[0].Value.ToString();
                TcpSocket tcp = new TcpSocket(); //공통된 기능을 불러오기 위해 TcpSocket클래스 객체를 생성
                string send = "{\"route_id\":\"" + selectRoute + "\"}";
                tcp.ConnectServer(); //서버 연결 시작
                byte[] sendMsg = Encoding.UTF8.GetBytes(send);
                byte[] buff = tcp.DataParse(sendMsg);
                tcp.Request(buff); //서버로 데이터를 보내줌
                JObject recvMsg = tcp.Response(); //서버에서 보내주는 데이터를 받아서 응답하는 함수를 recvMsg 변수에 저장
                tcp.Close(); //서버 연결 해제

                JArray routes = (JArray)recvMsg["route"]; //jsonarray형식의 변수지정 후 서버에서 받은 데이터를 저장
                int len = routes.Count;
                ArrayList curList = new ArrayList();
                string[] nextList = new string[6];

                for (int i = 0; i < len; i++)
                {
                    curList.Add(routes[i]["curr_route"].ToString());
                }
                curList.Remove("SAWING");
                for (int i = 0; i < len; i++)
                {
                    for (int j = 0; j < curList.Count; j++)
                    {
                        if (routes[i]["next_route"].ToString().Equals(curList[j].ToString()))
                        {
                            nextList[i] = routes[i]["next_route"].ToString();
                            curList.Remove(curList[j]);
                        }
                    }
                }
                route1.Text = "SAWING";
                route2.Text = nextList[0];
                route3.Text = nextList[1];
                route4.Text = nextList[2];
                route5.Text = nextList[3];
                route6.Text = nextList[4];
                route7.Text = nextList[5];
            }
            else
            {
                return;
            }
        }
        //추가할 경로들을 선택 후 추가버튼을 누르면 추가되고 새로고침
        private void Add_Click(object sender, EventArgs e)
        {
            if (routeAdd.CheckedItems.Count == 0)
            {
                MetroFramework.MetroMessageBox.Show(this, "공장을 선택해주세요!!!", "FAILED", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                TcpSocket tcp = new TcpSocket(); //공통된 기능을 불러오기 위해 TcpSocket클래스 객체를 생성
                JsonParsing json = new JsonParsing(); //데이터를 받아오기 위해 클래스의 객체를 생성
                string[] selectRt = new string[routeAdd.CheckedItems.Count];
                for (int i = 0; i < routeAdd.CheckedItems.Count; i++)
                {
                    selectRt[i] = routeAdd.CheckedItems[i].ToString();
                }
                tcp.ConnectServer(); //서버 연결 시작

                byte[] route_data = json.RouteParse(selectRt);
                byte[] route_info = tcp.DataParse(route_data); //바이트로 바꾼 데이터를 파싱
                tcp.Request(route_info); //서버로 데이터를 보내줌

                JObject recvMsg = tcp.Response(); //서버에서 보내주는 데이터를 받아서 응답하는 함수를 recvMsg 변수에 저장

                tcp.Close(); //서버 연결 해제

                int val = Convert.ToInt32(recvMsg["route_add_status"]);

                if (val == 1) //val=1이면 로그인 성공
                {
                    init();
                    SelectRt.CurrentCell = null;
                    MetroFramework.MetroMessageBox.Show(this, "추가 성공하였습니다.", "SUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else //아니면 실패
                {
                    SelectRt.CurrentCell = null;
                    MetroFramework.MetroMessageBox.Show(this, "추가 실패하였습니다.", "FAILED", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                for (int i = 0; i < routeAdd.Items.Count; i++)
                {
                    routeAdd.SetItemChecked(i, false);
                }
            }
        }
        //삭제하고 싶은 경로를 테이블에서 선택 후 삭제버튼을 누리면 삭제 후 새로고침
        private void RouteDel_Click(object sender, EventArgs e)
        {
            TcpSocket tcp = new TcpSocket(); //공통된 기능을 불러오기 위해 TcpSocket클래스 객체를 생성
            string send = "{\"route_del\":\"" + selectRoute + "\"}";
            tcp.ConnectServer(); //서버 연결 시작
            byte[] sendMsg = Encoding.UTF8.GetBytes(send);
            byte[] buff = tcp.DataParse(sendMsg);
            tcp.Request(buff); //서버로 데이터를 보내줌
            JObject recvMsg = tcp.Response(); //서버에서 보내주는 데이터를 받아서 응답하는 함수를 recvMsg 변수에 저장
            tcp.Close(); //서버 연결 해제

            int val = Convert.ToInt32(recvMsg["route_del_status"]); //json형태의 데이터에 login_status라는 이름의 값을 찾아서 val변수에 저장

            if (val == 1)
            {
                init();
                SelectRt.CurrentCell = null;
                route2.Text = string.Empty;
                route1.Text = string.Empty;
                route3.Text = string.Empty;
                route4.Text = string.Empty;
                route5.Text = string.Empty;
                route6.Text = string.Empty;
                route7.Text = string.Empty;
                MetroFramework.MetroMessageBox.Show(this, "삭제 성공하였습니다.", "SUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else //아니면 실패
            {
                SelectRt.CurrentCell = null;
                MetroFramework.MetroMessageBox.Show(this, "삭제 실패하였습니다.ㅠ", "FAILED", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void RouteManagement_Shown(object sender, EventArgs e)
        {
            SelectRt.CurrentCell = null;
        }
    }
}
