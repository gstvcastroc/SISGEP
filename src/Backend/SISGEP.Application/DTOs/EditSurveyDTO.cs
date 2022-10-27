using SISGEP.Application.Entities;
using System;
using System.Collections.Generic;

namespace SISGEP.Application.DTOs
{
    public class EditSurveyDTO
    {
        public string? Name { get; set; } = string.Empty;

        public DateTime? Date { get; set; }

        public string? Structure { get; set; } = string.Empty;

        public Guid? ProjectId { get; set; }

        public List<FilledSurvey>? FilledSurveys { get; set; } = new List<FilledSurvey>();
    }
}
