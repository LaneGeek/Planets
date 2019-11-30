using System;
using Microsoft.AspNetCore.Mvc;
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

        public IActionResult ThankSurvey() => View();

        [HttpPost]
        public IActionResult TakeSurvey(string firstName, string lastName, string city, string country,
            string rating, string comment)
        {
            Survey survey = new Survey
            {
                FirstName = firstName,
                LastName = lastName,
                City = city,
                Country = country,
                Rating = rating == "" ? 5: Int32.Parse(rating),
                Comment = comment,
                SurveyDateTime = DateTime.Now
            };
            return View("ThankSurvey", survey);
        }

        public IActionResult ViewSurveys() => View();

        public IActionResult About() => View();
    }
}
