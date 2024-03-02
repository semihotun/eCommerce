using Business.Services.ProductAggregate.ProductStocks.ProductStockServiceModel;
using Core.Utilities.Results;
using Entities.Concrete.ProductAggregate;
using Entities.Others;
using Entities.ViewModels.AdminViewModel.AdminProduct;
using System.Threading.Tasks;
using X.PagedList;
namespace Business.Services.ProductAggregate.ProductStocks
{
    public interface IProductStockService
    {
        Task<IDataResult<IPagedList<ProductStock>>> GetAllProductStock(GetAllProductStock request);
        Task<IResult> AddProductStock(ProductStock productStock);
        Task<IResult> DeleteProductStock(DeleteProductStock request);
    }
}
