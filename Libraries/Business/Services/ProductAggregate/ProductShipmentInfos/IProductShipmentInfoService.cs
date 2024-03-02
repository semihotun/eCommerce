using Business.Services.ProductAggregate.ProductShipmentInfos.ProductShipmentInfoServiceModel;
using Core.Utilities.Results;
using Entities.Concrete.ProductAggregate;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
namespace Business.Services.ProductAggregate.ProductShipmentInfos
{
    public interface IProductShipmentInfoService
    {
        Task<IDataResult<ProductShipmentInfo>> GetProductShipmentInfo(GetProductShipmentInfo request);
        Task<IResult> AddProductShipmentInfo(ProductShipmentInfo productShipmentInfo);
        Task<IResult> UpdateProductShipmentInfo(ProductShipmentInfo productShipmentInfo);
        Task<IResult> AddOrUpdateProductShipmentInfo(ProductShipmentInfo productShipmentInfo);
    }
}
