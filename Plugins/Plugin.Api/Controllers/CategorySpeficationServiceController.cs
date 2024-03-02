 using System;
using System.Collections.Generic;
using System.Text;
using X.PagedList;
using Microsoft.AspNetCore.Mvc;
using Business.Services.CategoriesAggregate.CategorySpefications;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Core.Utilities.Identity;
using Business.Services.CategoriesAggregate.CategorySpefications.CategorySpeficationServiceModel;
using Entities.Concrete.CategoriesAggregate; 
 namespace eCommerce.Areas.Api { 
 [AuthorizeControl] 
 [Route("api/[controller]")] 
 [ApiController] 
 public class CategorySpeficationServiceController : ControllerBase{ 
 private readonly ICategorySpeficationService _categorySpeficationService; 
 public CategorySpeficationServiceController(ICategorySpeficationService categorySpeficationService){ 
 _categorySpeficationService=categorySpeficationService; 
 } 
 [Produces("application/json", "text/plain")] 
 [HttpGet("getbycategoryspeficationid")] 
 [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))] 
 public async Task<IActionResult> GetByCategorySpeficationId ([FromQuery]GetByCategorySpeficationId request) { 
 var result = await _categorySpeficationService.GetByCategorySpeficationId(request); 
 if(result.Success) 
 return Ok(result.Data); 
 else 
 return BadRequest(result.Message); 
 } 
 [Produces("application/json", "text/plain")] 
 [HttpPost("deletecategoryspefication")] 
 [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))] 
 public async Task<IActionResult> DeleteCategorySpefication ([FromBody]CategorySpefication categorySpefication) { 
 var result = await _categorySpeficationService.DeleteCategorySpefication(categorySpefication); 
 if(result.Success) 
 return Ok(result.Success); 
 else 
 return BadRequest(result.Message); 
 } 
 [Produces("application/json", "text/plain")] 
 [HttpPost("insertcategoryspefication")] 
 [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))] 
 public async Task<IActionResult> InsertCategorySpefication ([FromBody]CategorySpefication categorySpefication) { 
 var result = await _categorySpeficationService.InsertCategorySpefication(categorySpefication); 
 if(result.Success) 
 return Ok(result.Success); 
 else 
 return BadRequest(result.Message); 
 } 
 [Produces("application/json", "text/plain")] 
 [HttpPost("updatecategoryspefication")] 
 [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))] 
 public async Task<IActionResult> UpdateCategorySpefication ([FromBody]CategorySpefication categorySpefication) { 
 var result = await _categorySpeficationService.UpdateCategorySpefication(categorySpefication); 
 if(result.Success) 
 return Ok(result.Success); 
 else 
 return BadRequest(result.Message); 
 } 
 [Produces("application/json", "text/plain")] 
 [HttpGet("getallcategoryspefication")] 
 [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))] 
 public async Task<IActionResult> GetAllCategorySpefication ([FromQuery]GetAllCategorySpefication request) { 
 var result = await _categorySpeficationService.GetAllCategorySpefication(request); 
 if(result.Success) 
 return Ok(result.Data); 
 else 
 return BadRequest(result.Message); 
 } 
 } 
 }
