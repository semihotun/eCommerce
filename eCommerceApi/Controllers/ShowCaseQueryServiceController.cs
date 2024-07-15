using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.PagedList;
using Microsoft.AspNetCore.Mvc;
using Business.Services.ShowcaseAggregate.ShowcaseServices.Queries;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Core.Utilities.Identity;
using Entities.RequestModel.ShowcaseAggregate.ShowcaseServices;

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
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Core.Utilities.Results.Result<System.Collections.Generic.IList<Entities.Concrete.ShowCase>>))]
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
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Core.Utilities.Results.Result<Entities.Concrete.ShowCase>))]
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
