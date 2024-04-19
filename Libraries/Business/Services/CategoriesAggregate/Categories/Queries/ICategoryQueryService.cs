using Core.Utilities.Results;
using Entities.Concrete;
using Entities.RequestModel.CategoriesAggregate.Categories;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Services.CategoriesAggregate.Categories.Queries
{
    public interface ICategoryQueryService
    {
        Task<Result<List<Category>>> GetAllCategories();
        Task<Result<List<Category>>> GetAllCategoriesByParentCategoryId(GetAllCategoriesByParentCategoryIdReqModel request);
        Task<Result<Category>> GetCategoryById(GetCategoryByIdReqModel request);
        Task<Result<IEnumerable<SelectListItem>>> GetCategoryDropdown(GetCategoryDropdownReqModel request);
    }
}
