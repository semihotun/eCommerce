 using System;
using System.Collections.Generic;
using System.Text;
using X.PagedList;
using Microsoft.AspNetCore.Mvc;
using Business.Services.DiscountsAggregate.Discounts;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Core.Utilities.Identity;
using Business.Services.DiscountsAggregate.Discounts.DiscountServiceModel;
using Entities.Concrete.DiscountsAggregate; 
 namespace eCommerce.Areas.Api { 
 [AuthorizeControl] 
 [Route("api/[controller]")] 
 [ApiController] 
 public class DiscountServiceController : ControllerBase{ 
 private readonly IDiscountService _discountService; 
 public DiscountServiceController(IDiscountService discountService){ 
 _discountService=discountService; 
 } 
 [Produces("application/json", "text/plain")] 
 [HttpGet("getdiscount")] 
 [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))] 
 public async Task<IActionResult> GetDiscount ([FromQuery]GetDiscount request) { 
 var result = await _discountService.GetDiscount(request); 
 if(result.Success) 
 return Ok(result.Data); 
 else 
 return BadRequest(result.Message); 
 } 
 [Produces("application/json", "text/plain")] 
 [HttpPost("adddiscount")] 
 [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))] 
 public async Task<IActionResult> AddDiscount ([FromBody]Discount discount) { 
 var result = await _discountService.AddDiscount(discount); 
 if(result.Success) 
 return Ok(result.Success); 
 else 
 return BadRequest(result.Message); 
 } 
 [Produces("application/json", "text/plain")] 
 [HttpPost("deletediscount")] 
 [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))] 
 public async Task<IActionResult> DeleteDiscount ([FromBody]Discount discount) { 
 var result = await _discountService.DeleteDiscount(discount); 
 if(result.Success) 
 return Ok(result.Success); 
 else 
 return BadRequest(result.Message); 
 } 
 [Produces("application/json", "text/plain")] 
 [HttpGet("getalllist")] 
 [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))] 
 public async Task<IActionResult> GetAllList ([FromQuery]GetAllList request) { 
 var result = await _discountService.GetAllList(request); 
 if(result.Success) 
 return Ok(result.Data); 
 else 
 return BadRequest(result.Message); 
 } 
 [Produces("application/json", "text/plain")] 
 [HttpPost("updatediscount")] 
 [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))] 
 public async Task<IActionResult> UpdateDiscount ([FromBody]Discount discount) { 
 var result = await _discountService.UpdateDiscount(discount); 
 if(result.Success) 
 return Ok(result.Success); 
 else 
 return BadRequest(result.Message); 
 } 
 } 
 }
