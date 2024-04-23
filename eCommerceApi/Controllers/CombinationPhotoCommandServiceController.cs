using Business.Services.PhotoAggregate.CombinationPhotos.Commands;
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
