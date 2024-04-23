using Business.Services.ProductAggregate.Products.Commands;
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
    public class ProductCommandServiceController : ControllerBase
    {
        private readonly IProductCommandService _productCommandService;
        public ProductCommandServiceController(IProductCommandService productCommandService)
        {
            _productCommandService = productCommandService;
        }

        [Produces("application/json", "text/plain")]
        [HttpPost("deleteproduct")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> DeleteProduct([FromBody] DeleteProductReqModel request)
        {
            var result = await _productCommandService.DeleteProduct(request);
            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result.Message);
        }

        [Produces("application/json", "text/plain")]
        [HttpPost("addproduct")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> AddProduct([FromBody] AddProductReqModel request)
        {
            var result = await _productCommandService.AddProduct(request);
            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result.Message);
        }

        [Produces("application/json", "text/plain")]
        [HttpPost("updateproduct")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> UpdateProduct([FromBody] UpdateProductReqModel request)
        {
            var result = await _productCommandService.UpdateProduct(request);
            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result.Message);
        }

        [Produces("application/json", "text/plain")]
        [HttpPost("createorupdateproduct")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> CreateOrUpdateProduct([FromBody] CreateOrUpdateProductReqModel product)
        {
            var result = await _productCommandService.CreateOrUpdateProduct(product);
            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result.Message);
        }
    }
}
