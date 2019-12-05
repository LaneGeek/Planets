using System.Collections.Generic;

namespace Planets.Models
{
    public class FakeRepository : IRepository
    {
        private readonly List<Survey> _surveys = new List<Survey>();

        public List<Survey> Surveys => _surveys;

        public void AddSurvey(Survey survey) => Surveys.Add(survey);
    }
}
