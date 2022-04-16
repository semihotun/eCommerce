 using System;
using System.Collections.Generic;
using System.Text;
using X.PagedList;
using Microsoft.AspNetCore.Mvc;
using DataAccess.DALs.EntitiyFramework.DiscountsAggregate.Discounts;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Core.Utilities.Identity;
using DataAccess.DALs.EntitiyFramework.DiscountsAggregate.Discounts.DiscountDALModels; 
 namespace eCommerce.Areas.Api { 
 [AuthorizeControl] 
 [Route("api/[controller]")] 
 [ApiController] 
 public class DiscountDALController : ControllerBase{ 
 private readonly IDiscountDAL _discountDAL; 
 
 public DiscountDALController(IDiscountDAL discountDAL){ 
 _discountDAL=discountDAL; 
 } 
 
 
 [Produces("application/json", "text/plain")] 
 [HttpPost("getdatatablelist")] 
 [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))] 
 public async Task<IActionResult> GetDataTableList ([FromBody]GetDataTableList request) { 
 
 var result = await _discountDAL.GetDataTableList(request); 
 
 if(result.Success) 
 return Ok(result.Data); 
 else 
 return BadRequest(result.Message); 
 
 } 
 
 } 
 }
