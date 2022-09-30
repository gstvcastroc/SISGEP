using Microsoft.AspNetCore.Mvc;
using SISGEP.Application.Contracts;
using SISGEP.Application.DTOs;
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
        public async Task<IActionResult> Post([FromBody] EditSurveyDTO dto)
        {
            await _surveyService.CreateSurveyAsync(dto);

            return Ok();
        }
    }
}
