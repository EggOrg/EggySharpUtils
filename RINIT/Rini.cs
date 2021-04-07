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
        public List<string[]> Parse(string rinit)
        {
            List<string[]> strs = new List<string[]>();
            string[] rnf = rinit.Replace("@RinitFile[<-", string.Empty).Replace("->]", string.Empty).Split(',');
            foreach (string rnfkey in rnf)
            {
                string[] keyh = rnfkey.Split('-');
                strs.Add(keyh);
            }
            return strs;
        }
        public List<string[]> Parse(Stream rinitpath)
        {
            List<string[]> strs = new List<string[]>();
            string[] rnf = new StreamReader(rinitpath).ReadToEnd().Replace("@RinitFile[<-", string.Empty).Replace("->]", string.Empty).Split(',');
            foreach (string rnfkey in rnf)
            {
                string[] keyh = rnfkey.Split('-');
                strs.Add(keyh);
            }
            return strs;
        }
    }
}
