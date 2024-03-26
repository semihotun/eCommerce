using Core.Utilities.Results;
using DataAccess.DALs.EntitiyFramework.ProductAggregate.ProductStocks.ProductStockDALModels;
using eCommerce.Core.DataAccess;
using Entities.Concrete.ProductAggregate;
using Entities.DTO.Product;
using System.Threading.Tasks;
using X.PagedList;
namespace DataAccess.DALs.EntitiyFramework.ProductAggregate.ProductStocks
{
    public interface IProductStockDAL : IEntityRepository<ProductStock>
    {
        Task<Result<IPagedList<ProductStockDto>>> GetAllProductStockDto(GetAllProductStockDto request);
    }
}
