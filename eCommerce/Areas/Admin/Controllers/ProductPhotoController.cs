using Business.Services.PhotoAggregate.ProductPhotos;
using Business.Services.PhotoAggregate.ProductPhotos.ProductPhotoServiceModel;
using Entities.Others;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
namespace eCommerce.Areas.Admin.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [Route("[area]/[controller]/[action]")]
    [Area("Admin")]
    public class ProductPhotoController : AdminBaseController
    {
        private readonly IProductPhotoService _productPhotoService;
        public ProductPhotoController(
            IProductPhotoService productPhotoService)
        {
            _productPhotoService = productPhotoService;
        }
        public async Task<IActionResult> ProductPhotoList(int productId, DataTablesParam param) =>
            ToDataTableJson(await _productPhotoService.GetProductPhoto(new GetProductPhoto(id: productId,
                pageIndex: param.PageIndex,
                pageSize: param.PageSize,
                orderByText: param.ColumnOrder)), param);
    }
}
