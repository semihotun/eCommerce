using Business.Services.CategoriesAggregate.CategorySpefications.CategorySpeficationServiceModel;
using Core.Utilities.Results;
using Entities.Concrete.CategoriesAggregate;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace Business.Services.CategoriesAggregate.CategorySpefications
{
    public interface ICategorySpeficationService
    {
        Task<IDataResult<CategorySpefication>> GetByCategorySpeficationId(GetByCategorySpeficationId request);
        Task<IResult> DeleteCategorySpefication(CategorySpefication categorySpefication);
        Task<IResult> InsertCategorySpefication(CategorySpefication categorySpefication);
        Task<IResult> UpdateCategorySpefication(CategorySpefication categorySpefication);
        Task<IDataResult<List<CategorySpefication>>> GetAllCategorySpefication(GetAllCategorySpefication request);
    }
}
