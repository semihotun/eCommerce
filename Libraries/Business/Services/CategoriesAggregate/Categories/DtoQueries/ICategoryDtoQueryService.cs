using Core.Utilities.Results;
using Entities.Dtos.CategoryDALModels;
using Entities.RequestModel.CategoriesAggregate.CategorySpefications;
using Entities.ViewModels.AdminViewModel.CategoryTree;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Services.CategoriesAggregate.Categories.DtoQueries
{
    public interface ICategoryDtoQueryService
    {
        Task<Result<List<CategoryDTO>>> GetAllCategoryTreeList();
        Task<Result<CategorySpeficationDTO>> GetCategorySpefication(GetCategorySpeficationReqModel request);
        Task<Result<CategorySpeficationOptionDTO>> GetCategorySpeficationOptionDTO(GetCategorySpeficationOptionDTO request);
        Task<Result<List<HierarchyViewModel>>> GetHierarchy();
    }
}
