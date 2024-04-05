using Core.Utilities.Results;
using Entities.Concrete.ShowcaseAggregate;
using Entities.RequestModel.ShowcaseAggregate.ShowcaseTypes;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace Business.Services.ShowcaseAggregate.ShowcaseTypes
{
    public interface IShowcaseTypeService
    {
        Task<Result<IList<ShowCaseType>>> GetAllShowCaseType();
        Task<Result<IEnumerable<SelectListItem>>> GetAllShowCaseTypeSelectListItem(GetAllShowCaseTypeSelectListItemReqModel request);
    }
}
