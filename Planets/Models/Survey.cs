using System;
using System.ComponentModel.DataAnnotations;

namespace Planets.Models
{
    public class Survey
    {
        public int SurveyId { get; set; }
        public DateTime SurveyDateTime { get; set; }

        // The properties below need input validation
        [Required(ErrorMessage = "Please enter your first name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter your last name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please enter your city")]
        public string City { get; set; }

        [Required(ErrorMessage = "Please enter your country")]
        public string Country { get; set; }

        [Range(1, 5, ErrorMessage = "Please choose stars to award us")]
        public int Rating { get; set; }
        
        [Required(ErrorMessage = "Please enter some comments")]
        public string Comment { get; set; }
    }
}
