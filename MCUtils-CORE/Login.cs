using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MCUtils
{
    /// <summary>
    /// Works with the MCObject class.
    /// </summary>
    static class Obj
    {
        /// <summary>
        /// Converts an MCNAME to an MCObject.
        /// </summary>
        /// <param name="username">The MCNAME</param>
        /// <returns>MCObject</returns>
        public static async Task<Hookins.MCObject> ToMCObject(this Hookins.MCNAME username)
        {
            HttpClient cl = new HttpClient();
            string response = await cl.GetStringAsync($"api.mojang.com/users/profiles/minecraft/{username}");
            Hookins.MCObject jrop = JsonConvert.DeserializeObject<Hookins.MCObject>(response);
            return jrop;
        }
    }
}
