using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.PagedList;
using Microsoft.AspNetCore.Mvc;
using Business.Services.BrandAggregate.Brands.Commands;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Core.Utilities.Identity;
using Entities.RequestModel.BrandAggregate.Brands;

namespace eCommerce.Areas.Api
{
    [AuthorizeControl]
    [Route("api/[controller]")]
    [ApiController]
    public class BrandCommandServiceController : ControllerBase
    {
        private readonly IBrandCommandService _brandCommandService;
        public BrandCommandServiceController(IBrandCommandService brandCommandService)
        {
            _brandCommandService = brandCommandService;
        }

        [Produces("application/json", "text/plain")]
        [HttpPost("addbrand")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Core.Utilities.Results.Result<Entities.Concrete.Brand>))]
        public async Task<IActionResult> AddBrand([FromBody] AddBrandReqModel request)
        {
            var result = await _brandCommandService.AddBrand(request);
            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result.Message);
        }

        [Produces("application/json", "text/plain")]
        [HttpPost("deletebrand")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Core.Utilities.Results.Result))]
        public async Task<IActionResult> DeleteBrand([FromBody] DeleteBrandReqModel request)
        {
            var result = await _brandCommandService.DeleteBrand(request);
            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result.Message);
        }

        [Produces("application/json", "text/plain")]
        [HttpPost("updatebrand")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Core.Utilities.Results.Result))]
        public async Task<IActionResult> UpdateBrand([FromBody] UpdateBrandReqModel request)
        {
            var result = await _brandCommandService.UpdateBrand(request);
            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result.Message);
        }
    }
}
