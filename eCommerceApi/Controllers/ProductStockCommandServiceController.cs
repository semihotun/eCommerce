using Business.Services.ProductAggregate.ProductStocks.Commands;
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
    public class ProductStockCommandServiceController : ControllerBase
    {
        private readonly IProductStockCommandService _productStockCommandService;
        public ProductStockCommandServiceController(IProductStockCommandService productStockCommandService)
        {
            _productStockCommandService = productStockCommandService;
        }

        [Produces("application/json", "text/plain")]
        [HttpPost("addproductstock")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> AddProductStock([FromBody] AddProductStockReqModel productStock)
        {
            var result = await _productStockCommandService.AddProductStock(productStock);
            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result.Message);
        }

        [Produces("application/json", "text/plain")]
        [HttpPost("deleteproductstock")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> DeleteProductStock([FromBody] DeleteProductStockReqModel request)
        {
            var result = await _productStockCommandService.DeleteProductStock(request);
            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result.Message);
        }
    }
}
