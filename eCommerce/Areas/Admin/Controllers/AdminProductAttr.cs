using Business.Services.ProductAggregate.ProductAttributes;
using Business.Services.ProductAggregate.ProductAttributes.ProductAttributeServiceModel;
using Entities.Concrete.ProductAggregate;
using Entities.Others;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace eCommerce.Areas.Admin.Controllers
{
    [Route("[area]/[controller]/[action]")]
    [ApiExplorerSettings(IgnoreApi = true)]
    [Area("Admin")]
    public class AdminProductAttrController : AdminBaseController
    {
        private readonly IProductAttributeService _productattrService;
        public AdminProductAttrController(
            IProductAttributeService productattrService
           )
        {
            this._productattrService = productattrService;
        }
        public async Task<IActionResult> ProductAttributeListJson(ProductAttribute model, DataTablesParam param)
        {
            var query =(await _productattrService.GetAllProductAttributes(new GetAllProductAttributes(param.PageIndex, param.PageSize, model.Name)));

            return ToDataTableJson(query,param);
        }

        public IActionResult ProductAttributeList(ProductAttribute model) => View(model);

        public IActionResult AttrCreate() => View();

        [HttpPost]
        public async Task<IActionResult> AttrCreate(ProductAttribute model)
        {       
            ResponseAlert(await _productattrService.InsertProductAttribute(model));

            return RedirectToAction("AttrEdit", "AdminProductAttr", new { Id = model.Id });
        }

        public async Task<IActionResult> AttrEdit(int Id)
        {
            var query =await _productattrService.GetProductAttributeById(new GetProductAttributeById(Id));
            
            return View(query.Data);
        }

        [HttpPost]
        public async Task<ActionResult> AttrEdit(ProductAttribute model)
        {
            ResponseAlert(await _productattrService.UpdateProductAttribute(model));

            return View(model);
        }

        public async Task<ActionResult> AttrDelete(int id)
        {
            var query = (await _productattrService.GetProductAttributeById(new GetProductAttributeById(id))).Data;
            ResponseAlert(await _productattrService.DeleteProductAttribute(query));

            return RedirectToAction("ProductAttributeList");
        }

    }
}
