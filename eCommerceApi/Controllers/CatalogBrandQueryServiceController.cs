using Business.Services.BrandAggregate.CatalogBrands.Queries;
using Core.Utilities.Identity;
using Entities.RequestModel.BrandAggregate.CatalogBrands;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace eCommerce.Areas.Api
{
    [AuthorizeControl]
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogBrandQueryServiceController : ControllerBase
    {
        private readonly ICatalogBrandQueryService _catalogBrandQueryService;
        public CatalogBrandQueryServiceController(ICatalogBrandQueryService catalogBrandQueryService)
        {
            _catalogBrandQueryService = catalogBrandQueryService;
        }

        [Produces("application/json", "text/plain")]
        [HttpGet("getcatalogbrand")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetCatalogBrand([FromQuery] GetCatalogBrandReqModel request)
        {
            var result = await _catalogBrandQueryService.GetCatalogBrand(request);
            if (result.Success)
                return Ok(result.Data);
            else
                return BadRequest(result.Message);
        }
    }
}
