using Business.Services.ProductAggregate.PredefinedProductAttributeValues.PredefinedProductAttributeValueServiceModel;
using Core.Utilities.Results;
using Entities.Concrete.ProductAggregate;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace Business.Services.ProductAggregate.PredefinedProductAttributeValues
{
    public interface IPredefinedProductAttributeValueService
    {
        Task<Result> DeletePredefinedProductAttributeValue(PredefinedProductAttributeValue ppav);
        Task<Result<List<PredefinedProductAttributeValue>>> GetPredefinedProductAttributeValues(GetPredefinedProductAttributeValues request);
        Task<Result<PredefinedProductAttributeValue>> GetPredefinedProductAttributeValueById(GetPredefinedProductAttributeValueById request);
        Task<Result> InsertPredefinedProductAttributeValue(PredefinedProductAttributeValue ppav);
        Task<Result> UpdatePredefinedProductAttributeValue(PredefinedProductAttributeValue ppav);
    }
}
