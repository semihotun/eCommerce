using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.PagedList;
using Microsoft.AspNetCore.Mvc;
using Business.Services.ProductAggregate.Products.Commands;
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
    public class ProductCommandServiceController : ControllerBase
    {
        private readonly IProductCommandService _productCommandService;
        public ProductCommandServiceController(IProductCommandService productCommandService)
        {
            _productCommandService = productCommandService;
        }

        [Produces("application/json", "text/plain")]
        [HttpPost("deleteproduct")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Core.Utilities.Results.Result))]
        public async Task<IActionResult> DeleteProduct([FromBody] DeleteProductReqModel request)
        {
            var result = await _productCommandService.DeleteProduct(request);
            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result.Message);
        }

        [Produces("application/json", "text/plain")]
        [HttpPost("addproduct")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Core.Utilities.Results.Result<Entities.Concrete.Product>))]
        public async Task<IActionResult> AddProduct([FromBody] AddProductReqModel request)
        {
            var result = await _productCommandService.AddProduct(request);
            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result.Message);
        }

        [Produces("application/json", "text/plain")]
        [HttpPost("updateproduct")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Core.Utilities.Results.Result<Entities.Concrete.Product>))]
        public async Task<IActionResult> UpdateProduct([FromBody] UpdateProductReqModel request)
        {
            var result = await _productCommandService.UpdateProduct(request);
            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result.Message);
        }

        [Produces("application/json", "text/plain")]
        [HttpPost("createorupdateproduct")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Core.Utilities.Results.Result<Entities.Concrete.Product>))]
        public async Task<IActionResult> CreateOrUpdateProduct([FromBody] CreateOrUpdateProductReqModel product)
        {
            var result = await _productCommandService.CreateOrUpdateProduct(product);
            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result.Message);
        }
    }
}
