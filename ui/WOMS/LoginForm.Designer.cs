namespace WOMS
{
    partial class LoginForm
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

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.pnlTop = new System.Windows.Forms.TableLayoutPanel();
            this.close = new System.Windows.Forms.Button();
            this.logIn = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.PW = new MetroFramework.Controls.MetroTextBox();
            this.ID = new MetroFramework.Controls.MetroTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pnlTop.ColumnCount = 1;
            this.pnlTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.pnlTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.RowCount = 1;
            this.pnlTop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.pnlTop.Size = new System.Drawing.Size(609, 31);
            this.pnlTop.TabIndex = 13;
            this.pnlTop.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlTop_MouseDown);
            this.pnlTop.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnlTop_MouseMove);
            this.pnlTop.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pnlTop_MouseUp);
            // 
            // close
            // 
            this.close.BackColor = System.Drawing.Color.White;
            this.close.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("close.BackgroundImage")));
            this.close.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.close.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.close.FlatAppearance.BorderSize = 0;
            this.close.FlatAppearance.MouseDownBackColor = System.Drawing.Color.WhiteSmoke;
            this.close.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.close.Location = new System.Drawing.Point(475, 131);
            this.close.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.close.Name = "close";
            this.close.Size = new System.Drawing.Size(94, 124);
            this.close.TabIndex = 3;
            this.close.UseVisualStyleBackColor = false;
            this.close.Click += new System.EventHandler(this.close_Click);
            // 
            // logIn
            // 
            this.logIn.BackColor = System.Drawing.Color.White;
            this.logIn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("logIn.BackgroundImage")));
            this.logIn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.logIn.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.logIn.FlatAppearance.BorderSize = 0;
            this.logIn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.WhiteSmoke;
            this.logIn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.logIn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.logIn.Location = new System.Drawing.Point(368, 131);
            this.logIn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.logIn.Name = "logIn";
            this.logIn.Size = new System.Drawing.Size(101, 124);
            this.logIn.TabIndex = 2;
            this.logIn.UseVisualStyleBackColor = false;
            this.logIn.Click += new System.EventHandler(this.logIn_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(0, 39);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(455, 78);
            this.pictureBox2.TabIndex = 17;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(14, 280);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(555, 551);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 16;
            this.pictureBox1.TabStop = false;
            // 
            // PW
            // 
            // 
            // 
            // 
            this.PW.CustomButton.Image = null;
            this.PW.CustomButton.Location = new System.Drawing.Point(198, 2);
            this.PW.CustomButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.PW.CustomButton.Name = "";
            this.PW.CustomButton.Size = new System.Drawing.Size(39, 39);
            this.PW.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.PW.CustomButton.TabIndex = 1;
            this.PW.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.PW.CustomButton.UseSelectable = true;
            this.PW.CustomButton.Visible = false;
            this.PW.DisplayIcon = true;
            this.PW.FontSize = MetroFramework.MetroTextBoxSize.Tall;
            this.PW.FontWeight = MetroFramework.MetroTextBoxWeight.Bold;
            this.PW.Icon = global::WOMS.Properties.Resources.iconfinder_Streamline_68_185088;
            this.PW.Lines = new string[] {
        "4321"};
            this.PW.Location = new System.Drawing.Point(98, 205);
            this.PW.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.PW.MaxLength = 32767;
            this.PW.Name = "PW";
            this.PW.PasswordChar = '*';
            this.PW.PromptText = "Enter your password";
            this.PW.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.PW.SelectedText = "";
            this.PW.SelectionLength = 0;
            this.PW.SelectionStart = 0;
            this.PW.ShortcutsEnabled = true;
            this.PW.Size = new System.Drawing.Size(240, 44);
            this.PW.TabIndex = 1;
            this.PW.Text = "4321";
            this.PW.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.PW.UseSelectable = true;
            this.PW.WaterMark = "Enter your password";
            this.PW.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.PW.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.PW.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PW_KeyDown);
            // 
            // ID
            // 
            // 
            // 
            // 
            this.ID.CustomButton.Image = null;
            this.ID.CustomButton.Location = new System.Drawing.Point(198, 2);
            this.ID.CustomButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ID.CustomButton.Name = "";
            this.ID.CustomButton.Size = new System.Drawing.Size(39, 39);
            this.ID.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.ID.CustomButton.TabIndex = 1;
            this.ID.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.ID.CustomButton.UseSelectable = true;
            this.ID.CustomButton.Visible = false;
            this.ID.DisplayIcon = true;
            this.ID.FontSize = MetroFramework.MetroTextBoxSize.Tall;
            this.ID.Icon = global::WOMS.Properties.Resources.iconfinder_88_111104;
            this.ID.Lines = new string[] {
        "son"};
            this.ID.Location = new System.Drawing.Point(98, 146);
            this.ID.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ID.MaxLength = 32767;
            this.ID.Name = "ID";
            this.ID.PasswordChar = '\0';
            this.ID.PromptText = "Enter your user name";
            this.ID.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.ID.SelectedText = "";
            this.ID.SelectionLength = 0;
            this.ID.SelectionStart = 0;
            this.ID.ShortcutsEnabled = true;
            this.ID.Size = new System.Drawing.Size(240, 44);
            this.ID.TabIndex = 0;
            this.ID.Text = "son";
            this.ID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ID.UseSelectable = true;
            this.ID.WaterMark = "Enter your user name";
            this.ID.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.ID.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 841);
            this.Controls.Add(this.close);
            this.Controls.Add(this.logIn);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.PW);
            this.Controls.Add(this.ID);
            this.Controls.Add(this.pnlTop);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(600, 180);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Movable = false;
            this.Name = "LoginForm";
            this.Padding = new System.Windows.Forms.Padding(23, 75, 23, 25);
            this.Resizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Style = MetroFramework.MetroColorStyle.Silver;
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel pnlTop;
        private MetroFramework.Controls.MetroTextBox ID;
        private MetroFramework.Controls.MetroTextBox PW;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button close;
        private System.Windows.Forms.Button logIn;
    }
}

