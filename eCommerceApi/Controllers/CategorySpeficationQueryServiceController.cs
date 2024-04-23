using Business.Services.CategoriesAggregate.CategorySpefications.Queries;
using Core.Utilities.Identity;
using Entities.RequestModel.CategoriesAggregate.CategorySpefications;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace eCommerce.Areas.Api
{
    [AuthorizeControl]
    [Route("api/[controller]")]
    [ApiController]
    public class CategorySpeficationQueryServiceController : ControllerBase
    {
        private readonly ICategorySpeficationQueryService _categorySpeficationQueryService;
        public CategorySpeficationQueryServiceController(ICategorySpeficationQueryService categorySpeficationQueryService)
        {
            _categorySpeficationQueryService = categorySpeficationQueryService;
        }

        [Produces("application/json", "text/plain")]
        [HttpGet("getbycategoryspeficationid")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetByCategorySpeficationId([FromQuery] GetByCategorySpeficationIdReqModel request)
        {
            var result = await _categorySpeficationQueryService.GetByCategorySpeficationId(request);
            if (result.Success)
                return Ok(result.Data);
            else
                return BadRequest(result.Message);
        }

        [Produces("application/json", "text/plain")]
        [HttpGet("getallcategoryspefication")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetAllCategorySpefication([FromQuery] GetAllCategorySpeficationReqModel request)
        {
            var result = await _categorySpeficationQueryService.GetAllCategorySpefication(request);
            if (result.Success)
                return Ok(result.Data);
            else
                return BadRequest(result.Message);
        }
    }
}
