using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Business.Services.ProductAggregate.ProductStockTypes.ProductStockTypeServiceModel;
using Core.Utilities.Results;
using Microsoft.AspNetCore.Mvc.Rendering;
namespace Business.Services.ProductAggregate.ProductStockTypes
{
    public interface IProductStockTypeService
    {
        Task<IDataResult<IEnumerable<SelectListItem>>> GetAllProductStockType(GetAllProductStockType request);
    }
}
