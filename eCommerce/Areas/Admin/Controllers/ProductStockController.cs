using Business.Services.ProductAggregate.ProductStocks;
using Business.Services.ProductAggregate.ProductStocks.ProductStockServiceModel;
using DataAccess.DALs.EntitiyFramework.ProductAggregate.ProductStocks;
using DataAccess.DALs.EntitiyFramework.ProductAggregate.ProductStocks.ProductStockDALModels;
using Entities.Concrete.ProductAggregate;
using Entities.Helpers.AutoMapper;
using Entities.Others;
using Entities.ViewModels.AdminViewModel.AdminProduct;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Threading.Tasks;
namespace eCommerce.Areas.Admin.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [Route("[area]/[controller]/[action]")]
    [Area("Admin")]
    public class ProductStockController : AdminBaseController
    {
        private readonly IProductStockDAL _productStockDal;
        private readonly IProductStockService _productStockService;
        public ProductStockController(IProductStockDAL productStockDal, IProductStockService productStockService)
        {
            _productStockDal = productStockDal;
            _productStockService = productStockService;
        }
        public async Task<IActionResult> ProductStockListJson(ProductStockFilter productStockFilter, DataTablesParam param)
        {
            var query = await _productStockDal.GetAllProductStockDto(
                new GetAllProductStockDto(productStockFilter.ProductId, param));
            return ToDataTableJson(query, param);
        }
        public async Task<IActionResult> ProductStockAdd(ProductStockCreateOrUpdateVM productStock)
        {
            var data = productStock.MapTo<ProductStock>();
            ResponseAlert(await _productStockService.AddProductStock(data));
            productStock.Id = data.Id;
            return Json(productStock, new JsonSerializerSettings());
        }
        public async Task<IActionResult> ProductStockDelete(int id)
        {
            ResponseAlert(await _productStockService.DeleteProductStock(new DeleteProductStock(id)));
            return Json(true, new JsonSerializerSettings());
        }
    }
}
