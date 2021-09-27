using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using X.PagedList;

namespace Business.Abstract.Categories
{
    public interface ICategoryService
    {
        Task<IResult> DeleteCategory(int id);
        Task<IDataResult<IList<Category>>> GetAllCategories();
        Task<IDataResult<IList<Category>>> GetAllCategoriesByParentCategoryId(int parentCategoryId);
        Task<IResult> RemoveRangeCategory(int id);
        Task<IDataResult<Category>> GetCategoryById(int categoryId);
        Task<IResult> InsertCategory(Category category);
        Task<IResult> UpdateCategory(Category category);
        Task<IDataResult<IEnumerable<SelectListItem>>> GetCategoryDropdown(int? selectedId = 0);
        Task<IResult> ChangeNodePosition(int id, int? parentId);
        Task<IResult> DeleteNodes(string values);
        
    }
}
