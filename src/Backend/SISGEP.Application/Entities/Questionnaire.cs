using System;
using System.Collections.Generic;

namespace SISGEP.Application.Entities
{
    public class Questionnaire : Entity
    {
        public Questionnaire()
        {

        }

        public Questionnaire(string name, DateOnly date, string structure, Project project)
        {
            Id = Guid.NewGuid();
            Name = name;
            Date = date;
            Structure = structure;
            Project = project;
        }

        public Guid Id { get; set; }

        public string Name { get; set; }

        public DateOnly Date { get; set; }

        public string Structure { get; set; }

        // Navigation properties
        public Guid ProjectId { get; set; }
        public Project Project { get; set; }

        public List<AnsweredQuestionnaire>? AnsweredQuestionnaires { get; set; }
    }
}
