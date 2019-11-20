using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.DirectX.AudioVideoPlayback;
using Microsoft.DirectX;

namespace WOMS
{
    public partial class home_index : UserControl
    {
        Video v;

        public home_index()
        {
            InitializeComponent();
        }
        // 패스워드 변경 UI로 이동
        private void pwUpdate_Click(object sender, EventArgs e)
        {
            PwChange pwChange = new PwChange();
            pwChange.Show();
        }

        private void home_index_Load(object sender, EventArgs e)
        {
            v = new Video(@".\image\video\wafer.wmv");
            Size media_size = media.Size;
            v.Owner = media;
            v.Size = new Size(media_size.Width, media_size.Height);
            v.Play();
            v.Ending += new EventHandler(back);
        }

        private void back(object sender, EventArgs e)
        {
            v.CurrentPosition = 0;
        }
    }
}
