using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.PagedList;
using Microsoft.AspNetCore.Mvc;
using Business.Services.BasketAggregate.Baskets;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Core.Utilities.Identity;
using Entities.RequestModel.BasketAggregate.Baskets;

namespace eCommerce.Areas.Api
{
    [AuthorizeControl]
    [Route("api/[controller]")]
    [ApiController]
    public class BasketServiceController : ControllerBase
    {
        private readonly IBasketService _basketService;
        public BasketServiceController(IBasketService basketService)
        {
            _basketService = basketService;
        }

        [Produces("application/json", "text/plain")]
        [HttpPost("addbasket")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> AddBasket([FromBody] AddBasketReqModel request)
        {
            var result = await _basketService.AddBasket(request);
            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result.Message);
        }

        [Produces("application/json", "text/plain")]
        [HttpPost("deletebasketproduct")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> DeleteBasketProduct([FromBody] DeleteBasketProductReqModel request)
        {
            var result = await _basketService.DeleteBasketProduct(request);
            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result.Message);
        }

        [Produces("application/json", "text/plain")]
        [HttpPost("updatebasketproductpiece")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> UpdateBasketProductPiece([FromBody] UpdateBasketProductPieceReqModel request)
        {
            var result = await _basketService.UpdateBasketProductPiece(request);
            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result.Message);
        }

        [Produces("application/json", "text/plain")]
        [HttpGet("getbasket")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetBasket()
        {
            var result = await _basketService.GetBasket();
            if (result.Success)
                return Ok(result.Data);
            else
                return BadRequest(result.Message);
        }
    }
}
