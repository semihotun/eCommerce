using Business.Services.ProductAggregate.ProductAttributeValues.ProductAttributeValueServiceModel;
using Core.Utilities.Results;
using Entities.Concrete.ProductAggregate;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace Business.Services.ProductAggregate.ProductAttributeValues
{
    public interface IProductAttributeValueService
    {
        Task<Result> DeleteProductAttributeValue(DeleteProductAttributeValue request);
        Task<Result<List<ProductAttributeValue>>> GetProductAttributeValues(GetProductAttributeValues request);
        Task<Result<ProductAttributeValue>> GetProductAttributeValueById(GetProductAttributeValueById request);
        Task<Result<ProductAttributeValue>> InsertProductAttributeValue(ProductAttributeValue productAttributeValue);
        Task<Result> InsertOrUpdateProductAttributeValue(ProductAttributeValue productAttributeValue);
        Task<Result<ProductAttributeValue>> UpdateProductAttributeValue(ProductAttributeValue productAttributeValue);
    }
}
