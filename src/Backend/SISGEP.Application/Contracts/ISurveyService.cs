using SISGEP.Application.DTOs;
using SISGEP.Application.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SISGEP.Application.Contracts
{
    public interface ISurveyService
    {
        Task<bool> CreateSurveyAsync(EditSurveyDTO dto);

        Task<Survey> GetSurveyByIdAsync(Guid id);

        Task<IEnumerable<Survey>> GetAllSurveysAsync();

        Task<bool> UpdateSurveyAsync(Guid id, EditSurveyDTO dto);

        Task<bool> DeleteSurveyAsync(Guid id);

        Task<bool> FillSurvey(EditFilledSurveyDTO dto);
    }
}