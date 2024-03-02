using Core.Utilities.Results;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using X.PagedList;
using Core.Aspects.Autofac.Caching;
using Core.Utilities.Interceptors;
using Business.Services.CategoriesAggregate.CategorySpefications.CategorySpeficationServiceModel;
using DataAccess.DALs.EntitiyFramework.CategoriesAggregate.CategorySpefications;
using DataAccess.Context;
using Entities.Concrete.CategoriesAggregate;
using Core.Aspects.Autofac.Logging;
using Core.CrossCuttingConcerns.Logging.Serilog.Loggers;
namespace Business.Services.CategoriesAggregate.CategorySpefications
{
    public class CategorySpeficationService : ICategorySpeficationService
    {
        #region Field
        private readonly ICategorySpeficationDAL _categorySpeficationRepository;
        #endregion
        #region Ctor
        public CategorySpeficationService(ICategorySpeficationDAL categorySpeficationRepository)
        {
            _categorySpeficationRepository = categorySpeficationRepository;
        }
        #endregion
        #region Method
        [CacheAspect]
        public async Task<IDataResult<CategorySpefication>> GetByCategorySpeficationId(GetByCategorySpeficationId request)
        {
            var data = await _categorySpeficationRepository.GetAsync(x => x.CategoryId == request.CategoryId &&
             x.SpeficationAttributeId == request.SpeficationId);
            return new SuccessDataResult<CategorySpefication>(data);
        }
        [LogAspect(typeof(MsSqlLogger))]
        [TransactionAspect(typeof(eCommerceContext))]
        [CacheRemoveAspect("ICategorySpeficationService.Get")]
        public async Task<IResult> DeleteCategorySpefication(CategorySpefication categorySpefication)
        {
            if (categorySpefication == null)
                return new ErrorResult();
            _categorySpeficationRepository.Delete(categorySpefication);
            await _categorySpeficationRepository.SaveChangesAsync();
            return new SuccessResult();
        }
        [LogAspect(typeof(MsSqlLogger))]
        [TransactionAspect(typeof(eCommerceContext))]
        [CacheRemoveAspect("ICategorySpeficationService.Get")]
        public async Task<IResult> InsertCategorySpefication(CategorySpefication categorySpefication)
        {
            if (categorySpefication == null)
                return new ErrorResult();
            _categorySpeficationRepository.Add(categorySpefication);
            await _categorySpeficationRepository.SaveChangesAsync();
            return new SuccessResult();
        }
        [LogAspect(typeof(MsSqlLogger))]
        [TransactionAspect(typeof(eCommerceContext))]
        [CacheRemoveAspect("ICategorySpeficationService.Get")]
        public async Task<IResult> UpdateCategorySpefication(CategorySpefication categorySpefication)
        {
            if (categorySpefication == null)
                return new ErrorResult();
            _categorySpeficationRepository.Update(categorySpefication);
            await _categorySpeficationRepository.SaveChangesAsync();
            return new SuccessResult();
        }
        [CacheAspect]
        public async Task<IDataResult<List<CategorySpefication>>> GetAllCategorySpefication(GetAllCategorySpefication request)
        {
            var query = _categorySpeficationRepository.Query();
            if (request.CategoryId != 0)
                query = query.Where(x => x.CategoryId == request.CategoryId);
            var data = await query.ToListAsync();
            return new SuccessDataResult<List<CategorySpefication>>(data);
        }
        #endregion
    }
}
