using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.PagedList;
using Microsoft.AspNetCore.Mvc;
using Business.Services.PhotoAggregate.CombinationPhotos.DtoQueries;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Core.Utilities.Identity;
using Entities.Dtos.CombinationPhotoDALModels;

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
