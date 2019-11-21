namespace WOMS
{
    partial class IngotCreate
    {
        /// <summary> 
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            StopThread();
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary> 
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.RestTime = new System.Windows.Forms.TextBox();
            this.소요시간 = new System.Windows.Forms.TextBox();
            this.StartTime = new System.Windows.Forms.TextBox();
            this.슬래쉬 = new System.Windows.Forms.Label();
            this.Fin_Len = new System.Windows.Forms.TextBox();
            this.Cur_Len = new System.Windows.Forms.TextBox();
            this.진행현황 = new System.Windows.Forms.TextBox();
            this.Pro_Vel = new System.Windows.Forms.TextBox();
            this.Cur_Vel = new System.Windows.Forms.TextBox();
            this.속도 = new System.Windows.Forms.TextBox();
            this.Pro_Temp = new System.Windows.Forms.TextBox();
            this.Cur_Temp = new System.Windows.Forms.TextBox();
            this.온도 = new System.Windows.Forms.TextBox();
            this.User_Name = new System.Windows.Forms.TextBox();
            this.이용자 = new System.Windows.Forms.TextBox();
            this.Ingot_Id = new System.Windows.Forms.TextBox();
            this.Ingot = new System.Windows.Forms.TextBox();
            this.Add = new System.Windows.Forms.Button();
            this.모니터링 = new System.Windows.Forms.TextBox();
            this.Ingot_Title = new System.Windows.Forms.TextBox();
            this.Ingot_Grid = new MetroFramework.Controls.MetroGrid();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.시작시간 = new System.Windows.Forms.TextBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.ingotMoniter = new MetroFramework.Controls.MetroProgressBar();
            this.진척도 = new System.Windows.Forms.Label();
            this.ingotNum = new System.Windows.Forms.Label();
            this.퍼센트 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Ingot_Grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("굴림", 15F);
            this.label2.Location = new System.Drawing.Point(672, 450);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(18, 20);
            this.label2.TabIndex = 91;
            this.label2.Text = "/";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("굴림", 15F);
            this.label1.Location = new System.Drawing.Point(672, 403);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 20);
            this.label1.TabIndex = 90;
            this.label1.Text = "/";
            // 
            // RestTime
            // 
            this.RestTime.Font = new System.Drawing.Font("나눔스퀘어", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.RestTime.ForeColor = System.Drawing.Color.Black;
            this.RestTime.Location = new System.Drawing.Point(534, 576);
            this.RestTime.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.RestTime.Name = "RestTime";
            this.RestTime.Size = new System.Drawing.Size(229, 29);
            this.RestTime.TabIndex = 88;
            this.RestTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // 소요시간
            // 
            this.소요시간.BackColor = System.Drawing.Color.White;
            this.소요시간.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.소요시간.Font = new System.Drawing.Font("나눔스퀘어", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.소요시간.ForeColor = System.Drawing.Color.Black;
            this.소요시간.Location = new System.Drawing.Point(428, 576);
            this.소요시간.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.소요시간.Name = "소요시간";
            this.소요시간.ReadOnly = true;
            this.소요시간.Size = new System.Drawing.Size(100, 28);
            this.소요시간.TabIndex = 87;
            this.소요시간.Text = "소요시간";
            this.소요시간.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // StartTime
            // 
            this.StartTime.Font = new System.Drawing.Font("나눔스퀘어", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.StartTime.ForeColor = System.Drawing.Color.Black;
            this.StartTime.Location = new System.Drawing.Point(534, 534);
            this.StartTime.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.StartTime.Name = "StartTime";
            this.StartTime.Size = new System.Drawing.Size(255, 29);
            this.StartTime.TabIndex = 86;
            this.StartTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // 슬래쉬
            // 
            this.슬래쉬.AutoSize = true;
            this.슬래쉬.Font = new System.Drawing.Font("굴림", 15F);
            this.슬래쉬.Location = new System.Drawing.Point(672, 498);
            this.슬래쉬.Name = "슬래쉬";
            this.슬래쉬.Size = new System.Drawing.Size(18, 20);
            this.슬래쉬.TabIndex = 84;
            this.슬래쉬.Text = "/";
            // 
            // Fin_Len
            // 
            this.Fin_Len.Font = new System.Drawing.Font("나눔스퀘어", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Fin_Len.ForeColor = System.Drawing.Color.Black;
            this.Fin_Len.Location = new System.Drawing.Point(696, 491);
            this.Fin_Len.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Fin_Len.Name = "Fin_Len";
            this.Fin_Len.Size = new System.Drawing.Size(140, 29);
            this.Fin_Len.TabIndex = 83;
            this.Fin_Len.Text = "최종길이";
            this.Fin_Len.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Cur_Len
            // 
            this.Cur_Len.Font = new System.Drawing.Font("나눔스퀘어", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Cur_Len.ForeColor = System.Drawing.Color.Black;
            this.Cur_Len.Location = new System.Drawing.Point(534, 491);
            this.Cur_Len.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Cur_Len.Name = "Cur_Len";
            this.Cur_Len.Size = new System.Drawing.Size(132, 29);
            this.Cur_Len.TabIndex = 82;
            this.Cur_Len.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // 진행현황
            // 
            this.진행현황.BackColor = System.Drawing.Color.White;
            this.진행현황.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.진행현황.Font = new System.Drawing.Font("나눔스퀘어", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.진행현황.ForeColor = System.Drawing.Color.Black;
            this.진행현황.Location = new System.Drawing.Point(428, 490);
            this.진행현황.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.진행현황.Name = "진행현황";
            this.진행현황.ReadOnly = true;
            this.진행현황.Size = new System.Drawing.Size(100, 28);
            this.진행현황.TabIndex = 81;
            this.진행현황.Text = "진행현황";
            this.진행현황.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Pro_Vel
            // 
            this.Pro_Vel.Font = new System.Drawing.Font("나눔스퀘어", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Pro_Vel.ForeColor = System.Drawing.Color.Black;
            this.Pro_Vel.Location = new System.Drawing.Point(696, 446);
            this.Pro_Vel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Pro_Vel.Name = "Pro_Vel";
            this.Pro_Vel.Size = new System.Drawing.Size(140, 29);
            this.Pro_Vel.TabIndex = 80;
            this.Pro_Vel.Text = "적정속도";
            this.Pro_Vel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Cur_Vel
            // 
            this.Cur_Vel.Font = new System.Drawing.Font("나눔스퀘어", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Cur_Vel.ForeColor = System.Drawing.Color.Black;
            this.Cur_Vel.Location = new System.Drawing.Point(534, 446);
            this.Cur_Vel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Cur_Vel.Name = "Cur_Vel";
            this.Cur_Vel.Size = new System.Drawing.Size(132, 29);
            this.Cur_Vel.TabIndex = 79;
            this.Cur_Vel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // 속도
            // 
            this.속도.BackColor = System.Drawing.Color.White;
            this.속도.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.속도.Font = new System.Drawing.Font("나눔스퀘어", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.속도.ForeColor = System.Drawing.Color.Black;
            this.속도.Location = new System.Drawing.Point(428, 447);
            this.속도.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.속도.Name = "속도";
            this.속도.ReadOnly = true;
            this.속도.Size = new System.Drawing.Size(100, 28);
            this.속도.TabIndex = 78;
            this.속도.Text = "속도";
            this.속도.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Pro_Temp
            // 
            this.Pro_Temp.Font = new System.Drawing.Font("나눔스퀘어", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Pro_Temp.ForeColor = System.Drawing.Color.Black;
            this.Pro_Temp.Location = new System.Drawing.Point(696, 401);
            this.Pro_Temp.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Pro_Temp.Name = "Pro_Temp";
            this.Pro_Temp.Size = new System.Drawing.Size(140, 29);
            this.Pro_Temp.TabIndex = 77;
            this.Pro_Temp.Text = "적정온도";
            this.Pro_Temp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Cur_Temp
            // 
            this.Cur_Temp.Font = new System.Drawing.Font("나눔스퀘어", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Cur_Temp.ForeColor = System.Drawing.Color.Black;
            this.Cur_Temp.Location = new System.Drawing.Point(534, 401);
            this.Cur_Temp.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Cur_Temp.Name = "Cur_Temp";
            this.Cur_Temp.Size = new System.Drawing.Size(132, 29);
            this.Cur_Temp.TabIndex = 76;
            this.Cur_Temp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // 온도
            // 
            this.온도.BackColor = System.Drawing.Color.White;
            this.온도.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.온도.Font = new System.Drawing.Font("나눔스퀘어", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.온도.ForeColor = System.Drawing.Color.Black;
            this.온도.Location = new System.Drawing.Point(428, 402);
            this.온도.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.온도.Name = "온도";
            this.온도.ReadOnly = true;
            this.온도.Size = new System.Drawing.Size(100, 28);
            this.온도.TabIndex = 75;
            this.온도.Text = "온도";
            this.온도.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // User_Name
            // 
            this.User_Name.Font = new System.Drawing.Font("나눔스퀘어", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.User_Name.ForeColor = System.Drawing.Color.Black;
            this.User_Name.Location = new System.Drawing.Point(534, 616);
            this.User_Name.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.User_Name.Name = "User_Name";
            this.User_Name.Size = new System.Drawing.Size(229, 29);
            this.User_Name.TabIndex = 74;
            this.User_Name.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // 이용자
            // 
            this.이용자.BackColor = System.Drawing.Color.White;
            this.이용자.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.이용자.Font = new System.Drawing.Font("나눔스퀘어", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.이용자.ForeColor = System.Drawing.Color.Black;
            this.이용자.Location = new System.Drawing.Point(428, 617);
            this.이용자.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.이용자.Name = "이용자";
            this.이용자.ReadOnly = true;
            this.이용자.Size = new System.Drawing.Size(100, 28);
            this.이용자.TabIndex = 73;
            this.이용자.Text = "이용자";
            this.이용자.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Ingot_Id
            // 
            this.Ingot_Id.Font = new System.Drawing.Font("나눔스퀘어", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Ingot_Id.ForeColor = System.Drawing.Color.Black;
            this.Ingot_Id.Location = new System.Drawing.Point(534, 359);
            this.Ingot_Id.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Ingot_Id.Name = "Ingot_Id";
            this.Ingot_Id.Size = new System.Drawing.Size(229, 29);
            this.Ingot_Id.TabIndex = 72;
            this.Ingot_Id.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Ingot
            // 
            this.Ingot.BackColor = System.Drawing.Color.White;
            this.Ingot.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Ingot.Font = new System.Drawing.Font("나눔스퀘어", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Ingot.ForeColor = System.Drawing.Color.Black;
            this.Ingot.Location = new System.Drawing.Point(428, 360);
            this.Ingot.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Ingot.Name = "Ingot";
            this.Ingot.ReadOnly = true;
            this.Ingot.Size = new System.Drawing.Size(100, 28);
            this.Ingot.TabIndex = 71;
            this.Ingot.Text = "잉곳번호";
            this.Ingot.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Add
            // 
            this.Add.BackColor = System.Drawing.Color.White;
            this.Add.FlatAppearance.BorderSize = 0;
            this.Add.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Add.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Add.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Add.Font = new System.Drawing.Font("나눔스퀘어", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Add.ForeColor = System.Drawing.Color.Black;
            this.Add.Location = new System.Drawing.Point(712, 13);
            this.Add.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Add.Name = "Add";
            this.Add.Size = new System.Drawing.Size(212, 53);
            this.Add.TabIndex = 0;
            this.Add.Text = "잉곳 생성하기";
            this.Add.UseVisualStyleBackColor = false;
            this.Add.Click += new System.EventHandler(this.Add_Click);
            // 
            // 모니터링
            // 
            this.모니터링.BackColor = System.Drawing.Color.White;
            this.모니터링.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.모니터링.Font = new System.Drawing.Font("나눔스퀘어", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.모니터링.ForeColor = System.Drawing.Color.Black;
            this.모니터링.Location = new System.Drawing.Point(27, 352);
            this.모니터링.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.모니터링.Name = "모니터링";
            this.모니터링.ReadOnly = true;
            this.모니터링.Size = new System.Drawing.Size(218, 33);
            this.모니터링.TabIndex = 68;
            this.모니터링.Text = "모니터링 및 수정";
            this.모니터링.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Ingot_Title
            // 
            this.Ingot_Title.BackColor = System.Drawing.Color.White;
            this.Ingot_Title.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Ingot_Title.Font = new System.Drawing.Font("나눔스퀘어", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Ingot_Title.ForeColor = System.Drawing.Color.Black;
            this.Ingot_Title.Location = new System.Drawing.Point(27, 101);
            this.Ingot_Title.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Ingot_Title.Name = "Ingot_Title";
            this.Ingot_Title.ReadOnly = true;
            this.Ingot_Title.Size = new System.Drawing.Size(120, 33);
            this.Ingot_Title.TabIndex = 65;
            this.Ingot_Title.Text = "진행현황";
            this.Ingot_Title.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Ingot_Grid
            // 
            this.Ingot_Grid.AllowUserToResizeRows = false;
            this.Ingot_Grid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.Ingot_Grid.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Ingot_Grid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Ingot_Grid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.Ingot_Grid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("나눔스퀘어", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Ingot_Grid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.Ingot_Grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("나눔스퀘어", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Ingot_Grid.DefaultCellStyle = dataGridViewCellStyle2;
            this.Ingot_Grid.EnableHeadersVisualStyles = false;
            this.Ingot_Grid.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.Ingot_Grid.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Ingot_Grid.Location = new System.Drawing.Point(27, 146);
            this.Ingot_Grid.Name = "Ingot_Grid";
            this.Ingot_Grid.ReadOnly = true;
            this.Ingot_Grid.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Ingot_Grid.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.Ingot_Grid.RowHeadersWidth = 51;
            this.Ingot_Grid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.Ingot_Grid.RowTemplate.Height = 23;
            this.Ingot_Grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Ingot_Grid.Size = new System.Drawing.Size(897, 163);
            this.Ingot_Grid.Style = MetroFramework.MetroColorStyle.Silver;
            this.Ingot_Grid.TabIndex = 92;
            this.Ingot_Grid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Ingot_Grid_CellClick);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::WOMS.Properties.Resources.ingot_img1;
            this.pictureBox3.Location = new System.Drawing.Point(3, 3);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(360, 67);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 137;
            this.pictureBox3.TabStop = false;
            // 
            // 시작시간
            // 
            this.시작시간.BackColor = System.Drawing.Color.White;
            this.시작시간.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.시작시간.Font = new System.Drawing.Font("나눔스퀘어", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.시작시간.ForeColor = System.Drawing.Color.Black;
            this.시작시간.Location = new System.Drawing.Point(428, 535);
            this.시작시간.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.시작시간.Name = "시작시간";
            this.시작시간.ReadOnly = true;
            this.시작시간.Size = new System.Drawing.Size(100, 28);
            this.시작시간.TabIndex = 85;
            this.시작시간.Text = "시작시간";
            this.시작시간.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::WOMS.Properties.Resources.iconfinder_f_check_256_282474;
            this.pictureBox4.Location = new System.Drawing.Point(655, 13);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(51, 53);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 138;
            this.pictureBox4.TabStop = false;
            // 
            // ingotMoniter
            // 
            this.ingotMoniter.Location = new System.Drawing.Point(27, 409);
            this.ingotMoniter.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ingotMoniter.Name = "ingotMoniter";
            this.ingotMoniter.Size = new System.Drawing.Size(270, 109);
            this.ingotMoniter.Style = MetroFramework.MetroColorStyle.Silver;
            this.ingotMoniter.TabIndex = 139;
            this.ingotMoniter.Theme = MetroFramework.MetroThemeStyle.Light;
            // 
            // 진척도
            // 
            this.진척도.AutoSize = true;
            this.진척도.Font = new System.Drawing.Font("나눔스퀘어", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.진척도.Location = new System.Drawing.Point(24, 534);
            this.진척도.Name = "진척도";
            this.진척도.Size = new System.Drawing.Size(97, 26);
            this.진척도.TabIndex = 140;
            this.진척도.Text = "진척도 : ";
            // 
            // ingotNum
            // 
            this.ingotNum.AutoSize = true;
            this.ingotNum.Font = new System.Drawing.Font("나눔스퀘어", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ingotNum.Location = new System.Drawing.Point(138, 534);
            this.ingotNum.Name = "ingotNum";
            this.ingotNum.Size = new System.Drawing.Size(26, 26);
            this.ingotNum.TabIndex = 141;
            this.ingotNum.Text = "0";
            // 
            // 퍼센트
            // 
            this.퍼센트.AutoSize = true;
            this.퍼센트.Font = new System.Drawing.Font("나눔스퀘어", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.퍼센트.Location = new System.Drawing.Point(185, 534);
            this.퍼센트.Name = "퍼센트";
            this.퍼센트.Size = new System.Drawing.Size(33, 26);
            this.퍼센트.TabIndex = 142;
            this.퍼센트.Text = "%";
            // 
            // IngotCreate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.퍼센트);
            this.Controls.Add(this.ingotNum);
            this.Controls.Add(this.진척도);
            this.Controls.Add(this.ingotMoniter);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.Ingot_Grid);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.RestTime);
            this.Controls.Add(this.소요시간);
            this.Controls.Add(this.StartTime);
            this.Controls.Add(this.시작시간);
            this.Controls.Add(this.슬래쉬);
            this.Controls.Add(this.Fin_Len);
            this.Controls.Add(this.Cur_Len);
            this.Controls.Add(this.진행현황);
            this.Controls.Add(this.Pro_Vel);
            this.Controls.Add(this.Cur_Vel);
            this.Controls.Add(this.속도);
            this.Controls.Add(this.Pro_Temp);
            this.Controls.Add(this.Cur_Temp);
            this.Controls.Add(this.온도);
            this.Controls.Add(this.User_Name);
            this.Controls.Add(this.이용자);
            this.Controls.Add(this.Ingot_Id);
            this.Controls.Add(this.Ingot);
            this.Controls.Add(this.Add);
            this.Controls.Add(this.모니터링);
            this.Controls.Add(this.Ingot_Title);
            this.Name = "IngotCreate";
            this.Size = new System.Drawing.Size(940, 670);
            this.Load += new System.EventHandler(this.IngotCreate_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.Ingot_Grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox RestTime;
        private System.Windows.Forms.TextBox 소요시간;
        private System.Windows.Forms.TextBox StartTime;
        private System.Windows.Forms.Label 슬래쉬;
        private System.Windows.Forms.TextBox Fin_Len;
        private System.Windows.Forms.TextBox Cur_Len;
        private System.Windows.Forms.TextBox 진행현황;
        private System.Windows.Forms.TextBox Pro_Vel;
        private System.Windows.Forms.TextBox Cur_Vel;
        private System.Windows.Forms.TextBox 속도;
        private System.Windows.Forms.TextBox Pro_Temp;
        private System.Windows.Forms.TextBox Cur_Temp;
        private System.Windows.Forms.TextBox 온도;
        private System.Windows.Forms.TextBox User_Name;
        private System.Windows.Forms.TextBox 이용자;
        private System.Windows.Forms.TextBox Ingot_Id;
        private System.Windows.Forms.TextBox Ingot;
        private System.Windows.Forms.Button Add;
        private System.Windows.Forms.TextBox 모니터링;
        private System.Windows.Forms.TextBox Ingot_Title;
        private MetroFramework.Controls.MetroGrid Ingot_Grid;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.TextBox 시작시간;
        private System.Windows.Forms.PictureBox pictureBox4;
        private MetroFramework.Controls.MetroProgressBar ingotMoniter;
        private System.Windows.Forms.Label 진척도;
        private System.Windows.Forms.Label ingotNum;
        private System.Windows.Forms.Label 퍼센트;
    }
}
