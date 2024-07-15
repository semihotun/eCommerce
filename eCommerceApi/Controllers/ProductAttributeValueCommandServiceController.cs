using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.PagedList;
using Microsoft.AspNetCore.Mvc;
using Business.Services.ProductAggregate.ProductAttributeValues.Commands;
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
    public class ProductAttributeValueCommandServiceController : ControllerBase
    {
        private readonly IProductAttributeValueCommandService _productAttributeValueCommandService;
        public ProductAttributeValueCommandServiceController(IProductAttributeValueCommandService productAttributeValueCommandService)
        {
            _productAttributeValueCommandService = productAttributeValueCommandService;
        }

        [Produces("application/json", "text/plain")]
        [HttpPost("deleteproductattributevalue")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Core.Utilities.Results.Result))]
        public async Task<IActionResult> DeleteProductAttributeValue([FromBody] DeleteProductAttributeValueReqModel request)
        {
            var result = await _productAttributeValueCommandService.DeleteProductAttributeValue(request);
            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result.Message);
        }

        [Produces("application/json", "text/plain")]
        [HttpPost("insertproductattributevalue")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Core.Utilities.Results.Result<Entities.Concrete.ProductAttributeValue>))]
        public async Task<IActionResult> InsertProductAttributeValue([FromBody] InsertProductAttributeValueReqModel productAttributeValue)
        {
            var result = await _productAttributeValueCommandService.InsertProductAttributeValue(productAttributeValue);
            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result.Message);
        }

        [Produces("application/json", "text/plain")]
        [HttpPost("insertorupdateproductattributevalue")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Core.Utilities.Results.Result<Entities.Concrete.ProductAttributeValue>))]
        public async Task<IActionResult> InsertOrUpdateProductAttributeValue([FromBody] InsertOrUpdateProductAttributeValueReqModel productAttributeValue)
        {
            var result = await _productAttributeValueCommandService.InsertOrUpdateProductAttributeValue(productAttributeValue);
            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result.Message);
        }

        [Produces("application/json", "text/plain")]
        [HttpPost("updateproductattributevalue")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Core.Utilities.Results.Result<Entities.Concrete.ProductAttributeValue>))]
        public async Task<IActionResult> UpdateProductAttributeValue([FromBody] UpdateProductAttributeValueReqModel request)
        {
            var result = await _productAttributeValueCommandService.UpdateProductAttributeValue(request);
            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result.Message);
        }
    }
}
