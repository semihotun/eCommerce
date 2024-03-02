 using System;
using System.Collections.Generic;
using System.Text;
using X.PagedList;
using Microsoft.AspNetCore.Mvc;
using Business.Services.ProductAggregate.ProductStocks;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Core.Utilities.Identity;
using Business.Services.ProductAggregate.ProductStocks.ProductStockServiceModel;
using Entities.Concrete.ProductAggregate; 
 namespace eCommerce.Areas.Api { 
 [AuthorizeControl] 
 [Route("api/[controller]")] 
 [ApiController] 
 public class ProductStockServiceController : ControllerBase{ 
 private readonly IProductStockService _productStockService; 
 public ProductStockServiceController(IProductStockService productStockService){ 
 _productStockService=productStockService; 
 } 
 [Produces("application/json", "text/plain")] 
 [HttpGet("getallproductstock")] 
 [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))] 
 public async Task<IActionResult> GetAllProductStock ([FromQuery]GetAllProductStock request) { 
 var result = await _productStockService.GetAllProductStock(request); 
 if(result.Success) 
 return Ok(result.Data); 
 else 
 return BadRequest(result.Message); 
 } 
 [Produces("application/json", "text/plain")] 
 [HttpPost("addproductstock")] 
 [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))] 
 public async Task<IActionResult> AddProductStock ([FromBody]ProductStock productStock) { 
 var result = await _productStockService.AddProductStock(productStock); 
 if(result.Success) 
 return Ok(result.Success); 
 else 
 return BadRequest(result.Message); 
 } 
 [Produces("application/json", "text/plain")] 
 [HttpPost("deleteproductstock")] 
 [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))] 
 public async Task<IActionResult> DeleteProductStock ([FromBody]DeleteProductStock request) { 
 var result = await _productStockService.DeleteProductStock(request); 
 if(result.Success) 
 return Ok(result.Success); 
 else 
 return BadRequest(result.Message); 
 } 
 } 
 }
