using SISGEP.Application.DTOs;
using SISGEP.Application.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SISGEP.Application.Contracts
{
    public interface IPersonService
    {
        Task<bool> CreatePersonAsync(EditPersonDTO dto);

        Task<Person> GetPersonByIdAsync(Guid id);

        IEnumerable<Person> GetAllPersonsAsync();

        Task<bool> DeletePersonAsync(Guid id);

        Task<bool> UpdatePersonAsync(Guid id, EditPersonDTO dto);
    }
}