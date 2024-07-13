using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.PagedList;
using Microsoft.AspNetCore.Mvc;
using Business.Services.AuthAggregate.Customers;
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
    public class CustomerAuthServiceController : ControllerBase
    {
        private readonly ICustomerAuthService _customerAuthService;
        public CustomerAuthServiceController(ICustomerAuthService customerAuthService)
        {
            _customerAuthService = customerAuthService;
        }

        [AllowAnonymous]
        [Produces("application/json", "text/plain")]
        [HttpPost("register")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> Register([FromBody] RegisterReqModel userForRegisterDto)
        {
            var result = await _customerAuthService.Register(userForRegisterDto);
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
            var result = await _customerAuthService.Login(userForLoginDto);
            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result.Message);
        }
    }
}
