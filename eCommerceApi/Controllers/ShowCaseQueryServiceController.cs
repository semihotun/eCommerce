using Business.Services.ShowcaseAggregate.ShowcaseServices.Queries;
using Core.Utilities.Identity;
using Entities.RequestModel.ShowcaseAggregate.ShowcaseServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace eCommerce.Areas.Api
{
    [AuthorizeControl]
    [Route("api/[controller]")]
    [ApiController]
    public class ShowCaseQueryServiceController : ControllerBase
    {
        private readonly IShowCaseQueryService _showCaseQueryService;
        public ShowCaseQueryServiceController(IShowCaseQueryService showCaseQueryService)
        {
            _showCaseQueryService = showCaseQueryService;
        }

        [Produces("application/json", "text/plain")]
        [HttpGet("getallshowcase")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetAllShowcase()
        {
            var result = await _showCaseQueryService.GetAllShowcase();
            if (result.Success)
                return Ok(result.Data);
            else
                return BadRequest(result.Message);
        }

        [Produces("application/json", "text/plain")]
        [HttpGet("getshowcase")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetShowcase([FromQuery] GetShowcaseReqModel request)
        {
            var result = await _showCaseQueryService.GetShowcase(request);
            if (result.Success)
                return Ok(result.Data);
            else
                return BadRequest(result.Message);
        }
    }
}
