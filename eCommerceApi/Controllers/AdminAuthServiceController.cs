using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.PagedList;
using Microsoft.AspNetCore.Mvc;
using Business.Services.AuthAggregate.AdminAuths;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Core.Utilities.Identity;
using Entities.RequestModel.AdminAggregate.AdminAuths;

namespace eCommerce.Areas.Api
{
    [AuthorizeControl]
    [Route("api/[controller]")]
    [ApiController]
    public class AdminAuthServiceController : ControllerBase
    {
        private readonly IAdminAuthService _adminAuthService;
        public AdminAuthServiceController(IAdminAuthService adminAuthService)
        {
            _adminAuthService = adminAuthService;
        }

        [AllowAnonymous]
        [Produces("application/json", "text/plain")]
        [HttpPost("register")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> Register([FromBody] RegisterReqModel userForRegisterDto)
        {
            var result = await _adminAuthService.Register(userForRegisterDto);
            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result.Message);
        }

        [AllowAnonymous]
        [Produces("application/json", "text/plain")]
        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> Login([FromBody] LoginReqModel userForLoginDto)
        {
            var result = await _adminAuthService.Login(userForLoginDto);
            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result.Message);
        }

        [Produces("application/json", "text/plain")]
        [HttpPost("addadminuser")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> AddAdminUser([FromBody] AddReqModel user)
        {
            var result = await _adminAuthService.AddAdminUser(user);
            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result.Message);
        }

        [Produces("application/json", "text/plain")]
        [HttpGet("getbymail")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetByMail([FromQuery] GetByMailReqModel request)
        {
            var result = await _adminAuthService.GetByMail(request);
            if (result.Success)
                return Ok(result.Data);
            else
                return BadRequest(result.Message);
        }

        [Produces("application/json", "text/plain")]
        [HttpGet("getadmincount")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetAdminCount()
        {
            var result = await _adminAuthService.GetAdminCount();
            if (result.Success)
                return Ok(result.Data);
            else
                return BadRequest(result.Message);
        }
    }
}
