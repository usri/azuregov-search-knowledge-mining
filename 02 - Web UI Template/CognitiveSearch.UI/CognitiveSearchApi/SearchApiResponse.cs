using System.Net;

namespace CognitiveSearch.UI.CognitiveSearchApi
{
    public class SearchApiResponse
    {
        public bool IsSuccessStatusCode { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public string Content { get; set; }
    }
}
