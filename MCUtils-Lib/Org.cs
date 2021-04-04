using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
        /// An MCPlayerOBJECT to store data about a user (UUID, name).
        /// </summary>
        public class MCPlayerObject
        {
            public string id { get; set; }
            public string name { get; set; }
        }

        /// <summary>
        /// MCServiceObject to store data about Minecraft servers.
        /// </summary>
        public class MCServiceObject
        {
            public string mcweb { get; set; }
            public string mcsession { get; set; }
            public string mcacc { get; set; }
            public string mcauth { get; set; }
            public string mcskins { get; set; }
            public string mcauthserver { get; set; }
            public string mcsessionserver { get; set; }
            public string mcapi { get; set; }
            public string mctextures { get; set; }
            public string mcmojangweb { get; set; }
        }
    }
    public static class Convert
    {
        /// <summary>
        /// Converts an MCNAME to an MCObject.
        /// </summary>
        /// <param name="username">The MCNAME</param>
        /// <returns>MCObject</returns>
        public static async Task<Hookins.MCPlayerObject> GetMCPlayerObject(Hookins.MCNAME username)
        {
            HttpClient cl = new HttpClient();
            string response = await cl.GetStringAsync(new Uri($"https://api.mojang.com/users/profiles/minecraft/{username.NAME}"));
            JObject jsr = JObject.Parse(response);
            Hookins.MCPlayerObject jrop = new Hookins.MCPlayerObject();
            jrop.id = (string)jsr["id"];
            jrop.name = (string)jsr["name"];
            return jrop;
        }

        public static async Task<Hookins.MCServiceObject> GetMCServiceObject()
        {
            HttpClient cl = new HttpClient();
            string response = await cl.GetStringAsync(new Uri($"https://status.mojang.com/check"));
            JObject jsr = JObject.Parse(response);
            Hookins.MCServiceObject jrop = new Hookins.MCServiceObject();
            jrop.mcweb = (string)jsr["minecraft.net"];
            jrop.mcsession = (string)jsr["session.minecraft.net"];
            jrop.mcacc = (string)jsr["account.mojang.com"];
            jrop.mcauth = (string)jsr["auth.mojang.com"];
            jrop.mcskins = (string)jsr["skins.minecraft.net"];
            jrop.mcauthserver = (string)jsr["authserver.mojang.com"];
            jrop.mcsessionserver = (string)jsr["sessionserver.mojang.com"];
            jrop.mcapi = (string)jsr["api.mojang.com"];
            jrop.mctextures = (string)jsr["textures.minecraft.net"];
            jrop.mcmojangweb = (string)jsr["mojang.com"];
            return jrop;
        }
    }
}
