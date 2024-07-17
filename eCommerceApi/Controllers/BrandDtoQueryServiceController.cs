using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.PagedList;
using Microsoft.AspNetCore.Mvc;
using Business.Services.BrandAggregate.Brands.DtoQueries;
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
    public class BrandDtoQueryServiceController : ControllerBase
    {
        private readonly IBrandDtoQueryService _brandDtoQueryService;
        public BrandDtoQueryServiceController(IBrandDtoQueryService brandDtoQueryService)
        {
            _brandDtoQueryService = brandDtoQueryService;
        }

        [AllowAnonymous]
        [Produces("application/json", "text/plain")]
        [HttpPost("getbranddatatable")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Core.Utilities.Results.Result<Core.Utilities.PagedList.IPagedList<Entities.Concrete.Brand>>))]
        public async Task<IActionResult> GetBrandDataTable([FromBody] GetBrandDataTable request)
        {
            var result = await _brandDtoQueryService.GetBrandDataTable(request);
            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result.Message);
        }
    }
}
