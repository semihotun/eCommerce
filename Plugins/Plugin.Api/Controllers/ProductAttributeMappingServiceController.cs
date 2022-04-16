 using System;
using System.Collections.Generic;
using System.Text;
using X.PagedList;
using Microsoft.AspNetCore.Mvc;
using Business.Services.ProductAggregate.ProductAttributeMappings;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Core.Utilities.Identity;
using Business.Services.ProductAggregate.ProductAttributeMappings.ProductAttributeMappingServiceModel;
using Entities.Concrete.ProductAggregate; 
 namespace eCommerce.Areas.Api { 
 [AuthorizeControl] 
 [Route("api/[controller]")] 
 [ApiController] 
 public class ProductAttributeMappingServiceController : ControllerBase{ 
 private readonly IProductAttributeMappingService _productAttributeMappingService; 
 
 public ProductAttributeMappingServiceController(IProductAttributeMappingService productAttributeMappingService){ 
 _productAttributeMappingService=productAttributeMappingService; 
 } 
 
 
 [Produces("application/json", "text/plain")] 
 [HttpGet("getallproductattributemapping")] 
 [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))] 
 public async Task<IActionResult> GetAllProductAttributeMapping ([FromQuery]GetAllProductAttributeMapping request) { 
 
 var result = await _productAttributeMappingService.GetAllProductAttributeMapping(request); 
 
 if(result.Success) 
 return Ok(result.Data); 
 else 
 return BadRequest(result.Message); 
 } 
 
 
 [Produces("application/json", "text/plain")] 
 [HttpPost("deleteproductattributemapping")] 
 [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))] 
 public async Task<IActionResult> DeleteProductAttributeMapping ([FromBody]DeleteProductAttributeMapping request) { 
 
 var result = await _productAttributeMappingService.DeleteProductAttributeMapping(request); 
 
 if(result.Success) 
 return Ok(result.Success); 
 else 
 return BadRequest(result.Message); 
 
 } 
 
 
 [Produces("application/json", "text/plain")] 
 [HttpGet("getproductattributemappingsbyproductid")] 
 [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))] 
 public async Task<IActionResult> GetProductAttributeMappingsByProductId ([FromQuery]GetProductAttributeMappingsByProductId request) { 
 
 var result = await _productAttributeMappingService.GetProductAttributeMappingsByProductId(request); 
 
 if(result.Success) 
 return Ok(result.Data); 
 else 
 return BadRequest(result.Message); 
 } 
 
 
 [Produces("application/json", "text/plain")] 
 [HttpGet("getproductattributemappingbyid")] 
 [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))] 
 public async Task<IActionResult> GetProductAttributeMappingById ([FromQuery]GetProductAttributeMappingById request) { 
 
 var result = await _productAttributeMappingService.GetProductAttributeMappingById(request); 
 
 if(result.Success) 
 return Ok(result.Data); 
 else 
 return BadRequest(result.Message); 
 } 
 
 
 [Produces("application/json", "text/plain")] 
 [HttpPost("insertproductattributemapping")] 
 [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))] 
 public async Task<IActionResult> InsertProductAttributeMapping ([FromBody]ProductAttributeMapping productAttributeMapping) { 
 
 var result = await _productAttributeMappingService.InsertProductAttributeMapping(productAttributeMapping); 
 
 if(result.Success) 
 return Ok(result.Success); 
 else 
 return BadRequest(result.Message); 
 
 } 
 
 
 [Produces("application/json", "text/plain")] 
 [HttpPost("updateproductattributemapping")] 
 [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))] 
 public async Task<IActionResult> UpdateProductAttributeMapping ([FromBody]ProductAttributeMapping productAttributeMapping) { 
 
 var result = await _productAttributeMappingService.UpdateProductAttributeMapping(productAttributeMapping); 
 
 if(result.Success) 
 return Ok(result.Success); 
 else 
 return BadRequest(result.Message); 
 
 } 
 
 } 
 }
