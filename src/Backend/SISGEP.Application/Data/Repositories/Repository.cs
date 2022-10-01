using SISGEP.Application.Contracts;
using SISGEP.Application.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SISGEP.Application.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
        private readonly SISGEPContext _context;

        public Repository(SISGEPContext context)
        {
            _context = context;
        }

        public bool Create(T entity)
        {
            _context.Add(entity);

            return true;
        }

        public async Task<T> GetById(Guid id)
        {
            var entity = await _context.FindAsync<T>(id);

            return entity;
        }

        public IEnumerable<T> GetAll(string[] includes = null)
        {
            var entities = _context.Set<T>().AsQueryable();

            if (includes is null)
            {
                return entities;
            }

            foreach (var include in includes)
            {
                entities = entities.Include(include);
            }

            return entities;
        }

        public bool Update(T entity)
        {
            _context.Update(entity);

            return true;
        }

        public async Task<bool> Delete(Guid id)
        {
            var entity = await _context.FindAsync<T>(id);

            _context.Remove(entity);

            return true;
        }
    }
}
