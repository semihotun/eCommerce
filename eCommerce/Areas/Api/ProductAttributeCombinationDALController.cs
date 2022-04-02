 using System;
using System.Collections.Generic;
using System.Text;
using X.PagedList;
using Microsoft.AspNetCore.Mvc;
using DataAccess.DALs.EntitiyFramework.ProductAggregate.ProductAttributeCombinations;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using DataAccess.DALs.EntitiyFramework.ProductAggregate.ProductAttributeCombinations.ProductAttributeCombinationDALModels; 
 namespace eCommerce.Areas.Api { 
 
 [Route("api/[controller]")] 
 [ApiController] 
 public class ProductAttributeCombinationDALController : ControllerBase{ 
 private readonly IProductAttributeCombinationDAL _productAttributeCombinationDAL; 
 
 public ProductAttributeCombinationDALController(IProductAttributeCombinationDAL productAttributeCombinationDAL){ 
 _productAttributeCombinationDAL=productAttributeCombinationDAL; 
 } 
 
 [Produces("application/json", "text/plain")] 
 [HttpPost("productattributecombinationdropdown")] 
 [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))] 
 [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))] 
 public async Task<IActionResult> ProductAttributeCombinationDropDown ([FromBody]ProductAttributeCombinationDropDown request) { 
 
 var result = await _productAttributeCombinationDAL.ProductAttributeCombinationDropDown(request); 
 
 if(result.Success) 
 return Ok(result.Success); 
 else 
 return BadRequest(result.Message); 
 
 } 
 
 [Produces("application/json", "text/plain")] 
 [HttpPost("productattributecombinationdatatable")] 
 [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))] 
 [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))] 
 public async Task<IActionResult> ProductAttributeCombinationDataTable ([FromBody]ProductAttributeCombinationDataTable request) { 
 
 var result = await _productAttributeCombinationDAL.ProductAttributeCombinationDataTable(request); 
 
 if(result.Success) 
 return Ok(result.Success); 
 else 
 return BadRequest(result.Message); 
 
 } 
 
 [Produces("application/json", "text/plain")] 
 [HttpPost("productcombinationmappingattrxml")] 
 [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))] 
 [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))] 
 public async Task<IActionResult> ProductCombinationMappingAttrXml ([FromBody]ProductCombinationMappingAttrXml request) { 
 
 var result = await _productAttributeCombinationDAL.ProductCombinationMappingAttrXml(request); 
 
 if(result.Success) 
 return Ok(result.Success); 
 else 
 return BadRequest(result.Message); 
 
 } 
 
 } 
 }
