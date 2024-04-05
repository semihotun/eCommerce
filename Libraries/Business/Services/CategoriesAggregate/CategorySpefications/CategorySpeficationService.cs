using Business.Constants;
using Core.Aspects.Autofac.Caching;
using Core.Utilities.Results;
using DataAccess.DALs.EntitiyFramework.CategoriesAggregate.CategorySpefications;
using DataAccess.UnitOfWork;
using Entities.Concrete.CategoriesAggregate;
using Entities.Extensions.AutoMapper;
using Entities.RequestModel.CategoriesAggregate.CategorySpefications;
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
        #region Command
        /// <summary>
        /// DeleteCategorySpefication
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [CacheRemoveAspect("ICategorySpeficationService")]
        public async Task<Result> DeleteCategorySpefication(DeleteCategorySpeficationReqModel request)
        {
            return await _unitOfWork.BeginTransaction(async () =>
            {
                var categorySpefication = await _categorySpeficationRepository.GetByIdAsync(request.Id);
                if (categorySpefication == null)
                    return Result.ErrorResult(Messages.IdNotFound);
                _categorySpeficationRepository.Remove(categorySpefication);
                return Result.SuccessResult();
            });
        }
        /// <summary>
        /// InsertCategorySpefication
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [CacheRemoveAspect("ICategorySpeficationService")]
        public async Task<Result<CategorySpefication>> InsertCategorySpefication(InsertCategorySpeficationReqModel request)
        {
            return await _unitOfWork.BeginTransaction(async () =>
            {
                var data = request.MapTo<CategorySpefication>();
                await _categorySpeficationRepository.AddAsync(data);
                return Result.SuccessDataResult(data);
            });
        }
        /// <summary>
        /// UpdateCategorySpefication
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [CacheRemoveAspect("ICategorySpeficationService")]
        public async Task<Result> UpdateCategorySpefication(UpdateCategorySpeficationReqModel request)
        {
            return await _unitOfWork.BeginTransaction(async () =>
            {
                var categorySpefication = await _categorySpeficationRepository.GetByIdAsync(request.Id);
                if (categorySpefication != null)
                    return Result.ErrorResult();
                var data = request.MapTo(categorySpefication);
                _categorySpeficationRepository.Update(categorySpefication);
                return Result.SuccessResult();
            });
        }
        #endregion
        #region Query
        /// <summary>
        /// GetByCategorySpeficationId
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [CacheAspect]
        public async Task<Result<CategorySpefication>> GetByCategorySpeficationId(GetByCategorySpeficationIdReqModel request)
        {
            return Result.SuccessDataResult(await _categorySpeficationRepository.GetAsync(x => x.CategoryId == request.CategoryId &&
             x.SpeficationAttributeId == request.SpeficationId));
        }
        /// <summary>
        /// GetAllCategorySpefication
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [CacheAspect]
        public async Task<Result<List<CategorySpefication>>> GetAllCategorySpefication(GetAllCategorySpeficationReqModel request)
        {
            var query = _categorySpeficationRepository.Query();
            if (request.CategoryId != 0)
                query = query.Where(x => x.CategoryId == request.CategoryId);
            return Result.SuccessDataResult(await query.ToListAsync());
        }
        #endregion
        #endregion
    }
}
