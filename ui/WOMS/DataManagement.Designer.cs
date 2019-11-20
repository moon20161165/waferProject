namespace WOMS
{
    partial class DataManagement
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DataManagement));
            this.select_Oper = new System.Windows.Forms.ComboBox();
            this.Data_Grid = new MetroFramework.Controls.MetroGrid();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.count = new MetroFramework.Controls.MetroTextBox();
            this.page = new System.Windows.Forms.Label();
            this.before = new MetroFramework.Controls.MetroButton();
            this.end = new MetroFramework.Controls.MetroButton();
            this.first = new MetroFramework.Controls.MetroButton();
            this.next = new MetroFramework.Controls.MetroButton();
            this.numLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Data_Grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // select_Oper
            // 
            this.select_Oper.BackColor = System.Drawing.Color.White;
            this.select_Oper.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.select_Oper.Font = new System.Drawing.Font("나눔스퀘어", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.select_Oper.FormattingEnabled = true;
            this.select_Oper.Location = new System.Drawing.Point(733, 80);
            this.select_Oper.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.select_Oper.Name = "select_Oper";
            this.select_Oper.Size = new System.Drawing.Size(285, 34);
            this.select_Oper.TabIndex = 0;
            this.select_Oper.SelectedIndexChanged += new System.EventHandler(this.Select_Oper_SelectedIndexChanged);
            this.select_Oper.Click += new System.EventHandler(this.Select_Oper_Click);
            // 
            // Data_Grid
            // 
            this.Data_Grid.AllowUserToResizeRows = false;
            this.Data_Grid.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Data_Grid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Data_Grid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.Data_Grid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            dataGridViewCellStyle13.Font = new System.Drawing.Font("나눔스퀘어", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Data_Grid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle13;
            this.Data_Grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle14.Font = new System.Drawing.Font("나눔스퀘어", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Data_Grid.DefaultCellStyle = dataGridViewCellStyle14;
            this.Data_Grid.EnableHeadersVisualStyles = false;
            this.Data_Grid.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.Data_Grid.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Data_Grid.Location = new System.Drawing.Point(23, 133);
            this.Data_Grid.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Data_Grid.Name = "Data_Grid";
            this.Data_Grid.ReadOnly = true;
            this.Data_Grid.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Data_Grid.RowHeadersDefaultCellStyle = dataGridViewCellStyle15;
            this.Data_Grid.RowHeadersWidth = 51;
            this.Data_Grid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.Data_Grid.RowTemplate.Height = 23;
            this.Data_Grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Data_Grid.Size = new System.Drawing.Size(1029, 625);
            this.Data_Grid.Style = MetroFramework.MetroColorStyle.Silver;
            this.Data_Grid.TabIndex = 56;
            this.Data_Grid.Theme = MetroFramework.MetroThemeStyle.Light;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::WOMS.Properties.Resources.rhdwjd;
            this.pictureBox2.Location = new System.Drawing.Point(621, 69);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(83, 56);
            this.pictureBox2.TabIndex = 58;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::WOMS.Properties.Resources.dataManagement_img2;
            this.pictureBox1.Location = new System.Drawing.Point(3, 4);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(291, 75);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 57;
            this.pictureBox1.TabStop = false;
            // 
            // count
            // 
            // 
            // 
            // 
            this.count.CustomButton.Image = null;
            this.count.CustomButton.Location = new System.Drawing.Point(16, 2);
            this.count.CustomButton.Name = "";
            this.count.CustomButton.Size = new System.Drawing.Size(25, 25);
            this.count.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.count.CustomButton.TabIndex = 1;
            this.count.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.count.CustomButton.UseSelectable = true;
            this.count.CustomButton.Visible = false;
            this.count.Lines = new string[] {
        "10"};
            this.count.Location = new System.Drawing.Point(389, 84);
            this.count.MaxLength = 32767;
            this.count.Name = "count";
            this.count.PasswordChar = '\0';
            this.count.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.count.SelectedText = "";
            this.count.SelectionLength = 0;
            this.count.SelectionStart = 0;
            this.count.ShortcutsEnabled = true;
            this.count.Size = new System.Drawing.Size(44, 30);
            this.count.TabIndex = 59;
            this.count.Text = "10";
            this.count.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.count.UseSelectable = true;
            this.count.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.count.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // page
            // 
            this.page.AutoSize = true;
            this.page.Font = new System.Drawing.Font("굴림", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.page.Location = new System.Drawing.Point(482, 762);
            this.page.Name = "page";
            this.page.Size = new System.Drawing.Size(0, 28);
            this.page.TabIndex = 61;
            this.page.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // before
            // 
            this.before.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("before.BackgroundImage")));
            this.before.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.before.Location = new System.Drawing.Point(439, 762);
            this.before.Name = "before";
            this.before.Size = new System.Drawing.Size(26, 32);
            this.before.TabIndex = 63;
            this.before.UseSelectable = true;
            this.before.Click += new System.EventHandler(this.Before_Click);
            // 
            // end
            // 
            this.end.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("end.BackgroundImage")));
            this.end.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.end.Location = new System.Drawing.Point(621, 762);
            this.end.Name = "end";
            this.end.Size = new System.Drawing.Size(37, 32);
            this.end.TabIndex = 64;
            this.end.UseSelectable = true;
            this.end.Click += new System.EventHandler(this.End_Click);
            // 
            // first
            // 
            this.first.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("first.BackgroundImage")));
            this.first.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.first.Location = new System.Drawing.Point(396, 762);
            this.first.Name = "first";
            this.first.Size = new System.Drawing.Size(37, 32);
            this.first.TabIndex = 65;
            this.first.UseSelectable = true;
            this.first.Click += new System.EventHandler(this.First_Click);
            // 
            // next
            // 
            this.next.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("next.BackgroundImage")));
            this.next.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.next.Location = new System.Drawing.Point(589, 762);
            this.next.Name = "next";
            this.next.Size = new System.Drawing.Size(26, 32);
            this.next.TabIndex = 66;
            this.next.UseSelectable = true;
            this.next.Click += new System.EventHandler(this.Next_Click);
            // 
            // numLabel
            // 
            this.numLabel.AutoSize = true;
            this.numLabel.Font = new System.Drawing.Font("나눔스퀘어", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.numLabel.Location = new System.Drawing.Point(435, 88);
            this.numLabel.Name = "numLabel";
            this.numLabel.Size = new System.Drawing.Size(78, 20);
            this.numLabel.TabIndex = 69;
            this.numLabel.Text = "개씩 보기";
            // 
            // DataManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.numLabel);
            this.Controls.Add(this.next);
            this.Controls.Add(this.first);
            this.Controls.Add(this.end);
            this.Controls.Add(this.before);
            this.Controls.Add(this.page);
            this.Controls.Add(this.count);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.Data_Grid);
            this.Controls.Add(this.select_Oper);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "DataManagement";
            this.Size = new System.Drawing.Size(1074, 838);
            this.Load += new System.EventHandler(this.DataManagement_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.Data_Grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox select_Oper;
        private MetroFramework.Controls.MetroGrid Data_Grid;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private MetroFramework.Controls.MetroTextBox count;
        private System.Windows.Forms.Label page;
        private MetroFramework.Controls.MetroButton before;
        private MetroFramework.Controls.MetroButton end;
        private MetroFramework.Controls.MetroButton first;
        private MetroFramework.Controls.MetroButton next;
        private System.Windows.Forms.Label numLabel;
    }
}
