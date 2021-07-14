using CognitiveSearch.UI.CognitiveSearchApi;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CognitiveSearch.UI
{
    public class CognitiveSearchApiClient
    {
        private IConfiguration _configuration { get; set; }
        private string apiKey { get; set; }
        private string apiBaseURL { get; set; }
        private string apiVersion { get; set; }
        private HttpClient httpClient { get; set; }

        public CognitiveSearchApiClient(IConfiguration configuration)
        {
            try
            {
                _configuration = configuration;
                apiKey = configuration.GetSection("SearchApiKey")?.Value;
                apiBaseURL = configuration.GetSection("SearchApiBaseURL").Value;
                apiVersion = configuration.GetSection("SearchApiVersion").Value;
                httpClient = new HttpClient
                {
                    BaseAddress = new Uri(apiBaseURL),
                };

                httpClient.DefaultRequestHeaders.Add("api-key", apiKey);
                
                

            }
            catch (Exception e)
            {
                // If you get an exception here, most likely you have not set your
                // credentials correctly in appsettings.json
                throw new ArgumentException(e.Message.ToString());
            }
        }

        public async Task<List<SynonymMap>> ListSynonymMaps()
        {
            var requestUri = $"/synonymmaps?api-version={apiVersion}";

            HttpResponseMessage response = await httpClient.GetAsync(requestUri);

            if (response != null)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                return System.Text.Json.JsonSerializer.Deserialize<List<SynonymMap>>(jsonString);
            }

            return null;
        }

        public async Task<string> CreateSynonymMap(string name, string format, string synonyms, string encryptionKey)
        {
            //PUT https://[service name].search.windows.net/synonymmaps/[synonymmap name]?api-version=[api-version]  

            var putRequestUri = $"/synonymmaps/{name}/?api-version={apiVersion}";

            var requestUri = $"/synonymmaps?api-version={apiVersion}";

            var synonymMap = new SynonymMap
            {
                name = name,
                format = format,
                synonyms = synonyms,
                encryptionKey = encryptionKey
            };

            string body = JsonConvert.SerializeObject(synonymMap);

            var content = new StringContent(body, Encoding.UTF8, "application/json");
            try
            {
                //HttpResponseMessage response = await httpClient.PostAsync(requestUri, content);


                HttpResponseMessage response = await httpClient.PutAsync(putRequestUri, content);



                //response.EnsureSuccessStatusCode();

                string responseBody = await response.Content.ReadAsStringAsync();

                return responseBody;
            }
            catch(Exception ex)
            {
                var err = ex.Message;
                return null;
            }
           

        }

        public void GetSynonymMap(string synonymMapName)
        {

        }
       
    }
}
