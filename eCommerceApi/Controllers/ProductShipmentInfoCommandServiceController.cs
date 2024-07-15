using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.PagedList;
using Microsoft.AspNetCore.Mvc;
using Business.Services.ProductAggregate.ProductShipmentInfos.Commands;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Core.Utilities.Identity;
using Entities.RequestModel.ProductAggregate.ProductShipmentInfos;

namespace eCommerce.Areas.Api
{
    [AuthorizeControl]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductShipmentInfoCommandServiceController : ControllerBase
    {
        private readonly IProductShipmentInfoCommandService _productShipmentInfoCommandService;
        public ProductShipmentInfoCommandServiceController(IProductShipmentInfoCommandService productShipmentInfoCommandService)
        {
            _productShipmentInfoCommandService = productShipmentInfoCommandService;
        }

        [Produces("application/json", "text/plain")]
        [HttpPost("addproductshipmentinfo")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Core.Utilities.Results.Result<Entities.Concrete.ProductShipmentInfo>))]
        public async Task<IActionResult> AddProductShipmentInfo([FromBody] AddProductShipmentInfoReqModel productShipmentInfo)
        {
            var result = await _productShipmentInfoCommandService.AddProductShipmentInfo(productShipmentInfo);
            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result.Message);
        }

        [Produces("application/json", "text/plain")]
        [HttpPost("updateproductshipmentinfo")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Core.Utilities.Results.Result<Entities.Concrete.ProductShipmentInfo>))]
        public async Task<IActionResult> UpdateProductShipmentInfo([FromBody] UpdateProductShipmentInfoReqModel request)
        {
            var result = await _productShipmentInfoCommandService.UpdateProductShipmentInfo(request);
            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result.Message);
        }

        [Produces("application/json", "text/plain")]
        [HttpPost("addorupdateproductshipmentinfo")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Core.Utilities.Results.Result<Entities.Concrete.ProductShipmentInfo>))]
        public async Task<IActionResult> AddOrUpdateProductShipmentInfo([FromBody] AddOrUpdateProductShipmentInfoReqModel productShipmentInfo)
        {
            var result = await _productShipmentInfoCommandService.AddOrUpdateProductShipmentInfo(productShipmentInfo);
            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result.Message);
        }
    }
}
