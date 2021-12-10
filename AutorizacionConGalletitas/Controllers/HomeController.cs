using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;

namespace AutorizacionConGalletitas.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Publico()
        {
            return View();
        }

        [Authorize(Roles = "usuario")]
        public IActionResult Usuario()
        {
            return View();
        }

        [Authorize(Roles ="admin")]
        public IActionResult Administrador()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string rol)
        {
            if (!string.IsNullOrWhiteSpace(rol))
            {
                var identity =
                    new ClaimsIdentity(
                        CookieAuthenticationDefaults.AuthenticationScheme,
                        ClaimTypes.Name, ClaimTypes.Role);
                identity.AddClaim(new Claim(ClaimTypes.Role, rol));
                var principal = new ClaimsPrincipal(identity);
                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                string url=HttpContext.Request.Query["returnUrl"];
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
