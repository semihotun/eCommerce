using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract.Products
{
    public interface IProductShipmentInfoService
    {
        Task<IDataResult<ProductShipmentInfo>> GetProductShipmentInfo(int ProductId);
        Task<IResult> AddProductShipmentInfo(ProductShipmentInfo productShipmentInfo);
        Task<IResult> UpdateProductShipmentInfo(ProductShipmentInfo productShipmentInfo);
        Task<IResult> AddOrUpdateProductShipmentInfo(ProductShipmentInfo productShipmentInfo);
    }
}
