using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaferProject.DB;

namespace WaferProject.SERVER
{
    class AutoIncrement
    {
        public AutoIncrement() { }
        /* 웨이퍼 아이디 넘버 생성 */
        public static string wafer_num()
        {
            Database db = new Database();
            int number = db.max_index(3);

            /* 1 증가 */
            number += 1;

            return "WAFER" + DateTime.Now.ToString("yy") + number.ToString("D5");
        }
        /* 잉곳 아이디 넘버 생성 */
        public static string ingot_num()
        {
            Database db = new Database();
            int number = db.max_index(1);

            /* 1 증가 */
            number += 1;

            return "INGOT" + DateTime.Now.ToString("yy") + number.ToString("D5");
        }
        /* 블록 아이디 넘버 생성 */
        public static string[] block_num()
        {
            Database db = new Database();
            int number = db.max_index(2);
            string[] num = new string[3];

            /* 1 증가 */
            number += 1;
            for(int i=0; i<3; i++)
            {
                num[i] = "BLOCK" + DateTime.Now.ToString("yy") + number.ToString("D5");
                number++;
            }

            return num;
        }
        /* 경로 아이디 넘버 생성 */
        public static string route_num()
        {
            Database db = new Database();
            int number = db.max_index(4);

            /* 1 증가 */
            number += 1;

            return "ROUTE" + number.ToString("D5");
        }
    }
}
