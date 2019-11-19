using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaferProject.INFO
{
    class WaferInfo
    {
        private string waferId;
        private string blockId;
        private string ingotId;
        private int waferQuant;
        private int waferCreate;
        private string waferStartT;
        private string waferFinishT;
        private string waferComm;
        private int waferFaulty;
        private string operId;
        private string msCode;
        private string equipId;
        private string equipRpm;
        private string waferMaker;

        public WaferInfo() { }
        public WaferInfo(string waferId, string blockId, string ingotId, int waferQuant, 
            int waferCreate, string waferStartT, string waferFinishT, string waferComm, 
            int waferFaulty, string operId, string msCode, string equipId, string equipRpm)
        {
            this.waferId = waferId;
            this.blockId = blockId;
            this.ingotId = ingotId;
            this.waferQuant = waferQuant;
            this.waferCreate = waferCreate;
            this.waferStartT = waferStartT;
            this.waferFinishT = waferFinishT;
            this.waferComm = waferComm;
            this.waferFaulty = waferFaulty;
            this.operId = operId;
            this.msCode = msCode;
            this.equipId = equipId;
            this.equipRpm = equipRpm;
        }
        public void setEquipRpm(string equipRpm)
        {
            this.equipRpm = equipRpm;
        }
        public string getEquipRpm()
        {
            return equipRpm;
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
        public void setWaferFaulty(int waferFaulty)
        {
            this.waferFaulty = waferFaulty;
        }
        public int getWaferFaulty()
        {
            return waferFaulty;
        }
        public void setWaferComm(string waferComm)
        {
            this.waferComm = waferComm;
        }
        public string getWaferComm()
        {
            return waferComm;
        }
        public void setWaferFinishT(string waferFinishT)
        {
            this.waferFinishT = waferFinishT;
        }
        public string getWaferFinishT()
        {
            return waferFinishT;
        }
        public void setWaferStartT(string waferStartT)
        {
            this.waferStartT = waferStartT;
        }
        public string getWaferStartT()
        {
            return waferStartT;
        }
        public void setWaferCreate(int waferCreate)
        {
            this.waferCreate = waferCreate;
        }
        public int getWaferCreate()
        {
            return waferCreate;
        }
        public void setWaferQuant(int waferQuant)
        {
            this.waferQuant = waferQuant;
        }
        public int getWaferQuant()
        {
            return waferQuant;
        }
        public void setIngotId(string ingotId)
        {
            this.ingotId = ingotId;
        }
        public string getIngotId()
        {
            return ingotId;
        }
        public void setBlockId(string blockId)
        {
            this.blockId = blockId;
        }
        public string getBlockId()
        {
            return blockId;
        }
        public void setWaferId(string waferId)
        {
            this.waferId = waferId;
        }
        public string getWaferId()
        {
            return waferId;
        }
        public void setWaferMaker(string waferMaker)
        {
            this.waferMaker = waferMaker;
        }
        public string getWaferMaker()
        {
            return waferMaker;
        }
    }
}

