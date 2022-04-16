using Business.Services.ProductAggregate.Products.ProductServiceModel;
using Core.Utilities.Results;
using Entities.Concrete.ProductAggregate;
using System.Threading.Tasks;
using X.PagedList;
namespace Business.Services.ProductAggregate.Products
{
    public interface IProductService
    {
        Task<IResult> AddProduct(Product product);
        Task<IResult> UpdateProduct(Product product);
        Task<IResult> DeleteProduct(DeleteProduct request);
        Task<IDataResult<Product>> GetProduct(GetProduct request);
        Task<IDataResult<IPagedList<Product>>> GetMainSearchProduct(MainSearchProduct request);
        Task<IDataResult<IPagedList<Product>>> GetProductsBySpecificationAttributeId(GetProductsBySpecificationAttributeId request);

    }
}
