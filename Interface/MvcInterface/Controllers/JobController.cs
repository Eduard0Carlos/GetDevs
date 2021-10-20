using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MvcInterface.Models;
using MvcInterface.Models.Announcement;
using MvcInterface.Models.Company;
using MvcInterface.Shared;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MVCUserInterface.Controllers
{
    public class JobController : Controller
    {
        private readonly ILogger<JobController> _logger;

        public JobController(ILogger<JobController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            if (!User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "SignIn");

            if (User.IsInRole("company"))
                RedirectToAction("Company", "Job");

            return View();
        }

        public async Task<IActionResult> Company()
        {
            var response = await new HttpClient().GetAsync($"{Api.URL}/announcement?email={User.Identity.Name}");
            var companyResponse = await new HttpClient().GetAsync($"{Api.URL}/company?email={User.Identity.Name}");

            if (!response.IsSuccessStatusCode || !response.IsSuccessStatusCode)
                return RedirectToAction("Index", "Home");

            var responseString = await response.Content.ReadAsStringAsync();
            var companyResponseString = await companyResponse.Content.ReadAsStringAsync();
            var announcementList = JsonConvert.DeserializeObject<List<AnnouncementViewModel>>(responseString);
            var company = JsonConvert.DeserializeObject<CompanyViewModel>(companyResponseString);

            ViewBag.Company = company;

            return View(announcementList);
        }

        public IActionResult Create()
        {
            return View();
        }
    }
}