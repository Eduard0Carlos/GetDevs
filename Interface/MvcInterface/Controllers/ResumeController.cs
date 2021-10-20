using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MvcInterface.Models;
using MvcInterface.Shared;
using Newtonsoft.Json;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MVCUserInterface.Controllers
{
    public class ResumeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public ResumeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet("Resume")]
        public async Task<IActionResult> Index()
        {
            if (!User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "SignIn");

            var response = await new HttpClient().GetAsync($"{Api.URL}/resume?email={User.Identity.Name}");

            if (!response.IsSuccessStatusCode)
                return View();

            var responseString = await response.Content.ReadAsStringAsync();
            var resumeObject = JsonConvert.DeserializeObject<ResumeViewModel>(responseString);
            return View(resumeObject);
        }

        [HttpPost("Resume")]
        public async Task<IActionResult> Index(ResumeEditViewModel viewModel)
        {
            var json = JsonConvert.SerializeObject(viewModel.ConvertToResumeViewModel(User.Identity.Name));
            var candidateJson = JsonConvert.SerializeObject(viewModel.ConvertToCandidateViewModel(User.Identity.Name));
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var candidateData = new StringContent(candidateJson, Encoding.UTF8, "application/json");

            using var client = new HttpClient();
            var response = await client.PostAsync($"{Api.URL}/resume", data);
            var candidateResponse = await client.PutAsync($"{Api.URL}/candidate", candidateData);

            return RedirectToAction("Index", "Profile");
        }
    }
}