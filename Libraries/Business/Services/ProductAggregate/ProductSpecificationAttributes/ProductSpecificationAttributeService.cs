using Business.Services.ProductAggregate.ProductSpecificationAttributes.ProductSpecificationAttributeServiceModel;
using Business.Services.ProductAggregate.ProductSpecificationAttributes.Validator;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Logging;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Logging.Serilog.Loggers;
using Core.Utilities.Results;
using DataAccess.DALs.EntitiyFramework.ProductAggregate.ProductSpecificationAttributes;
using DataAccess.UnitOfWork;
using Entities.Concrete.ProductAggregate;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using X.PagedList;
namespace Business.Services.ProductAggregate.ProductSpecificationAttributes
{
    public class ProductSpecificationAttributeService : IProductSpecificationAttributeService
    {
        #region Field
        private readonly IProductSpecificationAttributeDAL _productSpecificationAttributeRepository;
        private readonly IUnitOfWork _unitOfWork;
        #endregion
        #region Ctor
        public ProductSpecificationAttributeService(IProductSpecificationAttributeDAL productSpecificationAttributeRepository, IUnitOfWork unitOfWork)
        {
            _productSpecificationAttributeRepository = productSpecificationAttributeRepository;
            _unitOfWork = unitOfWork;
        }
        #endregion
        #region Method
        [LogAspect(typeof(MsSqlLogger))]
        [CacheRemoveAspect("IProductShipmentInfoService.Get")]
        public async Task<Result> DeleteProductSpecificationAttribute(DeleteProductSpecificationAttribute request)
        {
            return await _unitOfWork.BeginTransaction<Result>(async () =>
            {
                _productSpecificationAttributeRepository.Remove(
                (await GetProductSpecificationAttributeById(new GetProductSpecificationAttributeById(request.Id))).Data);
                return Result.SuccessResult();
            });
        }
        [CacheAspect]
        public async Task<Result<IPagedList<ProductSpecificationAttribute>>> GetProductSpecificationAttributes(
            GetProductSpecificationAttributes request)
        {
            var query = _productSpecificationAttributeRepository.Query();
            if (request.ProductId > 0)
                query = query.Where(psa => psa.ProductId == request.ProductId);
            if (request.SpecificationAttributeOptionId > 0)
                query = query.Where(psa => psa.SpecificationAttributeOptionId == request.SpecificationAttributeOptionId);
            if (request.AllowFiltering.HasValue)
                query = query.Where(psa => psa.AllowFiltering == request.AllowFiltering.Value);
            if (request.ShowOnProductPage.HasValue)
                query = query.Where(psa => psa.ShowOnProductPage == request.ShowOnProductPage.Value);
            query = query.OrderBy(psa => psa.DisplayOrder).ThenBy(psa => psa.Id);
            return Result.SuccessDataResult<IPagedList<ProductSpecificationAttribute>>(
                await query.ToPagedListAsync(request.PageIndex, request.PageSize));
        }
        [CacheAspect]
        public async Task<Result<ProductSpecificationAttribute>> GetProductSpecificationAttributeById(GetProductSpecificationAttributeById request)
        {
            return Result.SuccessDataResult<ProductSpecificationAttribute>(
                await _productSpecificationAttributeRepository.GetAsync(x => x.Id == request.ProductSpecificationAttributeId));
        }
        [ValidationAspect(typeof(CreateProductSpecificationAttributeValidator))]
        [CacheRemoveAspect("IProductShipmentInfoService.Get")]
        [LogAspect(typeof(MsSqlLogger))]
        public async Task<Result> InsertProductSpecificationAttribute(ProductSpecificationAttribute productSpecificationAttribute)
        {
            return await _unitOfWork.BeginTransaction<Result>(async () =>
            {
                await _productSpecificationAttributeRepository.AddAsync(productSpecificationAttribute);
                return Result.SuccessResult();
            });
        }
        [CacheRemoveAspect("IProductShipmentInfoService.Get")]
        [LogAspect(typeof(MsSqlLogger))]
        public async Task<Result> UpdateProductSpecificationAttribute(ProductSpecificationAttribute productSpecificationAttribute)
        {
            return await _unitOfWork.BeginTransaction(async () =>
            {
                _productSpecificationAttributeRepository.Update(productSpecificationAttribute);
                return Result.SuccessResult();
            });
        }
        [CacheAspect]
        public async Task<Result<int>> GetProductSpecificationAttributeCount(GetProductSpecificationAttributeCount request)
        {
            var query = _productSpecificationAttributeRepository.Query();
            if (request.ProductId > 0)
                query = query.Where(psa => psa.ProductId == request.ProductId);
            if (request.SpecificationAttributeOptionId > 0)
                query = query.Where(psa => psa.SpecificationAttributeOptionId == request.SpecificationAttributeOptionId);
            var data = await query.CountAsync();
            return Result.SuccessDataResult<int>(query.Count());
        }
        #endregion
    }
}
