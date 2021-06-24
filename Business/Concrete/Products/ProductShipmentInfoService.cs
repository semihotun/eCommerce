using Business.Abstract.Products;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Helpers.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete.Products
{
    public class ProductShipmentInfoService : IProductShipmentInfoService
    {
        #region Field
        private readonly IProductShipmentInfoDAL _productShipmentInfoDAL;

        #endregion
        #region Ctor
        public ProductShipmentInfoService(IProductShipmentInfoDAL productShipmentInfoDAL)
        {
            this._productShipmentInfoDAL = productShipmentInfoDAL;
        }
        #endregion

        public async Task<IDataResult<ProductShipmentInfo>> GetProductShipmentInfo(int ProductId)
        {
            var query =await _productShipmentInfoDAL.GetAsync(x=>x.ProductId == ProductId);

            return new SuccessDataResult<ProductShipmentInfo>(query);
        }

        public async Task<IResult> AddProductShipmentInfo(ProductShipmentInfo productShipmentInfo)
        {

            _productShipmentInfoDAL.Add(productShipmentInfo);
            await _productShipmentInfoDAL.SaveChangesAsync();

            return new SuccessResult();
        }

        public async Task<IResult> UpdateProductShipmentInfo(ProductShipmentInfo productShipmentInfo)
        {
            var query = await _productShipmentInfoDAL.GetAsync(x => x.Id == productShipmentInfo.Id);
            var data = query.MapTo<ProductShipmentInfo>(productShipmentInfo);
            _productShipmentInfoDAL.Update(data);
            await _productShipmentInfoDAL.SaveChangesAsync();

            return new SuccessResult();
        }

        public async Task<IResult> AddOrUpdateProductShipmentInfo(ProductShipmentInfo productShipmentInfo)
        {
            if (productShipmentInfo.Id == 0)
                await AddProductShipmentInfo(productShipmentInfo);
            else
                await UpdateProductShipmentInfo(productShipmentInfo);

            return new SuccessResult();
        }


    }
}
