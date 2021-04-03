using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static htmsharp.HTMLib;

namespace htmsharp
{
    static class Utils
    {
        public static string GetInBetweens(this htmsharp.HTMLib.Html htm, string blockname)
        {
            return htm.PureHTML.Split(new string[] { $"{blockname}" }, StringSplitOptions.None)[1].Split('>')[1].Split('<')[0];
        }
    }
}
