using Business.Constants;
using Core.Aspects.Autofac.Caching;
using Core.Utilities.Infrastructure.Filter;
using Core.Utilities.PagedList;
using Core.Utilities.Results;
using DataAccess.DALs.EntitiyFramework.ProductAggregate.ProductStocks;
using DataAccess.UnitOfWork;
using Entities.Concrete.ProductAggregate;
using Entities.Extensions.AutoMapper;
using Entities.RequestModel.ProductAggregate.ProductStocks;
using System.Threading.Tasks;
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
        #region Method
        #region Command
        /// <summary>
        /// AddProductStock
        /// </summary>
        /// <param name="productStock"></param>
        /// <returns></returns>
        [CacheRemoveAspect("IProductStock", "IShowcase")]
        public async Task<Result<ProductStock>> AddProductStock(AddProductStockReqModel productStock)
        {
            return await _unitOfWork.BeginTransaction(async () =>
            {
                var data = productStock.MapTo<ProductStock>();
                await _productStockDal.AddAsync(data);
                return Result.SuccessDataResult(data);
            });
        }
        /// <summary>
        /// DeleteProductStockReqModel
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [CacheRemoveAspect("IProductStock", "IShowcase")]
        public async Task<Result> DeleteProductStock(DeleteProductStockReqModel request)
        {
            return await _unitOfWork.BeginTransaction(async () =>
            {
                var data = await _productStockDal.GetByIdAsync(request.Id);
                if (data == null)
                    Result.ErrorResult(Messages.IdNotFound);
                _productStockDal.Remove(data);
                return Result.SuccessResult();
            });
        }
        #endregion
        #region Query
        /// <summary>
        /// GetAllProductStock
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [CacheAspect]
        public async Task<Result<IPagedList<ProductStock>>> GetAllProductStock(GetAllProductStockReqModel request)
        {
            return Result.SuccessDataResult(await _productStockDal
                .Query()
                .ApplyFilter(request.ProductStockFilter)
                .ToPagedListAsync(request.Param.PageIndex, request.Param.PageSize));
        }
        #endregion
        #endregion
    }
}
