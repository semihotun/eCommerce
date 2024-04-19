using Core.Utilities.PagedList;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.RequestModel.ProductAggregate.ProductAttributeCombinations;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Services.ProductAggregate.ProductAttributeCombinations.Queries
{
    public interface IProductAttributeCombinationQueryService
    {
        Task<Result<List<string>>> GetProductCombinationXml(GetProductCombinationXmlReqModel request);
        Task<Result<IPagedList<ProductAttributeCombination>>> GetAllProductAttributeCombinations(
            GetAllProductAttributeCombinationsReqModel request);
        Task<Result<ProductAttributeCombination>> GetProductAttributeCombinationById(
            GetProductAttributeCombinationByIdReqModel request);
        Task<Result<ProductAttributeCombination>> GetProductAttributeCombinationBySku(
            GetProductAttributeCombinationBySkuReqModel request);
    }
}
