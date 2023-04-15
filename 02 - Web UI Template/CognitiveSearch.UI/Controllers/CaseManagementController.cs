using Microsoft.AspNetCore.Mvc;

namespace CognitiveSearch.UI.Controllers
{
    public class CaseManagementController : Controller
    {
        public IActionResult Index()
        {
            //Show Cases
            return View();

        }
    }
}
