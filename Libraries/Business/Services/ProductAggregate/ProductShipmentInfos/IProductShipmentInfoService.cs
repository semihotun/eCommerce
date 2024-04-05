using Core.Utilities.Results;
using Entities.Concrete.ProductAggregate;
using Entities.RequestModel.ProductAggregate.ProductShipmentInfos;
using System.Threading.Tasks;
namespace Business.Services.ProductAggregate.ProductShipmentInfos
{
    public interface IProductShipmentInfoService
    {
        Task<Result<ProductShipmentInfo>> GetProductShipmentInfo(GetProductShipmentInfoReqModel request);
        Task<Result<ProductShipmentInfo>> AddProductShipmentInfo(AddProductShipmentInfoReqModel productShipmentInfo);
        Task<Result<ProductShipmentInfo>> UpdateProductShipmentInfo(UpdateProductShipmentInfoReqModel productShipmentInfo);
        Task<Result<ProductShipmentInfo>> AddOrUpdateProductShipmentInfo(AddOrUpdateProductShipmentInfoReqModel productShipmentInfo);
    }
}
