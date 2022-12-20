using SISGEP.Application.DTOs;
using SISGEP.Application.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SISGEP.Application.Contracts
{
    public interface IProjectService
    {
        Task<bool> CreateProjectAsync(EditProjectDTO dto);
        Task<bool> DeleteProjectAsync(Guid id);
        IEnumerable<Project> GetAllProjectsAsync();
        Task<Project> GetProjectByIdAsync(Guid id);
        Task<bool> UpdateProjectAsync(Guid id, EditProjectDTO dto);
    }
}