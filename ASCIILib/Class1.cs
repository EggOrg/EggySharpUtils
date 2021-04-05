using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ASCIILib
{
    public class Artii
    {
        public async Task<string> Get(string txt)
        {
            return await new HttpClient().GetStringAsync($"https://artii.herokuapp.com/make?text={txt.Replace(' ', '+')}");
        }
    }
}
