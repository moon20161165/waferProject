using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WOMS
{
    class ProgressInfo
    {
        public static int status { get; set; }
        private static int fullStatus;
        public int getFullStatus()
        {
            return 100;
        }
        public void setFullStatus(int _fullStatus)
        {
            fullStatus = _fullStatus;
        }
        public ProgressInfo() { }
        
        private static DateTime Delay(int MS)
        {
            DateTime ThisMoment = DateTime.Now;
            TimeSpan duration = new TimeSpan(0, 0, 0, 0, MS);
            DateTime AfterWards = ThisMoment.Add(duration);

            while (AfterWards >= ThisMoment)
            {
                System.Windows.Forms.Application.DoEvents();
                ThisMoment = DateTime.Now;
            }
            return DateTime.Now;
        }
        private void addStatus()
        {
            Delay(2000);
            status += 2;
        }
        public void Start()
        {
            status = 0;
            while(true)
            {
                addStatus();
                if(status == 100)
                {
                    break;
                }
            }
        }
    }
}
