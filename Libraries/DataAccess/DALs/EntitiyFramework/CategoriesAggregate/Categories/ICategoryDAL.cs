using Core.Utilities.Results;
using DataAccess.DALs.EntitiyFramework.CategoriesAggregate.Categories.CategoryDALModels;
using eCommerce.Core.DataAccess;
using Entities.Concrete.CategoriesAggregate;
using Entities.DTO.Category;
using Entities.ViewModels.AdminViewModel.CategoryTree;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace DataAccess.DALs.EntitiyFramework.CategoriesAggregate.Categories
{
    public interface ICategoryDAL : IEntityRepository<Category>
    {
        Task<Result<List<CategoryDTO>>> GetAllCategoryTreeList();
        Task<Result<CategorySpeficationDTO>> GetCategorySpefication(GetCategorySpefication request);
        Task<Result<CategorySpeficationOptionDTO>> GetCategorySpeficationOptionDTO(GetCategorySpeficationOptionDTO request);
        Task<Result<List<HierarchyViewModel>>> GetHierarchy();
    }
}
