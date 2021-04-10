using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http;

namespace MCLogsSharp
{
    public class API
    {
        public async Task<Str.MCLogsApiResponse> Paste(string content)
        {
            var vl = new Dictionary<string, string> { { "content", content } };
            HttpClient cl = new HttpClient();
            var response = await (await cl.PostAsync(@"https://api.mclo.gs/1/log", new FormUrlEncodedContent(vl))).Content.ReadAsStringAsync();
            Str.MCLogsApiResponse rsp = new Str.MCLogsApiResponse();
            JObject jrs = JObject.Parse(response);
            try
            {
                rsp.success = (bool)jrs["success"];
                rsp.id = (string)jrs["id"];
                rsp.url = (string)jrs["url"];
                rsp.raw = (string)jrs["raw"];
            }
            catch
            {
                rsp.error = (string)jrs["error"];
                rsp.success = (bool)jrs["success"];
            }
            return rsp;
        }
    }
    public class Str
    {
        public struct MCLogsApiResponse
        {
            public bool success { get; set; }
            public string error { get; set; }
            public string id { get; set; }
            public string url { get; set; }
            public string raw { get; set; }
        }
    }
}
