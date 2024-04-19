using Business.Constants;
using Core.Utilities.Aspects.Autofac.Caching;
using Core.Utilities.Results;
using DataAccess.Repository.Write;
using DataAccess.UnitOfWork;
using Entities.Concrete;
using Entities.Extensions.AutoMapper;
using Entities.RequestModel.ProductAggregate.ProductStocks;
using System.Threading.Tasks;

namespace Business.Services.ProductAggregate.ProductStocks.Commands
{
    public class ProductStockCommandService : IProductStockCommandService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWriteDbRepository<ProductStock> _productStockRepository;

        public ProductStockCommandService(IUnitOfWork unitOfWork, IWriteDbRepository<ProductStock> productStockRepository)
        {
            _unitOfWork = unitOfWork;
            _productStockRepository = productStockRepository;
        }

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
                await _productStockRepository.AddAsync(data);
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
                var data = await _productStockRepository.GetByIdAsync(request.Id);
                if (data == null)
                    Result.ErrorResult(Messages.IdNotFound);
                _productStockRepository.Remove(data);
                return Result.SuccessResult();
            });
        }
    }
}
