 using System;
using System.Collections.Generic;
using System.Text;
using X.PagedList;
using Microsoft.AspNetCore.Mvc;
using Business.Services.SpeficationAggregate.SpecificationAttributes;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Business.Services.SpeficationAggregate.SpecificationAttributes.SpecificationAttributeServiceModel;
using Entities.Concrete.SpeficationAggregate; 
 namespace eCommerce.Areas.Api { 
 
 [Route("api/[controller]")] 
 [ApiController] 
 public class SpecificationAttributeServiceController : ControllerBase{ 
 private readonly ISpecificationAttributeService _specificationAttributeService; 
 
 public SpecificationAttributeServiceController(ISpecificationAttributeService specificationAttributeService){ 
 _specificationAttributeService=specificationAttributeService; 
 } 
 
 [Produces("application/json", "text/plain")] 
 [HttpGet("getspecificationattributebyid")] 
 [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))] 
 public async Task<IActionResult> GetSpecificationAttributeById (GetSpecificationAttributeById request) { 
 
 var result = await _specificationAttributeService.GetSpecificationAttributeById(request); 
 
 if(result.Success) 
 return Ok(result.Success); 
 else 
 return BadRequest(result.Message); 
 } 
 
 [Produces("application/json", "text/plain")] 
 [HttpGet("getspecificationattributebyids")] 
 [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))] 
 public async Task<IActionResult> GetSpecificationAttributeByIds (GetSpecificationAttributeByIds request) { 
 
 var result = await _specificationAttributeService.GetSpecificationAttributeByIds(request); 
 
 if(result.Success) 
 return Ok(result.Success); 
 else 
 return BadRequest(result.Message); 
 } 
 
 [Produces("application/json", "text/plain")] 
 [HttpGet("getspecificationattributes")] 
 [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))] 
 public async Task<IActionResult> GetSpecificationAttributes (GetSpecificationAttributes request) { 
 
 var result = await _specificationAttributeService.GetSpecificationAttributes(request); 
 
 if(result.Success) 
 return Ok(result.Success); 
 else 
 return BadRequest(result.Message); 
 } 
 
 [Produces("application/json", "text/plain")] 
 [HttpGet("getspecificationattributeswithoptions")] 
 [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))] 
 public async Task<IActionResult> GetSpecificationAttributesWithOptions () { 
 
 var result = await _specificationAttributeService.GetSpecificationAttributesWithOptions(); 
 
 if(result.Success) 
 return Ok(result.Success); 
 else 
 return BadRequest(result.Message); 
 } 
 
 [Produces("application/json", "text/plain")] 
 [HttpPost("deletespecificationattribute")] 
 [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))] 
 [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))] 
 public async Task<IActionResult> DeleteSpecificationAttribute ([FromBody]SpecificationAttribute specificationAttribute) { 
 
 var result = await _specificationAttributeService.DeleteSpecificationAttribute(specificationAttribute); 
 
 if(result.Success) 
 return Ok(result.Success); 
 else 
 return BadRequest(result.Message); 
 
 } 
 
 [Produces("application/json", "text/plain")] 
 [HttpPost("insertspecificationattribute")] 
 [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))] 
 [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))] 
 public async Task<IActionResult> InsertSpecificationAttribute ([FromBody]SpecificationAttribute specificationAttribute) { 
 
 var result = await _specificationAttributeService.InsertSpecificationAttribute(specificationAttribute); 
 
 if(result.Success) 
 return Ok(result.Success); 
 else 
 return BadRequest(result.Message); 
 
 } 
 
 [Produces("application/json", "text/plain")] 
 [HttpPost("updatespecificationattribute")] 
 [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))] 
 [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))] 
 public async Task<IActionResult> UpdateSpecificationAttribute ([FromBody]SpecificationAttribute specificationAttribute) { 
 
 var result = await _specificationAttributeService.UpdateSpecificationAttribute(specificationAttribute); 
 
 if(result.Success) 
 return Ok(result.Success); 
 else 
 return BadRequest(result.Message); 
 
 } 
 
 [Produces("application/json", "text/plain")] 
 [HttpGet("getcatalogspefication")] 
 [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))] 
 public async Task<IActionResult> GetCatalogSpefication (GetCatalogSpefication request) { 
 
 var result = await _specificationAttributeService.GetCatalogSpefication(request); 
 
 if(result.Success) 
 return Ok(result.Success); 
 else 
 return BadRequest(result.Message); 
 } 
 
 [Produces("application/json", "text/plain")] 
 [HttpGet("getproductspeficationattributedropdwon")] 
 [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))] 
 public async Task<IActionResult> GetProductSpeficationAttributeDropdwon (GetProductSpeficationAttributeDropdwon request) { 
 
 var result = await _specificationAttributeService.GetProductSpeficationAttributeDropdwon(request); 
 
 if(result.Success) 
 return Ok(result.Success); 
 else 
 return BadRequest(result.Message); 
 } 
 
 } 
 }
