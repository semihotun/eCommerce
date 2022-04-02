 using System;
using System.Collections.Generic;
using System.Text;
using X.PagedList;
using Microsoft.AspNetCore.Mvc;
using Business.Services.ProductAggregate.ProductSpecificationAttributes;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Business.Services.ProductAggregate.ProductSpecificationAttributes.ProductSpecificationAttributeServiceModel;
using Entities.Concrete.ProductAggregate; 
 namespace eCommerce.Areas.Api { 
 
 [Route("api/[controller]")] 
 [ApiController] 
 public class ProductSpecificationAttributeServiceController : ControllerBase{ 
 private readonly IProductSpecificationAttributeService _productSpecificationAttributeService; 
 
 public ProductSpecificationAttributeServiceController(IProductSpecificationAttributeService productSpecificationAttributeService){ 
 _productSpecificationAttributeService=productSpecificationAttributeService; 
 } 
 
 [Produces("application/json", "text/plain")] 
 [HttpPost("deleteproductspecificationattribute")] 
 [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))] 
 [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))] 
 public async Task<IActionResult> DeleteProductSpecificationAttribute ([FromBody]DeleteProductSpecificationAttribute request) { 
 
 var result = await _productSpecificationAttributeService.DeleteProductSpecificationAttribute(request); 
 
 if(result.Success) 
 return Ok(result.Success); 
 else 
 return BadRequest(result.Message); 
 
 } 
 
 [Produces("application/json", "text/plain")] 
 [HttpGet("getproductspecificationattributes")] 
 [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))] 
 public async Task<IActionResult> GetProductSpecificationAttributes (GetProductSpecificationAttributes request) { 
 
 var result = await _productSpecificationAttributeService.GetProductSpecificationAttributes(request); 
 
 if(result.Success) 
 return Ok(result.Success); 
 else 
 return BadRequest(result.Message); 
 } 
 
 [Produces("application/json", "text/plain")] 
 [HttpGet("getproductspecificationattributebyid")] 
 [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))] 
 public async Task<IActionResult> GetProductSpecificationAttributeById (GetProductSpecificationAttributeById request) { 
 
 var result = await _productSpecificationAttributeService.GetProductSpecificationAttributeById(request); 
 
 if(result.Success) 
 return Ok(result.Success); 
 else 
 return BadRequest(result.Message); 
 } 
 
 [Produces("application/json", "text/plain")] 
 [HttpPost("insertproductspecificationattribute")] 
 [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))] 
 [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))] 
 public async Task<IActionResult> InsertProductSpecificationAttribute ([FromBody]ProductSpecificationAttribute productSpecificationAttribute) { 
 
 var result = await _productSpecificationAttributeService.InsertProductSpecificationAttribute(productSpecificationAttribute); 
 
 if(result.Success) 
 return Ok(result.Success); 
 else 
 return BadRequest(result.Message); 
 
 } 
 
 [Produces("application/json", "text/plain")] 
 [HttpPost("updateproductspecificationattribute")] 
 [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))] 
 [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))] 
 public async Task<IActionResult> UpdateProductSpecificationAttribute ([FromBody]ProductSpecificationAttribute productSpecificationAttribute) { 
 
 var result = await _productSpecificationAttributeService.UpdateProductSpecificationAttribute(productSpecificationAttribute); 
 
 if(result.Success) 
 return Ok(result.Success); 
 else 
 return BadRequest(result.Message); 
 
 } 
 
 [Produces("application/json", "text/plain")] 
 [HttpGet("getproductspecificationattributecount")] 
 [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))] 
 public async Task<IActionResult> GetProductSpecificationAttributeCount (GetProductSpecificationAttributeCount request) { 
 
 var result = await _productSpecificationAttributeService.GetProductSpecificationAttributeCount(request); 
 
 if(result.Success) 
 return Ok(result.Success); 
 else 
 return BadRequest(result.Message); 
 } 
 
 } 
 }
