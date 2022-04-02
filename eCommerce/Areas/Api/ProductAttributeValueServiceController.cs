 using System;
using System.Collections.Generic;
using System.Text;
using X.PagedList;
using Microsoft.AspNetCore.Mvc;
using Business.Services.ProductAggregate.ProductAttributeValues;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Business.Services.ProductAggregate.ProductAttributeValues.ProductAttributeValueServiceModel;
using Entities.Concrete.ProductAggregate; 
 namespace eCommerce.Areas.Api { 
 
 [Route("api/[controller]")] 
 [ApiController] 
 public class ProductAttributeValueServiceController : ControllerBase{ 
 private readonly IProductAttributeValueService _productAttributeValueService; 
 
 public ProductAttributeValueServiceController(IProductAttributeValueService productAttributeValueService){ 
 _productAttributeValueService=productAttributeValueService; 
 } 
 
 [Produces("application/json", "text/plain")] 
 [HttpPost("deleteproductattributevalue")] 
 [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))] 
 [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))] 
 public async Task<IActionResult> DeleteProductAttributeValue ([FromBody]DeleteProductAttributeValue request) { 
 
 var result = await _productAttributeValueService.DeleteProductAttributeValue(request); 
 
 if(result.Success) 
 return Ok(result.Success); 
 else 
 return BadRequest(result.Message); 
 
 } 
 
 [Produces("application/json", "text/plain")] 
 [HttpGet("getproductattributevalues")] 
 [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))] 
 public async Task<IActionResult> GetProductAttributeValues (GetProductAttributeValues request) { 
 
 var result = await _productAttributeValueService.GetProductAttributeValues(request); 
 
 if(result.Success) 
 return Ok(result.Success); 
 else 
 return BadRequest(result.Message); 
 } 
 
 [Produces("application/json", "text/plain")] 
 [HttpGet("getproductattributevaluebyid")] 
 [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))] 
 public async Task<IActionResult> GetProductAttributeValueById (GetProductAttributeValueById request) { 
 
 var result = await _productAttributeValueService.GetProductAttributeValueById(request); 
 
 if(result.Success) 
 return Ok(result.Success); 
 else 
 return BadRequest(result.Message); 
 } 
 
 [Produces("application/json", "text/plain")] 
 [HttpPost("insertproductattributevalue")] 
 [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))] 
 [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))] 
 public async Task<IActionResult> InsertProductAttributeValue ([FromBody]ProductAttributeValue productAttributeValue) { 
 
 var result = await _productAttributeValueService.InsertProductAttributeValue(productAttributeValue); 
 
 if(result.Success) 
 return Ok(result.Success); 
 else 
 return BadRequest(result.Message); 
 
 } 
 
 [Produces("application/json", "text/plain")] 
 [HttpPost("insertorupdateproductattributevalue")] 
 [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))] 
 [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))] 
 public async Task<IActionResult> InsertOrUpdateProductAttributeValue ([FromBody]ProductAttributeValue productAttributeValue) { 
 
 var result = await _productAttributeValueService.InsertOrUpdateProductAttributeValue(productAttributeValue); 
 
 if(result.Success) 
 return Ok(result.Success); 
 else 
 return BadRequest(result.Message); 
 
 } 
 
 [Produces("application/json", "text/plain")] 
 [HttpPost("updateproductattributevalue")] 
 [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))] 
 [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))] 
 public async Task<IActionResult> UpdateProductAttributeValue ([FromBody]ProductAttributeValue productAttributeValue) { 
 
 var result = await _productAttributeValueService.UpdateProductAttributeValue(productAttributeValue); 
 
 if(result.Success) 
 return Ok(result.Success); 
 else 
 return BadRequest(result.Message); 
 
 } 
 
 } 
 }
