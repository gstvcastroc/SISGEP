using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;

namespace SISGEP.Application.Entities
{
    public class Project : Entity
    {
        public Guid ProjectId { get; set; } = Guid.NewGuid();

        public string Name { get; set; } = string.Empty; 

        public string? Description { get; set; } = string.Empty;

        public bool IsActive { get; set; } = true;

        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public Survey? Survey { get; set; } = new Survey();

        public List<Person>? Persons { get; set; }
    }
}
