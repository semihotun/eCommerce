 using System;
using System.Collections.Generic;
using System.Text;
using X.PagedList;
using Microsoft.AspNetCore.Mvc;
using Business.Services.ProductAggregate.ProductAttributes;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Core.Utilities.Identity;
using Entities.Concrete.ProductAggregate;
using Business.Services.ProductAggregate.ProductAttributes.ProductAttributeServiceModel; 
 namespace eCommerce.Areas.Api { 
 [AuthorizeControl] 
 [Route("api/[controller]")] 
 [ApiController] 
 public class ProductAttributeServiceController : ControllerBase{ 
 private readonly IProductAttributeService _productAttributeService; 
 public ProductAttributeServiceController(IProductAttributeService productAttributeService){ 
 _productAttributeService=productAttributeService; 
 } 
 [Produces("application/json", "text/plain")] 
 [HttpPost("deleteproductattribute")] 
 [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))] 
 public async Task<IActionResult> DeleteProductAttribute ([FromBody]ProductAttribute productAttribute) { 
 var result = await _productAttributeService.DeleteProductAttribute(productAttribute); 
 if(result.Success) 
 return Ok(result.Success); 
 else 
 return BadRequest(result.Message); 
 } 
 [Produces("application/json", "text/plain")] 
 [HttpGet("getallproductattributes")] 
 [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))] 
 public async Task<IActionResult> GetAllProductAttributes ([FromQuery]GetAllProductAttributes request) { 
 var result = await _productAttributeService.GetAllProductAttributes(request); 
 if(result.Success) 
 return Ok(result.Data); 
 else 
 return BadRequest(result.Message); 
 } 
 [Produces("application/json", "text/plain")] 
 [HttpGet("getallproductattribute")] 
 [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))] 
 public async Task<IActionResult> GetAllProductAttribute () { 
 var result = await _productAttributeService.GetAllProductAttribute(); 
 if(result.Success) 
 return Ok(result.Data); 
 else 
 return BadRequest(result.Message); 
 } 
 [Produces("application/json", "text/plain")] 
 [HttpGet("getproductattributebyid")] 
 [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))] 
 public async Task<IActionResult> GetProductAttributeById ([FromQuery]GetProductAttributeById request) { 
 var result = await _productAttributeService.GetProductAttributeById(request); 
 if(result.Success) 
 return Ok(result.Data); 
 else 
 return BadRequest(result.Message); 
 } 
 [Produces("application/json", "text/plain")] 
 [HttpPost("insertproductattribute")] 
 [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))] 
 public async Task<IActionResult> InsertProductAttribute ([FromBody]ProductAttribute productAttribute) { 
 var result = await _productAttributeService.InsertProductAttribute(productAttribute); 
 if(result.Success) 
 return Ok(result.Success); 
 else 
 return BadRequest(result.Message); 
 } 
 [Produces("application/json", "text/plain")] 
 [HttpPost("updateproductattribute")] 
 [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))] 
 public async Task<IActionResult> UpdateProductAttribute ([FromBody]ProductAttribute productAttribute) { 
 var result = await _productAttributeService.UpdateProductAttribute(productAttribute); 
 if(result.Success) 
 return Ok(result.Success); 
 else 
 return BadRequest(result.Message); 
 } 
 [Produces("application/json", "text/plain")] 
 [HttpGet("getnotexistingattributes")] 
 [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))] 
 public async Task<IActionResult> GetNotExistingAttributes ([FromQuery]GetNotExistingAttributes request) { 
 var result = await _productAttributeService.GetNotExistingAttributes(request); 
 if(result.Success) 
 return Ok(result.Data); 
 else 
 return BadRequest(result.Message); 
 } 
 [Produces("application/json", "text/plain")] 
 [HttpGet("getproductattributedropdown")] 
 [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))] 
 public async Task<IActionResult> GetProductAttributeDropdown ([FromQuery]GetProductAttributeDropdown request) { 
 var result = await _productAttributeService.GetProductAttributeDropdown(request); 
 if(result.Success) 
 return Ok(result.Data); 
 else 
 return BadRequest(result.Message); 
 } 
 } 
 }
