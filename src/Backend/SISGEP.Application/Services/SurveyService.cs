using SISGEP.Application.Contracts;
using SISGEP.Application.Data;
using SISGEP.Application.Data.Repositories;
using SISGEP.Application.DTOs;
using SISGEP.Application.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SISGEP.Application.Services
{
    public class SurveyService : ISurveyService
    {
        private readonly SISGEPContext _context;
        private readonly IRepository<Survey> _repository;
        private readonly IRepository<FilledSurvey> _filledSurveyRepository;

        public SurveyService(SISGEPContext context, IRepository<Survey> repository, IRepository<FilledSurvey> filledSurveyRepository)
        {
            _context = context;
            _repository = repository;
            _filledSurveyRepository = filledSurveyRepository;
        }

        public async Task<bool> CreateSurveyAsync(EditSurveyDTO dto)
        {
            var survey = new Survey()
            {
                Name = dto.Name,
                Date = dto.Date,
                Structure = dto.Structure,
                ProjectId = dto.ProjectId.Value
            };

            _repository.Create(survey);

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<Survey> GetSurveyByIdAsync(Guid id)
        {
            var survey = await _repository.GetById(id);

            return survey;
        }

        public async Task<IEnumerable<Survey>> GetAllSurveysAsync()
        {
            var surveys = _repository.GetAll(includes: new string[] { "FilledSurveys" });

            return surveys;
        }

        public async Task<bool> UpdateSurveyAsync(Guid id, EditSurveyDTO dto)
        {
            var survey = await _repository.GetById(id);

            if (survey is null)
            {
                return false;
            }

            survey.Update(dto);

            _context.Update(survey);

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteSurveyAsync(Guid id)
        {
            await _repository.Delete(id);

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> FillSurvey(EditFilledSurveyDTO dto)
        {
            var filledSurvey = new FilledSurvey()
            {
                Structure = dto.Structure,
                Date = dto.Date,
                PersonId = dto.PersonId,
                SurveyId = dto.SurveyId
            };

            _filledSurveyRepository.Create(filledSurvey);

            await _context.SaveChangesAsync();

            return true;
        }
    }
}
