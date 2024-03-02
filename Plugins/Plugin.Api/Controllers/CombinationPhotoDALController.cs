 using System;
using System.Collections.Generic;
using System.Text;
using X.PagedList;
using Microsoft.AspNetCore.Mvc;
using DataAccess.DALs.EntitiyFramework.PhotoAggregate.CombinationPhotos;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Core.Utilities.Identity;
using DataAccess.DALs.EntitiyFramework.PhotoAggregate.CombinationPhotos.CombinationPhotoDALModels; 
 namespace eCommerce.Areas.Api { 
 [AuthorizeControl] 
 [Route("api/[controller]")] 
 [ApiController] 
 public class CombinationPhotoDALController : ControllerBase{ 
 private readonly ICombinationPhotoDAL _combinationPhotoDAL; 
 public CombinationPhotoDALController(ICombinationPhotoDAL combinationPhotoDAL){ 
 _combinationPhotoDAL=combinationPhotoDAL; 
 } 
 [Produces("application/json", "text/plain")] 
 [HttpGet("getallcombinationphotosdto")] 
 [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))] 
 public async Task<IActionResult> GetAllCombinationPhotosDTO ([FromQuery]GetAllCombinationPhotosDTO request) { 
 var result = await _combinationPhotoDAL.GetAllCombinationPhotosDTO(request); 
 if(result.Success) 
 return Ok(result.Data); 
 else 
 return BadRequest(result.Message); 
 } 
 } 
 }
