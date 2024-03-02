using Business.Services.PhotoAggregate.CombinationPhotos;
using Business.Services.PhotoAggregate.CombinationPhotos.CombinationPhotoServiceModel;
using Business.Services.PhotoAggregate.ProductPhotos;
using Business.Services.PhotoAggregate.ProductPhotos.ProductPhotoServiceModel;
using DataAccess.DALs.EntitiyFramework.PhotoAggregate.CombinationPhotos;
using DataAccess.DALs.EntitiyFramework.PhotoAggregate.CombinationPhotos.CombinationPhotoDALModels;
using DataAccess.DALs.EntitiyFramework.ProductAggregate.ProductAttributeCombinations;
using DataAccess.DALs.EntitiyFramework.ProductAggregate.ProductAttributeCombinations.ProductAttributeCombinationDALModels;
using Entities.Others;
using Entities.ViewModels.AdminViewModel.AdminProduct;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Linq;
using System.Threading.Tasks;
namespace eCommerce.Areas.Admin.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [Route("[area]/[controller]/[action]")]
    [Area("Admin")]
    public class ProductPhotoController : AdminBaseController
    {
        private readonly IProductAttributeCombinationDAL _productAttributeCombinationDal;
        private readonly IProductPhotoService _productPhotoService;
        private readonly ICombinationPhotoDAL _combinationPhotoDAL;
        private readonly ICombinationPhotoService _combinationPhotoService;
        public ProductPhotoController(
            IProductAttributeCombinationDAL productAttributeCombinationDal,
            IProductPhotoService productPhotoService, 
            ICombinationPhotoDAL combinationPhotoDAL,
            ICombinationPhotoService combinationPhotoService)
        {
            _productAttributeCombinationDal = productAttributeCombinationDal;
            _productPhotoService = productPhotoService;
            _combinationPhotoDAL = combinationPhotoDAL;
            _combinationPhotoService = combinationPhotoService;
        }
        public async Task<IActionResult> PhotoCombinationdata(int productId = 4)
        {
            var data = await _productAttributeCombinationDal.ProductCombinationMappingAttrXml(
                new ProductCombinationMappingAttrXml(productId));
            return Json(data.Data, new JsonSerializerSettings());
        }
        public async Task<IActionResult> AddProductPhoto(ProductPhotoVM productPhoto)
        {
            await _productPhotoService.AddRangeProductPhotoInsert(new AddRangeProductPhotoInsert(productPhoto.ResimDosya,productPhoto.ProductId));
            var dene = productPhoto.ResimDosya;
            return Json(productPhoto.ResimDosya, new JsonSerializerSettings());
        }
        public async Task<IActionResult> ProductPhotoList(int productId, DataTablesParam param)
        {
            var query = await _productPhotoService.GetProductPhoto(new GetProductPhoto(id: productId,
                pageIndex:param.PageIndex,
                pageSize:param.PageSize,
                orderByText: param.ColumnOrder));
            return ToDataTableJson(query, param);
        }
        public async Task<IActionResult> ProductPhotoListDelete(int id, int productId)
        {
            ResponseAlert(await _productPhotoService.ProductPhotoDelete(new ProductPhotoDelete(id)));
            return Json(true, new JsonSerializerSettings());
        }
        public async Task<IActionResult> PhotoCombinationAdded(CombinationPhotoVM combinationPhotoModel)
        {
            ResponseAlert(await _combinationPhotoService.InsertCombinationPhotos(new InsertCombinationPhotos(
                    combinationPhotoModel.PhotoId,
                    combinationPhotoModel.Combinations,
                    combinationPhotoModel.NotCombinations)));
            return Json(combinationPhotoModel, new JsonSerializerSettings());
        }
        public async Task<IActionResult> PhotoSelectedCombination(int productId, int photoId)
        {
            var data = (await _combinationPhotoDAL.GetAllCombinationPhotosDTO(
                new GetAllCombinationPhotosDTO(productId, photoId))).Data.ToList();
            return Json(data, new JsonSerializerSettings());
        }
    }
}
