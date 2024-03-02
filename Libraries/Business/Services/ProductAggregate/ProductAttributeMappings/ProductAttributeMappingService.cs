using Business.Services.ProductAggregate.ProductAttributeMappings.ProductAttributeMappingServiceModel;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Logging;
using Core.CrossCuttingConcerns.Logging.Serilog.Loggers;
using Core.Utilities.Interceptors;
using Core.Utilities.Results;
using DataAccess.Context;
using DataAccess.DALs.EntitiyFramework.ProductAggregate.ProductAttributeMappings;
using DataAccess.DALs.EntitiyFramework.ProductAggregate.ProductAttributeValues;
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
        #endregion
        #region Ctor
        public ProductAttributeMappingService(IProductAttributeMappingDAL productAttributeMappingRepository,
                                              IProductAttributeValueDAL productAttributeValueRepository)
        {
            _productAttributeMappingRepository = productAttributeMappingRepository;
            _productAttributeValueRepository = productAttributeValueRepository;
        }
        #endregion
        #region Method
        [CacheAspect]
        public async Task<IDataResult<IPagedList<ProductAttributeMapping>>> GetAllProductAttributeMapping(GetAllProductAttributeMapping request)
        {
            var query = from pam in _productAttributeMappingRepository.Query()
                        orderby pam.DisplayOrder, pam.Id
                        where pam.ProductId == request.ProductId
                        select pam;
            var data = await query.ToPagedListAsync(request.Param.PageIndex, request.Param.PageSize);
            return new SuccessDataResult<IPagedList<ProductAttributeMapping>>(data);
        }
        [CacheRemoveAspect("IProductAttributeMappingService.Get")]
        [TransactionAspect(typeof(eCommerceContext))]
        [LogAspect(typeof(MsSqlLogger))]
        public async Task<IResult> DeleteProductAttributeMapping(DeleteProductAttributeMapping request)
        {
            if (request.Id == 0)
                return new ErrorResult();
            var data = await _productAttributeValueRepository.
                GetListAsync(x => x.ProductAttributeMappingId == request.Id);
            if (data.Count() != 0)
            {
                foreach (var item in data)
                {
                    var productAttributeData = await _productAttributeValueRepository.GetAsync(x => x.Id == item.Id);
                    _productAttributeValueRepository.Delete(productAttributeData);
                }
            }
            await _productAttributeValueRepository.SaveChangesAsync();
            var mappingData = await _productAttributeMappingRepository.GetAsync(x => x.Id == request.Id);
            _productAttributeMappingRepository.Delete(mappingData);
            await _productAttributeMappingRepository.SaveChangesAsync();
            return new SuccessResult();
        }
        [CacheAspect]
        public async Task<IDataResult<IList<ProductAttributeMapping>>> GetProductAttributeMappingsByProductId(GetProductAttributeMappingsByProductId request)
        {
            var query = from pam in _productAttributeMappingRepository.Query()
                        orderby pam.DisplayOrder, pam.Id
                        where pam.ProductId == request.ProductId
                        select pam;
            var data = await query.ToListAsync();
            return new SuccessDataResult<List<ProductAttributeMapping>>(data);
        }
        [TransactionAspect(typeof(eCommerceContext))]
        [CacheRemoveAspect("IProductAttributeMappingService.Get")]
        public async Task<IDataResult<ProductAttributeMapping>> GetProductAttributeMappingById(GetProductAttributeMappingById request)
        {
            var data = await _productAttributeMappingRepository.GetAsync(x => x.Id == request.ProductAttributeMappingId);
            return new SuccessDataResult<ProductAttributeMapping>(data);
        }
        [TransactionAspect(typeof(eCommerceContext))]
        [LogAspect(typeof(MsSqlLogger))]
        [CacheRemoveAspect("IProductAttributeMappingService.Get")]
        public async Task<IResult> InsertProductAttributeMapping(ProductAttributeMapping productAttributeMapping)
        {
            if (productAttributeMapping == null)
                return new ErrorResult();
            _productAttributeMappingRepository.Add(productAttributeMapping);
            await _productAttributeMappingRepository.SaveChangesAsync();
            return new SuccessResult();
        }
        [TransactionAspect(typeof(eCommerceContext))]
        [LogAspect(typeof(MsSqlLogger))]
        [CacheRemoveAspect("IProductAttributeMappingService.Get")]
        public async Task<IResult> UpdateProductAttributeMapping(ProductAttributeMapping productAttributeMapping)
        {
            if (productAttributeMapping == null)
                return new ErrorResult();
            _productAttributeMappingRepository.Update(productAttributeMapping);
            await _productAttributeMappingRepository.SaveChangesAsync();
            return new SuccessResult();
        }
        #endregion
    }
}
