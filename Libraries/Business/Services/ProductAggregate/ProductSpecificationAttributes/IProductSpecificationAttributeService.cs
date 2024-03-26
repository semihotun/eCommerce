using Business.Services.ProductAggregate.ProductSpecificationAttributes.ProductSpecificationAttributeServiceModel;
using Core.Utilities.Results;
using Entities.Concrete.ProductAggregate;
using System.Threading.Tasks;
using X.PagedList;
namespace Business.Services.ProductAggregate.ProductSpecificationAttributes
{
    public interface IProductSpecificationAttributeService
    {
        Task<Result> DeleteProductSpecificationAttribute(DeleteProductSpecificationAttribute request);
        Task<Result<IPagedList<ProductSpecificationAttribute>>> GetProductSpecificationAttributes(GetProductSpecificationAttributes request);
        Task<Result<ProductSpecificationAttribute>> GetProductSpecificationAttributeById(GetProductSpecificationAttributeById request);
        Task<Result> InsertProductSpecificationAttribute(ProductSpecificationAttribute productSpecificationAttribute);
        Task<Result> UpdateProductSpecificationAttribute(ProductSpecificationAttribute productSpecificationAttribute);
        Task<Result<int>> GetProductSpecificationAttributeCount(GetProductSpecificationAttributeCount request);
    }
}
