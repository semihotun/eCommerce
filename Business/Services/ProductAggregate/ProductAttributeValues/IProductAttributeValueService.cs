using Business.Services.ProductAggregate.ProductAttributeValues.ProductAttributeValueServiceModel;
using Core.Utilities.Results;
using Entities.Concrete.ProductAggregate;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.ProductAggregate.ProductAttributeValues
{
    public interface IProductAttributeValueService
    {
        Task<IResult> DeleteProductAttributeValue(DeleteProductAttributeValue request);
        Task<IDataResult<IList<ProductAttributeValue>>> GetProductAttributeValues(GetProductAttributeValues request);
        Task<IDataResult<ProductAttributeValue>> GetProductAttributeValueById(GetProductAttributeValueById request);
        Task<IResult> InsertProductAttributeValue(ProductAttributeValue productAttributeValue);
        Task<IResult> InsertOrUpdateProductAttributeValue(ProductAttributeValue productAttributeValue);
        Task<IResult> UpdateProductAttributeValue(ProductAttributeValue productAttributeValue);
    }
}
