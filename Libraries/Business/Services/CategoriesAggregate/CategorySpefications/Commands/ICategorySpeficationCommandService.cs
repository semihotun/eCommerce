using Core.Utilities.Results;
using Entities.Concrete;
using Entities.RequestModel.CategoriesAggregate.CategorySpefications;
using System.Threading.Tasks;

namespace Business.Services.CategoriesAggregate.CategorySpefications.Commands
{
    public interface ICategorySpeficationCommandService
    {
        Task<Result> DeleteCategorySpefication(DeleteCategorySpeficationReqModel categorySpefication);
        Task<Result<CategorySpefication>> InsertCategorySpefication(InsertCategorySpeficationReqModel categorySpefication);
        Task<Result> UpdateCategorySpefication(UpdateCategorySpeficationReqModel categorySpefication);
    }
}
