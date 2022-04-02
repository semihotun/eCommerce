 using System;
using System.Collections.Generic;
using System.Text;
using X.PagedList;
using Microsoft.AspNetCore.Mvc;
using DataAccess.DALs.EntitiyFramework.ProductAggregate.ProductSpecificationAttributes;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using DataAccess.DALs.EntitiyFramework.ProductAggregate.ProductSpecificationAttributes.ProductSpecificationAttributeDALModels; 
 namespace eCommerce.Areas.Api { 
 
 [Route("api/[controller]")] 
 [ApiController] 
 public class ProductSpecificationAttributeDALController : ControllerBase{ 
 private readonly IProductSpecificationAttributeDAL _productSpecificationAttributeDAL; 
 
 public ProductSpecificationAttributeDALController(IProductSpecificationAttributeDAL productSpecificationAttributeDAL){ 
 _productSpecificationAttributeDAL=productSpecificationAttributeDAL; 
 } 
 
 [Produces("application/json", "text/plain")] 
 [HttpPost("productspecattrlist")] 
 [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))] 
 [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))] 
 public async Task<IActionResult> ProductSpecAttrList ([FromBody]ProductSpecAttrList request) { 
 
 var result = await _productSpecificationAttributeDAL.ProductSpecAttrList(request); 
 
 if(result.Success) 
 return Ok(result.Success); 
 else 
 return BadRequest(result.Message); 
 
 } 
 
 [Produces("application/json", "text/plain")] 
 [HttpGet("getproductspeficationattr")] 
 [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))] 
 public async Task<IActionResult> GetProductSpeficationAttr (GetProductSpeficationAttr request) { 
 
 var result = await _productSpecificationAttributeDAL.GetProductSpeficationAttr(request); 
 
 if(result.Success) 
 return Ok(result.Success); 
 else 
 return BadRequest(result.Message); 
 } 
 
 } 
 }
