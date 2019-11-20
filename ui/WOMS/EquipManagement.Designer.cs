namespace WOMS
{
    partial class EquipManagement
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.장비이벤트 = new System.Windows.Forms.TextBox();
            this.Add = new System.Windows.Forms.Button();
            this.equip_Comment = new System.Windows.Forms.TextBox();
            this.설명 = new System.Windows.Forms.TextBox();
            this.Equip_Name = new System.Windows.Forms.TextBox();
            this.장비이름 = new System.Windows.Forms.TextBox();
            this.Equip_Type = new System.Windows.Forms.ComboBox();
            this.장비종류 = new System.Windows.Forms.TextBox();
            this.Eqiup_Title = new System.Windows.Forms.TextBox();
            this.공정 = new System.Windows.Forms.TextBox();
            this.Oper_Grid = new MetroFramework.Controls.MetroGrid();
            this.Equip_Grid = new MetroFramework.Controls.MetroGrid();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.Eqiup_Event = new MetroFramework.Controls.MetroGrid();
            ((System.ComponentModel.ISupportInitialize)(this.Oper_Grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Equip_Grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Eqiup_Event)).BeginInit();
            this.SuspendLayout();
            // 
            // 장비이벤트
            // 
            this.장비이벤트.BackColor = System.Drawing.Color.White;
            this.장비이벤트.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.장비이벤트.Font = new System.Drawing.Font("나눔스퀘어", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.장비이벤트.ForeColor = System.Drawing.Color.Black;
            this.장비이벤트.Location = new System.Drawing.Point(24, 520);
            this.장비이벤트.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.장비이벤트.Name = "장비이벤트";
            this.장비이벤트.ReadOnly = true;
            this.장비이벤트.Size = new System.Drawing.Size(178, 42);
            this.장비이벤트.TabIndex = 48;
            this.장비이벤트.Text = "장비 이벤트";
            this.장비이벤트.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Add
            // 
            this.Add.BackColor = System.Drawing.Color.White;
            this.Add.FlatAppearance.BorderSize = 0;
            this.Add.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Add.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Add.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Add.Font = new System.Drawing.Font("나눔스퀘어 Bold", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Add.ForeColor = System.Drawing.Color.Black;
            this.Add.Location = new System.Drawing.Point(898, 109);
            this.Add.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Add.Name = "Add";
            this.Add.Size = new System.Drawing.Size(149, 66);
            this.Add.TabIndex = 3;
            this.Add.Text = "추가하기";
            this.Add.UseVisualStyleBackColor = false;
            this.Add.Click += new System.EventHandler(this.Add_Click);
            // 
            // equip_Comment
            // 
            this.equip_Comment.Font = new System.Drawing.Font("나눔스퀘어", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.equip_Comment.ForeColor = System.Drawing.Color.Black;
            this.equip_Comment.Location = new System.Drawing.Point(769, 14);
            this.equip_Comment.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.equip_Comment.Multiline = true;
            this.equip_Comment.Name = "equip_Comment";
            this.equip_Comment.Size = new System.Drawing.Size(267, 88);
            this.equip_Comment.TabIndex = 2;
            this.equip_Comment.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // 설명
            // 
            this.설명.BackColor = System.Drawing.Color.White;
            this.설명.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.설명.Font = new System.Drawing.Font("나눔스퀘어", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.설명.ForeColor = System.Drawing.Color.Black;
            this.설명.Location = new System.Drawing.Point(714, 19);
            this.설명.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.설명.Name = "설명";
            this.설명.ReadOnly = true;
            this.설명.Size = new System.Drawing.Size(58, 27);
            this.설명.TabIndex = 45;
            this.설명.Text = "설명";
            this.설명.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Equip_Name
            // 
            this.Equip_Name.Font = new System.Drawing.Font("나눔스퀘어", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Equip_Name.ForeColor = System.Drawing.Color.Black;
            this.Equip_Name.Location = new System.Drawing.Point(496, 68);
            this.Equip_Name.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Equip_Name.Name = "Equip_Name";
            this.Equip_Name.Size = new System.Drawing.Size(207, 34);
            this.Equip_Name.TabIndex = 1;
            this.Equip_Name.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // 장비이름
            // 
            this.장비이름.BackColor = System.Drawing.Color.White;
            this.장비이름.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.장비이름.Font = new System.Drawing.Font("나눔스퀘어", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.장비이름.ForeColor = System.Drawing.Color.Black;
            this.장비이름.Location = new System.Drawing.Point(377, 71);
            this.장비이름.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.장비이름.Name = "장비이름";
            this.장비이름.ReadOnly = true;
            this.장비이름.Size = new System.Drawing.Size(97, 27);
            this.장비이름.TabIndex = 44;
            this.장비이름.Text = "장비 이름";
            this.장비이름.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Equip_Type
            // 
            this.Equip_Type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Equip_Type.Font = new System.Drawing.Font("나눔스퀘어", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Equip_Type.FormattingEnabled = true;
            this.Equip_Type.Location = new System.Drawing.Point(496, 14);
            this.Equip_Type.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Equip_Type.Name = "Equip_Type";
            this.Equip_Type.Size = new System.Drawing.Size(169, 34);
            this.Equip_Type.TabIndex = 0;
            this.Equip_Type.Click += new System.EventHandler(this.Equip_Type_Click);
            // 
            // 장비종류
            // 
            this.장비종류.BackColor = System.Drawing.Color.White;
            this.장비종류.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.장비종류.Font = new System.Drawing.Font("나눔스퀘어", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.장비종류.ForeColor = System.Drawing.Color.Black;
            this.장비종류.Location = new System.Drawing.Point(377, 18);
            this.장비종류.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.장비종류.Name = "장비종류";
            this.장비종류.ReadOnly = true;
            this.장비종류.Size = new System.Drawing.Size(97, 27);
            this.장비종류.TabIndex = 43;
            this.장비종류.Text = "장비 종류";
            this.장비종류.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Eqiup_Title
            // 
            this.Eqiup_Title.BackColor = System.Drawing.Color.White;
            this.Eqiup_Title.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Eqiup_Title.Font = new System.Drawing.Font("나눔스퀘어", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Eqiup_Title.ForeColor = System.Drawing.Color.Black;
            this.Eqiup_Title.Location = new System.Drawing.Point(301, 152);
            this.Eqiup_Title.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Eqiup_Title.Name = "Eqiup_Title";
            this.Eqiup_Title.ReadOnly = true;
            this.Eqiup_Title.Size = new System.Drawing.Size(149, 42);
            this.Eqiup_Title.TabIndex = 40;
            this.Eqiup_Title.Text = "장비현황";
            this.Eqiup_Title.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // 공정
            // 
            this.공정.BackColor = System.Drawing.Color.White;
            this.공정.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.공정.Font = new System.Drawing.Font("나눔스퀘어", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.공정.ForeColor = System.Drawing.Color.Black;
            this.공정.Location = new System.Drawing.Point(24, 152);
            this.공정.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.공정.Name = "공정";
            this.공정.ReadOnly = true;
            this.공정.Size = new System.Drawing.Size(81, 42);
            this.공정.TabIndex = 36;
            this.공정.Text = "공정";
            this.공정.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Oper_Grid
            // 
            this.Oper_Grid.AllowUserToResizeRows = false;
            this.Oper_Grid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.Oper_Grid.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Oper_Grid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Oper_Grid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.Oper_Grid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("나눔스퀘어", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Oper_Grid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.Oper_Grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("나눔스퀘어", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Oper_Grid.DefaultCellStyle = dataGridViewCellStyle2;
            this.Oper_Grid.EnableHeadersVisualStyles = false;
            this.Oper_Grid.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.Oper_Grid.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Oper_Grid.Location = new System.Drawing.Point(24, 200);
            this.Oper_Grid.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Oper_Grid.Name = "Oper_Grid";
            this.Oper_Grid.ReadOnly = true;
            this.Oper_Grid.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Oper_Grid.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.Oper_Grid.RowHeadersWidth = 51;
            this.Oper_Grid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.Oper_Grid.RowTemplate.Height = 23;
            this.Oper_Grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Oper_Grid.Size = new System.Drawing.Size(235, 290);
            this.Oper_Grid.Style = MetroFramework.MetroColorStyle.Silver;
            this.Oper_Grid.TabIndex = 49;
            this.Oper_Grid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Oper_Grid_CellClick);
            // 
            // Equip_Grid
            // 
            this.Equip_Grid.AllowUserToResizeRows = false;
            this.Equip_Grid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.Equip_Grid.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Equip_Grid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Equip_Grid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.Equip_Grid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("나눔스퀘어", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Equip_Grid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.Equip_Grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("나눔스퀘어", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Equip_Grid.DefaultCellStyle = dataGridViewCellStyle5;
            this.Equip_Grid.EnableHeadersVisualStyles = false;
            this.Equip_Grid.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.Equip_Grid.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Equip_Grid.Location = new System.Drawing.Point(301, 200);
            this.Equip_Grid.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Equip_Grid.Name = "Equip_Grid";
            this.Equip_Grid.ReadOnly = true;
            this.Equip_Grid.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Equip_Grid.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.Equip_Grid.RowHeadersWidth = 51;
            this.Equip_Grid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.Equip_Grid.RowTemplate.Height = 23;
            this.Equip_Grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Equip_Grid.Size = new System.Drawing.Size(746, 290);
            this.Equip_Grid.Style = MetroFramework.MetroColorStyle.Silver;
            this.Equip_Grid.TabIndex = 50;
            this.Equip_Grid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Equip_Grid_CellClick);
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::WOMS.Properties.Resources.iconfinder_f_check_256_282474;
            this.pictureBox4.Location = new System.Drawing.Point(833, 109);
            this.pictureBox4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(58, 66);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 130;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::WOMS.Properties.Resources.equip_img1;
            this.pictureBox3.Location = new System.Drawing.Point(3, 4);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(218, 75);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 128;
            this.pictureBox3.TabStop = false;
            // 
            // Eqiup_Event
            // 
            this.Eqiup_Event.AllowUserToResizeRows = false;
            this.Eqiup_Event.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.Eqiup_Event.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Eqiup_Event.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Eqiup_Event.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.Eqiup_Event.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            dataGridViewCellStyle7.Font = new System.Drawing.Font("나눔스퀘어", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Eqiup_Event.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.Eqiup_Event.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle8.Font = new System.Drawing.Font("나눔스퀘어", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Eqiup_Event.DefaultCellStyle = dataGridViewCellStyle8;
            this.Eqiup_Event.EnableHeadersVisualStyles = false;
            this.Eqiup_Event.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.Eqiup_Event.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Eqiup_Event.Location = new System.Drawing.Point(24, 568);
            this.Eqiup_Event.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Eqiup_Event.Name = "Eqiup_Event";
            this.Eqiup_Event.ReadOnly = true;
            this.Eqiup_Event.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Eqiup_Event.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.Eqiup_Event.RowHeadersWidth = 51;
            this.Eqiup_Event.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.Eqiup_Event.RowTemplate.Height = 23;
            this.Eqiup_Event.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Eqiup_Event.Size = new System.Drawing.Size(1023, 251);
            this.Eqiup_Event.Style = MetroFramework.MetroColorStyle.Silver;
            this.Eqiup_Event.TabIndex = 132;
            this.Eqiup_Event.Theme = MetroFramework.MetroThemeStyle.Light;
            // 
            // EquipManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.Eqiup_Event);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.Equip_Grid);
            this.Controls.Add(this.Oper_Grid);
            this.Controls.Add(this.장비이벤트);
            this.Controls.Add(this.Add);
            this.Controls.Add(this.equip_Comment);
            this.Controls.Add(this.설명);
            this.Controls.Add(this.Equip_Name);
            this.Controls.Add(this.장비이름);
            this.Controls.Add(this.Equip_Type);
            this.Controls.Add(this.장비종류);
            this.Controls.Add(this.Eqiup_Title);
            this.Controls.Add(this.공정);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "EquipManagement";
            this.Size = new System.Drawing.Size(1074, 838);
            this.Load += new System.EventHandler(this.EquipManagement_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.Oper_Grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Equip_Grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Eqiup_Event)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox 장비이벤트;
        private System.Windows.Forms.Button Add;
        private System.Windows.Forms.TextBox equip_Comment;
        private System.Windows.Forms.TextBox 설명;
        private System.Windows.Forms.TextBox Equip_Name;
        private System.Windows.Forms.TextBox 장비이름;
        private System.Windows.Forms.ComboBox Equip_Type;
        private System.Windows.Forms.TextBox 장비종류;
        private System.Windows.Forms.TextBox Eqiup_Title;
        private System.Windows.Forms.TextBox 공정;
        private MetroFramework.Controls.MetroGrid Oper_Grid;
        private MetroFramework.Controls.MetroGrid Equip_Grid;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;
        private MetroFramework.Controls.MetroGrid Eqiup_Event;
    }
}
