using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.PagedList;
using Microsoft.AspNetCore.Mvc;
using Business.Services.CategoriesAggregate.Categories.Commands;
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
    public class CategoryCommandServiceController : ControllerBase
    {
        private readonly ICategoryCommandService _categoryCommandService;
        public CategoryCommandServiceController(ICategoryCommandService categoryCommandService)
        {
            _categoryCommandService = categoryCommandService;
        }

        [Produces("application/json", "text/plain")]
        [HttpPost("insertcategory")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Core.Utilities.Results.Result<Entities.Concrete.Category>))]
        public async Task<IActionResult> InsertCategory([FromBody] InsertCategoryReqModel request)
        {
            var result = await _categoryCommandService.InsertCategory(request);
            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result.Message);
        }

        [Produces("application/json", "text/plain")]
        [HttpPost("updatecategory")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Core.Utilities.Results.Result))]
        public async Task<IActionResult> UpdateCategory([FromBody] UpdateCategoryReqModel request)
        {
            var result = await _categoryCommandService.UpdateCategory(request);
            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result.Message);
        }

        [Produces("application/json", "text/plain")]
        [HttpPost("deletecategory")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Core.Utilities.Results.Result))]
        public async Task<IActionResult> DeleteCategory([FromBody] DeleteCategoryReqModel request)
        {
            var result = await _categoryCommandService.DeleteCategory(request);
            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result.Message);
        }

        [Produces("application/json", "text/plain")]
        [HttpPost("removerangecategory")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Core.Utilities.Results.Result))]
        public async Task<IActionResult> RemoveRangeCategory([FromBody] RemoveRangeCategoryReqModel request)
        {
            var result = await _categoryCommandService.RemoveRangeCategory(request);
            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result.Message);
        }

        [Produces("application/json", "text/plain")]
        [HttpPost("changenodeposition")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Core.Utilities.Results.Result))]
        public async Task<IActionResult> ChangeNodePosition([FromBody] ChangeNodePositionReqModel request)
        {
            var result = await _categoryCommandService.ChangeNodePosition(request);
            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result.Message);
        }

        [Produces("application/json", "text/plain")]
        [HttpPost("deletenodes")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Core.Utilities.Results.Result))]
        public async Task<IActionResult> DeleteNodes([FromBody] DeleteNodesReqModel request)
        {
            var result = await _categoryCommandService.DeleteNodes(request);
            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result.Message);
        }
    }
}
