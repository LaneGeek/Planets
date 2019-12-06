using System.Collections.Generic;
using System.Linq;

namespace Planets.Models
{
    public class SurveyRepository : IRepository
    {
        private readonly AppDbContext _context;
        public List<Survey> Surveys => _context.Surveys.ToList();
        public SurveyRepository(AppDbContext context) => _context = context;

        public void AddSurvey(Survey survey)
        {
            _context.Surveys.Add(survey);
            _context.SaveChanges();
        }
    }
}
