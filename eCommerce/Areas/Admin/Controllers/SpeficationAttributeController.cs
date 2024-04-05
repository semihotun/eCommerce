using AutoMapper;
using Business.Services.SpeficationAggregate.SpecificationAttributeOptions;
using Business.Services.SpeficationAggregate.SpecificationAttributes;
using Entities.Concrete.SpeficationAggregate;
using Entities.Extensions.AutoMapper;
using Entities.Others;
using Entities.RequestModel.SpeficationAggregate.SpecificationAttributeOptions;
using Entities.RequestModel.SpeficationAggregate.SpecificationAttributes;
using Entities.ViewModels.AdminViewModel.SpeficationAttribute;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
namespace eCommerce.Areas.Admin.Controllers
{
    public class SpeficationAttributeController : AdminBaseController
    {
        #region Method
        private readonly ISpecificationAttributeService _specificationAttributeService;
        private readonly IMapper _mapper;
        private readonly ISpecificationAttributeOptionService _specificationAttributeOptionService;
        #endregion
        #region Ctor
        public SpeficationAttributeController(
            ISpecificationAttributeService specificationAttributeService,
            IMapper mapper,
            ISpecificationAttributeOptionService specificationAttributeOptionService)
        {
            _specificationAttributeService = specificationAttributeService;
            _mapper = mapper;
            _specificationAttributeOptionService = specificationAttributeOptionService;
        }
        #endregion
        #region Method
        #region SpeficationAttribute
        public async Task<IActionResult> SpeficationAttributeListJson(DataTablesParam param)
        {
            var query = await _specificationAttributeService.GetSpecificationAttributes(
                new (param.PageIndex, param.PageSize));
            return ToDataTableJson(query, param);
        }
        public IActionResult SpeficationAttributeList() => View(new SpecificationAttributeVM());
        [HttpPost]
        public IActionResult SpeficationAttributeList(SpecificationAttributeVM model) => View(model);
        public IActionResult SpeficationAttributeCreate() => View();
        [HttpPost]
        public async Task<IActionResult> SpeficationAttributeCreate(SpecificationAttributeVM model)
        {
            var data = _mapper.Map<SpecificationAttributeVM, SpecificationAttribute>(model);
            var mapper = data.MapTo<InsertSpecificationAttributeReqModel>();
            ResponseAlert(await _specificationAttributeService.InsertSpecificationAttribute(mapper));
            return RedirectToAction(nameof(SpeficationAttributeList));
        }
        public async Task<IActionResult> SpeficationAttributeEdit(int id)
        {
            var data = (await _specificationAttributeService.GetSpecificationAttributeById(new GetSpecificationAttributeByIdReqModel(id))).Data;
            var mapData = data.MapTo<SpecificationAttributeVM>();
            return View(mapData);
        }
        [HttpPost]
        public async Task<IActionResult> SpeficationAttributeEdit(SpecificationAttributeVM model)
        {
            var data = model.MapTo<UpdateSpecificationAttributeReqModel>();
            ResponseAlert(await _specificationAttributeService.UpdateSpecificationAttribute(data));
            return RedirectToAction(nameof(SpeficationAttributeEdit), new { id = model.Id });
        }
        public async Task<IActionResult> SpeficationAttributeDelete(int id)
        {
            ResponseAlert(await _specificationAttributeService.DeleteSpecificationAttribute(new(id)));
            return RedirectToAction("SpeficationAttributeList");
        }
        #endregion
        #region SpeficationAttributeOption
        public async Task<IActionResult> SpeficationAttributeOptionListJson(SpecificationAttributeOptionVM model, DataTablesParam param)
            => ToDataTableJson(await _specificationAttributeOptionService.GetSpecificationAttributeOptionsBySpecificationAttribute(
                new (model.SpecificationAttributeId, param.PageIndex, param.PageSize)),
                param);

        public IActionResult SpeficationAttributeOptionCreate() => View();
        [HttpPost]
        public async Task<IActionResult> SpeficationAttributeOptionCreate(SpecificationAttributeVM model)
        {
            model.SpecificationAttributeOptionModel.SpecificationAttributeId = model.Id;
            var mapdata = model.SpecificationAttributeOptionModel.MapTo<InsertSpecificationAttributeOptionReqModel>();
            ResponseAlert(await _specificationAttributeOptionService.InsertSpecificationAttributeOption(mapdata));
            return RedirectToAction("SpeficationAttributeEdit", "SpeficationAttribute", new { model.Id });
        }
        [HttpGet]
        public async Task<IActionResult> SpeficationAttributeOptionEdit(int id)
        {
            var data = (await _specificationAttributeOptionService.GetSpecificationAttributeOptionById(new(id))).Data;
            var mapdata = data.MapTo<SpecificationAttributeOptionVM>();
            return View(mapdata);
        }
        [HttpPost]
        public async Task<IActionResult> SpeficationAttributeOptionEdit(SpecificationAttributeOptionVM model)
        {
            var data = model.MapTo<UpdateSpecificationAttributeOptionReqModel>();
            ResponseAlert(await _specificationAttributeOptionService.UpdateSpecificationAttributeOption(data));
            return RedirectToAction("SpeficationAttributeEdit", "SpeficationAttribute", new { Id = data.SpecificationAttributeId });
        }
        public async Task<IActionResult> SpeficationAttributeOptionDelete(int id)
        {
            var data = (await _specificationAttributeOptionService.GetSpecificationAttributeOptionById(new(id))).Data;
            ResponseAlert(await _specificationAttributeOptionService.DeleteSpecificationAttributeOption(new(id)));
            return RedirectToAction("SpeficationAttributeEdit", "SpeficationAttribute", new { Id = data!.SpecificationAttributeId });
        }
        #endregion
        #endregion
    }
}
