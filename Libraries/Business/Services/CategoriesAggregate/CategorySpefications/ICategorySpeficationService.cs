using Core.Utilities.Results;
using Entities.Concrete.CategoriesAggregate;
using Entities.RequestModel.CategoriesAggregate.CategorySpefications;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace Business.Services.CategoriesAggregate.CategorySpefications
{
    public interface ICategorySpeficationService
    {
        Task<Result<CategorySpefication>> GetByCategorySpeficationId(GetByCategorySpeficationIdReqModel request);
        Task<Result> DeleteCategorySpefication(DeleteCategorySpeficationReqModel categorySpefication);
        Task<Result<CategorySpefication>> InsertCategorySpefication(InsertCategorySpeficationReqModel categorySpefication);
        Task<Result> UpdateCategorySpefication(UpdateCategorySpeficationReqModel categorySpefication);
        Task<Result<List<CategorySpefication>>> GetAllCategorySpefication(GetAllCategorySpeficationReqModel request);
    }
}
