using LOVA.Models;
using LOVA.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace LOVA.Services
{
    public class LovaRestService 
    {
        HttpClient client;

        public List<IssueReport> Items { get; private set; }

        public LovaRestService()
        {
            client = new HttpClient
            {
                BaseAddress = new Uri("https://lovaapi.azurewebsites.net")
            };

            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<List<IssueReport>> GetAllIssues()
        {
            Items = new List<IssueReport>();
            
            var response = await client.GetStringAsync("/api/IssueReports");

           Items = JsonConvert.DeserializeObject<List<IssueReport>>(response);

            return Items;
        }
    }
}