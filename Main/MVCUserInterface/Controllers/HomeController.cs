using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MVCUserInterface.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using System.IO;
using System.Text.Json;

namespace MVCUserInterface.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            var test = await new HttpClient().GetAsync("http://localhost:30442/WeatherForecast");
            var contentStream = test.Content.ReadAsStream();
            var textReader = new StreamReader(contentStream);
            var contentString = textReader.ReadToEnd();
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
