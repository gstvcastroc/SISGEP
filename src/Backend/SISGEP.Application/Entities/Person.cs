using SISGEP.Application.DTOs;
using System;
using System.Collections.Generic;

namespace SISGEP.Application.Entities
{
    public class Person : Entity
    {
        public Guid PersonId { get; set; } = Guid.NewGuid();

        public string Name { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        /* TODO: remove this password property and replace it with two other properties: Hash and Salt.
         * SHA1 algorithm method (plain text password + Salt) returns a hash.
         * Saves the hash and salt in the database. */
        public string Password { get; set; } = string.Empty;

        public bool IsActive { get; set; } = true;

        public string Cpf { get; set; } = string.Empty;

        public PersonType PersonType { get; set; } = PersonType.Benefited;

        public Address Address { get; set; }

        public List<Project>? Projects { get; set; } = new List<Project>();

        public List<FilledSurvey>? FilledSurveys { get; set; } = new List<FilledSurvey>();

        public void Update(EditPersonDTO dto)
        {
            Name = dto.Name is null ? Name : dto.Name;

            Email = dto.Email is null ? Email : dto.Email;

            Password = dto.Password is null ? Password : dto.Password;

            IsActive = dto.IsActive;

            Cpf = dto.Cpf is null ? Cpf : dto.Cpf;

            PersonType = dto.PersonType;

            Address.PostalCode = dto.Address.PostalCode is null ? Address.PostalCode : dto.Address.PostalCode;

            Address.Thoroughfare = dto.Address.Thoroughfare is null ? Address.Thoroughfare : dto.Address.Thoroughfare;

            Address.Number = dto.Address.Number is 0 ? Address.Number : dto.Address.Number;

            Address.Neighborhood = dto.Address.Neighborhood is null ? Address.Neighborhood : dto.Address.Neighborhood;

            Address.Complement = dto.Address.Complement is null ? Address.Complement : dto.Address.Complement;

            Address.City = dto.Address.City is null ? Address.City : dto.Address.City;

            Address.State = dto.Address.State is null ? Address.State : dto.Address.State;

            Address.PersonId = PersonId;
        }
    }

    public enum PersonType
    {
        Manager,
        Voluntary,
        Benefited
    }
}
