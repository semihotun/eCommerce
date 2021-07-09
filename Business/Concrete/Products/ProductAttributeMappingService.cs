using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract.Products;
using Entities.Others;
using Microsoft.EntityFrameworkCore;
using X.PagedList;
using Core.Aspects.Autofac.Caching;

namespace Business.Concrete.Products
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
            this._productAttributeMappingRepository = productAttributeMappingRepository;
            this._productAttributeValueRepository = productAttributeValueRepository;
        }
        #endregion

        #region Method

        [CacheAspect]
        public async Task<IDataResult<IPagedList<ProductAttributeMapping>>> GetAllProductAttributeMapping(int productId, DataTablesParam param)
        {
            var query = from pam in _productAttributeMappingRepository.Query()
                orderby pam.DisplayOrder, pam.Id
                where pam.ProductId == productId
                select pam;

            var data = await query.ToPagedListAsync(param.PageIndex, param.PageSize);

            return new SuccessDataResult<IPagedList<ProductAttributeMapping>>(data);
        }

        [CacheRemoveAspect("IProductAttributeMappingService.Get")]
        public async Task<IResult> DeleteProductAttributeMapping(int id)
        {
            if (id == 0)
                return new ErrorResult();

            var data = await _productAttributeValueRepository.
                GetListAsync(x => x.ProductAttributeMappingId == id);

            if (data.Count() != 0)
            {
                foreach (var item in data)
                {
                    var productAttributeData =await _productAttributeValueRepository.GetAsync(x=>x.Id==item.Id);
                     _productAttributeValueRepository.Delete(productAttributeData);
                }
            }
            await _productAttributeValueRepository.SaveChangesAsync();

            var mappingData = await _productAttributeMappingRepository.GetAsync(x => x.Id == id);
            _productAttributeMappingRepository.Delete(mappingData);
            await _productAttributeMappingRepository.SaveChangesAsync();
            

            return new SuccessResult();
        }
        [CacheAspect]
        public async Task<IDataResult<IList<ProductAttributeMapping>>> GetProductAttributeMappingsByProductId(int productId)
        {
            var query = from pam in _productAttributeMappingRepository.Query()
                        orderby pam.DisplayOrder, pam.Id
                        where pam.ProductId == productId
                        select pam;

            var data = await query.ToListAsync();

            return new SuccessDataResult<List<ProductAttributeMapping>>(data);
        }
        [CacheRemoveAspect("IProductAttributeMappingService.Get")]
        public async Task<IDataResult<ProductAttributeMapping>> GetProductAttributeMappingById(int productAttributeMappingId)
        {
            var data =await _productAttributeMappingRepository.GetAsync(x=>x.Id==productAttributeMappingId);

            return new SuccessDataResult<ProductAttributeMapping>(data);
        }
        [CacheRemoveAspect("IProductAttributeMappingService.Get")]
        public async Task<IResult> InsertProductAttributeMapping(ProductAttributeMapping productAttributeMapping)
        {

                if (productAttributeMapping == null)
                    return new ErrorResult();

                _productAttributeMappingRepository.Add(productAttributeMapping);
                await _productAttributeMappingRepository.SaveChangesAsync();
                return new SuccessResult();
        }
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
