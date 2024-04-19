using Core.Utilities.PagedList;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.RequestModel.ProductAggregate.ProductStocks;
using System.Threading.Tasks;

namespace Business.Services.ProductAggregate.ProductStocks.Queries
{
    public interface IProductStockQueryService
    {
        Task<Result<IPagedList<ProductStock>>> GetAllProductStock(GetAllProductStockReqModel request);
    }
}
