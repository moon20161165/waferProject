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
    public partial class WaferManagement : UserControl
    {
        string selectwafer = null;
        //등록된 모든 웨이퍼들을 테이블에 보여주는 함수(새로고침)
        public void init()
        {
            TcpSocket tcp = new TcpSocket(); //공통된 기능을 불러오기 위해 TcpSocket클래스 객체를 생성
            string send = "{\"wafer_manage\":\"null\"}";
            tcp.ConnectServer(); //서버 연결 시작
            byte[] sendMsg = Encoding.UTF8.GetBytes(send);
            byte[] buff = tcp.DataParse(sendMsg);
            tcp.Request(buff); //서버로 데이터를 보내줌
            JObject recvMsg = tcp.Response(); //서버에서 보내주는 데이터를 받아서 응답하는 함수를 recvMsg 변수에 저장
            tcp.Close(); //서버 연결 해제

            DataTable wafer = new DataTable();
            //table의 칼럼 지정
            wafer.Columns.Add("웨이퍼ID", typeof(string));
            wafer.Columns.Add("잉곳ID", typeof(string));
            wafer.Columns.Add("블록ID", typeof(string));
            wafer.Columns.Add("수량", typeof(string));
            wafer.Columns.Add("생성일 수", typeof(string));
            wafer.Columns.Add("시작 시간", typeof(string));
            wafer.Columns.Add("완료 시간", typeof(string));
            wafer.Columns.Add("설명", typeof(string));
            wafer.Columns.Add("불량 수량", typeof(string));
            wafer.Columns.Add("현재 공정", typeof(string));
            wafer.Columns.Add("제품정보", typeof(string));
            wafer.Columns.Add("사용 된 장비", typeof(string));
            wafer.Columns.Add("생성자", typeof(string));
            //칼럼별 value값 지정
            JArray wafers = (JArray)recvMsg["wafer"]; //jsonarray형식의 변수지정 후 서버에서 받은 데이터를 저장
            int len = wafers.Count; //json배열의 길이

            for (int i = 0; i < len; i++) //배열의 길이만큼 반복문을 돌려 DB에 있는 이용자를 모두 user에 저장
            {
                wafer.Rows.Add(wafers[i]["wafer_id"], wafers[i]["ingot_id"], wafers[i]["block_id"],
                wafers[i]["wafer_quant"], wafers[i]["wafer_create"], wafers[i]["wafer_start"], wafers[i]["wafer_finish"],
                wafers[i]["wafer_comm"], wafers[i]["wafer_fault"], wafers[i]["oper_id"], wafers[i]["mscode"],
                wafers[i]["equip_id"], wafers[i]["wafer_maker"]);
            }
            //값들을 테이블에 표시
            Wafer_Grid.DataSource = wafer;
        }
        //첫 화면에 등록된 모든 웨이퍼들을 테이블에 보여줌
        public WaferManagement()
        {
            InitializeComponent();
            init();
        }
        //모니터링 버튼 클릭시 모니터링 화면으로 넘어감
        private void Moniter_Click(object sender, EventArgs e)
        {
            WaferMonitering waferMonitering = new WaferMonitering();
            waferMonitering.ShowDialog();
        }
        //선택하고자하는 웨이트를 테이블에서 선택시 불량률을 테이블에 보여줌
        private void Wafer_Grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                selectwafer = Wafer_Grid.Rows[e.RowIndex].Cells[0].Value.ToString();
                TcpSocket tcp = new TcpSocket(); //공통된 기능을 불러오기 위해 TcpSocket클래스 객체를 생성
                string send = "{\"wafer_faulty_id\":\"" + selectwafer + "\"}";
                tcp.ConnectServer(); //서버 연결 시작
                byte[] sendMsg = Encoding.UTF8.GetBytes(send);
                byte[] buff = tcp.DataParse(sendMsg);
                tcp.Request(buff); //서버로 데이터를 보내줌
                JObject recvMsg = tcp.Response(); //서버에서 보내주는 데이터를 받아서 응답하는 함수를 recvMsg 변수에 저장
                tcp.Close(); //서버 연결 해제

                DataTable error = new DataTable();
                //table의 칼럼 지정
                error.Columns.Add("불량코드ID", typeof(string));
                error.Columns.Add("불량수량", typeof(string));
                //칼럼별 value값 지정
                JArray errors = (JArray)recvMsg["wafer_faulty"]; //jsonarray형식의 변수지정 후 서버에서 받은 데이터를 저장
                int len = errors.Count; //json배열의 길이

                for (int i = 0; i < len; i++)
                {
                    error.Rows.Add(errors[i]["faulty_id"], errors[i]["faulty_quant"]);
                }
                //값들을 테이블에 표시
                errorRate.DataSource = error;
            }
            else
            {
                return;
            }
        }
        //제작할 수량 및 정보를 입력 후 제작버튼을 클릭시 제작되며 테이블 새로고침
        private void Make_Click(object sender, EventArgs e)
        {
            if (selectMS.SelectedItem == null || Qty.Text.Equals("") || Comment.Text.Equals(""))
            {
                MetroFramework.MetroMessageBox.Show(this, "데이터를 입력해주세요 ㅠㅠ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                TcpSocket tcp = new TcpSocket(); //공통된 기능을 불러오기 위해 TcpSocket클래스 객체를 생성
                JsonParsing json = new JsonParsing(); //데이터를 받아오기 위해 클래스의 객체를 생성

                tcp.ConnectServer(); //서버 연결 시작

                byte[] wafer_data = json.WaferMakeParse(selectMS.SelectedItem.ToString(), Qty.Text, Comment.Text, Person.name);
                byte[] wafer_info = tcp.DataParse(wafer_data); //바이트로 바꾼 데이터를 파싱
                tcp.Request(wafer_info); //서버로 데이터를 보내줌

                JObject recvMsg = tcp.Response(); //서버에서 보내주는 데이터를 받아서 응답하는 함수를 recvMsg 변수에 저장

                tcp.Close(); //서버 연결 해제

                int val = Convert.ToInt32(recvMsg["wafer_add_status"]);

                if (val == 1)
                {
                    init();
                    Wafer_Grid.CurrentCell = null;
                    errorRate.CurrentCell = null;
                    Qty.Text = string.Empty;
                    Comment.Text = string.Empty;
                    selectMS.Items[selectMS.SelectedIndex] = string.Empty;
                    routeView.Clear();
                    MetroFramework.MetroMessageBox.Show(this, "생성을 시작합니다.", "SUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else //아니면 실패
                {
                    Wafer_Grid.CurrentCell = null;
                    errorRate.CurrentCell = null;
                    MetroFramework.MetroMessageBox.Show(this, "사용할 수 있는 장비가 없습니다.", "FAILED", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        //공정 검색을 위해 콤보박스 클릭시 DB에 있는 공정테이블을 불러옴
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
            equips.Remove(equips[0]);
            equips.Remove(equips[0]);
            select_Oper.Items.Clear();
            string[] selectOper = equips.ToObject<string[]>();
            select_Oper.Items.AddRange(selectOper);
        }
        //원하는 공정클릭시 해당 공정의 웨이퍼들이 테이블에 표시
        private void Select_Oper_SelectedIndexChanged(object sender, EventArgs e)
        {
            string oper = select_Oper.SelectedItem.ToString();
            TcpSocket tcp = new TcpSocket(); //공통된 기능을 불러오기 위해 TcpSocket클래스 객체를 생성
            string send = "{\"wafer_oper_id\":\"" + oper + "\"}";
            tcp.ConnectServer(); //서버 연결 시작
            byte[] sendMsg = Encoding.UTF8.GetBytes(send);
            byte[] buff = tcp.DataParse(sendMsg);
            tcp.Request(buff); //서버로 데이터를 보내줌
            JObject recvMsg = tcp.Response(); //서버에서 보내주는 데이터를 받아서 응답하는 함수를 recvMsg 변수에 저장
            tcp.Close(); //서버 연결 해제

            DataTable wafer = new DataTable();
            //table의 칼럼 지정
            wafer.Columns.Add("웨이퍼ID", typeof(string));
            wafer.Columns.Add("잉곳ID", typeof(string));
            wafer.Columns.Add("블록ID", typeof(string));
            wafer.Columns.Add("수량", typeof(string));
            wafer.Columns.Add("생성일 수", typeof(string));
            wafer.Columns.Add("시작 시간", typeof(string));
            wafer.Columns.Add("완료 시간", typeof(string));
            wafer.Columns.Add("설명", typeof(string));
            wafer.Columns.Add("불량 수량", typeof(string));
            wafer.Columns.Add("현재 공정", typeof(string));
            wafer.Columns.Add("제품정보", typeof(string));
            wafer.Columns.Add("사용 된 장비", typeof(string));
            wafer.Columns.Add("생성자", typeof(string));
            //칼럼별 value값 지정
            JArray wafers = (JArray)recvMsg["wafer_select"]; //jsonarray형식의 변수지정 후 서버에서 받은 데이터를 저장
            int len = wafers.Count; //json배열의 길이

            for (int i = 0; i < len; i++) //배열의 길이만큼 반복문을 돌려 DB에 있는 이용자를 모두 user에 저장
            {
                wafer.Rows.Add(wafers[i]["wafer_id"], wafers[i]["ingot_id"], wafers[i]["block_id"],
                wafers[i]["wafer_quant"], wafers[i]["wafer_create"], wafers[i]["wafer_start"], wafers[i]["wafer_finish"],
                wafers[i]["wafer_comm"], wafers[i]["wafer_fault"], wafers[i]["oper_id"], wafers[i]["mscode"],
                wafers[i]["equip_id"], wafers[i]["wafer_maker"]);
            }
            //값들을 테이블에 표시
            Wafer_Grid.DataSource = wafer;
        }
        //웨이퍼 제작시 적용시킬 제품정보 선택을 위해 콤보박스 클릭시 DB에서 제품정보 테이블을 불러옴
        private void SelectMS_Click(object sender, EventArgs e)
        {
            TcpSocket tcp = new TcpSocket(); //공통된 기능을 불러오기 위해 TcpSocket클래스 객체를 생성
            string send = "{\"mscode\":\"null\"}";
            tcp.ConnectServer(); //서버 연결 시작
            byte[] sendMsg = Encoding.UTF8.GetBytes(send);
            byte[] buff = tcp.DataParse(sendMsg);
            tcp.Request(buff); //서버로 데이터를 보내줌
            JObject recvMsg = tcp.Response(); //서버에서 보내주는 데이터를 받아서 응답하는 함수를 recvMsg 변수에 저장
            tcp.Close(); //서버 연결 해제

            JArray mscodes = (JArray)recvMsg["mscode"];
            int len = mscodes.Count;
            string[] selectMscode = new string[len];
            selectMS.Items.Clear();
            for (int i = 0; i < len; i++)
            {
                selectMscode[i] = mscodes[i]["mscode"].ToString();
            }
            selectMS.Items.AddRange(selectMscode);
        }
        //제작할 웨이퍼의 정보에 적용시킬 제품정보를 콤보박스로 선택시 해당 제품정보의 경로가 표시
        private void SelectMS_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectMs = selectMS.SelectedItem.ToString();
            TcpSocket tcp = new TcpSocket(); //공통된 기능을 불러오기 위해 TcpSocket클래스 객체를 생성
            string send = "{\"mscode_select\":\"" + selectMs + "\"}";
            tcp.ConnectServer(); //서버 연결 시작
            byte[] sendMsg = Encoding.UTF8.GetBytes(send);
            byte[] buff = tcp.DataParse(sendMsg);
            tcp.Request(buff); //서버로 데이터를 보내줌
            JObject recvMsg = tcp.Response(); //서버에서 보내주는 데이터를 받아서 응답하는 함수를 recvMsg 변수에 저장
            tcp.Close(); //서버 연결 해제

            JArray routes = (JArray)recvMsg["route_view"]; //jsonarray형식의 변수지정 후 서버에서 받은 데이터를 저장
            int len = routes.Count; //json배열의 길이
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
            routeView.BeginUpdate();
            routeView.Columns.Clear();
            routeView.Items.Clear();
            routeView.View = View.Details;
            routeView.Columns.Add("", 0);
            routeView.Columns.Add("ROUTE", -2, HorizontalAlignment.Center);
            ListViewItem lvi = new ListViewItem();
            lvi.SubItems.Add("SAWING");
            routeView.Items.Add(lvi);
            foreach (var item in nextList)
            {
                ListViewItem lvi2 = new ListViewItem();
                lvi2.SubItems.Add(item);
                routeView.Items.Add(lvi2);
            }
            routeView.EndUpdate();
        }
        //경로 ListView의 Column의 색을 지정
        private void RouteView_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            e.Graphics.FillRectangle(Brushes.DarkGray, e.Bounds);
            e.DrawText();
        }
        //경로 ListView의 SubItem의 색을 지정
        private void RouteView_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            e.Graphics.FillRectangle(Brushes.White, e.Bounds);
            e.DrawText();
        }

        private void WaferManagement_Shown(object sender, EventArgs e)
        {
            Wafer_Grid.CurrentCell = null;
            errorRate.CurrentCell = null;
        }
    }
}
