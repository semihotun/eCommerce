 using System;
using System.Collections.Generic;
using System.Text;
using X.PagedList;
using Microsoft.AspNetCore.Mvc;
using Business.Services.DiscountsAggregate.DiscountUsageHistorys;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Core.Utilities.Identity;
using Entities.Concrete.DiscountsAggregate;
using Business.Services.DiscountsAggregate.DiscountUsageHistorys.DiscountUsageHistoryServiceModel; 
 namespace eCommerce.Areas.Api { 
 [AuthorizeControl] 
 [Route("api/[controller]")] 
 [ApiController] 
 public class DiscountUsageHistoryServiceController : ControllerBase{ 
 private readonly IDiscountUsageHistoryService _discountUsageHistoryService; 
 
 public DiscountUsageHistoryServiceController(IDiscountUsageHistoryService discountUsageHistoryService){ 
 _discountUsageHistoryService=discountUsageHistoryService; 
 } 
 
 
 [Produces("application/json", "text/plain")] 
 [HttpPost("adddiscountusagehistory")] 
 [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))] 
 public async Task<IActionResult> AddDiscountUsageHistory ([FromBody]DiscountUsageHistory discountUsageHistory) { 
 
 var result = await _discountUsageHistoryService.AddDiscountUsageHistory(discountUsageHistory); 
 
 if(result.Success) 
 return Ok(result.Success); 
 else 
 return BadRequest(result.Message); 
 
 } 
 
 
 [Produces("application/json", "text/plain")] 
 [HttpPost("deletediscountusagehistory")] 
 [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))] 
 public async Task<IActionResult> DeleteDiscountUsageHistory ([FromBody]DiscountUsageHistory discountUsageHistory) { 
 
 var result = await _discountUsageHistoryService.DeleteDiscountUsageHistory(discountUsageHistory); 
 
 if(result.Success) 
 return Ok(result.Success); 
 else 
 return BadRequest(result.Message); 
 
 } 
 
 
 [Produces("application/json", "text/plain")] 
 [HttpGet("getalldiscountusagehistory")] 
 [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))] 
 public async Task<IActionResult> GetAllDiscountUsageHistory ([FromQuery]GetAllDiscountUsageHistory request) { 
 
 var result = await _discountUsageHistoryService.GetAllDiscountUsageHistory(request); 
 
 if(result.Success) 
 return Ok(result.Data); 
 else 
 return BadRequest(result.Message); 
 } 
 
 
 [Produces("application/json", "text/plain")] 
 [HttpPost("updatediscountusagehistory")] 
 [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))] 
 public async Task<IActionResult> UpdateDiscountUsageHistory ([FromBody]DiscountUsageHistory discountUsageHistory) { 
 
 var result = await _discountUsageHistoryService.UpdateDiscountUsageHistory(discountUsageHistory); 
 
 if(result.Success) 
 return Ok(result.Success); 
 else 
 return BadRequest(result.Message); 
 
 } 
 
 } 
 }
