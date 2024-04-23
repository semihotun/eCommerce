using Business.Services.ProductAggregate.ProductShipmentInfos.Queries;
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
    public class ProductShipmentInfoQueryServiceController : ControllerBase
    {
        private readonly IProductShipmentInfoQueryService _productShipmentInfoQueryService;
        public ProductShipmentInfoQueryServiceController(IProductShipmentInfoQueryService productShipmentInfoQueryService)
        {
            _productShipmentInfoQueryService = productShipmentInfoQueryService;
        }

        [Produces("application/json", "text/plain")]
        [HttpGet("getproductshipmentinfo")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetProductShipmentInfo([FromQuery] GetProductShipmentInfoReqModel request)
        {
            var result = await _productShipmentInfoQueryService.GetProductShipmentInfo(request);
            if (result.Success)
                return Ok(result.Data);
            else
                return BadRequest(result.Message);
        }
    }
}
