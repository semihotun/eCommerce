using AutoMapper;
using Business.Services.ProductAggregate.ProductAttributeValues.ProductAttributeValueServiceModel;
using Business.Services.ProductAggregate.ProductAttributeValues.Validator;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Logging;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Logging.Serilog.Loggers;
using Core.Utilities.Interceptors;
using Core.Utilities.Results;
using DataAccess.Context;
using DataAccess.DALs.EntitiyFramework.ProductAggregate.ProductAttributeValues;
using Entities.Concrete.ProductAggregate;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;
namespace Business.Services.ProductAggregate.ProductAttributeValues
{
    public class ProductAttributeValueService : IProductAttributeValueService
    {
        #region Field
        private readonly IProductAttributeValueDAL _productAttributeValueRepository;
        private readonly IMapper _mapper;
        #endregion
        #region Ctor
        public ProductAttributeValueService(IProductAttributeValueDAL productAttributeValueRepository, IMapper mapper)
        {
            _productAttributeValueRepository = productAttributeValueRepository;
            _mapper = mapper;
        }
        #endregion
        #region Method
        [TransactionAspect(typeof(eCommerceContext))]
        [CacheRemoveAspect("IProductAttributeValueService.Get")]
        [LogAspect(typeof(MsSqlLogger))]
        public virtual async Task<IResult> DeleteProductAttributeValue(DeleteProductAttributeValue request)
        {
            if (request.Id == 0)
                return new ErrorResult();
            var deletedData = await _productAttributeValueRepository.GetAsync(x => x.Id == request.Id);
            _productAttributeValueRepository.Delete(deletedData);
            await _productAttributeValueRepository.SaveChangesAsync();
            return new SuccessResult();
        }
        [CacheAspect]
        public async Task<IDataResult<IList<ProductAttributeValue>>> GetProductAttributeValues(GetProductAttributeValues request)
        {
            var query = from pav in _productAttributeValueRepository.Query()
                        orderby pav.DisplayOrder, pav.Id
                        where pav.ProductAttributeMappingId == request.ProductAttributeMappingId
                        select pav;
            var data = await query.ToListAsync();
            return new SuccessDataResult<List<ProductAttributeValue>>(data);
        }
        [CacheAspect]
        public async Task<IDataResult<ProductAttributeValue>> GetProductAttributeValueById(GetProductAttributeValueById request)
        {
            var data = await _productAttributeValueRepository.GetAsync(x => x.Id == request.ProductAttributeValueId);
            return new SuccessDataResult<ProductAttributeValue>(data);
        }
        [ValidationAspect(typeof(CreateProductAttributeValueValidator))]
        [TransactionAspect(typeof(eCommerceContext))]
        [CacheRemoveAspect("IProductAttributeValueService.Get")]
        [LogAspect(typeof(MsSqlLogger))]
        public async Task<IResult> InsertProductAttributeValue(ProductAttributeValue productAttributeValue)
        {
            if (productAttributeValue == null)
                return new ErrorResult();
            _productAttributeValueRepository.Add(productAttributeValue);
            await _productAttributeValueRepository.SaveChangesAsync();
            return new SuccessResult();
        }
        [TransactionAspect(typeof(eCommerceContext))]
        [LogAspect(typeof(MsSqlLogger))]
        [CacheRemoveAspect("IProductAttributeValueService.Get")]
        public async Task<IResult> InsertOrUpdateProductAttributeValue(ProductAttributeValue productAttributeValue)
        {
            if (productAttributeValue == null)
                return new ErrorResult();
            if (productAttributeValue.Id == 0)
                _productAttributeValueRepository.Add(productAttributeValue);
            else
                _productAttributeValueRepository.Update(productAttributeValue);
            await _productAttributeValueRepository.SaveChangesAsync();
            return new SuccessResult();
        }
        [TransactionAspect(typeof(eCommerceContext))]
        [LogAspect(typeof(MsSqlLogger))]
        [CacheRemoveAspect("IProductAttributeValueService.Get")]
        public async Task<IResult> UpdateProductAttributeValue(ProductAttributeValue productAttributeValue)
        {
            if (productAttributeValue == null)
                return new ErrorResult();
            var data = await _productAttributeValueRepository.GetAsync(x => x.Id == productAttributeValue.Id);
            var mapData = _mapper.Map(productAttributeValue, data);
            _productAttributeValueRepository.Update(mapData);
            await _productAttributeValueRepository.SaveChangesAsync();
            return new SuccessResult();
        }
        #endregion
    }
}
