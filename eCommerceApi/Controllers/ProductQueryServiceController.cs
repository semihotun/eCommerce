using Business.Services.ProductAggregate.Products.Queries;
using Core.Utilities.Identity;
using Entities.RequestModel.ProductAggregate.Products;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace eCommerce.Areas.Api
{
    [AuthorizeControl]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductQueryServiceController : ControllerBase
    {
        private readonly IProductQueryService _productQueryService;
        public ProductQueryServiceController(IProductQueryService productQueryService)
        {
            _productQueryService = productQueryService;
        }

        [Produces("application/json", "text/plain")]
        [HttpGet("getproduct")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetProduct([FromQuery] GetProductReqModel request)
        {
            var result = await _productQueryService.GetProduct(request);
            if (result.Success)
                return Ok(result.Data);
            else
                return BadRequest(result.Message);
        }

        [Produces("application/json", "text/plain")]
        [HttpGet("getproductsbyspecificationattributeid")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetProductsBySpecificationAttributeId([FromQuery] GetProductsBySpecificationAttributeIdReqModel request)
        {
            var result = await _productQueryService.GetProductsBySpecificationAttributeId(request);
            if (result.Success)
                return Ok(result.Data);
            else
                return BadRequest(result.Message);
        }
    }
}
