using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;

namespace Geeky.Swimteam.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Title"] = "WaterFit";
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Water fit aquatics information page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Contact Us.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
