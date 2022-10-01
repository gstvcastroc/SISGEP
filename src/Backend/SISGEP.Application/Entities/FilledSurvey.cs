using System;

namespace SISGEP.Application.Entities
{
    public class FilledSurvey : Entity
    {
        public Guid FilledSurveyId { get; set; } = Guid.NewGuid();

        public string Structure { get; set; } = string.Empty;

        public DateTime Date { get; set; }

        public Guid SurveyId { get; set; }

        public Guid PersonId { get; set; }
    }
}
