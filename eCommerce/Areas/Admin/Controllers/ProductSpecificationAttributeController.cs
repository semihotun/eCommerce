using Core.Utilities.DataTable;
using DataAccess.DALs.EntitiyFramework.ProductAggregate.ProductSpecificationAttributes;
using Entities.ViewModels.AdminViewModel.AdminProduct;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
namespace eCommerce.Areas.Admin.Controllers
{
    public class ProductSpecificationAttributeController : AdminBaseController
    {
        private readonly IProductSpecificationAttributeDAL _productSpecificationAttributeDAL;
        public ProductSpecificationAttributeController(
            IProductSpecificationAttributeDAL productSpecificationAttributeDAL
            )
        {
            _productSpecificationAttributeDAL = productSpecificationAttributeDAL;
        }
        public async Task<IActionResult> ProductSpeficationJson(ProductVM model, DTParameters param) =>
             ToDataTableJson(await _productSpecificationAttributeDAL.ProductSpecAttrList(
                new (model.Id, param)), param);
    }
}
