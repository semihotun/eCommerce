using Business.Services.ProductAggregate.ProductAttributes;
using Core.Utilities.Identity;
using Entities.Concrete.ProductAggregate;
using Entities.Extensions.AutoMapper;
using Entities.Others;
using Entities.RequestModel.ProductAggregate.ProductAttributes;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
namespace eCommerce.Areas.Admin.Controllers
{
    public class AdminProductAttrController : AdminBaseController
    {
        private readonly IProductAttributeService _productattrService;
        public AdminProductAttrController(
            IProductAttributeService productattrService
           )
        {
            this._productattrService = productattrService;
        }
        public async Task<IActionResult> ProductAttributeListJson(ProductAttribute model, DataTablesParam param) =>
             ToDataTableJson(await _productattrService.GetAllProductAttributes(
                new GetAllProductAttributesReqModel(param.PageIndex, param.PageSize, model.Name)), param);

        public IActionResult ProductAttributeList(ProductAttribute model) => View(model);
        public IActionResult AttrCreate() => View();
        [HttpPost]
        public async Task<IActionResult> AttrCreate(ProductAttribute model)
        {
            var data = model.MapTo<InsertProductAttributeReqModel>();
            ResponseAlert(await _productattrService.InsertProductAttribute(data));
            return RedirectToAction(nameof(ProductAttributeList));
        }
        public async Task<IActionResult> AttrEdit(int Id)
        {
            return View((await _productattrService.GetProductAttributeById(new GetProductAttributeByIdReqModel(Id))).Data);
        }
        [HttpPost]
        public async Task<ActionResult> AttrEdit(ProductAttribute model)
        {
            var data = model.MapTo<UpdateProductAttributeReqModel>();
            ResponseAlert(await _productattrService.UpdateProductAttribute(data));
            return View(model);
        }
        public async Task<ActionResult> AttrDelete(int id)
        {
            ResponseAlert(await _productattrService.DeleteProductAttribute(new(id)));
            return RedirectToAction("ProductAttributeList");
        }
    }
}
