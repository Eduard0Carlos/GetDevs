using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MVCUserInterface.Models;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using WebRankingML;

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
            var temp = AIContext.Rank(1, AIContext.PrepareData(new List<AIResume>()));
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
