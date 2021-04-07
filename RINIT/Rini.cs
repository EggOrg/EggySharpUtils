using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RINIT
{
    public class ParsingEngine
    {
        public Rini.ParsedRinitFile Parse(Rini.RinitFile rn)
        {
            return new Rini.ParsedRinitFile(new StreamReader(rn.FullRinit).ReadToEnd().Replace("@RinitFile[<-", string.Empty).Replace("->]", string.Empty).Split(','));
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
            public string[] FullParsedRinit { get; set; }
            public ParsedRinitFile(string[] parsedrinit)
            {
                FullParsedRinit = parsedrinit;
            }
        }
    }
    public static class RiniStart
    {
        public static void Start(Rini.ParsedRinitFile rf)
        {
            foreach (string str in rf.FullParsedRinit)
            {
                System.Diagnostics.Process.Start(str);
            }
        }
    }
}
