using Core.Utilities.PagedList;
using Core.Utilities.Results;
using Entities.Concrete.ProductAggregate;
using Entities.RequestModel.ProductAggregate.ProductSpecificationAttributes;
using System.Threading.Tasks;
namespace Business.Services.ProductAggregate.ProductSpecificationAttributes
{
    public interface IProductSpecificationAttributeService
    {
        Task<Result<ProductSpecificationAttribute>> InsertProductSpecificationAttribute(InsertProductSpecificationAttributeReqModel productSpecificationAttribute);
        Task<Result> UpdateProductSpecificationAttribute(UpdateProductSpecificationAttributeReqModel productSpecificationAttribute);
        Task<Result> DeleteProductSpecificationAttribute(DeleteProductSpecificationAttributeReqModel request);
        Task<Result<IPagedList<ProductSpecificationAttribute>>> GetProductSpecificationAttributes(GetProductSpecificationAttributesReqModel request);
        Task<Result<ProductSpecificationAttribute>> GetProductSpecificationAttributeById(GetProductSpecificationAttributeByIdReqModel request);
        Task<Result<int>> GetProductSpecificationAttributeCount(GetProductSpecificationAttributeCountReqModel request);
    }
}
