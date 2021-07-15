using CognitiveSearch.UI.CognitiveSearchApi;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CognitiveSearch.UI
{
    public class CognitiveSearchApiClient
    {
        private IConfiguration _configuration { get; set; }
        private string _apiKey { get; set; }
        private string _apiBaseURL { get; set; }
        private string _apiVersion { get; set; }
        private string _indexName { get; set; }
        private HttpClient _httpClient { get; set; }

        public CognitiveSearchApiClient(IConfiguration configuration)
        {
            try
            {
                _configuration = configuration;
                _apiKey = configuration.GetSection("SearchApiKey")?.Value;
                _apiBaseURL = configuration.GetSection("SearchApiBaseURL").Value;
                _apiVersion = configuration.GetSection("SearchApiVersion").Value;
                _indexName = configuration.GetSection("SearchIndexName").Value;

                _httpClient = new HttpClient
                {
                    BaseAddress = new Uri(_apiBaseURL),
                };

                _httpClient.DefaultRequestHeaders.Add("api-key", _apiKey);
                
                

            }
            catch (Exception e)
            {
                // If you get an exception here, most likely you have not set your
                // credentials correctly in appsettings.json
                throw new ArgumentException(e.Message.ToString());
            }
        }

       
        public async Task<SynonymMapList> GetSynonymMaps()
        {
            var requestUri = $"/synonymmaps?api-version={_apiVersion}";

            HttpResponseMessage response = await _httpClient.GetAsync(requestUri);

            if (response != null)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                try
                {
                    return System.Text.Json.JsonSerializer.Deserialize<SynonymMapList>(jsonString);
                }
                catch(Exception ex)
                {
                    var err = ex.Message;
                }
               
            }

            return null;
        }

        public async Task<SynonymMap> GetSynonymMap(string synonymMapName)
        {
            var requestUri = $"/synonymmaps/{synonymMapName}?api-version={_apiVersion}";

            HttpResponseMessage response = await _httpClient.GetAsync(requestUri);

            if (response != null)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                try
                {
                    return System.Text.Json.JsonSerializer.Deserialize<SynonymMap>(jsonString);
                }
                catch (Exception ex)
                {
                    var err = ex.Message;
                }

            }

            return null;
        }

        public async Task<string> CreateSynonymMap(SynonymMap synonymMap)
        {
            var requestUri = $"/synonymmaps/?api-version={_apiVersion}";

            string body = JsonConvert.SerializeObject(synonymMap);

            var content = new StringContent(body, Encoding.UTF8, "application/json");
            try
            {
                HttpResponseMessage response = await _httpClient.PostAsync(requestUri, content);

                if (response.IsSuccessStatusCode)
                {
                    UpdateIndexSynonymMap(synonymMap.name, false);

                    return "success";
                }
                else
                {
                    return "failed";
                }

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public async Task<string> UpdateSynonymMap(SynonymMap synonymMap)
        {
            var requestUri = $"/synonymmaps/{synonymMap.name}/?api-version={_apiVersion}";

            string body = JsonConvert.SerializeObject(synonymMap);

            var content = new StringContent(body, Encoding.UTF8, "application/json");
            try
            {
                HttpResponseMessage response = await _httpClient.PutAsync(requestUri, content);

                if (response.IsSuccessStatusCode)
                {
                    UpdateIndexSynonymMap(synonymMap.name, false);

                    return "success";
                }
                else
                {
                    return "failed";
                }

            }
            catch(Exception ex)
            {
                return ex.Message;
            }
        }

        public async Task<string> DeleteSynonymMap(string name)
        {
            var requestUri = $"/synonymmaps/{name}/?api-version={_apiVersion}";

            try
            {
                HttpResponseMessage response = await _httpClient.DeleteAsync(requestUri);

                if (response.IsSuccessStatusCode)
                {
                    UpdateIndexSynonymMap(name, true);

                    return "success";
                }
                else
                {
                    return "failed";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public async Task<SearchIndex> GetIndex(string indexName)
        {
            var requestUri = $"/indexes/{indexName}?api-version={_apiVersion}";

            HttpResponseMessage response = await _httpClient.GetAsync(requestUri);

            if (response != null)
            {
                try
                {
                    var jsonString = await response.Content.ReadAsStringAsync();
                    return System.Text.Json.JsonSerializer.Deserialize<SearchIndex>(jsonString);
                }
                catch (Exception ex)
                {
                    var err = ex.Message;
                }

            }

            return null;
        }

        public async Task<SearchIndex> UpdateIndex(SearchIndex index)
        {
            var requestUri = $"/indexes/{index.name}?api-version={_apiVersion}";

            string body = JsonConvert.SerializeObject(index);

            var content = new StringContent(body, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _httpClient.PutAsync(requestUri, content);

            if (response != null)
            {
                try
                {
                    var jsonString = await response.Content.ReadAsStringAsync();
                    return System.Text.Json.JsonSerializer.Deserialize<SearchIndex>(jsonString);
                }
                catch (Exception ex)
                {
                    var err = ex.Message;
                }

            }

            return null;
        }

        private bool UpdateIndexSynonymMap(string synonymMapName, bool isDeleted)
        {
            bool success = false;

            var index = GetIndex(_indexName).Result;

            foreach(Field field in index.fields)
            {
                if(field.name == "content")
                {
                    if (!isDeleted)
                    {
                        field.synonymMaps = new string[] { synonymMapName };
                    }
                    else
                    {
                        field.synonymMaps = new string[] { };
                    }
                    
                }
            }

            var updatedIndex = UpdateIndex(index).Result;

            return success;
        }

    }
}
