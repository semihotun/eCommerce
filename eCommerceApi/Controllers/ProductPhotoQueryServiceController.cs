using Business.Services.PhotoAggregate.ProductPhotos.Queries;
using Core.Utilities.Identity;
using Entities.RequestModel.PhotoAggregate.ProductPhotos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace eCommerce.Areas.Api
{
    [AuthorizeControl]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductPhotoQueryServiceController : ControllerBase
    {
        private readonly IProductPhotoQueryService _productPhotoQueryService;
        public ProductPhotoQueryServiceController(IProductPhotoQueryService productPhotoQueryService)
        {
            _productPhotoQueryService = productPhotoQueryService;
        }

        [Produces("application/json", "text/plain")]
        [HttpGet("getproductphotobyid")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetProductPhotoById([FromQuery] GetProductPhotoByIdReqModel request)
        {
            var result = await _productPhotoQueryService.GetProductPhotoById(request);
            if (result.Success)
                return Ok(result.Data);
            else
                return BadRequest(result.Message);
        }

        [Produces("application/json", "text/plain")]
        [HttpGet("getproductphoto")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetProductPhoto([FromQuery] GetProductPhotoReqModel request)
        {
            var result = await _productPhotoQueryService.GetProductPhoto(request);
            if (result.Success)
                return Ok(result.Data);
            else
                return BadRequest(result.Message);
        }
    }
}
