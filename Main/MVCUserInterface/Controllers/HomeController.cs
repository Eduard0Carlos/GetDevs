using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MVCUserInterface.Models;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
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
            var jsonString = JsonConvert.SerializeObject(new Candidate().SetName("Carlos"));
            var httpContent = new StringContent(jsonString, Encoding.UTF8, "application/json");
            var teste2 = new HttpClient().GetAsync("http://localhost:6615/api/candidate?id=1");
            var teste = new HttpClient().PutAsync("http://localhost:6615/api/candidate", httpContent);
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
