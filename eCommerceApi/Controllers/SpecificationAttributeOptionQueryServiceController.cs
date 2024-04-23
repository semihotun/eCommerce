using Business.Services.SpeficationAggregate.SpecificationAttributeOptions.Queries;
using Core.Utilities.Identity;
using Entities.RequestModel.SpeficationAggregate.SpecificationAttributeOptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace eCommerce.Areas.Api
{
    [AuthorizeControl]
    [Route("api/[controller]")]
    [ApiController]
    public class SpecificationAttributeOptionQueryServiceController : ControllerBase
    {
        private readonly ISpecificationAttributeOptionQueryService _specificationAttributeOptionQueryService;
        public SpecificationAttributeOptionQueryServiceController(ISpecificationAttributeOptionQueryService specificationAttributeOptionQueryService)
        {
            _specificationAttributeOptionQueryService = specificationAttributeOptionQueryService;
        }

        [Produces("application/json", "text/plain")]
        [HttpGet("getspecificationattributeoptionbyid")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetSpecificationAttributeOptionById([FromQuery] GetSpecificationAttributeOptionByIdReqModel request)
        {
            var result = await _specificationAttributeOptionQueryService.GetSpecificationAttributeOptionById(request);
            if (result.Success)
                return Ok(result.Data);
            else
                return BadRequest(result.Message);
        }

        [Produces("application/json", "text/plain")]
        [HttpGet("getspecificationattributeoptionsbyids")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetSpecificationAttributeOptionsByIds([FromQuery] GetSpecificationAttributeOptionsByIdsReqModel request)
        {
            var result = await _specificationAttributeOptionQueryService.GetSpecificationAttributeOptionsByIds(request);
            if (result.Success)
                return Ok(result.Data);
            else
                return BadRequest(result.Message);
        }

        [Produces("application/json", "text/plain")]
        [HttpGet("getspecificationattributeoptionsbyspecificationattribute")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetSpecificationAttributeOptionsBySpecificationAttribute([FromQuery] GetSpecificationAttributeOptionsBySpecificationAttributeReqModel request)
        {
            var result = await _specificationAttributeOptionQueryService.GetSpecificationAttributeOptionsBySpecificationAttribute(request);
            if (result.Success)
                return Ok(result.Data);
            else
                return BadRequest(result.Message);
        }

        [Produces("application/json", "text/plain")]
        [HttpGet("getnotexistingspecificationattributeoptions")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetNotExistingSpecificationAttributeOptions([FromQuery] GetNotExistingSpecificationAttributeOptionsReqModel request)
        {
            var result = await _specificationAttributeOptionQueryService.GetNotExistingSpecificationAttributeOptions(request);
            if (result.Success)
                return Ok(result.Data);
            else
                return BadRequest(result.Message);
        }
    }
}
