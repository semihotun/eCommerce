using Business.Constants;
using Core.Aspects.Autofac.Caching;
using Core.Utilities.Results;
using DataAccess.DALs.EntitiyFramework.CategoriesAggregate.Categories;
using DataAccess.UnitOfWork;
using Entities.Concrete.CategoriesAggregate;
using Entities.Extensions.AutoMapper;
using Entities.RequestModel.CategoriesAggregate.Categories;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        #region Command
        /// <summary>
        /// InsertCategory
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [CacheRemoveAspect("ICategory")]
        public async Task<Result<Category>> InsertCategory(InsertCategoryReqModel request)
        {
            return await _unitOfWork.BeginTransaction(async () =>
            {
                var data = request.MapTo<Category>();
                await _categoryRepository.AddAsync(data);
                return Result.SuccessDataResult(data);
            });
        }
        /// <summary>
        /// UpdateCategory
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [CacheRemoveAspect("ICategory")]
        public async Task<Result> UpdateCategory(UpdateCategoryReqModel request)
        {
            return await _unitOfWork.BeginTransaction(async () =>
            {
                var category = await _categoryRepository.GetAsync(x => x.Id == request.Id);
                if(category == null)
                    return Result.ErrorResult();
                var data = request.MapTo(category);
                _categoryRepository.Update(data);
                return Result.SuccessResult();
            });
        }
        /// <summary>
        /// DeleteCategory
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [CacheRemoveAspect("ICategory")]
        public async Task<Result> DeleteCategory(DeleteCategoryReqModel request)
        {
            return await _unitOfWork.BeginTransaction(async () =>
            {
                var categorydata = await _categoryRepository.GetByIdAsync(request.Id);
                if (categorydata == null)
                {
                    return Result.ErrorResult(Messages.IdNotFound);
                }
                _categoryRepository.Remove(categorydata);
                return Result.SuccessResult();
            });
        }
        /// <summary>
        /// RemoveRangeCategory
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [CacheRemoveAspect("ICategory")]
        public async Task<Result> RemoveRangeCategory(RemoveRangeCategoryReqModel request)
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
        /// <summary>
        /// Change Node Pos
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [CacheRemoveAspect("ICategory")]
        public async Task<Result> ChangeNodePosition(ChangeNodePositionReqModel request)
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
        /// <summary>
        /// Delete Nodes
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [CacheRemoveAspect("ICategory")]
        public async Task<Result> DeleteNodes(DeleteNodesReqModel request)
        {
            return await _unitOfWork.BeginTransaction(async () =>
            {
                foreach (var splitString in request.Values.Split(','))
                {
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
        #endregion
        #region Query
        /// <summary>
        /// Get All Categories
        /// </summary>
        /// <returns></returns>
        [CacheAspect]
        public async Task<Result<List<Category>>> GetAllCategories()
        {
            return Result.SuccessDataResult(await _categoryRepository.Query().ToListAsync());
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
            return Result.SuccessDataResult(await _categoryRepository.Query().Where(x => x.ParentCategoryId == request.ParentCategoryId).ToListAsync());
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
            data.Insert(0, new SelectListItem(Messages.DropdownFirstItem, "0", request.SelectedId == 0));
            return Result.SuccessDataResult<IEnumerable<SelectListItem>>(data);
        }
        #endregion
    }
}
