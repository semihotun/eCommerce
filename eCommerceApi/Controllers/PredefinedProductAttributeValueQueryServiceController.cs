using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.PagedList;
using Microsoft.AspNetCore.Mvc;
using Business.Services.ProductAggregate.PredefinedProductAttributeValues.Queries;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Core.Utilities.Identity;
using Entities.RequestModel.ProductAggregate.PredefinedProductAttributeValues;

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

        [AllowAnonymous]
        [Produces("application/json", "text/plain")]
        [HttpGet("getpredefinedproductattributevalues")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(System.Collections.Generic.List<Entities.Concrete.PredefinedProductAttributeValue>))]
        public async Task<IActionResult> GetPredefinedProductAttributeValues([FromQuery] GetPredefinedProductAttributeValuesReqModel request)
        {
            var result = await _predefinedProductAttributeValueQueryService.GetPredefinedProductAttributeValues(request);
            if (result.Success)
                return Ok(result.Data);
            else
                return BadRequest(result.Message);
        }

        [AllowAnonymous]
        [Produces("application/json", "text/plain")]
        [HttpGet("getpredefinedproductattributevaluebyid")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Entities.Concrete.PredefinedProductAttributeValue))]
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
