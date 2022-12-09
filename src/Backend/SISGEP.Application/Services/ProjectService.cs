using SISGEP.Application.Contracts;
using SISGEP.Application.Data;
using SISGEP.Application.DTOs;
using SISGEP.Application.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SISGEP.Application.Services
{
    public class ProjectService : IProjectService
    {
        private readonly SISGEPContext _context;
        private readonly IRepository<Project> _repository;

        public ProjectService(SISGEPContext context, IRepository<Project> repository)
        {
            _context = context;
            _repository = repository;
        }

        public async Task<bool> CreateProjectAsync(EditProjectDTO dto)
        {
            var project = new Project()
            {
                Name = dto.Name,
                Description = dto.Description,
                IsActive = dto.IsActive,
                StartDate = dto.StartDate,
                EndDate = dto.EndDate,
            };

            _repository.Create(project);

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<Project> GetProjectByIdAsync(Guid id)
        {
            var project = await _repository.GetById(id);

            return project;
        }

        public IEnumerable<Project> GetAllProjectsAsync()
        {
            var projects = _repository.GetAll(new string[] { });

            return projects;
        }

        public async Task<bool> UpdateProjectAsync(Guid id, EditProjectDTO dto)
        {
            var project = await _repository.GetById(id);

            if (project is null)
            {
                return false;
            }

            project.Update(dto);

            _repository.Update(project);

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteProjectAsync(Guid id)
        {
            await _repository.Delete(id);

            await _context.SaveChangesAsync();

            return true;
        }
    }
}
