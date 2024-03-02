using Business.Services.CategoriesAggregate.Categories.CategoryServiceModel;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Logging;
using Core.CrossCuttingConcerns.Logging.Serilog.Loggers;
using Core.Utilities.Interceptors;
using Core.Utilities.Results;
using DataAccess.Context;
using DataAccess.DALs.EntitiyFramework.CategoriesAggregate.Categories;
using Entities.Concrete.CategoriesAggregate;
using Entities.Helpers.AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;
namespace Business.Services.CategoriesAggregate.Categories
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
            _categoryRepository = categoryRepository;
        }
        #endregion
        [LogAspect(typeof(MsSqlLogger))]
        [CacheRemoveAspect("ICategoryService.Get", "ICategoryDAL.Get")]
        [TransactionAspect(typeof(eCommerceContext))]
        public async Task<IResult> DeleteCategory(DeleteCategory request)
        {
            if (request.Id == 0)
                return new ErrorResult();
            _categoryRepository.Delete(_categoryRepository.GetById(request.Id));
            await _categoryRepository.SaveChangesAsync();
            return new SuccessResult();
        }
        [LogAspect(typeof(MsSqlLogger))]
        [TransactionAspect(typeof(eCommerceContext))]
        [CacheRemoveAspect("ICategoryService.Get", "ICategoryDAL.Get")]
        public async Task<IResult> RemoveRangeCategory(RemoveRangeCategory request)
        {
            RemoveGroup(new RemoveGroup(request.Id));
            var deletedData = _categoryRepository.Query().Where(x => x.Id == request.Id).FirstOrDefault();
            _categoryRepository.Delete(deletedData);
            _categoryRepository.SaveChanges();
            return new SuccessResult();
        }
        [CacheAspect]
        public async Task<IDataResult<IList<Category>>> GetAllCategories()
        {
            var data = await _categoryRepository.Query().ToListAsync();
            return new SuccessDataResult<List<Category>>(data);
        }
        [CacheAspect]
        public async Task<IDataResult<IList<Category>>> GetAllCategoriesByParentCategoryId(
            GetAllCategoriesByParentCategoryId request)
        {
            var result = await _categoryRepository.Query().Where(x => x.ParentCategoryId == request.ParentCategoryId).ToListAsync();
            return new SuccessDataResult<List<Category>>(result);
        }
        [CacheAspect]
        public async Task<IDataResult<Category>> GetCategoryById(GetCategoryById request)
        {
            var result = await _categoryRepository.GetAsync(x => x.Id == request.CategoryId);
            return new SuccessDataResult<Category>(result);
        }
        [LogAspect(typeof(MsSqlLogger))]
        [TransactionAspect(typeof(eCommerceContext))]
        [CacheRemoveAspect("ICategoryService.Get", "ICategoryDAL.Get")]
        public async Task<IResult> InsertCategory(Category category)
        {
            if (category == null)
                return new ErrorDataResult<Category>();
            _categoryRepository.Add(category);
            await _categoryRepository.SaveChangesAsync();
            return new SuccessResult();
        }
        [LogAspect(typeof(MsSqlLogger))]
        [TransactionAspect(typeof(eCommerceContext))]
        [CacheRemoveAspect("ICategoryService.Get", "ICategoryDAL.Get")]
        public async Task<IResult> UpdateCategory(Category category)
        {
            var data = await _categoryRepository.GetAsync(x => x.Id == category.Id);
            var mapData = data.MapTo<Category>(category);
            _categoryRepository.Update(mapData);
            await _categoryRepository.SaveChangesAsync();
            return new SuccessResult();
        }
        [CacheAspect]
        public async Task<IDataResult<IEnumerable<SelectListItem>>> GetCategoryDropdown(GetCategoryDropdown request)
        {
            var query = from s in _categoryRepository.Query()
                        select new SelectListItem
                        {
                            Text = s.CategoryName,
                            Value = s.Id.ToString(),
                            Selected = s.Id == request.SelectedId ? true : false
                        };
            var data = await query.ToListAsync();
            data.Insert(0, new SelectListItem("Seçiniz", "0", request.SelectedId == 0));
            return new SuccessDataResult<IEnumerable<SelectListItem>>(data);
        }
        [TransactionAspect(typeof(eCommerceContext))]
        [LogAspect(typeof(MsSqlLogger))]
        [CacheRemoveAspect("ICategoryService.Get", "ICategoryDAL.Get")]
        public async Task<IResult> ChangeNodePosition(ChangeNodePosition request)
        {
            if (request.ParentId == 0)
                request.ParentId = null;
            var hd = await _categoryRepository.Query().FirstOrDefaultAsync(x => x.Id == request.Id);
            hd.ParentCategoryId = request.ParentId;
            var update = _categoryRepository.Update(hd);
            return new SuccessResult();
        }
        [TransactionAspect(typeof(eCommerceContext))]
        [LogAspect(typeof(MsSqlLogger))]
        [CacheRemoveAspect("ICategoryService.Get", "ICategoryDAL.Get")]
        public async Task<IResult> DeleteNodes(DeleteNodes request)
        {
            var ids = request.Values.Split(',');
            foreach (var item in ids)
            {
                await RemoveRangeCategory(new RemoveRangeCategory(int.Parse(item)));
            }
            return new SuccessResult();
        }
        private void RemoveGroup(RemoveGroup request)
        {
            var subDeletedData = _categoryRepository.Query().Where(x => x.ParentCategoryId == request.Id);
            if (subDeletedData.Count() > 0)
            {
                foreach (var item in subDeletedData)
                {
                    var deletedData = _categoryRepository.Query().Where(x => x.Id == item.Id).FirstOrDefault();
                    _categoryRepository.Delete(deletedData);
                }
            }
        }
    }
}
