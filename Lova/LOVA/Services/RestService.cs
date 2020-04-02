using LOVA.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace LOVA.Services
{
    public class RestService
    {

        private readonly HttpClient client;

        public RestService()
        {
            client = new HttpClient
            {
                BaseAddress = new Uri("https://swapi.co/api/")
            };
        }

        public async Task<Starwars> GetStarwars()
        {
            var response = await client.GetStringAsync("people");

            var starwars = JsonConvert.DeserializeObject<Starwars>(response);

            return starwars;
        }
    }
}
