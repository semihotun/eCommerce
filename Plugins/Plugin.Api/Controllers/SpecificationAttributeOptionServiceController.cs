 using System;
using System.Collections.Generic;
using System.Text;
using X.PagedList;
using Microsoft.AspNetCore.Mvc;
using Business.Services.SpeficationAggregate.SpecificationAttributeOptions;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Core.Utilities.Identity;
using Business.Services.SpeficationAggregate.SpecificationAttributeOptions.SpecificationAttributeOptionServiceModel;
using Entities.Concrete.SpeficationAggregate; 
 namespace eCommerce.Areas.Api { 
 [AuthorizeControl] 
 [Route("api/[controller]")] 
 [ApiController] 
 public class SpecificationAttributeOptionServiceController : ControllerBase{ 
 private readonly ISpecificationAttributeOptionService _specificationAttributeOptionService; 
 public SpecificationAttributeOptionServiceController(ISpecificationAttributeOptionService specificationAttributeOptionService){ 
 _specificationAttributeOptionService=specificationAttributeOptionService; 
 } 
 [Produces("application/json", "text/plain")] 
 [HttpGet("getspecificationattributeoptionbyid")] 
 [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))] 
 public async Task<IActionResult> GetSpecificationAttributeOptionById ([FromQuery]GetSpecificationAttributeOptionById request) { 
 var result = await _specificationAttributeOptionService.GetSpecificationAttributeOptionById(request); 
 if(result.Success) 
 return Ok(result.Data); 
 else 
 return BadRequest(result.Message); 
 } 
 [Produces("application/json", "text/plain")] 
 [HttpGet("getspecificationattributeoptionsbyids")] 
 [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))] 
 public async Task<IActionResult> GetSpecificationAttributeOptionsByIds ([FromQuery]GetSpecificationAttributeOptionsByIds request) { 
 var result = await _specificationAttributeOptionService.GetSpecificationAttributeOptionsByIds(request); 
 if(result.Success) 
 return Ok(result.Data); 
 else 
 return BadRequest(result.Message); 
 } 
 [Produces("application/json", "text/plain")] 
 [HttpGet("getspecificationattributeoptionsbyspecificationattribute")] 
 [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))] 
 public async Task<IActionResult> GetSpecificationAttributeOptionsBySpecificationAttribute ([FromQuery]GetSpecificationAttributeOptionsBySpecificationAttribute request) { 
 var result = await _specificationAttributeOptionService.GetSpecificationAttributeOptionsBySpecificationAttribute(request); 
 if(result.Success) 
 return Ok(result.Data); 
 else 
 return BadRequest(result.Message); 
 } 
 [Produces("application/json", "text/plain")] 
 [HttpPost("deletespecificationattributeoption")] 
 [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))] 
 public async Task<IActionResult> DeleteSpecificationAttributeOption ([FromBody]SpecificationAttributeOption specificationAttributeOption) { 
 var result = await _specificationAttributeOptionService.DeleteSpecificationAttributeOption(specificationAttributeOption); 
 if(result.Success) 
 return Ok(result.Success); 
 else 
 return BadRequest(result.Message); 
 } 
 [Produces("application/json", "text/plain")] 
 [HttpPost("insertspecificationattributeoption")] 
 [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))] 
 public async Task<IActionResult> InsertSpecificationAttributeOption ([FromBody]SpecificationAttributeOption specificationAttributeOption) { 
 var result = await _specificationAttributeOptionService.InsertSpecificationAttributeOption(specificationAttributeOption); 
 if(result.Success) 
 return Ok(result.Success); 
 else 
 return BadRequest(result.Message); 
 } 
 [Produces("application/json", "text/plain")] 
 [HttpPost("updatespecificationattributeoption")] 
 [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))] 
 public async Task<IActionResult> UpdateSpecificationAttributeOption ([FromBody]SpecificationAttributeOption specificationAttributeOption) { 
 var result = await _specificationAttributeOptionService.UpdateSpecificationAttributeOption(specificationAttributeOption); 
 if(result.Success) 
 return Ok(result.Success); 
 else 
 return BadRequest(result.Message); 
 } 
 [Produces("application/json", "text/plain")] 
 [HttpGet("getnotexistingspecificationattributeoptions")] 
 [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))] 
 public async Task<IActionResult> GetNotExistingSpecificationAttributeOptions ([FromQuery]GetNotExistingSpecificationAttributeOptions request) { 
 var result = await _specificationAttributeOptionService.GetNotExistingSpecificationAttributeOptions(request); 
 if(result.Success) 
 return Ok(result.Data); 
 else 
 return BadRequest(result.Message); 
 } 
 } 
 }
