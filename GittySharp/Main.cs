using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace GittySharp
{
    public class Repos
    {
        public void Clone(Enums.Format fr, Structs.Repo rp, string outp)
        {
            WebClient wcl = new WebClient();
            if (fr == Enums.Format.git) wcl.DownloadFile($"https://github.com/{rp.Author}/{rp.Name}.git", outp);
        }
    }
    public class Structs
    {
        public struct Repo
        {
            public string Author { get; set; }
            public string Name { get; set; }
        }
    }
    public class Enums
    {
        public enum Format
        {
            git,
            zip
        }
    }
}
