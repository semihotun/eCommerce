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
        Task<IDataResult<List<string>>> GetProductCombinationXml(GetProductCombinationXml request);
        Task<IResult> InsertPermutationCombination(InsertPermutationCombination request);
        Task<IResult> DeleteProductAttributeCombination(DeleteProductAttributeCombination request);
        Task<IDataResult<IPagedList<ProductAttributeCombination>>> GetAllProductAttributeCombinations(
            GetAllProductAttributeCombinations request);
        Task<IDataResult<ProductAttributeCombination>> GetProductAttributeCombinationById(
            GetProductAttributeCombinationById request);
        Task<IDataResult<ProductAttributeCombination>> GetProductAttributeCombinationBySku(
            GetProductAttributeCombinationBySku request);
        Task<IResult> InsertProductAttributeCombination(ProductAttributeCombination combination);
        Task<IResult> UpdateProductAttributeCombination(ProductAttributeCombination combination);
    }
}
