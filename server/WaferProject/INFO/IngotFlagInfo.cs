using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaferProject.INFO
{
    static class IngotFlagInfo
    {
        private static object _lock = new object();

        private static string _ingotMake;
        private static string _ingotFlag;
        private static string _fan;
        private static string _heat;
        public static string ingotFlag
        {
            set
            {
                lock(_lock)
                {
                    _ingotFlag = value;
                }
            }
            get
            {
                lock(_lock)
                {
                    return _ingotFlag;
                }
            }
        }
        public static string ingotMake
        {
            set
            {
                lock(_lock)
                {
                    _ingotMake = value;
                }
            }

            get
            {
                lock (_lock)
                {
                    return _ingotMake;
                }
            }
        }
        public static string fan
        {
            set
            {
                lock (_lock)
                {
                    _fan = value;
                }
            }

            get
            {
                lock (_lock)
                {
                    return _fan;
                }
            }
        }
        public static string heat
        {
            set
            {
                lock (_lock)
                {
                    _heat = value;
                }
            }

            get
            {
                lock (_lock)
                {
                    return _heat;
                }
            }
        }
    }
}
