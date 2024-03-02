 using System;
using System.Collections.Generic;
using System.Text;
using X.PagedList;
using Microsoft.AspNetCore.Mvc;
using Business.Services.ProductAggregate.PredefinedProductAttributeValues;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Core.Utilities.Identity;
using Entities.Concrete.ProductAggregate;
using Business.Services.ProductAggregate.PredefinedProductAttributeValues.PredefinedProductAttributeValueServiceModel; 
 namespace eCommerce.Areas.Api { 
 [AuthorizeControl] 
 [Route("api/[controller]")] 
 [ApiController] 
 public class PredefinedProductAttributeValueServiceController : ControllerBase{ 
 private readonly IPredefinedProductAttributeValueService _predefinedProductAttributeValueService; 
 public PredefinedProductAttributeValueServiceController(IPredefinedProductAttributeValueService predefinedProductAttributeValueService){ 
 _predefinedProductAttributeValueService=predefinedProductAttributeValueService; 
 } 
 [Produces("application/json", "text/plain")] 
 [HttpPost("deletepredefinedproductattributevalue")] 
 [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))] 
 public async Task<IActionResult> DeletePredefinedProductAttributeValue ([FromBody]PredefinedProductAttributeValue ppav) { 
 var result = await _predefinedProductAttributeValueService.DeletePredefinedProductAttributeValue(ppav); 
 if(result.Success) 
 return Ok(result.Success); 
 else 
 return BadRequest(result.Message); 
 } 
 [Produces("application/json", "text/plain")] 
 [HttpGet("getpredefinedproductattributevalues")] 
 [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))] 
 public async Task<IActionResult> GetPredefinedProductAttributeValues ([FromQuery]GetPredefinedProductAttributeValues request) { 
 var result = await _predefinedProductAttributeValueService.GetPredefinedProductAttributeValues(request); 
 if(result.Success) 
 return Ok(result.Data); 
 else 
 return BadRequest(result.Message); 
 } 
 [Produces("application/json", "text/plain")] 
 [HttpGet("getpredefinedproductattributevaluebyid")] 
 [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))] 
 public async Task<IActionResult> GetPredefinedProductAttributeValueById ([FromQuery]GetPredefinedProductAttributeValueById request) { 
 var result = await _predefinedProductAttributeValueService.GetPredefinedProductAttributeValueById(request); 
 if(result.Success) 
 return Ok(result.Data); 
 else 
 return BadRequest(result.Message); 
 } 
 [Produces("application/json", "text/plain")] 
 [HttpPost("insertpredefinedproductattributevalue")] 
 [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))] 
 public async Task<IActionResult> InsertPredefinedProductAttributeValue ([FromBody]PredefinedProductAttributeValue ppav) { 
 var result = await _predefinedProductAttributeValueService.InsertPredefinedProductAttributeValue(ppav); 
 if(result.Success) 
 return Ok(result.Success); 
 else 
 return BadRequest(result.Message); 
 } 
 [Produces("application/json", "text/plain")] 
 [HttpPost("updatepredefinedproductattributevalue")] 
 [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))] 
 public async Task<IActionResult> UpdatePredefinedProductAttributeValue ([FromBody]PredefinedProductAttributeValue ppav) { 
 var result = await _predefinedProductAttributeValueService.UpdatePredefinedProductAttributeValue(ppav); 
 if(result.Success) 
 return Ok(result.Success); 
 else 
 return BadRequest(result.Message); 
 } 
 } 
 }
