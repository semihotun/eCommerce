using Business.Services.ProductAggregate.ProductShipmentInfos.ProductShipmentInfoServiceModel;
using Core.Utilities.Results;
using Entities.Concrete.ProductAggregate;
using System.Threading.Tasks;
namespace Business.Services.ProductAggregate.ProductShipmentInfos
{
    public interface IProductShipmentInfoService
    {
        Task<Result<ProductShipmentInfo>> GetProductShipmentInfo(GetProductShipmentInfo request);
        Task<Result> AddProductShipmentInfo(ProductShipmentInfo productShipmentInfo);
        Task<Result> UpdateProductShipmentInfo(ProductShipmentInfo productShipmentInfo);
        Task<Result> AddOrUpdateProductShipmentInfo(ProductShipmentInfo productShipmentInfo);
    }
}
