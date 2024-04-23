using Business.Services.SpeficationAggregate.SpeficationAttributes.Commands;
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
    public class SpecificationAttributeCommandServiceController : ControllerBase
    {
        private readonly ISpecificationAttributeCommandService _specificationAttributeCommandService;
        public SpecificationAttributeCommandServiceController(ISpecificationAttributeCommandService specificationAttributeCommandService)
        {
            _specificationAttributeCommandService = specificationAttributeCommandService;
        }

        [Produces("application/json", "text/plain")]
        [HttpPost("deletespecificationattribute")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> DeleteSpecificationAttribute([FromBody] DeleteSpecificationAttributeReqModel specificationAttribute)
        {
            var result = await _specificationAttributeCommandService.DeleteSpecificationAttribute(specificationAttribute);
            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result.Message);
        }

        [Produces("application/json", "text/plain")]
        [HttpPost("insertspecificationattribute")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> InsertSpecificationAttribute([FromBody] InsertSpecificationAttributeReqModel specificationAttribute)
        {
            var result = await _specificationAttributeCommandService.InsertSpecificationAttribute(specificationAttribute);
            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result.Message);
        }

        [Produces("application/json", "text/plain")]
        [HttpPost("updatespecificationattribute")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> UpdateSpecificationAttribute([FromBody] UpdateSpecificationAttributeReqModel request)
        {
            var result = await _specificationAttributeCommandService.UpdateSpecificationAttribute(request);
            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result.Message);
        }
    }
}
