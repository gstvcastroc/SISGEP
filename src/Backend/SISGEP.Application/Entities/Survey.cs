using System;
using System.Collections.Generic;

namespace SISGEP.Application.Entities
{
    public class Survey : Entity
    {
        public Guid SurveyId { get; set; } = Guid.NewGuid();

        public string Name { get; set; } = string.Empty;

        public DateTime Date { get; set; }

        public string Structure { get; set; } = "{}";

        public Guid ProjectId { get; set; }

        public List<FilledSurvey> FilledSurveys { get; set; } = new List<FilledSurvey>();
    }
}
