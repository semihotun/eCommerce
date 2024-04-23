using Business.Services.ProductAggregate.ProductStocks.Queries;
using Core.Utilities.Identity;
using Entities.RequestModel.ProductAggregate.ProductStocks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace eCommerce.Areas.Api
{
    [AuthorizeControl]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductStockQueryServiceController : ControllerBase
    {
        private readonly IProductStockQueryService _productStockQueryService;
        public ProductStockQueryServiceController(IProductStockQueryService productStockQueryService)
        {
            _productStockQueryService = productStockQueryService;
        }

        [Produces("application/json", "text/plain")]
        [HttpGet("getallproductstock")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetAllProductStock([FromQuery] GetAllProductStockReqModel request)
        {
            var result = await _productStockQueryService.GetAllProductStock(request);
            if (result.Success)
                return Ok(result.Data);
            else
                return BadRequest(result.Message);
        }
    }
}
