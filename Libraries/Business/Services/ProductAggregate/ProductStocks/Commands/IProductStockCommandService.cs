using Core.Utilities.Results;
using Entities.Concrete;
using Entities.RequestModel.ProductAggregate.ProductStocks;
using System.Threading.Tasks;

namespace Business.Services.ProductAggregate.ProductStocks.Commands
{
    public interface IProductStockCommandService
    {
        Task<Result<ProductStock>> AddProductStock(AddProductStockReqModel productStock);
        Task<Result> DeleteProductStock(DeleteProductStockReqModel request);
    }
}
