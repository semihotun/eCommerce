using Business.Services.ProductAggregate.ProductStocks.ProductStockServiceModel;
using Core.Utilities.Results;
using Entities.Concrete.ProductAggregate;
using System.Threading.Tasks;
using X.PagedList;
namespace Business.Services.ProductAggregate.ProductStocks
{
    public interface IProductStockService
    {
        Task<Result<IPagedList<ProductStock>>> GetAllProductStock(GetAllProductStock request);
        Task<Result> AddProductStock(ProductStock productStock);
        Task<Result> DeleteProductStock(DeleteProductStock request);
    }
}
