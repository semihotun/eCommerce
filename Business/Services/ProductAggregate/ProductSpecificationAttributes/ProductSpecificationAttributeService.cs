using Business.Services.ProductAggregate.ProductSpecificationAttributes.ProductSpecificationAttributeServiceModel;
using Business.Services.ProductAggregate.ProductSpecificationAttributes.Validator;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Interceptors;
using Core.Utilities.Results;
using DataAccess.Context;
using DataAccess.DALs.EntitiyFramework.ProductAggregate.ProductSpecificationAttributes;
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
        IProductSpecificationAttributeDAL _productSpecificationAttributeRepository;
        #endregion

        #region Ctor
        public ProductSpecificationAttributeService(IProductSpecificationAttributeDAL productSpecificationAttributeRepository)
        {
            _productSpecificationAttributeRepository = productSpecificationAttributeRepository;
        }
        #endregion

        #region Method
        [TransactionAspect(typeof(eCommerceContext))]
        [CacheRemoveAspect("IProductShipmentInfoService.Get")]
        public async Task<IResult> DeleteProductSpecificationAttribute(DeleteProductSpecificationAttribute request)
        {
            var data = (await GetProductSpecificationAttributeById(new GetProductSpecificationAttributeById(request.Id))).Data;
            _productSpecificationAttributeRepository.Delete(data);
            await _productSpecificationAttributeRepository.SaveChangesAsync();

            return new SuccessResult();

        }

        [CacheAspect]
        public async Task<IDataResult<IPagedList<ProductSpecificationAttribute>>> GetProductSpecificationAttributes(
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

            var data = await query.ToPagedListAsync(request.PageIndex, request.PageSize);

            return new SuccessDataResult<IPagedList<ProductSpecificationAttribute>>(data);
        }

        [CacheAspect]
        public async Task<IDataResult<ProductSpecificationAttribute>> GetProductSpecificationAttributeById(GetProductSpecificationAttributeById request)
        {
            var data = await _productSpecificationAttributeRepository.GetAsync(x => x.Id == request.productSpecificationAttributeId);

            return new SuccessDataResult<ProductSpecificationAttribute>(data);
        }

        [ValidationAspect(typeof(CreateProductSpecificationAttributeValidator))]
        [TransactionAspect(typeof(eCommerceContext))]
        [CacheRemoveAspect("IProductShipmentInfoService.Get")]
        public async Task<IResult> InsertProductSpecificationAttribute(ProductSpecificationAttribute productSpecificationAttribute)
        {
            if (productSpecificationAttribute == null)
                return new ErrorResult();

            _productSpecificationAttributeRepository.Add(productSpecificationAttribute);
            await _productSpecificationAttributeRepository.SaveChangesAsync();
            return new SuccessResult();
        }

        [TransactionAspect(typeof(eCommerceContext))]
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
        public async Task<IDataResult<int>> GetProductSpecificationAttributeCount(GetProductSpecificationAttributeCount request)
        {
            var query = _productSpecificationAttributeRepository.Query();
            if (request.ProductId > 0)
                query = query.Where(psa => psa.ProductId == request.ProductId);
            if (request.SpecificationAttributeOptionId > 0)
                query = query.Where(psa => psa.SpecificationAttributeOptionId == request.SpecificationAttributeOptionId);

            var data = await query.CountAsync();

            return new SuccessDataResult<int>(query.Count());
        }



        #endregion
    }
}
