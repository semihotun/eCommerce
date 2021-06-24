using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract.Products
{
    public interface IProductAttributeValueService
    {
        Task<IResult> DeleteProductAttributeValue(int id);
        Task<IDataResult<IList<ProductAttributeValue>>> GetProductAttributeValues(int productAttributeMappingId);
        Task<IDataResult<ProductAttributeValue>> GetProductAttributeValueById(int productAttributeValueId);
        Task<IResult> InsertProductAttributeValue(ProductAttributeValue productAttributeValue);
        Task<IResult> InsertOrUpdateProductAttributeValue(ProductAttributeValue productAttributeValue);
        Task<IResult> UpdateProductAttributeValue(ProductAttributeValue productAttributeValue);
    }
}
