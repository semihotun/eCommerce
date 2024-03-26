using Business.Constants;
using Business.Services.ProductAggregate.ProductAttributeMappings.ProductAttributeMappingServiceModel;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Logging;
using Core.CrossCuttingConcerns.Logging.Serilog.Loggers;
using Core.Utilities.Results;
using DataAccess.DALs.EntitiyFramework.ProductAggregate.ProductAttributeMappings;
using DataAccess.DALs.EntitiyFramework.ProductAggregate.ProductAttributeValues;
using DataAccess.UnitOfWork;
using Entities.Concrete.ProductAggregate;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;
namespace Business.Services.ProductAggregate.ProductAttributeMappings
{
    public class ProductAttributeMappingService : IProductAttributeMappingService
    {
        #region Field
        private readonly IProductAttributeMappingDAL _productAttributeMappingRepository;
        private readonly IProductAttributeValueDAL _productAttributeValueRepository;
        private readonly IUnitOfWork _unitOfWork;
        #endregion
        #region Ctor
        public ProductAttributeMappingService(IProductAttributeMappingDAL productAttributeMappingRepository,
                                              IProductAttributeValueDAL productAttributeValueRepository,
                                              IUnitOfWork unitOfWork)
        {
            _productAttributeMappingRepository = productAttributeMappingRepository;
            _productAttributeValueRepository = productAttributeValueRepository;
            _unitOfWork = unitOfWork;
        }
        #endregion
        #region Method
        [CacheAspect]
        public async Task<Result<IPagedList<ProductAttributeMapping>>> GetAllProductAttributeMapping(GetAllProductAttributeMapping request)
        {
            return Result.SuccessDataResult(
                await (from pam in _productAttributeMappingRepository.Query()
                       orderby pam.DisplayOrder, pam.Id
                       where pam.ProductId == request.ProductId
                       select pam).ToPagedListAsync(request.Param.PageIndex, request.Param.PageSize));
        }
        [CacheRemoveAspect("IProductAttributeMappingService.Get")]
        [LogAspect(typeof(MsSqlLogger))]
        public async Task<Result> DeleteProductAttributeMapping(DeleteProductAttributeMapping request)
        {
            return await _unitOfWork.BeginTransaction(async () =>
            {
                var productAttributeValues = await _productAttributeValueRepository.GetListAsync(x => x.ProductAttributeMappingId == request.Id);
                foreach (var item in productAttributeValues)
                {
                    var productAttributeData = await _productAttributeValueRepository.GetAsync(x => x.Id == item.Id);
                    _productAttributeValueRepository.Remove(productAttributeData);
                }
                _productAttributeMappingRepository.Remove(await _productAttributeMappingRepository.GetAsync(x => x.Id == request.Id));
                return Result.SuccessResult();
            });
        }
        [CacheAspect]
        public async Task<Result<List<ProductAttributeMapping>>> GetProductAttributeMappingsByProductId(GetProductAttributeMappingsByProductId request)
        {
            var query = from pam in _productAttributeMappingRepository.Query()
                        orderby pam.DisplayOrder, pam.Id
                        where pam.ProductId == request.ProductId
                        select pam;
            return Result.SuccessDataResult(await query.ToListAsync());
        }
        [CacheRemoveAspect("IProductAttributeMappingService.Get")]
        public async Task<Result<ProductAttributeMapping>> GetProductAttributeMappingById(GetProductAttributeMappingById request)
        {
            return Result.SuccessDataResult(
                await _productAttributeMappingRepository.GetAsync(x => x.Id == request.ProductAttributeMappingId));
        }
        [LogAspect(typeof(MsSqlLogger))]
        [CacheRemoveAspect("IProductAttributeMappingService.Get")]
        public async Task<Result<ProductAttributeMapping>> InsertProductAttributeMapping(ProductAttributeMapping productAttributeMapping)
        {
            return await _unitOfWork.BeginTransaction(async () =>
            {
                await _productAttributeMappingRepository.AddAsync(productAttributeMapping);
                return Result.SuccessDataResult(productAttributeMapping);
            });
        }
        [LogAspect(typeof(MsSqlLogger))]
        [CacheRemoveAspect("IProductAttributeMappingService.Get")]
        public async Task<Result> UpdateProductAttributeMapping(ProductAttributeMapping productAttributeMapping)
        {
            return await _unitOfWork.BeginTransaction(async () =>
            {
                _productAttributeMappingRepository.Update(productAttributeMapping);
                return Result.SuccessResult();
            });
        }
        #endregion
    }
}
