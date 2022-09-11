using System;

namespace SISGEP.Application.Entities
{
    public class Address : Entity
    {
        public Address()
        {

        }

        public Address(
            string postalCode,
            string thoroughfare,
            int number,
            string neighborhood,
            string complement,
            string city,
            string state)
        {
            Id = Guid.NewGuid();
            PostalCode = postalCode;
            Thoroughfare = thoroughfare;
            Number = number;
            Neighborhood = neighborhood;
            Complement = complement;
            City = city;
            State = state;
        }

        public Guid Id { get; set; }

        public string PostalCode { get; set; }

        public string Thoroughfare { get; set; }

        public int Number { get; set; }

        public string Neighborhood { get; set; }

        public string Complement { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        // Navigation property
        public Guid PersonId { get; set; }
        public Person? Person { get; set; }
    }
}
