using Core.Utilities.PagedList;
using Core.Utilities.Results;
using Entities.Concrete.ProductAggregate;
using Entities.RequestModel.ProductAggregate.ProductStocks;
using System.Threading.Tasks;
namespace Business.Services.ProductAggregate.ProductStocks
{
    public interface IProductStockService
    {
        Task<Result<ProductStock>> AddProductStock(AddProductStockReqModel productStock);
        Task<Result> DeleteProductStock(DeleteProductStockReqModel request);
        Task<Result<IPagedList<ProductStock>>> GetAllProductStock(GetAllProductStockReqModel request);
    }
}
