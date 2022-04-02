 using System;
using System.Collections.Generic;
using System.Text;
using X.PagedList;
using Microsoft.AspNetCore.Mvc;
using Business.Services.BrandAggregate.CatalogBrands;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Business.Services.BrandAggregate.CatalogBrands.CatalogBrandModels; 
 namespace eCommerce.Areas.Api { 
 
 [Route("api/[controller]")] 
 [ApiController] 
 public class CatalogBrandServiceController : ControllerBase{ 
 private readonly ICatalogBrandService _catalogBrandService; 
 
 public CatalogBrandServiceController(ICatalogBrandService catalogBrandService){ 
 _catalogBrandService=catalogBrandService; 
 } 
 
 [Produces("application/json", "text/plain")] 
 [HttpGet("getcatalogbrand")] 
 [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))] 
 public async Task<IActionResult> GetCatalogBrand (GetCatalogBrand request) { 
 
 var result = await _catalogBrandService.GetCatalogBrand(request); 
 
 if(result.Success) 
 return Ok(result.Success); 
 else 
 return BadRequest(result.Message); 
 } 
 
 } 
 }
