using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.PagedList;
using Microsoft.AspNetCore.Mvc;
using Business.Services.ProductAggregate.ProductAttributeCombinations.DtoQueries;
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
    public class ProductAttributeCombinationDtoQueryServiceController : ControllerBase
    {
        private readonly IProductAttributeCombinationDtoQueryService _productAttributeCombinationDtoQueryService;
        public ProductAttributeCombinationDtoQueryServiceController(IProductAttributeCombinationDtoQueryService productAttributeCombinationDtoQueryService)
        {
            _productAttributeCombinationDtoQueryService = productAttributeCombinationDtoQueryService;
        }

        [AllowAnonymous]
        [Produces("application/json", "text/plain")]
        [HttpPost("productattributecombinationdropdown")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Core.Utilities.Results.Result<System.Collections.Generic.IEnumerable<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem>>))]
        public async Task<IActionResult> ProductAttributeCombinationDropDown([FromBody] ProductAttributeCombinationDropDownReqModel request)
        {
            var result = await _productAttributeCombinationDtoQueryService.ProductAttributeCombinationDropDown(request);
            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result.Message);
        }

        [AllowAnonymous]
        [Produces("application/json", "text/plain")]
        [HttpPost("productattributecombinationdatatable")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Core.Utilities.Results.Result<Core.Utilities.PagedList.IPagedList<Entities.ViewModels.AdminViewModel.AdminProduct.ProductAttributeCombinationVM>>))]
        public async Task<IActionResult> ProductAttributeCombinationDataTable([FromBody] ProductAttributeCombinationDataTableReqModel request)
        {
            var result = await _productAttributeCombinationDtoQueryService.ProductAttributeCombinationDataTable(request);
            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result.Message);
        }

        [AllowAnonymous]
        [Produces("application/json", "text/plain")]
        [HttpPost("productcombinationmappingattrxml")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Core.Utilities.Results.Result<System.Collections.Generic.IList<Entities.ViewModels.AdminViewModel.AdminProduct.ProductAttributeCombinationVM>>))]
        public async Task<IActionResult> ProductCombinationMappingAttrXml([FromBody] ProductCombinationMappingAttrXmlReqModel request)
        {
            var result = await _productAttributeCombinationDtoQueryService.ProductCombinationMappingAttrXml(request);
            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result.Message);
        }
    }
}
