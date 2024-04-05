using Business.Constants;
using Core.Aspects.Autofac.Caching;
using Core.Utilities.PagedList;
using Core.Utilities.Results;
using DataAccess.DALs.EntitiyFramework.ProductAggregate.ProductAttributes;
using DataAccess.UnitOfWork;
using Entities.Concrete.ProductAggregate;
using Entities.Extensions.AutoMapper;
using Entities.RequestModel.ProductAggregate.ProductAttributes;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
namespace Business.Services.ProductAggregate.ProductAttributes
{
    public class ProductAttributeService : IProductAttributeService
    {
        private readonly IProductAttributeDAL _productAttributeRepository;
        private readonly IUnitOfWork _unitOfWork;
        public ProductAttributeService(
            IProductAttributeDAL productAttributeRepository,
            IUnitOfWork unitOfWork)
        {
            _productAttributeRepository = productAttributeRepository;
            _unitOfWork = unitOfWork;
        }
        #region Methods
        #region Command
        /// <summary>
        /// DeleteProductAttribute
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [CacheRemoveAspect("IProductAttribute")]
        public async Task<Result> DeleteProductAttribute(DeleteProductAttributeReqModel request)
        {
            return await _unitOfWork.BeginTransaction(async () =>
            {
                var data = await _productAttributeRepository.GetByIdAsync(request.Id);
                if (data == null)
                    return Result.ErrorResult(Messages.IdNotFound);
                _productAttributeRepository.Remove(data);
                return Result.SuccessResult();
            });
        }
        /// <summary>
        /// InsertProductAttribute
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [CacheRemoveAspect("IProductAttribute")]
        public async Task<Result<ProductAttribute>> InsertProductAttribute(InsertProductAttributeReqModel request)
        {
            return await _unitOfWork.BeginTransaction(async () =>
            {
                var data = request.MapTo<ProductAttribute>();
                await _productAttributeRepository.AddAsync(data);
                return Result.SuccessDataResult(data);
            });
        }
        /// <summary>
        /// UpdateProductAttribute
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [CacheRemoveAspect("IProductAttribute")]
        public async Task<Result> UpdateProductAttribute(UpdateProductAttributeReqModel request)
        {
            return await _unitOfWork.BeginTransaction(async () =>
            {
                var productAttribute = await _productAttributeRepository.GetAsync(x => x.Id == request.Id);
                if (productAttribute == null)
                    Result.ErrorResult(Messages.IdNotFound);
                var data = request.MapTo(productAttribute);
                _productAttributeRepository.Update(data);
                return Result.SuccessResult();
            });
        }
        #endregion
        #region Query
        /// <summary>
        /// GetAllProductAttributes
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [CacheAspect]
        public async Task<Result<IPagedList<ProductAttribute>>> GetAllProductAttributes(GetAllProductAttributesReqModel request)
        {
            var query = from pa in _productAttributeRepository.Query()
                        select pa;
            if (request.Name != null)
                query = query.Where(x => x.Name == request.Name);
            return Result.SuccessDataResult(
                await query.ToPagedListAsync(request.PageIndex, request.PageSize));
        }
        /// <summary>
        /// GetAllProductAttribute
        /// </summary>
        /// <returns></returns>
        [CacheAspect]
        public async Task<Result<List<ProductAttribute>>> GetAllProductAttribute()
        {
            return Result.SuccessDataResult(
                await _productAttributeRepository.Query().ToListAsync());
        }
        /// <summary>
        /// GetProductAttributeById
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [CacheAspect]
        public async Task<Result<ProductAttribute>> GetProductAttributeById(GetProductAttributeByIdReqModel request)
        {
            return Result.SuccessDataResult(
                await _productAttributeRepository.GetAsync(x => x.Id == request.ProductAttributeId));
        }
        /// <summary>
        /// GetNotExistingAttributes
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [CacheAspect]
        public async Task<Result<int[]>> GetNotExistingAttributes(GetNotExistingAttributesReqModel request)
        {
            var queryFilter = request.AttributeId.Distinct().ToArray();
            var filter = await _productAttributeRepository.Query().Select(a => a.Id).Where(m => queryFilter.Contains(m)).ToListAsync();
            var data = queryFilter.Except(filter).ToArray();
            return Result.SuccessDataResult(data);
        }
        /// <summary>
        /// GetProductAttributeDropdown
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [CacheAspect]
        public async Task<Result<IEnumerable<SelectListItem>>> GetProductAttributeDropdown(GetProductAttributeDropdownReqModel request)
        {
            var data = await(from s in _productAttributeRepository.Query()
                        select new SelectListItem
                        {
                            Text = s.Name,
                            Value = s.Id.ToString(),
                            Selected = s.Id == request.SelectedId
                        }).ToListAsync();
            return Result.SuccessDataResult<IEnumerable<SelectListItem>>(data);
        }
        #endregion
        #endregion
    }
}
