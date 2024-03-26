using Business.Services.ProductAggregate.ProductStocks;
using DataAccess.DALs.EntitiyFramework.ProductAggregate.ProductStocks;
using DataAccess.DALs.EntitiyFramework.ProductAggregate.ProductStocks.ProductStockDALModels;
using Entities.Others;
using Entities.ViewModels.AdminViewModel.AdminProduct;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<IActionResult> ProductStockListJson(ProductStockFilter productStockFilter, DataTablesParam param) =>
            ToDataTableJson(await _productStockDal.GetAllProductStockDto(
                new GetAllProductStockDto(productStockFilter.ProductId, param)), param);
    }
}
