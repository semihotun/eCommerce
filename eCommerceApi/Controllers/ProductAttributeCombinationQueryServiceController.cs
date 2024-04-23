using Business.Services.ProductAggregate.ProductAttributeCombinations.Queries;
using Core.Utilities.Identity;
using Entities.RequestModel.ProductAggregate.ProductAttributeCombinations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace eCommerce.Areas.Api
{
    [AuthorizeControl]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductAttributeCombinationQueryServiceController : ControllerBase
    {
        private readonly IProductAttributeCombinationQueryService _productAttributeCombinationQueryService;
        public ProductAttributeCombinationQueryServiceController(IProductAttributeCombinationQueryService productAttributeCombinationQueryService)
        {
            _productAttributeCombinationQueryService = productAttributeCombinationQueryService;
        }

        [Produces("application/json", "text/plain")]
        [HttpGet("getallproductattributecombinations")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetAllProductAttributeCombinations([FromQuery] GetAllProductAttributeCombinationsReqModel request)
        {
            var result = await _productAttributeCombinationQueryService.GetAllProductAttributeCombinations(request);
            if (result.Success)
                return Ok(result.Data);
            else
                return BadRequest(result.Message);
        }

        [Produces("application/json", "text/plain")]
        [HttpGet("getproductcombinationxml")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetProductCombinationXml([FromQuery] GetProductCombinationXmlReqModel request)
        {
            var result = await _productAttributeCombinationQueryService.GetProductCombinationXml(request);
            if (result.Success)
                return Ok(result.Data);
            else
                return BadRequest(result.Message);
        }

        [Produces("application/json", "text/plain")]
        [HttpGet("getproductattributecombinationbyid")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetProductAttributeCombinationById([FromQuery] GetProductAttributeCombinationByIdReqModel request)
        {
            var result = await _productAttributeCombinationQueryService.GetProductAttributeCombinationById(request);
            if (result.Success)
                return Ok(result.Data);
            else
                return BadRequest(result.Message);
        }

        [Produces("application/json", "text/plain")]
        [HttpGet("getproductattributecombinationbysku")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetProductAttributeCombinationBySku([FromQuery] GetProductAttributeCombinationBySkuReqModel request)
        {
            var result = await _productAttributeCombinationQueryService.GetProductAttributeCombinationBySku(request);
            if (result.Success)
                return Ok(result.Data);
            else
                return BadRequest(result.Message);
        }
    }
}
