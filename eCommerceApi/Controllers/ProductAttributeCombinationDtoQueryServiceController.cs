using Business.Services.ProductAggregate.ProductAttributeCombinations.DtoQueries;
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
    public class ProductAttributeCombinationDtoQueryServiceController : ControllerBase
    {
        private readonly IProductAttributeCombinationDtoQueryService _productAttributeCombinationDtoQueryService;
        public ProductAttributeCombinationDtoQueryServiceController(IProductAttributeCombinationDtoQueryService productAttributeCombinationDtoQueryService)
        {
            _productAttributeCombinationDtoQueryService = productAttributeCombinationDtoQueryService;
        }

        [Produces("application/json", "text/plain")]
        [HttpPost("productattributecombinationdropdown")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> ProductAttributeCombinationDropDown([FromBody] ProductAttributeCombinationDropDownReqModel request)
        {
            var result = await _productAttributeCombinationDtoQueryService.ProductAttributeCombinationDropDown(request);
            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result.Message);
        }

        [Produces("application/json", "text/plain")]
        [HttpPost("productattributecombinationdatatable")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> ProductAttributeCombinationDataTable([FromBody] ProductAttributeCombinationDataTableReqModel request)
        {
            var result = await _productAttributeCombinationDtoQueryService.ProductAttributeCombinationDataTable(request);
            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result.Message);
        }

        [Produces("application/json", "text/plain")]
        [HttpPost("productcombinationmappingattrxml")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> ProductCombinationMappingAttrXml([FromBody] ProductCombinationMappingAttrXmlReqModel request)
        {
            var result = await _productAttributeCombinationDtoQueryService.ProductCombinationMappingAttrXml(request);
            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result.Message);
        }
    }
}
