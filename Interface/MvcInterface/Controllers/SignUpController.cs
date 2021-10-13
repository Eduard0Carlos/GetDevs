using Microsoft.AspNetCore.Mvc;

namespace MVCUserInterface.Controllers
{
    public class SignUpController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        
        [HttpGet]
        public IActionResult Candidate()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Company()
        {
            return View();
        }
    }
}
