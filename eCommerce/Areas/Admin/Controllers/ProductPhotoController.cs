using Business.Services.PhotoAggregate.ProductPhotos.Queries;
using Core.Utilities.DataTable;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
namespace eCommerce.Areas.Admin.Controllers
{
    public class ProductPhotoController : AdminBaseController
    {
        private readonly IProductPhotoQueryService _productPhotoQueryService;
        public ProductPhotoController(
            IProductPhotoQueryService productPhotoQueryService)
        {
            _productPhotoQueryService = productPhotoQueryService;
        }
        public async Task<IActionResult> ProductPhotoList(Guid productId, DTParameters param) =>
             ToDataTableJson(await _productPhotoQueryService.GetProductPhoto(new(productId, param)), param);
    }
}
