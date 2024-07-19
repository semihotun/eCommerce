using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.PagedList;
using Microsoft.AspNetCore.Mvc;
using Business.Services.ShowcaseAggregate.ShowcaseServices.DtoQueries;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Core.Utilities.Identity;
using Entities.Dtos.ShowcaseDALModels;

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

        [AllowAnonymous]
        [Produces("application/json", "text/plain")]
        [HttpGet("getshowcasedto")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Entities.Dtos.ShowcaseDALModels.ShowCaseDTO))]
        public async Task<IActionResult> GetShowCaseDto([FromQuery] GetShowCaseDto request)
        {
            var result = await _showCaseDtoQueryService.GetShowCaseDto(request);
            if (result.Success)
                return Ok(result.Data);
            else
                return BadRequest(result.Message);
        }

        [AllowAnonymous]
        [Produces("application/json", "text/plain")]
        [HttpGet("getallshowcasedto")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(System.Collections.Generic.IList<Entities.Dtos.ShowcaseDALModels.ShowCaseDTO>))]
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
