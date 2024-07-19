using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.PagedList;
using Microsoft.AspNetCore.Mvc;
using Business.Services.BrandAggregate.CatalogBrands.Queries;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Core.Utilities.Identity;
using Entities.RequestModel.BrandAggregate.CatalogBrands;

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

        [AllowAnonymous]
        [Produces("application/json", "text/plain")]
        [HttpGet("getcatalogbrand")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(System.Collections.Generic.List<Entities.Concrete.CatalogBrand>))]
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
