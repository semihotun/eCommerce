using Business.Services.ProductAggregate.ProductAttributeValues.Queries;
using Core.Utilities.Identity;
using Entities.RequestModel.ProductAggregate.ProductAttributeValues;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace eCommerce.Areas.Api
{
    [AuthorizeControl]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductAttributeValueQueryServiceController : ControllerBase
    {
        private readonly IProductAttributeValueQueryService _productAttributeValueQueryService;
        public ProductAttributeValueQueryServiceController(IProductAttributeValueQueryService productAttributeValueQueryService)
        {
            _productAttributeValueQueryService = productAttributeValueQueryService;
        }

        [Produces("application/json", "text/plain")]
        [HttpGet("getproductattributevaluebyid")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetProductAttributeValueById([FromQuery] GetProductAttributeValueByIdReqModel request)
        {
            var result = await _productAttributeValueQueryService.GetProductAttributeValueById(request);
            if (result.Success)
                return Ok(result.Data);
            else
                return BadRequest(result.Message);
        }

        [Produces("application/json", "text/plain")]
        [HttpGet("getproductattributevalues")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetProductAttributeValues([FromQuery] GetProductAttributeValuesReqModel request)
        {
            var result = await _productAttributeValueQueryService.GetProductAttributeValues(request);
            if (result.Success)
                return Ok(result.Data);
            else
                return BadRequest(result.Message);
        }
    }
}
