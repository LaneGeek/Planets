using System;
using System.ComponentModel.DataAnnotations;

namespace Planets.Models
{
    public class Survey
    {
        public int SurveyId { get; set; }
        public DateTime SurveyDateTime { get; set; }

        // The properties below need input validation
        [Required(ErrorMessage = "Please enter your first name please.")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "First Name must be between 2 and 20 characters long!")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter your last name please.")]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "Last Name must be between 2 and 30 characters long!")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please enter your city please.")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "City must be between 2 and 20 characters long!")]
        public string City { get; set; }

        [Required(ErrorMessage = "Please enter your country please.")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Country must be between 2 and 20 characters long!")]
        public string Country { get; set; }

        [Range(1, 5, ErrorMessage = "Please choose stars to award us. Thank you.")]
        public int Rating { get; set; }
        
        [Required(ErrorMessage = "Please enter some comments please.")]
        public string Comment { get; set; }
    }
}
