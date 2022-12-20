using System;

namespace SISGEP.Application.DTOs
{
    public class EditFilledSurveyDTO
    {
        public string Structure { get; set; } = string.Empty;

        public DateTime Date { get; set; }

        public Guid SurveyId { get; set; }

        public Guid PersonId { get; set; }
    }
}
