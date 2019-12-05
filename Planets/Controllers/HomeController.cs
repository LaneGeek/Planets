using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Planets.Models;

namespace Planets.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepository _repository;

        // Dependency injection
        public HomeController(IRepository repository) => _repository = repository;

        // We need the best three most recent surveys on the home page
        public IActionResult Index() => View(_repository.Surveys.Where(x => x.Rating == 5).OrderByDescending(x => x.SurveyDateTime).Take(3));

        // Pages for the planets, etc
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

        // Pages without Nav Links
        public IActionResult ThankSurvey() => View();
        public IActionResult SearchSurveys() => View();
        public IActionResult WrongPassword() => View();
        public IActionResult SearchByCountry() => View();
        public IActionResult SearchByRating() => View();
        public IActionResult ListOfSurveys() => View(_repository.Surveys);

        [HttpPost]
        public IActionResult TakeSurvey(string firstName, string lastName, string city, string country, string rating, string comment)
        {
            // First we add the survey to the repository
            _repository.AddSurvey(new Survey
            {
                FirstName = firstName,
                LastName = lastName,
                City = city,
                Country = country,
                Rating = rating == "" ? 5 : Int32.Parse(rating),
                Comment = comment,
                SurveyDateTime = DateTime.Now
            });

            // Now we create a message to thank him or her based on the rating
            var message = rating switch
            {
                "1" => "one star? What have we done to deserve this?",
                "5" => "five stars! Thank you so much! You will now be mentioned on our home page!",
                _ => (rating + " stars.")
            };

            // Since we are allowed to send only one variable to the view, we will use a Tuple to send many
            var thankUser = new Tuple<string, string, string, string>(firstName, message, city, country);

            return View("ThankSurvey", thankUser);
        }

        [HttpPost]
        public IActionResult ViewSurveys(string password) => password == "password" ? View("SearchSurveys") : View("WrongPassword");

        [HttpPost]
        public IActionResult SearchByCountry(string country) => View("ListOfSurveys", _repository.Surveys.Where(x => x.Country == country));

        [HttpPost]
        public IActionResult SearchByRating(int rating) => View("ListOfSurveys", _repository.Surveys.Where(x => x.Rating == rating));
    }
}
