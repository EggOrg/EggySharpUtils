using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Imaging;
using System.Drawing;
using System.IO;

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
    public static class Get
    {
        /// <summary>
        /// Converts an MCNAME to an MCObject.
        /// </summary>
        /// <param name="username">The MCNAME</param>
        /// <returns>MCObject</returns>
        public static async Task<Hookins.MCPlayerObject> GetMCPlayerObject(this Hookins.MCNAME username)
        {
            HttpClient cl = new HttpClient();
            string response = await cl.GetStringAsync(new Uri($"https://api.mojang.com/users/profiles/minecraft/{username.NAME}"));
            JObject jsr = new JObject();
            Hookins.MCPlayerObject jrop = new Hookins.MCPlayerObject();
            try
            {
                jsr = JObject.Parse(response);
                jrop.id = (string)jsr["id"];
                jrop.name = (string)jsr["name"];
            }
            catch (JsonReaderException er)
            {
                throw new Exceptions.MojangParserExc($"An error has occurred while parsing MCPlayerObject information with Newtonsoft.JSON: {er.Message}. This may have been caused by an invalid username.");
            }
            if (!string.IsNullOrEmpty((string)jsr["error"]))
            {
                throw new Exceptions.MojangErrorExc($"An error has occurred while fetching MCPlayerObject information: {(string)jsr["error"]}");
            }
            return jrop;
        }

        public static async Task<Hookins.MCServiceObject> GetMCServiceObject()
        {
            HttpClient cl = new HttpClient();
            string response = await cl.GetStringAsync(new Uri($"https://status.mojang.com/check"));
            Hookins.MCServiceObject jrop = new Hookins.MCServiceObject();
            JObject jsr = new JObject();
            try
            {
                jsr = JObject.Parse(response);
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
            }
            catch (JsonReaderException er)
            {
                throw new Exceptions.MojangParserExc($"An error has occurred while parsing MCServiceObject information with Newtonsoft.JSON: {er.Message}. This may have been caused by an invalid request.");
            }
            
            return jrop;
        }
    }
    public static class Services
    {
        public static class Imaging
        {
            public static Image Crafatar(Hookins.MCPlayerObject mp, Enums.CrafatarImagingStyles st)
            {
                WebClient wc = new WebClient();
                byte[] av = { };
                if (st == Enums.CrafatarImagingStyles.avatar)
                {
                    av = wc.DownloadData($"https://crafatar.com/avatars/{mp.id}");
                }
                else if (st == Enums.CrafatarImagingStyles.body)
                {
                    av = wc.DownloadData($"https://crafatar.com/renders/body/{mp.id}");
                }
                else if (st == Enums.CrafatarImagingStyles.head)
                {
                    av = wc.DownloadData($"https://crafatar.com/renders/head/{mp.id}");
                }
                else if (st == Enums.CrafatarImagingStyles.skin)
                {
                    av = wc.DownloadData($"https://crafatar.com/skins/{mp.id}");
                }
                else if (st == Enums.CrafatarImagingStyles.cape)
                {
                    av = wc.DownloadData($"https://crafatar.com/capes/{mp.id}");
                }
                MemoryStream ms = new MemoryStream(av);
                System.Drawing.Image ig = System.Drawing.Image.FromStream(ms);
                return ig;
            }
            public static Image Minotar(Hookins.MCPlayerObject mp, Enums.MinotarImagingStyles st)
            {
                WebClient wc = new WebClient();
                byte[] av = { };
                if (st == Enums.MinotarImagingStyles.avatar)
                {
                    av = wc.DownloadData($"https://minotar.net/helm/{mp.name}/100.png");
                }
                else if (st == Enums.MinotarImagingStyles.body)
                {
                    av = wc.DownloadData($"https://minotar.net/armor/body/{mp.name}/100.png");
                }
                else if (st == Enums.MinotarImagingStyles.bust)
                {
                    av = wc.DownloadData($"https://minotar.net/armor/bust/{mp.name}/100.png");
                }
                else if (st == Enums.MinotarImagingStyles.cube)
                {
                    av = wc.DownloadData($"https://minotar.net/cube/{mp.name}/100.png");
                }
                else if (st == Enums.MinotarImagingStyles.skin)
                {
                    av = wc.DownloadData($"https://minotar.net/skin/{mp.name}");
                }
                MemoryStream ms = new MemoryStream(av);
                System.Drawing.Image ig = System.Drawing.Image.FromStream(ms);
                return ig;
            }
            public static class Enums
            {
                public enum CrafatarImagingStyles
                {
                    avatar,
                    body,
                    head,
                    skin,
                    cape
                }
                public enum MinotarImagingStyles
                {
                    avatar,
                    cube,
                    body,
                    bust,
                    skin
                }
            }
        }
    }
    public class Exceptions
    {
        [Serializable]
        public class MojangErrorExc : Exception
        {
            public MojangErrorExc() : base() { }
            public MojangErrorExc(string message) : base(message) { }
            public MojangErrorExc(string message, Exception inner) : base(message, inner) { }
            protected MojangErrorExc(System.Runtime.Serialization.SerializationInfo info,
                System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
        }
        [Serializable]
        public class MojangParserExc : Exception
        {
            public MojangParserExc() : base() { }
            public MojangParserExc(string message) : base(message) { }
            public MojangParserExc(string message, Exception inner) : base(message, inner) { }
            protected MojangParserExc(System.Runtime.Serialization.SerializationInfo info,
                System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
        }
    }
}
