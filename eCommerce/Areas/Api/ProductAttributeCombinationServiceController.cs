 using System;
using System.Collections.Generic;
using System.Text;
using X.PagedList;
using Microsoft.AspNetCore.Mvc;
using Business.Services.ProductAggregate.ProductAttributeCombinations;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Business.Services.ProductAggregate.ProductAttributeCombinations.ProductAttributeCombinationServiceModel;
using Entities.Concrete.ProductAggregate; 
 namespace eCommerce.Areas.Api { 
 
 [Route("api/[controller]")] 
 [ApiController] 
 public class ProductAttributeCombinationServiceController : ControllerBase{ 
 private readonly IProductAttributeCombinationService _productAttributeCombinationService; 
 
 public ProductAttributeCombinationServiceController(IProductAttributeCombinationService productAttributeCombinationService){ 
 _productAttributeCombinationService=productAttributeCombinationService; 
 } 
 
 [Produces("application/json", "text/plain")] 
 [HttpPost("insertpermutationcombination")] 
 [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))] 
 [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))] 
 public async Task<IActionResult> InsertPermutationCombination ([FromBody]InsertPermutationCombination request) { 
 
 var result = await _productAttributeCombinationService.InsertPermutationCombination(request); 
 
 if(result.Success) 
 return Ok(result.Success); 
 else 
 return BadRequest(result.Message); 
 
 } 
 
 [Produces("application/json", "text/plain")] 
 [HttpPost("deleteproductattributecombination")] 
 [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))] 
 [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))] 
 public async Task<IActionResult> DeleteProductAttributeCombination ([FromBody]DeleteProductAttributeCombination request) { 
 
 var result = await _productAttributeCombinationService.DeleteProductAttributeCombination(request); 
 
 if(result.Success) 
 return Ok(result.Success); 
 else 
 return BadRequest(result.Message); 
 
 } 
 
 [Produces("application/json", "text/plain")] 
 [HttpGet("getallproductattributecombinations")] 
 [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))] 
 public async Task<IActionResult> GetAllProductAttributeCombinations (GetAllProductAttributeCombinations request) { 
 
 var result = await _productAttributeCombinationService.GetAllProductAttributeCombinations(request); 
 
 if(result.Success) 
 return Ok(result.Success); 
 else 
 return BadRequest(result.Message); 
 } 
 
 [Produces("application/json", "text/plain")] 
 [HttpGet("getproductcombinationxml")] 
 [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))] 
 public async Task<IActionResult> GetProductCombinationXml (GetProductCombinationXml request) { 
 
 var result = await _productAttributeCombinationService.GetProductCombinationXml(request); 
 
 if(result.Success) 
 return Ok(result.Success); 
 else 
 return BadRequest(result.Message); 
 } 
 
 [Produces("application/json", "text/plain")] 
 [HttpGet("getproductattributecombinationbyid")] 
 [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))] 
 public async Task<IActionResult> GetProductAttributeCombinationById (GetProductAttributeCombinationById request) { 
 
 var result = await _productAttributeCombinationService.GetProductAttributeCombinationById(request); 
 
 if(result.Success) 
 return Ok(result.Success); 
 else 
 return BadRequest(result.Message); 
 } 
 
 [Produces("application/json", "text/plain")] 
 [HttpGet("getproductattributecombinationbysku")] 
 [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))] 
 public async Task<IActionResult> GetProductAttributeCombinationBySku (GetProductAttributeCombinationBySku request) { 
 
 var result = await _productAttributeCombinationService.GetProductAttributeCombinationBySku(request); 
 
 if(result.Success) 
 return Ok(result.Success); 
 else 
 return BadRequest(result.Message); 
 } 
 
 [Produces("application/json", "text/plain")] 
 [HttpPost("insertproductattributecombination")] 
 [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))] 
 [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))] 
 public async Task<IActionResult> InsertProductAttributeCombination ([FromBody]ProductAttributeCombination combination) { 
 
 var result = await _productAttributeCombinationService.InsertProductAttributeCombination(combination); 
 
 if(result.Success) 
 return Ok(result.Success); 
 else 
 return BadRequest(result.Message); 
 
 } 
 
 [Produces("application/json", "text/plain")] 
 [HttpPost("updateproductattributecombination")] 
 [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))] 
 [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))] 
 public async Task<IActionResult> UpdateProductAttributeCombination ([FromBody]ProductAttributeCombination combination) { 
 
 var result = await _productAttributeCombinationService.UpdateProductAttributeCombination(combination); 
 
 if(result.Success) 
 return Ok(result.Success); 
 else 
 return BadRequest(result.Message); 
 
 } 
 
 } 
 }
