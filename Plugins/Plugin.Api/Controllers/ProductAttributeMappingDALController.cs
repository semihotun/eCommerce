 using System;
using System.Collections.Generic;
using System.Text;
using X.PagedList;
using Microsoft.AspNetCore.Mvc;
using DataAccess.DALs.EntitiyFramework.ProductAggregate.ProductAttributeMappings;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Core.Utilities.Identity;
using DataAccess.DALs.EntitiyFramework.ProductAggregate.ProductAttributeMappings.ProductAttributeMappingDALModels; 
 namespace eCommerce.Areas.Api { 
 [AuthorizeControl] 
 [Route("api/[controller]")] 
 [ApiController] 
 public class ProductAttributeMappingDALController : ControllerBase{ 
 private readonly IProductAttributeMappingDAL _productAttributeMappingDAL; 
 
 public ProductAttributeMappingDALController(IProductAttributeMappingDAL productAttributeMappingDAL){ 
 _productAttributeMappingDAL=productAttributeMappingDAL; 
 } 
 
 
 [Produces("application/json", "text/plain")] 
 [HttpGet("getproductdetailmappingjson")] 
 [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))] 
 public async Task<IActionResult> GetProductDetailMappingJson ([FromQuery]GetProductDetailMappingJson request) { 
 
 var result = await _productAttributeMappingDAL.GetProductDetailMappingJson(request); 
 
 if(result.Success) 
 return Ok(result.Data); 
 else 
 return BadRequest(result.Message); 
 } 
 
 
 [Produces("application/json", "text/plain")] 
 [HttpGet("getmappingproductattributelist")] 
 [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))] 
 public async Task<IActionResult> GetMappingProductAttributeList ([FromQuery]GetMappingProductAttributeList request) { 
 
 var result = await _productAttributeMappingDAL.GetMappingProductAttributeList(request); 
 
 if(result.Success) 
 return Ok(result.Data); 
 else 
 return BadRequest(result.Message); 
 } 
 
 } 
 }
