 using System;
using System.Collections.Generic;
using System.Text;
using X.PagedList;
using Microsoft.AspNetCore.Mvc;
using DataAccess.DALs.EntitiyFramework.BrandAggregate.Brands;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Core.Utilities.Identity;
using DataAccess.DALs.EntitiyFramework.BrandAggregate.Brands.BrandDALModels; 
 namespace eCommerce.Areas.Api { 
 [AuthorizeControl] 
 [Route("api/[controller]")] 
 [ApiController] 
 public class BrandDALController : ControllerBase{ 
 private readonly IBrandDAL _brandDAL; 
 public BrandDALController(IBrandDAL brandDAL){ 
 _brandDAL=brandDAL; 
 } 
 [Produces("application/json", "text/plain")] 
 [HttpPost("getbranddatatable")] 
 [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))] 
 public async Task<IActionResult> GetBrandDataTable ([FromBody]GetBrandDataTable request) { 
 var result = await _brandDAL.GetBrandDataTable(request); 
 if(result.Success) 
 return Ok(result.Data); 
 else 
 return BadRequest(result.Message); 
 } 
 } 
 }
