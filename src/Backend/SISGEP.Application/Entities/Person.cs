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

        public bool IsActive { get; set; }

        public string Cpf { get; set; } = string.Empty;

        public PersonType PersonType { get; set; }

        public Address Address { get; set; } = new Address();

        public List<Project>? Projects { get; set; }

        public List<FilledSurvey> FilledSurveys { get; set; } = new List<FilledSurvey>(); 
    }

    public enum PersonType
    {
        Manager,
        Voluntary,
        Benefited
    }
}
