using Business.Constants;
using Core.Aspects.Autofac.Caching;
using Core.Utilities.PagedList;
using Core.Utilities.Results;
using DataAccess.DALs.EntitiyFramework.ProductAggregate.ProductSpecificationAttributes;
using DataAccess.UnitOfWork;
using Entities.Concrete.ProductAggregate;
using Entities.Extensions.AutoMapper;
using Entities.RequestModel.ProductAggregate.ProductSpecificationAttributes;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
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
        #region Command
        /// <summary>
        /// DeleteProductSpecificationAttribute
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [CacheRemoveAspect("IProductShipmentInfo")]
        public async Task<Result> DeleteProductSpecificationAttribute(DeleteProductSpecificationAttributeReqModel request)
        {
            return await _unitOfWork.BeginTransaction(async () =>
            {
                var data = await _productSpecificationAttributeRepository.GetByIdAsync(request.Id);
                if (data == null)
                    Result.ErrorResult(Messages.IdNotFound);
                _productSpecificationAttributeRepository.Remove(data);
                return Result.SuccessResult();
            });
        }
        /// <summary>
        /// InsertProductSpecificationAttribute
        /// </summary>
        /// <param name="productSpecificationAttribute"></param>
        /// <returns></returns>
        [CacheRemoveAspect("IProductShipmentInfo")]
        public async Task<Result<ProductSpecificationAttribute>> InsertProductSpecificationAttribute(InsertProductSpecificationAttributeReqModel productSpecificationAttribute)
        {
            return await _unitOfWork.BeginTransaction(async () =>
            {
                var data = productSpecificationAttribute.MapTo<ProductSpecificationAttribute>();
                await _productSpecificationAttributeRepository.AddAsync(data);
                return Result.SuccessDataResult(data);
            });
        }
        /// <summary>
        /// UpdateProductSpecificationAttribute
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [CacheRemoveAspect("IProductShipmentInfo")]
        public async Task<Result> UpdateProductSpecificationAttribute(UpdateProductSpecificationAttributeReqModel request)
        {
            return await _unitOfWork.BeginTransaction(async () =>
            {
                var data = await _productSpecificationAttributeRepository.GetByIdAsync(request.Id);
                if (data == null)
                    Result.ErrorResult(Messages.IdNotFound);
                var productSpecificationAttribute = request.MapTo(data);
                _productSpecificationAttributeRepository.Update(productSpecificationAttribute);
                return Result.SuccessResult();
            });
        }
        #endregion
        #region Query
        /// <summary>
        /// GetProductSpecificationAttributes
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [CacheAspect]
        public async Task<Result<IPagedList<ProductSpecificationAttribute>>> GetProductSpecificationAttributes(
            GetProductSpecificationAttributesReqModel request)
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
            return Result.SuccessDataResult(
                await query.ToPagedListAsync(request.PageIndex, request.PageSize));
        }
        /// <summary>
        /// GetProductSpecificationAttributeById
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [CacheAspect]
        public async Task<Result<ProductSpecificationAttribute>> GetProductSpecificationAttributeById(GetProductSpecificationAttributeByIdReqModel request)
        {
            var data = await _productSpecificationAttributeRepository.GetByIdAsync(request.ProductSpecificationAttributeId);
            return Result.SuccessDataResult(data);
        }
        /// <summary>
        /// GetProductSpecificationAttributeCount
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [CacheAspect]
        public async Task<Result<int>> GetProductSpecificationAttributeCount(GetProductSpecificationAttributeCountReqModel request)
        {
            var query = _productSpecificationAttributeRepository.Query();
            if (request.ProductId > 0)
                query = query.Where(psa => psa.ProductId == request.ProductId);
            if (request.SpecificationAttributeOptionId > 0)
                query = query.Where(psa => psa.SpecificationAttributeOptionId == request.SpecificationAttributeOptionId);
            var data = await query.CountAsync();
            return Result.SuccessDataResult(data);
        }
        #endregion
        #endregion
    }
}
