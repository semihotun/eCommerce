 using System;
using System.Collections.Generic;
using System.Text;
using X.PagedList;
using Microsoft.AspNetCore.Mvc;
using Core.Library.Business.AdminAggregate.AdminAuths;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Core.Utilities.Identity;
using Core.Library.Entities.Concrete; 
 namespace eCommerce.Areas.Api { 
 [AuthorizeControl] 
 [Route("api/[controller]")] 
 [ApiController] 
 public class AdminAuthServiceController : ControllerBase{ 
 private readonly IAdminAuthService _adminAuthService; 
 public AdminAuthServiceController(IAdminAuthService adminAuthService){ 
 _adminAuthService=adminAuthService; 
 } 
 [AllowAnonymous] 
 [Produces("application/json", "text/plain")] 
 [HttpPost("register")] 
 [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))] 
 public async Task<IActionResult> Register ([FromBody]UserForRegisterDto userForRegisterDto) { 
 var result = await _adminAuthService.Register(userForRegisterDto); 
 if(result.Success) 
 return Ok(result.Data); 
 else 
 return BadRequest(result.Message); 
 } 
 [AllowAnonymous] 
 [Produces("application/json", "text/plain")] 
 [HttpPost("login")] 
 [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))] 
 public async Task<IActionResult> Login ([FromBody]UserForLoginDto userForLoginDto) { 
 var result = await _adminAuthService.Login(userForLoginDto); 
 if(result.Success) 
 return Ok(result.Data); 
 else 
 return BadRequest(result.Message); 
 } 
 } 
 }
