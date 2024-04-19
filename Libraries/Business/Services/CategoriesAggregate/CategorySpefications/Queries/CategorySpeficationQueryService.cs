using Core.Utilities.Aspects.Autofac.Caching;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.RequestModel.CategoriesAggregate.CategorySpefications;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using DataAccess.Repository.Read;

namespace Business.Services.CategoriesAggregate.CategorySpefications.Queries
{
    public class CategorySpeficationQueryService : ICategorySpeficationQueryService
    {
        private readonly IReadDbRepository<CategorySpefication> _categorySpeficationRepository;

        public CategorySpeficationQueryService(IReadDbRepository<CategorySpefication> categorySpeficationRepository)
        {
            _categorySpeficationRepository = categorySpeficationRepository;
        }

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
            if (request.CategoryId != Guid.Empty)
                query = query.Where(x => x.CategoryId == request.CategoryId);
            return Result.SuccessDataResult(await query.ToListAsync());
        }
    }
}