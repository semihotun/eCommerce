using Business.Services.ShowcaseAggregate.ShowcaseServices.Commands;
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
    public class ShowCaseCommandServiceController : ControllerBase
    {
        private readonly IShowCaseCommandService _showCaseCommandService;
        public ShowCaseCommandServiceController(IShowCaseCommandService showCaseCommandService)
        {
            _showCaseCommandService = showCaseCommandService;
        }

        [Produces("application/json", "text/plain")]
        [HttpPost("updateshowcase")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> UpdateShowcase([FromBody] UpdateShowcaseReqModel showCase)
        {
            var result = await _showCaseCommandService.UpdateShowcase(showCase);
            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result.Message);
        }

        [Produces("application/json", "text/plain")]
        [HttpPost("insertshowcase")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> InsertShowcase([FromBody] InsertShowcaseReqModel showCase)
        {
            var result = await _showCaseCommandService.InsertShowcase(showCase);
            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result.Message);
        }

        [Produces("application/json", "text/plain")]
        [HttpPost("deleteshowcase")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> DeleteShowCase([FromBody] DeleteShowCaseReqModel showCase)
        {
            var result = await _showCaseCommandService.DeleteShowCase(showCase);
            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result.Message);
        }
    }
}
