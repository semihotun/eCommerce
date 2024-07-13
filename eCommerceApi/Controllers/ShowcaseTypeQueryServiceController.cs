using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.PagedList;
using Microsoft.AspNetCore.Mvc;
using Business.Services.ShowcaseAggregate.ShowcaseTypes.Queries;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Core.Utilities.Identity;
using Entities.RequestModel.ShowcaseAggregate.ShowcaseTypes;

namespace eCommerce.Areas.Api
{
    [AuthorizeControl]
    [Route("api/[controller]")]
    [ApiController]
    public class ShowcaseTypeQueryServiceController : ControllerBase
    {
        private readonly IShowcaseTypeQueryService _showcaseTypeQueryService;
        public ShowcaseTypeQueryServiceController(IShowcaseTypeQueryService showcaseTypeQueryService)
        {
            _showcaseTypeQueryService = showcaseTypeQueryService;
        }

        [Produces("application/json", "text/plain")]
        [HttpGet("getallshowcasetype")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetAllShowCaseType()
        {
            var result = await _showcaseTypeQueryService.GetAllShowCaseType();
            if (result.Success)
                return Ok(result.Data);
            else
                return BadRequest(result.Message);
        }

        [Produces("application/json", "text/plain")]
        [HttpGet("getallshowcasetypeselectlistitem")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetAllShowCaseTypeSelectListItem([FromQuery] GetAllShowCaseTypeSelectListItemReqModel request)
        {
            var result = await _showcaseTypeQueryService.GetAllShowCaseTypeSelectListItem(request);
            if (result.Success)
                return Ok(result.Data);
            else
                return BadRequest(result.Message);
        }
    }
}
