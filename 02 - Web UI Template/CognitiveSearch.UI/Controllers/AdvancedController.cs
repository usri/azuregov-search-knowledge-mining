using CognitiveSearch.UI.CognitiveSearchApi;
using CognitiveSearch.UI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;

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

        public IActionResult Synonyms()
        {
            var viewModel = new SynonymMapsViewModel
            {
                SynonymMapList = GetSynonymMapList()
            };

            return View(viewModel);
        }

        public IActionResult NewSynonymMap()
        {
            var synonymMap = new SynonymMap();

            return View("CreateSynonymMap", synonymMap);
        }

        public IActionResult CreateSynonymMap(SynonymMap synonymMap)
        {
            InitializeApiClient();

            var searchApiResponse = _apiClient.CreateSynonymMap(synonymMap).Result;

            if (searchApiResponse.IsSuccessStatusCode)
            {
                return RedirectToAction("Synonyms");
            }
            else
            {
                ErrorViewModel error = new ErrorViewModel
                {
                    ErrorMessage = searchApiResponse.Content
                };

                return RedirectToAction("SearchApiResponseError", "Home",  error);
            }

        }

        public IActionResult MakeActiveSynonymMap(string name)
        {
            InitializeApiClient();

            var searchApiResponse = _apiClient.UpdateIndexSynonymMap(name, false).Result;

            if (searchApiResponse.IsSuccessStatusCode)
            {
                return RedirectToAction("Synonyms");
            }
            else
            {
                ErrorViewModel error = new ErrorViewModel
                {
                    ErrorMessage = searchApiResponse.Content
                };

                return RedirectToAction("SearchApiResponseError", "Home", error);
            }
        }

        public IActionResult EditSynonymMap(string name)
        {
            InitializeApiClient();

            var synonymMap = _apiClient.GetSynonymMap(name).Result;

            return View(synonymMap);
        }

        public IActionResult DeleteSynonymMap(string name)
        {
            InitializeApiClient();

            var searchApiResponse = _apiClient.DeleteSynonymMap(name).Result;


            if (searchApiResponse.IsSuccessStatusCode)
            {
                return RedirectToAction("Synonyms");
            }
            else
            {
                ErrorViewModel error = new ErrorViewModel
                {
                    ErrorMessage = searchApiResponse.Content
                };

                return RedirectToAction("SearchApiResponseError", "Home", error);
            }
        }

        public IActionResult UpdateSynonymMap(SynonymMap synonymMap)
        {
            InitializeApiClient();

            var searchApiResponse = _apiClient.UpdateSynonymMap(synonymMap).Result;

            if (searchApiResponse.IsSuccessStatusCode)
            {
                return RedirectToAction("Synonyms");
            }
            else
            {
                ErrorViewModel error = new ErrorViewModel
                {
                    ErrorMessage = searchApiResponse.Content
                };

                return RedirectToAction("SearchApiResponseError", "Home", error);
            }

        }

        public SynonymMapList GetSynonymMapList()
        {
            InitializeApiClient();

            return _apiClient.GetSynonymMaps().Result;           
        }
    }
}
