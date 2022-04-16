 using System;
using System.Collections.Generic;
using System.Text;
using X.PagedList;
using Microsoft.AspNetCore.Mvc;
using Business.Services.PhotoAggregate.CombinationPhotos;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Core.Utilities.Identity;
using Business.Services.PhotoAggregate.CombinationPhotos.CombinationPhotoServiceModel; 
 namespace eCommerce.Areas.Api { 
 [AuthorizeControl] 
 [Route("api/[controller]")] 
 [ApiController] 
 public class CombinationPhotoServiceController : ControllerBase{ 
 private readonly ICombinationPhotoService _combinationPhotoService; 
 
 public CombinationPhotoServiceController(ICombinationPhotoService combinationPhotoService){ 
 _combinationPhotoService=combinationPhotoService; 
 } 
 
 
 [Produces("application/json", "text/plain")] 
 [HttpGet("getallcombinationphotos")] 
 [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))] 
 public async Task<IActionResult> GetAllCombinationPhotos ([FromQuery]GetAllCombinationPhotos request) { 
 
 var result = await _combinationPhotoService.GetAllCombinationPhotos(request); 
 
 if(result.Success) 
 return Ok(result.Data); 
 else 
 return BadRequest(result.Message); 
 } 
 
 
 [Produces("application/json", "text/plain")] 
 [HttpPost("insertcombinationphotos")] 
 [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))] 
 public async Task<IActionResult> InsertCombinationPhotos ([FromBody]InsertCombinationPhotos request) { 
 
 var result = await _combinationPhotoService.InsertCombinationPhotos(request); 
 
 if(result.Success) 
 return Ok(result.Success); 
 else 
 return BadRequest(result.Message); 
 
 } 
 
 } 
 }
