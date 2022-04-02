 using System;
using System.Collections.Generic;
using System.Text;
using X.PagedList;
using Microsoft.AspNetCore.Mvc;
using Business.Services.ProductAggregate.ProductStockTypes;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Business.Services.ProductAggregate.ProductStockTypes.ProductStockTypeServiceModel; 
 namespace eCommerce.Areas.Api { 
 
 [Route("api/[controller]")] 
 [ApiController] 
 public class ProductStockTypeServiceController : ControllerBase{ 
 private readonly IProductStockTypeService _productStockTypeService; 
 
 public ProductStockTypeServiceController(IProductStockTypeService productStockTypeService){ 
 _productStockTypeService=productStockTypeService; 
 } 
 
 [Produces("application/json", "text/plain")] 
 [HttpGet("getallproductstocktype")] 
 [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))] 
 public async Task<IActionResult> GetAllProductStockType (GetAllProductStockType request) { 
 
 var result = await _productStockTypeService.GetAllProductStockType(request); 
 
 if(result.Success) 
 return Ok(result.Success); 
 else 
 return BadRequest(result.Message); 
 } 
 
 } 
 }
