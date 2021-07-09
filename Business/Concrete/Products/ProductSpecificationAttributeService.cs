using Business.Abstract;
using Business.Abstract.Products;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using X.PagedList;
using Core.Aspects.Autofac.Caching;

namespace Business.Concrete.Attribute.Products
{
    public class ProductSpecificationAttributeService : IProductSpecificationAttributeService
    {
        #region Field
        IProductSpecificationAttributeDAL _productSpecificationAttributeRepository;
        #endregion

        #region Ctor
        public ProductSpecificationAttributeService(IProductSpecificationAttributeDAL productSpecificationAttributeRepository)
        {
            this._productSpecificationAttributeRepository = productSpecificationAttributeRepository;
        }
        #endregion

        #region Method
        [CacheRemoveAspect("IProductShipmentInfoService.Get")]
        public async Task<IResult> DeleteProductSpecificationAttribute(int id)
        {
            var data = (await GetProductSpecificationAttributeById(id)).Data;
            _productSpecificationAttributeRepository.Delete(data);
            await _productSpecificationAttributeRepository.SaveChangesAsync();

            return new SuccessResult();

        }
        [CacheAspect]
        public async Task<IDataResult<IPagedList<ProductSpecificationAttribute>>> GetProductSpecificationAttributes(int productId = 0,
            string specificationAttributeName = null,
            int specificationAttributeOptionId = 0, bool? allowFiltering = null, bool? showOnProductPage = null,
            int pageIndex = 1, int pageSize = int.MaxValue)
        {

            var query = _productSpecificationAttributeRepository.Query();
            if (productId > 0)
                query = query.Where(psa => psa.ProductId == productId);

            if (specificationAttributeOptionId > 0)
                query = query.Where(psa => psa.SpecificationAttributeOptionId == specificationAttributeOptionId);

            if (allowFiltering.HasValue)
                query = query.Where(psa => psa.AllowFiltering == allowFiltering.Value);

            if (showOnProductPage.HasValue)
                query = query.Where(psa => psa.ShowOnProductPage == showOnProductPage.Value);


            query = query.OrderBy(psa => psa.DisplayOrder).ThenBy(psa => psa.Id);

            var data = await query.ToPagedListAsync(pageIndex, pageSize);

            return new SuccessDataResult<IPagedList<ProductSpecificationAttribute>>(data);
        }

        [CacheAspect]
        public async Task<IDataResult<ProductSpecificationAttribute>> GetProductSpecificationAttributeById(int productSpecificationAttributeId)
        {
            var data =await _productSpecificationAttributeRepository.GetAsync(x=>x.Id== productSpecificationAttributeId);

            return new SuccessDataResult<ProductSpecificationAttribute>(data);
        }
        [CacheRemoveAspect("IProductShipmentInfoService.Get")]
        public async Task<IResult> InsertProductSpecificationAttribute(ProductSpecificationAttribute productSpecificationAttribute)
        {
            if (productSpecificationAttribute == null)
                return new ErrorResult();

            _productSpecificationAttributeRepository.Add(productSpecificationAttribute);
            await _productSpecificationAttributeRepository.SaveChangesAsync();
            return new SuccessResult();
        }
        [CacheRemoveAspect("IProductShipmentInfoService.Get")]
        public async Task<IResult> UpdateProductSpecificationAttribute(ProductSpecificationAttribute productSpecificationAttribute)
        {
            if (productSpecificationAttribute == null)
                return new ErrorResult();

            _productSpecificationAttributeRepository.Update(productSpecificationAttribute);
            await _productSpecificationAttributeRepository.SaveChangesAsync();
            return new SuccessResult();
        }
        [CacheAspect]
        public async Task<IDataResult<int>> GetProductSpecificationAttributeCount(int productId = 0, int specificationAttributeOptionId = 0)
        {
            var query = _productSpecificationAttributeRepository.Query();
            if (productId > 0)
                query = query.Where(psa => psa.ProductId == productId);
            if (specificationAttributeOptionId > 0)
                query = query.Where(psa => psa.SpecificationAttributeOptionId == specificationAttributeOptionId);

            var data = await query.CountAsync();

            return new SuccessDataResult<int>(query.Count());
        }



        #endregion
    }
}
