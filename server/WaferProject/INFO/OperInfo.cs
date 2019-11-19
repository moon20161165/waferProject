using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaferProject.INFO
{
    class OperInfo
    {
        private string operId;
        private string operType;
        private string operCreate;
        private string operUpdate;
        private string operSeq;

        public OperInfo()
        { }

        public OperInfo(string operId, string operType, string operCreate, string operUpdate, string operSeq)
        {
            this.operId = operId;
            this.operType = operType;
            this.operCreate = operCreate;
            this.operUpdate = operUpdate;
            this.operSeq = operSeq;
        }
        public void setOperSeq(string operSeq)
        {
            this.operSeq = operSeq;
        }
        public string getOperSeq()
        {
            return operSeq;
        }
        public void setOperUpdate(string operUpdate)
        {
            this.operUpdate = operUpdate;
        }
        public string getOperUpdate()
        {
            return operUpdate;
        }
        public void setOperCreate(string operCreate)
        {
            this.operCreate = operCreate;
        }
        public string getOperCreate()
        {
            return operCreate;
        }
        public void setOperId(string operId)
        {
            this.operId = operId;
        }
        public string getOperId()
        {
            return operId;
        }
        public void setOperType(string operType)
        {
            this.operType = operType;
        }
        public string getOperType()
        {
            return operType;
        }
    }
}
