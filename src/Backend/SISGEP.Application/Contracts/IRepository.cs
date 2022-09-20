using SISGEP.Application.Entities;
using System;
using System.Collections.Generic;

namespace SISGEP.Application.Contracts
{
    public interface IRepository<T> where T : Entity
    {
        bool Create(T entity);

        T GetById(Guid id);

        IEnumerable<T> GetAll();

        bool Update(Guid id, T entity);

        bool Delete(Guid id);
    }
}