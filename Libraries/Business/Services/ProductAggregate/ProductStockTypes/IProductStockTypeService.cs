using Business.Services.ProductAggregate.ProductStockTypes.ProductStockTypeServiceModel;
using Core.Utilities.Results;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace Business.Services.ProductAggregate.ProductStockTypes
{
    public interface IProductStockTypeService
    {
        Task<IDataResult<IEnumerable<SelectListItem>>> GetAllProductStockType(GetAllProductStockType request);
    }
}
