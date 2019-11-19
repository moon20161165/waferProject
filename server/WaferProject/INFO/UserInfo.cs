using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaferProject.INFO
{
    class UserInfo
    {
        private string user_id;
        private string user_pw;
        private string user_name;
        private string user_pos;
        private string user_right;
        public UserInfo()
        {
            user_name = "";
        }

        public void setUser_id(string user_id)
        {
            this.user_id = user_id;
        }
        public string getUser_id()
        {
            return user_id;
        }

        public void setUser_pw(string user_pw)
        {
            this.user_pw = user_pw;
        }
        public string getUser_pw()
        {
            return user_pw;
        }

        public void setUser_name(string user_name)
        {
            this.user_name = user_name;
        }
        public string getUser_name()
        {
            return user_name;
        }

        public void setUser_pos(string user_pos)
        {
            this.user_pos = user_pos;
        }
        public string getUser_pos()
        {
            return user_pos;
        }

        public void setUser_right(string user_right)
        {
            this.user_right = user_right;
        }
        public string getUser_right()
        {
            return user_right;
        }
    }
}
