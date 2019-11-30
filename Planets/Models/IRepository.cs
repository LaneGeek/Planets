using System.Collections.Generic;

namespace Planets.Models
{
    interface IRepository
    {
        List<Survey> Surveys { get; }

        void AddSurvey(Survey survey);
    }
}
