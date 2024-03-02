using Business.Services.ProductAggregate.PredefinedProductAttributeValues.PredefinedProductAttributeValueServiceModel;
using Core.Utilities.Results;
using Entities.Concrete.ProductAggregate;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace Business.Services.ProductAggregate.PredefinedProductAttributeValues
{
    public interface IPredefinedProductAttributeValueService
    {
        Task<IResult> DeletePredefinedProductAttributeValue(PredefinedProductAttributeValue ppav);
        Task<IDataResult<IList<PredefinedProductAttributeValue>>> GetPredefinedProductAttributeValues(GetPredefinedProductAttributeValues request);
        Task<IDataResult<PredefinedProductAttributeValue>> GetPredefinedProductAttributeValueById(GetPredefinedProductAttributeValueById request);
        Task<IResult> InsertPredefinedProductAttributeValue(PredefinedProductAttributeValue ppav);
        Task<IResult> UpdatePredefinedProductAttributeValue(PredefinedProductAttributeValue ppav);
    }
}
