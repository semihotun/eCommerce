using AutoMapper;
using Business.Services.ProductAggregate.ProductAttributes.ProductAttributeServiceModel;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Logging;
using Core.CrossCuttingConcerns.Logging.Serilog.Loggers;
using Core.Utilities.Interceptors;
using Core.Utilities.Results;
using DataAccess.Context;
using DataAccess.DALs.EntitiyFramework.ProductAggregate.ProductAttributes;
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
        public ProductAttributeService(
            IProductAttributeDAL productAttributeRepository,
            IMapper mapper
            )
        {
            _productAttributeRepository = productAttributeRepository;
            _mapper = mapper;
        }
        #region Methods
        [LogAspect(typeof(MsSqlLogger))]
        [TransactionAspect(typeof(eCommerceContext))]
        [CacheRemoveAspect("IProductAttributeService.Get")]
        public async Task<IResult> DeleteProductAttribute(ProductAttribute productAttribute)
        {
            if (productAttribute == null)
                return new ErrorResult();
            _productAttributeRepository.Delete(productAttribute);
            await _productAttributeRepository.SaveChangesAsync();
            return new SuccessResult();
        }
        [CacheAspect]
        public async Task<IDataResult<IPagedList<ProductAttribute>>> GetAllProductAttributes(GetAllProductAttributes request)
        {
            var query = from pa in _productAttributeRepository.Query()
                        select pa;
            if (request.Name != null)
                query = query.Where(x => x.Name == request.Name);
            var data = await query.ToPagedListAsync(request.PageIndex, request.PageSize);
            return new SuccessDataResult<IPagedList<ProductAttribute>>(data);
        }
        [CacheAspect]
        public async Task<IDataResult<IList<ProductAttribute>>> GetAllProductAttribute()
        {
            var query = await _productAttributeRepository.Query().ToListAsync();
            return new SuccessDataResult<List<ProductAttribute>>(query);
        }
        [CacheAspect]
        public async Task<IDataResult<ProductAttribute>> GetProductAttributeById(GetProductAttributeById request)
        {
            var data = await _productAttributeRepository.GetAsync(x => x.Id == request.ProductAttributeId);
            return new SuccessDataResult<ProductAttribute>(data);
        }
        [TransactionAspect(typeof(eCommerceContext))]
        [CacheRemoveAspect("IProductAttributeService.Get")]
        [LogAspect(typeof(MsSqlLogger))]
        public async Task<IResult> InsertProductAttribute(ProductAttribute productAttribute)
        {
            if (productAttribute == null)
                return new ErrorResult();
            _productAttributeRepository.Add(productAttribute);
            await _productAttributeRepository.SaveChangesAsync();
            return new SuccessResult();
        }
        [TransactionAspect(typeof(eCommerceContext))]
        [CacheRemoveAspect("IProductAttributeService.Get")]
        [LogAspect(typeof(MsSqlLogger))]
        public async Task<IResult> UpdateProductAttribute(ProductAttribute productAttribute)
        {
            if (productAttribute == null)
                return new ErrorResult();
            var data = await _productAttributeRepository.GetAsync(x => x.Id == productAttribute.Id);
            data = _mapper.Map(productAttribute, data);
            _productAttributeRepository.Update(data);
            await _productAttributeRepository.SaveChangesAsync();
            return new SuccessResult();
        }
        [CacheAspect]
        public async Task<IDataResult<int[]>> GetNotExistingAttributes(GetNotExistingAttributes request)
        {
            var query = _productAttributeRepository.Query();
            var queryFilter = request.AttributeId.Distinct().ToArray();
            var filter = await query.Select(a => a.Id).Where(m => queryFilter.Contains(m)).ToListAsync();
            var data = queryFilter.Except(filter).ToArray();
            return new SuccessDataResult<int[]>(data);
        }
        [CacheAspect]
        public async Task<IDataResult<IEnumerable<SelectListItem>>> GetProductAttributeDropdown(GetProductAttributeDropdown request)
        {
            var query = from s in _productAttributeRepository.Query()
                        select new SelectListItem
                        {
                            Text = s.Name,
                            Value = s.Id.ToString(),
                            Selected = s.Id == request.SelectedId ? true : false
                        };
            var data = await query.ToListAsync();
            return new SuccessDataResult<IEnumerable<SelectListItem>>(data);
        }
        #endregion
    }
}
