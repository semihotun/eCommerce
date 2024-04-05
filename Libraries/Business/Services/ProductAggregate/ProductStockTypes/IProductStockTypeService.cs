using Core.Utilities.Results;
using Entities.RequestModel.ProductAggregate.ProductStockTypes;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace Business.Services.ProductAggregate.ProductStockTypes
{
    public interface IProductStockTypeService
    {
        Task<Result<IEnumerable<SelectListItem>>> GetAllProductStockType(GetAllProductStockTypeReqModel request);
    }
}
