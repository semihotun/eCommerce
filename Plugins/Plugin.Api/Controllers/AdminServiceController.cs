 using System;
using System.Collections.Generic;
using System.Text;
using X.PagedList;
using Microsoft.AspNetCore.Mvc;
using Core.Library.Business.AdminAggregate.AdminServices;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Core.Utilities.Identity;
using Core.Library.Entities.Concrete; 
 namespace eCommerce.Areas.Api { 
 [AuthorizeControl] 
 [Route("api/[controller]")] 
 [ApiController] 
 public class AdminServiceController : ControllerBase{ 
 private readonly IAdminService _adminService; 
 
 public AdminServiceController(IAdminService adminService){ 
 _adminService=adminService; 
 } 
 
 
 [Produces("application/json", "text/plain")] 
 [HttpGet("getclaims")] 
 [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))] 
 public async Task<IActionResult> GetClaims ([FromQuery]AdminUser user) { 
 
 var result = await _adminService.GetClaims(user); 
 
 if(result.Success) 
 return Ok(result.Data); 
 else 
 return BadRequest(result.Message); 
 } 
 
 
 [Produces("application/json", "text/plain")] 
 [HttpPost("add")] 
 [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))] 
 public async Task<IActionResult> Add ([FromBody]AdminUser user) { 
 
 var result = await _adminService.Add(user); 
 
 if(result.Success) 
 return Ok(result.Success); 
 else 
 return BadRequest(result.Message); 
 
 } 
 
 
 [Produces("application/json", "text/plain")] 
 [HttpGet("getbymail")] 
 [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))] 
 public async Task<IActionResult> GetByMail ([FromQuery]String email) { 
 
 var result = await _adminService.GetByMail(email); 
 
 if(result.Success) 
 return Ok(result.Data); 
 else 
 return BadRequest(result.Message); 
 } 
 
 
 [Produces("application/json", "text/plain")] 
 [HttpGet("getadmincount")] 
 [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))] 
 public async Task<IActionResult> GetAdminCount () { 
 
 var result = await _adminService.GetAdminCount(); 
 
 if(result.Success) 
 return Ok(result.Data); 
 else 
 return BadRequest(result.Message); 
 } 
 
 } 
 }
