using Microsoft.AspNetCore.Mvc;
using MvcInterface.Models;
using MvcInterface.Shared;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

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

        [HttpPost]
        public async Task<IActionResult> Candidate(SignUpViewModel signUpViewModel)
        {
            var json = JsonConvert.SerializeObject(signUpViewModel);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            using var client = new HttpClient();
            var response = await client.PostAsync($"{Api.URL}/candidate/register", data);
            return RedirectToAction("Index", "SignIn");
        }

        [HttpGet]
        public IActionResult Company()
        {
            return View();
        }
    }
}
