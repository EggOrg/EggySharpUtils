using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace htmsharp
{
    public class HTMLib
    {
        public struct Html
        {
            public string PureHTML { get; set; }
            public Html(string htm)
            {
                PureHTML = htm;
            }
        }
    }
}
