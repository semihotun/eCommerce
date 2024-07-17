using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.PagedList;
using Microsoft.AspNetCore.Mvc;
using Business.Services.ProductAggregate.ProductAttributeValues.Queries;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Core.Utilities.Identity;
using Entities.RequestModel.ProductAggregate.ProductAttributeValues;

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

        [AllowAnonymous]
        [Produces("application/json", "text/plain")]
        [HttpGet("getproductattributevaluebyid")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Core.Utilities.Results.Result<Entities.Concrete.ProductAttributeValue>))]
        public async Task<IActionResult> GetProductAttributeValueById([FromQuery] GetProductAttributeValueByIdReqModel request)
        {
            var result = await _productAttributeValueQueryService.GetProductAttributeValueById(request);
            if (result.Success)
                return Ok(result.Data);
            else
                return BadRequest(result.Message);
        }

        [AllowAnonymous]
        [Produces("application/json", "text/plain")]
        [HttpGet("getproductattributevalues")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Core.Utilities.Results.Result<System.Collections.Generic.List<Entities.Concrete.ProductAttributeValue>>))]
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
