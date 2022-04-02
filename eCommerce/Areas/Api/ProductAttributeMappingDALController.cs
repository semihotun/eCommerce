 using System;
using System.Collections.Generic;
using System.Text;
using X.PagedList;
using Microsoft.AspNetCore.Mvc;
using DataAccess.DALs.EntitiyFramework.ProductAggregate.ProductAttributeMappings;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using DataAccess.DALs.EntitiyFramework.ProductAggregate.ProductAttributeMappings.ProductAttributeMappingDALModels; 
 namespace eCommerce.Areas.Api { 
 
 [Route("api/[controller]")] 
 [ApiController] 
 public class ProductAttributeMappingDALController : ControllerBase{ 
 private readonly IProductAttributeMappingDAL _productAttributeMappingDAL; 
 
 public ProductAttributeMappingDALController(IProductAttributeMappingDAL productAttributeMappingDAL){ 
 _productAttributeMappingDAL=productAttributeMappingDAL; 
 } 
 
 [Produces("application/json", "text/plain")] 
 [HttpPost("productdetailmappingjson")] 
 [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))] 
 [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))] 
 public async Task<IActionResult> ProductDetailMappingJson ([FromBody]ProductDetailMappingJson request) { 
 
 var result = await _productAttributeMappingDAL.ProductDetailMappingJson(request); 
 
 if(result.Success) 
 return Ok(result.Success); 
 else 
 return BadRequest(result.Message); 
 
 } 
 
 [Produces("application/json", "text/plain")] 
 [HttpGet("getmappingproductattributelist")] 
 [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))] 
 public async Task<IActionResult> GetMappingProductAttributeList (GetMappingProductAttributeList request) { 
 
 var result = await _productAttributeMappingDAL.GetMappingProductAttributeList(request); 
 
 if(result.Success) 
 return Ok(result.Success); 
 else 
 return BadRequest(result.Message); 
 } 
 
 } 
 }
