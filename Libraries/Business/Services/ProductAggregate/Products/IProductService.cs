using Core.Utilities.PagedList;
using Core.Utilities.Results;
using Entities.Concrete.ProductAggregate;
using Entities.RequestModel.ProductAggregate.Products;
using System.Threading.Tasks;
namespace Business.Services.ProductAggregate.Products
{
    public interface IProductService
    {
        Task<Result<Product>> CreateOrUpdateProduct(CreateOrUpdateProductReqModel product);
        Task<Result<Product>> AddProduct(AddProductReqModel product);
        Task<Result<Product>> UpdateProduct(UpdateProductReqModel product);
        Task<Result> DeleteProduct(DeleteProductReqModel request);
        Task<Result<Product>> GetProduct(GetProductReqModel request);
        Task<Result<IPagedList<Product>>> GetProductsBySpecificationAttributeId(GetProductsBySpecificationAttributeIdReqModel request);
    }
}
