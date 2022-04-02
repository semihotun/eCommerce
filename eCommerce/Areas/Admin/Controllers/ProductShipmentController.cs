using Business.Services.ProductAggregate.ProductShipmentInfos;
using Business.Services.ProductAggregate.ProductShipmentInfos.ProductShipmentInfoServiceModel;
using Entities.Concrete.ProductAggregate;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace eCommerce.Areas.Admin.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [Route("[area]/[controller]/[action]")]
    [Area("Admin")]
    public class ProductShipmentController : AdminBaseController
    {
        private readonly IProductShipmentInfoService _productShipmentInfoService;
        public ProductShipmentController(IProductShipmentInfoService productShipmentInfoService)
        {
            _productShipmentInfoService = productShipmentInfoService;
        }
        public async Task<IActionResult> ProductShipmentInfoAddOrUpdate(ProductShipmentInfo productShipmentInfo)
        {
            var data = await _productShipmentInfoService.AddOrUpdateProductShipmentInfo(productShipmentInfo);

            return Json(productShipmentInfo, new JsonSerializerSettings());
        }

        public async Task<IActionResult> GetProductShipmentInfo(int productId)
        {
            var data = (await _productShipmentInfoService.GetProductShipmentInfo(new GetProductShipmentInfo(productId))).Data;

            return Json(data, new JsonSerializerSettings());
        }
    }
}
