using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CognitiveSearch.UI.Controllers
{
    public class AdvancedController : Controller
    {
        private IConfiguration _configuration { get; set; }
        private CognitiveSearchApiClient _apiClient { get; set; }
        private string _configurationError { get; set; }

        public AdvancedController(IConfiguration configuration)
        {
            _configuration = configuration;
            InitializeApiClient();
        }

        private void InitializeApiClient()
        {
            try
            {
                _apiClient = new CognitiveSearchApiClient(_configuration);
            }
            catch (Exception e)
            {
                _configurationError = $"The application settings are possibly incorrect. The server responded with this message: " + e.Message.ToString();
            }
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Synonyms()
        {
            InitializeApiClient();

            var test = _apiClient.ListSynonymMaps();
            return View();
        }

        public IActionResult CreateSynonymMap(string name, string format, string synonyms, string encryptionKey)
        {
            InitializeApiClient();

            name = "usa-synonyms333445";
            format = "solr";
            synonyms = "United States of America, U.S.A., America, EEUU, USA";
            var responseString = _apiClient.CreateSynonymMap(name, format, synonyms, encryptionKey);

            return RedirectToAction("Synonyms");
        }
    }
}
