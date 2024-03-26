using Business.Services.ProductAggregate.ProductAttributeCombinations.ProductAttributeCombinationServiceModel;
using Core.Utilities.Results;
using Entities.Concrete.ProductAggregate;
using System.Collections.Generic;
using System.Threading.Tasks;
using X.PagedList;
namespace Business.Services.ProductAggregate.ProductAttributeCombinations
{
    public interface IProductAttributeCombinationService
    {
        Task<Result<List<string>>> GetProductCombinationXml(GetProductCombinationXml request);
        Task<Result> AllInsertPermutationCombination(AllInsertPermutationCombination request);
        Task<Result> InsertPermutationCombination(InsertPermutationCombination request);
        Task<Result> DeleteProductAttributeCombination(DeleteProductAttributeCombination request);
        Task<Result<IPagedList<ProductAttributeCombination>>> GetAllProductAttributeCombinations(
            GetAllProductAttributeCombinations request);
        Task<Result<ProductAttributeCombination>> GetProductAttributeCombinationById(
            GetProductAttributeCombinationById request);
        Task<Result<ProductAttributeCombination>> GetProductAttributeCombinationBySku(
            GetProductAttributeCombinationBySku request);
        Task<Result> InsertProductAttributeCombination(ProductAttributeCombination combination);
        Task<Result> UpdateProductAttributeCombination(ProductAttributeCombination combination);
    }
}
