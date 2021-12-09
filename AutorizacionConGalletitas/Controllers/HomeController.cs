using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            return View();
        }
    }
}
