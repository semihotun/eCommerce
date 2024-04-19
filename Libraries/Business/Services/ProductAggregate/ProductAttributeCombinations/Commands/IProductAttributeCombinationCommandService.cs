using Core.Utilities.Results;
using Entities.Concrete;
using Entities.RequestModel.ProductAggregate.ProductAttributeCombinations;
using System.Threading.Tasks;

namespace Business.Services.ProductAggregate.ProductAttributeCombinations.Commands
{
    public interface IProductAttributeCombinationCommandService
    {
        Task<Result<ProductAttributeCombination>> InsertProductAttributeCombination(InsertProductAttributeCombinationReqModel combination);
        Task<Result> UpdateProductAttributeCombination(UpdateProductAttributeCombinationReqModel combination);
        Task<Result> AllInsertPermutationCombination(AllInsertPermutationCombinationReqModel request);
        Task<Result> InsertPermutationCombination(InsertPermutationCombinationReqModel request);
        Task<Result> DeleteProductAttributeCombination(DeleteProductAttributeCombinationReqModel request);
    }
}
