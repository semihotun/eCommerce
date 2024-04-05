using AutoMapper;
using Business.Constants;
using Core.Aspects.Autofac.Caching;
using Core.Utilities.PagedList;
using Core.Utilities.Results;
using DataAccess.DALs.EntitiyFramework.BrandAggregate.Brands;
using DataAccess.UnitOfWork;
using Entities.Concrete.BrandAggregate;
using Entities.Extensions.AutoMapper;
using Entities.RequestModel.BrandAggregate.Brands;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        #region Command
        /// <summary>
        /// Add Brand
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [CacheRemoveAspect("IBrand")]
        public async Task<Result<Brand>> AddBrand(AddBrandReqModel request)
        {
            return await _unitOfWork.BeginTransaction(async () =>
            {
                var data = request.MapTo<Brand>();
                await _brandRepository.AddAsync(data);
                return Result.SuccessDataResult(data);
            });
        }
        /// <summary>
        /// Delete Brand
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [CacheRemoveAspect("IBrand")]
        public async Task<Result> DeleteBrand(DeleteBrandReqModel request)
        {
            return await _unitOfWork.BeginTransaction(async () =>
            {
                var brandData = await _brandRepository.GetByIdAsync(request.Id);
                if (brandData != null)
                {
                    _brandRepository.Remove(brandData);
                    return Result.SuccessResult();
                }
                return Result.ErrorResult(Messages.IdNotFound);
            });
        }
        /// <summary>
        /// Update Brand
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [CacheRemoveAspect("IBrand")]
        public async Task<Result> UpdateBrand(UpdateBrandReqModel request)
        {
            return await _unitOfWork.BeginTransaction(async () =>
            {
                var data = await _brandRepository.GetAsync(x => x.Id == request.Id);
                if (data == null)
                    return Result.ErrorResult();
                data = _mapper.Map(request, data);
                _brandRepository.Update(data);
                return Result.SuccessResult();
            });
        }
        #endregion
        #region Query
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
            data.Insert(0, new SelectListItem(Messages.DropdownFirstItem, "0", request.SelectedId == 0));
            return Result.SuccessDataResult<IEnumerable<SelectListItem>>(data);
        }
        #endregion
        #endregion
    }
}
