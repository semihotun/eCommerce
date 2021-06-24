using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using X.PagedList;

namespace Business.Abstract.Products
{
    public interface IProductAttributeCombinationService
    {
        Task<IDataResult<List<string>>> GetProductCombinationXml(int productId);
        Task<IResult> InsertPermutationCombination(List<List<int>> data, int productid);
        Task<IResult> DeleteProductAttributeCombination(int Id);
        Task<IDataResult<IPagedList<ProductAttributeCombination>>> GetAllProductAttributeCombinations(int productId,
            int pageIndex = 1, int pageSize = int.MaxValue, string orderByText = null);
        Task<IDataResult<ProductAttributeCombination>> GetProductAttributeCombinationById(int productAttributeCombinationId);
        Task<IDataResult<ProductAttributeCombination>> GetProductAttributeCombinationBySku(string sku);
        Task<IResult> InsertProductAttributeCombination(ProductAttributeCombination combination);
        Task<IResult> UpdateProductAttributeCombination(ProductAttributeCombination combination);
    }
}
