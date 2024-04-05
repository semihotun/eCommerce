using Core.Utilities.Results;
using Entities.Concrete.ProductAggregate;
using Entities.RequestModel.ProductAggregate.PredefinedProductAttributeValues;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace Business.Services.ProductAggregate.PredefinedProductAttributeValues
{
    public interface IPredefinedProductAttributeValueService
    {
        Task<Result> DeletePredefinedProductAttributeValue(DeletePredefinedProductAttributeValueReqModel ppav);
        Task<Result<List<PredefinedProductAttributeValue>>> GetPredefinedProductAttributeValues(GetPredefinedProductAttributeValuesReqModel request);
        Task<Result<PredefinedProductAttributeValue>> GetPredefinedProductAttributeValueById(GetPredefinedProductAttributeValueByIdReqModel request);
        Task<Result<PredefinedProductAttributeValue>> InsertPredefinedProductAttributeValue(InsertPredefinedProductAttributeValueReqModel ppav);
        Task<Result> UpdatePredefinedProductAttributeValue(UpdatePredefinedProductAttributeValueReqModel ppav);
    }
}
