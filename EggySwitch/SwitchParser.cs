﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EggySwitch
{
    public static class Ext
    {
        public static int[] IndexSwitches(this string[] toparse, string[] lookfor)
        {
            List<int> intsh = new List<int>();
            foreach ((string it, Int32 i) in toparse.Select((value, i) => (value, i)))
            {
                foreach (string tolookfor in lookfor)
                {
                    if (it == tolookfor)
                    {
                        intsh.Add(i);
                    }
                }
            }
            return intsh.ToArray();
        }
    }
}
