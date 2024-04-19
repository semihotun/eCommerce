using Core.Utilities.Results;
using Entities.Concrete;
using Entities.RequestModel.ProductAggregate.ProductShipmentInfos;
using System.Threading.Tasks;

namespace Business.Services.ProductAggregate.ProductShipmentInfos.Commands
{
    public interface IProductShipmentInfoCommandService
    {
        Task<Result<ProductShipmentInfo>> AddProductShipmentInfo(AddProductShipmentInfoReqModel productShipmentInfo);
        Task<Result<ProductShipmentInfo>> UpdateProductShipmentInfo(UpdateProductShipmentInfoReqModel productShipmentInfo);
        Task<Result<ProductShipmentInfo>> AddOrUpdateProductShipmentInfo(AddOrUpdateProductShipmentInfoReqModel productShipmentInfo);
    }
}
