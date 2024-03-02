 using System;
using System.Collections.Generic;
using System.Text;
using X.PagedList;
using Microsoft.AspNetCore.Mvc;
using Business.Services.UserIdentityAggregate.Manages;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Core.Utilities.Identity;
using Business.Services.UserIdentityAggregate.Manages.ManageServiceModels; 
 namespace eCommerce.Areas.Api { 
 [AuthorizeControl] 
 [Route("api/[controller]")] 
 [ApiController] 
 public class ManageServiceController : ControllerBase{ 
 private readonly IManageService _manageService; 
 public ManageServiceController(IManageService manageService){ 
 _manageService=manageService; 
 } 
 [Produces("application/json", "text/plain")] 
 [HttpPost("sendverificationemail")] 
 [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))] 
 public async Task<IActionResult> SendVerificationEmail ([FromBody]SendVerificationEmail request) { 
 var result = await _manageService.SendVerificationEmail(request); 
 if(result.Success) 
 return Ok(result.Success); 
 else 
 return BadRequest(result.Message); 
 } 
 [Produces("application/json", "text/plain")] 
 [HttpPost("changepassword")] 
 [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))] 
 public async Task<IActionResult> ChangePassword ([FromBody]ChangePassword request) { 
 var result = await _manageService.ChangePassword(request); 
 if(result.Success) 
 return Ok(result.Success); 
 else 
 return BadRequest(result.Message); 
 } 
 [Produces("application/json", "text/plain")] 
 [HttpPost("setpassword")] 
 [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))] 
 public async Task<IActionResult> SetPassword ([FromBody]SetPassword request) { 
 var result = await _manageService.SetPassword(request); 
 if(result.Success) 
 return Ok(result.Success); 
 else 
 return BadRequest(result.Message); 
 } 
 [Produces("application/json", "text/plain")] 
 [HttpPost("generaterecoverycodes")] 
 [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))] 
 public async Task<IActionResult> GenerateRecoveryCodes ([FromBody]GenerateRecoveryCodes request) { 
 var result = await _manageService.GenerateRecoveryCodes(request); 
 if(result.Success) 
 return Ok(result.Data); 
 else 
 return BadRequest(result.Message); 
 } 
 [Produces("application/json", "text/plain")] 
 [HttpPost("enableauthenticator")] 
 [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))] 
 public async Task<IActionResult> EnableAuthenticator ([FromBody]EnableAuthenticator request) { 
 var result = await _manageService.EnableAuthenticator(request); 
 if(result.Success) 
 return Ok(result.Data); 
 else 
 return BadRequest(result.Message); 
 } 
 [Produces("application/json", "text/plain")] 
 [HttpPost("resetauthenticator")] 
 [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))] 
 public async Task<IActionResult> ResetAuthenticator ([FromBody]ResetAuthenticator request) { 
 var result = await _manageService.ResetAuthenticator(request); 
 if(result.Success) 
 return Ok(result.Success); 
 else 
 return BadRequest(result.Message); 
 } 
 [Produces("application/json", "text/plain")] 
 [HttpPost("loadsharedkeyandqrcodeuriasync")] 
 [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))] 
 public async Task<IActionResult> LoadSharedKeyAndQrCodeUriAsync ([FromBody]LoadSharedKeyAndQrCodeUriAsync request) { 
 var result = await _manageService.LoadSharedKeyAndQrCodeUriAsync(request); 
 if(result.Success) 
 return Ok(result.Success); 
 else 
 return BadRequest(result.Message); 
 } 
 } 
 }
