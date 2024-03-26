using Business.Services.CategoriesAggregate.Categories.CategoryServiceModel;
using Core.Utilities.Results;
using Entities.Concrete.CategoriesAggregate;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace Business.Services.CategoriesAggregate.Categories
{
    public interface ICategoryService
    {
        Task<Result> DeleteCategory(DeleteCategory request);
        Task<Result<List<Category>>> GetAllCategories();
        Task<Result<List<Category>>> GetAllCategoriesByParentCategoryId(GetAllCategoriesByParentCategoryId request);
        Task<Result> RemoveRangeCategory(RemoveRangeCategory request);
        Task<Result<Category>> GetCategoryById(GetCategoryById request);
        Task<Result> InsertCategory(Category category);
        Task<Result> UpdateCategory(Category category);
        Task<Result<IEnumerable<SelectListItem>>> GetCategoryDropdown(GetCategoryDropdown request);
        Task<Result> ChangeNodePosition(ChangeNodePosition request);
        Task<Result> DeleteNodes(DeleteNodes request);
    }
}
