using System;
using System.Collections.Generic;

namespace SISGEP.Application.Entities
{
    public class Project : Entity
    {
        public Project(string name, bool isActive, DateOnly startDate, DateOnly endDate, string description)
        {
            Id = Guid.NewGuid();
            Name = name;
            IsActive = isActive;
            StartDate = startDate;
            EndDate = endDate;
            Description = description;
        }

        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public bool IsActive { get; set; }

        public DateOnly StartDate { get; set; }

        public DateOnly EndDate { get; set; }

        // Navigation property
        public Questionnaire? Questionnaire { get; set; }

        public List<Person>? Persons { get; set; }
    }
}
