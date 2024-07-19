using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.PagedList;
using Microsoft.AspNetCore.Mvc;
using Business.Services.ProductAggregate.Products.DtoQueries;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Core.Utilities.Identity;
using Entities.RequestModel.ProductAggregate.Products;
using Entities.RequestModel.ProductAggregate.Catalog;

namespace eCommerce.Areas.Api
{
    [AuthorizeControl]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductDtoQueryServiceController : ControllerBase
    {
        private readonly IProductDtoQueryService _productDtoQueryService;
        public ProductDtoQueryServiceController(IProductDtoQueryService productDtoQueryService)
        {
            _productDtoQueryService = productDtoQueryService;
        }

        [AllowAnonymous]
        [Produces("application/json", "text/plain")]
        [HttpPost("getproductdatatablelist")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Core.Utilities.Results.Result<Core.Utilities.PagedList.IPagedList<Entities.Dtos.ProductDALModels.ProductDataTableJson>>))]
        public async Task<IActionResult> GetProductDataTableList([FromBody] GetProductDataTableListReqModel request)
        {
            var result = await _productDtoQueryService.GetProductDataTableList(request);
            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result.Message);
        }

        [AllowAnonymous]
        [Produces("application/json", "text/plain")]
        [HttpGet("gethomeproductdetail")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Entities.Dtos.ProductDALModels.ProductDetailDTO))]
        public async Task<IActionResult> GetHomeProductDetail([FromQuery] GetHomeProductDetailReqModel request)
        {
            var result = await _productDtoQueryService.GetHomeProductDetail(request);
            if (result.Success)
                return Ok(result.Data);
            else
                return BadRequest(result.Message);
        }

        [AllowAnonymous]
        [Produces("application/json", "text/plain")]
        [HttpGet("getanotherproductlist")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(System.Collections.Generic.List<Entities.Dtos.ShowcaseDALModels.ShowCaseProductDTO.Product>))]
        public async Task<IActionResult> GetAnotherProductList()
        {
            var result = await _productDtoQueryService.GetAnotherProductList();
            if (result.Success)
                return Ok(result.Data);
            else
                return BadRequest(result.Message);
        }

        [AllowAnonymous]
        [Produces("application/json", "text/plain")]
        [HttpGet("getcheckout")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Entities.Dtos.ProductDALModels.Checkout))]
        public async Task<IActionResult> GetCheckout([FromQuery] GetCheckoutReqModel request)
        {
            var result = await _productDtoQueryService.GetCheckout(request);
            if (result.Success)
                return Ok(result.Data);
            else
                return BadRequest(result.Message);
        }

        [AllowAnonymous]
        [Produces("application/json", "text/plain")]
        [HttpGet("getcommentlistdto")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Entities.Dtos.ProductDALModels.ProductCommentDTO))]
        public async Task<IActionResult> GetCommentListDTO([FromQuery] GetCommentListReqModel request)
        {
            var result = await _productDtoQueryService.GetCommentListDTO(request);
            if (result.Success)
                return Ok(result.Data);
            else
                return BadRequest(result.Message);
        }

        [AllowAnonymous]
        [Produces("application/json", "text/plain")]
        [HttpGet("getcatalogproduct")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Core.Utilities.PagedList.IPagedList<Entities.Dtos.ProductDALModels.CatalogProduct>))]
        public async Task<IActionResult> GetCatalogProduct([FromQuery] GetCatalogProductReqModel catalog)
        {
            var result = await _productDtoQueryService.GetCatalogProduct(catalog);
            if (result.Success)
                return Ok(result.Data);
            else
                return BadRequest(result.Message);
        }

        [AllowAnonymous]
        [Produces("application/json", "text/plain")]
        [HttpGet("getproductdetailvm")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Entities.ViewModels.WebViewModel.Home.ProductDetailVM))]
        public async Task<IActionResult> GetProductDetailVM([FromQuery] GetProductDetailReqModel request)
        {
            var result = await _productDtoQueryService.GetProductDetailVM(request);
            if (result.Success)
                return Ok(result.Data);
            else
                return BadRequest(result.Message);
        }

        [AllowAnonymous]
        [Produces("application/json", "text/plain")]
        [HttpGet("getmainsearchproduct")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(System.Collections.Generic.List<Entities.ViewModels.WebViewModel.Home.ProductSearch>))]
        public async Task<IActionResult> GetMainSearchProduct([FromQuery] GetMainSearchProductReqModel request)
        {
            var result = await _productDtoQueryService.GetMainSearchProduct(request);
            if (result.Success)
                return Ok(result.Data);
            else
                return BadRequest(result.Message);
        }
    }
}
