using Core.DataAccess;
using Core.Utilities.PagedList;
using Core.Utilities.Results;
using Entities.Concrete.ProductAggregate;
using Entities.Dtos.ProductStockDALModels;
using System.Threading.Tasks;
namespace DataAccess.DALs.EntitiyFramework.ProductAggregate.ProductStocks
{
    public interface IProductStockDAL : IEntityRepository<ProductStock>
    {
        Task<Result<IPagedList<ProductStockDto>>> GetAllProductStockDto(GetAllProductStockDto request);
    }
}
