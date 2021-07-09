using Business.Abstract;
using Business.Abstract.Categories;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using X.PagedList;
using Entities.Helpers.AutoMapper;
using Core.Aspects.Autofac.Caching;

namespace Business.Concrete.Categories
{
    public class CategoryService : ICategoryService
    {
        #region fields
        private readonly ICategoryDAL _categoryRepository;
        
        #endregion
        #region ctor
        public CategoryService(
            ICategoryDAL categoryRepository)
        {
            this._categoryRepository = categoryRepository;
        }
        #endregion

        [CacheRemoveAspect("ICategoryService.Get")]
        public async Task<IResult> DeleteCategory(int id)
        {
            if (id == 0)
                return new ErrorResult();

            _categoryRepository.Delete(_categoryRepository.GetById(id));

            await _categoryRepository.SaveChangesAsync();

            return new SuccessResult();

        }
        [CacheRemoveAspect("ICategoryService.Get")]
        public async Task<IResult> RemoveRangeCategory(int id)
        {

            var deletedData = _categoryRepository.Query().Where(x => x.Id == id).ToList();
            _categoryRepository.DeleteRange(deletedData);
            await _categoryRepository.SaveChangesAsync();

            return new SuccessResult();

        }
        [CacheAspect]
        public async Task<IDataResult<IList<Category>>> GetAllCategories()
        {
            var data =await _categoryRepository.Query().ToListAsync();

            return new SuccessDataResult<List<Category>>(data);
        }
        [CacheAspect]
        public async Task<IDataResult<IList<Category>>> GetAllCategoriesByParentCategoryId(int parentCategoryId)
        {

            var result =await _categoryRepository.Query().Where(x => x.ParentCategoryId == parentCategoryId).ToListAsync();

            return new SuccessDataResult<List<Category>>(result);
        }
        [CacheAspect]
        public async Task<IDataResult<Category>> GetCategoryById(int categoryId)
        {

            var result =await _categoryRepository.GetAsync(x=>x.Id==categoryId);

            return new SuccessDataResult<Category>(result);
        }
        [CacheRemoveAspect("ICategoryService.Get")]
        public async Task<IResult> InsertCategory(Category category)
        {
            if (category == null)
                return new ErrorDataResult<Category>();

            _categoryRepository.Add(category);
            await _categoryRepository.SaveChangesAsync();
            return new SuccessResult();

        }
        [CacheRemoveAspect("ICategoryService.Get")]
        public async Task<IResult> UpdateCategory(Category category)
        {
            var data =await _categoryRepository.GetAsync(x => x.Id == category.Id);
            var mapData = data.MapTo<Category>(category);
            _categoryRepository.Update(mapData);
            await _categoryRepository.SaveChangesAsync();
            return new SuccessResult();
        }
        [CacheAspect]
        public async Task<IDataResult<IEnumerable<SelectListItem>>> GetCategoryDropdown(int? selectedId = 0)
        {
            var query = from s in _categoryRepository.Query()
                select new SelectListItem
                {
                    Text = s.CategoryName,
                    Value = s.Id.ToString(),
                    Selected = (s.Id == selectedId) ? true : false
                };
            var data = await query.ToListAsync();
            return new SuccessDataResult<IEnumerable<SelectListItem>>(data);
        }



    }
}
