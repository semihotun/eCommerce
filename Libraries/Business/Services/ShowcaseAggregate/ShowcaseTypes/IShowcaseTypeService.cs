using Business.Services.ShowcaseAggregate.ShowcaseTypes.ShowcaseTypeServiceModel;
using Core.Utilities.Results;
using Entities.Concrete.ShowcaseAggregate;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace Business.Services.ShowcaseAggregate.ShowcaseTypes
{
    public interface IShowcaseTypeService
    {
        Task<IDataResult<IList<ShowCaseType>>> GetAllShowCaseType();
        Task<IDataResult<IEnumerable<SelectListItem>>> GetAllShowCaseTypeSelectListItem(GetAllShowCaseTypeSelectListItem request);
    }
}
