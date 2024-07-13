using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.PagedList;
using Microsoft.AspNetCore.Mvc;
using Business.Services.ProductAggregate.ProductAttributeMappings.DtoQueries;
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
    public class ProductAttributeMappingDtoQueryServiceController : ControllerBase
    {
        private readonly IProductAttributeMappingDtoQueryService _productAttributeMappingDtoQueryService;
        public ProductAttributeMappingDtoQueryServiceController(IProductAttributeMappingDtoQueryService productAttributeMappingDtoQueryService)
        {
            _productAttributeMappingDtoQueryService = productAttributeMappingDtoQueryService;
        }

        [Produces("application/json", "text/plain")]
        [HttpGet("getproductdetailmappingjson")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetProductDetailMappingJson([FromQuery] GetProductDetailMappingJsonReqModel request)
        {
            var result = await _productAttributeMappingDtoQueryService.GetProductDetailMappingJson(request);
            if (result.Success)
                return Ok(result.Data);
            else
                return BadRequest(result.Message);
        }

        [Produces("application/json", "text/plain")]
        [HttpGet("getmappingproductattributelist")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetMappingProductAttributeList([FromQuery] GetMappingProductAttributeListReqModel request)
        {
            var result = await _productAttributeMappingDtoQueryService.GetMappingProductAttributeList(request);
            if (result.Success)
                return Ok(result.Data);
            else
                return BadRequest(result.Message);
        }
    }
}
