using Business.Services.PhotoAggregate.ProductPhotos.Commands;
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
    public class ProductPhotoCommandServiceController : ControllerBase
    {
        private readonly IProductPhotoCommandService _productPhotoCommandService;
        public ProductPhotoCommandServiceController(IProductPhotoCommandService productPhotoCommandService)
        {
            _productPhotoCommandService = productPhotoCommandService;
        }

        [Produces("application/json", "text/plain")]
        [HttpPost("addrangeproductphotoinsert")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> AddRangeProductPhotoInsert([FromForm] AddRangeProductPhotoInsertReqModel request)
        {
            var result = await _productPhotoCommandService.AddRangeProductPhotoInsert(request);
            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result.Message);
        }

        [Produces("application/json", "text/plain")]
        [HttpPost("deleteproductphoto")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> DeleteProductPhoto([FromBody] DeleteProductPhotoReqModel request)
        {
            var result = await _productPhotoCommandService.DeleteProductPhoto(request);
            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result.Message);
        }

        [Produces("application/json", "text/plain")]
        [HttpPost("addproductphoto")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> AddProductPhoto([FromBody] AddProductPhotoReqModel product)
        {
            var result = await _productPhotoCommandService.AddProductPhoto(product);
            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result.Message);
        }
    }
}
