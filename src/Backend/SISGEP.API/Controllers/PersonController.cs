using Microsoft.AspNetCore.Mvc;
using SISGEP.Application.Contracts;
using SISGEP.Application.DTOs;
using System;
using System.Threading.Tasks;

namespace SISGEP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _service;

        public PersonController(IPersonService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] EditPersonDTO dto)
        {
            var result = await _service.CreatePersonAsync(dto);

            if (result is not true)
            {
                return BadRequest();
            }

            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Read([FromRoute] Guid id)
        {
            var person = await _service.GetPersonByIdAsync(id);

            if (person is null)
            {
                return BadRequest();
            }

            return Ok(person);
        }

        [HttpGet]
        public IActionResult Read()
        {
            var persons = _service.GetAllPersonsAsync();

            if (persons is null)
            {
                return BadRequest();
            }

            return Ok(persons);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] EditPersonDTO dto)
        {
            var result = await _service.UpdatePersonAsync(id, dto);

            if (result is not true)
            {
                return BadRequest();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var result = await _service.DeletePersonAsync(id);

            if (result is not true)
            {
                return BadRequest();
            }

            return NoContent();
        }
    }
}
