﻿using Business.Services.ProductAggregate.ProductAttributes;
using Business.Services.ProductAggregate.ProductAttributes.ProductAttributeServiceModel;
using Core.Utilities.Identity;
using Entities.Concrete.ProductAggregate;
using Entities.Others;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
namespace eCommerce.Areas.Admin.Controllers
{
    [AuthorizeControl("")]
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
        public async Task<IActionResult> ProductAttributeListJson(ProductAttribute model, DataTablesParam param) =>
             ToDataTableJson(await _productattrService.GetAllProductAttributes(
                new GetAllProductAttributes(param.PageIndex, param.PageSize, model.Name)), param);

        public IActionResult ProductAttributeList(ProductAttribute model) => View(model);
        public IActionResult AttrCreate() => View();
        [HttpPost]
        public async Task<IActionResult> AttrCreate(ProductAttribute model)
        {
            ResponseAlert(await _productattrService.InsertProductAttribute(model));
            return RedirectToAction(nameof(ProductAttributeList));
        }
        public async Task<IActionResult> AttrEdit(int Id)
        {
            return View((await _productattrService.GetProductAttributeById(new GetProductAttributeById(Id))).Data);
        }
        [HttpPost]
        public async Task<ActionResult> AttrEdit(ProductAttribute model)
        {
            ResponseAlert(await _productattrService.UpdateProductAttribute(model));
            return View(model);
        }
        public async Task<ActionResult> AttrDelete(int id)
        {
            ResponseAlert(await _productattrService.DeleteProductAttribute((await _productattrService.GetProductAttributeById(new GetProductAttributeById(id))).Data));
            return RedirectToAction("ProductAttributeList");
        }
    }
}
