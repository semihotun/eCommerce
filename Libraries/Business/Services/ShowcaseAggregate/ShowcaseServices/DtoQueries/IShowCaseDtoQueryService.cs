using Core.Utilities.Results;
using Entities.Dtos.ShowcaseDALModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Services.ShowcaseAggregate.ShowcaseServices.DtoQueries
{
    public interface IShowCaseDtoQueryService
    {
        Task<Result<IList<ShowCaseDTO>>> GetAllShowCaseDto();
        Task<Result<ShowCaseDTO>> GetShowCaseDto(GetShowCaseDto request);
    }
}
