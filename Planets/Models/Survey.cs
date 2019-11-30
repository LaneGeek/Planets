using System;

namespace Planets.Models
{
    public class Survey
    {
        public int SurveyId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
        public DateTime SurveyDateTime { get; set; }
    }
}
