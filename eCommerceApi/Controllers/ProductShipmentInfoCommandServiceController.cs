using Business.Services.ProductAggregate.ProductShipmentInfos.Commands;
using Core.Utilities.Identity;
using Entities.RequestModel.ProductAggregate.ProductShipmentInfos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

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
