using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaferProject.INFO
{
    class CodeInfo
    {
        private string codeId;
        private string codeType;
        private string codeComm;
        private string codeAttFir;
        private string codeAttSec;
        private string codeAttThr;
        private string codeAttFour;
        private string codeAttFif;
        private string codeAttSix;
        private string codeAttSev;
        private string codeAttEig;
        private string codeAttNin;
        private string codeAttTen;
        private string codeCreate;
        private string codeUpdate;


        public CodeInfo()
        { }
        public CodeInfo(string codeId, string codeType, string codeComm, string codeAttFir,
            string codeAttSec, string codeAttThr, string codeAttFour, string codeAttFif, string codeAttSix,
            string codeAttSev, string codeAttEig, string codeAttNin, string codeAttTen, string codeCreate, string codeUpdate)
        {
            this.codeId = codeId;
            this.codeType = codeType;
            this.codeComm = codeComm;
            this.codeAttFir = codeAttFir;
            this.codeAttSec = codeAttSec;
            this.codeAttThr = codeAttThr;
            this.codeAttFour = codeAttFour;
            this.codeAttFif = codeAttFif;
            this.codeAttSix = codeAttSix;
            this.codeAttSev = codeAttSev;
            this.codeAttEig = codeAttEig;
            this.codeAttNin = codeAttNin;
            this.codeAttTen = codeAttTen;
            this.codeCreate = codeCreate;
            this.codeUpdate = codeUpdate;
        }
        public void setCodeUpdate(string codeUpdate)
        {
            this.codeUpdate = codeUpdate;
        }
        public string getCodeUpdate()
        {
            return codeUpdate;
        }
        public void setCodeCreate(string codeCreate)
        {
            this.codeCreate = codeCreate;
        }
        public string getCodeCreate()
        {
            return codeCreate;
        }
        public void setCodeId(string codeId)
        {
            this.codeId = codeId;
        }
        public string getCodeId()
        {
            return codeId;
        }
        public void setCodeType(string codeType)
        {
            this.codeType = codeType;
        }
        public string getCodeType()
        {
            return codeType;
        }
        public void setCodeComm(string codeComm)
        {
            this.codeComm = codeComm;
        }
        public string getCodeComm()
        {
            return codeComm;
        }
        public void setCodeAttFir(string codeAttFir)
        {
            this.codeAttFir = codeAttFir;
        }
        public string getCodeAttFir()
        {
            return codeAttFir;
        }
        public void setCodeAttSec(string codeAttSec)
        {
            this.codeAttSec = codeAttSec;
        }
        public string getCodeAttSec()
        {
            return codeAttSec;
        }
        public void setCodeAttThr(string codeAttThr)
        {
            this.codeAttThr = codeAttThr;
        }
        public string getCodeAttThr()
        {
            return codeAttThr;
        }
        public void setCodeAttFour(string codeAttFour)
        {
            this.codeAttFour = codeAttFour;
        }
        public string getCodeAttFour()
        {
            return codeAttFour;
        }
        public void setCodeAttFif(string codeAttFif)
        {
            this.codeAttFif = codeAttFif;
        }
        public string getCodeAttFif()
        {
            return codeAttFif;
        }
        public void setCodeAttSix(string codeAttSix)
        {
            this.codeAttSix = codeAttSix;
        }
        public string getCodeAttSix()
        {
            return codeAttSix;
        }
        public void setCodeAttSev(string codeAttSev)
        {
            this.codeAttSev = codeAttSev;
        }
        public string getCodeAttSev()
        {
            return codeAttSev;
        }
        public void setCodeAttEig(string codeAttEig)
        {
            this.codeAttEig = codeAttEig;
        }
        public string getCodeAttEig()
        {
            return codeAttEig;
        }
        public void setCodeAttNin(string codeAttNin)
        {
            this.codeAttNin = codeAttNin;
        }
        public string getCodeAttNin()
        {
            return codeAttNin; 
        }
        public void setCodeAttTen(string codeAttTen)
        {
            this.codeAttTen = codeAttTen;
        }
        public string getCodeAttTen()
        {
            return codeAttTen; 
        }
    }
}
