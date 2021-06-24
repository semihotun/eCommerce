using Core.Utilities.Results;
using Entities.Concrete;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Business.Abstract.Categories
{
    public interface ICategorySpeficationService
    {
        Task<IDataResult<CategorySpefication>> GetByCategorySpeficationId(int speficationId, int categoryId);
        Task<IResult> DeleteCategorySpefication(CategorySpefication categorySpefication);
        Task<IResult> InsertCategorySpefication(CategorySpefication categorySpefication);
        Task<IResult> UpdateCategorySpefication(CategorySpefication categorySpefication);
        Task<IDataResult<List<CategorySpefication>>> GetAllCategorySpefication(int categoryId = 0);
    }
}
