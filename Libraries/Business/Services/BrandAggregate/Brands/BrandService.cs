using AutoMapper;
using Business.Constants;
using Business.Services.BrandAggregate.Brands.BrandServiceModel;
using Business.Validator;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Logging;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Logging.Serilog.Loggers;
using Core.Utilities.Interceptors;
using Core.Utilities.Results;
using DataAccess.Context;
using DataAccess.DALs.EntitiyFramework.BrandAggregate.Brands;
using DataAccess.UnitOfWork;
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
        private readonly IUnitOfWork _unitOfWork;
        #endregion
        #region Ctor
        public BrandService(IBrandDAL brandService, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _brandRepository = brandService;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        #endregion
        #region Method
        [LogAspect(typeof(MsSqlLogger))]
        [CacheRemoveAspect("IBrandService.Get", "IBrandDAL.Get")]
        [ValidationAspect(typeof(CreateBrandValidator))]
        public async Task<Result> AddBrand(Brand model)
        {
            return await _unitOfWork.BeginTransaction<Result>(async () =>
            {
                await _brandRepository.AddAsync(model);
                return Result.SuccessResult();
            });
        }
        [CacheAspect]
        public async Task<Result<IPagedList<Brand>>> GetBrandList(GetBrandList request)
        {
            var result = _brandRepository.Query();
            if (request.BrandName != null)
                result = result.Where(x => x.BrandName == request.BrandName);
            var data = await result.ToPagedListAsync(request.PageIndex, request.PageSize);
            return Result.SuccessDataResult(data);
        }
        [CacheAspect]
        public async Task<Result<Brand>> GetBrand(GetBrand request)
        {
            var data = await _brandRepository.GetAsync(x => x.Id == request.BrandId);
            return Result.SuccessDataResult(data);
        }
        [CacheRemoveAspect("IBrandService.Get", "IBrandDAL.Get")]
        [LogAspect(typeof(MsSqlLogger))]
        public async Task<Result> DeleteBrand(Brand brand)
        {
            return await _unitOfWork.BeginTransaction<Result>(async () =>
            {
                var brandData = await _brandRepository.GetByIdAsync(brand.Id);
                if (brandData != null)
                {
                    _brandRepository.Remove(brand);
                    return Result.SuccessResult();
                }
                return Result.ErrorResult(Messages.IdNotFound);
            });
        }
        [LogAspect(typeof(MsSqlLogger))]
        [CacheRemoveAspect("IBrandService.Get", "IBrandDAL.Get")]
        public async Task<Result> UpdateBrand(Brand brand)
        {
            return await _unitOfWork.BeginTransaction<Result>(async () =>
            {
                var data = await _brandRepository.GetAsync(x => x.Id == brand.Id);
                if (data == null)
                    return Result.ErrorResult();
                data = _mapper.Map(brand, data);
                _brandRepository.Update(data);
                return Result.SuccessResult();
            });
        }
        [CacheAspect]
        public async Task<Result<IEnumerable<SelectListItem>>> GetBrandDropdown(GetBrandDropdown request)
        {
            var query = from s in _brandRepository.Query()
                        select new SelectListItem
                        {
                            Text = s.BrandName,
                            Value = s.Id.ToString(),
                            Selected = s.Id == request.SelectedId
                        };
            var data = await query.ToListAsync();
            data.Insert(0, new SelectListItem(Messages.DropdownFirstItem, "0", request.SelectedId == 0));
            return Result.SuccessDataResult<IEnumerable<SelectListItem>>(data);
        }
        #endregion
    }
}
