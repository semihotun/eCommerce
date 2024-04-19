using Core.Utilities.PagedList;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.RequestModel.ProductAggregate.ProductSpecificationAttributes;
using System.Threading.Tasks;

namespace Business.Services.ProductAggregate.ProductSpecificationAttributes.Queries
{
    public interface IProductSpecificationAttributeQueryService
    {
        Task<Result<IPagedList<ProductSpecificationAttribute>>> GetProductSpecificationAttributes(GetProductSpecificationAttributesReqModel request);
        Task<Result<ProductSpecificationAttribute>> GetProductSpecificationAttributeById(GetProductSpecificationAttributeByIdReqModel request);
        Task<Result<int>> GetProductSpecificationAttributeCount(GetProductSpecificationAttributeCountReqModel request);
    }
}
