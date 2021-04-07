using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RINIT
{
    public class ParsingEngine
    {
        public Rini.ParsedRinitFile Parse(Rini.RinitFile rn)
        {
            return new Rini.ParsedRinitFile(rn.FullRinit.Replace("@RINIT[<-", string.Empty).Replace("->]", string.Empty));
        }
    }
    public class Rini
    {
        public struct RinitFile
        {
            public string FullRinit { get; set; }
            public RinitFile(string rinit)
            {
                FullRinit = rinit;
            }
        }
        public struct ParsedRinitFile {
            public string FullParsedRinit { get; set; }
            public ParsedRinitFile(string parsedrinit)
            {
                FullParsedRinit = parsedrinit;
            }
        }
    }
    public class RiniStart
    {
        public void Start(Rini.ParsedRinitFile rf)
        {
            System.Diagnostics.Process.Start(rf.FullParsedRinit);
        }
    }
}
