using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitSharp
{
    public class GitClient
    {
        public class JSON
        {
            public RestClient rc = new RestClient("https://api.github.com");
            public Str.GitJSON GetUser(string username)
            {
                Str.GitJSON jsg = new Str.GitJSON();
                jsg.JSON = rc.Get(new RestRequest("/users/{username}", DataFormat.Json)).Content;
                return jsg;
            }
        }
    }
    public class Str
    {
        public struct GitJSON
        {
            public string JSON { get; set; }
        }
    }
}
