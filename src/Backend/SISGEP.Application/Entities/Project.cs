using SISGEP.Application.DTOs;
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

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public Survey? Survey { get; set; } = new Survey();

        public List<Person>? Persons { get; set; }

        public void Update(EditProjectDTO dto)
        {
            Name = dto.Name is null ? Name : dto.Name;

            Description = dto.Description is null ? Description : dto.Description;

            IsActive = dto.IsActive;

            StartDate = dto.StartDate is null ? StartDate : dto.StartDate;

            EndDate = dto.EndDate is null ? EndDate : dto.EndDate;

            Survey = dto.Survey is null ? Survey : dto.Survey;

            Persons = dto.Persons is null ? Persons : dto.Persons;
        }
    }
}
