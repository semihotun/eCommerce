using Core.DataAccess;
using Core.Utilities.Results;
using Entities.Concrete.CategoriesAggregate;
using Entities.Dtos.CategoryDALModels;
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
