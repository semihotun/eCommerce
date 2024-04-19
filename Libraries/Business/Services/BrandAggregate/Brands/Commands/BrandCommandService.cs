using Business.Constants;
using Core.Utilities.Aspects.Autofac.Caching;
using Core.Utilities.Results;
using DataAccess.Repository.Write;
using DataAccess.UnitOfWork;
using Entities.Concrete;
using Entities.Extensions.AutoMapper;
using Entities.RequestModel.BrandAggregate.Brands;
using System.Threading.Tasks;

namespace Business.Services.BrandAggregate.Brands.Commands
{
    public class BrandCommandService : IBrandCommandService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWriteDbRepository<Brand> _brandRepository;

        public BrandCommandService(IUnitOfWork unitOfWork, IWriteDbRepository<Brand> brandRepository)
        {
            _unitOfWork = unitOfWork;
            _brandRepository = brandRepository;
        }

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
                var data = await _brandRepository.GetByIdAsync(request.Id);
                if (data == null)
                    return Result.ErrorResult();
                data = request.MapTo(data);
                _brandRepository.Update(data);
                return Result.SuccessResult();
            });
        }
    }
}
