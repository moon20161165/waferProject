using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaferProject.INFO
{
    class EquipInfo
    {
        private string equipId;
        private string equipType;
        private int equipState;
        private string equipComm;
        private string equipRecDate;
        private string equipManager;
        private string operId;
        private string equipUpdate;

        public EquipInfo()
        { }
        public EquipInfo(string equipId, string equipType, int equipState, string equipComm, string equipRecDate, string equipManager, string operId, string equipUpdate)
        {
            this.equipId = equipId;
            this.equipType = equipType;
            this.equipState = equipState;
            this.equipComm = equipComm;
            this.equipRecDate = equipRecDate;
            this.equipManager = equipManager;
            this.operId = operId;
            this.equipUpdate = equipUpdate;
        }

        public void setEquipId(string equipId)
        {
            this.equipId = equipId;
        }
        public string getEquipId()
        {
            return equipId;
        }
        public void setEquipType(string equipType)
        {
            this.equipType = equipType;
        }
        public string getEquipType()
        {
            return equipType;
        }
        public void setEquipState(int equipState)
        {
            this.equipState = equipState;
        }
        public int getEquipState()
        {
            return equipState;
        }
        public void setEquipComm(string equipComm)
        {
            this.equipComm = equipComm;
        }
        public string getEquipComm()
        {
            return equipComm;
        }
        public void setEquipRecDate(string equipRecDate)
        {
            this.equipRecDate = equipRecDate;
        }
        public string getEquipRecDate()
        {
            return equipRecDate;
        }
        public void setEquipManager(string equipManager)
        {
            this.equipManager = equipManager;
        }
        public string getEquipManager()
        {
            return equipManager;
        }
        public void setOperId(string operId)
        {
            this.operId = operId;
        }
        public string getOperId()
        {
            return operId;
        }
        public void setEquipUpdate(string equipUpdate)
        {
            this.equipUpdate = equipUpdate;
        }
        public string getEquipUpdate()
        {
            return equipUpdate;
        }
    }
}
