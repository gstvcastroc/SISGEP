using System;
using System.Collections.Generic;

namespace SISGEP.Application.Entities
{
    public class Person : Entity
    {
        public Person(
            string name,
            string email,
            string password,
            bool isActive,
            string cpf,
            PersonType personType,
            Address address)
        {
            Id = Guid.NewGuid();
            Name = name;
            Email = email;
            Password = password;
            IsActive = isActive;
            Cpf = cpf;
            PersonType = personType;
            Address = address;
        }

        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        /* TODO: remove this password property and replace it with two other properties: Hash and Salt.
         * SHA1 algorithm method (plain text password + Salt) returns a hash.
         * Saves the hash and salt in the database. */
        public string Password { get; set; }

        public bool IsActive { get; set; }

        public string Cpf { get; set; }

        public PersonType PersonType { get; set; }

        // Navigation property
        public Address Address { get; set; }

        public List<Project>? Projects { get; set; }
    }

    public enum PersonType
    {
        Manager,
        Voluntary,
        Benefited
    }
}
