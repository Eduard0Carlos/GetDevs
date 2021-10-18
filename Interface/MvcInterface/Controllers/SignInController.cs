using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Net.Http;
using Microsoft.AspNetCore.Authentication.Cookies;
using MvcInterface.Shared;
using MvcInterface.Models;
using Newtonsoft.Json;
using System.Text;

namespace MVCUserInterface.Controllers
{
    public class SignInController : Controller
    {
        private IHttpContextAccessor _context;

        public SignInController(IHttpContextAccessor context)
        {
            this._context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(LoginViewModel loginViewModel)
        {
            var json = JsonConvert.SerializeObject(loginViewModel);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            using var client = new HttpClient();
            var response = await client.PostAsync(Api.URL, data);

            if (response.IsSuccessStatusCode)
            {
                var claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.Name, loginViewModel.Email),
                    new Claim(ClaimTypes.Role, "candidate")
                };

                var claimsIdentity = new ClaimsIdentity(claims, "Login");

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }
        }
    }
}
