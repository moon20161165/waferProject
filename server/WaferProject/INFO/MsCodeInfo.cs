using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaferProject.INFO
{
    class MsCodeInfo
    {
        private string msCode;
        private string corpName;
        private string corpComm;
        private string corpManager;
        private string routeId;
        private string msCodeCreate;
        private string msCodeUpdate;

        public MsCodeInfo() { }

        public MsCodeInfo(string msCode, string corpName, string corpComm, string corpManager, string routeId,
            string msCodeCreate, string msCodeUpdate)
        {
            this.msCode = msCode;
            this.corpName = corpName;
            this.corpComm = corpComm;
            this.corpManager = corpManager;
            this.routeId = routeId;
            this.msCodeCreate = msCodeCreate;
            this.msCodeUpdate = msCodeUpdate;
        }
        public void setMsCodeUpdate(string msCodeUpdate)
        {
            this.msCodeUpdate = msCodeUpdate;
        }
        public string getMsCodeUpdate()
        {
            return msCodeUpdate;
        }
        public void setMsCodeCreate(string msCodeCreate)
        {
            this.msCodeCreate = msCodeCreate;
        }
        public string getMsCodeCreate()
        {
            return msCodeCreate;
        }
        public void setRouteId(string routeId)
        {
            this.routeId = routeId;
        }
        public string getRouteId()
        {
            return routeId;
        }
        public void setCorpManager(string corpManager)
        {
            this.corpManager = corpManager;
        }
        public string getCorpManager()
        {
            return corpManager;
        }
        public void setCorpComm(string corpComm)
        {
            this.corpComm = corpComm;
        }
        public string getCorpComm()
        {
            return corpComm;
        }
        public void setCorpName(string corpName)
        {
            this.corpName = corpName;
        }
        public string getCorpName()
        {
            return corpName;
        }
        public void setMsCode(string msCode)
        {
            this.msCode = msCode;
        }
        public string getMsCode()
        {
            return msCode;
        }
    }
}
