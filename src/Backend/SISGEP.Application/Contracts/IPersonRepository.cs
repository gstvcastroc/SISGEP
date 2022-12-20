using SISGEP.Application.Entities;
using System;
using System.Threading.Tasks;

namespace SISGEP.Application.Contracts
{
    public interface IPersonRepository
    {
        Task<Person> GetPersonById(Guid id);
    }
}
