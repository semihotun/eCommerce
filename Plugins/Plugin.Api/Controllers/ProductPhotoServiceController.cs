 using System;
using System.Collections.Generic;
using System.Text;
using X.PagedList;
using Microsoft.AspNetCore.Mvc;
using Business.Services.PhotoAggregate.ProductPhotos;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Core.Utilities.Identity;
using Business.Services.PhotoAggregate.ProductPhotos.ProductPhotoServiceModel;
using Entities.Concrete.PhotoAggregate; 
 namespace eCommerce.Areas.Api { 
 [AuthorizeControl] 
 [Route("api/[controller]")] 
 [ApiController] 
 public class ProductPhotoServiceController : ControllerBase{ 
 private readonly IProductPhotoService _productPhotoService; 
 public ProductPhotoServiceController(IProductPhotoService productPhotoService){ 
 _productPhotoService=productPhotoService; 
 } 
 [Produces("application/json", "text/plain")] 
 [HttpGet("getproductphotobyid")] 
 [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))] 
 public async Task<IActionResult> GetProductPhotoById ([FromQuery]GetProductPhotoById request) { 
 var result = await _productPhotoService.GetProductPhotoById(request); 
 if(result.Success) 
 return Ok(result.Data); 
 else 
 return BadRequest(result.Message); 
 } 
 [Produces("application/json", "text/plain")] 
 [HttpGet("getproductphoto")] 
 [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))] 
 public async Task<IActionResult> GetProductPhoto ([FromQuery]GetProductPhoto request) { 
 var result = await _productPhotoService.GetProductPhoto(request); 
 if(result.Success) 
 return Ok(result.Data); 
 else 
 return BadRequest(result.Message); 
 } 
 [Produces("application/json", "text/plain")] 
 [HttpPost("productphotoinsert")] 
 [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))] 
 public async Task<IActionResult> ProductPhotoInsert ([FromBody]ProductPhoto product) { 
 var result = await _productPhotoService.ProductPhotoInsert(product); 
 if(result.Success) 
 return Ok(result.Success); 
 else 
 return BadRequest(result.Message); 
 } 
 [Produces("application/json", "text/plain")] 
 [HttpPost("addrangeproductphotoinsert")] 
 [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))] 
 public async Task<IActionResult> AddRangeProductPhotoInsert ([FromBody]AddRangeProductPhotoInsert request) { 
 var result = await _productPhotoService.AddRangeProductPhotoInsert(request); 
 if(result.Success) 
 return Ok(result.Success); 
 else 
 return BadRequest(result.Message); 
 } 
 [Produces("application/json", "text/plain")] 
 [HttpPost("productphotodelete")] 
 [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))] 
 public async Task<IActionResult> ProductPhotoDelete ([FromBody]ProductPhotoDelete request) { 
 var result = await _productPhotoService.ProductPhotoDelete(request); 
 if(result.Success) 
 return Ok(result.Success); 
 else 
 return BadRequest(result.Message); 
 } 
 } 
 }
