using SISGEP.Application.DTOs;
using System;
using System.Collections.Generic;

namespace SISGEP.Application.Entities
{
    public class Survey : Entity
    {
        public Guid SurveyId { get; set; } = Guid.NewGuid();

        public string Name { get; set; } = string.Empty;

        public DateTime? Date { get; set; } = DateTime.MinValue;

        public string Structure { get; set; } = "{}";

        public Guid ProjectId { get; set; }

        public List<FilledSurvey> FilledSurveys { get; set; } = new List<FilledSurvey>();

        public void Update(EditSurveyDTO dto)
        {
            Name = dto.Name is null ? Name : dto.Name;

            Date = dto.Date is null ? Date : dto.Date;

            Structure = dto.Structure is null ? Structure : dto.Structure;

            ProjectId = dto.ProjectId is null ? ProjectId : dto.ProjectId.Value;

            FilledSurveys = dto.FilledSurveys is null ? FilledSurveys : dto.FilledSurveys;
        }
    }
}
