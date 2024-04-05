using Core.Utilities.Results;
using Entities.Concrete.CategoriesAggregate;
using Entities.RequestModel.CategoriesAggregate.Categories;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace Business.Services.CategoriesAggregate.Categories
{
    public interface ICategoryService
    {
        Task<Result<Category>> InsertCategory(InsertCategoryReqModel category);
        Task<Result> UpdateCategory(UpdateCategoryReqModel category);
        Task<Result> DeleteCategory(DeleteCategoryReqModel request);
        Task<Result<List<Category>>> GetAllCategories();
        Task<Result<List<Category>>> GetAllCategoriesByParentCategoryId(GetAllCategoriesByParentCategoryIdReqModel request);
        Task<Result> RemoveRangeCategory(RemoveRangeCategoryReqModel request);
        Task<Result<Category>> GetCategoryById(GetCategoryByIdReqModel request);
        Task<Result> DeleteNodes(DeleteNodesReqModel request);
        Task<Result<IEnumerable<SelectListItem>>> GetCategoryDropdown(GetCategoryDropdownReqModel request);
        Task<Result> ChangeNodePosition(ChangeNodePositionReqModel request);
    }
}
