using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.PagedList;
using Microsoft.AspNetCore.Mvc;
using Business.Services.PhotoAggregate.CombinationPhotos.Queries;
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
    public class CombinationPhotoQueryServiceController : ControllerBase
    {
        private readonly ICombinationPhotoQueryService _combinationPhotoQueryService;
        public CombinationPhotoQueryServiceController(ICombinationPhotoQueryService combinationPhotoQueryService)
        {
            _combinationPhotoQueryService = combinationPhotoQueryService;
        }

        [Produces("application/json", "text/plain")]
        [HttpGet("getallcombinationphotos")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Core.Utilities.Results.Result<System.Collections.Generic.List<Entities.Concrete.CombinationPhoto>>))]
        public async Task<IActionResult> GetAllCombinationPhotos([FromQuery] GetAllCombinationPhotosReqModel request)
        {
            var result = await _combinationPhotoQueryService.GetAllCombinationPhotos(request);
            if (result.Success)
                return Ok(result.Data);
            else
                return BadRequest(result.Message);
        }
    }
}
