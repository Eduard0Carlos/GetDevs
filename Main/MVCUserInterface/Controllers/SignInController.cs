using Microsoft.AspNetCore.Mvc;

namespace MVCUserInterface.Controllers
{
    public class SignInController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Candidate()
        {
            return View();
        }

        public IActionResult Company()
        {
            return View();
        }
    }
}
