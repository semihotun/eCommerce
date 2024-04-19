using Core.Utilities.Results;
using Entities.Concrete;
using Entities.RequestModel.ProductAggregate.Products;
using System.Threading.Tasks;

namespace Business.Services.ProductAggregate.Products.Commands
{
    public interface IProductCommandService
    {
        Task<Result<Product>> CreateOrUpdateProduct(CreateOrUpdateProductReqModel product);
        Task<Result<Product>> AddProduct(AddProductReqModel product);
        Task<Result<Product>> UpdateProduct(UpdateProductReqModel product);
        Task<Result> DeleteProduct(DeleteProductReqModel request);
    }
}
