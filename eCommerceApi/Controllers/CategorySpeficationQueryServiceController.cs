using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.PagedList;
using Microsoft.AspNetCore.Mvc;
using Business.Services.CategoriesAggregate.CategorySpefications.Queries;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Core.Utilities.Identity;
using Entities.RequestModel.CategoriesAggregate.CategorySpefications;

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

        [AllowAnonymous]
        [Produces("application/json", "text/plain")]
        [HttpGet("getbycategoryspeficationid")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Entities.Concrete.CategorySpefication))]
        public async Task<IActionResult> GetByCategorySpeficationId([FromQuery] GetByCategorySpeficationIdReqModel request)
        {
            var result = await _categorySpeficationQueryService.GetByCategorySpeficationId(request);
            if (result.Success)
                return Ok(result.Data);
            else
                return BadRequest(result.Message);
        }

        [AllowAnonymous]
        [Produces("application/json", "text/plain")]
        [HttpGet("getallcategoryspefication")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(System.Collections.Generic.List<Entities.Concrete.CategorySpefication>))]
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
