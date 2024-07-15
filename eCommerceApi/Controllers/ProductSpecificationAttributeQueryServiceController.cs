using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.PagedList;
using Microsoft.AspNetCore.Mvc;
using Business.Services.ProductAggregate.ProductSpecificationAttributes.Queries;
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
    public class ProductSpecificationAttributeQueryServiceController : ControllerBase
    {
        private readonly IProductSpecificationAttributeQueryService _productSpecificationAttributeQueryService;
        public ProductSpecificationAttributeQueryServiceController(IProductSpecificationAttributeQueryService productSpecificationAttributeQueryService)
        {
            _productSpecificationAttributeQueryService = productSpecificationAttributeQueryService;
        }

        [Produces("application/json", "text/plain")]
        [HttpGet("getproductspecificationattributes")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Core.Utilities.Results.Result<Core.Utilities.PagedList.IPagedList<Entities.Concrete.ProductSpecificationAttribute>>))]
        public async Task<IActionResult> GetProductSpecificationAttributes([FromQuery] GetProductSpecificationAttributesReqModel request)
        {
            var result = await _productSpecificationAttributeQueryService.GetProductSpecificationAttributes(request);
            if (result.Success)
                return Ok(result.Data);
            else
                return BadRequest(result.Message);
        }

        [Produces("application/json", "text/plain")]
        [HttpGet("getproductspecificationattributebyid")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Core.Utilities.Results.Result<Entities.Concrete.ProductSpecificationAttribute>))]
        public async Task<IActionResult> GetProductSpecificationAttributeById([FromQuery] GetProductSpecificationAttributeByIdReqModel request)
        {
            var result = await _productSpecificationAttributeQueryService.GetProductSpecificationAttributeById(request);
            if (result.Success)
                return Ok(result.Data);
            else
                return BadRequest(result.Message);
        }

        [Produces("application/json", "text/plain")]
        [HttpGet("getproductspecificationattributecount")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Core.Utilities.Results.Result<int>))]
        public async Task<IActionResult> GetProductSpecificationAttributeCount([FromQuery] GetProductSpecificationAttributeCountReqModel request)
        {
            var result = await _productSpecificationAttributeQueryService.GetProductSpecificationAttributeCount(request);
            if (result.Success)
                return Ok(result.Data);
            else
                return BadRequest(result.Message);
        }
    }
}
