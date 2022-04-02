using Business.Services.ProductAggregate.ProductAttributeMappings;
using Business.Services.ProductAggregate.ProductAttributeMappings.ProductAttributeMappingServiceModel;
using Business.Services.ProductAggregate.ProductAttributeValues;
using Business.Services.ProductAggregate.ProductAttributeValues.ProductAttributeValueServiceModel;
using Entities.Concrete.ProductAggregate;
using Entities.ViewModels.AdminViewModel.AdminProduct;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace eCommerce.Areas.Admin.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [Route("[area]/[controller]/[action]")]
    [Area("Admin")]
    public class ProductAttributeMappingController : AdminBaseController
    {

        private readonly IProductAttributeValueService _productAttributeValueService;
        private readonly IProductAttributeMappingService _productAttributeMappingService;

        public ProductAttributeMappingController(
            IProductAttributeValueService productAttributeValueService, 
            IProductAttributeMappingService productAttributeMappingService)
        {
            _productAttributeValueService = productAttributeValueService;
            _productAttributeMappingService = productAttributeMappingService;
        }

        public async Task<IActionResult> GetMappingAttributeValue(int id)
        {
            var data = await _productAttributeValueService.GetProductAttributeValueById(new GetProductAttributeValueById(id));
            return Json(data.Data, new JsonSerializerSettings());
        }

        public async Task<IActionResult> AttrMapingDelete(int id)
        {
            ResponseAlert(await _productAttributeMappingService.DeleteProductAttributeMapping(new DeleteProductAttributeMapping(id)));

            return Json(true, new JsonSerializerSettings());
        }

        public async Task<IActionResult> AddProductAttirubeMapping([FromBody] ProductAttributeMapping mappings)
        {
            ResponseAlert(await _productAttributeMappingService.InsertProductAttributeMapping(mappings));

            return Json(mappings, new JsonSerializerSettings());
        }

        public async Task<IActionResult> UpdateProductMappingAttributeValue([FromBody] ProductVM productModel)
        {
            ResponseAlert(await _productAttributeValueService.UpdateProductAttributeValue(productModel.ProductAttributeValue));

            return Json(productModel.ProductAttributeValue, new JsonSerializerSettings());
        }

        public async Task<IActionResult> AddProductEditPageMappingAttributeValue([FromBody] ProductVM productModel)
        {
            ResponseAlert(await _productAttributeValueService.InsertProductAttributeValue(productModel.ProductAttributeValue));

            return Json(productModel.ProductAttributeValue, new JsonSerializerSettings());
        }

        public async Task<IActionResult> ProductAttributeValueList(int productAttrMapingId)
        {
            var result = await _productAttributeValueService.GetProductAttributeValues(new GetProductAttributeValues(productAttrMapingId));

            return Json(result.Data, new JsonSerializerSettings());
        }

        public async Task<IActionResult> ProductAttributeValueDelete(int attributeValueid)
        {
            ResponseAlert(await _productAttributeValueService.DeleteProductAttributeValue(new DeleteProductAttributeValue(attributeValueid)));

            return Json(attributeValueid, new JsonSerializerSettings());
        }
    }
}
