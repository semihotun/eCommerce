using Business.Services.ShowcaseAggregate.ShowcaseServices.DtoQueries;
using Core.Utilities.Identity;
using Entities.Dtos.ShowcaseDALModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace eCommerce.Areas.Api
{
    [AuthorizeControl]
    [Route("api/[controller]")]
    [ApiController]
    public class ShowCaseDtoQueryServiceController : ControllerBase
    {
        private readonly IShowCaseDtoQueryService _showCaseDtoQueryService;
        public ShowCaseDtoQueryServiceController(IShowCaseDtoQueryService showCaseDtoQueryService)
        {
            _showCaseDtoQueryService = showCaseDtoQueryService;
        }

        [Produces("application/json", "text/plain")]
        [HttpGet("getshowcasedto")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetShowCaseDto([FromQuery] GetShowCaseDto request)
        {
            var result = await _showCaseDtoQueryService.GetShowCaseDto(request);
            if (result.Success)
                return Ok(result.Data);
            else
                return BadRequest(result.Message);
        }

        [Produces("application/json", "text/plain")]
        [HttpGet("getallshowcasedto")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetAllShowCaseDto()
        {
            var result = await _showCaseDtoQueryService.GetAllShowCaseDto();
            if (result.Success)
                return Ok(result.Data);
            else
                return BadRequest(result.Message);
        }
    }
}
