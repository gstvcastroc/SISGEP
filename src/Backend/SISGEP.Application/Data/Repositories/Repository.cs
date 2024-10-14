using Microsoft.EntityFrameworkCore;
using SISGEP.Application.Contracts;
using SISGEP.Application.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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

#pragma warning disable CS8603 // Possible null reference return.
        public async Task<T>? GetById(Guid id)
        {
            switch (typeof(T))
            {
                case Type personType when personType == typeof(Person):

                    var person = await _context.Persons
                        .Include(person => person.Address)
                        .Include(person => person.Projects)
                        .Include(person => person.FilledSurveys)
                        .FirstOrDefaultAsync(person => person.PersonId == id);

                    if (person is null) 
                        return null;

                    return (T)Convert.ChangeType(person, typeof(Person));

                case Type projectType when projectType == typeof(Project):

                    var project = await _context.Projects.FindAsync(id);

                    if (project is null)
                    {
                        return null;
                    }

                    return (T)Convert.ChangeType(project, typeof(Project));

                case Type surveyType when surveyType == typeof(Survey):

                    var survey = await _context.Surveys.FindAsync(id);

                    if (survey is null)
                    {
                        return null;
                    }

                    return (T)Convert.ChangeType(survey, typeof(Survey));

                default:
                    break;
            }

            var entity = await _context.FindAsync<T>(id);

            return entity;
        }

        public IEnumerable<T>? GetAll(string[]? includes = null)
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
#pragma warning restore CS8603 // Possible null reference return.

        public bool Update(T entity)
        {
            _context.Update(entity);

            return true;
        }

        public async Task<bool> Delete(Guid id)
        {
            var entity = await _context.FindAsync<T>(id);

            if (entity is null)
            {
                return false;
            }

            _context.Remove(entity);

            return true;
        }
    }
}
