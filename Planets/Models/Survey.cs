using System;
using System.ComponentModel.DataAnnotations;

namespace Planets.Models
{
    public class Survey
    {
        public int SurveyId { get; set; }
        public int Rating { get; set; }
        public DateTime SurveyDateTime { get; set; }

        // The properties below cannot be blank
        [Required(ErrorMessage = "Please enter your first name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter your last name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please enter your city")]
        public string City { get; set; }

        [Required(ErrorMessage = "Please enter your country")]
        public string Country { get; set; }

        [Required(ErrorMessage = "Please enter some comments")]
        public string Comment { get; set; }
    }
}
