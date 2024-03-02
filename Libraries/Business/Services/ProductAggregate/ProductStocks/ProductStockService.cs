using Business.Services.ProductAggregate.ProductStocks.ProductStockServiceModel;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Logging;
using Core.CrossCuttingConcerns.Logging.Serilog.Loggers;
using Core.Utilities.Infrastructure.Filter;
using Core.Utilities.Interceptors;
using Core.Utilities.Results;
using DataAccess.Context;
using DataAccess.DALs.EntitiyFramework.ProductAggregate.ProductStocks;
using Entities.Concrete.ProductAggregate;
using System.Threading.Tasks;
using X.PagedList;
namespace Business.Services.ProductAggregate.ProductStocks
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
        public async Task<IDataResult<IPagedList<ProductStock>>> GetAllProductStock(GetAllProductStock request)
        {
            var query = _productStockDal.Query().ApplyFilter(request.ProductStockFilter);
            var result = await query.ToPagedListAsync(request.Param.PageIndex, request.Param.PageSize);
            return new SuccessDataResult<IPagedList<ProductStock>>(result);
        }
        [TransactionAspect(typeof(eCommerceContext))]
        [LogAspect(typeof(MsSqlLogger))]
        [CacheRemoveAspect("IProductStockService.Get", 
        "IShowcaseDAL.GetShowCaseDto", "IShowcaseDAL.GetAllShowCaseDto")]
        public async Task<IResult> AddProductStock(ProductStock productStock)
        {
            _productStockDal.Add(productStock);
            await _productStockDal.SaveChangesAsync();
            return new SuccessResult();
        }
        [TransactionAspect(typeof(eCommerceContext))]
        [LogAspect(typeof(MsSqlLogger))]
        [CacheRemoveAspect("IProductStockService.Get", "IShowcaseDAL.GetShowCaseDto", 
        "IShowcaseDAL.GetAllShowCaseDto")]
        public async Task<IResult> DeleteProductStock(DeleteProductStock request)
        {
            var productStock = await _productStockDal.GetAsync(x => x.Id == request.Id);
            _productStockDal.Delete(productStock);
            await _productStockDal.SaveChangesAsync();
            return new SuccessResult();
        }
    }
}
