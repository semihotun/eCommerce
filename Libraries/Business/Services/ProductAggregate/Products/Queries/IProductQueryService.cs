using Core.Utilities.PagedList;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.RequestModel.ProductAggregate.Products;
using System.Threading.Tasks;

namespace Business.Services.ProductAggregate.Products.Queries
{
    public interface IProductQueryService
    {
        Task<Result<Product>> GetProduct(GetProductReqModel request);
        Task<Result<IPagedList<Product>>> GetProductsBySpecificationAttributeId(GetProductsBySpecificationAttributeIdReqModel request);
    }
}
