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
            if (!User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "SignIn");

            if (User.IsInRole("candidate"))
                return Redirect($"profile/{User.Identity.Name}");
            else
                return Redirect($"company/{User.Identity.Name}");
        }

        [HttpGet("Profile/{profileName}")]
        public IActionResult Index(string profileName)
        {
            return View();
        }
    }
}