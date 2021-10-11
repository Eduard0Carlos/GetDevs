using Domain.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Net.Http;

namespace MVCUserInterface.Controllers
{
    public class SignInController : Controller
    {
        private IUserService _userService;
        private IHttpContextAccessor _context;

        public SignInController(IUserService service, IHttpContextAccessor context)
        {
            this._userService = service;
            this._context = context;
        }

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

        [HttpPost]
        public async Task<IActionResult> Candidate(AuthenticateRequest model)
        {
            Shared.Results.AuthenticateResult result = await _userService.Authenticate(model);

            if (result == null)
            {
                ViewBag.Errors = "Erro na autenticação.";
                return View();
            }

            string role = result.IsCandidate ? "Candidate" : "Company";
            var userClaims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, result.Email),
                new Claim(ClaimTypes.Role, role),
                new Claim(ClaimTypes.NameIdentifier, result.Id.ToString())
            };
            var minhaIdentity = new ClaimsIdentity(userClaims, "User");
            var userPrincipal = new ClaimsPrincipal(new[] { minhaIdentity });

            if(_context != null)
            {
                await _context.HttpContext.SignInAsync(userPrincipal);
            }
            else
            {
                await HttpContext.SignInAsync(userPrincipal);
            }

            if (role == "Candidate")
            {
                return RedirectToAction("Index", "Candidate");
            }
            if (role == "Company")
            {
                return RedirectToAction("Index", "Company");
            }
            //TODO: redirecionar para a página correspondente.
            return View();
        }
    }
}
