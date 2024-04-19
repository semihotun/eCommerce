using Core.Utilities.PagedList;
using Core.Utilities.Results;
using Entities.Dtos.ProductStockDALModels;
using Entities.RequestModel.ProductAggregate.ProductStocks;
using System.Threading.Tasks;

namespace Business.Services.ProductAggregate.ProductStocks.DtoQueries
{
    public interface IProductStockDtoQueryService
    {
        Task<Result<IPagedList<ProductStockDto>>> GetAllProductStockDto(GetAllProductStockReqModel request);
    }
}
