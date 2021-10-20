using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MvcInterface.Models;
using MvcInterface.Shared;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace MVCUserInterface.Controllers
{
    public class CompanyController : Controller
    {
        private readonly ILogger<CompanyController> _logger;

        public CompanyController(ILogger<CompanyController> logger)
        {
            _logger = logger;
        }

        [HttpGet("Company")]
        public IActionResult Index()
        {
            if (!User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "SignIn");

            return RedirectToAction("Index", "Home");
        }

        [HttpGet("Company/{profileName}")]
        public async Task<IActionResult> Index(string profileName)
        {
            var response = await new HttpClient().GetAsync($"{Api.URL}/company?companyName={profileName}");

            if (!response.IsSuccessStatusCode)
                return RedirectToAction("Index", "Home");

            var responseString = await response.Content.ReadAsStringAsync();
            var candidateObject = JsonSerializer.Deserialize<CandidateViewModel>(responseString);

            ViewBag.ProfileName = profileName;

            return View(candidateObject);
        }
    }
}
