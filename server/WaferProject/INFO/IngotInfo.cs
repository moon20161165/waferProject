using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaferProject.INFO
{
    class IngotInfo
    {
        private string ingotId;
        private double ingotWeight;
        private double ingotTemp;
        private int ingotState;
        private int ingotCreate;
        private string ingotStartT;
        private string ingotFinishT;
        private string operId;
        private string equipId;
        private string ingotMaker;
        private int ingotFlag;

        public IngotInfo() { }

        public IngotInfo(string ingotId, double ingotWeight, double ingotTemp, int ingotState, 
            int ingotCreate, string ingotStartT, string ingotFinishT, string operId, string equipId, string ingotMaker, int ingotFlag)
        {
            this.ingotId = ingotId;
            this.ingotWeight = ingotWeight;
            this.ingotTemp = ingotTemp;
            this.ingotState = ingotState;
            this.ingotCreate = ingotCreate;
            this.ingotStartT = ingotStartT;
            this.ingotFinishT = ingotFinishT;
            this.operId = operId;
            this.equipId = equipId;
            this.ingotMaker = ingotMaker;
            this.ingotFlag = ingotFlag;
        }
        public void setIngotFlag(int ingotFlag)
        {
            this.ingotFlag = ingotFlag;
        }
        public int getIngotFlag()
        {
            return ingotFlag;
        }
        public void setIngotMaker(string ingotMaker)
        {
            this.ingotMaker = ingotMaker;
        }
        public string getIngotMaker()
        {
            return ingotMaker;
        }
        public void setEquipId(string equipId)
        {
            this.equipId = equipId;
        }
        public string getEquipId()
        {
            return equipId;
        }
        public void setOperId(string operId)
        {
            this.operId = operId;
        }
        public string getOperId()
        {
            return operId;
        }
        public void setIngotFinishT(string ingotFinishT)
        {
            this.ingotFinishT = ingotFinishT;
        }
        public string getIngotFinishT()
        {
            return ingotFinishT;
        }
        public void setIngotStartT(string ingotStartT)
        {
            this.ingotStartT = ingotStartT;
        }
        public string getIngotStartT()
        {
            return ingotStartT;
        }
        public void setIngotCreate(int ingotCreate)
        {
            this.ingotCreate = ingotCreate;
        }
        public int getIngotCreate()
        {
            return ingotCreate;
        }
        public void setIngotState(int ingotState)
        {
            this.ingotState = ingotState;
        }
        public int getIngotState()
        {
            return ingotState;
        }
        public void setIngotTemp(double ingotTemp)
        {
            this.ingotTemp = ingotTemp;
        }
        public double getIngotTemp()
        {
            return ingotTemp;
        }
        public void setIngotWeight(double ingotWeight)
        {
            this.ingotWeight = ingotWeight;
        }
        public double getIngotWeight()
        {
            return ingotWeight;
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
