using Business.Services.ProductAggregate.ProductAttributes.Commands;
using Core.Utilities.Identity;
using Entities.RequestModel.ProductAggregate.ProductAttributes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace eCommerce.Areas.Api
{
    [AuthorizeControl]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductAttributeCommandServiceController : ControllerBase
    {
        private readonly IProductAttributeCommandService _productAttributeCommandService;
        public ProductAttributeCommandServiceController(IProductAttributeCommandService productAttributeCommandService)
        {
            _productAttributeCommandService = productAttributeCommandService;
        }

        [Produces("application/json", "text/plain")]
        [HttpPost("deleteproductattribute")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> DeleteProductAttribute([FromBody] DeleteProductAttributeReqModel request)
        {
            var result = await _productAttributeCommandService.DeleteProductAttribute(request);
            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result.Message);
        }

        [Produces("application/json", "text/plain")]
        [HttpPost("insertproductattribute")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> InsertProductAttribute([FromBody] InsertProductAttributeReqModel request)
        {
            var result = await _productAttributeCommandService.InsertProductAttribute(request);
            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result.Message);
        }

        [Produces("application/json", "text/plain")]
        [HttpPost("updateproductattribute")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> UpdateProductAttribute([FromBody] UpdateProductAttributeReqModel request)
        {
            var result = await _productAttributeCommandService.UpdateProductAttribute(request);
            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result.Message);
        }
    }
}
