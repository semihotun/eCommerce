using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.PagedList;
using Microsoft.AspNetCore.Mvc;
using Business.Services.ProductAggregate.ProductStockTypes.Queries;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Core.Utilities.Identity;
using Entities.RequestModel.ProductAggregate.ProductStockTypes;

namespace eCommerce.Areas.Api
{
    [AuthorizeControl]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductStockTypeQueryServiceController : ControllerBase
    {
        private readonly IProductStockTypeQueryService _productStockTypeQueryService;
        public ProductStockTypeQueryServiceController(IProductStockTypeQueryService productStockTypeQueryService)
        {
            _productStockTypeQueryService = productStockTypeQueryService;
        }

        [AllowAnonymous]
        [Produces("application/json", "text/plain")]
        [HttpGet("getallproductstocktype")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Core.Utilities.Results.Result<System.Collections.Generic.IEnumerable<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem>>))]
        public async Task<IActionResult> GetAllProductStockType([FromQuery] GetAllProductStockTypeReqModel request)
        {
            var result = await _productStockTypeQueryService.GetAllProductStockType(request);
            if (result.Success)
                return Ok(result.Data);
            else
                return BadRequest(result.Message);
        }
    }
}
