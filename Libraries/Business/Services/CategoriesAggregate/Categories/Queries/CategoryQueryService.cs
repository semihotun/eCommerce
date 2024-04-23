using Business.Constants;
using Core.Utilities.Aspects.Autofac.Caching;
using Core.Utilities.Results;
using DataAccess.Repository.Read;
using Entities.Concrete;
using Entities.RequestModel.CategoriesAggregate.Categories;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Business.Services.CategoriesAggregate.Categories.Queries
{
    public class CategoryQueryService : ICategoryQueryService
    {
        private readonly IReadDbRepository<Category> _categoryRepository;
        public CategoryQueryService(IReadDbRepository<Category> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        #region Query
        /// <summary>
        /// Get All Categories
        /// </summary>
        /// <returns></returns>
        [CacheAspect]
        public async Task<Result<List<Category>>> GetAllCategories()
        {
            return Result.SuccessDataResult(await _categoryRepository.ToListAsync());
        }
        /// <summary>
        /// Get All Categories Parent Id
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [CacheAspect]
        public async Task<Result<List<Category>>> GetAllCategoriesByParentCategoryId(
            GetAllCategoriesByParentCategoryIdReqModel request)
        {
            return Result.SuccessDataResult(await _categoryRepository.ToListAsync(x => x.ParentCategoryId == request.ParentCategoryId));
        }
        /// <summary>
        /// Get CategoryById
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [CacheAspect]
        public async Task<Result<Category>> GetCategoryById(GetCategoryByIdReqModel request)
        {
            return Result.SuccessDataResult(await _categoryRepository.GetAsync(x => x.Id == request.CategoryId));
        }
        /// <summary>
        /// Get DropDown
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [CacheAspect]
        public async Task<Result<IEnumerable<SelectListItem>>> GetCategoryDropdown(GetCategoryDropdownReqModel request)
        {
            var query = from s in _categoryRepository.Query()
                        select new SelectListItem
                        {
                            Text = s.CategoryName,
                            Value = s.Id.ToString(),
                            Selected = s.Id == request.SelectedId
                        };
            var data = await query.ToListAsync();
            data.Insert(0, new SelectListItem(Messages.DropdownFirstItem, "0", request.SelectedId == Guid.Empty));
            return Result.SuccessDataResult<IEnumerable<SelectListItem>>(data);
        }
        #endregion
    }
}
