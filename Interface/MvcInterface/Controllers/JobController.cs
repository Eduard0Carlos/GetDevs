using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MvcInterface.Models;
using MvcInterface.Models.Announcement;
using MvcInterface.Models.Company;
using MvcInterface.Shared;
using Newtonsoft.Json;
using System;
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

        public async Task<IActionResult> Index()
        {
            if (!User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "SignIn");

            if (User.IsInRole("company"))
                return RedirectToAction("Company", "Job");

            var response = await new HttpClient().GetAsync($"{Api.URL}/announcement?email={User.Identity.Name}");

            if (!response.IsSuccessStatusCode)
                return RedirectToAction("Index", "Home");

            var responseString = await response.Content.ReadAsStringAsync();
            try
            {
                var announcementList = JsonConvert.DeserializeObject<List<CandidateAnnouncementViewModel>>(responseString);
                if (announcementList != null)
                    return View(announcementList);
            }
            catch (Exception)
            {
                return View();
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(int id)
        {
            var json = JsonConvert.SerializeObject(new { Email = User.Identity.Name, AnnouncementId = id });
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var registerResponse = await new HttpClient().PostAsync($"{Api.URL}/candidate/job/register", data);

            return RedirectToAction("Index");
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

        public async Task<IActionResult> ViewMore(string id)
        {
            var response = await new HttpClient().GetAsync($"{Api.URL}/candidate?id={id}");

            var json = JsonConvert.SerializeObject(new { Id = id });
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            await new HttpClient().PostAsync($"{Api.URL}/announcement/findevs", data);

            if (!response.IsSuccessStatusCode || !response.IsSuccessStatusCode)
                return View();

            var responseString = await response.Content.ReadAsStringAsync();
            var candidateList = JsonConvert.DeserializeObject<List<CandidateViewModel>>(responseString);

            return View(candidateList);
        }

        [HttpPost]
        public async Task<IActionResult> Company(string id)
        {
            var json = JsonConvert.SerializeObject(new { Id = id});
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            
            await new HttpClient().PostAsync($"{Api.URL}/announcement/findevs", data);
            return RedirectToAction("ViewMore", "Job", new { id = id });
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(AnnouncementRegisterViewModel registerModel)
        {
            registerModel.Email = User.Identity.Name;
            registerModel.AnnouncementDate = DateTime.Now;
            var json = JsonConvert.SerializeObject(registerModel);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            using var client = new HttpClient();
            var response = await client.PostAsync($"{Api.URL}/announcement", data);

            if (!response.IsSuccessStatusCode)
                return View();

            return RedirectToAction("Index", "Job");
        }
    }
}