using Business.Services.SpeficationAggregate.SpeficationAttributes.Queries;
using Core.Utilities.Identity;
using Entities.RequestModel.SpeficationAggregate.SpecificationAttributes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

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

        [Produces("application/json", "text/plain")]
        [HttpGet("getspecificationattributebyid")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetSpecificationAttributeById([FromQuery] GetSpecificationAttributeByIdReqModel request)
        {
            var result = await _specificationAttributeQueryService.GetSpecificationAttributeById(request);
            if (result.Success)
                return Ok(result.Data);
            else
                return BadRequest(result.Message);
        }

        [Produces("application/json", "text/plain")]
        [HttpGet("getspecificationattributebyids")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetSpecificationAttributeByIds([FromQuery] GetSpecificationAttributeByIdsReqModel request)
        {
            var result = await _specificationAttributeQueryService.GetSpecificationAttributeByIds(request);
            if (result.Success)
                return Ok(result.Data);
            else
                return BadRequest(result.Message);
        }

        [Produces("application/json", "text/plain")]
        [HttpGet("getspecificationattributes")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetSpecificationAttributes([FromQuery] GetSpecificationAttributesReqModel request)
        {
            var result = await _specificationAttributeQueryService.GetSpecificationAttributes(request);
            if (result.Success)
                return Ok(result.Data);
            else
                return BadRequest(result.Message);
        }

        [Produces("application/json", "text/plain")]
        [HttpGet("getproductspeficationattributedropdwon")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
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
