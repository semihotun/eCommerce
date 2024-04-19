using Core.Utilities.Results;
using Entities.RequestModel.ProductAggregate.ProductStockTypes;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Services.ProductAggregate.ProductStockTypes.Queries
{
    public interface IProductStockTypeQueryService
    {
        Task<Result<IEnumerable<SelectListItem>>> GetAllProductStockType(GetAllProductStockTypeReqModel request);
    }
}
