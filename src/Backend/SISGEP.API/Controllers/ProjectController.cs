using Microsoft.AspNetCore.Mvc;
using SISGEP.Application.Contracts;
using SISGEP.Application.DTOs;
using System;
using System.Threading.Tasks;

namespace SISGEP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _service;

        public ProjectController(IProjectService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] EditProjectDTO dto)
        {
            var result = await _service.CreateProjectAsync(dto);

            if (result is not true)
            {
                return BadRequest();
            }

            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Read([FromRoute] Guid id)
        {
            var project = await _service.GetProjectByIdAsync(id);

            if (project is null)
            {
                return BadRequest();
            }

            return Ok(project);
        }

        [HttpGet]
        public IActionResult Read()
        {
            var projects = _service.GetAllProjectsAsync();

            if (projects is null)
            {
                return BadRequest();
            }

            return Ok(projects);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] EditProjectDTO dto)
        {
            var result = await _service.UpdateProjectAsync(id, dto);

            if (result is not true)
            {
                return BadRequest();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var result = await _service.DeleteProjectAsync(id);

            if (result is not true)
            {
                return BadRequest();
            }

            return NoContent();
        }
    }
}
