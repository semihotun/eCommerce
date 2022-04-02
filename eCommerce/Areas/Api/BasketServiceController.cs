 using System;
using System.Collections.Generic;
using System.Text;
using X.PagedList;
using Microsoft.AspNetCore.Mvc;
using Business.Services.BasketAggregate.Baskets;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Entities.Concrete.BasketAggregate; 
 namespace eCommerce.Areas.Api { 
 
 [Route("api/[controller]")] 
 [ApiController] 
 public class BasketServiceController : ControllerBase{ 
 private readonly IBasketService _basketService; 
 
 public BasketServiceController(IBasketService basketService){ 
 _basketService=basketService; 
 } 
 
 [Produces("application/json", "text/plain")] 
 [HttpGet("getbasket")] 
 [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))] 
 public async Task<IActionResult> GetBasket () { 
 
 var result = await _basketService.GetBasket(); 
 
 if(result.Success) 
 return Ok(result.Success); 
 else 
 return BadRequest(result.Message); 
 } 
 
 [Produces("application/json", "text/plain")] 
 [HttpPost("basketadded")] 
 [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))] 
 [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))] 
 public async Task<IActionResult> BasketAdded ([FromBody]Basket basket) { 
 
 var result = await _basketService.BasketAdded(basket); 
 
 if(result.Success) 
 return Ok(result.Success); 
 else 
 return BadRequest(result.Message); 
 
 } 
 
 } 
 }
