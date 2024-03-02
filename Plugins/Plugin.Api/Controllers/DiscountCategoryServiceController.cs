 using System;
using System.Collections.Generic;
using System.Text;
using X.PagedList;
using Microsoft.AspNetCore.Mvc;
using Business.Services.DiscountsAggregate.DiscountCategorys;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Core.Utilities.Identity;
using Entities.Concrete.DiscountsAggregate;
using Business.Services.DiscountsAggregate.DiscountCategorys.DiscountCategoryServiceModel; 
 namespace eCommerce.Areas.Api { 
 [AuthorizeControl] 
 [Route("api/[controller]")] 
 [ApiController] 
 public class DiscountCategoryServiceController : ControllerBase{ 
 private readonly IDiscountCategoryService _discountCategoryService; 
 public DiscountCategoryServiceController(IDiscountCategoryService discountCategoryService){ 
 _discountCategoryService=discountCategoryService; 
 } 
 [Produces("application/json", "text/plain")] 
 [HttpPost("deletediscountcategory")] 
 [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))] 
 public async Task<IActionResult> DeleteDiscountCategory ([FromBody]DiscountCategory discountCategory) { 
 var result = await _discountCategoryService.DeleteDiscountCategory(discountCategory); 
 if(result.Success) 
 return Ok(result.Success); 
 else 
 return BadRequest(result.Message); 
 } 
 [Produces("application/json", "text/plain")] 
 [HttpGet("getalldiscountcategory")] 
 [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))] 
 public async Task<IActionResult> GetAllDiscountCategory ([FromQuery]GetAllDiscountCategory request) { 
 var result = await _discountCategoryService.GetAllDiscountCategory(request); 
 if(result.Success) 
 return Ok(result.Data); 
 else 
 return BadRequest(result.Message); 
 } 
 [Produces("application/json", "text/plain")] 
 [HttpPost("adddiscountcategory")] 
 [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))] 
 public async Task<IActionResult> AddDiscountCategory ([FromBody]DiscountCategory discountCategory) { 
 var result = await _discountCategoryService.AddDiscountCategory(discountCategory); 
 if(result.Success) 
 return Ok(result.Success); 
 else 
 return BadRequest(result.Message); 
 } 
 } 
 }
