using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.PagedList;
using Microsoft.AspNetCore.Mvc;
using Business.Services.ProductAggregate.Products.Queries;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Core.Utilities.Identity;
using Entities.RequestModel.ProductAggregate.Products;

namespace eCommerce.Areas.Api
{
    [AuthorizeControl]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductQueryServiceController : ControllerBase
    {
        private readonly IProductQueryService _productQueryService;
        public ProductQueryServiceController(IProductQueryService productQueryService)
        {
            _productQueryService = productQueryService;
        }

        [AllowAnonymous]
        [Produces("application/json", "text/plain")]
        [HttpGet("getproduct")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Entities.Concrete.Product))]
        public async Task<IActionResult> GetProduct([FromQuery] GetProductReqModel request)
        {
            var result = await _productQueryService.GetProduct(request);
            if (result.Success)
                return Ok(result.Data);
            else
                return BadRequest(result.Message);
        }

        [AllowAnonymous]
        [Produces("application/json", "text/plain")]
        [HttpGet("getproductsbyspecificationattributeid")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Core.Utilities.PagedList.IPagedList<Entities.Concrete.Product>))]
        public async Task<IActionResult> GetProductsBySpecificationAttributeId([FromQuery] GetProductsBySpecificationAttributeIdReqModel request)
        {
            var result = await _productQueryService.GetProductsBySpecificationAttributeId(request);
            if (result.Success)
                return Ok(result.Data);
            else
                return BadRequest(result.Message);
        }
    }
}
