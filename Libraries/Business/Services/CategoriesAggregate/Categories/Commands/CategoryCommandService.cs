using Business.Constants;
using Core.Const;
using Core.Utilities.Aspects.Autofac.Caching;
using Core.Utilities.Aspects.Autofac.Secure;
using Core.Utilities.Results;
using DataAccess.Repository.Write;
using DataAccess.UnitOfWork;
using Entities.Concrete;
using Entities.Extensions.AutoMapper;
using Entities.RequestModel.CategoriesAggregate.Categories;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Business.Services.CategoriesAggregate.Categories.Commands
{
    public class CategoryCommandService : ICategoryCommandService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWriteDbRepository<Category> _categoryRepository;

        public CategoryCommandService(IUnitOfWork unitOfWork, IWriteDbRepository<Category> categoryRepository)
        {
            _unitOfWork = unitOfWork;
            _categoryRepository = categoryRepository;
        }

        /// <summary>
        /// InsertCategory
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [CacheRemoveAspect("ICategory")]
        [AuthAspect(RoleConst.Admin)]
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
        [AuthAspect(RoleConst.Admin)]
        public async Task<Result> UpdateCategory(UpdateCategoryReqModel request)
        {
            return await _unitOfWork.BeginTransaction(async () =>
            {
                var category = await _categoryRepository.GetByIdAsync(request.Id);
                if (category == null)
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
        [AuthAspect(RoleConst.Admin)]
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
        [AuthAspect(RoleConst.Admin)]
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
                var deletedData = await _categoryRepository.GetByIdAsync(request.Id);
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
        [AuthAspect(RoleConst.Admin)]
        public async Task<Result> ChangeNodePosition(ChangeNodePositionReqModel request)
        {
            return await _unitOfWork.BeginTransaction(async () =>
            {
                var hd = await _categoryRepository.GetByIdAsync(request.Id);
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
        [AuthAspect(RoleConst.Admin)]
        public async Task<Result> DeleteNodes(DeleteNodesReqModel request)
        {
            return await _unitOfWork.BeginTransaction(async () =>
            {
                foreach (var splitString in request.IdsString.Split(','))
                {
                    var ss = await _categoryRepository.ToListAsync();
                    var subDeletedData = await _categoryRepository.ToListAsync(x => x.ParentCategoryId == Guid.Parse(splitString));
                    if (subDeletedData.Any())
                    {
                        foreach (var item in subDeletedData)
                        {
                            var deletedCategory = await _categoryRepository.GetByIdAsync(item.Id);
                            if (deletedCategory != null)
                            {
                                _categoryRepository.Remove(deletedCategory);
                            }
                        }
                    }
                    var deletedData = await _categoryRepository.GetByIdAsync(Guid.Parse(splitString));
                    _categoryRepository.Remove(deletedData);
                }
                return Result.SuccessResult();
            });
        }
    }
}
