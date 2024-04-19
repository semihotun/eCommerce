using Core.Utilities.Results;
using Entities.Concrete;
using Entities.RequestModel.ProductAggregate.ProductSpecificationAttributes;
using System.Threading.Tasks;

namespace Business.Services.ProductAggregate.ProductSpecificationAttributes.Commands
{
    public interface IProductSpecificationAttributeCommandService
    {
        Task<Result<ProductSpecificationAttribute>> InsertProductSpecificationAttribute(InsertProductSpecificationAttributeReqModel productSpecificationAttribute);
        Task<Result> UpdateProductSpecificationAttribute(UpdateProductSpecificationAttributeReqModel productSpecificationAttribute);
        Task<Result> DeleteProductSpecificationAttribute(DeleteProductSpecificationAttributeReqModel request);
    }
}
