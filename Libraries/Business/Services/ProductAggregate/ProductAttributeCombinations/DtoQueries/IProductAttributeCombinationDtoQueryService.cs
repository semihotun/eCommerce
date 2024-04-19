using Core.Utilities.PagedList;
using Core.Utilities.Results;
using Entities.RequestModel.ProductAggregate.ProductAttributeCombinations;
using Entities.ViewModels.AdminViewModel.AdminProduct;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Services.ProductAggregate.ProductAttributeCombinations.DtoQueries
{
    public interface IProductAttributeCombinationDtoQueryService
    {
        Task<Result<IEnumerable<SelectListItem>>> ProductAttributeCombinationDropDown(
        ProductAttributeCombinationDropDownReqModel request);
        Task<Result<IPagedList<ProductAttributeCombinationVM>>> ProductAttributeCombinationDataTable(
            ProductAttributeCombinationDataTableReqModel request);
        Task<Result<IList<ProductAttributeCombinationVM>>> ProductCombinationMappingAttrXml(
            ProductCombinationMappingAttrXmlReqModel request);
    }
}
