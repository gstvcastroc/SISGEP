using SISGEP.Application.DTOs;
using System.Threading.Tasks;

namespace SISGEP.Application.Contracts
{
    public interface ISurveyService
    {
        Task<bool> CreateSurveyAsync(EditSurveyDTO dto);
    }
}