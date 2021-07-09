using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract.Products;
using Core.Aspects.Autofac.Caching;
using Core.Utilities.Infrastructure.Filter;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Others;
using Entities.ViewModels.Admin.Products.ProductStock;
using X.PagedList;

namespace Business.Concrete.Products
{
    public class ProductStockService : IProductStockService
    {
        #region Field

        private readonly IProductStockDAL _productStockDal;

        #endregion

        #region Ctor
        public ProductStockService(IProductStockDAL productStockDal)
        {
            _productStockDal = productStockDal;
        }
        #endregion   
        [CacheAspect]
        public async Task<IDataResult<IPagedList<ProductStock>>> GetAllProductStock(ProductStockFilter productStockFilter, DataTablesParam param = null)
        {
            var query = _productStockDal.Query().ApplyFilter(productStockFilter);
            var result = await query.ToPagedListAsync(param.PageIndex, param.PageSize);

            return new SuccessDataResult<IPagedList<ProductStock>>(result);
        }
        [CacheRemoveAspect("IProductStockService.Get")]
        public async Task<IResult> AddProductStock(ProductStock productStock)
        {
            _productStockDal.Add(productStock);
            await _productStockDal.SaveChangesAsync();

            return new SuccessResult();
        }
        [CacheRemoveAspect("IProductStockService.Get")]
        public async Task<IResult> DeleteProductStock(int id)
        {
            var productStock =await _productStockDal.GetAsync(x=>x.Id==id);
            _productStockDal.Delete(productStock);
            await _productStockDal.SaveChangesAsync();

            return new SuccessResult();
        }

    }
}
