using Business.Constants;
using Core.Utilities.Aspects.Autofac.Caching;
using Core.Utilities.PagedList;
using Core.Utilities.Results;
using Entities.RequestModel.BrandAggregate.Brands;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Entities.Concrete;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using DataAccess.Repository.Read;

namespace Business.Services.BrandAggregate.Brands.Queries
{
    public class BrandQueryService : IBrandQueryService
    {
        private readonly IReadDbRepository<Brand> _brandRepository;
        public BrandQueryService(IReadDbRepository<Brand> brandRepository)
        {
            _brandRepository = brandRepository;
        }
        /// <summary>
        /// Get BrandList
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [CacheAspect]
        public async Task<Result<IPagedList<Brand>>> GetBrandList(GetBrandListReqModel request)
        {
            var result = _brandRepository.Query();
            if (request.BrandName != null)
                result = result.Where(x => x.BrandName == request.BrandName);
            var data = await result.ToPagedListAsync(request.PageIndex, request.PageSize);
            return Result.SuccessDataResult(data);
        }
        /// <summary>
        /// Get Brand
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [CacheAspect]
        public async Task<Result<Brand>> GetBrand(GetBrandReqModel request)
        {
            var data = await _brandRepository.GetAsync(x => x.Id == request.BrandId);
            return Result.SuccessDataResult(data);
        }
        /// <summary>
        /// Get Brand DropDown
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [CacheAspect]
        public async Task<Result<IEnumerable<SelectListItem>>> GetBrandDropdown(GetBrandDropdownReqModel request)
        {
            var query = from s in _brandRepository.Query()
                        select new SelectListItem
                        {
                            Text = s.BrandName,
                            Value = s.Id.ToString(),
                            Selected = s.Id == request.SelectedId
                        };
            var data = await query.ToListAsync();
            data.Insert(0, new SelectListItem(Messages.DropdownFirstItem, "0", request.SelectedId == Guid.Empty));
            return Result.SuccessDataResult<IEnumerable<SelectListItem>>(data);
        }
    }
}
