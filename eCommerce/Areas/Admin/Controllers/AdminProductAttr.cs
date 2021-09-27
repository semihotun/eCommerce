using AutoMapper;
using Business.Abstract;
using Business.Abstract.Categories;
using Business.Abstract.Products;
using Business.Abstract.Spefications;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Others;
using Entities.ViewModels.Admin;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerce.Areas.Admin.Controllers
{
    [Route("[area]/[controller]/[action]")]

    [Area("Admin")]
    public class AdminProductAttrController : AdminBaseController
    {
        private readonly IProductService _productService;
        private readonly IProductAttributeService _productattrService;
        private readonly ICategoryService _categoryService;
        private readonly IProductAttributeFormatter _productAttributeFormatter;
        private readonly ISpecificationAttributeService _specificationAttributeService;
        private readonly IMapper _mapper;
        public AdminProductAttrController(IProductService productService,
            IProductAttributeService productattrService, ICategoryService categoryService,
            IProductAttributeFormatter productAttributeFormatter, IMapper mapper,
            ISpecificationAttributeService specificationAttributeService)
        {
            this._productService = productService;
            this._productattrService = productattrService;
            this._categoryService = categoryService;
            this._productAttributeFormatter = productAttributeFormatter;
            this._mapper = mapper;
            this._specificationAttributeService = specificationAttributeService;
        }



        public async Task<IActionResult> ProductAttributeListJson(ProductAttributeModel Model, DataTablesParam Param)
        {
            var query =(await _productattrService.GetAllProductAttributes(
                pageIndex: Param.PageIndex,
                pageSize: Param.PageSize,
                name: Model.Name
                ));

            return ToDataTableJson(query,Param);
        }

        public IActionResult ProductAttributeList(ProductAttributeModel Model) => View(Model);


        public IActionResult AttrCreate() => View();


        [HttpPost]
        public async Task<IActionResult> AttrCreate(ProductAttributeModel Model)
        {
            var data = _mapper.Map<ProductAttributeModel, ProductAttribute>(Model);
            ResponseAlert(await _productattrService.InsertProductAttribute(data));

            return RedirectToAction("AttrEdit", "AdminProductAttr", new { Id = data.Id });
        }


        public async Task<IActionResult> AttrEdit(int Id)
        {
            var query =await _productattrService.GetProductAttributeById(Id);
            var data = _mapper.Map<ProductAttribute, ProductAttributeModel>(query.Data);

            return View(data);
        }

        [HttpPost]
        public async Task<ActionResult> AttrEdit(ProductAttributeModel Model)
        {
            var Data = _mapper.Map<ProductAttributeModel, ProductAttribute>(Model);
            ResponseAlert(await _productattrService.UpdateProductAttribute(Data));

            return View(Model);
        }

        public async Task<ActionResult> AttrDelete(int Id)
        {
            var query = (await _productattrService.GetProductAttributeById(Id)).Data;
            ResponseAlert(await _productattrService.DeleteProductAttribute(query));

            return RedirectToAction("ProductAttributeList");
        }

    }
}
