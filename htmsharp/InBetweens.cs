using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace htmsharp
{
    public class InBetweens
    {
        public struct Html
        {
            private static string PureHTML { get; set; }
            public Html(string htm)
            {
                PureHTML = htm;
            }
            public static class GetInBtws
            {
                public static string GetInBetweens(string blockname)
                {
                    return PureHTML.Split(new string[] { $"<{blockname}>" }, StringSplitOptions.None)[1];
                }
            } 
        }
    }
}
