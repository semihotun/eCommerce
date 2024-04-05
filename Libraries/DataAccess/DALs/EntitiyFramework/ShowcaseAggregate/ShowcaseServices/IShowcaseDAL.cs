using Core.DataAccess;
using Core.Utilities.Results;
using Entities.Concrete.ShowcaseAggregate;
using Entities.Dtos.ShowcaseDALModels;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace DataAccess.DALs.EntitiyFramework.ShowcaseAggregate.ShowcaseServices
{
    public interface IShowcaseDAL : IEntityRepository<ShowCase>
    {
        Task<Result<IList<ShowCaseDTO>>> GetAllShowCaseDto();
        Task<Result<ShowCaseDTO>> GetShowCaseDto(GetShowCaseDto request);
    }
}
