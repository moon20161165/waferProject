namespace WOMS
{
    partial class WaferManagement
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
            this.공정 = new System.Windows.Forms.TextBox();
            this.select_Oper = new System.Windows.Forms.ComboBox();
            this.Moniter = new System.Windows.Forms.Button();
            this.make = new System.Windows.Forms.Button();
            this.불량률 = new System.Windows.Forms.TextBox();
            this.Comment = new System.Windows.Forms.TextBox();
            this.설명 = new System.Windows.Forms.TextBox();
            this.Qty = new System.Windows.Forms.TextBox();
            this.수량 = new System.Windows.Forms.TextBox();
            this.제품정보 = new System.Windows.Forms.TextBox();
            this.selectMS = new System.Windows.Forms.ComboBox();
            this.Wafer_Title = new System.Windows.Forms.TextBox();
            this.Wafer_Grid = new MetroFramework.Controls.MetroGrid();
            this.errorRate = new MetroFramework.Controls.MetroGrid();
            this.routeView = new MetroFramework.Controls.MetroListView();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.Wafer_Grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.SuspendLayout();
            // 
            // 공정
            // 
            this.공정.BackColor = System.Drawing.Color.White;
            this.공정.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.공정.Font = new System.Drawing.Font("나눔스퀘어", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.공정.ForeColor = System.Drawing.Color.Black;
            this.공정.Location = new System.Drawing.Point(299, 44);
            this.공정.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.공정.Name = "공정";
            this.공정.ReadOnly = true;
            this.공정.Size = new System.Drawing.Size(97, 35);
            this.공정.TabIndex = 69;
            this.공정.Text = "공정";
            this.공정.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // select_Oper
            // 
            this.select_Oper.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.select_Oper.Font = new System.Drawing.Font("나눔스퀘어", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.select_Oper.FormattingEnabled = true;
            this.select_Oper.Location = new System.Drawing.Point(403, 42);
            this.select_Oper.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.select_Oper.Name = "select_Oper";
            this.select_Oper.Size = new System.Drawing.Size(230, 34);
            this.select_Oper.TabIndex = 68;
            this.select_Oper.SelectedIndexChanged += new System.EventHandler(this.Select_Oper_SelectedIndexChanged);
            this.select_Oper.Click += new System.EventHandler(this.Select_Oper_Click);
            // 
            // Moniter
            // 
            this.Moniter.BackColor = System.Drawing.Color.White;
            this.Moniter.FlatAppearance.BorderSize = 0;
            this.Moniter.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Moniter.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Moniter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Moniter.Font = new System.Drawing.Font("나눔스퀘어", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Moniter.ForeColor = System.Drawing.Color.Black;
            this.Moniter.Location = new System.Drawing.Point(751, 21);
            this.Moniter.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Moniter.Name = "Moniter";
            this.Moniter.Size = new System.Drawing.Size(312, 66);
            this.Moniter.TabIndex = 67;
            this.Moniter.Text = "모니터링 화면 보기";
            this.Moniter.UseVisualStyleBackColor = false;
            this.Moniter.Click += new System.EventHandler(this.Moniter_Click);
            // 
            // make
            // 
            this.make.BackColor = System.Drawing.Color.White;
            this.make.FlatAppearance.BorderSize = 0;
            this.make.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.make.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.make.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.make.Font = new System.Drawing.Font("나눔스퀘어", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.make.ForeColor = System.Drawing.Color.Black;
            this.make.Location = new System.Drawing.Point(777, 744);
            this.make.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.make.Name = "make";
            this.make.Size = new System.Drawing.Size(271, 66);
            this.make.TabIndex = 3;
            this.make.Text = "웨이퍼 제작하기";
            this.make.UseVisualStyleBackColor = false;
            this.make.Click += new System.EventHandler(this.Make_Click);
            // 
            // 불량률
            // 
            this.불량률.BackColor = System.Drawing.Color.White;
            this.불량률.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.불량률.Font = new System.Drawing.Font("나눔스퀘어", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.불량률.ForeColor = System.Drawing.Color.Black;
            this.불량률.Location = new System.Drawing.Point(19, 466);
            this.불량률.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.불량률.Name = "불량률";
            this.불량률.ReadOnly = true;
            this.불량률.Size = new System.Drawing.Size(106, 39);
            this.불량률.TabIndex = 66;
            this.불량률.Text = "불량률";
            this.불량률.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Comment
            // 
            this.Comment.Font = new System.Drawing.Font("나눔스퀘어", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Comment.ForeColor = System.Drawing.Color.Black;
            this.Comment.Location = new System.Drawing.Point(767, 562);
            this.Comment.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Comment.Multiline = true;
            this.Comment.Name = "Comment";
            this.Comment.Size = new System.Drawing.Size(281, 164);
            this.Comment.TabIndex = 2;
            this.Comment.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // 설명
            // 
            this.설명.BackColor = System.Drawing.Color.White;
            this.설명.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.설명.Font = new System.Drawing.Font("나눔스퀘어", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.설명.ForeColor = System.Drawing.Color.Black;
            this.설명.Location = new System.Drawing.Point(631, 562);
            this.설명.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.설명.Name = "설명";
            this.설명.ReadOnly = true;
            this.설명.Size = new System.Drawing.Size(119, 35);
            this.설명.TabIndex = 63;
            this.설명.Text = "설명";
            this.설명.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Qty
            // 
            this.Qty.Font = new System.Drawing.Font("나눔스퀘어", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Qty.ForeColor = System.Drawing.Color.Black;
            this.Qty.Location = new System.Drawing.Point(767, 508);
            this.Qty.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Qty.Name = "Qty";
            this.Qty.Size = new System.Drawing.Size(281, 34);
            this.Qty.TabIndex = 1;
            this.Qty.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // 수량
            // 
            this.수량.BackColor = System.Drawing.Color.White;
            this.수량.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.수량.Font = new System.Drawing.Font("나눔스퀘어", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.수량.ForeColor = System.Drawing.Color.Black;
            this.수량.Location = new System.Drawing.Point(631, 509);
            this.수량.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.수량.Name = "수량";
            this.수량.ReadOnly = true;
            this.수량.Size = new System.Drawing.Size(119, 35);
            this.수량.TabIndex = 62;
            this.수량.Text = "수량";
            this.수량.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // 제품정보
            // 
            this.제품정보.BackColor = System.Drawing.Color.White;
            this.제품정보.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.제품정보.Font = new System.Drawing.Font("나눔스퀘어", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.제품정보.ForeColor = System.Drawing.Color.Black;
            this.제품정보.Location = new System.Drawing.Point(347, 466);
            this.제품정보.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.제품정보.Name = "제품정보";
            this.제품정보.ReadOnly = true;
            this.제품정보.Size = new System.Drawing.Size(137, 42);
            this.제품정보.TabIndex = 61;
            this.제품정보.Text = "제품 정보";
            this.제품정보.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // selectMS
            // 
            this.selectMS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.selectMS.Font = new System.Drawing.Font("굴림", 12F);
            this.selectMS.FormattingEnabled = true;
            this.selectMS.Location = new System.Drawing.Point(491, 474);
            this.selectMS.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.selectMS.Name = "selectMS";
            this.selectMS.Size = new System.Drawing.Size(132, 28);
            this.selectMS.TabIndex = 0;
            this.selectMS.SelectedIndexChanged += new System.EventHandler(this.SelectMS_SelectedIndexChanged);
            this.selectMS.Click += new System.EventHandler(this.SelectMS_Click);
            // 
            // Wafer_Title
            // 
            this.Wafer_Title.BackColor = System.Drawing.Color.White;
            this.Wafer_Title.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Wafer_Title.Font = new System.Drawing.Font("나눔스퀘어", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Wafer_Title.ForeColor = System.Drawing.Color.Black;
            this.Wafer_Title.Location = new System.Drawing.Point(19, 110);
            this.Wafer_Title.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Wafer_Title.Name = "Wafer_Title";
            this.Wafer_Title.ReadOnly = true;
            this.Wafer_Title.Size = new System.Drawing.Size(160, 39);
            this.Wafer_Title.TabIndex = 58;
            this.Wafer_Title.Text = "웨이퍼 현황";
            this.Wafer_Title.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Wafer_Grid
            // 
            this.Wafer_Grid.AllowUserToResizeRows = false;
            this.Wafer_Grid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.Wafer_Grid.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Wafer_Grid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Wafer_Grid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.Wafer_Grid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("나눔스퀘어", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Wafer_Grid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.Wafer_Grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("나눔스퀘어", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Wafer_Grid.DefaultCellStyle = dataGridViewCellStyle2;
            this.Wafer_Grid.EnableHeadersVisualStyles = false;
            this.Wafer_Grid.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.Wafer_Grid.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Wafer_Grid.Location = new System.Drawing.Point(19, 155);
            this.Wafer_Grid.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Wafer_Grid.Name = "Wafer_Grid";
            this.Wafer_Grid.ReadOnly = true;
            this.Wafer_Grid.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Wafer_Grid.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.Wafer_Grid.RowHeadersWidth = 51;
            this.Wafer_Grid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.Wafer_Grid.RowTemplate.Height = 23;
            this.Wafer_Grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Wafer_Grid.Size = new System.Drawing.Size(1029, 292);
            this.Wafer_Grid.Style = MetroFramework.MetroColorStyle.Silver;
            this.Wafer_Grid.TabIndex = 141;
            this.Wafer_Grid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Wafer_Grid_CellClick);
            // 
            // errorRate
            // 
            this.errorRate.AllowUserToResizeRows = false;
            this.errorRate.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.errorRate.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.errorRate.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.errorRate.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.errorRate.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("나눔스퀘어", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.errorRate.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.errorRate.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("나눔스퀘어", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.errorRate.DefaultCellStyle = dataGridViewCellStyle5;
            this.errorRate.EnableHeadersVisualStyles = false;
            this.errorRate.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.errorRate.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.errorRate.Location = new System.Drawing.Point(19, 508);
            this.errorRate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.errorRate.Name = "errorRate";
            this.errorRate.ReadOnly = true;
            this.errorRate.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.errorRate.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.errorRate.RowHeadersWidth = 51;
            this.errorRate.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.errorRate.RowTemplate.Height = 23;
            this.errorRate.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.errorRate.Size = new System.Drawing.Size(321, 302);
            this.errorRate.Style = MetroFramework.MetroColorStyle.Silver;
            this.errorRate.TabIndex = 142;
            // 
            // routeView
            // 
            this.routeView.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.routeView.FullRowSelect = true;
            this.routeView.Location = new System.Drawing.Point(347, 508);
            this.routeView.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.routeView.Name = "routeView";
            this.routeView.OwnerDraw = true;
            this.routeView.Size = new System.Drawing.Size(276, 302);
            this.routeView.TabIndex = 143;
            this.routeView.UseCompatibleStateImageBehavior = false;
            this.routeView.UseSelectable = true;
            this.routeView.DrawColumnHeader += new System.Windows.Forms.DrawListViewColumnHeaderEventHandler(this.RouteView_DrawColumnHeader);
            this.routeView.DrawSubItem += new System.Windows.Forms.DrawListViewSubItemEventHandler(this.RouteView_DrawSubItem);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::WOMS.Properties.Resources.wafer_img1;
            this.pictureBox3.Location = new System.Drawing.Point(3, 4);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(243, 75);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 144;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::WOMS.Properties.Resources.iconfinder_Arrow_doodle_05_3847906;
            this.pictureBox1.Location = new System.Drawing.Point(686, 21);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(58, 66);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 140;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::WOMS.Properties.Resources.iconfinder_f_check_256_282474;
            this.pictureBox4.Location = new System.Drawing.Point(712, 744);
            this.pictureBox4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(58, 66);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 139;
            this.pictureBox4.TabStop = false;
            // 
            // WaferManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.routeView);
            this.Controls.Add(this.errorRate);
            this.Controls.Add(this.Wafer_Grid);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.공정);
            this.Controls.Add(this.select_Oper);
            this.Controls.Add(this.Moniter);
            this.Controls.Add(this.make);
            this.Controls.Add(this.불량률);
            this.Controls.Add(this.Comment);
            this.Controls.Add(this.설명);
            this.Controls.Add(this.Qty);
            this.Controls.Add(this.수량);
            this.Controls.Add(this.제품정보);
            this.Controls.Add(this.selectMS);
            this.Controls.Add(this.Wafer_Title);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "WaferManagement";
            this.Size = new System.Drawing.Size(1074, 838);
            this.Load += new System.EventHandler(this.WaferManagement_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.Wafer_Grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox 공정;
        private System.Windows.Forms.ComboBox select_Oper;
        private System.Windows.Forms.Button Moniter;
        private System.Windows.Forms.Button make;
        private System.Windows.Forms.TextBox 불량률;
        private System.Windows.Forms.TextBox Comment;
        private System.Windows.Forms.TextBox 설명;
        private System.Windows.Forms.TextBox Qty;
        private System.Windows.Forms.TextBox 수량;
        private System.Windows.Forms.TextBox 제품정보;
        private System.Windows.Forms.ComboBox selectMS;
        private System.Windows.Forms.TextBox Wafer_Title;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox1;
        private MetroFramework.Controls.MetroGrid Wafer_Grid;
        private MetroFramework.Controls.MetroGrid errorRate;
        private MetroFramework.Controls.MetroListView routeView;
        private System.Windows.Forms.PictureBox pictureBox3;
    }
}
