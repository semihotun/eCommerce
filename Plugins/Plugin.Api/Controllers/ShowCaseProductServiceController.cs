 using System;
using System.Collections.Generic;
using System.Text;
using X.PagedList;
using Microsoft.AspNetCore.Mvc;
using Business.Services.ShowcaseAggregate.ShowCaseProducts;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Core.Utilities.Identity;
using Business.Services.ShowcaseAggregate.ShowCaseProducts.ShowCaseProductServiceModel;
using Entities.Concrete.ShowcaseAggregate; 
 namespace eCommerce.Areas.Api { 
 [AuthorizeControl] 
 [Route("api/[controller]")] 
 [ApiController] 
 public class ShowCaseProductServiceController : ControllerBase{ 
 private readonly IShowCaseProductService _showCaseProductService; 
 
 public ShowCaseProductServiceController(IShowCaseProductService showCaseProductService){ 
 _showCaseProductService=showCaseProductService; 
 } 
 
 
 [Produces("application/json", "text/plain")] 
 [HttpPost("deleteshowcaseproduct")] 
 [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))] 
 public async Task<IActionResult> DeleteShowCaseProduct ([FromBody]DeleteShowCaseProduct request) { 
 
 var result = await _showCaseProductService.DeleteShowCaseProduct(request); 
 
 if(result.Success) 
 return Ok(result.Success); 
 else 
 return BadRequest(result.Message); 
 
 } 
 
 
 [Produces("application/json", "text/plain")] 
 [HttpPost("insertproductshowcase")] 
 [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))] 
 public async Task<IActionResult> InsertProductShowcase ([FromBody]ShowCaseProduct showCaseProduct) { 
 
 var result = await _showCaseProductService.InsertProductShowcase(showCaseProduct); 
 
 if(result.Success) 
 return Ok(result.Success); 
 else 
 return BadRequest(result.Message); 
 
 } 
 
 } 
 }
