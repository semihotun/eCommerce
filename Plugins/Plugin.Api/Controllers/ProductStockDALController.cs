 using System;
using System.Collections.Generic;
using System.Text;
using X.PagedList;
using Microsoft.AspNetCore.Mvc;
using DataAccess.DALs.EntitiyFramework.ProductAggregate.ProductStocks;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Core.Utilities.Identity;
using DataAccess.DALs.EntitiyFramework.ProductAggregate.ProductStocks.ProductStockDALModels; 
 namespace eCommerce.Areas.Api { 
 [AuthorizeControl] 
 [Route("api/[controller]")] 
 [ApiController] 
 public class ProductStockDALController : ControllerBase{ 
 private readonly IProductStockDAL _productStockDAL; 
 
 public ProductStockDALController(IProductStockDAL productStockDAL){ 
 _productStockDAL=productStockDAL; 
 } 
 
 
 [Produces("application/json", "text/plain")] 
 [HttpGet("getallproductstockdto")] 
 [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))] 
 public async Task<IActionResult> GetAllProductStockDto ([FromQuery]GetAllProductStockDto request) { 
 
 var result = await _productStockDAL.GetAllProductStockDto(request); 
 
 if(result.Success) 
 return Ok(result.Data); 
 else 
 return BadRequest(result.Message); 
 } 
 
 } 
 }
