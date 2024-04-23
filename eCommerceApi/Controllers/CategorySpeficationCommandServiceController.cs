using Business.Services.CategoriesAggregate.CategorySpefications.Commands;
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
    public class CategorySpeficationCommandServiceController : ControllerBase
    {
        private readonly ICategorySpeficationCommandService _categorySpeficationCommandService;
        public CategorySpeficationCommandServiceController(ICategorySpeficationCommandService categorySpeficationCommandService)
        {
            _categorySpeficationCommandService = categorySpeficationCommandService;
        }

        [Produces("application/json", "text/plain")]
        [HttpPost("deletecategoryspefication")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> DeleteCategorySpefication([FromBody] DeleteCategorySpeficationReqModel request)
        {
            var result = await _categorySpeficationCommandService.DeleteCategorySpefication(request);
            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result.Message);
        }

        [Produces("application/json", "text/plain")]
        [HttpPost("insertcategoryspefication")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> InsertCategorySpefication([FromBody] InsertCategorySpeficationReqModel request)
        {
            var result = await _categorySpeficationCommandService.InsertCategorySpefication(request);
            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result.Message);
        }

        [Produces("application/json", "text/plain")]
        [HttpPost("updatecategoryspefication")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> UpdateCategorySpefication([FromBody] UpdateCategorySpeficationReqModel request)
        {
            var result = await _categorySpeficationCommandService.UpdateCategorySpefication(request);
            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result.Message);
        }
    }
}
