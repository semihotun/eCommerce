using Business.Services.CategoriesAggregate.CategorySpefications.CategorySpeficationServiceModel;
using Core.Utilities.Results;
using Entities.Concrete.CategoriesAggregate;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace Business.Services.CategoriesAggregate.CategorySpefications
{
    public interface ICategorySpeficationService
    {
        Task<Result<CategorySpefication>> GetByCategorySpeficationId(GetByCategorySpeficationId request);
        Task<Result> DeleteCategorySpefication(CategorySpefication categorySpefication);
        Task<Result> InsertCategorySpefication(CategorySpefication categorySpefication);
        Task<Result> UpdateCategorySpefication(CategorySpefication categorySpefication);
        Task<Result<List<CategorySpefication>>> GetAllCategorySpefication(GetAllCategorySpefication request);
    }
}
