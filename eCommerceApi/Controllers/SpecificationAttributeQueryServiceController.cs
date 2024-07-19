using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.PagedList;
using Microsoft.AspNetCore.Mvc;
using Business.Services.SpeficationAggregate.SpeficationAttributes.Queries;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Core.Utilities.Identity;
using Entities.RequestModel.SpeficationAggregate.SpecificationAttributes;

namespace eCommerce.Areas.Api
{
    [AuthorizeControl]
    [Route("api/[controller]")]
    [ApiController]
    public class SpecificationAttributeQueryServiceController : ControllerBase
    {
        private readonly ISpecificationAttributeQueryService _specificationAttributeQueryService;
        public SpecificationAttributeQueryServiceController(ISpecificationAttributeQueryService specificationAttributeQueryService)
        {
            _specificationAttributeQueryService = specificationAttributeQueryService;
        }

        [AllowAnonymous]
        [Produces("application/json", "text/plain")]
        [HttpGet("getspecificationattributebyid")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Entities.Concrete.SpecificationAttribute))]
        public async Task<IActionResult> GetSpecificationAttributeById([FromQuery] GetSpecificationAttributeByIdReqModel request)
        {
            var result = await _specificationAttributeQueryService.GetSpecificationAttributeById(request);
            if (result.Success)
                return Ok(result.Data);
            else
                return BadRequest(result.Message);
        }

        [AllowAnonymous]
        [Produces("application/json", "text/plain")]
        [HttpGet("getspecificationattributebyids")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(System.Collections.Generic.List<Entities.Concrete.SpecificationAttribute>))]
        public async Task<IActionResult> GetSpecificationAttributeByIds([FromQuery] GetSpecificationAttributeByIdsReqModel request)
        {
            var result = await _specificationAttributeQueryService.GetSpecificationAttributeByIds(request);
            if (result.Success)
                return Ok(result.Data);
            else
                return BadRequest(result.Message);
        }

        [AllowAnonymous]
        [Produces("application/json", "text/plain")]
        [HttpGet("getspecificationattributes")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Core.Utilities.PagedList.IPagedList<Entities.Concrete.SpecificationAttribute>))]
        public async Task<IActionResult> GetSpecificationAttributes([FromQuery] GetSpecificationAttributesReqModel request)
        {
            var result = await _specificationAttributeQueryService.GetSpecificationAttributes(request);
            if (result.Success)
                return Ok(result.Data);
            else
                return BadRequest(result.Message);
        }

        [AllowAnonymous]
        [Produces("application/json", "text/plain")]
        [HttpGet("getproductspeficationattributedropdwon")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(System.Collections.Generic.IEnumerable<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem>))]
        public async Task<IActionResult> GetProductSpeficationAttributeDropdwon([FromQuery] GetProductSpeficationAttributeDropdwonReqModel request)
        {
            var result = await _specificationAttributeQueryService.GetProductSpeficationAttributeDropdwon(request);
            if (result.Success)
                return Ok(result.Data);
            else
                return BadRequest(result.Message);
        }
    }
}
