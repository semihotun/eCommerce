 using System;
using System.Collections.Generic;
using System.Text;
using X.PagedList;
using Microsoft.AspNetCore.Mvc;
using DataAccess.DALs.EntitiyFramework.CategoriesAggregate.Categories;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Core.Utilities.Identity;
using DataAccess.DALs.EntitiyFramework.CategoriesAggregate.Categories.CategoryDALModels; 
 namespace eCommerce.Areas.Api { 
 [AuthorizeControl] 
 [Route("api/[controller]")] 
 [ApiController] 
 public class CategoryDALController : ControllerBase{ 
 private readonly ICategoryDAL _categoryDAL; 
 public CategoryDALController(ICategoryDAL categoryDAL){ 
 _categoryDAL=categoryDAL; 
 } 
 [Produces("application/json", "text/plain")] 
 [HttpGet("getallcategorytreelist")] 
 [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))] 
 public async Task<IActionResult> GetAllCategoryTreeList () { 
 var result = await _categoryDAL.GetAllCategoryTreeList(); 
 if(result.Success) 
 return Ok(result.Data); 
 else 
 return BadRequest(result.Message); 
 } 
 [Produces("application/json", "text/plain")] 
 [HttpGet("getcategoryspefication")] 
 [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))] 
 public async Task<IActionResult> GetCategorySpefication ([FromQuery]GetCategorySpefication request) { 
 var result = await _categoryDAL.GetCategorySpefication(request); 
 if(result.Success) 
 return Ok(result.Data); 
 else 
 return BadRequest(result.Message); 
 } 
 [Produces("application/json", "text/plain")] 
 [HttpGet("getcategoryspeficationoptiondto")] 
 [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))] 
 public async Task<IActionResult> GetCategorySpeficationOptionDTO ([FromQuery]GetCategorySpeficationOptionDTO request) { 
 var result = await _categoryDAL.GetCategorySpeficationOptionDTO(request); 
 if(result.Success) 
 return Ok(result.Data); 
 else 
 return BadRequest(result.Message); 
 } 
 [Produces("application/json", "text/plain")] 
 [HttpGet("gethierarchy")] 
 [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))] 
 public async Task<IActionResult> GetHierarchy () { 
 var result = await _categoryDAL.GetHierarchy(); 
 if(result.Success) 
 return Ok(result.Data); 
 else 
 return BadRequest(result.Message); 
 } 
 } 
 }
