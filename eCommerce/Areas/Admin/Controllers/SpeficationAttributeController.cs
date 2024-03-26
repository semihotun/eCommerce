using AutoMapper;
using Business.Services.SpeficationAggregate.SpecificationAttributeOptions;
using Business.Services.SpeficationAggregate.SpecificationAttributeOptions.SpecificationAttributeOptionServiceModel;
using Business.Services.SpeficationAggregate.SpecificationAttributes;
using Business.Services.SpeficationAggregate.SpecificationAttributes.SpecificationAttributeServiceModel;
using Entities.Concrete.SpeficationAggregate;
using Entities.Others;
using Entities.ViewModels.AdminViewModel.SpeficationAttribute;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
namespace eCommerce.Areas.Admin.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [Route("[area]/[controller]/[action]")]
    [Area("Admin")]
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
                new GetSpecificationAttributes(param.PageIndex, param.PageSize));
            return ToDataTableJson(query, param);
        }
        public IActionResult SpeficationAttributeList() => View(new SpecificationAttributeVM());
        [HttpPost]
        public IActionResult SpeficationAttributeList(SpecificationAttributeVM model) => View(model);
        public IActionResult SpeficationAttributeCreate() => View();
        [HttpPost]
        public async Task<IActionResult> SpeficationAttributeCreate(SpecificationAttributeVM model)
        {
            ResponseAlert(await _specificationAttributeService.InsertSpecificationAttribute(
                _mapper.Map<SpecificationAttributeVM, SpecificationAttribute>(model)));
            return RedirectToAction(nameof(SpeficationAttributeList));
        }
        public async Task<IActionResult> SpeficationAttributeEdit(int id) => View(
            _mapper.Map<SpecificationAttribute, SpecificationAttributeVM>(
                (await _specificationAttributeService.GetSpecificationAttributeById(new GetSpecificationAttributeById(id))).Data
                ));
        [HttpPost]
        public async Task<IActionResult> SpeficationAttributeEdit(SpecificationAttributeVM model)
        {
            ResponseAlert(await _specificationAttributeService.UpdateSpecificationAttribute(
                _mapper.Map<SpecificationAttributeVM, SpecificationAttribute>(model)));
            return RedirectToAction(nameof(SpeficationAttributeEdit), new { id = model.Id });
        }
        public async Task<IActionResult> SpeficationAttributeDelete(int id)
        {
            ResponseAlert(await _specificationAttributeService.DeleteSpecificationAttribute(
                (await _specificationAttributeService.GetSpecificationAttributeById(new GetSpecificationAttributeById(id))).Data));
            return RedirectToAction("SpeficationAttributeList");
        }
        #endregion
        #region SpeficationAttributeOption
        public async Task<IActionResult> SpeficationAttributeOptionListJson(SpecificationAttributeOptionVM model, DataTablesParam param)
            => ToDataTableJson(await _specificationAttributeOptionService.GetSpecificationAttributeOptionsBySpecificationAttribute(
                new GetSpecificationAttributeOptionsBySpecificationAttribute(model.SpecificationAttributeId, param.PageIndex, param.PageSize)),
                param);

        public IActionResult SpeficationAttributeOptionCreate() => View();
        [HttpPost]
        public async Task<IActionResult> SpeficationAttributeOptionCreate(SpecificationAttributeVM model)
        {
            model.SpecificationAttributeOptionModel.SpecificationAttributeId = model.Id;
            ResponseAlert(await _specificationAttributeOptionService.InsertSpecificationAttributeOption(model.SpecificationAttributeOptionModel));
            return RedirectToAction("SpeficationAttributeEdit", "SpeficationAttribute", new { model.Id });
        }
        [HttpGet]
        public async Task<IActionResult> SpeficationAttributeOptionEdit(int id)
        {
            return View(_mapper.Map<SpecificationAttributeOption, SpecificationAttributeOptionVM>((
                await _specificationAttributeOptionService.GetSpecificationAttributeOptionById(
                new GetSpecificationAttributeOptionById(id))).Data));
        }
        [HttpPost]
        public async Task<IActionResult> SpeficationAttributeOptionEdit(SpecificationAttributeOptionVM model)
        {
            var data = _mapper.Map<SpecificationAttributeOptionVM, SpecificationAttributeOption>(model);
            ResponseAlert(await _specificationAttributeOptionService.UpdateSpecificationAttributeOption(data));
            return RedirectToAction("SpeficationAttributeEdit", "SpeficationAttribute", new { Id = data.SpecificationAttributeId });
        }
        public async Task<IActionResult> SpeficationAttributeOptionDelete(int id)
        {
            var data = await _specificationAttributeOptionService.GetSpecificationAttributeOptionById(
                new GetSpecificationAttributeOptionById(id));
            ResponseAlert(await _specificationAttributeOptionService.DeleteSpecificationAttributeOption(data.Data));
            return RedirectToAction("SpeficationAttributeEdit", "SpeficationAttribute", new { Id = data.Data.SpecificationAttributeId });
        }
        #endregion
        #endregion
    }
}
