using Core.Utilities.Results;
using Entities.Concrete;
using Entities.RequestModel.ProductAggregate.ProductShipmentInfos;
using System.Threading.Tasks;

namespace Business.Services.ProductAggregate.ProductShipmentInfos.Queries
{
    public interface IProductShipmentInfoQueryService
    {
        Task<Result<ProductShipmentInfo>> GetProductShipmentInfo(GetProductShipmentInfoReqModel request);
    }
}
