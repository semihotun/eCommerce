using AutoMapper;
using Business.Services.BrandAggregate.Brands.BrandServiceModel;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Logging;
using Core.CrossCuttingConcerns.Logging.Serilog.Loggers;
using Core.Utilities.Interceptors;
using Core.Utilities.Results;
using DataAccess.Context;
using DataAccess.DALs.EntitiyFramework.BrandAggregate.Brands;
using Entities.Concrete.BrandAggregate;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;
namespace Business.Services.BrandAggregate.Brands
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
            _brandRepository = brandService;
            _mapper = mapper;
        }
        #endregion
        #region Method
        [LogAspect(typeof(MsSqlLogger))]
        [CacheRemoveAspect("IBrandService.Get","IBrandDAL.Get")]
        [TransactionAspect(typeof(eCommerceContext))]
        public async Task<IResult> AddBrand(Brand model)
        {
            _brandRepository.Add(model);
            await _brandRepository.SaveChangesAsync();
            return new SuccessResult();
        }
        [CacheAspect]
        public async Task<IDataResult<IPagedList<Brand>>> GetBrandList(GetBrandList request)
        {
            var result = _brandRepository.Query();
            if (request.BrandName != null)
                result = result.Where(x => x.BrandName == request.BrandName);
            var data = await result.ToPagedListAsync(request.PageIndex, request.PageSize);
            return new SuccessDataResult<IPagedList<Brand>>(data);
        }
        [CacheAspect]
        public async Task<IDataResult<Brand>> GetBrand(GetBrand request)
        {
            var data = await _brandRepository.GetAsync(x => x.Id == request.BrandId);
            return new SuccessDataResult<Brand>(data);
        }
        [CacheRemoveAspect("IBrandService.Get", "IBrandDAL.Get")]
        [LogAspect(typeof(MsSqlLogger))]
        [TransactionAspect(typeof(eCommerceContext))]
        public async Task<IResult> DeleteBrand(Brand brand)
        {
            _brandRepository.Delete(brand);
            await _brandRepository.SaveChangesAsync();
            return new SuccessResult();
        }
        [LogAspect(typeof(MsSqlLogger))]
        [CacheRemoveAspect("IBrandService.Get", "IBrandDAL.Get")]
        [TransactionAspect(typeof(eCommerceContext))]
        public async Task<IResult> UpdateBrand(Brand brand)
        {
            var data = await _brandRepository.GetAsync(x => x.Id == brand.Id);
            data = _mapper.Map(brand, data);
            _brandRepository.Update(data);
            await _brandRepository.SaveChangesAsync();
            return new SuccessResult();
        }
        [CacheAspect]
        public async Task<IDataResult<IEnumerable<SelectListItem>>> GetBrandDropdown(GetBrandDropdown request)
        {
            var query = from s in _brandRepository.Query()
                        select new SelectListItem
                        {
                            Text = s.BrandName,
                            Value = s.Id.ToString(),
                            Selected = s.Id == request.SelectedId ? true : false
                        };
            var data = await query.ToListAsync();
            data.Insert(0, new SelectListItem("Seçiniz", "0", request.SelectedId == 0));
            return new SuccessDataResult<IEnumerable<SelectListItem>>(data);
        }
        #endregion
    }
}
