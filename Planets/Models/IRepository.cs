using System.Collections.Generic;

namespace Planets.Models
{
    public interface IRepository
    {
        List<Survey> Surveys { get; }

        void AddSurvey(Survey survey);
    }
}
