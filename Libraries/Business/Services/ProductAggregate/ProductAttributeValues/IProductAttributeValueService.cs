using Core.Utilities.Results;
using Entities.Concrete.ProductAggregate;
using Entities.RequestModel.ProductAggregate.ProductAttributeValues;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace Business.Services.ProductAggregate.ProductAttributeValues
{
    public interface IProductAttributeValueService
    {
        Task<Result<ProductAttributeValue>> InsertProductAttributeValue(InsertProductAttributeValueReqModel productAttributeValue);
        Task<Result<ProductAttributeValue>> InsertOrUpdateProductAttributeValue(InsertOrUpdateProductAttributeValueReqModel productAttributeValue);
        Task<Result<ProductAttributeValue>> UpdateProductAttributeValue(UpdateProductAttributeValueReqModel productAttributeValue);
        Task<Result> DeleteProductAttributeValue(DeleteProductAttributeValueReqModel request);
        Task<Result<List<ProductAttributeValue>>> GetProductAttributeValues(GetProductAttributeValuesReqModel request);
        Task<Result<ProductAttributeValue>> GetProductAttributeValueById(GetProductAttributeValueByIdReqModel request);
    }
}
