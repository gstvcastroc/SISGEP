using SISGEP.Application.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SISGEP.Application.Contracts
{
    public interface IRepository<T> where T : Entity
    {
        bool Create(T entity);

        Task<T>? GetById(Guid id);

        IEnumerable<T>? GetAll(string[]? includes = null);

        bool Update(T entity);

        Task<bool> Delete(Guid id);
    }
}