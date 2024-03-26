using AutoMapper;
using Business.Services.ProductAggregate.ProductAttributes.ProductAttributeServiceModel;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Logging;
using Core.CrossCuttingConcerns.Logging.Serilog.Loggers;
using Core.Utilities.Results;
using DataAccess.DALs.EntitiyFramework.ProductAggregate.ProductAttributes;
using DataAccess.UnitOfWork;
using Entities.Concrete.ProductAggregate;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using X.PagedList;
namespace Business.Services.ProductAggregate.ProductAttributes
{
    public class ProductAttributeService : IProductAttributeService
    {
        private readonly IProductAttributeDAL _productAttributeRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public ProductAttributeService(
            IProductAttributeDAL productAttributeRepository,
            IMapper mapper
,
            IUnitOfWork unitOfWork)
        {
            _productAttributeRepository = productAttributeRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        #region Methods
        [LogAspect(typeof(MsSqlLogger))]
        [CacheRemoveAspect("IProductAttributeService.Get")]
        public async Task<Result> DeleteProductAttribute(ProductAttribute productAttribute)
        {
            return await _unitOfWork.BeginTransaction(async () =>
            {
                _productAttributeRepository.Remove(productAttribute);
                return Result.SuccessResult();
            });
        }
        [CacheAspect]
        public async Task<Result<IPagedList<ProductAttribute>>> GetAllProductAttributes(GetAllProductAttributes request)
        {
            var query = from pa in _productAttributeRepository.Query()
                        select pa;
            if (request.Name != null)
                query = query.Where(x => x.Name == request.Name);
            return Result.SuccessDataResult(
                await query.ToPagedListAsync(request.PageIndex, request.PageSize));
        }
        [CacheAspect]
        public async Task<Result<List<ProductAttribute>>> GetAllProductAttribute()
        {
            return Result.SuccessDataResult(
                await _productAttributeRepository.Query().ToListAsync());
        }
        [CacheAspect]
        public async Task<Result<ProductAttribute>> GetProductAttributeById(GetProductAttributeById request)
        {
            return Result.SuccessDataResult(
                await _productAttributeRepository.GetAsync(x => x.Id == request.ProductAttributeId));
        }
        [CacheRemoveAspect("IProductAttributeService.Get")]
        [LogAspect(typeof(MsSqlLogger))]
        public async Task<Result> InsertProductAttribute(ProductAttribute productAttribute)
        {
            return await _unitOfWork.BeginTransaction(async () =>
            {
                await _productAttributeRepository.AddAsync(productAttribute);
                return Result.SuccessResult();
            });
        }
        [CacheRemoveAspect("IProductAttributeService.Get")]
        [LogAspect(typeof(MsSqlLogger))]
        public async Task<Result> UpdateProductAttribute(ProductAttribute productAttribute)
        {
            return await _unitOfWork.BeginTransaction(async () =>
            {
                var data = await _productAttributeRepository.GetAsync(x => x.Id == productAttribute.Id);
                data = _mapper.Map(productAttribute, data);
                _productAttributeRepository.Update(data);
                return Result.SuccessResult();
            });
        }
        [CacheAspect]
        public async Task<Result<int[]>> GetNotExistingAttributes(GetNotExistingAttributes request)
        {
            var queryFilter = request.AttributeId.Distinct().ToArray();
            var filter = await _productAttributeRepository.Query().Select(a => a.Id).Where(m => queryFilter.Contains(m)).ToListAsync();
            var data = queryFilter.Except(filter).ToArray();
            return Result.SuccessDataResult(data);
        }
        [CacheAspect]
        public async Task<Result<IEnumerable<SelectListItem>>> GetProductAttributeDropdown(GetProductAttributeDropdown request)
        {
            var query = from s in _productAttributeRepository.Query()
                        select new SelectListItem
                        {
                            Text = s.Name,
                            Value = s.Id.ToString(),
                            Selected = s.Id == request.SelectedId
                        };
            var data = await query.ToListAsync();
            return Result.SuccessDataResult<IEnumerable<SelectListItem>>(data);
        }
        #endregion
    }
}
