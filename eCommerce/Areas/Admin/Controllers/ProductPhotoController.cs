using Business.Services.PhotoAggregate.ProductPhotos;
using Core.Utilities.DataTable;
using Entities.Others;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
namespace eCommerce.Areas.Admin.Controllers
{
    public class ProductPhotoController : AdminBaseController
    {
        private readonly IProductPhotoService _productPhotoService;
        public ProductPhotoController(
            IProductPhotoService productPhotoService)
        {
            _productPhotoService = productPhotoService;
        }
        public async Task<IActionResult> ProductPhotoList(int productId, DTParameters param) =>
             ToDataTableJson(await _productPhotoService.GetProductPhoto(new(productId, param)), param);
    }
}
