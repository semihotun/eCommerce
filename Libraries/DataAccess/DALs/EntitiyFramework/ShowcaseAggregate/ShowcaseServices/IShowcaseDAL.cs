using Core.Utilities.Results;
using DataAccess.DALs.EntitiyFramework.ShowcaseAggregate.ShowcaseServices.ShowcaseDALModels;
using eCommerce.Core.DataAccess;
using Entities.Concrete.ShowcaseAggregate;
using Entities.DTO.ShowCase;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace DataAccess.DALs.EntitiyFramework.ShowcaseAggregate.ShowcaseServices
{
    public interface IShowcaseDAL : IEntityRepository<ShowCase>
    {
        Task<IDataResult<IList<ShowCaseDTO>>> GetAllShowCaseDto();
        Task<IDataResult<ShowCaseDTO>> GetShowCaseDto(GetShowCaseDto request);
    }
}
