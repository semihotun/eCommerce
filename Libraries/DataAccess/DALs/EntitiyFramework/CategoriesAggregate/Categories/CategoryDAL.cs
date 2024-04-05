using Core.Aspects.Autofac.Caching;
using Core.DataAccess.EntitiyFramework;
using Core.Utilities.Results;
using DataAccess.Context;
using Entities.Concrete.CategoriesAggregate;
using Entities.Dtos.CategoryDALModels;
using Entities.ViewModels.AdminViewModel.CategoryTree;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace DataAccess.DALs.EntitiyFramework.CategoriesAggregate.Categories
{
    public class CategoryDAL : EfEntityRepositoryBase<Category, ECommerceContext>, ICategoryDAL
    {
        public CategoryDAL(ECommerceContext context) : base(context)
        {
        }
        [CacheAspect]
        private static async Task<Result<List<CategoryDTO>>> CategoriesForTreeList(CategoriesForTreeList request)
        {
            var result = new List<CategoryDTO>();
            foreach (var cat in request.Source.Where(c => c.ParentCategoryId == request.ParentId).ToList())
            {
                result.Add(new CategoryDTO
                {
                    Id = cat.Id,
                    CategoryName = cat.CategoryName,
                    ParentCategoryId = cat.ParentCategoryId,
                    SubCategory = (await CategoriesForTreeList(new CategoriesForTreeList(request.Source, cat.Id))).Data
                });
            }
            return Result.SuccessDataResult(result);
        }
        [CacheAspect]
        public async Task<Result<List<CategoryDTO>>> GetAllCategoryTreeList()
        {
            return Result.SuccessDataResult((
                await CategoriesForTreeList(
                    new CategoriesForTreeList(
                        await (from c in Context.Category select c).ToListAsync()))).Data);
        }
        [CacheAspect]
        public async Task<Result<CategorySpeficationDTO>> GetCategorySpefication(GetCategorySpefication request)
        {
            var data = await (from c in Context.Category
                              where c.Id == request.CategoryId
                              let csg = (from cs in Context.CategorySpefication
                                         where c.Id == cs.CategoryId
                                         join s in Context.SpecificationAttribute on cs.SpeficationAttributeId equals s.Id
                                         select s).AsEnumerable()
                              select new CategorySpeficationDTO
                              {
                                  Category = c,
                                  CategorySpeficationList = csg
                              }).FirstOrDefaultAsync();
            return Result.SuccessDataResult(data);
        }
        [CacheAspect]
        public async Task<Result<CategorySpeficationOptionDTO>> GetCategorySpeficationOptionDTO(GetCategorySpeficationOptionDTO request)
        {
            var data = await (from c in Context.Category
                              where c.Id == request.CategoryId
                              let csg = (from cs in Context.CategorySpefication
                                         where c.Id == cs.CategoryId
                                         join s in Context.SpecificationAttribute on cs.SpeficationAttributeId equals s.Id
                                         let speficationOptionGroup = (from speficationOption in Context.SpecificationAttributeOption
                                                                       where speficationOption.SpecificationAttributeId == s.Id
                                                                       select speficationOption).AsEnumerable()
                                         select new CategorySpeficationOptionDTO.SpecificationAttribute
                                         {
                                             Name = s.Name,
                                             DisplayOrder = s.DisplayOrder,
                                             SpecificationAttributeOptionList = speficationOptionGroup
                                         }).AsEnumerable()
                              select new CategorySpeficationOptionDTO
                              {
                                  CategorySpeficationList = csg
                              }).FirstOrDefaultAsync();
            return Result.SuccessDataResult(data);
        }
        [CacheAspect]
        public async Task<Result<List<HierarchyViewModel>>> GetHierarchy()
        {
            var hdList = await Context.Category.ToListAsync();
            var records = hdList.Where(l => l.ParentCategoryId == null)
                .Select(l => new HierarchyViewModel
                {
                    Id = l.Id,
                    text = l.CategoryName,
                    perentId = l.ParentCategoryId,
                    children = GetChildren(new GetChildren(hdList, l.Id))
                }).ToList();
            return Result.SuccessDataResult(records);
        }
        [CacheAspect]
        private static List<HierarchyViewModel> GetChildren(GetChildren request)
        {
            return request.HdList.Where(l => l.ParentCategoryId == request.ParentId)
                .Select(l => new HierarchyViewModel
                {
                    Id = l.Id,
                    text = l.CategoryName,
                    perentId = l.ParentCategoryId,
                    children = GetChildren(new GetChildren(request.HdList, l.Id))
                }).ToList();
        }
    }
}
