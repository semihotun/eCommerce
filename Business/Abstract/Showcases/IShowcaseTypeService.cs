using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Business.Abstract.Showcases
{
    public  interface IShowcaseTypeService
    {
        Task<IDataResult<IList<ShowCaseType>>> GetAllShowCaseType();

        Task<IDataResult<IEnumerable<SelectListItem>>> GetAllShowCaseTypeSelectListItem(int? selectedId=0);
    }
}
