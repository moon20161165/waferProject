using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaferProject.INFO
{
    class CodeNameInfo
    {
        private string codeType;
        private string attFirst;
        private string attSecond;
        private string attThird;
        private string attFourth;
        private string attFifth;
        private string attSixth;
        private string attSeventh;
        private string attEighth;
        private string attNinth;
        private string attTenth;
        public CodeNameInfo() { }
        public CodeNameInfo(string codeType, string attFirst, string attSecond, string attThird, 
            string attFourth, string attFifth, string attSixth, string attSeventh, string attEighth, string attNinth, string attTenth)
        {
            this.codeType = codeType;
            this.attFirst = attFirst;
            this.attSecond = attSecond;
            this.attThird = attThird;
            this.attFourth = attFourth;
            this.attFifth = attFifth;
            this.attSixth = attSixth;
            this.attSeventh = attSeventh;
            this.attEighth = attEighth;
            this.attNinth = attNinth;
            this.attTenth = attTenth;
        }
        public void setAttTenth(string attTenth)
        {
            this.attTenth = attTenth;
        }
        public string getAttTenth()
        {
            return attTenth;
        }
        public void setAttNinth(string attNinth)
        {
            this.attNinth = attNinth;
        }
        public string getAttNinth()
        {
            return attNinth;
        }
        public void setAttEighth(string attEighth)
        {
            this.attEighth = attEighth;
        }
        public string getAttEighth()
        {
            return attEighth;
        }
        public void setAttSeventh(string attSeventh)
        {
            this.attSeventh = attSeventh;
        }
        public string getAttSeventh()
        {
            return attSeventh;
        }
        public void setAttSixth(string attSixth)
        {
            this.attSixth = attSixth;
        }
        public string getAttSixth()
        {
            return attSixth;
        }
        public void setAttFifth(string attFifth)
        {
            this.attFifth = attFifth;
        }
        public string getAttFifth()
        {
            return attFifth;
        }
        public void setAttFourth(string attFourth)
        {
            this.attFourth = attFourth;
        }
        public string getAttFourth()
        {
            return attFourth;
        }
        public void setAttThird(string attThird)
        {
            this.attThird = attThird;
        }
        public string getAttThird()
        {
            return attThird;
        }
        public void setAttSecond(string attSecond)
        {
            this.attSecond = attSecond;
        }
        public string getAttSecond()
        {
            return attSecond;
        }
        public void setAttFirst(string attFirst)
        {
            this.attFirst = attFirst;
        }
        public string getAttFirst()
        {
            return attFirst;
        }
        public void setCodeType(string codeType)
        {
            this.codeType = codeType;
        }
        public string getCodeType()
        {
            return codeType;
        }
    }
}
