using Business.Services.ProductAggregate.ProductSpecificationAttributes.ProductSpecificationAttributeServiceModel;
using Core.Utilities.Results;
using Entities.Concrete.ProductAggregate;
using System.Threading.Tasks;
using X.PagedList;

namespace Business.Services.ProductAggregate.ProductSpecificationAttributes
{
    public interface IProductSpecificationAttributeService
    {
        Task<IResult> DeleteProductSpecificationAttribute(DeleteProductSpecificationAttribute request);
        Task<IDataResult<IPagedList<ProductSpecificationAttribute>>> GetProductSpecificationAttributes(GetProductSpecificationAttributes request);
        Task<IDataResult<ProductSpecificationAttribute>> GetProductSpecificationAttributeById(GetProductSpecificationAttributeById request);
        Task<IResult> InsertProductSpecificationAttribute(ProductSpecificationAttribute productSpecificationAttribute);
        Task<IResult> UpdateProductSpecificationAttribute(ProductSpecificationAttribute productSpecificationAttribute);
        Task<IDataResult<int>> GetProductSpecificationAttributeCount(GetProductSpecificationAttributeCount request);
    }
}
