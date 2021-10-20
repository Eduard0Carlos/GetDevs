using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MvcInterface.Models;
using MvcInterface.Shared;
using Newtonsoft.Json;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace MVCUserInterface.Controllers
{
    public class ProfileController : Controller
    {
        private readonly ILogger<CompanyController> _logger;

        public ProfileController(ILogger<CompanyController> logger)
        {
            _logger = logger;
        }

        [HttpGet("Profile")]
        public IActionResult Index()
        {
            if (!User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "SignIn");

            if (User.IsInRole("candidate"))
                return Redirect($"profile/{User.Identity.Name}");
            else
                return Redirect($"company/{User.Identity.Name}");
        }

        [HttpGet("Profile/{profileName}")]
        public async Task<IActionResult> Index(string profileName)
        {
            var response = await new HttpClient().GetAsync($"{Api.URL}/candidate?email={profileName}");
            var resumeResponse = await new HttpClient().GetAsync($"{Api.URL}/resume?email={profileName}");

            if (!response.IsSuccessStatusCode)
                return RedirectToAction("Index", "Home");

            var responseString = await response.Content.ReadAsStringAsync();
            var resumeResponseString = await resumeResponse.Content.ReadAsStringAsync();
            var candidateObject = System.Text.Json.JsonSerializer.Deserialize<CandidateViewModel>(responseString);
            var resumeObject = JsonConvert.DeserializeObject<ResumeViewModel>(resumeResponseString);

            ViewBag.ProfileName = profileName;
            ViewBag.Resume = resumeObject;

            return View(candidateObject);
        }
    }
}