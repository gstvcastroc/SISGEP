using Microsoft.AspNetCore.Mvc;
using SISGEP.Application.Contracts;
using SISGEP.Application.DTOs;
using System;
using System.Threading.Tasks;

namespace SISGEP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SurveyController : ControllerBase
    {
        private readonly ISurveyService _surveyService;

        public SurveyController(ISurveyService surveyService)
        {
            _surveyService = surveyService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] EditSurveyDTO dto)
        {
            await _surveyService.CreateSurveyAsync(dto);

            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Read([FromRoute] Guid id)
        {
            var survey = await _surveyService.GetSurveyByIdAsync(id);

            if (survey is null)
            {
                return BadRequest();
            }

            return Ok(survey);
        }

        [HttpGet]
        public IActionResult Read()
        {
            var surveys = _surveyService.GetAllSurveysAsync();

            if (surveys is null)
            {
                return BadRequest();
            }

            return Ok(surveys);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] EditSurveyDTO dto)
        {
            var result = await _surveyService.UpdateSurveyAsync(id, dto);

            if (result is not true)
            {
                return BadRequest();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var result = await _surveyService.DeleteSurveyAsync(id);

            if (result is not true)
            {
                return BadRequest();
            }

            return NoContent();
        }

        [HttpPost("fill")]
        public async Task<IActionResult> FillSurvey([FromBody] EditFilledSurveyDTO dto)
        {
            var result = await _surveyService.FillSurvey(dto);

            if (result is not true)
            {
                return BadRequest();
            }

            return NoContent();
        }
    }
}
