using DataAccess.DALs.EntitiyFramework.ProductAggregate.ProductSpecificationAttributes;
using DataAccess.DALs.EntitiyFramework.ProductAggregate.ProductSpecificationAttributes.ProductSpecificationAttributeDALModels;
using Entities.Others;
using Entities.ViewModels.AdminViewModel.AdminProduct;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
namespace eCommerce.Areas.Admin.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [Route("[area]/[controller]/[action]")]
    [Area("Admin")]
    public class ProductSpecificationAttributeController : AdminBaseController
    {
        private readonly IProductSpecificationAttributeDAL _productSpecificationAttributeDAL;
        public ProductSpecificationAttributeController(
            IProductSpecificationAttributeDAL productSpecificationAttributeDAL
            )
        {
            _productSpecificationAttributeDAL = productSpecificationAttributeDAL;
        }
        public async Task<IActionResult> ProductSpeficationJson(ProductVM model, DataTablesParam param) =>
             ToDataTableJson(await _productSpecificationAttributeDAL.ProductSpecAttrList(
                new ProductSpecAttrList(model.Id, param)), param);
    }
}
