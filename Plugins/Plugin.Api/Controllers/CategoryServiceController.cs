 using System;
using System.Collections.Generic;
using System.Text;
using X.PagedList;
using Microsoft.AspNetCore.Mvc;
using Business.Services.CategoriesAggregate.Categories;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Core.Utilities.Identity;
using Business.Services.CategoriesAggregate.Categories.CategoryServiceModel;
using Entities.Concrete.CategoriesAggregate; 
 namespace eCommerce.Areas.Api { 
 [AuthorizeControl] 
 [Route("api/[controller]")] 
 [ApiController] 
 public class CategoryServiceController : ControllerBase{ 
 private readonly ICategoryService _categoryService; 
 public CategoryServiceController(ICategoryService categoryService){ 
 _categoryService=categoryService; 
 } 
 [Produces("application/json", "text/plain")] 
 [HttpPost("deletecategory")] 
 [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))] 
 public async Task<IActionResult> DeleteCategory ([FromBody]DeleteCategory request) { 
 var result = await _categoryService.DeleteCategory(request); 
 if(result.Success) 
 return Ok(result.Success); 
 else 
 return BadRequest(result.Message); 
 } 
 [Produces("application/json", "text/plain")] 
 [HttpPost("removerangecategory")] 
 [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))] 
 public async Task<IActionResult> RemoveRangeCategory ([FromBody]RemoveRangeCategory request) { 
 var result = await _categoryService.RemoveRangeCategory(request); 
 if(result.Success) 
 return Ok(result.Success); 
 else 
 return BadRequest(result.Message); 
 } 
 [Produces("application/json", "text/plain")] 
 [HttpGet("getallcategories")] 
 [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))] 
 public async Task<IActionResult> GetAllCategories () { 
 var result = await _categoryService.GetAllCategories(); 
 if(result.Success) 
 return Ok(result.Data); 
 else 
 return BadRequest(result.Message); 
 } 
 [Produces("application/json", "text/plain")] 
 [HttpGet("getallcategoriesbyparentcategoryid")] 
 [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))] 
 public async Task<IActionResult> GetAllCategoriesByParentCategoryId ([FromQuery]GetAllCategoriesByParentCategoryId request) { 
 var result = await _categoryService.GetAllCategoriesByParentCategoryId(request); 
 if(result.Success) 
 return Ok(result.Data); 
 else 
 return BadRequest(result.Message); 
 } 
 [Produces("application/json", "text/plain")] 
 [HttpGet("getcategorybyid")] 
 [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))] 
 public async Task<IActionResult> GetCategoryById ([FromQuery]GetCategoryById request) { 
 var result = await _categoryService.GetCategoryById(request); 
 if(result.Success) 
 return Ok(result.Data); 
 else 
 return BadRequest(result.Message); 
 } 
 [Produces("application/json", "text/plain")] 
 [HttpPost("insertcategory")] 
 [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))] 
 public async Task<IActionResult> InsertCategory ([FromBody]Category category) { 
 var result = await _categoryService.InsertCategory(category); 
 if(result.Success) 
 return Ok(result.Success); 
 else 
 return BadRequest(result.Message); 
 } 
 [Produces("application/json", "text/plain")] 
 [HttpPost("updatecategory")] 
 [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))] 
 public async Task<IActionResult> UpdateCategory ([FromBody]Category category) { 
 var result = await _categoryService.UpdateCategory(category); 
 if(result.Success) 
 return Ok(result.Success); 
 else 
 return BadRequest(result.Message); 
 } 
 [Produces("application/json", "text/plain")] 
 [HttpGet("getcategorydropdown")] 
 [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))] 
 public async Task<IActionResult> GetCategoryDropdown ([FromQuery]GetCategoryDropdown request) { 
 var result = await _categoryService.GetCategoryDropdown(request); 
 if(result.Success) 
 return Ok(result.Data); 
 else 
 return BadRequest(result.Message); 
 } 
 [Produces("application/json", "text/plain")] 
 [HttpPost("changenodeposition")] 
 [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))] 
 public async Task<IActionResult> ChangeNodePosition ([FromBody]ChangeNodePosition request) { 
 var result = await _categoryService.ChangeNodePosition(request); 
 if(result.Success) 
 return Ok(result.Success); 
 else 
 return BadRequest(result.Message); 
 } 
 [Produces("application/json", "text/plain")] 
 [HttpPost("deletenodes")] 
 [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))] 
 public async Task<IActionResult> DeleteNodes ([FromBody]DeleteNodes request) { 
 var result = await _categoryService.DeleteNodes(request); 
 if(result.Success) 
 return Ok(result.Success); 
 else 
 return BadRequest(result.Message); 
 } 
 } 
 }
