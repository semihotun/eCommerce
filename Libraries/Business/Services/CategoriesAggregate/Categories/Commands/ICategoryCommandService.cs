using Core.Utilities.Results;
using Entities.Concrete;
using Entities.RequestModel.CategoriesAggregate.Categories;
using System.Threading.Tasks;

namespace Business.Services.CategoriesAggregate.Categories.Commands
{
    public interface ICategoryCommandService
    {
        Task<Result<Category>> InsertCategory(InsertCategoryReqModel category);
        Task<Result> UpdateCategory(UpdateCategoryReqModel category);
        Task<Result> DeleteCategory(DeleteCategoryReqModel request);
        Task<Result> RemoveRangeCategory(RemoveRangeCategoryReqModel request);
        Task<Result> DeleteNodes(DeleteNodesReqModel request);
        Task<Result> ChangeNodePosition(ChangeNodePositionReqModel request);
    }
}
