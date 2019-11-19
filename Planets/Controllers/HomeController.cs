using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Planets.Models;

namespace Planets.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index() => View();

        public IActionResult Mercury() => View();

        public IActionResult Venus() => View();

        public IActionResult Earth() => View();

        public IActionResult Mars() => View();

        public IActionResult Jupiter() => View();

        public IActionResult Saturn() => View();

        public IActionResult Uranus() => View();

        public IActionResult Neptune() => View();

        public IActionResult TakeSurvey() => View();

        public IActionResult ViewSurveys() => View();

        public IActionResult About() => View();
    }
}
