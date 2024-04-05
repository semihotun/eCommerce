using Core.Utilities.PagedList;
using Core.Utilities.Results;
using Entities.Concrete.ProductAggregate;
using Entities.RequestModel.ProductAggregate.ProductAttributeCombinations;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace Business.Services.ProductAggregate.ProductAttributeCombinations
{
    public interface IProductAttributeCombinationService
    {
        Task<Result<ProductAttributeCombination>> InsertProductAttributeCombination(InsertProductAttributeCombinationReqModel combination);
        Task<Result> UpdateProductAttributeCombination(UpdateProductAttributeCombinationReqModel combination);
        Task<Result<List<string>>> GetProductCombinationXml(GetProductCombinationXmlReqModel request);
        Task<Result> AllInsertPermutationCombination(AllInsertPermutationCombinationReqModel request);
        Task<Result> InsertPermutationCombination(InsertPermutationCombinationReqModel request);
        Task<Result> DeleteProductAttributeCombination(DeleteProductAttributeCombinationReqModel request);
        Task<Result<IPagedList<ProductAttributeCombination>>> GetAllProductAttributeCombinations(
            GetAllProductAttributeCombinationsReqModel request);
        Task<Result<ProductAttributeCombination>> GetProductAttributeCombinationById(
            GetProductAttributeCombinationByIdReqModel request);
        Task<Result<ProductAttributeCombination>> GetProductAttributeCombinationBySku(
            GetProductAttributeCombinationBySkuReqModel request);
    }
}
