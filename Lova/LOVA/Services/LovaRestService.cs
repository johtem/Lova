using LOVA.Models;
using LOVA.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        public async Task SaveIssueReportAsync(IssueReport item, bool isNewItem = true)
        {
            try
            {
                var json = JsonConvert.SerializeObject(item);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = null;
                if (isNewItem)
                {
                    response = await client.PostAsync("/api/IssueReports", content);
                }
                else
                {
                    response = await client.PutAsync("/api/IssueReports", content);
                }

                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine(@"\tIssueReport succesfully saved");
                }
            } catch (Exception ex)
            {
                Debug.WriteLine(@"\tError {0}", ex.Message);
            }
        }
    }
}