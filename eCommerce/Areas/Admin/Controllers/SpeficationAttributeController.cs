using Business.Services.SpeficationAggregate.SpecificationAttributeOptions.Commands;
using Business.Services.SpeficationAggregate.SpecificationAttributeOptions.Queries;
using Business.Services.SpeficationAggregate.SpeficationAttributes.Commands;
using Business.Services.SpeficationAggregate.SpeficationAttributes.Queries;
using Entities.Concrete;
using Entities.Extensions.AutoMapper;
using Entities.RequestModel.SpeficationAggregate.SpecificationAttributeOptions;
using Entities.RequestModel.SpeficationAggregate.SpecificationAttributes;
using Entities.ViewModels.AdminViewModel.SpeficationAttributes;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
namespace eCommerce.Areas.Admin.Controllers
{
    public class SpeficationAttributeController : AdminBaseController
    {
        #region Ctor
        private readonly ISpecificationAttributeCommandService _specificationAttributeCommandService;
        private readonly ISpecificationAttributeQueryService _specificationAttributeQueryService;
        private readonly ISpecificationAttributeOptionCommandService _specificationAttributeOptionCommandService;
        private readonly ISpecificationAttributeOptionQueryService _specificationAttributeOptionQueryService;
        public SpeficationAttributeController(ISpecificationAttributeCommandService specificationAttributeCommandService,
            ISpecificationAttributeQueryService specificationAttributeQueryService,
            ISpecificationAttributeOptionCommandService specificationAttributeOptionCommandService,
            ISpecificationAttributeOptionQueryService specificationAttributeOptionQueryService)
        {
            _specificationAttributeCommandService = specificationAttributeCommandService;
            _specificationAttributeQueryService = specificationAttributeQueryService;
            _specificationAttributeOptionCommandService = specificationAttributeOptionCommandService;
            _specificationAttributeOptionQueryService = specificationAttributeOptionQueryService;
        }
        #endregion
        #region Method
        #region SpeficationAttribute
        public async Task<IActionResult> SpeficationAttributeListJson(GetSpecificationAttributesReqModel request)
            => ToDataTableJson(await _specificationAttributeQueryService.GetSpecificationAttributes(request), request);
        public IActionResult SpeficationAttributeList() => View(new SpecificationAttributeVM());
        [HttpPost]
        public IActionResult SpeficationAttributeList(SpecificationAttributeVM model) => View(model);
        public IActionResult SpeficationAttributeCreate() => View();
        [HttpPost]
        public async Task<IActionResult> SpeficationAttributeCreate(SpecificationAttributeVM model)
        {
            var data = model.MapTo<SpecificationAttribute>();
            var mapper = data.MapTo<InsertSpecificationAttributeReqModel>();
            ResponseAlert(await _specificationAttributeCommandService.InsertSpecificationAttribute(mapper));
            return RedirectToAction(nameof(SpeficationAttributeList));
        }
        public async Task<IActionResult> SpeficationAttributeEdit(Guid id)
        {
            var data = (await _specificationAttributeQueryService.GetSpecificationAttributeById(new GetSpecificationAttributeByIdReqModel(id))).Data;
            var mapData = data.MapTo<SpecificationAttributeVM>();
            return View(mapData);
        }
        [HttpPost]
        public async Task<IActionResult> SpeficationAttributeEdit(SpecificationAttributeVM model)
        {
            var data = model.MapTo<UpdateSpecificationAttributeReqModel>();
            ResponseAlert(await _specificationAttributeCommandService.UpdateSpecificationAttribute(data));
            return RedirectToAction(nameof(SpeficationAttributeEdit), new { id = model.Id });
        }
        public async Task<IActionResult> SpeficationAttributeDelete(Guid id)
        {
            ResponseAlert(await _specificationAttributeCommandService.DeleteSpecificationAttribute(new(id)));
            return RedirectToAction("SpeficationAttributeList");
        }
        #endregion
        #region SpeficationAttributeOption
        public async Task<IActionResult> SpeficationAttributeOptionListJson(GetSpecificationAttributeOptionsBySpecificationAttributeReqModel model)
            => ToDataTableJson(await _specificationAttributeOptionQueryService.GetSpecificationAttributeOptionsBySpecificationAttribute(model), model);

        public IActionResult SpeficationAttributeOptionCreate() => View();
        [HttpPost]
        public async Task<IActionResult> SpeficationAttributeOptionCreate(SpecificationAttributeVM model)
        {
            model.SpecificationAttributeOptionModel.SpecificationAttributeId = model.Id;
            var mapdata = model.SpecificationAttributeOptionModel.MapTo<InsertSpecificationAttributeOptionReqModel>();
            ResponseAlert(await _specificationAttributeOptionCommandService.InsertSpecificationAttributeOption(mapdata));
            return RedirectToAction("SpeficationAttributeEdit", "SpeficationAttribute", new { model.Id });
        }
        [HttpGet]
        public async Task<IActionResult> SpeficationAttributeOptionEdit(Guid id)
        {
            var data = (await _specificationAttributeOptionQueryService.GetSpecificationAttributeOptionById(new(id))).Data;
            var mapdata = data.MapTo<SpecificationAttributeOptionVM>();
            return View(mapdata);
        }
        [HttpPost]
        public async Task<IActionResult> SpeficationAttributeOptionEdit(SpecificationAttributeOptionVM model)
        {
            var data = model.MapTo<UpdateSpecificationAttributeOptionReqModel>();
            ResponseAlert(await _specificationAttributeOptionCommandService.UpdateSpecificationAttributeOption(data));
            return RedirectToAction("SpeficationAttributeEdit", "SpeficationAttribute", new { Id = data.SpecificationAttributeId });
        }
        public async Task<IActionResult> SpeficationAttributeOptionDelete(Guid id)
        {
            var data = (await _specificationAttributeOptionQueryService.GetSpecificationAttributeOptionById(new(id))).Data;
            ResponseAlert(await _specificationAttributeOptionCommandService.DeleteSpecificationAttributeOption(new(id)));
            return RedirectToAction("SpeficationAttributeEdit", "SpeficationAttribute", new { Id = data!.SpecificationAttributeId });
        }
        #endregion
        #endregion
    }
}
