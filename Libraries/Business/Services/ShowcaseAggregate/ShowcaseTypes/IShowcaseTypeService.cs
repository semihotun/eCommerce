using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Business.Services.ShowcaseAggregate.ShowcaseTypes.ShowcaseTypeServiceModel;
using Core.Utilities.Results;
using Entities.Concrete.ShowcaseAggregate;
using Microsoft.AspNetCore.Mvc.Rendering;
namespace Business.Services.ShowcaseAggregate.ShowcaseTypes
{
    public interface IShowcaseTypeService
    {
        Task<IDataResult<IList<ShowCaseType>>> GetAllShowCaseType();
        Task<IDataResult<IEnumerable<SelectListItem>>> GetAllShowCaseTypeSelectListItem(GetAllShowCaseTypeSelectListItem request);
    }
}
