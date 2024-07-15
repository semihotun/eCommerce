using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.PagedList;
using Microsoft.AspNetCore.Mvc;
using Business.Services.ProductAggregate.ProductStocks.DtoQueries;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Core.Utilities.Identity;
using Entities.RequestModel.ProductAggregate.ProductStocks;

namespace eCommerce.Areas.Api
{
    [AuthorizeControl]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductStockDtoQueryServiceController : ControllerBase
    {
        private readonly IProductStockDtoQueryService _productStockDtoQueryService;
        public ProductStockDtoQueryServiceController(IProductStockDtoQueryService productStockDtoQueryService)
        {
            _productStockDtoQueryService = productStockDtoQueryService;
        }

        [Produces("application/json", "text/plain")]
        [HttpGet("getallproductstockdto")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Core.Utilities.Results.Result<Core.Utilities.PagedList.IPagedList<Entities.Dtos.ProductStockDALModels.ProductStockDto>>))]
        public async Task<IActionResult> GetAllProductStockDto([FromQuery] GetAllProductStockReqModel request)
        {
            var result = await _productStockDtoQueryService.GetAllProductStockDto(request);
            if (result.Success)
                return Ok(result.Data);
            else
                return BadRequest(result.Message);
        }
    }
}
