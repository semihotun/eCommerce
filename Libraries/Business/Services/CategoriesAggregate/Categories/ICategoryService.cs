using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using X.PagedList;
using Business.Services.CategoriesAggregate.Categories.CategoryServiceModel;
using Entities.Concrete.CategoriesAggregate;
namespace Business.Services.CategoriesAggregate.Categories
{
    public interface ICategoryService
    {
        Task<IResult> DeleteCategory(DeleteCategory request);
        Task<IDataResult<IList<Category>>> GetAllCategories();
        Task<IDataResult<IList<Category>>> GetAllCategoriesByParentCategoryId(GetAllCategoriesByParentCategoryId request);
        Task<IResult> RemoveRangeCategory(RemoveRangeCategory request);
        Task<IDataResult<Category>> GetCategoryById(GetCategoryById request);
        Task<IResult> InsertCategory(Category category);
        Task<IResult> UpdateCategory(Category category);
        Task<IDataResult<IEnumerable<SelectListItem>>> GetCategoryDropdown(GetCategoryDropdown request);
        Task<IResult> ChangeNodePosition(ChangeNodePosition request);
        Task<IResult> DeleteNodes(DeleteNodes request);
    }
}
