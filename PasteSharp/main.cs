using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

namespace PasteSharp
{
    public class Paste
    {
        public async Task<string> Post(Str.PastebinToken tk, Str.PastebinContent cnt)
        {
            Dictionary<string, string> dsr = new Dictionary<string, string>
            {
                { "api_dev_key", tk.token },
                { "api_paste_code", cnt.content },
                { "api_user_key", cnt.userkey },
                { "api_paste_private", cnt.visibility },
                { "api_paste_name", cnt.title },
                { "api_paste_expire_date", cnt.expdate },
                { "api_paste_format",  cnt.format }
            };
            HttpClient hts = new HttpClient();
            var rsp = await (await hts.PostAsync("https://pastebin.com/api/api_post.php", new FormUrlEncodedContent(dsr))).Content.ReadAsStringAsync();
            return rsp;
        }
    }
    public class Str
    {
        public struct PastebinToken
        {
            public string token { get; set; }
            public PastebinToken(string tok)
            {
                token = tok;
            }
        }
        public struct PastebinContent
        {
            public string title { get; set; }
            public string content { get; set; }
            public string visibility { get; set; }
            public string format { get; set; }
            public string userkey { get; set; }
            public string expdate { get; set; }
            public PastebinContent(string cnt, string vis, string form, string usk, string ttl, string exp)
            {
                content = cnt;
                visibility = vis;
                format = form;
                userkey = usk;
                title = ttl;
                expdate = exp;
            }
        }
    }
}
