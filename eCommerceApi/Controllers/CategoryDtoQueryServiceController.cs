using Business.Services.CategoriesAggregate.Categories.DtoQueries;
using Core.Utilities.Identity;
using Entities.Dtos.CategoryDALModels;
using Entities.RequestModel.CategoriesAggregate.CategorySpefications;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace eCommerce.Areas.Api
{
    [AuthorizeControl]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryDtoQueryServiceController : ControllerBase
    {
        private readonly ICategoryDtoQueryService _categoryDtoQueryService;
        public CategoryDtoQueryServiceController(ICategoryDtoQueryService categoryDtoQueryService)
        {
            _categoryDtoQueryService = categoryDtoQueryService;
        }

        [Produces("application/json", "text/plain")]
        [HttpGet("getallcategorytreelist")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetAllCategoryTreeList()
        {
            var result = await _categoryDtoQueryService.GetAllCategoryTreeList();
            if (result.Success)
                return Ok(result.Data);
            else
                return BadRequest(result.Message);
        }

        [Produces("application/json", "text/plain")]
        [HttpGet("getcategoryspefication")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetCategorySpefication([FromQuery] GetCategorySpeficationReqModel request)
        {
            var result = await _categoryDtoQueryService.GetCategorySpefication(request);
            if (result.Success)
                return Ok(result.Data);
            else
                return BadRequest(result.Message);
        }

        [Produces("application/json", "text/plain")]
        [HttpGet("getcategoryspeficationoptiondto")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetCategorySpeficationOptionDTO([FromQuery] GetCategorySpeficationOptionDTO request)
        {
            var result = await _categoryDtoQueryService.GetCategorySpeficationOptionDTO(request);
            if (result.Success)
                return Ok(result.Data);
            else
                return BadRequest(result.Message);
        }

        [Produces("application/json", "text/plain")]
        [HttpGet("gethierarchy")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetHierarchy()
        {
            var result = await _categoryDtoQueryService.GetHierarchy();
            if (result.Success)
                return Ok(result.Data);
            else
                return BadRequest(result.Message);
        }
    }
}
