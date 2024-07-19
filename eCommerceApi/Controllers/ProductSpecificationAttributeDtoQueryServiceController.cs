using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.PagedList;
using Microsoft.AspNetCore.Mvc;
using Business.Services.ProductAggregate.ProductSpecificationAttributes.DtoQueries;
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
    public class ProductSpecificationAttributeDtoQueryServiceController : ControllerBase
    {
        private readonly IProductSpecificationAttributeDtoQueryService _productSpecificationAttributeDtoQueryService;
        public ProductSpecificationAttributeDtoQueryServiceController(IProductSpecificationAttributeDtoQueryService productSpecificationAttributeDtoQueryService)
        {
            _productSpecificationAttributeDtoQueryService = productSpecificationAttributeDtoQueryService;
        }

        [AllowAnonymous]
        [Produces("application/json", "text/plain")]
        [HttpGet("getproductspecattrlist")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Core.Utilities.PagedList.IPagedList<Entities.Dtos.ProductSpecificationAttributeDALModels.ProductSpecificationAttributeDTO>))]
        public async Task<IActionResult> GetProductSpecAttrList([FromQuery] GetProductSpecAttrListReqModel request)
        {
            var result = await _productSpecificationAttributeDtoQueryService.GetProductSpecAttrList(request);
            if (result.Success)
                return Ok(result.Data);
            else
                return BadRequest(result.Message);
        }

        [AllowAnonymous]
        [Produces("application/json", "text/plain")]
        [HttpGet("getproductspeficationattr")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Entities.Dtos.ProductSpecificationAttributeDALModels.ProductSpecificationAttributeDTO))]
        public async Task<IActionResult> GetProductSpeficationAttr()
        {
            var result = await _productSpecificationAttributeDtoQueryService.GetProductSpeficationAttr();
            if (result.Success)
                return Ok(result.Data);
            else
                return BadRequest(result.Message);
        }
    }
}
