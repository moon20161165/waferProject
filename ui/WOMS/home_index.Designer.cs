namespace WOMS
{
    partial class home_index
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(home_index));
            this.pwUpdate = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.media = new System.Windows.Forms.Panel();
            this.출처 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // pwUpdate
            // 
            this.pwUpdate.BackColor = System.Drawing.Color.DimGray;
            this.pwUpdate.Font = new System.Drawing.Font("굴림", 8F);
            this.pwUpdate.ForeColor = System.Drawing.Color.White;
            this.pwUpdate.Location = new System.Drawing.Point(970, 4);
            this.pwUpdate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pwUpdate.Name = "pwUpdate";
            this.pwUpdate.Size = new System.Drawing.Size(101, 36);
            this.pwUpdate.TabIndex = 36;
            this.pwUpdate.Text = "비밀번호변경";
            this.pwUpdate.UseVisualStyleBackColor = false;
            this.pwUpdate.Click += new System.EventHandler(this.pwUpdate_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::WOMS.Properties.Resources.home1;
            this.pictureBox1.Location = new System.Drawing.Point(3, 4);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(134, 76);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 37;
            this.pictureBox1.TabStop = false;
            // 
            // media
            // 
            this.media.Location = new System.Drawing.Point(50, 253);
            this.media.Name = "media";
            this.media.Size = new System.Drawing.Size(941, 530);
            this.media.TabIndex = 38;
            // 
            // 출처
            // 
            this.출처.AutoSize = true;
            this.출처.Font = new System.Drawing.Font("나눔스퀘어", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.출처.Location = new System.Drawing.Point(47, 786);
            this.출처.Name = "출처";
            this.출처.Size = new System.Drawing.Size(400, 17);
            this.출처.TabIndex = 41;
            this.출처.Text = "출처 : https://www.youtube.com/watch?v=LWfCqpJzJYM";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(385, 109);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(279, 138);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 42;
            this.pictureBox2.TabStop = false;
            // 
            // home_index
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.출처);
            this.Controls.Add(this.media);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pwUpdate);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "home_index";
            this.Size = new System.Drawing.Size(1074, 838);
            this.Load += new System.EventHandler(this.home_index_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button pwUpdate;
        private System.Windows.Forms.Panel media;
        private System.Windows.Forms.Label 출처;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}
