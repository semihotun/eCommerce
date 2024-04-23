using Business.Services.ProductAggregate.PredefinedProductAttributeValues.Queries;
using Core.Utilities.Identity;
using Entities.RequestModel.ProductAggregate.PredefinedProductAttributeValues;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace eCommerce.Areas.Api
{
    [AuthorizeControl]
    [Route("api/[controller]")]
    [ApiController]
    public class PredefinedProductAttributeValueQueryServiceController : ControllerBase
    {
        private readonly IPredefinedProductAttributeValueQueryService _predefinedProductAttributeValueQueryService;
        public PredefinedProductAttributeValueQueryServiceController(IPredefinedProductAttributeValueQueryService predefinedProductAttributeValueQueryService)
        {
            _predefinedProductAttributeValueQueryService = predefinedProductAttributeValueQueryService;
        }

        [Produces("application/json", "text/plain")]
        [HttpGet("getpredefinedproductattributevalues")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetPredefinedProductAttributeValues([FromQuery] GetPredefinedProductAttributeValuesReqModel request)
        {
            var result = await _predefinedProductAttributeValueQueryService.GetPredefinedProductAttributeValues(request);
            if (result.Success)
                return Ok(result.Data);
            else
                return BadRequest(result.Message);
        }

        [Produces("application/json", "text/plain")]
        [HttpGet("getpredefinedproductattributevaluebyid")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetPredefinedProductAttributeValueById([FromQuery] GetPredefinedProductAttributeValueByIdReqModel request)
        {
            var result = await _predefinedProductAttributeValueQueryService.GetPredefinedProductAttributeValueById(request);
            if (result.Success)
                return Ok(result.Data);
            else
                return BadRequest(result.Message);
        }
    }
}
