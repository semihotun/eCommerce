using Business.Constants;
using Business.Services.CategoriesAggregate.Categories.CategoryServiceModel;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Logging;
using Core.CrossCuttingConcerns.Logging.Serilog.Loggers;
using Core.Utilities.Results;
using DataAccess.DALs.EntitiyFramework.CategoriesAggregate.Categories;
using DataAccess.UnitOfWork;
using Entities.Concrete.CategoriesAggregate;
using Entities.Helpers.AutoMapper;
using Microsoft.AspNetCore.Mvc;
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
        private readonly IUnitOfWork _unitOfWork;
        #endregion
        #region ctor
        public CategoryService(
            ICategoryDAL categoryRepository, IUnitOfWork unitOfWork)
        {
            _categoryRepository = categoryRepository;
            _unitOfWork = unitOfWork;
        }
        #endregion
        [LogAspect(typeof(MsSqlLogger))]
        [CacheRemoveAspect("ICategoryService.Get", "ICategoryDAL.Get")]
        public async Task<Result> DeleteCategory(DeleteCategory request)
        {
            return await _unitOfWork.BeginTransaction<Result>(async () =>
            {
                if (request.Id == 0)
                    return Result.ErrorResult(Messages.NullOrEmpty);
                var categorydata = await _categoryRepository.GetByIdAsync(request.Id);
                if (categorydata == null)
                {
                    return Result.ErrorResult(Messages.IdNotFound);
                }
                _categoryRepository.Remove(categorydata);
                return Result.SuccessResult();
            });
        }
        [LogAspect(typeof(MsSqlLogger))]
        [CacheRemoveAspect("ICategoryService.Get", "ICategoryDAL.Get")]
        public async Task<Result> RemoveRangeCategory(RemoveRangeCategory request)
        {
            return await _unitOfWork.BeginTransaction(async () =>
            {
                var subDeletedData = _categoryRepository.Query().Where(x => x.ParentCategoryId == request.Id);
                if (subDeletedData.Any())
                {
                    foreach (var item in subDeletedData)
                    {
                        var deletedCategory = _categoryRepository.Query().Where(x => x.Id == item.Id).FirstOrDefault();
                        if (deletedCategory != null)
                        {
                            _categoryRepository.Remove(deletedCategory);
                        }
                    }
                }
                var deletedData = await _categoryRepository.Query().Where(x => x.Id == request.Id).FirstOrDefaultAsync();
                _categoryRepository.Remove(deletedData);
                return Result.SuccessResult();
            });
        }
        [CacheAspect]
        public async Task<Result<List<Category>>> GetAllCategories()
        {
            return Result.SuccessDataResult(await _categoryRepository.Query().ToListAsync());
        }
        [CacheAspect]
        public async Task<Result<List<Category>>> GetAllCategoriesByParentCategoryId(
            GetAllCategoriesByParentCategoryId request)
        {
            return Result.SuccessDataResult(await _categoryRepository.Query().Where(x => x.ParentCategoryId == request.ParentCategoryId).ToListAsync());
        }
        [CacheAspect]
        public async Task<Result<Category>> GetCategoryById(GetCategoryById request)
        {
            return Result.SuccessDataResult(await _categoryRepository.GetAsync(x => x.Id == request.CategoryId));
        }
        [LogAspect(typeof(MsSqlLogger))]
        [CacheRemoveAspect("ICategoryService.Get", "ICategoryDAL.Get")]
        public async Task<Result> InsertCategory(Category category)
        {
            return await _unitOfWork.BeginTransaction(async () =>
            {
                await _categoryRepository.AddAsync(category);
                return Result.SuccessResult();
            });
        }
        [LogAspect(typeof(MsSqlLogger))]
        [CacheRemoveAspect("ICategoryService.Get", "ICategoryDAL.Get")]
        public async Task<Result> UpdateCategory(Category category)
        {
            return await _unitOfWork.BeginTransaction<Result>(async () =>
            {
                var data = await _categoryRepository.GetAsync(x => x.Id == category.Id);
                var mapData = data.MapTo<Category>(category);
                _categoryRepository.Update(mapData);
                return Result.SuccessResult();
            });
        }
        [CacheAspect]
        public async Task<Result<IEnumerable<SelectListItem>>> GetCategoryDropdown(GetCategoryDropdown request)
        {
            var query = from s in _categoryRepository.Query()
                        select new SelectListItem
                        {
                            Text = s.CategoryName,
                            Value = s.Id.ToString(),
                            Selected = s.Id == request.SelectedId
                        };
            var data = await query.ToListAsync();
            data.Insert(0, new SelectListItem(Messages.DropdownFirstItem, "0", request.SelectedId == 0));
            return Result.SuccessDataResult<IEnumerable<SelectListItem>>(data);
        }
        [LogAspect(typeof(MsSqlLogger))]
        [CacheRemoveAspect("ICategoryService.Get", "ICategoryDAL.Get")]
        public async Task<Result> ChangeNodePosition(ChangeNodePosition request)
        {
            return await _unitOfWork.BeginTransaction<Result>(async () =>
            {
                if (request.ParentId == 0)
                    request.ParentId = null;
                var hd = await _categoryRepository.Query().FirstOrDefaultAsync(x => x.Id == request.Id);
                hd.ParentCategoryId = request.ParentId;
                var update = _categoryRepository.Update(hd);
                return Result.SuccessResult();
            });
        }
        [LogAspect(typeof(MsSqlLogger))]
        [CacheRemoveAspect("ICategoryService.Get", "ICategoryDAL.Get")]
        public async Task<Result> DeleteNodes(DeleteNodes request)
        {
            return await _unitOfWork.BeginTransaction<Result>(async () =>
            {
                foreach (var splitString in request.Values.Split(','))
                {
                    await RemoveRangeCategory(new RemoveRangeCategory());
                    var requestId = int.Parse(splitString);
                    var subDeletedData = _categoryRepository.Query().Where(x => x.ParentCategoryId == requestId);
                    if (subDeletedData.Any())
                    {
                        foreach (var item in subDeletedData)
                        {
                            var deletedCategory = _categoryRepository.Query().Where(x => x.Id == item.Id).FirstOrDefault();
                            if (deletedCategory != null)
                            {
                                _categoryRepository.Remove(deletedCategory);
                            }
                        }
                    }
                    var deletedData = await _categoryRepository.Query().Where(x => x.Id == requestId).FirstOrDefaultAsync();
                    _categoryRepository.Remove(deletedData);
                }
                return Result.SuccessResult();
            });
        }
    }
}
