 using System;
using System.Collections.Generic;
using System.Text;
using X.PagedList;
using Microsoft.AspNetCore.Mvc;
using Business.Services.ShowcaseAggregate.ShowcaseServices;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Core.Utilities.Identity;
using Entities.Concrete.ShowcaseAggregate;
using Business.Services.ShowcaseAggregate.ShowcaseServices.ShowcaseServiceModel; 
 namespace eCommerce.Areas.Api { 
 [AuthorizeControl] 
 [Route("api/[controller]")] 
 [ApiController] 
 public class ShowcaseServiceController : ControllerBase{ 
 private readonly IShowcaseService _showcaseService; 
 
 public ShowcaseServiceController(IShowcaseService showcaseService){ 
 _showcaseService=showcaseService; 
 } 
 
 
 [Produces("application/json", "text/plain")] 
 [HttpGet("getallshowcase")] 
 [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))] 
 public async Task<IActionResult> GetAllShowcase () { 
 
 var result = await _showcaseService.GetAllShowcase(); 
 
 if(result.Success) 
 return Ok(result.Data); 
 else 
 return BadRequest(result.Message); 
 } 
 
 
 [Produces("application/json", "text/plain")] 
 [HttpPost("insertshowcase")] 
 [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))] 
 public async Task<IActionResult> InsertShowcase ([FromBody]ShowCase showCase) { 
 
 var result = await _showcaseService.InsertShowcase(showCase); 
 
 if(result.Success) 
 return Ok(result.Success); 
 else 
 return BadRequest(result.Message); 
 
 } 
 
 
 [Produces("application/json", "text/plain")] 
 [HttpPost("deleteshowcase")] 
 [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))] 
 public async Task<IActionResult> DeleteShowCase ([FromBody]DeleteShowCase showCase) { 
 
 var result = await _showcaseService.DeleteShowCase(showCase); 
 
 if(result.Success) 
 return Ok(result.Success); 
 else 
 return BadRequest(result.Message); 
 
 } 
 
 
 [Produces("application/json", "text/plain")] 
 [HttpGet("getshowcase")] 
 [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))] 
 public async Task<IActionResult> GetShowcase ([FromQuery]GetShowcase request) { 
 
 var result = await _showcaseService.GetShowcase(request); 
 
 if(result.Success) 
 return Ok(result.Data); 
 else 
 return BadRequest(result.Message); 
 } 
 
 
 [Produces("application/json", "text/plain")] 
 [HttpPost("updateshowcase")] 
 [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))] 
 public async Task<IActionResult> UpdateShowcase ([FromBody]ShowCase showCase) { 
 
 var result = await _showcaseService.UpdateShowcase(showCase); 
 
 if(result.Success) 
 return Ok(result.Success); 
 else 
 return BadRequest(result.Message); 
 
 } 
 
 } 
 }
