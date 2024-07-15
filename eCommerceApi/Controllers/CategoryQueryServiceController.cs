using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.PagedList;
using Microsoft.AspNetCore.Mvc;
using Business.Services.CategoriesAggregate.Categories.Queries;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Core.Utilities.Identity;
using Entities.RequestModel.CategoriesAggregate.Categories;

namespace eCommerce.Areas.Api
{
    [AuthorizeControl]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryQueryServiceController : ControllerBase
    {
        private readonly ICategoryQueryService _categoryQueryService;
        public CategoryQueryServiceController(ICategoryQueryService categoryQueryService)
        {
            _categoryQueryService = categoryQueryService;
        }

        [Produces("application/json", "text/plain")]
        [HttpGet("getallcategories")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Core.Utilities.Results.Result<System.Collections.Generic.List<Entities.Concrete.Category>>))]
        public async Task<IActionResult> GetAllCategories()
        {
            var result = await _categoryQueryService.GetAllCategories();
            if (result.Success)
                return Ok(result.Data);
            else
                return BadRequest(result.Message);
        }

        [Produces("application/json", "text/plain")]
        [HttpGet("getallcategoriesbyparentcategoryid")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Core.Utilities.Results.Result<System.Collections.Generic.List<Entities.Concrete.Category>>))]
        public async Task<IActionResult> GetAllCategoriesByParentCategoryId([FromQuery] GetAllCategoriesByParentCategoryIdReqModel request)
        {
            var result = await _categoryQueryService.GetAllCategoriesByParentCategoryId(request);
            if (result.Success)
                return Ok(result.Data);
            else
                return BadRequest(result.Message);
        }

        [Produces("application/json", "text/plain")]
        [HttpGet("getcategorybyid")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Core.Utilities.Results.Result<Entities.Concrete.Category>))]
        public async Task<IActionResult> GetCategoryById([FromQuery] GetCategoryByIdReqModel request)
        {
            var result = await _categoryQueryService.GetCategoryById(request);
            if (result.Success)
                return Ok(result.Data);
            else
                return BadRequest(result.Message);
        }

        [Produces("application/json", "text/plain")]
        [HttpGet("getcategorydropdown")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Core.Utilities.Results.Result<System.Collections.Generic.IEnumerable<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem>>))]
        public async Task<IActionResult> GetCategoryDropdown([FromQuery] GetCategoryDropdownReqModel request)
        {
            var result = await _categoryQueryService.GetCategoryDropdown(request);
            if (result.Success)
                return Ok(result.Data);
            else
                return BadRequest(result.Message);
        }
    }
}
