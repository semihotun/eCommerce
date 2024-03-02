 using System;
using System.Collections.Generic;
using System.Text;
using X.PagedList;
using Microsoft.AspNetCore.Mvc;
using Business.Services.ProductAggregate.ProductShipmentInfos;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Core.Utilities.Identity;
using Business.Services.ProductAggregate.ProductShipmentInfos.ProductShipmentInfoServiceModel;
using Entities.Concrete.ProductAggregate; 
 namespace eCommerce.Areas.Api { 
 [AuthorizeControl] 
 [Route("api/[controller]")] 
 [ApiController] 
 public class ProductShipmentInfoServiceController : ControllerBase{ 
 private readonly IProductShipmentInfoService _productShipmentInfoService; 
 public ProductShipmentInfoServiceController(IProductShipmentInfoService productShipmentInfoService){ 
 _productShipmentInfoService=productShipmentInfoService; 
 } 
 [Produces("application/json", "text/plain")] 
 [HttpGet("getproductshipmentinfo")] 
 [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))] 
 public async Task<IActionResult> GetProductShipmentInfo ([FromQuery]GetProductShipmentInfo request) { 
 var result = await _productShipmentInfoService.GetProductShipmentInfo(request); 
 if(result.Success) 
 return Ok(result.Data); 
 else 
 return BadRequest(result.Message); 
 } 
 [Produces("application/json", "text/plain")] 
 [HttpPost("addproductshipmentinfo")] 
 [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))] 
 public async Task<IActionResult> AddProductShipmentInfo ([FromBody]ProductShipmentInfo productShipmentInfo) { 
 var result = await _productShipmentInfoService.AddProductShipmentInfo(productShipmentInfo); 
 if(result.Success) 
 return Ok(result.Success); 
 else 
 return BadRequest(result.Message); 
 } 
 [Produces("application/json", "text/plain")] 
 [HttpPost("updateproductshipmentinfo")] 
 [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))] 
 public async Task<IActionResult> UpdateProductShipmentInfo ([FromBody]ProductShipmentInfo productShipmentInfo) { 
 var result = await _productShipmentInfoService.UpdateProductShipmentInfo(productShipmentInfo); 
 if(result.Success) 
 return Ok(result.Success); 
 else 
 return BadRequest(result.Message); 
 } 
 [Produces("application/json", "text/plain")] 
 [HttpPost("addorupdateproductshipmentinfo")] 
 [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))] 
 public async Task<IActionResult> AddOrUpdateProductShipmentInfo ([FromBody]ProductShipmentInfo productShipmentInfo) { 
 var result = await _productShipmentInfoService.AddOrUpdateProductShipmentInfo(productShipmentInfo); 
 if(result.Success) 
 return Ok(result.Success); 
 else 
 return BadRequest(result.Message); 
 } 
 } 
 }
