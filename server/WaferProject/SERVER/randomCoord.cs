using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaferProject.SERVER
{
    class randomCoord
    {
        public randomCoord() { }

        /* random 좌표값 뽑기 */
        public int[] randomPick()
        {
            Random ran = new Random();
            int[] coord = new int[4];

            for(int i=0; i<2; i++)
            {
                coord[i] = ran.Next(40,181);
            }
            for(int j=2; j<4; j++)
            {
                coord[j] = ran.Next(50, 131);
            }

            return coord;
        }

        /* random bow, warp, thk 뽑기 */
        public int[] randomData()
        {
            Random ran = new Random();
            int[] random = new int[3];
            for(int i=0; i<3; i++)
            {
                random[i] = ran.Next(0, 301);
            }

            return random;
        }
    }
}
