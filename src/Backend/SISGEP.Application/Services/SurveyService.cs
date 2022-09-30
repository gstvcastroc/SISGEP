using SISGEP.Application.Contracts;
using SISGEP.Application.Data;
using SISGEP.Application.DTOs;
using SISGEP.Application.Entities;
using System;
using System.Threading.Tasks;

namespace SISGEP.Application.Services
{
    public class SurveyService : ISurveyService
    {
        private readonly SISGEPContext _context;
        private readonly IRepository<Survey> _repository;

        public SurveyService(SISGEPContext context, IRepository<Survey> repository)
        {
            _context = context;
            _repository = repository;
        }

        public async Task<bool> CreateSurveyAsync(EditSurveyDTO dto)
        {
            var survey = new Survey()
            {
                Name = dto.Name,
                Date = dto.Date,
                Structure = dto.Structure,
                ProjectId = dto.ProjectId
            };

            _repository.Create(survey);

            await _context.SaveChangesAsync();

            return true;
        }
    }
}
