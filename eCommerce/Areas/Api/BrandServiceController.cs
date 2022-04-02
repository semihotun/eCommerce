 using System;
using System.Collections.Generic;
using System.Text;
using X.PagedList;
using Microsoft.AspNetCore.Mvc;
using Business.Services.BrandAggregate.Brands;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Entities.Concrete.BrandAggregate;
using Business.Services.BrandAggregate.Brands.BrandServiceModel; 
 namespace eCommerce.Areas.Api { 
 
 [Route("api/[controller]")] 
 [ApiController] 
 public class BrandServiceController : ControllerBase{ 
 private readonly IBrandService _brandService; 
 
 public BrandServiceController(IBrandService brandService){ 
 _brandService=brandService; 
 } 
 
 [Produces("application/json", "text/plain")] 
 [HttpPost("brandadd")] 
 [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))] 
 [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))] 
 public async Task<IActionResult> BrandAdd ([FromBody]Brand model) { 
 
 var result = await _brandService.BrandAdd(model); 
 
 if(result.Success) 
 return Ok(result.Success); 
 else 
 return BadRequest(result.Message); 
 
 } 
 
 [Produces("application/json", "text/plain")] 
 [HttpGet("getbrandlist")] 
 [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))] 
 public async Task<IActionResult> GetBrandList (GetBrandList request) { 
 
 var result = await _brandService.GetBrandList(request); 
 
 if(result.Success) 
 return Ok(result.Success); 
 else 
 return BadRequest(result.Message); 
 } 
 
 [Produces("application/json", "text/plain")] 
 [HttpGet("getbrand")] 
 [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))] 
 public async Task<IActionResult> GetBrand (GetBrand request) { 
 
 var result = await _brandService.GetBrand(request); 
 
 if(result.Success) 
 return Ok(result.Success); 
 else 
 return BadRequest(result.Message); 
 } 
 
 [Produces("application/json", "text/plain")] 
 [HttpPost("deletebrand")] 
 [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))] 
 [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))] 
 public async Task<IActionResult> DeleteBrand ([FromBody]Brand brand) { 
 
 var result = await _brandService.DeleteBrand(brand); 
 
 if(result.Success) 
 return Ok(result.Success); 
 else 
 return BadRequest(result.Message); 
 
 } 
 
 [Produces("application/json", "text/plain")] 
 [HttpPost("updatebrand")] 
 [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))] 
 [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))] 
 public async Task<IActionResult> UpdateBrand ([FromBody]Brand brand) { 
 
 var result = await _brandService.UpdateBrand(brand); 
 
 if(result.Success) 
 return Ok(result.Success); 
 else 
 return BadRequest(result.Message); 
 
 } 
 
 [Produces("application/json", "text/plain")] 
 [HttpGet("getbranddropdown")] 
 [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))] 
 public async Task<IActionResult> GetBrandDropdown (GetBrandDropdown request) { 
 
 var result = await _brandService.GetBrandDropdown(request); 
 
 if(result.Success) 
 return Ok(result.Success); 
 else 
 return BadRequest(result.Message); 
 } 
 
 } 
 }
