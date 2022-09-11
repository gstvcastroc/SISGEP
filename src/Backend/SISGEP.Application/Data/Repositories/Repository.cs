using SISGEP.Application.Contracts;
using SISGEP.Application.Entities;
using System;
using System.Collections.Generic;

namespace SISGEP.Application.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
        public bool Create(T entity)
        {
            throw new NotImplementedException();
        }

        public T GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public bool Update(Guid id, T entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
