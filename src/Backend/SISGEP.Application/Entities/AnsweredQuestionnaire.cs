using System;

namespace SISGEP.Application.Entities
{
    public class AnsweredQuestionnaire : Entity
    {
        public AnsweredQuestionnaire(string structure, DateOnly date, Questionnaire questionnaire, Person benefited)
        {
            Id = Guid.NewGuid();
            Structure = structure;
            Date = date;
            Questionnaire = questionnaire;
            Benefited = benefited;
        }

        public Guid Id { get; set; }

        public string Structure { get; set; }

        public DateOnly Date { get; set; }

        // Navigation properties
        public Questionnaire Questionnaire { get; set; }

        public Person Benefited { get; set; }
    }
}
