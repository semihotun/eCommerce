using Business.Services.BrandAggregate.Brands.DtoQueries;
using Core.Utilities.Identity;
using Entities.RequestModel.BrandAggregate.Brands;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

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

        [Produces("application/json", "text/plain")]
        [HttpPost("getbranddatatable")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
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
