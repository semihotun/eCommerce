using System.Collections.Generic;
using Business.Abstract.Brands;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Business.Validation.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using X.PagedList;
using Core.Aspects.Autofac.Logging;
using Core.CrossCuttingConcerns.Logging.Serilog.Loggers;
using Core.Aspects.Autofac.Performace;

namespace Business.Concrete.Brands
{
    public class BrandService : IBrandService
    {
        #region Field
        private readonly IBrandDAL _brandRepository;
        private readonly IMapper _mapper;
        #endregion
        #region Ctor
        public BrandService(IBrandDAL brandService, IMapper mapper)
        {
            this._brandRepository = brandService;
            this._mapper = mapper;
        }
        #endregion

        #region BusinesRule
        #endregion

        #region Method

        [CacheRemoveAspect("IBrandService.Get")]
        public async Task<IResult> BrandAdd(Brand model)
        {          
            _brandRepository.Add(model);
            await _brandRepository.SaveChangesAsync();

            return new SuccessResult();
        }
   
        [CacheAspect]
        public async Task<IDataResult<IPagedList<Brand>>> GetBrandList(string brandName = null,
             int pageIndex = 1, int pageSize = int.MaxValue, string orderByText = null)
        {
            var result = _brandRepository.Query();

            if (brandName != null)
                result = result.Where(x => x.BrandName == brandName);

            var data =await result.ToPagedListAsync(pageIndex,pageSize);

            return new SuccessDataResult<IPagedList<Brand>>(data);
        }
        [CacheAspect]
        public async Task<IDataResult<Brand>> GetBrand(int brandId = 0)
        {
            var data = await _brandRepository.GetAsync(x=>x.Id==brandId);

            return new SuccessDataResult<Brand>(data);
        }

        [CacheRemoveAspect("IBrandService.Get")]
        [LogAspect(typeof(FileLogger))]
        public async Task<IResult> DeleteBrand(Brand brand)
        {
            _brandRepository.Delete(brand);
             await _brandRepository.SaveChangesAsync();
            return new SuccessResult();
        }
        [CacheRemoveAspect("IBrandService.Get")]
        public async Task<IResult> UpdateBrand(Brand brand)
        {
            var data=await _brandRepository.GetAsync(x => x.Id == brand.Id);
            data=_mapper.Map(brand,data);

            _brandRepository.Update(data);
            await _brandRepository.SaveChangesAsync();
            return new SuccessResult();
        }


        [CacheAspect]
        public async Task<IDataResult<IEnumerable<SelectListItem>>> GetBrandDropdown(int? selectedId = 0)
        {
            var query = from s in _brandRepository.Query()
                select new SelectListItem
                {
                    Text = s.BrandName,
                    Value = s.Id.ToString(),
                    Selected = (s.Id == selectedId) ? true : false
                };
            var data = await query.ToListAsync();
            return new SuccessDataResult<IEnumerable<SelectListItem>>(data);
        }
        #endregion


    }
}
