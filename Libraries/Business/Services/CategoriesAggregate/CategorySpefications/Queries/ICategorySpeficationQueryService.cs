using Core.Utilities.Results;
using Entities.Concrete;
using Entities.RequestModel.CategoriesAggregate.CategorySpefications;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Services.CategoriesAggregate.CategorySpefications.Queries
{
    public interface ICategorySpeficationQueryService
    {
        Task<Result<List<CategorySpefication>>> GetAllCategorySpefication(GetAllCategorySpeficationReqModel request);
        Task<Result<CategorySpefication>> GetByCategorySpeficationId(GetByCategorySpeficationIdReqModel request);
    }
}
