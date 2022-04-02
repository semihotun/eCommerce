 using System;
using System.Collections.Generic;
using System.Text;
using X.PagedList;
using Microsoft.AspNetCore.Mvc;
using DataAccess.DALs.EntitiyFramework.ProductAggregate.Products;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using DataAccess.DALs.EntitiyFramework.ProductAggregate.Products.ProductDALModels;
using Entities.ViewModels.WebViewModel.Home; 
 namespace eCommerce.Areas.Api { 
 
 [Route("api/[controller]")] 
 [ApiController] 
 public class ProductDALController : ControllerBase{ 
 private readonly IProductDAL _productDAL; 
 
 public ProductDALController(IProductDAL productDAL){ 
 _productDAL=productDAL; 
 } 
 
 [Produces("application/json", "text/plain")] 
 [HttpPost("getproductdatatablelist")] 
 [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))] 
 [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))] 
 public async Task<IActionResult> GetProductDataTableList ([FromBody]GetProductDataTableList request) { 
 
 var result = await _productDAL.GetProductDataTableList(request); 
 
 if(result.Success) 
 return Ok(result.Success); 
 else 
 return BadRequest(result.Message); 
 
 } 
 
 [Produces("application/json", "text/plain")] 
 [HttpGet("gethomeproductdetail")] 
 [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))] 
 public async Task<IActionResult> GetHomeProductDetail (GetHomeProductDetail request) { 
 
 var result = await _productDAL.GetHomeProductDetail(request); 
 
 if(result.Success) 
 return Ok(result.Success); 
 else 
 return BadRequest(result.Message); 
 } 
 
 [Produces("application/json", "text/plain")] 
 [HttpGet("getanotherproductlist")] 
 [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))] 
 public async Task<IActionResult> GetAnotherProductList () { 
 
 var result = await _productDAL.GetAnotherProductList(); 
 
 if(result.Success) 
 return Ok(result.Success); 
 else 
 return BadRequest(result.Message); 
 } 
 
 [Produces("application/json", "text/plain")] 
 [HttpGet("getcheckout")] 
 [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))] 
 public async Task<IActionResult> GetCheckout (GetCheckout request) { 
 
 var result = await _productDAL.GetCheckout(request); 
 
 if(result.Success) 
 return Ok(result.Success); 
 else 
 return BadRequest(result.Message); 
 } 
 
 [Produces("application/json", "text/plain")] 
 [HttpGet("getcommentlistdto")] 
 [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))] 
 public async Task<IActionResult> GetCommentListDTO (GetCommentListDTO request) { 
 
 var result = await _productDAL.GetCommentListDTO(request); 
 
 if(result.Success) 
 return Ok(result.Success); 
 else 
 return BadRequest(result.Message); 
 } 
 
 [Produces("application/json", "text/plain")] 
 [HttpGet("getcatalogproduct")] 
 [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))] 
 public async Task<IActionResult> GetCatalogProduct (CatalogVM catalog) { 
 
 var result = await _productDAL.GetCatalogProduct(catalog); 
 
 if(result.Success) 
 return Ok(result.Success); 
 else 
 return BadRequest(result.Message); 
 } 
 
 [Produces("application/json", "text/plain")] 
 [HttpGet("getproductdetailvm")] 
 [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))] 
 public async Task<IActionResult> GetProductDetailVM (GetProductDetailVM request) { 
 
 var result = await _productDAL.GetProductDetailVM(request); 
 
 if(result.Success) 
 return Ok(result.Success); 
 else 
 return BadRequest(result.Message); 
 } 
 
 } 
 }
