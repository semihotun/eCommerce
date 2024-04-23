using Business.Services.ProductAggregate.ProductAttributeMappings.Queries;
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
    public class ProductAttributeMappingQueryServiceController : ControllerBase
    {
        private readonly IProductAttributeMappingQueryService _productAttributeMappingQueryService;
        public ProductAttributeMappingQueryServiceController(IProductAttributeMappingQueryService productAttributeMappingQueryService)
        {
            _productAttributeMappingQueryService = productAttributeMappingQueryService;
        }

        [Produces("application/json", "text/plain")]
        [HttpGet("getallproductattributemapping")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetAllProductAttributeMapping([FromQuery] GetAllProductAttributeMappingReqModel request)
        {
            var result = await _productAttributeMappingQueryService.GetAllProductAttributeMapping(request);
            if (result.Success)
                return Ok(result.Data);
            else
                return BadRequest(result.Message);
        }

        [Produces("application/json", "text/plain")]
        [HttpGet("getproductattributemappingsbyproductid")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetProductAttributeMappingsByProductId([FromQuery] GetProductAttributeMappingsByProductIdReqModel request)
        {
            var result = await _productAttributeMappingQueryService.GetProductAttributeMappingsByProductId(request);
            if (result.Success)
                return Ok(result.Data);
            else
                return BadRequest(result.Message);
        }

        [Produces("application/json", "text/plain")]
        [HttpGet("getproductattributemappingbyid")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetProductAttributeMappingById([FromQuery] GetProductAttributeMappingByIdReqModel request)
        {
            var result = await _productAttributeMappingQueryService.GetProductAttributeMappingById(request);
            if (result.Success)
                return Ok(result.Data);
            else
                return BadRequest(result.Message);
        }
    }
}
