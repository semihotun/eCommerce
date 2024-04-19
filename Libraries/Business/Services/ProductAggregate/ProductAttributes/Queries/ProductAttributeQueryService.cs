using Core.Utilities.Aspects.Autofac.Caching;
using Core.Utilities.PagedList;
using Core.Utilities.Results;
using DataAccess.Repository.Write;
using Entities.Concrete;
using Entities.RequestModel.ProductAggregate.ProductAttributes;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Business.Services.ProductAggregate.ProductAttributes.Queries
{
    public class ProductAttributeQueryService : IProductAttributeQueryService
    {
        private IWriteDbRepository<ProductAttribute> _productAttributeRepository;

        public ProductAttributeQueryService(IWriteDbRepository<ProductAttribute> productAttributeRepository)
        {
            _productAttributeRepository = productAttributeRepository;
        }

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
                await _productAttributeRepository.ToListAsync());
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
        /// GetProductAttributeDropdown
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [CacheAspect]
        public async Task<Result<IEnumerable<SelectListItem>>> GetProductAttributeDropdown(GetProductAttributeDropdownReqModel request)
        {
            var data = await (from s in _productAttributeRepository.Query()
                              select new SelectListItem
                              {
                                  Text = s.Name,
                                  Value = s.Id.ToString(),
                                  Selected = s.Id == request.SelectedId
                              }).ToListAsync();
            return Result.SuccessDataResult<IEnumerable<SelectListItem>>(data);
        }
    }
}
