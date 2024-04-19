using Core.Utilities.Results;
using Entities.Concrete;
using Entities.RequestModel.ProductAggregate.ProductAttributeValues;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Services.ProductAggregate.ProductAttributeValues.Queries
{
    public interface IProductAttributeValueQueryService
    {
        Task<Result<List<ProductAttributeValue>>> GetProductAttributeValues(GetProductAttributeValuesReqModel request);
        Task<Result<ProductAttributeValue>> GetProductAttributeValueById(GetProductAttributeValueByIdReqModel request);
    }
}
