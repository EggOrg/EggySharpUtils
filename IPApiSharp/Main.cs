﻿using System;
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
        public struct IPStr
        {
            public string Lat { get; set; }
            public string Long { get; set; }
            public string Timezone { get; set; }
            public string Zip { get; set; }
            public string Isp { get; set; }
            public string CountryCode { get; set; }
            public string City { get; set; }
            public string Country { get; set; }
            public string Status { get; set; }
            public string As { get; set; }
            public string Org { get; set; }
            public string Query { get; set; }
            public string Asname { get; set; }
            public string Reverse { get; set; }
            public string District { get; set; }
            public string Mobile { get; set; }
            public string Hosting { get; set; }
            public string Proxy { get; set; }
            public string RegionName { get; set; }
            public string Continent { get; set; }
            public string ContinentCode { get; set; }
        }
    }
    public class API
    {
        public static async Task<Str.IPStr> Get(string source)
        {
            HttpClient cl = new HttpClient();
            string response = await cl.GetStringAsync(new Uri($"http://ip-api.com/json/{source}?fields=66846719"));
            JObject jsr = new JObject();
            jsr = JObject.Parse(response);
            Str.IPStr jrop = new Str.IPStr();
            jrop.Lat = (string)jsr["lat"];
            jrop.Long = (string)jsr["lon"];
            jrop.Zip = (string)jsr["zip"];
            jrop.Status = (string)jsr["status"];
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
            jrop.Mobile = (string)jsr["mobile"];
            jrop.Hosting = (string)jsr["hosting"];
            jrop.Proxy = (string)jsr["proxy"];
            jrop.RegionName = (string)jsr["regionName"];
            jrop.Continent = (string)jsr["continent"];
            jrop.ContinentCode = (string)jsr["continentCode"];
            return jrop;
        }
    }
}