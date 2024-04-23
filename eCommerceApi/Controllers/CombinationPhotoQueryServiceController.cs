using Business.Services.PhotoAggregate.CombinationPhotos.Queries;
using Core.Utilities.Identity;
using Entities.RequestModel.PhotoAggregate.CombinationPhotos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

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
