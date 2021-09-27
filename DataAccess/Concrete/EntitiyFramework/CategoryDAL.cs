using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using eCommerce.Core.DataAccess;
using eCommerce.Core.DataAccess.EntitiyFramework;
using Entities.Concrete;
using Entities.DTO.Category;
using Entities.ViewModels.Admin;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntitiyFramework
{
    public class CategoryDAL : EfEntityRepositoryBase<Category, eCommerceContext>, ICategoryDAL
    {
        public CategoryDAL(eCommerceContext context) : base(context)
        {
        }
        public List<CategoryDTO> CategoriesForTreeList(IList<Category> source, int? parentId = null)
        {
            var result = new List<CategoryDTO>();
            var research = source.Where(c => c.ParentCategoryId == parentId).ToList();
            foreach (var cat in research)
            {
                var category = new CategoryDTO();
                category.Id = cat.Id;
                category.CategoryName = cat.CategoryName;
                category.ParentCategoryId = cat.ParentCategoryId;
                category.SubCategory = CategoriesForTreeList(source, cat.Id);
                result.Add(category);
            }
            return result;
        }

        public async Task<IDataResult<IList<CategoryDTO>>> GetAllCategoryTreeList()
        {
            var query = from c in Context.Category select c;
            var queryList = await query.ToListAsync();
            var result= CategoriesForTreeList(queryList.ToList());
            return new SuccessDataResult<IList<CategoryDTO>>(result);
        }

        public async Task<IDataResult<CategorySpeficationDTO>> GetCategorySpefication(int categoryId)
        {
            var query = from c in Context.Category
                        where c.Id==categoryId
                        let csg = (from cs in Context.CategorySpefication where c.Id == cs.CategoryId 
                                   join s in Context.SpecificationAttribute on cs.SpeficationAttributeId equals s.Id 
                                   select s)                               
                        select new CategorySpeficationDTO { 
                            Category=c,
                            CategorySpeficationList=csg.ToList()
                        };

            var data = await query.FirstOrDefaultAsync();
            return new SuccessDataResult<CategorySpeficationDTO>(data);
        }


        public async Task<IDataResult<CategorySpeficationOptionDTO>> GetCategorySpeficationOptionDTO(int categoryId)
        {
            var query = from c in Context.Category
                        where c.Id == categoryId
                        let csg = (from cs in Context.CategorySpefication
                                   where c.Id == cs.CategoryId
                                   join s in Context.SpecificationAttribute on cs.SpeficationAttributeId equals s.Id
                                   let speficationOptionGroup = (from speficationOption in Context.SpecificationAttributeOption
                                                                 where speficationOption.SpecificationAttributeId == s.Id
                                                                 select speficationOption)

                                   select new CategorySpeficationOptionDTO.SpecificationAttribute
                                   {
                                       Name = s.Name,
                                       DisplayOrder = s.DisplayOrder,
                                       SpecificationAttributeOptionList = speficationOptionGroup.ToList()
                                   })
                        select new CategorySpeficationOptionDTO
                        {
                            CategorySpeficationList = csg.ToList()
                        };
                   

            var data = await query.FirstOrDefaultAsync();
            return new SuccessDataResult<CategorySpeficationOptionDTO>(data);
        }



        public async Task<IDataResult<IList<HierarchyViewModel>>> GetHierarchy()
        {
            var hdList =await Context.Category.ToListAsync();

            var records = hdList.Where(l => l.ParentCategoryId == null)
                .Select(l => new HierarchyViewModel
                {
                    Id = l.Id,
                    text = l.CategoryName,
                    perentId = l.ParentCategoryId,
                    children = GetChildren(hdList, l.Id)
                }).ToList();

            return new SuccessDataResult<List<HierarchyViewModel>> (records);
        }

        private List<HierarchyViewModel> GetChildren(IList<Category> hdList, int parentId)
        {
            return hdList.Where(l => l.ParentCategoryId == parentId)
                .Select(l => new HierarchyViewModel
                {
                    Id = l.Id,
                    text = l.CategoryName,
                    perentId = l.ParentCategoryId,
                    children = GetChildren(hdList, l.Id)
                }).ToList();
        }






    }
}
