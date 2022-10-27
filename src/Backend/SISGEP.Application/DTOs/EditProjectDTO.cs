using SISGEP.Application.Entities;
using System;
using System.Collections.Generic;

namespace SISGEP.Application.DTOs
{
    public class EditProjectDTO
    {
        public string? Name { get; set; } = string.Empty;

        public string? Description { get; set; } = string.Empty;

        public bool IsActive { get; set; } = true;

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public Survey? Survey { get; set; }

        public List<Person>? Persons { get; set; }
    }
}
