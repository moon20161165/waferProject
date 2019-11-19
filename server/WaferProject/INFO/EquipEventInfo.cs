using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaferProject.INFO
{
    class EquipEventInfo
    {
        private string equipId;
        private string equipEventId;
        private string equipEventType;
        private string equipEvemtTime;
        private string equipState;
        private string repairManager;
        public EquipEventInfo()
        { }
        public EquipEventInfo(string equipId, string equipEventId, string equipEventType, string equipEvemtTime, string equipState, string repairManager)
        {
            this.equipId = equipId;
            this.equipEventId = equipEventId;
            this.equipEventType = equipEventType;
            this.equipEvemtTime = equipEvemtTime;
            this.equipState = equipState;
            this.repairManager = repairManager;
        }

        public void setEquipId(string equipId)
        {
            this.equipId = equipId;
        }
        public string getEquipId()
        {
            return equipId;
        }
        public void setEquipEventId(string equipEventId)
        {
            this.equipEventId = equipEventId;
        }
        public string getEquipEventId()
        {
            return equipEventId;
        }
        public void setEquipEventType(string equipEventType)
        {
            this.equipEventType = equipEventType;
        }
        public string getEquipEventType()
        {
            return equipEventType;
        }
        public void setEquipEvemtTime(string equipEvemtTime)
        {
            this.equipEvemtTime = equipEvemtTime;
        }
        public string getEquipEvemtTime()
        {
            return equipEvemtTime;
        }
        public void setEquipState(string equipState)
        {
            this.equipState = equipState;
        }
        public string getEquipState()
        {
            return equipState;
        }
        public void setRepairManager(string repairManager)
        {
            this.repairManager = repairManager;
        }
        public string getRepairManager()
        {
            return repairManager;
        }
    }
}
