using Domain.Entities;
using Domain.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MVCUserInterface.Models;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using WebRankingML;
using WebRankingML.Utils;

namespace MVCUserInterface.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            Resume resume = new Resume();
            var temp = AIContext.Rank(1, AIContext.PrepareData(new List<WebRankingML.AIResume>() { new WebRankingML.AIResume() { Id = 1, BusinessBonds = 2123123, Educations = 1, GroupId = 1, Idioms = 1, Skills = 1, Label = 1 }, new WebRankingML.AIResume() { Id = 2, Label = 1, BusinessBonds = 1, Educations = 1, GroupId = 1, Idioms = 1, Skills = 1902390123 }, resume.ConvertToAIResume(Skill.CSharp, Language.Africâner, Degree.Doutorado, 1, resume.CandidateId) })) ;
            return View();
        }

        public IActionResult Test()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}