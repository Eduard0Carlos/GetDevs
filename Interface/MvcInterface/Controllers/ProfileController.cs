using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MVCUserInterface.Controllers
{
    public class ProfileController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public ProfileController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet("Profile")]
        public IActionResult Index()
        {
            var test = User.IsInRole("ckjbafskjbasf");

            return Redirect($"profile/{User.Identity.Name}");
        }

        [HttpGet("Profile/{profileName}")]
        public IActionResult Index(string profileName)
        {
            return View();
        }
    }
}