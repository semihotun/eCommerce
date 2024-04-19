using Core.Utilities.Results;
using Entities.Concrete;
using Entities.RequestModel.ProductAggregate.ProductAttributeValues;
using System.Threading.Tasks;

namespace Business.Services.ProductAggregate.ProductAttributeValues.Commands
{
    public interface IProductAttributeValueCommandService
    {
        Task<Result<ProductAttributeValue>> InsertProductAttributeValue(InsertProductAttributeValueReqModel productAttributeValue);
        Task<Result<ProductAttributeValue>> InsertOrUpdateProductAttributeValue(InsertOrUpdateProductAttributeValueReqModel productAttributeValue);
        Task<Result<ProductAttributeValue>> UpdateProductAttributeValue(UpdateProductAttributeValueReqModel productAttributeValue);
        Task<Result> DeleteProductAttributeValue(DeleteProductAttributeValueReqModel request);
    }
}
