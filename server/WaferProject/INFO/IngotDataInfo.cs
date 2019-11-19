using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaferProject.INFO
{
    class IngotDataInfo
    {
        private string ingotId;
        private double currTemp;
        private double currVel;
        private double currLen;
        private string currTime;

        public IngotDataInfo() { }

        public IngotDataInfo(string ingotId, double currTemp, double currVel, double currLen, string currTime)
        {
            this.ingotId = ingotId;
            this.currTemp = currTemp;
            this.currVel = currVel;
            this.currLen = currLen;
            this.currTime = currTime;
        }
        public void setCurrLen(double currLen)
        {
            this.currLen = currLen;
        }
        public double getCurrLen()
        {
            return currLen;
        }
        public void setCurrVel(double currVel)
        {
            this.currVel = currVel;
        }
        public double getCurrVel()
        {
            return currVel;
        }
        public void setCurrTemp(double currTemp)
        {
            this.currTemp = currTemp;
        }
        public double getCurrTemp()
        {
            return currTemp;
        }
        public void setCurrTime(string currTime)
        {
            this.currTime = currTime;
        }
        public string getCurrTime()
        {
            return currTime;
        }
        public void setIngotId(string ingotId)
        {
            this.ingotId = ingotId;
        }
        public string getIngotId()
        {
            return ingotId;
        }
    }
}
