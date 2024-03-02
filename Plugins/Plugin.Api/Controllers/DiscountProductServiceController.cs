 using System;
using System.Collections.Generic;
using System.Text;
using X.PagedList;
using Microsoft.AspNetCore.Mvc;
using Business.Services.DiscountsAggregate.DiscountProducts;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Core.Utilities.Identity;
using Entities.Concrete.DiscountsAggregate;
using Business.Services.DiscountsAggregate.DiscountProducts.DiscountProductServiceModel; 
 namespace eCommerce.Areas.Api { 
 [AuthorizeControl] 
 [Route("api/[controller]")] 
 [ApiController] 
 public class DiscountProductServiceController : ControllerBase{ 
 private readonly IDiscountProductService _discountProductService; 
 public DiscountProductServiceController(IDiscountProductService discountProductService){ 
 _discountProductService=discountProductService; 
 } 
 [Produces("application/json", "text/plain")] 
 [HttpPost("deletediscountproduct")] 
 [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))] 
 public async Task<IActionResult> DeleteDiscountProduct ([FromBody]DiscountProduct discountProduct) { 
 var result = await _discountProductService.DeleteDiscountProduct(discountProduct); 
 if(result.Success) 
 return Ok(result.Success); 
 else 
 return BadRequest(result.Message); 
 } 
 [Produces("application/json", "text/plain")] 
 [HttpPost("adddiscountproduct")] 
 [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))] 
 public async Task<IActionResult> AddDiscountProduct ([FromBody]DiscountProduct discountProduct) { 
 var result = await _discountProductService.AddDiscountProduct(discountProduct); 
 if(result.Success) 
 return Ok(result.Success); 
 else 
 return BadRequest(result.Message); 
 } 
 [Produces("application/json", "text/plain")] 
 [HttpGet("getalldiscountproduct")] 
 [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))] 
 public async Task<IActionResult> GetAllDiscountProduct ([FromQuery]GetAllDiscountProduct request) { 
 var result = await _discountProductService.GetAllDiscountProduct(request); 
 if(result.Success) 
 return Ok(result.Data); 
 else 
 return BadRequest(result.Message); 
 } 
 } 
 }
