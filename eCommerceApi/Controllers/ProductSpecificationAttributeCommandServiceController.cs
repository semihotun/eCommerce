using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.PagedList;
using Microsoft.AspNetCore.Mvc;
using Business.Services.ProductAggregate.ProductSpecificationAttributes.Commands;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Core.Utilities.Identity;
using Entities.RequestModel.ProductAggregate.ProductSpecificationAttributes;

namespace eCommerce.Areas.Api
{
    [AuthorizeControl]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductSpecificationAttributeCommandServiceController : ControllerBase
    {
        private readonly IProductSpecificationAttributeCommandService _productSpecificationAttributeCommandService;
        public ProductSpecificationAttributeCommandServiceController(IProductSpecificationAttributeCommandService productSpecificationAttributeCommandService)
        {
            _productSpecificationAttributeCommandService = productSpecificationAttributeCommandService;
        }

        [Produces("application/json", "text/plain")]
        [HttpPost("deleteproductspecificationattribute")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> DeleteProductSpecificationAttribute([FromBody] DeleteProductSpecificationAttributeReqModel request)
        {
            var result = await _productSpecificationAttributeCommandService.DeleteProductSpecificationAttribute(request);
            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result.Message);
        }

        [Produces("application/json", "text/plain")]
        [HttpPost("insertproductspecificationattribute")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> InsertProductSpecificationAttribute([FromBody] InsertProductSpecificationAttributeReqModel productSpecificationAttribute)
        {
            var result = await _productSpecificationAttributeCommandService.InsertProductSpecificationAttribute(productSpecificationAttribute);
            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result.Message);
        }

        [Produces("application/json", "text/plain")]
        [HttpPost("updateproductspecificationattribute")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> UpdateProductSpecificationAttribute([FromBody] UpdateProductSpecificationAttributeReqModel request)
        {
            var result = await _productSpecificationAttributeCommandService.UpdateProductSpecificationAttribute(request);
            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result.Message);
        }
    }
}
