 using System;
using System.Collections.Generic;
using System.Text;
using X.PagedList;
using Microsoft.AspNetCore.Mvc;
using Business.Services.DiscountsAggregate.DiscountBrands;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Entities.Concrete.DiscountsAggregate;
using Business.Services.DiscountsAggregate.DiscountBrands.DiscountBrandServiceModel; 
 namespace eCommerce.Areas.Api { 
 
 [Route("api/[controller]")] 
 [ApiController] 
 public class DiscountBrandServiceController : ControllerBase{ 
 private readonly IDiscountBrandService _discountBrandService; 
 
 public DiscountBrandServiceController(IDiscountBrandService discountBrandService){ 
 _discountBrandService=discountBrandService; 
 } 
 
 [Produces("application/json", "text/plain")] 
 [HttpPost("deletediscountbrand")] 
 [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))] 
 [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))] 
 public async Task<IActionResult> DeleteDiscountBrand ([FromBody]DiscountBrand discountBrand) { 
 
 var result = await _discountBrandService.DeleteDiscountBrand(discountBrand); 
 
 if(result.Success) 
 return Ok(result.Success); 
 else 
 return BadRequest(result.Message); 
 
 } 
 
 [Produces("application/json", "text/plain")] 
 [HttpGet("getalldiscountbrand")] 
 [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))] 
 public async Task<IActionResult> GetAllDiscountBrand (GetAllDiscountBrand request) { 
 
 var result = await _discountBrandService.GetAllDiscountBrand(request); 
 
 if(result.Success) 
 return Ok(result.Success); 
 else 
 return BadRequest(result.Message); 
 } 
 
 [Produces("application/json", "text/plain")] 
 [HttpPost("adddiscountbrand")] 
 [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))] 
 [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))] 
 public async Task<IActionResult> AddDiscountBrand ([FromBody]DiscountBrand discountBrand) { 
 
 var result = await _discountBrandService.AddDiscountBrand(discountBrand); 
 
 if(result.Success) 
 return Ok(result.Success); 
 else 
 return BadRequest(result.Message); 
 
 } 
 
 } 
 }
