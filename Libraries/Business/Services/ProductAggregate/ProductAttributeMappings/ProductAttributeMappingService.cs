using Core.Aspects.Autofac.Caching;
using Core.Utilities.PagedList;
using Core.Utilities.Results;
using DataAccess.DALs.EntitiyFramework.ProductAggregate.ProductAttributeMappings;
using DataAccess.DALs.EntitiyFramework.ProductAggregate.ProductAttributeValues;
using DataAccess.UnitOfWork;
using Entities.Concrete.ProductAggregate;
using Entities.Extensions.AutoMapper;
using Entities.RequestModel.ProductAggregate.ProductAttributeMappings;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        #region Command
        /// <summary>
        /// InsertProductAttributeMapping
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [CacheRemoveAspect("IProductAttributeMapping")]
        public async Task<Result<ProductAttributeMapping>> InsertProductAttributeMapping(InsertProductAttributeMappingReqModel request)
        {
            return await _unitOfWork.BeginTransaction(async () =>
            {
                var data = request.MapTo<ProductAttributeMapping>();
                await _productAttributeMappingRepository.AddAsync(data);
                return Result.SuccessDataResult(data);
            });
        }
        /// <summary>
        /// UpdateProductAttributeMapping
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [CacheRemoveAspect("IProductAttributeMapping")]
        public async Task<Result> UpdateProductAttributeMapping(UpdateProductAttributeMappingReqModel request)
        {
            return await _unitOfWork.BeginTransaction(async () =>
            {
                var productAttributeMapping =await _productAttributeMappingRepository.GetByIdAsync(request.Id);
                if (productAttributeMapping == null)
                    return Result.ErrorResult();
                var data = request.MapTo(productAttributeMapping);
                _productAttributeMappingRepository.Update(data);
                return Result.SuccessResult();
            });
        }
        /// <summary>
        /// DeleteProductAttributeMapping
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [CacheRemoveAspect("IProductAttributeMapping")]
        public async Task<Result> DeleteProductAttributeMapping(DeleteProductAttributeMappingReqModel request)
        {
            return await _unitOfWork.BeginTransaction(async () =>
            {
                var data = await _productAttributeMappingRepository.GetAsync(x => x.Id == request.Id);
                if(data == null)
                    return Result.ErrorResult();
                var productAttributeValues = await _productAttributeValueRepository.GetListAsync(x => x.ProductAttributeMappingId == request.Id);
                foreach (var item in productAttributeValues)
                {
                    var productAttributeData = await _productAttributeValueRepository.GetAsync(x => x.Id == item.Id);
                    if(productAttributeData != null)
                    {
                        _productAttributeValueRepository.Remove(productAttributeData);
                    }
                }
                _productAttributeMappingRepository.Remove(data);
                return Result.SuccessResult();
            });
        }
        #endregion
        #region Query
        /// <summary>
        /// GetAllProductAttributeMapping
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [CacheAspect]
        public async Task<Result<IPagedList<ProductAttributeMapping>>> GetAllProductAttributeMapping(GetAllProductAttributeMappingReqModel request)
        {
            return Result.SuccessDataResult(
                await (from pam in _productAttributeMappingRepository.Query()
                       orderby pam.DisplayOrder, pam.Id
                       where pam.ProductId == request.ProductId
                       select pam).ToPagedListAsync(request.Param.PageIndex, request.Param.PageSize));
        }
        /// <summary>
        /// GetProductAttributeMappingsByProductId
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [CacheAspect]
        public async Task<Result<List<ProductAttributeMapping>>> GetProductAttributeMappingsByProductId(GetProductAttributeMappingsByProductIdReqModel request)
        {
            var query = from pam in _productAttributeMappingRepository.Query()
                        orderby pam.DisplayOrder, pam.Id
                        where pam.ProductId == request.ProductId
                        select pam;
            return Result.SuccessDataResult(await query.ToListAsync());
        }
        /// <summary>
        /// GetProductAttributeMappingById
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [CacheRemoveAspect("IProductAttributeMapping")]
        public async Task<Result<ProductAttributeMapping>> GetProductAttributeMappingById(GetProductAttributeMappingByIdReqModel request)
        {
            return Result.SuccessDataResult(
                await _productAttributeMappingRepository.GetAsync(x => x.Id == request.ProductAttributeMappingId));
        }
        #endregion
        #endregion
    }
}
