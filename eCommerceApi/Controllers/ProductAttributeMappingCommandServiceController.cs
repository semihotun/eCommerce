using Business.Services.ProductAggregate.ProductAttributeMappings.Commands;
using Core.Utilities.Identity;
using Entities.RequestModel.ProductAggregate.ProductAttributeMappings;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace eCommerce.Areas.Api
{
    [AuthorizeControl]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductAttributeMappingCommandServiceController : ControllerBase
    {
        private readonly IProductAttributeMappingCommandService _productAttributeMappingCommandService;
        public ProductAttributeMappingCommandServiceController(IProductAttributeMappingCommandService productAttributeMappingCommandService)
        {
            _productAttributeMappingCommandService = productAttributeMappingCommandService;
        }

        [Produces("application/json", "text/plain")]
        [HttpPost("insertproductattributemapping")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> InsertProductAttributeMapping([FromBody] InsertProductAttributeMappingReqModel request)
        {
            var result = await _productAttributeMappingCommandService.InsertProductAttributeMapping(request);
            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result.Message);
        }

        [Produces("application/json", "text/plain")]
        [HttpPost("updateproductattributemapping")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> UpdateProductAttributeMapping([FromBody] UpdateProductAttributeMappingReqModel request)
        {
            var result = await _productAttributeMappingCommandService.UpdateProductAttributeMapping(request);
            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result.Message);
        }

        [Produces("application/json", "text/plain")]
        [HttpPost("deleteproductattributemapping")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> DeleteProductAttributeMapping([FromBody] DeleteProductAttributeMappingReqModel request)
        {
            var result = await _productAttributeMappingCommandService.DeleteProductAttributeMapping(request);
            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result.Message);
        }
    }
}
