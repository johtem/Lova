using LOVA.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace LOVA.Data
{
    public class RestService
    {
   

        public  async Task<Starwars> GetStarwars()
        {
            HttpClient client = new HttpClient(); ;

            var response = await client.GetStringAsync("https://swapi.co/api/people");

            var starwars = JsonConvert.DeserializeObject<Starwars>(response);

            return starwars;
        }
    }
}
