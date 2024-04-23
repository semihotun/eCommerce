using Business.Services.ProductAggregate.ProductAttributes.Queries;
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
    public class ProductAttributeQueryServiceController : ControllerBase
    {
        private readonly IProductAttributeQueryService _productAttributeQueryService;
        public ProductAttributeQueryServiceController(IProductAttributeQueryService productAttributeQueryService)
        {
            _productAttributeQueryService = productAttributeQueryService;
        }

        [Produces("application/json", "text/plain")]
        [HttpGet("getallproductattributes")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetAllProductAttributes([FromQuery] GetAllProductAttributesReqModel request)
        {
            var result = await _productAttributeQueryService.GetAllProductAttributes(request);
            if (result.Success)
                return Ok(result.Data);
            else
                return BadRequest(result.Message);
        }

        [Produces("application/json", "text/plain")]
        [HttpGet("getallproductattribute")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetAllProductAttribute()
        {
            var result = await _productAttributeQueryService.GetAllProductAttribute();
            if (result.Success)
                return Ok(result.Data);
            else
                return BadRequest(result.Message);
        }

        [Produces("application/json", "text/plain")]
        [HttpGet("getproductattributebyid")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetProductAttributeById([FromQuery] GetProductAttributeByIdReqModel request)
        {
            var result = await _productAttributeQueryService.GetProductAttributeById(request);
            if (result.Success)
                return Ok(result.Data);
            else
                return BadRequest(result.Message);
        }

        [Produces("application/json", "text/plain")]
        [HttpGet("getproductattributedropdown")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetProductAttributeDropdown([FromQuery] GetProductAttributeDropdownReqModel request)
        {
            var result = await _productAttributeQueryService.GetProductAttributeDropdown(request);
            if (result.Success)
                return Ok(result.Data);
            else
                return BadRequest(result.Message);
        }
    }
}
