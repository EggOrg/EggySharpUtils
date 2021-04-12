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
        /// An MCPlayerOBJECT to store data about a user (UUID, name).
        /// </summary>
        public class MCPlayerObject
        {
            public string id { get; set; }
            public string name { get; set; }
        }
    }
    public static class Get
    {
        /// <summary>
        /// Converts an MCNAME to an MCObject.
        /// </summary>
        /// <param name="username">The username of the player.</param>
        /// <returns>MCPlayerObject</returns>
        public static async Task<Hookins.MCPlayerObject> GetMCPlayerObject(this string username)
        {
            HttpClient cl = new HttpClient();
            string response = await cl.GetStringAsync(new Uri($"https://api.mojang.com/users/profiles/minecraft/{username}"));
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
    }
    public static class Services
    {
        public static class Skins
        {
            /// <summary>
            /// Gets a skin from the Crafatar API.
            /// </summary>
            /// <param name="mp">MCPlayerObject that stores data of the player.</param>
            /// <param name="st">The CrafatarSkinStyle to use.</param>
            /// <returns>An image of the player head from Crafatar.</returns>
            public static Image Crafatar(Hookins.MCPlayerObject mp, Enums.CrafatarSkinsStyles st)
            {
                WebClient wc = new WebClient();
                byte[] av = { };
                try
                {
                    if (st == Enums.CrafatarSkinsStyles.avatar)
                    {
                        av = wc.DownloadData($"https://crafatar.com/avatars/{mp.id}");
                    }
                    else if (st == Enums.CrafatarSkinsStyles.body)
                    {
                        av = wc.DownloadData($"https://crafatar.com/renders/body/{mp.id}");
                    }
                    else if (st == Enums.CrafatarSkinsStyles.head)
                    {
                        av = wc.DownloadData($"https://crafatar.com/renders/head/{mp.id}");
                    }
                    else if (st == Enums.CrafatarSkinsStyles.skin)
                    {
                        av = wc.DownloadData($"https://crafatar.com/skins/{mp.id}");
                    }
                    else if (st == Enums.CrafatarSkinsStyles.cape)
                    {
                        av = wc.DownloadData($"https://crafatar.com/capes/{mp.id}");
                    }
                }
                catch (WebException er)
                {
                    throw new Exceptions.SkinGrabberExc($"An error has occurred while grabbing a skin from Crafatar API: {er.Message}. You may have been request-limited, or this username doesn't exist.");
                }
                MemoryStream ms = new MemoryStream(av);
                System.Drawing.Image ig = System.Drawing.Image.FromStream(ms);
                return ig;
            }
            /// <summary>
            /// Gets a skin from the Minotar API.
            /// </summary>
            /// <param name="mp">MCPlayerObject that stores data of the player.</param>
            /// <param name="st">The MinotarSkinStyle to use.</param>
            /// <returns></returns>
            public static Image Minotar(Hookins.MCPlayerObject mp, Enums.MinotarSkinsStyles st)
            {
                WebClient wc = new WebClient();
                byte[] av = { };
                try
                {
                    if (st == Enums.MinotarSkinsStyles.avatar)
                    {
                        av = wc.DownloadData($"https://minotar.net/helm/{mp.name}/100.png");
                    }
                    else if (st == Enums.MinotarSkinsStyles.body)
                    {
                        av = wc.DownloadData($"https://minotar.net/armor/body/{mp.name}/100.png");
                    }
                    else if (st == Enums.MinotarSkinsStyles.bust)
                    {
                        av = wc.DownloadData($"https://minotar.net/armor/bust/{mp.name}/100.png");
                    }
                    else if (st == Enums.MinotarSkinsStyles.cube)
                    {
                        av = wc.DownloadData($"https://minotar.net/cube/{mp.name}/100.png");
                    }
                    else if (st == Enums.MinotarSkinsStyles.skin)
                    {
                        av = wc.DownloadData($"https://minotar.net/skin/{mp.name}");
                    }
                }
                catch (WebException er)
                {
                    throw new Exceptions.SkinGrabberExc($"An error has occurred while grabbing a skin from Minotar API: {er.Message}. You may have been request-limited, or this username doesn't exist.");
                }
                MemoryStream ms = new MemoryStream(av);
                System.Drawing.Image ig = System.Drawing.Image.FromStream(ms);
                return ig;
            }
        }
        public static class Enums
        {
            public enum CrafatarSkinsStyles
            {
                avatar,
                body,
                head,
                skin,
                cape
            }
            public enum MinotarSkinsStyles
            {
                avatar,
                cube,
                body,
                bust,
                skin
            }
            public enum CapeServiceProvider
            {
                optifine,
                minecraftcapes,
                fivezig,
                mcheads
            }
        }
        public static class Capes
        {
            public static Image GetCape(Hookins.MCPlayerObject mp, Enums.CapeServiceProvider cp)
            {
                WebClient wc = new WebClient();
                byte[] av = { };
                try
                {
                    if (cp == Enums.CapeServiceProvider.optifine)
                    {
                        av = wc.DownloadData($"http://s.optifine.net/capes/{mp.name}.png");
                    }
                    else if (cp == Enums.CapeServiceProvider.minecraftcapes)
                    {
                        av = wc.DownloadData($"https://www.minecraftcapes.co.uk/getCape.php?u={mp.name}");
                    }
                    else if (cp == Enums.CapeServiceProvider.fivezig)
                    {
                        av = wc.DownloadData($"http://textures.5zig.net/textures/2/{mp.id}");
                    }
                    else if (cp == Enums.CapeServiceProvider.mcheads)
                    {
                        av = wc.DownloadData($"https://mc-heads.net/cape/{mp.id}");
                    }
                }
                catch (WebException er)
                {
                    throw new Exceptions.CapeGrabberExc($"An error has occurred when grabbing a cape from {cp.ToString()}: {er.Message}. The user may not have a cape in this form.");
                }
                MemoryStream ms = new MemoryStream(av);
                System.Drawing.Image ig = System.Drawing.Image.FromStream(ms);
                return ig;
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
        [Serializable]
        public class SkinGrabberExc : Exception
        {
            public SkinGrabberExc() : base() { }
            public SkinGrabberExc(string message) : base(message) { }
            public SkinGrabberExc(string message, Exception inner) : base(message, inner) { }
            protected SkinGrabberExc(System.Runtime.Serialization.SerializationInfo info,
                System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
        }
        [Serializable]
        public class CapeGrabberExc : Exception
        {
            public CapeGrabberExc() : base() { }
            public CapeGrabberExc(string message) : base(message) { }
            public CapeGrabberExc(string message, Exception inner) : base(message, inner) { }
            protected CapeGrabberExc(System.Runtime.Serialization.SerializationInfo info,
                System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
        }
    }
}
