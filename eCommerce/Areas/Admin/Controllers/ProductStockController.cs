using Business.Services.ProductAggregate.ProductStocks.DtoQueries;
using Entities.RequestModel.ProductAggregate.ProductStocks;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
namespace eCommerce.Areas.Admin.Controllers
{
    public class ProductStockController : AdminBaseController
    {
        private readonly IProductStockDtoQueryService _productStockDtoQueryService;
        public ProductStockController(IProductStockDtoQueryService productStockDtoQueryService)
        {
            _productStockDtoQueryService = productStockDtoQueryService;
        }
        public async Task<IActionResult> ProductStockListJson(GetAllProductStockReqModel request) =>
            ToDataTableJson(await _productStockDtoQueryService.GetAllProductStockDto(request), request);
    }
}
