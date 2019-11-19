using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaferProject.INFO
{
    class FaultyInfo
    {
        private string faultyId;
        private int faultyQuant;
        private string waferId;
        private string faultyCreate;
        private string faultyUpdate;

        public FaultyInfo() { }
        public FaultyInfo(string faultyId, int faultyQuant, string waferId, string faultyCreate, string faultyUpdate)
        {
            this.faultyId = faultyId;
            this.faultyQuant = faultyQuant;
            this.waferId = waferId;
            this.faultyCreate = faultyCreate;
            this.faultyUpdate = faultyUpdate;
        }
        public void setFaultyUpdate(string faultyUpdate)
        {
            this.faultyUpdate = faultyUpdate;
        }
        public string getFaultyUpdate()
        {
            return faultyUpdate;
        }
        public void setFaultyCreate(string faultyCreate)
        {
            this.faultyCreate = faultyCreate;
        }
        public string getFaultyCreate()
        {
            return faultyCreate;
        }
        public void setWaferId(string waferId)
        {
            this.waferId = waferId;
        }
        public string getWaferId()
        {
            return waferId;
        }
        public void setFaultyQuant(int faultyQuant)
        {
            this.faultyQuant = faultyQuant;
        }
        public int getFaultyQuant()
        {
            return faultyQuant;
        }
        public void setFaultyId(string faultyId)
        {
            this.faultyId = faultyId;
        }
        public string getFaultyId()
        {
            return faultyId;
        }

    }
}
