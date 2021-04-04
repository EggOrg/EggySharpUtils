using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCUtils
{
    public class Hookins
    {
        public struct MCUUID
        {
            public string UUID { get; set; }
            public MCUUID(string uuid)
            {
                UUID = uuid;
            }
        }
        public struct MCNAME
        {
            public string NAME { get; set; }
            public MCNAME(string name)
            {
                NAME = name;
            }
        }
        public class MCJSON
        {
            public string id { get; set; }
            public string name { get; set; }
        }
    }
}
