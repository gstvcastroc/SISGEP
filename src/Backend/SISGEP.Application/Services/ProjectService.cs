using SISGEP.Application.Contracts;
using SISGEP.Application.Data;
using SISGEP.Application.Data.Repositories;
using SISGEP.Application.DTOs;
using SISGEP.Application.Entities;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

namespace SISGEP.Application.Services
{
    public class ProjectService : IProjectService
    {
        private readonly SISGEPContext _context;
        private readonly IRepository<Project> _genericRepository;

        public ProjectService(SISGEPContext context, IRepository<Project> genericRepository)
        {
            _context = context;
            _genericRepository = genericRepository;
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

            _genericRepository.Create(project);

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<Project> GetProjectByIdAsync(Guid id)
        {
            var project = await _genericRepository.GetById(id);

            return project;
        }

        public IEnumerable<Project> GetAllProjectsAsync()
        {
            var projects = _genericRepository.GetAll(new string[] { });

            return projects;
        }

        public async Task<bool> UpdateProjectAsync(Guid id, EditProjectDTO dto)
        {
            var project = await _genericRepository.GetById(id);

            if (project is null)
            {
                return false;
            }

            project.Update(dto);

            _genericRepository.Update(project);

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteProjectAsync(Guid id)
        {
            await _genericRepository.Delete(id);

            await _context.SaveChangesAsync();

            return true;
        }
    }
}
