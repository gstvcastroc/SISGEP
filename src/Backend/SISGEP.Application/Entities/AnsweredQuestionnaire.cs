using System;
using System.Collections.Generic;

namespace SISGEP.Application.Entities
{
    public class AnsweredQuestionnaire : Entity
    {
        public AnsweredQuestionnaire()
        {

        }

        public AnsweredQuestionnaire(string structure, DateOnly date, Questionnaire questionnaire, List<Person> benefiteds)
        {
            Id = Guid.NewGuid();
            Structure = structure;
            Date = date;
            Questionnaire = questionnaire;
            Benefiteds = benefiteds;
        }

        public Guid Id { get; set; }

        public string Structure { get; set; }

        public DateOnly Date { get; set; }

        // Navigation properties
        public Questionnaire Questionnaire { get; set; }

        public List<Person> Benefiteds { get; set; }
    }
}
