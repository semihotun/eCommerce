using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.PagedList;
using Microsoft.AspNetCore.Mvc;
using Business.Services.PhotoAggregate.CombinationPhotos.Commands;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Core.Utilities.Identity;
using Entities.RequestModel.PhotoAggregate.CombinationPhotos;

namespace eCommerce.Areas.Api
{
    [AuthorizeControl]
    [Route("api/[controller]")]
    [ApiController]
    public class CombinationPhotoCommandServiceController : ControllerBase
    {
        private readonly ICombinationPhotoCommandService _combinationPhotoCommandService;
        public CombinationPhotoCommandServiceController(ICombinationPhotoCommandService combinationPhotoCommandService)
        {
            _combinationPhotoCommandService = combinationPhotoCommandService;
        }

        [Produces("application/json", "text/plain")]
        [HttpPost("insertcombinationphotos")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Core.Utilities.Results.Result))]
        public async Task<IActionResult> InsertCombinationPhotos([FromBody] InsertCombinationPhotosReqModel request)
        {
            var result = await _combinationPhotoCommandService.InsertCombinationPhotos(request);
            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result.Message);
        }
    }
}
