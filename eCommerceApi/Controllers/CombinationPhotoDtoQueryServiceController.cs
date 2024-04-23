using Business.Services.PhotoAggregate.CombinationPhotos.DtoQueries;
using Core.Utilities.Identity;
using Entities.Dtos.CombinationPhotoDALModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace eCommerce.Areas.Api
{
    [AuthorizeControl]
    [Route("api/[controller]")]
    [ApiController]
    public class CombinationPhotoDtoQueryServiceController : ControllerBase
    {
        private readonly ICombinationPhotoDtoQueryService _combinationPhotoDtoQueryService;
        public CombinationPhotoDtoQueryServiceController(ICombinationPhotoDtoQueryService combinationPhotoDtoQueryService)
        {
            _combinationPhotoDtoQueryService = combinationPhotoDtoQueryService;
        }

        [Produces("application/json", "text/plain")]
        [HttpGet("getallcombinationphotosdto")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetAllCombinationPhotosDTO([FromQuery] GetAllCombinationPhotosDTO request)
        {
            var result = await _combinationPhotoDtoQueryService.GetAllCombinationPhotosDTO(request);
            if (result.Success)
                return Ok(result.Data);
            else
                return BadRequest(result.Message);
        }
    }
}
