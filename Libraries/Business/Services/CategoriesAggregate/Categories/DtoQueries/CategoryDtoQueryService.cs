using Core.Utilities.Aspects.Autofac.Caching;
using Core.Utilities.Results;
using DataAccess.Context;
using Entities.Concrete;
using Entities.Dtos.CategoryDALModels;
using Entities.RequestModel.CategoriesAggregate.Categories;
using Entities.RequestModel.CategoriesAggregate.CategorySpefications;
using Entities.ViewModels.AdminViewModel.CategoryTree;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Business.Services.CategoriesAggregate.Categories.DtoQueries
{
    public class CategoryDtoQueryService : ICategoryDtoQueryService
    {
        private readonly ECommerceReadContext _readContext;
        public CategoryDtoQueryService(ECommerceReadContext readContext)
        {
            _readContext = readContext;
        }
        /// <summary>
        /// CategoriesForTreeList
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [CacheAspect]
        private static async Task<Result<List<CategoryDTO>>> CategoriesForTreeList(CategoriesForTreeListReqModel request)
        {
            var result = new List<CategoryDTO>();
            foreach (var cat in request.Source.Where(c => c.ParentCategoryId == request.ParentId).ToList())
            {
                result.Add(new CategoryDTO
                {
                    Id = cat.Id,
                    CategoryName = cat.CategoryName,
                    ParentCategoryId = cat.ParentCategoryId,
                    SubCategory = (await CategoriesForTreeList(new CategoriesForTreeListReqModel(request.Source, cat.Id))).Data
                });
            }
            return Result.SuccessDataResult(result);
        }
        /// <summary>
        /// GetAllCategoryTreeList
        /// </summary>
        /// <returns></returns>
        [CacheAspect]
        public async Task<Result<List<CategoryDTO>>> GetAllCategoryTreeList()
        {
            var data= await (from c in _readContext.Query<Category>() select c).ToListAsync();
            return await CategoriesForTreeList(new(data,Guid.Empty));
        }
        /// <summary>
        /// GetCategorySpefication
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [CacheAspect]
        public async Task<Result<CategorySpeficationDTO>> GetCategorySpefication(GetCategorySpeficationReqModel request)
        {
            var data = await (from c in _readContext.Query<Category>()
                              where c.Id == request.CategoryId
                              let csg = (from cs in _readContext.Query<CategorySpefication>()
                                         where c.Id == cs.CategoryId
                                         join s in _readContext.Query<SpecificationAttribute>() on cs.SpeficationAttributeId equals s.Id
                                         select s).AsEnumerable()
                              select new CategorySpeficationDTO
                              {
                                  Category = c,
                                  CategorySpeficationList = csg
                              }).FirstOrDefaultAsync();
            return Result.SuccessDataResult(data);
        }
        /// <summary>
        /// GetCategorySpeficationOptionDTO
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [CacheAspect]
        public async Task<Result<CategorySpeficationOptionDTO>> GetCategorySpeficationOptionDTO(GetCategorySpeficationOptionDTO request)
        {
            var brandQuery = _readContext.Query<CatalogBrand>()
                     .Where(b => b.CategoryId == request.CategoryId)
                     .ToListAsync();

            var specQuery = (from cs in _readContext.Query<CategorySpefication>()
                             where cs.CategoryId == request.CategoryId
                             join s in _readContext.Query<SpecificationAttribute>() on cs.SpeficationAttributeId equals s.Id
                             let speficationOptionGroup = (from speficationOption in _readContext.Query<SpecificationAttributeOption>()
                                                           where speficationOption.SpecificationAttributeId == s.Id
                                                           select speficationOption).ToList()
                             select new CategorySpeficationOptionDTO.SpecificationAttribute
                             {
                                 Name = s.Name,
                                 DisplayOrder = s.DisplayOrder,
                                 SpecificationAttributeOptionList = speficationOptionGroup
                             }).ToListAsync();
            await Task.WhenAll(specQuery, brandQuery);
            return Result.SuccessDataResult(new CategorySpeficationOptionDTO
            {
                CategorySpeficationList = await specQuery,
                CatalogBrandList = await brandQuery
            });
        }
        /// <summary>
        /// GetHierarchy
        /// </summary>
        /// <returns></returns>
        [CacheAspect]
        public async Task<Result<List<HierarchyViewModel>>> GetHierarchy()
        {
            var hdList = await _readContext.Query<Category>().ToListAsync();
            var records = hdList.Where(l => l.ParentCategoryId == Guid.Empty)
                .Select(l => new HierarchyViewModel
                {
                    Id = l.Id,
                    text = l.CategoryName,
                    perentId = l.ParentCategoryId,
                    children = GetChildren(new GetChildrenReqModel(hdList, l.Id))
                }).ToList();
            return Result.SuccessDataResult(records);
        }
        /// <summary>
        /// GetChildren
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [CacheAspect]
        private static List<HierarchyViewModel> GetChildren(GetChildrenReqModel request)
        {
            return request.HdList.Where(l => l.ParentCategoryId == request.ParentId)
                .Select(l => new HierarchyViewModel
                {
                    Id = l.Id,
                    text = l.CategoryName,
                    perentId = l.ParentCategoryId,
                    children = GetChildren(new GetChildrenReqModel(request.HdList, l.Id))
                }).ToList();
        }
    }
}
