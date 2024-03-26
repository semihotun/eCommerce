using Core.Utilities.Results;
using DataAccess.DALs.EntitiyFramework.ProductAggregate.ProductAttributeCombinations.ProductAttributeCombinationDALModels;
using eCommerce.Core.DataAccess;
using Entities.Concrete.ProductAggregate;
using Entities.ViewModels.AdminViewModel.AdminProduct;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Threading.Tasks;
using X.PagedList;
namespace DataAccess.DALs.EntitiyFramework.ProductAggregate.ProductAttributeCombinations
{
    public interface IProductAttributeCombinationDAL : IEntityRepository<ProductAttributeCombination>
    {
        Task<Result<IEnumerable<SelectListItem>>> ProductAttributeCombinationDropDown(
            ProductAttributeCombinationDropDown request);
        Task<Result<IPagedList<ProductAttributeCombinationVM>>> ProductAttributeCombinationDataTable(
            ProductAttributeCombinationDataTable request);
        Task<Result<IList<ProductAttributeCombinationVM>>> ProductCombinationMappingAttrXml(
            ProductCombinationMappingAttrXml request);
    }
}
