using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Results;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Business.Abstract.Products
{
    public interface  IProductStockTypeService
    {
        Task<IDataResult<IEnumerable<SelectListItem>>> GetAllProductStockType(int selectedId = 0);
    }
}
