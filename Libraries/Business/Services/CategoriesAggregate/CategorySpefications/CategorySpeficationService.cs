using Business.Services.CategoriesAggregate.CategorySpefications.CategorySpeficationServiceModel;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Logging;
using Core.CrossCuttingConcerns.Logging.Serilog.Loggers;
using Core.Utilities.Results;
using DataAccess.DALs.EntitiyFramework.CategoriesAggregate.CategorySpefications;
using DataAccess.UnitOfWork;
using Entities.Concrete.CategoriesAggregate;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Business.Services.CategoriesAggregate.CategorySpefications
{
    public class CategorySpeficationService : ICategorySpeficationService
    {
        #region Field
        private readonly ICategorySpeficationDAL _categorySpeficationRepository;
        private readonly IUnitOfWork _unitOfWork;
        #endregion
        #region Ctor
        public CategorySpeficationService(ICategorySpeficationDAL categorySpeficationRepository, IUnitOfWork unitOfWork)
        {
            _categorySpeficationRepository = categorySpeficationRepository;
            _unitOfWork = unitOfWork;
        }
        #endregion
        #region Method
        [CacheAspect]
        public async Task<Result<CategorySpefication>> GetByCategorySpeficationId(GetByCategorySpeficationId request)
        {
            return Result.SuccessDataResult(await _categorySpeficationRepository.GetAsync(x => x.CategoryId == request.CategoryId &&
             x.SpeficationAttributeId == request.SpeficationId));
        }
        [LogAspect(typeof(MsSqlLogger))]

        [CacheRemoveAspect("ICategorySpeficationService.Get")]
        public async Task<Result> DeleteCategorySpefication(CategorySpefication categorySpefication)
        {
            return await _unitOfWork.BeginTransaction<Result>(async () =>
            {
                _categorySpeficationRepository.Remove(categorySpefication);
                return Result.SuccessResult();
            });
        }
        [LogAspect(typeof(MsSqlLogger))]
        [CacheRemoveAspect("ICategorySpeficationService.Get")]
        public async Task<Result> InsertCategorySpefication(CategorySpefication categorySpefication)
        {
            return await _unitOfWork.BeginTransaction<Result>(async () =>
            {
                if (categorySpefication == null)
                    return Result.ErrorResult();
                await _categorySpeficationRepository.AddAsync(categorySpefication);
                return Result.SuccessResult();
            });
        }
        [LogAspect(typeof(MsSqlLogger))]
        [CacheRemoveAspect("ICategorySpeficationService.Get")]
        public async Task<Result> UpdateCategorySpefication(CategorySpefication categorySpefication)
        {
            return await _unitOfWork.BeginTransaction(async () =>
            {
                if (categorySpefication == null)
                    return Result.ErrorResult();
                _categorySpeficationRepository.Update(categorySpefication);
                return Result.SuccessResult();
            });
        }
        [CacheAspect]
        public async Task<Result<List<CategorySpefication>>> GetAllCategorySpefication(GetAllCategorySpefication request)
        {
            var query = _categorySpeficationRepository.Query();
            if (request.CategoryId != 0)
                query = query.Where(x => x.CategoryId == request.CategoryId);
            return Result.SuccessDataResult(await query.ToListAsync());
        }
        #endregion
    }
}
