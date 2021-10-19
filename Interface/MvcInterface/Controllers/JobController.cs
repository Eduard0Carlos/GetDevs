using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MvcInterface.Models;
using MvcInterface.Shared;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace MVCUserInterface.Controllers
{
    public class JobController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public JobController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            if (!User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "SignIn");

            return View();
        }
    }
}