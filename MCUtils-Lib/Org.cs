using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MCUtils
{
    /// <summary>
    /// Hookins used by McUtils.
    /// </summary>
    public static class Hookins
    {
        /// <summary>
        /// An MCUUID to represent a UUID.
        /// </summary>
        public struct MCUUID
        {
            public string UUID { get; set; }
            public MCUUID(string uuid)
            {
                UUID = uuid;
            }
        }
        /// <summary>
        /// An MCNAME to represent a name.
        /// </summary>
        public struct MCNAME
        {
            public string NAME { get; set; }
            public MCNAME(string name)
            {
                NAME = name;
            }
        }
        
        /// <summary>
        /// An MCOBJECT to store data about a user (UUID, name).
        /// </summary>
        public class MCObject
        {
            public string id { get; set; }
            public string name { get; set; }
        }
    }
    public static class Convert
    {
        /// <summary>
        /// Converts an MCNAME to an MCObject.
        /// </summary>
        /// <param name="username">The MCNAME</param>
        /// <returns>MCObject</returns>
        public static async Task<Hookins.MCObject> ToMCObject(Hookins.MCNAME username)
        {
            HttpClient cl = new HttpClient();
            string response = await cl.GetStringAsync($"https://api.mojang.com/users/profiles/minecraft/{username}");
            Hookins.MCObject jrop = JsonConvert.DeserializeObject<Hookins.MCObject>(response);
            return jrop;
        }
    }
}
