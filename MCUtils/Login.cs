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
    class UUID
    {
        public async Task<string> UserToUUIDAsync(string username)
        {
            HttpClient cl = new HttpClient();
            string response = await cl.GetStringAsync($"api.mojang.com/users/profiles/minecraft/{username}");
            Hookins.MCJSON jrop = JsonConvert.DeserializeObject<Hookins.MCJSON>(response);
            return jrop.uuid;
        }
    }
}
