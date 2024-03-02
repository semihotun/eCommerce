using Business.Services.ProductAggregate.ProductSpecificationAttributes;
using Business.Services.ProductAggregate.ProductSpecificationAttributes.ProductSpecificationAttributeServiceModel;
using Business.Services.SpeficationAggregate.SpecificationAttributeOptions;
using Business.Services.SpeficationAggregate.SpecificationAttributeOptions.SpecificationAttributeOptionServiceModel;
using DataAccess.DALs.EntitiyFramework.ProductAggregate.ProductSpecificationAttributes;
using DataAccess.DALs.EntitiyFramework.ProductAggregate.ProductSpecificationAttributes.ProductSpecificationAttributeDALModels;
using Entities.Concrete.ProductAggregate;
using Entities.Concrete.SpeficationAggregate;
using Entities.Helpers.AutoMapper;
using Entities.Others;
using Entities.ViewModels.AdminViewModel.AdminProduct;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Linq;
using System.Threading.Tasks;
namespace eCommerce.Areas.Admin.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [Route("[area]/[controller]/[action]")]
    [Area("Admin")]
    public class ProductSpecificationAttributeController : AdminBaseController
    {
        private readonly IProductSpecificationAttributeDAL _productSpecificationAttributeDAL;
        private readonly ISpecificationAttributeOptionService _specificationAttributeOptionService;
        private readonly IProductSpecificationAttributeService _productSpecificationAttributeService;
        public ProductSpecificationAttributeController(
            IProductSpecificationAttributeDAL productSpecificationAttributeDAL,
            ISpecificationAttributeOptionService specificationAttributeOptionService, 
            IProductSpecificationAttributeService productSpecificationAttributeService
            )
        {
            _productSpecificationAttributeDAL = productSpecificationAttributeDAL;
            _specificationAttributeOptionService = specificationAttributeOptionService;
            _productSpecificationAttributeService = productSpecificationAttributeService;
        }
        public async Task<IActionResult> ProductSpeficationJson(ProductVM model, DataTablesParam param)
        {
            var query = await _productSpecificationAttributeDAL.ProductSpecAttrList(
                new ProductSpecAttrList(model.Id, param));
            return ToDataTableJson(query, param);
        }
        public async Task<IActionResult> ProductSpeficationCreate(ProductSpecificationAttribute productSpecificationAttribute)
        {
            var data = productSpecificationAttribute.MapTo<ProductSpecificationAttribute>();
            ResponseAlert(await _productSpecificationAttributeService.InsertProductSpecificationAttribute(data));
            productSpecificationAttribute.Id = data.Id;
            return Json(productSpecificationAttribute, new JsonSerializerSettings() { });
        }
        public async Task<IActionResult> GetSpeficationOptionById(int speficationAttrId = 0)
        {
            var data = await _specificationAttributeOptionService.GetSpecificationAttributeOptionsBySpecificationAttribute(
               new GetSpecificationAttributeOptionsBySpecificationAttribute(speficationAttrId));
            var result = data.Data.Select(x => new SpecificationAttributeOption
            {
                Id = x.Id,
                Name = x.Name
            });
            return Json(result, new JsonSerializerSettings());
        }
        public async Task<IActionResult> ProductSpeficationDelete(int id)
        {
            ResponseAlert(await _productSpecificationAttributeService.DeleteProductSpecificationAttribute(new DeleteProductSpecificationAttribute(id)));
            return Json(id, new JsonSerializerSettings());
        }
    }
}
