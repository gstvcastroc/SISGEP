﻿using SISGEP.Application.Contracts;
using SISGEP.Application.Data;
using SISGEP.Application.DTOs;
using SISGEP.Application.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SISGEP.Application.Services
{
    public class PersonService : IPersonService
    {
        private readonly SISGEPContext _context;
        private readonly IRepository<Person> _repository;

        public PersonService(
            SISGEPContext context,
            IRepository<Person> repository)
        {
            _context = context;
            _repository = repository;
        }

        public async Task<bool> CreatePersonAsync(EditPersonDTO dto)
        {
            var person = new Person()
            {
                Name = dto.Name,
                Email = dto.Email,
                Password = dto.Password,
                IsActive = dto.IsActive,
                Cpf = dto.Cpf,
                PersonType = dto.PersonType,
            };

            var address = new Address
            {
                PostalCode = dto.Address.PostalCode,
                Thoroughfare = dto.Address.Thoroughfare,
                Number = dto.Address.Number,
                Neighborhood = dto.Address.Neighborhood,
                Complement = dto.Address.Complement,
                City = dto.Address.City,
                State = dto.Address.State,
                PersonId = person.PersonId
            };

            person.Address = address;

            _repository.Create(person);

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<Person> GetPersonByIdAsync(Guid id)
        {
            var person = await _repository.GetById(id);

            return person;
        }

        public IEnumerable<Person> GetAllPersonsAsync()
        {
            var persons = _repository.GetAll(includes: new string[] { "Address" });

            return persons;
        }

        public async Task<bool> UpdatePersonAsync(Guid id, EditPersonDTO dto)
        {
            var person = await _repository.GetById(id);

            if (person is null)
            {
                return false;
            }

            person.Update(dto);

            _context.Update(person);

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeletePersonAsync(Guid id)
        {
            await _repository.Delete(id);

            await _context.SaveChangesAsync();

            return true;
        }
    }
}
