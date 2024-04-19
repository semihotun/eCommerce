using Core.Utilities.Results;
using Entities.Concrete;
using Entities.RequestModel.ProductAggregate.PredefinedProductAttributeValues;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Services.ProductAggregate.PredefinedProductAttributeValues.Queries
{
    public interface IPredefinedProductAttributeValueQueryService
    {
        Task<Result<List<PredefinedProductAttributeValue>>> GetPredefinedProductAttributeValues(GetPredefinedProductAttributeValuesReqModel request);
        Task<Result<PredefinedProductAttributeValue>> GetPredefinedProductAttributeValueById(GetPredefinedProductAttributeValueByIdReqModel request);
    }
}
