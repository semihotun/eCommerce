 using System;
using System.Collections.Generic;
using System.Text;
using X.PagedList;
using Microsoft.AspNetCore.Mvc;
using DataAccess.DALs.EntitiyFramework.ShowcaseAggregate.ShowcaseServices;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using DataAccess.DALs.EntitiyFramework.ShowcaseAggregate.ShowcaseServices.ShowcaseDALModels; 
 namespace eCommerce.Areas.Api { 
 
 [Route("api/[controller]")] 
 [ApiController] 
 public class ShowcaseDALController : ControllerBase{ 
 private readonly IShowcaseDAL _showcaseDAL; 
 
 public ShowcaseDALController(IShowcaseDAL showcaseDAL){ 
 _showcaseDAL=showcaseDAL; 
 } 
 
 [Produces("application/json", "text/plain")] 
 [HttpGet("getshowcasedto")] 
 [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))] 
 public async Task<IActionResult> GetShowCaseDto (GetShowCaseDto request) { 
 
 var result = await _showcaseDAL.GetShowCaseDto(request); 
 
 if(result.Success) 
 return Ok(result.Success); 
 else 
 return BadRequest(result.Message); 
 } 
 
 [Produces("application/json", "text/plain")] 
 [HttpGet("getallshowcasedto")] 
 [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))] 
 public async Task<IActionResult> GetAllShowCaseDto () { 
 
 var result = await _showcaseDAL.GetAllShowCaseDto(); 
 
 if(result.Success) 
 return Ok(result.Success); 
 else 
 return BadRequest(result.Message); 
 } 
 
 } 
 }
