using Microsoft.EntityFrameworkCore;
using SISGEP.Application.Contracts;
using SISGEP.Application.Entities;
using System;
using System.Threading.Tasks;

namespace SISGEP.Application.Data.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly SISGEPContext _context;

        public PersonRepository(SISGEPContext context)
        {
            _context = context;
        }

        public async Task<Person> GetPersonById(Guid id)
        {
            var person = await _context.Persons
                .Include(x => x.Address)
                .FirstOrDefaultAsync(x => x.PersonId == id);

            return person;
        }
    }
}
