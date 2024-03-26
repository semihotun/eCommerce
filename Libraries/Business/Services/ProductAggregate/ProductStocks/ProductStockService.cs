using Business.Services.ProductAggregate.ProductStocks.ProductStockServiceModel;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Logging;
using Core.CrossCuttingConcerns.Logging.Serilog.Loggers;
using Core.Utilities.Infrastructure.Filter;
using Core.Utilities.Results;
using DataAccess.DALs.EntitiyFramework.ProductAggregate.ProductStocks;
using DataAccess.UnitOfWork;
using Entities.Concrete.ProductAggregate;
using System.Threading.Tasks;
using X.PagedList;
namespace Business.Services.ProductAggregate.ProductStocks
{
    public class ProductStockService : IProductStockService
    {
        #region Field
        private readonly IProductStockDAL _productStockDal;
        private readonly IUnitOfWork _unitOfWork;
        #endregion
        #region Ctor
        public ProductStockService(IProductStockDAL productStockDal, IUnitOfWork unitOfWork)
        {
            _productStockDal = productStockDal;
            _unitOfWork = unitOfWork;
        }
        #endregion   
        [CacheAspect]
        public async Task<Result<IPagedList<ProductStock>>> GetAllProductStock(GetAllProductStock request)
        {
            return Result.SuccessDataResult(await _productStockDal
                .Query()
                .ApplyFilter(request.ProductStockFilter)
                .ToPagedListAsync(request.Param.PageIndex, request.Param.PageSize));
        }
        [LogAspect(typeof(MsSqlLogger))]
        [CacheRemoveAspect("IProductStockService.Get",
        "IShowcaseDAL.GetShowCaseDto", "IShowcaseDAL.GetAllShowCaseDto")]
        public async Task<Result> AddProductStock(ProductStock productStock)
        {
            return await _unitOfWork.BeginTransaction<Result>(async () =>
            {
                await _productStockDal.AddAsync(productStock);
                return Result.SuccessResult();
            });
        }
        [LogAspect(typeof(MsSqlLogger))]
        [CacheRemoveAspect("IProductStockService.Get", "IShowcaseDAL.GetShowCaseDto",
        "IShowcaseDAL.GetAllShowCaseDto")]
        public async Task<Result> DeleteProductStock(DeleteProductStock request)
        {
            return await _unitOfWork.BeginTransaction<Result>(async () =>
            {
                _productStockDal.Remove(await _productStockDal.GetAsync(x => x.Id == request.Id));
                return Result.SuccessResult();
            });
        }
    }
}
