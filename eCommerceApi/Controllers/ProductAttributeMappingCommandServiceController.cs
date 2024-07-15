using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.PagedList;
using Microsoft.AspNetCore.Mvc;
using Business.Services.ProductAggregate.ProductAttributeMappings.Commands;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Core.Utilities.Identity;
using Entities.RequestModel.ProductAggregate.ProductAttributeMappings;

namespace eCommerce.Areas.Api
{
    [AuthorizeControl]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductAttributeMappingCommandServiceController : ControllerBase
    {
        private readonly IProductAttributeMappingCommandService _productAttributeMappingCommandService;
        public ProductAttributeMappingCommandServiceController(IProductAttributeMappingCommandService productAttributeMappingCommandService)
        {
            _productAttributeMappingCommandService = productAttributeMappingCommandService;
        }

        [Produces("application/json", "text/plain")]
        [HttpPost("insertproductattributemapping")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Core.Utilities.Results.Result<Entities.Concrete.ProductAttributeMapping>))]
        public async Task<IActionResult> InsertProductAttributeMapping([FromBody] InsertProductAttributeMappingReqModel request)
        {
            var result = await _productAttributeMappingCommandService.InsertProductAttributeMapping(request);
            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result.Message);
        }

        [Produces("application/json", "text/plain")]
        [HttpPost("updateproductattributemapping")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Core.Utilities.Results.Result))]
        public async Task<IActionResult> UpdateProductAttributeMapping([FromBody] UpdateProductAttributeMappingReqModel request)
        {
            var result = await _productAttributeMappingCommandService.UpdateProductAttributeMapping(request);
            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result.Message);
        }

        [Produces("application/json", "text/plain")]
        [HttpPost("deleteproductattributemapping")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Core.Utilities.Results.Result))]
        public async Task<IActionResult> DeleteProductAttributeMapping([FromBody] DeleteProductAttributeMappingReqModel request)
        {
            var result = await _productAttributeMappingCommandService.DeleteProductAttributeMapping(request);
            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result.Message);
        }
    }
}
