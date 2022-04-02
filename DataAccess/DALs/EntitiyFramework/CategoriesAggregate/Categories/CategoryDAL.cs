using Core.Utilities.Results;
using DataAccess.Context;
using DataAccess.DALs.EntitiyFramework.CategoriesAggregate.Categories.CategoryDALModels;
using eCommerce.Core.DataAccess.EntitiyFramework;
using Entities.Concrete.CategoriesAggregate;
using Entities.DTO.Category;
using Entities.ViewModels.AdminViewModel.CategoryTree;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess.DALs.EntitiyFramework.CategoriesAggregate.Categories
{
    public class CategoryDAL : EfEntityRepositoryBase<Category, eCommerceContext>, ICategoryDAL
    {
        public CategoryDAL(eCommerceContext context) : base(context)
        {
        }
        private async Task<IDataResult<List<CategoryDTO>>> CategoriesForTreeList(CategoriesForTreeList request)
        {
            var result = new List<CategoryDTO>();
            var research = request.Source.Where(c => c.ParentCategoryId == request.ParentId).ToList();
            foreach (var cat in research)
            {
                var category = new CategoryDTO();
                category.Id = cat.Id;
                category.CategoryName = cat.CategoryName;
                category.ParentCategoryId = cat.ParentCategoryId;
                category.SubCategory = (await CategoriesForTreeList(new CategoriesForTreeList(request.Source, cat.Id))).Data;
                result.Add(category);
            }
            return new SuccessDataResult<List<CategoryDTO>>(result);
        }

        public async Task<IDataResult<List<CategoryDTO>>> GetAllCategoryTreeList()
        {
            var query = from c in Context.Category select c;
            var queryList = await query.ToListAsync();
            var result = (await CategoriesForTreeList(new CategoriesForTreeList(queryList.ToList()))).Data;

            return new SuccessDataResult<List<CategoryDTO>>(result);
        }

        public async Task<IDataResult<CategorySpeficationDTO>> GetCategorySpefication(GetCategorySpefication request)
        {
            var query = from c in Context.Category
                        where c.Id == request.CategoryId
                        let csg = from cs in Context.CategorySpefication
                                  where c.Id == cs.CategoryId
                                  join s in Context.SpecificationAttribute on cs.SpeficationAttributeId equals s.Id
                                  select s
                        select new CategorySpeficationDTO
                        {
                            Category = c,
                            CategorySpeficationList = csg.ToList()
                        };

            var data = await query.FirstOrDefaultAsync();
            return new SuccessDataResult<CategorySpeficationDTO>(data);
        }


        public async Task<IDataResult<CategorySpeficationOptionDTO>> GetCategorySpeficationOptionDTO(GetCategorySpeficationOptionDTO request)
        {
            var query = from c in Context.Category
                        where c.Id == request.CategoryId
                        let csg = from cs in Context.CategorySpefication
                                  where c.Id == cs.CategoryId
                                  join s in Context.SpecificationAttribute on cs.SpeficationAttributeId equals s.Id
                                  let speficationOptionGroup = from speficationOption in Context.SpecificationAttributeOption
                                                               where speficationOption.SpecificationAttributeId == s.Id
                                                               select speficationOption

                                  select new CategorySpeficationOptionDTO.SpecificationAttribute
                                  {
                                      Name = s.Name,
                                      DisplayOrder = s.DisplayOrder,
                                      SpecificationAttributeOptionList = speficationOptionGroup.ToList()
                                  }
                        select new CategorySpeficationOptionDTO
                        {
                            CategorySpeficationList = csg.ToList()
                        };


            var data = await query.FirstOrDefaultAsync();
            return new SuccessDataResult<CategorySpeficationOptionDTO>(data);
        }



        public async Task<IDataResult<IList<HierarchyViewModel>>> GetHierarchy()
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

            return new SuccessDataResult<List<HierarchyViewModel>>(records);
        }

        private List<HierarchyViewModel> GetChildren(GetChildren request)
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
