using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.PagedList;
using Microsoft.AspNetCore.Mvc;
using Business.Services.ProductAggregate.ProductAttributeCombinations.Queries;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Core.Utilities.Identity;
using Entities.RequestModel.ProductAggregate.ProductAttributeCombinations;

namespace eCommerce.Areas.Api
{
    [AuthorizeControl]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductAttributeCombinationQueryServiceController : ControllerBase
    {
        private readonly IProductAttributeCombinationQueryService _productAttributeCombinationQueryService;
        public ProductAttributeCombinationQueryServiceController(IProductAttributeCombinationQueryService productAttributeCombinationQueryService)
        {
            _productAttributeCombinationQueryService = productAttributeCombinationQueryService;
        }

        [AllowAnonymous]
        [Produces("application/json", "text/plain")]
        [HttpGet("getallproductattributecombinations")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Core.Utilities.PagedList.IPagedList<Entities.Concrete.ProductAttributeCombination>))]
        public async Task<IActionResult> GetAllProductAttributeCombinations([FromQuery] GetAllProductAttributeCombinationsReqModel request)
        {
            var result = await _productAttributeCombinationQueryService.GetAllProductAttributeCombinations(request);
            if (result.Success)
                return Ok(result.Data);
            else
                return BadRequest(result.Message);
        }

        [AllowAnonymous]
        [Produces("application/json", "text/plain")]
        [HttpGet("getproductcombinationxml")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(System.Collections.Generic.List<string>))]
        public async Task<IActionResult> GetProductCombinationXml([FromQuery] GetProductCombinationXmlReqModel request)
        {
            var result = await _productAttributeCombinationQueryService.GetProductCombinationXml(request);
            if (result.Success)
                return Ok(result.Data);
            else
                return BadRequest(result.Message);
        }

        [AllowAnonymous]
        [Produces("application/json", "text/plain")]
        [HttpGet("getproductattributecombinationbyid")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Entities.Concrete.ProductAttributeCombination))]
        public async Task<IActionResult> GetProductAttributeCombinationById([FromQuery] GetProductAttributeCombinationByIdReqModel request)
        {
            var result = await _productAttributeCombinationQueryService.GetProductAttributeCombinationById(request);
            if (result.Success)
                return Ok(result.Data);
            else
                return BadRequest(result.Message);
        }

        [AllowAnonymous]
        [Produces("application/json", "text/plain")]
        [HttpGet("getproductattributecombinationbysku")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Entities.Concrete.ProductAttributeCombination))]
        public async Task<IActionResult> GetProductAttributeCombinationBySku([FromQuery] GetProductAttributeCombinationBySkuReqModel request)
        {
            var result = await _productAttributeCombinationQueryService.GetProductAttributeCombinationBySku(request);
            if (result.Success)
                return Ok(result.Data);
            else
                return BadRequest(result.Message);
        }
    }
}
