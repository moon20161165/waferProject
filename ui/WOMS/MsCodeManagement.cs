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
    public partial class MsCodeManagement : UserControl
    {
        string selectMS = null;
        JArray mscodes = null;
        //등록된 제품정보들을 테이블에 보여주는 함수(새로고침)
        public void init()
        {
            TcpSocket tcp = new TcpSocket(); //공통된 기능을 불러오기 위해 TcpSocket클래스 객체를 생성
            string send = "{\"mscode\":\"null\"}";
            tcp.ConnectServer(); //서버 연결 시작
            byte[] sendMsg = Encoding.UTF8.GetBytes(send);
            byte[] buff = tcp.DataParse(sendMsg);
            tcp.Request(buff); //서버로 데이터를 보내줌
            JObject recvMsg = tcp.Response(); //서버에서 보내주는 데이터를 받아서 응답하는 함수를 recvMsg 변수에 저장
            tcp.Close(); //서버 연결 해제

            DataTable mscode = new DataTable();
            //table의 칼럼 지정
            mscode.Columns.Add("제품정보", typeof(string));
            //칼럼별 value값 지정
            mscodes = (JArray)recvMsg["mscode"]; //jsonarray형식의 변수지정 후 서버에서 받은 데이터를 저장
            int len = mscodes.Count; //json배열의 길이

            for (int i = 0; i < len; i++) //배열의 길이만큼 반복문을 돌려 DB에 있는 이용자를 모두 user에 저장
            {
                mscode.Rows.Add(mscodes[i]["mscode"]);
            }
            //값들을 테이블에 표시
            msCodeName.DataSource = mscode;
        }
        //첫 화면에 등록된 제품정보들을 테이블에 보여줌
        public MsCodeManagement()
        {
            InitializeComponent();
            init();
        }
        //추가하고자하는 제품정보를 입력후 추가버튼을 클릭하면 추가가 되며 새로고침
        private void Add_Click(object sender, EventArgs e)
        {
            TcpSocket tcp = new TcpSocket(); //공통된 기능을 불러오기 위해 TcpSocket클래스 객체를 생성
            JsonParsing json = new JsonParsing(); //데이터를 받아오기 위해 클래스의 객체를 생성

            if (MSCodeId_add.Text == "" || corpName_add.Text == "" || corpMan_add.Text == "" || routeId_add.SelectedItem == null)
            {
                MetroFramework.MetroMessageBox.Show(this, "정보를 입력하세요 !!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                tcp.ConnectServer(); //서버 연결 시작
                byte[] mscode_data = json.MSCodeAddParse(MSCodeId_add.Text, corpName_add.Text, corpComment_add.Text, corpMan_add.Text, routeId_add.SelectedItem.ToString()); //아이디와 패스워드를 json형식으로 받아와서 바이트로 바꿔줌
                byte[] mscode_info = tcp.DataParse(mscode_data); //바이트로 바꾼 데이터를 파싱
                tcp.Request(mscode_info); //서버로 데이터를 보내줌
                JObject recvMsg = tcp.Response(); //서버에서 보내주는 데이터를 받아서 응답하는 함수를 recvMsg 변수에 저장

                tcp.Close(); //서버 연결 해제

                int val = Convert.ToInt32(recvMsg["mscode_add_status"]); //json형태의 데이터에 login_status라는 이름의 값을 찾아서 val변수에 저장

                if (val == 1) //val=1이면 로그인 성공
                {
                    init();
                    msCodeName.CurrentCell = null;
                    MSCodeId_add.Text = string.Empty;
                    corpName_add.Text = string.Empty;
                    corpMan_add.Text = string.Empty;
                    corpComment_add.Text = string.Empty;
                    routeId_add.Items[routeId_add.SelectedIndex] = string.Empty;
                    MetroFramework.MetroMessageBox.Show(this, "등록 성공하였습니다.", "SUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else //아니면 실패
                {
                    msCodeName.CurrentCell = null;
                    MetroFramework.MetroMessageBox.Show(this, "등록 실패하였습니다.", "FAILED", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        //제품정보 테이블에서 원하는 제품정보를 클릭하면 선택한 제품정보의 정보들이 텍스트박스에 표시됨
        private void MsCodeName_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                int len = mscodes.Count;
                selectMS = msCodeName.Rows[e.RowIndex].Cells[0].Value.ToString();
                for (int i = 0; i < len; i++)
                {
                    if (mscodes[i]["mscode"].ToString() == selectMS)
                    {
                        mscodeId.Text = mscodes[i]["mscode"].ToString();
                        corpName.Text = mscodes[i]["corp_name"].ToString();
                        corpComm.Text = mscodes[i]["corp_comm"].ToString();
                        corpMan.Text = mscodes[i]["corp_man"].ToString();
                        routeId.Text = mscodes[i]["route_id"].ToString();
                        create.Text = mscodes[i]["mscode_create"].ToString();
                    }
                }
            }
            else
            {
                return;
            }
        }
        //삭제하고싶은 제품정보를 테이블에서 선택 후 삭제 버튼을 클릭시 삭제가 되며 새로고침
        private void MSCodeDel_Click(object sender, EventArgs e)
        {
            TcpSocket tcp = new TcpSocket(); //공통된 기능을 불러오기 위해 TcpSocket클래스 객체를 생성
            string send = "{\"mscode_del\":\"" + selectMS + "\"}";
            tcp.ConnectServer(); //서버 연결 시작
            byte[] sendMsg = Encoding.UTF8.GetBytes(send);
            byte[] buff = tcp.DataParse(sendMsg);
            tcp.Request(buff); //서버로 데이터를 보내줌
            JObject recvMsg = tcp.Response(); //서버에서 보내주는 데이터를 받아서 응답하는 함수를 recvMsg 변수에 저장
            tcp.Close(); //서버 연결 해제

            int val = Convert.ToInt32(recvMsg["mscode_del_status"]); //json형태의 데이터에 login_status라는 이름의 값을 찾아서 val변수에 저장

            if (val == 1)
            {
                init();
                msCodeName.CurrentCell = null;
                mscodeId.Text = string.Empty;
                corpName.Text = string.Empty;
                corpComm.Text = string.Empty;
                corpMan.Text = string.Empty;
                routeId.Text = string.Empty;
                create.Text = string.Empty;
                MetroFramework.MetroMessageBox.Show(this, "삭제 성공하였습니다.", "SUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else //아니면 실패
            {
                msCodeName.CurrentCell = null;
                MetroFramework.MetroMessageBox.Show(this, "삭제 실패하였습니다.", "FAILED", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        //제품정보를 추가할 때 경로를 선택하기 위해 콤보박스 클릭시 DB에 있는 경로테이블을 불러옴
        private void RouteId_add_Click(object sender, EventArgs e)
        {
            TcpSocket tcp = new TcpSocket(); //공통된 기능을 불러오기 위해 TcpSocket클래스 객체를 생성
            string send = "{\"route\":\"null\"}";
            tcp.ConnectServer(); //서버 연결 시작
            byte[] sendMsg = Encoding.UTF8.GetBytes(send);
            byte[] buff = tcp.DataParse(sendMsg);
            tcp.Request(buff); //서버로 데이터를 보내줌
            JObject recvMsg = tcp.Response(); //서버에서 보내주는 데이터를 받아서 응답하는 함수를 recvMsg 변수에 저장
            tcp.Close(); //서버 연결 해제

            JArray routes = (JArray)recvMsg["route_id"]; //jsonarray형식의 변수지정 후 서버에서 받은 데이터를 저장
            routeId_add.Items.Clear();
            string[] selectRoute = routes.ToObject<string[]>();
            routeId_add.Items.AddRange(selectRoute);
        }

        private void MSCodeManagement_Shown(object sender, EventArgs e)
        {
            msCodeName.CurrentCell = null;
        }
    }
}
