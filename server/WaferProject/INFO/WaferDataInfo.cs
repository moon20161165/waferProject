using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaferProject.INFO
{
    class WaferDataInfo
    {
        private string waferId;
        private int waferPX1;
        private int waferPY1;
        private int waferPX2;
        private int waferPY2;
        private int currTtv;
        private int currBow;
        private int currWarp;
        private int currThk;
        private string operId;
        private string msCode;
        private string equipId;
        private string currDate;
        private string equipRpm;
       
        public WaferDataInfo() { }

        public WaferDataInfo(string waferId, int waferPX1, int waferPY1, int waferPX2, int waferPY2, int currTtv, 
            int currBow, int currWarp, int currThk, string operId, string msCode, string equipId, string currDate, string equipRpm)
        {
            this.waferId = waferId;
            this.waferPX1 = waferPX1;
            this.waferPY1 = waferPY1;
            this.waferPX2 = waferPX2;
            this.waferPY2 = waferPY2;
            this.currTtv = currTtv;
            this.currBow = currBow;
            this.currWarp = currWarp;
            this.currThk = currThk;
            this.operId = operId;
            this.msCode = msCode;
            this.equipId = equipId;
            this.currDate = currDate;
            this.equipRpm = equipRpm;
        }
        public void setWaferPY2(int waferPY2)
        {
            this.waferPY2 = waferPY2;
        }
        public int getWaferPY2()
        {
            return waferPY2;
        }
        public void setWaferPX2(int waferPX2)
        {
            this.waferPX2 = waferPX2;
        }
        public int getWaferPX2()
        {
            return waferPX2;
        }
        public void setWaferPY1(int waferPY1)
        {
            this.waferPY1 = waferPY1;
        }
        public int getWaferPY1()
        {
            return waferPY1;
        }
        public void setWaferPX1(int waferPX1)
        {
            this.waferPX1 = waferPX1;
        }
        public int getWaferPX1()
        {
            return waferPX1;
        }
        public void setCurrDate(string currDate)
        {
            this.currDate = currDate;
        }
        public string getCurrDate()
        {
            return currDate;
        }
        public void setEquipRpm(string equipRpm)
        {
            this.equipRpm = equipRpm;
        }
        public string getEquipRpm()
        {
            return equipRpm;
        }
        public void setCurrThk(int currThk)
        {
            this.currThk = currThk;
        }
        public int getCurrThk()
        {
            return currThk;
        }
        public void setCurrWarp(int currWarp)
        {
            this.currWarp = currWarp;
        }
        public int getCurrWarp()
        {
            return currWarp;
        }
        public void setCurrBow(int currBow)
        {
            this.currBow = currBow;
        }
        public int getCurrBow()
        {
            return currBow;
        }
        public void setCurrTtv(int currTtv)
        {
            this.currTtv = currTtv;
        }
        public int getCurrTtv()
        {
            return currTtv;
        }
        public void setWaferId(string waferId)
        {
            this.waferId = waferId;
        }
        public string getWaferId()
        {
            return waferId;
        }
        public void setEquipId(string equipId)
        {
            this.equipId = equipId;
        }
        public string getEquipId()
        {
            return equipId;
        }
        public void setMsCode(string msCode)
        {
            this.msCode = msCode;
        }
        public string getMsCode()
        {
            return msCode;
        }
        public void setOperId(string operId)
        {
            this.operId = operId;
        }
        public string getOperId()
        {
            return operId;
        }
    }
}
