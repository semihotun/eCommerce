using Core.Utilities.Results;
using Entities.Concrete;
using Entities.RequestModel.ProductAggregate.PredefinedProductAttributeValues;
using System.Threading.Tasks;

namespace Business.Services.ProductAggregate.PredefinedProductAttributeValues.Commands
{
    public interface IPredefinedProductAttributeValueCommandService
    {
        Task<Result<PredefinedProductAttributeValue>> InsertPredefinedProductAttributeValue(InsertPredefinedProductAttributeValueReqModel ppav);
        Task<Result> UpdatePredefinedProductAttributeValue(UpdatePredefinedProductAttributeValueReqModel ppav);
        Task<Result> DeletePredefinedProductAttributeValue(DeletePredefinedProductAttributeValueReqModel ppav);
    }
}
