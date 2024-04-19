using Business.Services.ProductAggregate.ProductAttributes.Commands;
using Business.Services.ProductAggregate.ProductAttributes.DtoQueries;
using Business.Services.ProductAggregate.ProductAttributes.Queries;
using Entities.Concrete;
using Entities.Extensions.AutoMapper;
using Entities.RequestModel.ProductAggregate.ProductAttributes;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
namespace eCommerce.Areas.Admin.Controllers
{
    public class AdminProductAttrController : AdminBaseController
    {
        private readonly IProductAttributeCommandService _productAttributeCommandService;
        private readonly IProductAttributeQueryService _productAttributeQueryService;
        private readonly IProductAttributeDtoQueryService _productAttributeDtoQueryService;

        public AdminProductAttrController(IProductAttributeCommandService productAttributeCommandService,
            IProductAttributeQueryService productAttributeQueryService,
            IProductAttributeDtoQueryService productAttributeDtoQueryService)
        {
            _productAttributeCommandService = productAttributeCommandService;
            _productAttributeQueryService = productAttributeQueryService;
            _productAttributeDtoQueryService = productAttributeDtoQueryService;
        }

        public async Task<IActionResult> ProductAttributeListJson(GetAllProductAttributesReqModel request) =>
             ToDataTableJson(await _productAttributeQueryService.GetAllProductAttributes(request), request);

        public IActionResult ProductAttributeList(ProductAttribute model) => View(model);
        public IActionResult AttrCreate() => View();
        [HttpPost]
        public async Task<IActionResult> AttrCreate(ProductAttribute model)
        {
            var data = model.MapTo<InsertProductAttributeReqModel>();
            ResponseAlert(await _productAttributeCommandService.InsertProductAttribute(data));
            return RedirectToAction(nameof(ProductAttributeList));
        }
        public async Task<IActionResult> AttrEdit(Guid Id)
        {
            return View((await _productAttributeQueryService.GetProductAttributeById(new GetProductAttributeByIdReqModel(Id))).Data);
        }
        [HttpPost]
        public async Task<ActionResult> AttrEdit(ProductAttribute model)
        {
            var data = model.MapTo<UpdateProductAttributeReqModel>();
            ResponseAlert(await _productAttributeCommandService.UpdateProductAttribute(data));
            return View(model);
        }
        public async Task<ActionResult> AttrDelete(Guid id)
        {
            ResponseAlert(await _productAttributeCommandService.DeleteProductAttribute(new(id)));
            return RedirectToAction("ProductAttributeList");
        }
    }
}
