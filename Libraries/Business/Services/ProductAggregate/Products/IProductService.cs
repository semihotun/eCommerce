using Business.Services.ProductAggregate.Products.ProductServiceModel;
using Core.Utilities.Results;
using Entities.Concrete.ProductAggregate;
using System.Threading.Tasks;
using X.PagedList;
namespace Business.Services.ProductAggregate.Products
{
    public interface IProductService
    {
        Task<Result<Product>> CreateOrUpdateProduct(Product product);
        Task<Result<Product>> AddProduct(Product product);
        Task<Result<Product>> UpdateProduct(Product product);
        Task<Result> DeleteProduct(DeleteProduct request);
        Task<Result<Product>> GetProduct(GetProduct request);
        Task<Result<IPagedList<Product>>> GetProductsBySpecificationAttributeId(GetProductsBySpecificationAttributeId request);
    }
}
