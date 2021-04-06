using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace IPApiSharp
{
    public class Str
    {
        /// <summary>
        /// Stores data of an IP.
        /// </summary>
        public struct IPStr
        {
            public string Status { get; set; }
            public float Lat { get; set; }
            public float Long { get; set; }
            public string Timezone { get; set; }
            public string Zip { get; set; }
            public string Isp { get; set; }
            public string CountryCode { get; set; }
            public string City { get; set; }
            public string Country { get; set; }
            public string As { get; set; }
            public string Org { get; set; }
            public string Query { get; set; }
            public string Asname { get; set; }
            public string Reverse { get; set; }
            public string District { get; set; }
            public bool Mobile { get; set; }
            public bool Hosting { get; set; }
            public bool Proxy { get; set; }
            public string RegionName { get; set; }
            public string Continent { get; set; }
            public string ContinentCode { get; set; }
            public string Message { get; set; }
            public int Offset { get; set; }
            public JObject JObject { get; set; }
            public string Raw { get; set; }
        }
    }
    public class API
    {
        /// <summary>
        /// Gets IPStr from an IP asynchronously.
        /// </summary>
        /// <param name="source">Source IP.</param>
        public static async Task<Str.IPStr> Get(string source)
        {
            HttpClient cl = new HttpClient();
            string response = await cl.GetStringAsync(new Uri($"http://ip-api.com/json/{source}?fields=66846719"));
            JObject jsr = new JObject();
            jsr = JObject.Parse(response);
            Str.IPStr jrop = new Str.IPStr();
            jrop.Status = (string)jsr["status"];
            if (jrop.Status == "fail")
            {
                jrop.Message = (string)jsr["message"];
                return jrop;
            }
            jrop.Lat = (float)jsr["lat"];
            jrop.Long = (float)jsr["lon"];
            jrop.Zip = (string)jsr["zip"];
            jrop.Country = (string)jsr["country"];
            jrop.CountryCode = (string)jsr["countryCode"];
            jrop.As = (string)jsr["as"];
            jrop.Org = (string)jsr["org"];
            jrop.Isp = (string)jsr["isp"];
            jrop.Timezone = (string)jsr["timezone"];
            jrop.City = (string)jsr["city"];
            jrop.Query = (string)jsr["query"];
            jrop.Asname = (string)jsr["asname"];
            jrop.Reverse = (string)jsr["reverse"];
            jrop.District = (string)jsr["district"];
            jrop.Mobile = (bool)jsr["mobile"];
            jrop.Hosting = (bool)jsr["hosting"];
            jrop.Proxy = (bool)jsr["proxy"];
            jrop.RegionName = (string)jsr["regionName"];
            jrop.Continent = (string)jsr["continent"];
            jrop.ContinentCode = (string)jsr["continentCode"];
            jrop.Offset = (int)jsr["offset"];
            jrop.JObject = jsr;
            jrop.Raw = response;
            return jrop;
        }
    }
}
