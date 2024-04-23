using Business.Services.ProductAggregate.ProductStockTypes.Queries;
using Core.Utilities.Identity;
using Entities.RequestModel.ProductAggregate.ProductStockTypes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace eCommerce.Areas.Api
{
    [AuthorizeControl]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductStockTypeQueryServiceController : ControllerBase
    {
        private readonly IProductStockTypeQueryService _productStockTypeQueryService;
        public ProductStockTypeQueryServiceController(IProductStockTypeQueryService productStockTypeQueryService)
        {
            _productStockTypeQueryService = productStockTypeQueryService;
        }

        [Produces("application/json", "text/plain")]
        [HttpGet("getallproductstocktype")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetAllProductStockType([FromQuery] GetAllProductStockTypeReqModel request)
        {
            var result = await _productStockTypeQueryService.GetAllProductStockType(request);
            if (result.Success)
                return Ok(result.Data);
            else
                return BadRequest(result.Message);
        }
    }
}
